using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using DFe.Utils;
using Newtonsoft.Json;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.DistribuicaoDFe;
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

        static string _EnderecoEmitente_UF = "";
        static string _cnpj = "";
        static string _nsu = "";
        static string _chnfe = "";
        static string _NuvemFiscal_SerialNumber = "";
        static string _PATH_SCHEMAS = "";
        static string _PATH_NUVEMFISCAL = "";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MessageBox.Show("Aqui");

            try
            {
                _EnderecoEmitente_UF = args[0];
                _cnpj = args[1];
                if ((!String.IsNullOrEmpty(args[2])) && (args[2] != "''")) { _nsu = args[2]; }
                _NuvemFiscal_SerialNumber = args[3];
                _PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\Schemas");
                _PATH_NUVEMFISCAL = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            System.IO.DirectoryInfo di = new DirectoryInfo(_PATH_NUVEMFISCAL);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            NuvemFiscal(_EnderecoEmitente_UF, _cnpj, _nsu, _chnfe);
        }

        public static RetornoNfeDistDFeInt NuvemFiscal(string EnderecoEmitente_UF,
                                                       string cnpj,
                                                       string nsu,
                                                       string chnfe)
        {
            var servicoNFe = new ServicosNFe(Configuracao());
            var retornoNFeDistDFe = servicoNFe.NfeDistDFeInteresse("0", cnpj, nsu, "0", chnfe);

            //if ((retornoNFeDistDFe != null) && (retornoNFeDistDFe.Retorno.loteDistDFeInt != null))
            //{
            //    foreach (loteDistDFeInt item in retornoNFeDistDFe.Retorno.loteDistDFeInt)
            //    {
            //        if (item.NfeProc != null)
            //        {
            //            item.NfeProc.SalvarArquivoXml(Path.Combine(_PATH_NUVEMFISCAL, "NF-e_", item.NfeProc.NFe.infNFe.Id.Substring(3), ".xml"));
            //        }
            //        else if (item.ResNFe != null)
            //        {
            //            cResNF _cResNF = new cResNF();
            //            _cResNF.chNFe = item.ResNFe.chNFe;
            //            _cResNF.CNPJ = item.ResNFe.CNPJ;
            //            _cResNF.CPF = item.ResNFe.CPF;
            //            _cResNF.xNome = item.ResNFe.xNome;
            //            _cResNF.IE = item.ResNFe.IE;
            //            _cResNF.dhEmi = item.ResNFe.dhEmi;
            //            _cResNF.tpNF = item.ResNFe.tpNF;
            //            _cResNF.vNF = item.ResNFe.vNF;
            //            _cResNF.digVal = item.ResNFe.digVal;
            //            _cResNF.dhRecbto = item.ResNFe.dhRecbto;
            //            _cResNF.nProt = item.ResNFe.nProt;
            //            _cResNF.cSitNFe = item.ResNFe.cSitNFe;

            //            var jsonString = JsonConvert.SerializeObject(_cResNF);

            //            StreamWriter valor = new StreamWriter(Path.Combine(_PATH_NUVEMFISCAL, "ResNFe_", item.ResNFe.chNFe, ".json"), true, Encoding.ASCII);
            //        }
            //    }
            //}

            return retornoNFeDistDFe;
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
