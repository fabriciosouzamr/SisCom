using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using DFe.Utils;
using Funcoes._Enum;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.NFe;
using System.Net;

namespace SisCom.Aplicacao.Classes
{
    public static class Zeus
    {
        public static AmbienteSistemas ambienteSistemas = AmbienteSistemas.Producao;
        public static string NuvemFiscal_SerialNumber;
        public static string PATH_SCHEMAS;

        private static ConfiguracaoServico Configuracao()
        {
            ConfiguracaoServico oConfig = new ConfiguracaoServico();
            System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
            Estado oEstado = new Estado();
            TipoCertificado tipoCertificado = TipoCertificado.A1Repositorio;

            oEstado = oEstado.SiglaParaEstado("GO");

            oConfig = ConfiguracaoServico.Instancia;

            switch (ambienteSistemas)
            {
                case AmbienteSistemas.Producao:
                    oConfig.tpAmb = DFe.Classes.Flags.TipoAmbiente.Producao;
                    break;
                case AmbienteSistemas.Homologacao:
                    oConfig.tpAmb = DFe.Classes.Flags.TipoAmbiente.Homologacao;
                    break;
                default:
                    CaixaMensagem.Informacao("Tipo de ambiente de transmissão não definido");
                    break;
            }

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
                    if (string.IsNullOrEmpty(NuvemFiscal_SerialNumber))
                    {
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        oConfig.Certificado.Serial = oCert.SerialNumber;
                    }
                    else
                    {
                        oConfig.Certificado.Serial = NuvemFiscal_SerialNumber;
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
            oConfig.ModeloDocumento  = DFe.Classes.Flags.ModeloDocumento.NFe;
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
            oConfig.DiretorioSchemas = PATH_SCHEMAS;
            oConfig.SalvarXmlServicos = false;
            //oConfig.DiretorioSalvarXml = FNC_Diretorio_Temporario()

            return oConfig;
        }

        public static NFe.Classes.nfeProc CarregarNFE_XML(ref string arquivoXml)
        {
            arquivoXml = Arquivo.CarregarArquivoXML();

            NFe.Classes.nfeProc _nfeProc = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(arquivoXml))
                    try
                    {
                        _nfeProc = new NFe.Classes.nfeProc().CarregarDeArquivoXml(arquivoXml);
                    }
                    catch (System.Exception)
                    {
                        _nfeProc = new NFe.Classes.nfeProc();
                        _nfeProc.NFe = new NFe.Classes.NFe().CarregarDeArquivoXml(arquivoXml);
                    }
            }
            catch (System.Exception)
            {
            }

            return _nfeProc;
        }

        public static RetornoNfeDistDFeInt NuvemFiscal(string EnderecoEmitente_UF,
                                                       string cnpj,
                                                       string nsu,
                                                       string chnfe)
        {
            var servicoNFe = new ServicosNFe(Configuracao());
            var retornoNFeDistDFe = servicoNFe.NfeDistDFeInteresse(EnderecoEmitente_UF, cnpj, nsu, "", chnfe);

            return retornoNFeDistDFe;
        }
    }
}
