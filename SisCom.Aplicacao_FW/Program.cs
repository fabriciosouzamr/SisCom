using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using DFe.Utils;
using MDFe.Classes.Retorno;
using MDFe.Damdfe.Base;
using MDFe.Damdfe.Fast;
using NFe.Classes;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.DistribuicaoDFe.Schemas;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Utils;
using NFe.Utils.NFe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using nfeProc = NFe.Classes.nfeProc;
using NFeZeus = NFe.Classes.NFe;

namespace SisCom.Aplicacao_FW
{
    internal static class Program
    {
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
        static string _XML = "";
        static string _TXT = "";
        static string _PATH_SCHEMAS = "";
        static string _PATH_NUVEMFISCAL_Vendas = "";
        static string _PATH_NUVEMFISCAL_MDFE = "";
        static string _PATH_DOCFISCAL = "";
        static string _PATH_ArquivoRelatorio = "";
        static string _nFeTipoEvento = "";
        static string _protocoloAutorizacao = "";
        static int _lote = 0;

        [STAThread]
        static void Main(string[] args)
        {
            //nuvemfiscal GO 26616809000136 1 1E7F6E6A89ADD10D
            //manifestar GO 31220702623061000130550010000004721385764234 02623061000130 210200 417B2205054DEFE4
            //protocolar MG 'D:\\SisCom\\Projeto\\SisCom.Aplicacao\\bin\\Debug\\net6.0-windows\\temp\\transmitir.xml' 00B8070A04D8A768A8
            //cartacorrecao MG 31221111831939000114550010000007201100007201 11831939000114 'D:\\SisCom\\Projeto\\SisCom.Aplicacao\\bin\\Debug\\net6.0-windows\\temp\\cartacorrecao.txt' 00B8070A04D8A768A8
            //cancelamento MG 31221111831939000114550010000007201100007202 11831939000114 'D:\\SisCom\\Projeto\\SisCom.Aplicacao\\bin\\Debug\\net6.0-windows\\temp\\cancelamento.txt' 00B8070A04D8A768A8 131225031170016
            //mdfeimprimir 21230248205505000119580010000000401522422396 transmitido

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\Schemas");
            _PATH_NUVEMFISCAL_Vendas = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal_Vendas");
            _PATH_NUVEMFISCAL_MDFE = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal_MDFe");
            _PATH_ArquivoRelatorio = Path.Combine(Directory.GetCurrentDirectory(), "Configuration\\MDFeRetrato.frx");

            if (String.IsNullOrEmpty(Properties.Settings.Default.PathDocumentoFiscal))
            { _PATH_DOCFISCAL = _PATH_NUVEMFISCAL_Vendas; }
            else
            { _PATH_DOCFISCAL = Properties.Settings.Default.PathDocumentoFiscal; }

            _Operacao = args[0];

            switch (_Operacao)
            {
                case "manifestar":
                    _EnderecoEmitente_UF = args[1];
                    _chaveacesso = args[2];
                    _cnpj = args[3];
                    _nFeTipoEvento = args[4];
                    _NuvemFiscal_SerialNumber = args[5];

                    Manifestar(_chaveacesso, _cnpj, (NFeTipoEvento)Convert.ToInt64(_nFeTipoEvento));

                    break;
                case "nuvemfiscal":
                    _PATH_NUVEMFISCAL_Vendas = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal_Compras");
                    _EnderecoEmitente_UF = args[1];
                    _cnpj = args[2];
                    if ((!String.IsNullOrEmpty(args[3])) && (args[3] != "''")) { _nsu = args[3]; }
                    _NuvemFiscal_SerialNumber = args[4];
                    NuvemFiscal(_EnderecoEmitente_UF, _cnpj, _nsu, _chnfe);

                    break;
                case "protocolar":
                    _EnderecoEmitente_UF = args[1];
                    _XML = args[2];
                    _NuvemFiscal_SerialNumber = args[3];
                    Protocolar();
                    break;
                case "cartacorrecao":
                    _EnderecoEmitente_UF = args[1];
                    _chaveacesso = args[2];
                    _cnpj = args[3];
                    _TXT = args[4];
                    _NuvemFiscal_SerialNumber = args[5];
                    _lote = Convert.ToInt16(args[6]);
                    CartaCorrecao();
                    break;
                case "cancelamento":
                    _EnderecoEmitente_UF = args[1];
                    _chaveacesso = args[2];
                    _cnpj = args[3];
                    _TXT = args[4];
                    _NuvemFiscal_SerialNumber = args[5];
                    _protocoloAutorizacao = args[6];
                    _lote = Convert.ToInt16(args[7]);
                    Cancelamento();
                    break;
                case "mdfeimprimir":
                    _chaveacesso = args[1];
                    MDFeImprimir(_chaveacesso,
                                 (args[2].ToUpper() == "ENCERRADO"),
                                 (args[2].ToUpper() == "CANCELADO"),
                                 false,
                                 "");
                    break;
                default:
                    break;
            }

            Application.Exit();
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

        public static void Protocolar()
        {
            try
            {
                var oNFe = new NFe.Classes.NFe().CarregarDeArquivoXml(_XML.Replace("'", ""));

                if (oNFe.infNFe.emit.CNPJ.Length == 13)
                { _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\Enviados\\0" + oNFe.infNFe.emit.CNPJ; }
                else
                { _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\Enviados\\" + oNFe.infNFe.emit.CNPJ; }

                _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\" + oNFe.infNFe.ide.dhEmi.Year + "\\" + oNFe.infNFe.ide.dhEmi.Month.ToString("00") + "\\" + oNFe.infNFe.ide.dhEmi.Day.ToString("00");

                if (!Directory.Exists(_PATH_DOCFISCAL)) Directory.CreateDirectory(_PATH_DOCFISCAL);

                _PATH_NUVEMFISCAL_Vendas = _PATH_DOCFISCAL;

                var servicoNFe = new ServicosNFe(Configuracao());
                var sNFe_Chave = oNFe.infNFe.Id.Substring(3);
                string retorno = "";
                string mensagem = "Sem protocolo";
                string cStat = "00";
                string protocolo = "00";

                var retornoConsulta = servicoNFe.NfeConsultaProtocolo(sNFe_Chave);

                if (retornoConsulta.Retorno.cStat == 217 /* Rejeicao: NF-e nao consta na base de dados da SEFAZ */)
                {
                    var nFeAutorizacao = servicoNFe.NFeAutorizacao(Convert.ToInt32("1"), IndicadorSincronizacao.Sincrono, new List<NFeZeus>(new NFeZeus[] { oNFe }), true);
                    retorno = nFeAutorizacao.RetornoStr;
                    bool consularprotocolo = false;

                    if (nFeAutorizacao.Retorno != null)
                    {
                        NFe.Servicos.ServicosNFe oNFe_Servico;
                        NFe.Servicos.Retorno.RetornoNfeConsultaProtocolo oNFe_Servico_Retorno;
                        NFe.Classes.nfeProc oNFe_Proc;

                        if (nFeAutorizacao.Retorno.protNFe != null)
                        {
                            oNFe_Proc = new nfeProc();
                            oNFe_Proc.NFe = oNFe;
                            oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                            oNFe_Proc.protNFe = nFeAutorizacao.Retorno.protNFe;
                            oNFe_Proc.versao = nFeAutorizacao.Retorno.versao;

                            if (nFeAutorizacao.Retorno.protNFe.infProt.cStat == 217 /* Rejeicao_NFeNaoConstaBaseDadosSEFAZ */ )
                            {
                                cStat = nFeAutorizacao.Retorno.protNFe.infProt.cStat.ToString();
                                mensagem = "NFe Não Consta na Base Dados do SEFAZ";
                            }
                            else if (nFeAutorizacao.Retorno.protNFe.infProt.xMotivo.IndexOf("Rejeicao:") > -1)
                            {
                                cStat = nFeAutorizacao.Retorno.protNFe.infProt.cStat.ToString();
                                mensagem = nFeAutorizacao.Retorno.protNFe.infProt.xMotivo;
                            }
                            else
                            {
                                if (oNFe_Proc.protNFe != null)
                                {
                                    protocolo = oNFe_Proc.protNFe.infProt.nProt;
                                    var sNFe_Arquivo = _PATH_NUVEMFISCAL_Vendas + sNFe_Chave + "-procNfe.xml";

                                    FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, sNFe_Arquivo);
                                }
                            }
                        }
                        else
                        {
                            consularprotocolo = true;
                        }

                        if (consularprotocolo)
                        {
                            for (var iCont = 1; iCont <= 5; iCont++)
                            {
                                try
                                {
                                    oNFe_Servico_Retorno = servicoNFe.NfeConsultaProtocolo(sNFe_Chave);

                                    oNFe_Proc = new nfeProc();
                                    oNFe_Proc.NFe = oNFe;
                                    oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                                    oNFe_Proc.protNFe = oNFe_Servico_Retorno.Retorno.protNFe;
                                    oNFe_Proc.versao = oNFe_Servico_Retorno.Retorno.versao;


                                    if (oNFe_Servico_Retorno.Retorno.cStat == 217 /* Rejeicao_NFeNaoConstaBaseDadosSEFAZ */ )
                                    {
                                        cStat = oNFe_Servico_Retorno.Retorno.cStat.ToString();
                                        mensagem = "NFe Não Consta na Base Dados do SEFAZ";
                                        break;
                                    }
                                    else if (iCont == 5)
                                    {
                                        cStat = oNFe_Servico_Retorno.Retorno.cStat.ToString();

                                        mensagem = oNFe_Servico_Retorno.Retorno.xMotivo;
                                    }
                                    else
                                    {
                                        if (oNFe_Proc.protNFe != null)
                                        {
                                            protocolo = oNFe_Proc.protNFe.infProt.nProt;
                                            var sNFe_Arquivo = _PATH_NUVEMFISCAL_Vendas + sNFe_Chave + "-procNfe.xml";

                                            FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, sNFe_Arquivo);
                                        }

                                        break;
                                    }

                                    iCont++;
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
                else
                {
                    NFe.Classes.nfeProc oNFe_Proc;
                    oNFe_Proc = new nfeProc();
                    oNFe_Proc.NFe = oNFe;
                    oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                    oNFe_Proc.protNFe = retornoConsulta.Retorno.protNFe;
                    oNFe_Proc.versao = retornoConsulta.Retorno.versao;
                    var sNFe_Arquivo = Path.Combine(_PATH_NUVEMFISCAL_Vendas, sNFe_Chave + "-procNfe.xml");
                    FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, sNFe_Arquivo);

                    cStat = retornoConsulta.Retorno.cStat.ToString();
                    mensagem = retornoConsulta.Retorno.xMotivo;
                    retorno = retornoConsulta.RetornoStr;

                    if ((retornoConsulta.Retorno != null) && 
                        (retornoConsulta.Retorno.protNFe != null) && 
                        (retornoConsulta.Retorno.protNFe.infProt != null) && 
                        !String.IsNullOrEmpty(retornoConsulta.Retorno.protNFe.infProt.nProt))
                        protocolo = retornoConsulta.Retorno.protNFe.infProt.nProt;
                }

                retorno = retorno.Replace("retConsSitNFe", "retEnviNFe");
                try
                { 
                    if (retorno.IndexOf("<dhRecbto>") != -1)
                    retorno = retorno.Replace("</verAplic>", "</verAplic>" + retorno.Substring(retorno.IndexOf("<dhRecbto>"), retorno.IndexOf("</dhRecbto>") - retorno.IndexOf("<dhRecbto>") + "<dhRecbto>".Length + 1)); 
                }
                catch (Exception) { }
               
                retorno = retorno.Replace("dhRecbto", "dhRegEvento");                
                retorno = retorno.Replace("</retEnviNFe>",
                                          "<Protocolo><cStat>" + cStat + "</cStat><xMotivo>" + mensagem + "</xMotivo><nProtocolo>" + protocolo + "</nProtocolo></Protocolo></retEnviNFe>");

                try
                { 
                    if (retorno.IndexOf("<Signature") != -1)
                    retorno = retorno.Replace(retorno.Substring(retorno.IndexOf("<Signature"), retorno.IndexOf("</Signature>") - retorno.IndexOf("<Signature") + ("</Signature>").Length), ""); 
                }
                catch (Exception) { }

                Console.Write(retorno);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public static void CartaCorrecao()
        {
            string sDescricaoCorrecao = "";

            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoRecepcaoEvento oNFe_Servico_RetornoRecepcaoEvento;

            oNFe_Servico = new ServicosNFe(Configuracao());

            _TXT = _TXT.Replace("\\\\", @"\").Replace("'", "");

            StreamReader srArquivo = new StreamReader(_TXT);

            while (srArquivo.Peek() != -1)
            {
                sDescricaoCorrecao = srArquivo.ReadLine();
            }

            srArquivo.Close();
            srArquivo.Dispose();

            oNFe_Servico_RetornoRecepcaoEvento = oNFe_Servico.RecepcaoEventoCartaCorrecao(1, _lote, _chaveacesso, sDescricaoCorrecao, _cnpj);
            Console.Write(oNFe_Servico_RetornoRecepcaoEvento.RetornoStr);
        }

        public static void Cancelamento()
        {
            string sDescricaoJustificativa= "";
            string mensagem = "Sem protocolo";
            string cStat = "00";
            string protocolo = "00";

            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoRecepcaoEvento oNFe_Servico_RetornoRecepcaoEvento;

            oNFe_Servico = new ServicosNFe(Configuracao());

            _TXT = _TXT.Replace("\\\\", @"\").Replace("'", "");

            StreamReader srArquivo = new StreamReader(_TXT);

            while (srArquivo.Peek() != -1)
            {
                sDescricaoJustificativa = srArquivo.ReadLine();
            }

            srArquivo.Close();
            srArquivo.Dispose();

            oNFe_Servico_RetornoRecepcaoEvento = oNFe_Servico.RecepcaoEventoCancelamento(1, _lote, _protocoloAutorizacao, _chaveacesso,sDescricaoJustificativa,_cnpj);


            cStat = oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat.ToString();
            mensagem = oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento[0].infEvento.xMotivo;
            protocolo = oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento[0].infEvento.tpEvento.ToString();

            var retorno = oNFe_Servico_RetornoRecepcaoEvento.RetornoStr;
            retorno = retorno.Replace("</retEnvEvento>",
                                      "<Protocolo><cStat>" + cStat + "</cStat><xMotivo>" + mensagem + "</xMotivo><nProtocolo>" + protocolo + "</nProtocolo></Protocolo></retEnvEvento>");
            Console.Write(retorno);
        }

        private static void MDFeImprimir(string Autorizacao_ChaveAutenticacao,
                                         bool DocumentoEncerrado = false,
                                         bool DocumentoCancelado = false,
                                         bool QuebrarLinhasObservacao = false,
                                         string Desenvolvedor = "'")
        {
            try
            {
                MDFeProcMDFe mdfe = null;

                var caminhoXml = Path.Combine(_PATH_NUVEMFISCAL_MDFE, Autorizacao_ChaveAutenticacao + "-mdfe-protMdfe.xml");

                try
                {
                    mdfe = FuncoesXml.ArquivoXmlParaClasse<MDFe.Classes.Retorno.MDFeProcMDFe>(caminhoXml);
                }
                catch (Exception ex)
                {
                    log($"Configurar impressão - {ex.Message}");
                }

                var rpt = new DamdfeFrMDFe(proc: mdfe,
                    config: new ConfiguracaoDamdfe()
                    {
                        //Logomarca = ImageToByte(pcbLogotipo.Image),
                        DocumentoEncerrado = DocumentoEncerrado,
                        DocumentoCancelado = DocumentoCancelado,
                        Desenvolvedor = Desenvolvedor,
                        QuebrarLinhasObservacao = QuebrarLinhasObservacao
                    },
                    arquivoRelatorio: _PATH_ArquivoRelatorio);

                Console.Write(caminhoXml);

                rpt.Visualizar(true);
                rpt.ExportarPdf(caminhoXml.Replace(".xml", ".pdf"));

                log($"Configurar impressão - {caminhoXml.Replace(".xml", ".pdf")}");
            }
            catch (Exception ex)
            {
                log($"Configurar impressão - {ex.Message}");
            }
        }

        private static ConfiguracaoServico Configuracao()
        {
            ConfiguracaoServico oConfig = new ConfiguracaoServico();
            System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
            Estado oEstado = new Estado();
            TipoCertificado tipoCertificado = TipoCertificado.A1Repositorio;

            oEstado = oEstado.SiglaParaEstado(_EnderecoEmitente_UF);

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
            oConfig.DiretorioSalvarXml = _PATH_NUVEMFISCAL_Vendas;

            return oConfig;
        }

        private static void log(string texto)
        {
            StreamWriter x;

            x = File.CreateText(Path.Combine(_PATH_NUVEMFISCAL_MDFE, "Aplicacao_FW_log.txt"));
            x.WriteLine(texto);
            x.Close();
        }
    }
}