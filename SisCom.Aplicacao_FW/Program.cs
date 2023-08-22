using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using DFe.Utils;
using MDFe.Classes.Retorno;
using MDFe.Damdfe.Base;
using MDFe.Damdfe.Fast;
using NFe.Classes;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Utils;
using NFe.Utils.NFe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
//using static System.Net.WebRequestMethods;
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

        #region variaveis
        static string _Operacao = "";
        static string _EnderecoEmitente_UF = "";
        static string _cnpj = "";
        static string _nsu = "";
        static string _chnfe = "";
        static string _chaveacesso = "";
        static string _NuvemFiscal_SerialNumber = "";
        static string _recibo = "";
        static string _XML = "";
        static string _TXT = "";
        static string _PATH_DOCFISCAL = "";
        static string _PATH = "";
        static string _PATH_SCHEMAS = "";
        static string _PATH_NUVEMFISCAL_Vendas = "";
        static string _PATH_NUVEMFISCAL_Compras = "";
        static string _PATH_NUVEMFISCAL_MDFE = "";
        static string _PATH_NUVEMFISCAL_Config = "";
        static string _PATH_ArquivoRelatorio = "";
        static string _nFeTipoEvento = "";
        static string _protocoloAutorizacao = "";
        static int _lote = 0;
        #endregion

        [STAThread]
        static void Main(string[] args)
        {
            //nuvemfiscal GO 26616809000136 1 1E7F6E6A89ADD10D
            //manifestar GO 31220702623061000130550010000004721385764234 02623061000130 210200 417B2205054DEFE4
            //transmitir GO 'D:\\SisCom\\transmitir.xml' 7653D23A586C3E6F 00 49535361000121
            //cartacorrecao MG 31221111831939000114550010000007201100007201 11831939000114 'D:\\SisCom\\Projeto\\SisCom.Aplicacao\\bin\\Debug\\net6.0-windows\\temp\\cartacorrecao.txt' 00B8070A04D8A768A8
            //cancelamento MG 31221111831939000114550010000007201100007202 11831939000114 'D:\\SisCom\\Projeto\\SisCom.Aplicacao\\bin\\Debug\\net6.0-windows\\temp\\cancelamento.txt' 00B8070A04D8A768A8 131225031170016
            //mdfeimprimir 21230248205505000119580010000000401522422396 transmitido

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _PATH = Path.Combine(Directory.GetCurrentDirectory(), "Externos");
            _PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\Schemas");
            _PATH_NUVEMFISCAL_Vendas = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal_Vendas");
            _PATH_NUVEMFISCAL_MDFE = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal_MDFe");
            _PATH_NUVEMFISCAL_Compras = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\\\NuvemFiscal_Compras");
            _PATH_ArquivoRelatorio = Path.Combine(Directory.GetCurrentDirectory(), "Configuration\\MDFeRetrato.frx");

            if (!System.IO.Directory.Exists(_PATH))
                System.IO.Directory.CreateDirectory(_PATH);
            if (!System.IO.Directory.Exists(_PATH_SCHEMAS))
                System.IO.Directory.CreateDirectory(_PATH_SCHEMAS);
            if (!System.IO.Directory.Exists(_PATH_NUVEMFISCAL_Vendas))
                System.IO.Directory.CreateDirectory(_PATH_NUVEMFISCAL_Vendas);
            if (!System.IO.Directory.Exists(_PATH_NUVEMFISCAL_MDFE))
                System.IO.Directory.CreateDirectory(_PATH_NUVEMFISCAL_MDFE);
            if (!System.IO.Directory.Exists(_PATH_NUVEMFISCAL_Compras))
                System.IO.Directory.CreateDirectory(_PATH_NUVEMFISCAL_Compras);

            try
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.PathDocumentoFiscal))
                { _PATH_DOCFISCAL = Properties.Settings.Default.PathDocumentoFiscal; }
            }
            catch (Exception)
            {
            }

            if (!System.IO.Directory.Exists(_PATH_DOCFISCAL))
            {
                MessageBox.Show("É necessário informar o diretório XML na Nuvem Fiscal");
                Application.Exit();
            }

            _Operacao = args[0];

            switch (_Operacao)
            {
                case "manifestar":
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_Vendas;
                    _EnderecoEmitente_UF = args[1];
                    _chaveacesso = args[2];
                    _cnpj = args[3];
                    _nFeTipoEvento = args[4];
                    _NuvemFiscal_SerialNumber = args[5];
                    Manifestar(_chaveacesso, _cnpj, (NFeTipoEvento)Convert.ToInt64(_nFeTipoEvento));
                    break;
                case "nuvemfiscal":
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_Compras;
                    _EnderecoEmitente_UF = args[1];
                    _cnpj = args[2];
                    if ((!String.IsNullOrEmpty(args[3])) && (args[3] != "''")) { _nsu = args[3]; }
                    _NuvemFiscal_SerialNumber = args[4];
                    NuvemFiscal(_EnderecoEmitente_UF, _cnpj, _nsu, _chnfe);
                    break;
                case "transmitir":
                case "protocolar":
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_Vendas;
                    _EnderecoEmitente_UF = args[1];
                    _XML = args[2];
                    _NuvemFiscal_SerialNumber = args[3];
                    _cnpj = args[4];
                    _chaveacesso = args[5];
                    _recibo = args[6];
                    Protocolar();
                    break;
                case "cartacorrecao":
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_Vendas;
                    _EnderecoEmitente_UF = args[1];
                    _chaveacesso = args[2];
                    _cnpj = args[3];
                    _TXT = args[4];
                    _NuvemFiscal_SerialNumber = args[5];
                    _lote = Convert.ToInt16(args[6]);
                    CartaCorrecao();
                    break;
                case "cancelamento":
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_Vendas;
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
                    _PATH_NUVEMFISCAL_Config = _PATH_NUVEMFISCAL_MDFE;
                    _chaveacesso = args[1];
                    _cnpj = args[2];
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

        private static string path_DOCFISCAL_Validar(string processo, int ano, int mes, string arquivo)
        {
            _PATH_DOCFISCAL = Properties.Settings.Default.PathDocumentoFiscal;
            _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\" + _cnpj + "\\" + processo + "\\" + ano.ToString() + "\\" + mes.ToString("00");

            if (!System.IO.Directory.Exists(_PATH_DOCFISCAL))
                System.IO.Directory.CreateDirectory(_PATH_DOCFISCAL);

            return _PATH_DOCFISCAL + "\\" + arquivo;
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
            catch (Exception ex)
            {
                log($"Nuvem Fiscal - {ex.Message}");
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
            catch (Exception ex)
            {
                log($"Manifestar - {ex.Message}");
            }
        }

        class cConsulta
        {
            public int cStat { get; set; }
            public NFe.Classes.Protocolo.protNFe protNFe { get; set; }
            public string versao { get; set; }
            public string xMotivo { get; set; }
            public string RetornoStr { get; set; }
        }

        public static void Protocolar()
        {
            try
            {
                var oNFe = new NFe.Classes.NFe().CarregarDeArquivoXml(_XML.Replace("'", ""));

                var servicoNFe = new ServicosNFe(Configuracao());
                string retorno = "";
                string mensagem = "Pendente";
                string cStat = "00";
                string protocolo = "00";
                cConsulta consulta = new cConsulta();

                if (String.IsNullOrEmpty(_chaveacesso))
                    _chaveacesso = oNFe.infNFe.Id.Substring(3);

                if (String.IsNullOrEmpty(_recibo))
                    _recibo = "00";

                if (_Operacao == "protocolar")
                {
                    if (_recibo != "00")
                    {
                        var retornoConsulta = servicoNFe.NFeRetAutorizacao(_recibo);

                        consulta.cStat = retornoConsulta.Retorno.cStat;
                        consulta.versao = retornoConsulta.Retorno.versao;
                        consulta.xMotivo = retornoConsulta.Retorno.xMotivo;
                        consulta.RetornoStr = retornoConsulta.RetornoStr;

                        if (retornoConsulta.Retorno.protNFe.Any())
                        {
                            consulta.protNFe = retornoConsulta.Retorno.protNFe.FirstOrDefault();
                        }
                    }

                    if ((_recibo == "00") || (consulta.xMotivo.Contains("Rejeicao:")) || (consulta.protNFe != null && consulta.protNFe.infProt.xMotivo.Contains("Rejeicao:")))
                    {
                        var retornoConsulta = servicoNFe.NfeConsultaProtocolo(_chaveacesso);

                        consulta.cStat = retornoConsulta.Retorno.cStat;
                        consulta.versao = retornoConsulta.Retorno.versao;
                        consulta.xMotivo = retornoConsulta.Retorno.xMotivo;
                        consulta.RetornoStr = retornoConsulta.RetornoStr;

                        if (retornoConsulta.Retorno.protNFe != null)
                            consulta.protNFe = retornoConsulta.Retorno.protNFe;
                    }
                    
                }

                if ((_Operacao == "transmitir")  || (consulta.xMotivo.Contains("Rejeicao:")) || (consulta.protNFe != null && consulta.protNFe.infProt.xMotivo.Contains("Rejeicao:")))
                {
                    var nFeAutorizacao = servicoNFe.NFeAutorizacao(Convert.ToInt32("1"), IndicadorSincronizacao.Assincrono, new List<NFeZeus>(new NFeZeus[] { oNFe }), true);
                    retorno = nFeAutorizacao.RetornoStr;
                    bool consularprotocolo = false;

                    if (nFeAutorizacao.Retorno != null)
                    {
                        NFe.Servicos.ServicosNFe oNFe_Servico;
                        NFe.Servicos.Retorno.RetornoNfeConsultaProtocolo oNFe_Servico_Retorno;
                        NFe.Classes.nfeProc oNFe_Proc;

                        if (nFeAutorizacao.Retorno.infRec != null)
                        _recibo = nFeAutorizacao.Retorno.infRec.nRec.ToString();

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
                                    ProtocolarSalvar(oNFe, consulta);
                                }
                            }
                        }
                        else
                        {
                            if (nFeAutorizacao.Retorno.cStat == 656)
                            {
                                cStat = nFeAutorizacao.Retorno.cStat.ToString();
                                mensagem = nFeAutorizacao.Retorno.xMotivo;
                            }
                            else
                                consularprotocolo = true;
                        }

                        if (consularprotocolo)
                        {
                            for (var iCont = 1; iCont <= 5; iCont++)
                            {
                                try
                                {
                                    //oNFe_Servico_Retorno = servicoNFe.NfeConsultaProtocolo(sNFe_Chave);

                                    //oNFe_Proc = new nfeProc();
                                    //oNFe_Proc.NFe = oNFe;
                                    //oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                                    //oNFe_Proc.protNFe = oNFe_Servico_Retorno.Retorno.protNFe;
                                    //oNFe_Proc.versao = oNFe_Servico_Retorno.Retorno.versao;

                                    //if (oNFe_Servico_Retorno.Retorno.cStat == 217 /* Rejeicao_NFeNaoConstaBaseDadosSEFAZ */ )
                                    //{
                                    //    cStat = oNFe_Servico_Retorno.Retorno.cStat.ToString();
                                    //    mensagem = "NFe Não Consta na Base Dados do SEFAZ";
                                    //    break;
                                    //}
                                    //else if (iCont == 5)
                                    //{
                                    //    cStat = oNFe_Servico_Retorno.Retorno.cStat.ToString();
                                    //    mensagem = oNFe_Servico_Retorno.Retorno.xMotivo;
                                    //}
                                    //else
                                    //{
                                    //    if (oNFe_Proc.protNFe != null)
                                    //    {
                                    //        protocolo = oNFe_Proc.protNFe.infProt.nProt;
                                    //        var sNFe_Arquivo = _PATH_NUVEMFISCAL_Vendas + sNFe_Chave + "-procNfe.xml";

                                    //        FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, sNFe_Arquivo);
                                    //    }

                                    //    break;
                                    //}

                                    Thread.Sleep(1000);

                                    var retornoConsulta = servicoNFe.NFeRetAutorizacao(_recibo);

                                    consulta.cStat = retornoConsulta.Retorno.cStat;
                                    consulta.versao = retornoConsulta.Retorno.versao;
                                    consulta.xMotivo = retornoConsulta.Retorno.xMotivo;
                                    consulta.RetornoStr = retornoConsulta.RetornoStr;

                                    if (retornoConsulta.Retorno.protNFe.Any())
                                    {
                                        consulta.protNFe = retornoConsulta.Retorno.protNFe.FirstOrDefault();
                                    }

                                    if (retornoConsulta.Retorno.cStat == 217 /* Rejeicao_NFeNaoConstaBaseDadosSEFAZ */ )
                                    {
                                        cStat = retornoConsulta.Retorno.cStat.ToString();
                                        mensagem = "NFe Não Consta na Base Dados do SEFAZ";
                                        break;
                                    }
                                    else if (retornoConsulta.Retorno.cStat == 104 /* Lote processado */ )
                                    {
                                        if ((retornoConsulta.Retorno.protNFe.Any()) && ((retornoConsulta.Retorno.protNFe.Count != 0)))
                                        {
                                            cStat = retornoConsulta.Retorno.protNFe.FirstOrDefault().infProt.cStat.ToString();
                                            mensagem = retornoConsulta.Retorno.protNFe.FirstOrDefault().infProt.xMotivo;
                                            protocolo = retornoConsulta.Retorno.protNFe.FirstOrDefault().infProt.nProt;
                                        }
                                        else
                                        {
                                            cStat = retornoConsulta.Retorno.cStat.ToString();
                                            mensagem = retornoConsulta.Retorno.xMotivo;
                                        }
                                        break;
                                    }
                                    else if (iCont == 5)
                                    {
                                        cStat = retornoConsulta.Retorno.cStat.ToString();
                                        mensagem = retornoConsulta.Retorno.xMotivo;
                                    }
                                    else
                                    {
                                        if (consulta.protNFe != null)
                                        {
                                            protocolo = consulta.protNFe.infProt.nProt;
                                            ProtocolarSalvar(oNFe, consulta);
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
                        else
                        {
                            mensagem = consulta.xMotivo;
                            cStat = consulta.cStat.ToString();
                        }
                    }
                }
                else
                {
                    if (consulta.protNFe == null)
                    {
                        mensagem = consulta.xMotivo;
                        cStat = consulta.cStat.ToString();
                    }
                    else
                    {
                        mensagem = consulta.protNFe.infProt.xMotivo;
                        cStat = consulta.protNFe.infProt.cStat.ToString();
                    }

                    retorno = consulta.RetornoStr;
                    protocolo = consulta.protNFe.infProt.nProt;
                }

                if ((protocolo == null) || (protocolo == "00"))
                {
                    protocolo = " ";
                }
                else
                {
                    ProtocolarSalvar(oNFe, consulta);

                    cStat = "100";
                    mensagem = consulta.xMotivo;
                    retorno = consulta.RetornoStr;

                    if ((consulta.protNFe != null) &&
                        (consulta.protNFe.infProt != null))
                    {
                        if (!String.IsNullOrEmpty(consulta.protNFe.infProt.nProt))
                            protocolo = consulta.protNFe.infProt.nProt;

                        cStat = consulta.protNFe.infProt.cStat.ToString();
                        mensagem = consulta.protNFe.infProt.xMotivo;
                    }
                    else
                    {
                        mensagem = consulta.xMotivo;
                        cStat = consulta.cStat.ToString();
                    }
                }

                retorno = retorno.Replace("retConsSitNFe", "retEnviNFe");
                retorno = retorno.Replace("retConsReciNFe", "retEnviNFe");
                try
                { 
                    if (retorno.IndexOf("<dhRecbto>") != -1)
                    retorno = retorno.Replace("</verAplic>", "</verAplic>" + retorno.Substring(retorno.IndexOf("<dhRecbto>"), retorno.IndexOf("</dhRecbto>") - retorno.IndexOf("<dhRecbto>") + "<dhRecbto>".Length + 1).Replace("dhRecbto", "dhRegEvento")); 
                }
                catch (Exception) { }
               
                retorno = retorno.Replace("</retEnviNFe>",
                                          "<Protocolo><cStat>" + cStat + "</cStat><xMotivo>" + mensagem + "</xMotivo><nProtocolo>" + protocolo + "</nProtocolo></Protocolo><nRecibo>" + _recibo + "</nRecibo></retEnviNFe>");

                try
                { 
                    if (retorno.IndexOf("<Signature") != -1)
                    retorno = retorno.Replace(retorno.Substring(retorno.IndexOf("<Signature"), retorno.IndexOf("</Signature>") - retorno.IndexOf("<Signature") + ("</Signature>").Length), ""); 
                }
                catch (Exception) { }

                Console.Write(retorno);
            }
            catch (Exception ex)
            {
                log($"Protocolocar - {ex.Message}"); 
            }
        }

        static void ProtocolarSalvar(NFe.Classes.NFe oNFe, cConsulta consulta)
        {
            NFe.Classes.nfeProc oNFe_Proc;
            oNFe_Proc = new nfeProc();
            oNFe_Proc.NFe = oNFe;
            oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
            oNFe_Proc.protNFe = consulta.protNFe;
            oNFe_Proc.versao = consulta.versao;
            FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, path_DOCFISCAL_Validar("NF-e",
                                                                             consulta.protNFe.infProt.dhRecbto.Year,
                                                                             consulta.protNFe.infProt.dhRecbto.Month,
                                                                             _chaveacesso + "-procNfe.xml"));
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
            var retorno = String.Empty;

            try
            {
                string sDescricaoJustificativa = "";
                string mensagem;
                string cStat;
                string protocolo;

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

                oNFe_Servico_RetornoRecepcaoEvento = oNFe_Servico.RecepcaoEventoCancelamento(1, _lote, _protocoloAutorizacao, _chaveacesso, sDescricaoJustificativa, _cnpj);

                cStat = oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat.ToString();
                mensagem = oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento[0].infEvento.xMotivo;
                protocolo = oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento[0].infEvento.tpEvento.ToString();

                retorno = oNFe_Servico_RetornoRecepcaoEvento.RetornoStr;
                retorno = retorno.Replace("</retEnvEvento>",
                                          "<Protocolo><cStat>" + cStat + "</cStat><xMotivo>" + mensagem + "</xMotivo><nProtocolo>" + protocolo + "</nProtocolo></Protocolo></retEnvEvento>");
            }
            catch (Exception ex)
            {
                retorno = "<retEnvEvento><idLote>0</idLote><tpAmb>1</tpAmb><verAplic>Teste</verAplic><cOrgao>0</cOrgao><cStat>000</cStat><xMotivo>" + ex.Message + "</xMotivo></retEnvEvento>";
            }

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

                var caminhoXml = Path.Combine(_PATH_NUVEMFISCAL_Vendas, Autorizacao_ChaveAutenticacao + "-mdfe-protMdfe.xml");

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
                
                FileInfo fileInfo = new FileInfo(caminhoXml);
                rpt.ExportarPdf(path_DOCFISCAL_Validar("MDF-e", mdfe.MDFe.InfMDFe.Ide.DhEmi.Year, mdfe.MDFe.InfMDFe.Ide.DhEmi.Month, fileInfo.Name.Replace(".xml", ".pdf")));

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
            oConfig.ProtocoloDeSeguranca = SecurityProtocolType.Tls12;
            oConfig.Certificado = new ConfiguracaoCertificado();

            switch (tipoCertificado)
            {
                case TipoCertificado.A1Arquivo:
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A1Arquivo;
                    oConfig.Certificado.Arquivo = ""; // sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO;
                    oConfig.Certificado.Senha = ""; // sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA;
                    break;
                case TipoCertificado.A1ByteArray:
                    //oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                    //oConfig.Certificado.TipoCertificado = TipoCertificado.A1ByteArray;
                    //oConfig.Certificado.ArrayBytesArquivo = oCert.GetRawCertData();
                    //oConfig.Certificado.Serial = oCert.GetSerialNumberString();
                    break;
                case TipoCertificado.A1Repositorio:
                    oConfig.Certificado.TipoCertificado = TipoCertificado.A1Repositorio;
                    if (string.IsNullOrEmpty(_NuvemFiscal_SerialNumber))
                    {
                        //oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        //oConfig.Certificado.Serial = oCert.SerialNumber;
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
            oConfig.VersaoRecepcaoEventoEpec = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoRecepcaoEventoManifestacaoDestinatario = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeRecepcao = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoNfeRetRecepcao = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoNfeConsultaCadastro = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeInutilizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeConsultaProtocolo = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfeStatusServico = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeRetAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNFeDistribuicaoDFe = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoNfeConsultaDest = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.VersaoNfeDownloadNF = DFe.Classes.Flags.VersaoServico.Versao400;
            oConfig.VersaoNfceAministracaoCSC = DFe.Classes.Flags.VersaoServico.Versao100;
            oConfig.ProtocoloDeSeguranca = SecurityProtocolType.Tls12;
            oConfig.DiretorioSchemas = _PATH_SCHEMAS;
            oConfig.SalvarXmlServicos = true;
            oConfig.DiretorioSalvarXml = _PATH_NUVEMFISCAL_Config;

            return oConfig;
        }

        private static void log(string texto)
        {
            StreamWriter x;

            x = File.CreateText(Path.Combine(_PATH, "Aplicacao_FW_log.txt"));
            x.WriteLine(texto);
            x.Close();
        }
    }
}