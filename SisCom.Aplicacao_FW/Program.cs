using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using DFe.Utils;
using Newtonsoft.Json;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.DistribuicaoDFe;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SisCom.Aplicacao_FW
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 
        class cResNF
        {
            public string chNFe { get; set; }
            public string CNPJ { get; set; }
            public string CPF { get; set; }
            public string xNome { get; set; }
            public string IE { get; set; }
            public DateTime dhEmi { get; set; }
            public byte tpNF { get; set; }
            public decimal vNF { get; set; }
            public string digVal { get; set; }
            public DateTime dhRecbto { get; set; }
            public ulong nProt { get; set; }
            public byte cSitNFe { get; set; }

        }

        static string _Operacao = "";
        static string _EnderecoEmitente_UF = "";
        static string _cnpj = "";
        static string _nsu = "";
        static string _chnfe = "";
        static string _chaveacesso = "";
        static string _NuvemFiscal_SerialNumber = "";
        static string _PATH_SCHEMAS = "";
        static string _PATH_NUVEMFISCAL = "";
        static string _nFeTipoEvento = "";

        [STAThread]
        static void Main(string[] args)
        {
            //nuvemfiscal GO 26616809000136 1 1E7F6E6A89ADD10D
            //manifestar 31220702623061000130550010000004721385764234 02623061000130 210200 417B2205054DEFE4

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\Schemas");
            _PATH_NUVEMFISCAL = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal");

            try
            {
                _Operacao = args[0];

                switch (_Operacao)
                {
                    case "manifestar":
                        _chaveacesso = args[1];
                        _cnpj = args[2];
                        _nFeTipoEvento = args[3];
                        _NuvemFiscal_SerialNumber = args[4];

                        Manifestar(_chaveacesso, _cnpj, (NFeTipoEvento)Convert.ToInt64(_nFeTipoEvento));

                        break;
                    case "nuvemfiscal":
                        _EnderecoEmitente_UF = args[1];
                        _cnpj = args[2];
                        if ((!String.IsNullOrEmpty(args[3])) && (args[3] != "''")) { _nsu = args[3]; }
                        _NuvemFiscal_SerialNumber = args[4];

                        System.IO.DirectoryInfo di = new DirectoryInfo(_PATH_NUVEMFISCAL);

                        NuvemFiscal(_EnderecoEmitente_UF, _cnpj, _nsu, _chnfe);

                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public static void NuvemFiscal(string EnderecoEmitente_UF,
                                       string cnpj,
                                       string nsu,
                                       string chnfe)
        {
            try
            {
                var servicoNFe = new ServicosNFe(Configuracao());
                var retornoNFeDistDFe = servicoNFe.NfeDistDFeInteresse("0", cnpj, nsu, "0", chnfe);

                Console.Write(retornoNFeDistDFe.RetornoStr);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public static void Manifestar(string chaveacesso, 
                                      string cnpj, 
                                      NFeTipoEvento nFeTipoEvento)
        {
            try
            {
                var servicoNFe = new ServicosNFe(Configuracao());
                var retornoNFeDistDFe = servicoNFe.RecepcaoEventoManifestacaoDestinatario(int.Parse("1"),
                                                                                          int.Parse("1"),
                                                                                          chaveacesso,
                                                                                          nFeTipoEvento,
                                                                                          cnpj);
                Console.Write(retornoNFeDistDFe.RetornoStr);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private static ConfiguracaoServico Configuracao()
        {
            ConfiguracaoServico oConfig = new ConfiguracaoServico();
            System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
            Estado oEstado = new Estado();
            TipoCertificado tipoCertificado = TipoCertificado.A1Repositorio;

            oEstado = oEstado.SiglaParaEstado("GO");

            oConfig = ConfiguracaoServico.Instancia;
            oConfig.tpAmb = DFe.Classes.Flags.TipoAmbiente.Producao;
            oConfig.tpEmis = TipoEmissao.teNormal;
            oConfig.ProtocoloDeSeguranca = ServicePointManager.SecurityProtocol;

            oConfig.Certificado = new ConfiguracaoCertificado();

            switch (tipoCertificado)
            {
                case TipoCertificado.A1Arquivo:
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A1Arquivo;
                    oConfig.Certificado.Arquivo = ""; // sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO;
                    oConfig.Certificado.Senha = ""; // sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA;
                    break;
                case TipoCertificado.A1ByteArray:
                    oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A1ByteArray;
                    oConfig.Certificado.ArrayBytesArquivo = oCert.GetRawCertData();
                    oConfig.Certificado.Serial = oCert.GetSerialNumberString();
                    break;
                case TipoCertificado.A1Repositorio:
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A1Repositorio;
                    if (string.IsNullOrEmpty(_NuvemFiscal_SerialNumber))
                    {
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        oConfig.Certificado.Serial = oCert.SerialNumber;
                    }
                    else
                    {
                        oConfig.Certificado.Serial = _NuvemFiscal_SerialNumber;
                    }
                    break;
                case TipoCertificado.A3:
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A3;
                    break;
            }

            oConfig.Certificado.CacheId = "58A13AD9C6A41D4B";
            oConfig.Certificado.ManterDadosEmCache = false;
            oConfig.Certificado.SignatureMethodSignedXml = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            oConfig.Certificado.DigestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1";
            oConfig.TimeOut = 30000;
            oConfig.cUF = oEstado;
            oConfig.tpEmis = TipoEmissao.teNormal;
            oConfig.ModeloDocumento = DFe.Classes.Flags.ModeloDocumento.NFe;
            oConfig.VersaoLayout = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoRecepcaoEventoCceCancelamento = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoRecepcaoEventoEpec = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoRecepcaoEventoManifestacaoDestinatario = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeRecepcao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeRetRecepcao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeConsultaCadastro = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeInutilizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeConsultaProtocolo = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeStatusServico = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeRetAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeDistribuicaoDFe = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoNfeConsultaDest = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeDownloadNF = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfceAministracaoCSC = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.ProtocoloDeSeguranca = SecurityProtocolType.Tls12;
            oConfig.DiretorioSchemas = _PATH_SCHEMAS;
            oConfig.SalvarXmlServicos = true;
            oConfig.DiretorioSalvarXml = _PATH_NUVEMFISCAL;

            return oConfig;
        }
    }
}