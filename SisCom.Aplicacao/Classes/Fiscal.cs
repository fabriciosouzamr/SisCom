using DanfeSharp.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NFe.Danfe.Base.NFCe;
using NFe.Utils.NFe;
using DFe.Classes.Flags;
using NFe.Classes;
using NFe.Utils;
using DFe.Classes.Extensoes;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using System.Net;
using DFe.Utils;
using NFe.Servicos.Retorno;
using Microsoft.VisualBasic;
using NFe.Servicos;
using System.Data;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Pagamento;
using NFe.Utils.InformacoesSuplementares;
using Funcoes._Classes;
using NFe.Classes.Informacoes.Transporte;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Total;
using NFe.Utils.Tributacao.Estadual;
using NFe.Utils.Tributacao.Federal;
using Valor = Funcoes._Classes.Valor;
using MDFeEletronico = MDFe.Classes.Informacoes.MDFe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Servicos.Evento;
using SisCom.Aplicacao.Controllers;
using Funcoes.Interfaces;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Entidade.Modelos;
using MDFe.Classes.Flags;
using MDFe.Classes.Informacoes;
using MDFe.Utils.Configuracoes;
using DFe.Classes.Entidades;
using System.Runtime.CompilerServices;

namespace SisCom.Aplicacao.Classes
{
    public static class Fiscal
    {
        private static string TratarString(string texto)
        {
            return texto.Trim();
        }

        public static void GerarDanfe(string sXML, bool imprimirCancelado, bool abrirArquivo)
        {
            string sXML_Local = Arquivo.DiretorioMontarCaminhoArquivo(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria, "Danfe.xml");
            string sDanfe = Arquivo.ArquivoTemporario("Danfe.pdf");

            if (File.Exists(sXML_Local)) { File.Delete(sXML_Local); }
            if (File.Exists(sDanfe)) { File.Delete(sDanfe); }

            FileStream fs = new FileStream(sXML_Local, FileMode.Create);

            StreamWriter writer = new StreamWriter(fs);
            writer.Write(sXML);
            writer.Close();

            DanfeViewModel oModelo = DanfeViewModel.CreateFromXmlFile(sXML_Local);
            DanfeSharp.Danfe oDanfe;

            oDanfe = new DanfeSharp.Danfe(oModelo);

            //If FNC_NVL(sEMPRESA_DS_PATH_IMAGEM, "") <> "" Then
            //    Dim stream As New System.IO.FileStream(sEMPRESA_DS_PATH_IMAGEM, System.IO.FileMode.Open)
            //    'oDanfe.AdicionarLogoImagem(sEMPRESA_DS_PATH_IMAGEM)
            //    oDanfe.AdicionarLogoImagem(stream)
            //End If

            oDanfe.Rodape = "Gerado pelo DixMed";
            oDanfe.ImprimirCancelado = imprimirCancelado;
            oDanfe.Gerar();
            oDanfe.Salvar(sDanfe);

            if(abrirArquivo) { System.Diagnostics.Process.Start(@"C:\Windows\explorer.exe", sDanfe); }
        }

        public static void Fiscal_Danfe_ImprimirNCFe(string sXML, string sCD_NFCe_DetalheVendaNormal, string sCD_NFCe_DetalheVendaContigencia, string sCD_NFCe_Token_ID, string sCD_NFCe_Token_CSC)
        {
/*            sXML = Arquivo.DiretorioSistema_AdicionarPath(sXML);

            ConfiguracaoDanfeNfce oConfig;
            NFeZeus NFe = new NFe.Classes.NFe().CarregarDeArquivoXml(sXML);

            if (NFe.infNFe.ide.mod != ModeloDocumento.NFCe)
                CaixaMensagem.Informacao("O XML informado não é um NFCe");

            try
            {
                nfeProc oProc;
                string sArquivo;
                DanfeNativoNfce oImpr;

                oConfig = FNC_Fiscal_Configuracao_NCFe();

                try
                {
                    oProc = new nfeProc().CarregarDeArquivoXml(sXML);
                    sArquivo = oProc.ObterXmlString();
                }
                catch (Exception ex1)
                {
                    NFe = new NFe.Classes.NFe().CarregarDeArquivoXml(sXML);
                    sArquivo = NFe.ObterXmlString();
                }

                oImpr = new DanfeNativoNfce(sArquivo, oConfig, sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC, 0, 0, sESTACAO_TRABALHO_DS_FONTE_PADRAO_DANFENCFE);
                oImpr.Imprimir(sESTACAO_TRABALHO_DS_IMPRESSORA_PADRAO_DANFENCFE);
            }
            catch (Exception ex1)
            {
                try
                {
                    DanfeNativoNfce oDanfe;
                    oConfig = FNC_Fiscal_Configuracao_NCFe();
                    oDanfe = new DanfeNativoNfce(sXML, oConfig, sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);

                    oDanfe.Imprimir(false, sESTACAO_TRABALHO_DS_IMPRESSORA_PADRAO_DANFENCFE);
                }
                catch (Exception ex2)
                {
                    try
                    {
                        DanfeFrNfce oDanfe;

                        oConfig = FNC_Fiscal_Configuracao_NCFe();
                        oDanfe = new DanfeFrNfce(NFe, oConfig, sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);

                        oDanfe.Imprimir(false, sESTACAO_TRABALHO_DS_IMPRESSORA_PADRAO_DANFENCFE);
                    }
                    catch (Exception ex)
                    {
                        CaixaMensagem.Informacao(ex.Message);
                    }
                }
            }*/
        }

        private static NFe.Utils.ConfiguracaoServico Fiscal_Configuracao_NFe(ModeloDocumento eModeloDocumento = ModeloDocumento.NFe)
        {
            NFe.Utils.ConfiguracaoServico oConfig = new NFe.Utils.ConfiguracaoServico();
            System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
            DFe.Classes.Entidades.Estado oEstado = DFe.Classes.Entidades.Estado.MG;
            DFe.Utils.TipoCertificado iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO = TipoCertificado.A1Repositorio;

            oEstado = oEstado.SiglaParaEstado(Declaracoes.dados_Empresa_CodigoEstado);

            oConfig = ConfiguracaoServico.Instancia;
            {
                oConfig.tpAmb = TipoAmbiente.Producao;
                oConfig.tpEmis = TipoEmissao.teNormal;
                oConfig.ProtocoloDeSeguranca = ServicePointManager.SecurityProtocol;
                oConfig.Certificado = new ConfiguracaoCertificado();
                                                                                                                                                                              
                switch (iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO)
                {
                    case TipoCertificado.A1Arquivo:
                        oConfig.Certificado.TipoCertificado = TipoCertificado.A1Arquivo;
                        oConfig.Certificado.Arquivo = Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO;
                        oConfig.Certificado.Senha = Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA;
                        break;
                    case TipoCertificado.A1ByteArray:
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        oConfig.Certificado.TipoCertificado = TipoCertificado.A1ByteArray;
                        oConfig.Certificado.ArrayBytesArquivo = oCert.GetRawCertData();
                        oConfig.Certificado.Serial = oCert.GetSerialNumberString();
                        break;
                    case TipoCertificado.A1Repositorio:
                        oConfig.Certificado.TipoCertificado = TipoCertificado.A1Repositorio;

                        if (string.IsNullOrEmpty(Declaracoes.dados_Empresa_SerialNumber))
                        {
                            oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                            oConfig.Certificado.Serial = oCert.SerialNumber;
                        }
                        else
                        {
                            oConfig.Certificado.Serial = Declaracoes.dados_Empresa_SerialNumber;
                        }
                        break;
                    case TipoCertificado.A3:
                        oConfig.Certificado.TipoCertificado = TipoCertificado.A3;
                        break;
                }

                oConfig.Certificado.CacheId = "58A13AD9C6A41D4B";
                oConfig.Certificado.ManterDadosEmCache = true;
                oConfig.Certificado.SignatureMethodSignedXml = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                oConfig.Certificado.DigestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1";
                oConfig.TimeOut = 30000;
                oConfig.cUF = oEstado;
                oConfig.tpEmis = TipoEmissao.teNormal;
                oConfig.ModeloDocumento = eModeloDocumento;
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
                oConfig.DiretorioSchemas = Declaracoes.externos_Path_Schemas;
                oConfig.SalvarXmlServicos = true;
                oConfig.DiretorioSalvarXml = Declaracoes.Aplicacao_CaminhoDiretorioTemporaria;
            }

            return oConfig;
        }
        private static void Fiscal_Configuracao_MDFe()
        {
            DFe.Classes.Entidades.Estado oEstado = DFe.Classes.Entidades.Estado.MG;

            var configuracaoCertificado = new DFe.Utils.ConfiguracaoCertificado
            {
                TipoCertificado = TipoCertificado.A1Repositorio,
                Serial = Declaracoes.dados_Empresa_SerialNumber,
                Senha = Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA,            
                ManterDadosEmCache = true
            };

            MDFeConfiguracao.ConfiguracaoCertificado = configuracaoCertificado;
            MDFeConfiguracao.CaminhoSchemas = Declaracoes.externos_Path_Schemas;
            MDFeConfiguracao.CaminhoSalvarXml = Declaracoes.externos_Path_NuvemFiscal_MDFe;
            MDFeConfiguracao.IsSalvarXml = true;

            MDFeConfiguracao.VersaoWebService.VersaoLayout = MDFe.Utils.Flags.VersaoServico.Versao300;

            MDFeConfiguracao.VersaoWebService.TipoAmbiente = TipoAmbiente.Producao;
            MDFeConfiguracao.VersaoWebService.UfEmitente = oEstado.SiglaParaEstado(Declaracoes.dados_Empresa_CodigoEstado);
            MDFeConfiguracao.VersaoWebService.TimeOut = 10000;
            MDFeConfiguracao.IsAdicionaQrCode = true;
        }

        public static bool Fiscal_CartaCorrecao(ref NotaFiscalSaidaViewModel notaFiscalSaida, string sDescricaoCorrecao)
        {
            bool ok = false;

            if (notaFiscalSaida == null)
            {
                CaixaMensagem.Informacao("Informe o documento fiscal a ser corrigir");
                goto Sair;
            }
            if (sDescricaoCorrecao.Trim() == "")
            {
                CaixaMensagem.Informacao("Informe a descrição da correção");
                goto Sair;
            }

            try
            {
                var ret = Zeus.CartaCorrecao(notaFiscalSaida.CodigoChaveAcesso, Arquivo.CriarArquivoTexto(sDescricaoCorrecao, "cartacorrecao.txt"), notaFiscalSaida.NumeroLoteEnvioSefaz);

                if ((ret.RetEvento != null) && (ret.RetEvento.InfEvento != null))
                { notaFiscalSaida.RetornoCartaCorrecao = ret.RetEvento.InfEvento.XMotivo; }
                else
                { notaFiscalSaida.RetornoCartaCorrecao = ret.XMotivo; }

                if (Fiscal_NFe_StatusProcessamento(ret.CStat.ToString()) == enOpcoes_NFe_StatusProcessamento.LoteEventoProcessado)
                {
                    ok = true;
                }
                else
                {
                    CaixaMensagem.Informacao(ret.XMotivo);
                }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

        Sair:
            return ok;
        }
        public static bool Fiscal_Cancelamento(ref NotaFiscalSaidaViewModel notaFiscalSaida, string sJustificativa, string Protocolo)
        {
            bool ok = false;

            if (notaFiscalSaida == null)
            {
                CaixaMensagem.Informacao("Informe o documento fiscal a ser corrigir");
                goto Sair;
            }
            if (sJustificativa.Trim() == "")
            {
                CaixaMensagem.Informacao("Informe a descrição da justificativa");
                goto Sair;
            }

            try
            {
                var ret = Zeus.Cancelamento(notaFiscalSaida.CodigoChaveAcesso, Arquivo.CriarArquivoTexto(sJustificativa, "cancelamento.txt"), notaFiscalSaida.Protocolo, notaFiscalSaida.NumeroLoteEnvioSefaz);

                if ((ret.RetEvento != null) && (ret.RetEvento.InfEvento != null))
                { notaFiscalSaida.RetornoCartaCorrecao = ret.RetEvento.InfEvento.XMotivo; }
                else
                { notaFiscalSaida.RetornoCartaCorrecao = ret.XMotivo; }

                if ((ret.CStat.ToString() == "101" /* Cancelamento de NF-e homologado */) || 
                    (ret.CStat.ToString() == "151" /* Cancelamento de NF - e homologado fora de prazo */) ||
                    (ret.CStat.ToString() == "135" /* Evento registrado e vinculado a NF-e */))
                {
                    ok = true;
                }
                else
                {
                    CaixaMensagem.Informacao(ret.RetEvento.InfEvento.XMotivo);
                }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

        Sair:
            return ok;
        }

        public static string Certificado_DataExpiracao()
        {
            string data = "";

            try
            {
                System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
                DFe.Utils.TipoCertificado iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO = TipoCertificado.A1Repositorio;

                switch (iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO)
                {
                    case TipoCertificado.A1Arquivo:
                        break;
                    case TipoCertificado.A1ByteArray:
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        if (oCert != null) { data = oCert.GetExpirationDateString(); }
                        break;
                    case TipoCertificado.A1Repositorio:
                        if (string.IsNullOrEmpty(Declaracoes.dados_Empresa_SerialNumber))
                        {
                            oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                            if (oCert != null) { data = oCert.GetExpirationDateString(); }
                        }
                        else
                        {
                            var configuracaoCertificado = new ConfiguracaoCertificado();

                            configuracaoCertificado.TipoCertificado = TipoCertificado.A1Repositorio;
                            configuracaoCertificado.Serial = Declaracoes.dados_Empresa_SerialNumber;

                            oCert = DFe.Utils.Assinatura.CertificadoDigital.ObterCertificado(configuracaoCertificado);
                            if (oCert != null) { data = oCert.GetExpirationDateString(); }
                        }
                        break;
                    case TipoCertificado.A3:
                        break;
                }
            }
            catch (Exception)
            {
            }

            return data;
        }

        private static enOpcoes_NFe_StatusProcessamento Fiscal_NFe_StatusProcessamento(string scStat)
        {
            enOpcoes_NFe_StatusProcessamento eRet = enOpcoes_NFe_StatusProcessamento.LoteNaoLocalizado;

            if (scStat == "100")
                eRet = enOpcoes_NFe_StatusProcessamento.AutorizadoUsoNFe;
            else if (scStat == "101")
                eRet = enOpcoes_NFe_StatusProcessamento.CancelamentoNFeHomologado;
            else if (scStat == "102")
                eRet = enOpcoes_NFe_StatusProcessamento.InutilizacaoNumeroHomologado;
            else if (scStat == "103")
                eRet = enOpcoes_NFe_StatusProcessamento.LoteRecebidoComSucesso;
            else if (scStat == "104")
                eRet = enOpcoes_NFe_StatusProcessamento.LotePocessado;
            else if (scStat == "105")
                eRet = enOpcoes_NFe_StatusProcessamento.LoteProcessamento;
            else if (scStat == "106")
                eRet = enOpcoes_NFe_StatusProcessamento.LoteNaoLocalizado;
            else if (scStat == "107")
                eRet = enOpcoes_NFe_StatusProcessamento.ServicoSVCOperacao;
            else if (scStat == "108")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ServicoParalisadoMomentaneamente_CurtoPrazo;
            else if (scStat == "109")
                eRet = enOpcoes_NFe_StatusProcessamento.ServicoParalisadoPrevisao;
            else if (scStat == "110")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UsoDenegado;
            else if (scStat == "111")
                eRet = enOpcoes_NFe_StatusProcessamento.ConsultaCadastroComUmaOcorrencia;
            else if (scStat == "112")
                eRet = enOpcoes_NFe_StatusProcessamento.ConsultaCadastroComMaisUmaOcorrencia;
            else if (scStat == "128")
                eRet = enOpcoes_NFe_StatusProcessamento.LoteEventoProcessado;
            else if (scStat == "135")
                eRet = enOpcoes_NFe_StatusProcessamento.EventoRegistradoVinculadoNFe;
            else if (scStat == "201")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ONumeroMaximoNumeracaoNFeAInutilizarUtrapassouLimite;
            else if (scStat == "202")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_FalhaReconhecimentoAutoriaIntegridadeArquivoDigital;
            else if (scStat == "203")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_EmissorNaoHabilitadoParaEmissaoNFe;
            else if (scStat == "204")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DuplicidadeNFe_999999999999999999999999999999999;
            else if (scStat == "205")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeEstaDenegadaBaseDadosSEFAZ;
            else if (scStat == "206")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeJaEstaInutilizadaBaseDadosSEFAZ;
            else if (scStat == "207")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJEmitenteInvalido;
            else if (scStat == "208")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJDestinatarioInvalido;
            else if (scStat == "209")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IE_EmitenteInvalida;
            else if (scStat == "210")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IE_DestinatarioInvalida;
            else if (scStat == "211")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IE_SubstitutoInvalida;
            else if (scStat == "212")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataEmissaoNFePosteriorDataRecebimento;
            else if (scStat == "213")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJ_BaseEmitenteDifereCNPJ_BaseCertificadoDigital;
            else if (scStat == "214")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TamanhoMensagemExcedeuLimiteEstabelecido;
            else if (scStat == "215")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_FalhaSchemaXML;
            else if (scStat == "216")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ChaveAcessoDifereCadastrada;
            else if (scStat == "217")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeNaoConstaBaseDadosSEFAZ;
            else if (scStat == "218")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeJaEstaCanceladaBaseDadosSEFAZ;
            else if (scStat == "219")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CirculacaoNFeVerificada;
            else if (scStat == "220")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeAutorizadaHaMais7Dias_168Horas;
            else if (scStat == "221")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ConfirmadoRecebimentoNFePeloDestinatario;
            else if (scStat == "222")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ProtocoloAutorizacaoUsoDifereCadastrado;
            else if (scStat == "223")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJTransmissorLoteDifereCNPJTransmissorConsulta;
            else if (scStat == "224")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AFaixaInicialMaiorAFaixaFinal;
            else if (scStat == "225")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_FalhaSchemaXMLNFe;
            else if (scStat == "226")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoUFEmitenteDivergeUFAutorizadora;
            else if (scStat == "227")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ErroChaveAcesso_CampoIDFaltaLiteralNFe;
            else if (scStat == "228")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataEmissaoMuitoAtrasada;
            else if (scStat == "229")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEEmitenteNaoinformada;
            else if (scStat == "230")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEEmitenteNaocadastrada;
            else if (scStat == "231")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEEmitenteNaovinculadaCNPJ;
            else if (scStat == "232")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEDestinatarioNaoinformada;
            else if (scStat == "233")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEDestinatarioNaocadastrada;
            else if (scStat == "234")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEDestinatarioNaovinculadaCNPJ;
            else if (scStat == "235")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_InscricaoSUFRAMAInvalida;
            else if (scStat == "236")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ChaveAcessoDigitoVerificadorInvalido;
            else if (scStat == "237")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFDestinatarioInvalido;
            else if (scStat == "238")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_Cabecalho_VersaoArquivoXMLSuperiorVersaoVigente;
            else if (scStat == "239")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_Cabecalho_VersaoArquivoXMLNaoSuportada;
            else if (scStat == "240")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CancelamentoInutilizacaoIrregularidadeFiscalEmitente;
            else if (scStat == "241")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UmNumeroDaFaixaJaFoiUtilizado;
            else if (scStat == "242")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_Cabecalho_FalhaSchemaXML;
            else if (scStat == "243")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_XMLMalFormado;
            else if (scStat == "244")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJCertificadoDigitalDifereCNPJMatrizDoCNPJEmitente;
            else if (scStat == "245")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJEmitenteNaocadastrado;
            else if (scStat == "246")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJDestinatarioNaocadastrado;
            else if (scStat == "247")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SiglaUFEmitenteDivergeUFAutorizadora;
            else if (scStat == "248")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFReciboDivergeUFAutorizadora;
            else if (scStat == "249")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFChaveAcessoDivergeUFAutorizadora;
            else if (scStat == "250")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFDivergeUFAutorizadora;
            else if (scStat == "251")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFMunicipioDestinatarioNaoPertenceSUFRAMA;
            else if (scStat == "252")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AmbienteInformadoDivergeAmbienteRecebimento;
            else if (scStat == "253")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DigitoVerificadorChaveAcessoCompostaInvalida;
            else if (scStat == "254")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeComplementarNaoPossuiNFReferenciada;
            else if (scStat == "255")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeComplementarPossuiMaisUmaNFReferenciada;
            else if (scStat == "256")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UmaNFeDaFaixaJaEstaInutilizadaBaseDadosSEFAZ;
            else if (scStat == "257")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SolicitanteNaohabilitadoParaEmissaoNFe;
            else if (scStat == "258")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJConsultaInvalido;
            else if (scStat == "259")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJConsultaNaoCadastradoComoContribuinteUF;
            else if (scStat == "260")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEConsultaInvalida;
            else if (scStat == "261")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IEConsultaNaocadastradaComoContribuinteUF;
            else if (scStat == "262")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFNaoForneceConsultaPorCPF;
            else if (scStat == "263")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFConsultaInvalido;
            else if (scStat == "264")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFConsultaNaoCadastradoComoContribuinteUF;
            else if (scStat == "265")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SiglaUFConsultaDifereUFWebService;
            else if (scStat == "266")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SerieUtilizadaNaoPermitidaWebService;
            else if (scStat == "267")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFComplementarReferenciaNFeInexistente;
            else if (scStat == "268")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NFComplementarReferenciaOutraNFeComplementar;
            else if (scStat == "269")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJEmitenteNFComplementarDifereCNPJNFReferenciada;
            else if (scStat == "270")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioFatoGeradorDigitoInvalido;
            else if (scStat == "271")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioFatoGeradorDifereUFEmitente;
            else if (scStat == "272")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioEmitenteDigitoInvalido;
            else if (scStat == "273")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioEmitenteDifereUFEmitente;
            else if (scStat == "274")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioDestinatarioDigitoInvalido;
            else if (scStat == "275")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioDestinatarioDifereUFDestinatario;
            else if (scStat == "276")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalRetirada_DigitoInvalido;
            else if (scStat == "277")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalRetirada_DfereUFLocalRetirada;
            else if (scStat == "278")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalEntrega_DigitoInvalido;
            else if (scStat == "279")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalEntrega_DifereUFLocalEntrega;
            else if (scStat == "280")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorInvalido;
            else if (scStat == "281")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorDataValidade;
            else if (scStat == "282")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorSemCNPJ;
            else if (scStat == "283")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorErroCadeiaCertificacao;
            else if (scStat == "284")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorRevogado;
            else if (scStat == "285")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorDifereICPBrasil;
            else if (scStat == "286")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoTransmissorErroAcessoLCR;
            else if (scStat == "287")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioFG_ISSQNDigitoInvalido;
            else if (scStat == "288")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioFG_TransporteiígitoInvalido;
            else if (scStat == "289")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoInformadaDivergeUFSolicitada;
            else if (scStat == "290")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaInvalido;
            else if (scStat == "291")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaDataValidade;
            else if (scStat == "292")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaSemCNPJ;
            else if (scStat == "293")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaErroCadeiaCertificacao;
            else if (scStat == "294")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaRevogado;
            else if (scStat == "295")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaDifereICPBrasil;
            else if (scStat == "296")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CertificadoAssinaturaErroAcessoLCR;
            else if (scStat == "297")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AssinaturaDifereCalculado;
            else if (scStat == "298")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AssinaturaDiferePadraoProjeto;
            else if (scStat == "299")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_XMLAreaCabecalhoComCodificacaoDiferenteUTF8;
            else if (scStat == "301")
                eRet = enOpcoes_NFe_StatusProcessamento.UsoDenegadoIrregularidadeFiscalEmitente;
            else if (scStat == "302")
                eRet = enOpcoes_NFe_StatusProcessamento.UsoDenegadoIrregularidadeFiscalDestinatario;
            else if (scStat == "401")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFRemetenteInvalido;
            else if (scStat == "402")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_XMLAreaDadosComCodificacaoDiferenteUTF8;
            else if (scStat == "403")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OGrupoInformacoesNFeAvulsaDeUsoExclusivoFisco;
            else if (scStat == "404")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UsoPrefixoNamespaceNaoPermitido;
            else if (scStat == "405")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoPaisEmitente_DigitoInvalido;
            else if (scStat == "406")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoPaisDestinatario_DigitoInvalido;
            else if (scStat == "407")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OCPFSoPodeSerInformadoCampoEmitenteParaNFeAvulsa;
            else if (scStat == "409")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_Campo_cUF_InexistenteElemento_nfeCabecMsgSOAPHeader;
            else if (scStat == "410")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFInformadaCampo_cUFNao_AtendidaWebService;
            else if (scStat == "411")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CampoVersaoDadosInexistenteElemento_nfeCabecMsgSOAPHeader;
            else if (scStat == "453")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AnoInutilizacaoNaoPodeSersuperiorAnoAtual;
            else if (scStat == "454")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AnoInutilizacaoNaoPodeSerinferior2006;
            else if (scStat == "478")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_LocalEntregaNaoinformadoFaturamentoDiretoVeiculosNovos;
            else if (scStat == "502")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ErroChaveAcesso_CampoIDNaoCorrespondeAConcatenacao;
            else if (scStat == "503")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SerieUtilizadaForaDaFaixaPermitidaSCAN_900_999;
            else if (scStat == "504")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataEntradaSaidaPosteriorPermitido;
            else if (scStat == "505")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataEntradaSaidaAnteriorPermitido;
            else if (scStat == "506")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataSaidaMenorQueDataEmissao;
            else if (scStat == "507")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OCNPJDestinatarioRemetenteNaoDeveSerInformadoOperacao;
            else if (scStat == "508")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OCPFDestinatarioRemetenteNaoDeveSerInformadoOperacao;
            else if (scStat == "509")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OCNPJConteudoNuloSoValidoOperacaoExterior;
            else if (scStat == "510")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OperacaoExteriorCodigoPaisDestinatario1058_Brasil_ouNao;
            else if (scStat == "511")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NaoOperaçaoExteriorCodigoPaisDestinatarioDifere1058Brasil;
            else if (scStat == "512")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJLocalRetiradaInvalido;
            else if (scStat == "513")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalRetiradaDeveSer_9999999_UFRetirada_EX;
            else if (scStat == "514")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJLocalEntregaInvalido;
            else if (scStat == "515")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoMunicipioLocalEntregaDeveSer_9999999_UFEntrega_EX;
            else if (scStat == "516")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ObrigatoriaInformacaoNCM_Genero;
            else if (scStat == "517")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_InformacaoNCMDifereInformacaoGenero;
            else if (scStat == "518")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPEntradaNFeSaida;
            else if (scStat == "519")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPSaidaNFeEntrada;
            else if (scStat == "520")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPOperacaoExteriorUFDestinatarioDifereEX;
            else if (scStat == "521")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPNaoEDeOperacaoComExteriorUFDestinatarioEX;
            else if (scStat == "522")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPOperacaoEstadualUFEmitenteDifereUFDestinatario;
            else if (scStat == "523")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPNaoEOperacaoEstadualUFEmitenteIgualUFDestinatario;
            else if (scStat == "524")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPOperacaoComExteriorENaoInformadoNCM;
            else if (scStat == "525")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPImportacaoENaoInformadDadosDI;
            else if (scStat == "526")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CFOPExportacaoENaoInformadoLocalEmbarque;
            else if (scStat == "527")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OperacaoExportacaoComInformacaoICMSIncompativel;
            else if (scStat == "528")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ValorICMSDifereProdutoBCAliquota;
            else if (scStat == "529")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NCMInformacaoObrigatoriaParaProdutoTributadopeloIPI;
            else if (scStat == "530")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_OperacaoComTibutacaoISSQNinformarInscricaoMunicipal;
            else if (scStat == "531")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalBCICMSDifereSomatorioDosItens;
            else if (scStat == "532")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalICMSDifereSomatorioDosItens;
            else if (scStat == "533")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalBCICMS_STDifereSomatorioItens;
            else if (scStat == "534")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalICMS_STDifereSomatorioItens;
            else if (scStat == "535")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalFreteDifereSomatorioItens;
            else if (scStat == "536")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalSeguroDifereSomatorioItens;
            else if (scStat == "537")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalDescontoDifereSomatorioItens;
            else if (scStat == "538")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TotalIPIDifereSomatorioItens;
            else if (scStat == "539")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DuplicidadeNFecomDiferencaChaveAcesso;
            else if (scStat == "540")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFLocalRetiradaInvalido;
            else if (scStat == "541")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFLocalEntregaInvalido;
            else if (scStat == "542")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJTransportadorInvalido;
            else if (scStat == "543")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPFTransportadorInvalido;
            else if (scStat == "544")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IETransportadorInvalido;
            else if (scStat == "545")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_NotaFiscalEmitidaContingencia;
            else if (scStat == "546")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ErroChaveAcesso_CampoID_FaltaLiteralNFe;
            else if (scStat == "547")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DígitoVerificadorChaveAcessoNFeReferenciadaInvalido;
            else if (scStat == "548")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJ_NFReferenciadaInvalido;
            else if (scStat == "549")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJ_NFReferenciadaProdutorInvalido;
            else if (scStat == "550")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CPF_NFReferenciadaProdutorInvalido;
            else if (scStat == "551")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_IE_NFReferenciadaProdutorInvalido;
            else if (scStat == "552")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DigitoVerificadorChaveAcessoCTeReferenciadoInvalido;
            else if (scStat == "553")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TipoAutorizadorReciboDivergeOrgaoAutorizador;
            else if (scStat == "554")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_SerieDifereDaFaixa_0_899;
            else if (scStat == "555")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_TipoAutorizadorProtocoloDivergeOrgaoAutorizador;
            else if (scStat == "556")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_JustificativaEntradaContingenciaNaoDeveSerInformadaParaTipo;
            else if (scStat == "557")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_AJustificativaEntradaContingenciaDeveSerInformada;
            else if (scStat == "558")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_DataEntradaContingenciaPosteriorDataEmissao;
            else if (scStat == "559")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_UFTransportadorNaoInformado;
            else if (scStat == "560")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CNPJBaseEmitenteDifereCNPJBasePrimeiraNFeLoteRecebido;
            else if (scStat == "561")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_MesEmissaoInformadoChaveAcessoDifereMesEmissaoNFe;
            else if (scStat == "562")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_CodigoNumericoInformadoChaveAcessoDifereCodigoNumericoDa;
            else if (scStat == "999")
                eRet = enOpcoes_NFe_StatusProcessamento.Rejeicao_ErroNaoCatalogadoInformarMensagemErroCapturadoTratamentoDa;

            return eRet;
        }

        public static bool Fiscal_DFe_StatusServico()
        {
            bool bOk = false;

            try
            {
                ConfiguracaoServico oConfig;

                oConfig = Fiscal_Configuracao_NFe();

                if (oConfig == null)
                    goto Sair;

                NFe.Servicos.ServicosNFe oServico = new NFe.Servicos.ServicosNFe(oConfig);

                if (Fiscal_NFe_StatusProcessamento(oServico.NfeStatusServico().Retorno.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.ServicoSVCOperacao)
                    CaixaMensagem.Informacao("Serviço disponível");
                else
                {
                    CaixaMensagem.Informacao("Serviço indisponível");
                    goto Sair;
                }
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("FNC_Fiscal_DFe_StatusServico - " + ex.Message);
                goto Sair;
            }

            bOk = true;

        Sair:
            ;
            return bOk;
        }

        public static bool Fiscal_DFe_InutilizarNumeracao(string sCNPJ, int iAno, string sModelo, string sSerie, int iNumeracaoInicial, int iNumeracaoFinal, string sJustificativa)
        {
            bool bOk = false;

            try
            {
                ConfiguracaoServico oConfig;

                oConfig = Fiscal_Configuracao_NFe();

                if (oConfig == null)
                    goto Sair;

                NFe.Servicos.ServicosNFe oServico = new NFe.Servicos.ServicosNFe(oConfig);
                RetornoNfeInutilizacao oRetornoNfeInutilizacao;

                oRetornoNfeInutilizacao = oServico.NfeInutilizacao(Funcoes._Classes.Texto.SomenteNumero(sCNPJ), iAno, ModeloDocumento.NFe, Convert.ToInt16(sSerie), iNumeracaoInicial, iNumeracaoFinal, sJustificativa);

                if (Fiscal_NFe_StatusProcessamento(oRetornoNfeInutilizacao.Retorno.infInut.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.InutilizacaoNumeroHomologado)
                    bOk = true;
                else
                    CaixaMensagem.Informacao(oRetornoNfeInutilizacao.Retorno.infInut.xMotivo);
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("FNC_Fiscal_DFe_InutilizarNumeracao - " + ex.Message);
                goto Sair;
            }

        Sair:
            ;
            return bOk;
        }
        private static NFe.Classes.nfeProc Fiscal_DocumentoFiscal_AssociarProtocolo(NFe.Utils.ConfiguracaoServico oConfig, NFe.Classes.NFe oNFe, string sNFe_Chave)
        {
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoNfeConsultaProtocolo oNFe_Servico_Retorno;
            NFe.Classes.nfeProc oNFe_Proc;

            oNFe_Servico = new ServicosNFe(oConfig);
            oNFe_Servico_Retorno = oNFe_Servico.NfeConsultaProtocolo(sNFe_Chave);

            oNFe_Proc = new nfeProc();
            oNFe_Proc.NFe = oNFe;
            oNFe_Proc.protNFe = oNFe_Servico_Retorno.Retorno.protNFe;
            oNFe_Proc.versao = oNFe_Servico_Retorno.Retorno.versao;

            return oNFe_Proc;
        }
        private static bool Fiscal_DocumentoFiscal_Protocolo(NFe.Classes.NFe oNFe, NFe.Utils.ConfiguracaoServico oConfig, ref string sCD_PROTOCOLO, ref string sNFe_Arquivo)
        {
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoNfeConsultaProtocolo oNFe_Servico_Retorno;
            NFe.Classes.nfeProc oNFe_Proc;

            string sNFe_Chave;
            bool bOk = false;

            int iCont;

            sNFe_Chave = Fiscal_ChaveNFe(oNFe);

            Fiscal_Historico(0, 0 /* iSQ_DOCUMENTOFISCAL */, "Solicitação de protocolo");

            if (string.IsNullOrEmpty(sNFe_Chave))
            {
                Fiscal_Historico(0, 0 /* iSQ_DOCUMENTOFISCAL */, "Solicitação de protocolo - A Chave da NFe não foi encontrada no arquivo", null, false);
                goto Sair;
            }
            if (sNFe_Chave.Trim().Length != 44)
            {
                Fiscal_Historico(0, 0 /* iSQ_DOCUMENTOFISCAL */, "Solicitação de protocolo - Chave deve conter 44 caracteres", null, false);
                goto Sair;
            }

            for (iCont = 1; iCont <= 5; iCont++)
            {
                oNFe_Servico = new ServicosNFe(oConfig);
                oNFe_Servico_Retorno = oNFe_Servico.NfeConsultaProtocolo(sNFe_Chave);
                Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, "Solicitação de protocolo - Retorno - " + "Chave de Acesso: " + oNFe_Servico_Retorno.Retorno.chNFe);

                oNFe_Proc = new nfeProc();
                oNFe_Proc.NFe = oNFe;
                oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                oNFe_Proc.protNFe = oNFe_Servico_Retorno.Retorno.protNFe;
                oNFe_Proc.versao = oNFe_Servico_Retorno.Retorno.versao;

                if (Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeNaoConstaBaseDadosSEFAZ)
                {
                    if (iCont == 5)
                        Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, "NFe Não Consta na Base Dados do SEFAZ");
                }
                else
                {
                    Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, "Solicitação de protocolo - Retorno - " + "Chave de Acesso: " + oNFe_Proc.protNFe.infProt.chNFe + "Protocolo nº: " + oNFe_Proc.protNFe.infProt.nProt + "Motivo: " + oNFe_Proc.protNFe.infProt.xMotivo);
                    if (oNFe_Proc.protNFe != null)
                    {
                        sCD_PROTOCOLO = oNFe_Proc.protNFe.infProt.nProt;
                        sNFe_Arquivo = Arquivo.Diretorio_Tratar(oConfig.DiretorioSalvarXml) + sNFe_Chave + "-procNfe.xml";

                        FuncoesXml.ClasseParaArquivoXml(oNFe_Proc, sNFe_Arquivo);
                    }

                    bOk = true;

                    break;
                }
            }

        Sair:
            return bOk;
        }
        private static void Fiscal_Historico(enOpcoes_NFe_StatusProcessamento iErro, int iSQ_DOCUMENTOFISCAL, string sDS_HISTORICO, string sCD_HISTORICO = "", bool bExibirMensagem = false)
        {
            //Historico_Incluir(enOpcoes.Processo_Historico_Cadastro_CadastroDocumentoFiscal.GetHashCode(), enOpcoes.Processo_Acao_Transmissao.GetHashCode(), iErro, iSQ_DOCUMENTOFISCAL, sDS_HISTORICO, sCD_HISTORICO);

            if (bExibirMensagem)
                CaixaMensagem.Informacao(sDS_HISTORICO);
        }
        public static string Fiscal_ChaveNFe(NFe.Classes.NFe oNFe)
        {
            if (oNFe == null)
            { return ""; }
            else
            { return oNFe.infNFe.Id.Substring(3); }
        }
        public static bool FNC_Fiscal_DocumentoFiscal_Transmitir_Validar(NotaFiscalSaidaViewModel notaFiscalSaidaViewModel, 
                                                                         List<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels)
        {
            DataTable oData;
            string sSqlText;
            int iCont;
            StringBuilder sAux = new StringBuilder();
            bool bOk = false;

            if ((Declaracoes.Estacao_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO == TipoCertificado.A1Arquivo) && ((String.IsNullOrEmpty(Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO.Trim())) ||
                                                                                                                (String.IsNullOrEmpty(Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO.Trim()))))
            {
                CaixaMensagem.Informacao("Dados do certificado digital não informado");
                goto Sair;
            }
            if (Declaracoes.externos_Path_Schemas.Trim() == "")
            {
                CaixaMensagem.Informacao("Pasta de Schema no NF-e/NFC-e não informada");
                goto Sair;
            }

            if ((notaFiscalSaidaViewModel == null) || (notaFiscalSaidaMercadoriaViewModels == null) || (notaFiscalSaidaMercadoriaViewModels.Count == 0))
            {
                CaixaMensagem.Informacao("Documento Fiscal não encontrado ou incompleto");
                goto Sair;
            }
            else
            {
                if (notaFiscalSaidaViewModel.Status == Entidade.Enum.NF_Status.Transmitida)
                {
                    CaixaMensagem.Informacao("Nota Fiscal já transmitida");
                    goto Sair;
                }
                if (notaFiscalSaidaViewModel.Status == Entidade.Enum.NF_Status.Cancelado)
                {
                    CaixaMensagem.Informacao("Nota Fiscal cancelada");
                    goto Sair;
                }
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Modelo))
                {
                    CaixaMensagem.Informacao("Modelo de serviço do documento fiscal não informado");
                    goto Sair;
                }
                switch ((NF_Modelo)Convert.ToInt16(notaFiscalSaidaViewModel.Modelo))
                {
                    case NF_Modelo.CupomFiscalEletronica:
                        {
                            /*if (FNC_NVL(sESTACAO_TRABALHO_CD_NFCe_Token_CSC, "").Trim() == "")
                            {
                                CaixaMensagem.Informacao("Código do Token CSC não informado");
                                goto Sair;
                            }
                            if (FNC_NVL(sESTACAO_TRABALHO_CD_NFCe_Token_ID, "").Trim() == "")
                            {
                                CaixaMensagem.Informacao("Código do Token ID não informado");
                                goto Sair;
                            }
                            if (FNC_NVL(iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA, 0) == 0)
                            {
                                CaixaMensagem.Informacao("Tipo de Detalhe Venda Contigência não informado");
                                goto Sair;
                            }
                            if (FNC_NVL(iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_NORMAL, 0) == 0)
                            {
                                CaixaMensagem.Informacao("Tipo de Detalhe Venda Normal não informado");
                                goto Sair;
                            }
                            if (FNC_NVL(iESTACAO_TRABALHO_ID_OPT_NFCe_VERSAO_QRCODE, 0) == 0)
                            {
                                CaixaMensagem.Informacao("Versão do QR-Code não informado");
                                goto Sair;
                            }*/

                            break;
                        }
                }
            }

            // If FNC_NVL(.Item("IC_EXIBIR_PESSOA"), "N") = "S" Then
            // If FNC_CampoNulo(.Item("CD_CPF_CNPJ")) Then
            // CaixaMensagem.Informacao("É preciso informar o C.P.F./C.N.P.J. da pessoa da venda")
            // GoTo Sair
            // End If
            // If Not FNC_ValidarCPF_CNPJ(.Item("CD_CPF_CNPJ")) Then
            // CaixaMensagem.Informacao("É preciso informar o C.P.F./C.N.P.J. válido da pessoa da venda")
            // GoTo Sair
            // End If
            // End If
            if (notaFiscalSaidaViewModel.TransmitirEnderecoCliente)
            {
                if (notaFiscalSaidaViewModel.Cliente.Endereco == null)
                {
                    CaixaMensagem.Informacao("É preciso informar o endereço do cliente");
                    goto Sair;
                }
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.Endereco.End_Bairro))
                {
                    CaixaMensagem.Informacao("É preciso informar o bairro do endereço da pessoa");
                    goto Sair;
                }
                if (notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade == null)
                {
                    CaixaMensagem.Informacao("É preciso informar a cidade do endereço da pessoa");
                    goto Sair;
                }
                if (notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade.Estado == null)
                {
                    CaixaMensagem.Informacao("É preciso informar a U.F. do endereço da pessoa");
                    goto Sair;
                }
                if (notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade.Estado.Pais == null)
                {
                    CaixaMensagem.Informacao("É preciso informar o país do endereço da pessoa");
                    goto Sair;
                }
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade.CodigoIBGE))
                {
                    CaixaMensagem.Informacao("É preciso informar o código do IBGE da cidade do endereço da pessoa");
                    goto Sair;
                }
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.Endereco.End_CEP))
                {
                    CaixaMensagem.Informacao("É preciso informar o código do C.E.P. do endereço da pessoa");
                    goto Sair;
                }
                if (notaFiscalSaidaViewModel.Cliente.Endereco.End_CEP.Trim().Length == 8)
                {
                    CaixaMensagem.Informacao("o código do C.E.P. do endereço da pessoa está em formato incorreto");
                    goto Sair;
                }

                foreach (NotaFiscalSaidaMercadoriaViewModel notaFiscalSaidaMercadoriaViewModel in notaFiscalSaidaMercadoriaViewModels)
                {
                    if (sAux.Length != 0) { sAux.AppendLine(Environment.NewLine); }

                    if (String.IsNullOrEmpty(notaFiscalSaidaMercadoriaViewModel.TabelaCST_CSOSN.Codigo))
                    { sAux.AppendLine(notaFiscalSaidaMercadoriaViewModel.Descricao + " - CST COFINS não informado para o produto"); }

                    if (String.IsNullOrEmpty(notaFiscalSaidaMercadoriaViewModel.TabelaNCM.Codigo))
                    { sAux.AppendLine(notaFiscalSaidaMercadoriaViewModel.Descricao + " - NCM não informado para o produto"); }
                }

                if (sAux.Length != 0)
                {
                    sAux.AppendLine("O(s) produto(s) listado(s) abaixo estão com algum problema de cadastro ou lançamento" + Environment.NewLine + Environment.NewLine + sAux);

                    CaixaMensagem.Informacao(sAux.ToString());
                }

                bOk = (sAux.Length == 0);
            }

        Sair:
            return bOk;
        }
        public static bool FNC_Fiscal_DocumentoFiscal_Cancelar(ModeloDocumento eModeloDocumento, 
                                                               NotaFiscalSaidaViewModel notaFiscalSaidaViewModel, 
                                                               string sJustificativa = "")
        {
            return false;
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoRecepcaoEvento oNFe_Servico_RetornoRecepcaoEvento;
            NFe.Utils.ConfiguracaoServico oConfig;
            bool bOk = false;
            string sSqlText;
            DataTable oData;

            if (notaFiscalSaidaViewModel == null)
            {
                CaixaMensagem.Informacao("Informe o documento fiscal a ser corrigir");
                goto Sair;
            }
            if (sJustificativa.Trim() == "")
            {
                CaixaMensagem.Informacao("Informe a descrição da correção");
                goto Sair;
            }

            oConfig = Fiscal_Configuracao_NFe(eModeloDocumento);
            if (oConfig == null)
                goto Sair;

            oNFe_Servico = new ServicosNFe(oConfig);

            if (notaFiscalSaidaViewModel.Id == Guid.Empty)
                CaixaMensagem.Informacao("Documento Fiscal não encontrado");
            else
            {
                oNFe_Servico_RetornoRecepcaoEvento = oNFe_Servico.RecepcaoEventoCancelamento(1, 1, notaFiscalSaidaViewModel.Protocolo, 
                                                                                                   notaFiscalSaidaViewModel.CodigoChaveAcesso, sJustificativa, 
                                                                                                   notaFiscalSaidaViewModel.Empresa.CNPJ);

                var retEvento = oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento[0];

                if (Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.EventoRegistradoVinculadoNFe ||
                    Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.LoteEventoProcessado)
                {
                    Fiscal_Historico(Fiscal_NFe_StatusProcessamento(retEvento.infEvento.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, retEvento.infEvento.xMotivo + Constants.vbCrLf, notaFiscalSaidaViewModel.NotaFiscal);

                    if (Fiscal_NFe_StatusProcessamento(retEvento.infEvento.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.CancelamentoNFeHomologado ||
                        Fiscal_NFe_StatusProcessamento(retEvento.infEvento.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.EventoRegistradoVinculadoNFe)
                    {
                        bOk = true;
                        //FormCadastroDocumentoFiscal_Cancelamento_Gravar(notaFiscalSaidaViewModel, sJustificativa);
                    }
                    else
                        Fiscal_Historico(Fiscal_NFe_StatusProcessamento(retEvento.infEvento.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, retEvento.infEvento.xMotivo + Constants.vbCrLf, notaFiscalSaidaViewModel.NotaFiscal);
                }
                else
                    Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat.ToString()), 0 /* iSQ_DOCUMENTOFISCAL */, 
                                     oNFe_Servico_RetornoRecepcaoEvento.Retorno.xMotivo + Constants.vbCrLf, notaFiscalSaidaViewModel.NotaFiscal);
            }

        Sair:
            return bOk;
        }
        private static DFe.Classes.Entidades.Estado EstadoDBParaEstadoZeus(string CD_UF)
        {
            DFe.Classes.Entidades.Estado estado = DFe.Classes.Entidades.Estado.EX;

            switch (CD_UF)
            {
                case "BA":
                    estado = DFe.Classes.Entidades.Estado.BA;
                    break;
                case "GO":
                    estado = DFe.Classes.Entidades.Estado.GO;
                    break;
                case "AM":
                    estado = DFe.Classes.Entidades.Estado.AM;
                    break;
                case "PE":
                    estado = DFe.Classes.Entidades.Estado.PE;
                    break;
                case "RO":
                    estado = DFe.Classes.Entidades.Estado.RO;
                    break;
                case "DF":
                    estado = DFe.Classes.Entidades.Estado.DF;
                    break;
                case "MS":
                    estado = DFe.Classes.Entidades.Estado.MS;
                    break;
                case "ES":
                    estado = DFe.Classes.Entidades.Estado.ES;
                    break;
                case "AC":
                    estado = DFe.Classes.Entidades.Estado.AC;
                    break;
                case "PI":
                    estado = DFe.Classes.Entidades.Estado.PI;
                    break;
                case "PA":
                    estado = DFe.Classes.Entidades.Estado.PA;
                    break;
                case "SE":
                    estado = DFe.Classes.Entidades.Estado.SE;
                    break;
                case "MT":
                    estado = DFe.Classes.Entidades.Estado.MT;
                    break;
                case "MA":
                    estado = DFe.Classes.Entidades.Estado.MA;
                    break;
                case "MG":
                    estado = DFe.Classes.Entidades.Estado.MG;
                    break;
                case "PR":
                    estado = DFe.Classes.Entidades.Estado.PR;
                    break;
                case "RJ":
                    estado = DFe.Classes.Entidades.Estado.RJ;
                    break;
                case "AP":
                    estado = DFe.Classes.Entidades.Estado.AP;
                    break;
                case "RS":
                    estado = DFe.Classes.Entidades.Estado.RS;
                    break;
                case "RR":
                    estado = DFe.Classes.Entidades.Estado.RR;
                    break;
                case "RN":
                    estado = DFe.Classes.Entidades.Estado.RN;
                    break;
                case "EX":
                    estado = DFe.Classes.Entidades.Estado.EX;
                    break;
                case "AL":
                    estado = DFe.Classes.Entidades.Estado.AL;
                    break;
                case "CE":
                    estado = DFe.Classes.Entidades.Estado.CE;
                    break;
                case "SC":
                    estado = DFe.Classes.Entidades.Estado.SC;
                    break;
                case "SP":
                    estado = DFe.Classes.Entidades.Estado.SP;
                    break;
                case "PB":
                    estado = DFe.Classes.Entidades.Estado.PB;
                    break;
            }

            return estado;
        }
        private static NFe.Classes.NFe Fiscal_DocumentoFiscal_Gerar(ref NotaFiscalSaidaViewModel notaFiscalSaidaViewModel,
                                                                    ref IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels,
                                                                    ref IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels,
                                                                    ref IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels,
                                                                    ref NotaFiscalSaidaSerieViewModel notaFiscalSaidaSerieViewModel,
                                                                    NFe.Utils.ConfiguracaoServico oConfig,
                                                                    ref string sCD_NFCe_DetalheVendaNormal, 
                                                                    ref string sCD_NFCe_DetalheVendaContigencia, 
                                                                    ref string sCD_NFCe_Token_ID, 
                                                                    ref string sCD_NFCe_Token_CSC)
        {
            NFe.Classes.NFe oNFe;
            NFe.Classes.Informacoes.Detalhe.det oNFE_Det;
            NFe.Classes.Informacoes.Cobranca.dup oNFE_Dup = null;
            NFe.Classes.Informacoes.Pagamento.pag oNFE_Pag;
            NFe.Classes.Informacoes.Pagamento.card oNFE_Card;
            NFe.Classes.Informacoes.Pagamento.detPag oNFE_Pag_Det;
            NFe.Classes.Informacoes.autXML oNFE_autXML;
            string sDS_PATH_XML;
            string sAux;
            bool bClienteNaoInformado = false;

            string sNF;
            string sDS_INFORMACOES_ADICIONAIS = "";
            string sDS_INFORMACOES_FISCO = "";

            TipoNFe tipoNfe = TipoNFe.tnSaida;

            try
            {
                if ((notaFiscalSaidaMercadoriaViewModels.FirstOrDefault().TabelaCFOP.GrupoCFOP.TipoOperacaoCFOP == TipoOperacaoCFOP.EntradaDentroEstado) ||
                    (notaFiscalSaidaMercadoriaViewModels.FirstOrDefault().TabelaCFOP.GrupoCFOP.TipoOperacaoCFOP == TipoOperacaoCFOP.EntradaForaEstado) ||
                    (notaFiscalSaidaMercadoriaViewModels.FirstOrDefault().TabelaCFOP.GrupoCFOP.TipoOperacaoCFOP == TipoOperacaoCFOP.EntradaExterior))
                    tipoNfe = TipoNFe.tnEntrada;
            }
            catch (Exception e)
            {
                tipoNfe = TipoNFe.tnSaida;
            }

            try
            {
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Serie))
                {
                    CaixaMensagem.Informacao("O número de série do documento não foi informado");
                    return null;
                }
                if (Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.RegimeTributario))
                {
                    CaixaMensagem.Informacao("É preciso informar o C.R.T. (Código de Regime Tributário)");
                    return null;
                }
                if (Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Empresa) || Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Empresa.Endereco))
                {
                    CaixaMensagem.Informacao("Endereço da empresa não cadastrado");
                    return null;
                }
                if ((NF_Modelo)Convert.ToInt16(notaFiscalSaidaViewModel.Modelo) != NF_Modelo.CupomFiscalEletronica)
                {
                    if ((Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Cliente) ||
                         Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Cliente.Endereco) ||
                         Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade) ||
                         Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade.Estado)) &&
                        notaFiscalSaidaViewModel.TransmitirEnderecoCliente)
                    {
                        CaixaMensagem.Informacao("Endereço do destinatário não cadastrado");
                        return null;
                    }
                }
                if (String.IsNullOrEmpty(notaFiscalSaidaSerieViewModel.UltimaNotaFiscal))
                    notaFiscalSaidaSerieViewModel.UltimaNotaFiscal = "0";
                if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.NotaFiscal))
                {
                    Fiscal_Historico(0, 0 /* iSQ_DOCUMENTOFISCAL */, "Criação do XML do documento fiscal");

                    sNF = (Convert.ToInt16(notaFiscalSaidaSerieViewModel.UltimaNotaFiscal) + 1).ToString();

                    notaFiscalSaidaSerieViewModel.UltimaNotaFiscal = sNF;
                    notaFiscalSaidaSerieViewModel.UltimaNotaFiscalSaidaId = notaFiscalSaidaViewModel.Id;

                    notaFiscalSaidaViewModel.NotaFiscal = sNF;
                }
                else
                {
                    Fiscal_Historico(0, 0 /* iSQ_DOCUMENTOFISCAL */, "Correção do XML do documento fiscal");

                    sNF = notaFiscalSaidaViewModel.NotaFiscal;
                }
                if (notaFiscalSaidaViewModel.Cliente_Endereco.End_CidadeId == null)
                {
                    CaixaMensagem.Informacao("Endereço do cliente não informado");
                    return null;
                }

                oNFe = new NFe.Classes.NFe();

                oNFe.infNFe = new NFe.Classes.Informacoes.infNFe();
                oNFe.infNFe.versao = "4.00";
                oNFe.infNFe.ide = new NFe.Classes.Informacoes.Identificacao.ide();
                oNFe.infNFe.ide.cUF = (DFe.Classes.Entidades.Estado)Convert.ToInt16(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.Estado.CodigoIBGE);
                oNFe.infNFe.ide.natOp = TratarString(notaFiscalSaidaViewModel.NaturezaOperacao.Nome);
                oNFe.infNFe.ide.mod = (ModeloDocumento)Convert.ToInt16(notaFiscalSaidaViewModel.Modelo);
                oNFe.infNFe.ide.serie = Convert.ToInt16(notaFiscalSaidaViewModel.Serie);
                oNFe.infNFe.ide.nNF = Convert.ToInt16(sNF);
                oNFe.infNFe.ide.tpNF = tipoNfe;
                oNFe.infNFe.ide.cMunFG = Convert.ToInt32(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.CodigoIBGE);
                oNFe.infNFe.ide.tpEmis = TipoEmissao.teNormal;
                oNFe.infNFe.ide.tpImp = TipoImpressao.tiRetrato;
                oNFe.infNFe.ide.cNF = "1" + Convert.ToInt16(notaFiscalSaidaViewModel.NotaFiscal).ToString("0000000");
                oNFe.infNFe.ide.tpAmb = oConfig.tpAmb;
                oNFe.infNFe.ide.finNFe = FinalidadeNFe.fnNormal;
                oNFe.infNFe.ide.verProc = "4.000";

                if (oNFe.infNFe.ide.tpEmis != NFe.Classes.Informacoes.Identificacao.Tipos.TipoEmissao.teNormal)
                {
                    oNFe.infNFe.ide.dhCont = DateTime.Now;
                    oNFe.infNFe.ide.xJust = "TESTE DE CONTIGÊNCIA PARA NFe/NFCe";
                }

                if (notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.Estado.Codigo != notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade.Estado.Codigo)
                    oNFe.infNFe.ide.idDest = DestinoOperacao.doInterestadual;
                else
                    oNFe.infNFe.ide.idDest = DestinoOperacao.doInterna;

                oNFe.infNFe.ide.dhEmi = DateTime.Now;

                // Mude aqui para enviar a nfe vinculada ao EPEC, V3.10
                if (oNFe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFe)
                    oNFe.infNFe.ide.dhSaiEnt = DateTime.Now;

                oNFe.infNFe.ide.procEmi = NFe.Classes.Informacoes.Identificacao.Tipos.ProcessoEmissao.peAplicativoContribuinte;
                oNFe.infNFe.ide.indFinal = NFe.Classes.Informacoes.Identificacao.Tipos.ConsumidorFinal.cfConsumidorFinal;
                oNFe.infNFe.ide.indPres = NFe.Classes.Informacoes.Identificacao.Tipos.PresencaComprador.pcPresencial;

                // -- Emitente
                oNFe.infNFe.emit = new NFe.Classes.Informacoes.Emitente.emit();
                oNFe.infNFe.emit.CNPJ = Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Empresa.CNPJ);
                oNFe.infNFe.emit.xNome = TratarString(notaFiscalSaidaViewModel.Empresa.RazaoSocial);
                oNFe.infNFe.emit.xFant = TratarString(notaFiscalSaidaViewModel.Empresa.NomeFantasia);
                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.InscricaoEstadual))
                    oNFe.infNFe.emit.IE = notaFiscalSaidaViewModel.Empresa.InscricaoEstadual;
                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.InscricaoMunicipal))
                {
                    oNFe.infNFe.emit.IM = notaFiscalSaidaViewModel.Empresa.InscricaoMunicipal.Trim();
                    oNFe.infNFe.emit.CNAE = Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.InscricaoMunicipal).Trim();
                }

                oNFe.infNFe.emit.IEST = null;
                switch (notaFiscalSaidaViewModel.RegimeTributario)
                {
                    case RegimeTributario.RegimeNormal:
                        oNFe.infNFe.emit.CRT = NFe.Classes.Informacoes.Emitente.CRT.RegimeNormal;
                        break;
                    case RegimeTributario.SimplesNacional:
                        oNFe.infNFe.emit.CRT = NFe.Classes.Informacoes.Emitente.CRT.SimplesNacional;
                        break;
                    case RegimeTributario.SimplesNacional_ExcessoSublimiteReceitaBruta:
                        oNFe.infNFe.emit.CRT = NFe.Classes.Informacoes.Emitente.CRT.SimplesNacionalExcessoSublimite;
                        break;
                }
                // -- Emitente Endereço
                oNFe.infNFe.emit.enderEmit = new NFe.Classes.Informacoes.Emitente.enderEmit();
                if (notaFiscalSaidaViewModel.Empresa.Endereco != null)
                {
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_Logradouro)) { oNFe.infNFe.emit.enderEmit.xLgr = TratarString(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Logradouro)); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_Numero)) { oNFe.infNFe.emit.enderEmit.nro = TratarString(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Numero).Trim()); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_Complemento)) { oNFe.infNFe.emit.enderEmit.xCpl = TratarString(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Complemento).Trim()); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_Bairro)) { oNFe.infNFe.emit.enderEmit.xBairro = TratarString(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Bairro).Trim()); }
                    if (notaFiscalSaidaViewModel.Cliente.Endereco.End_Cidade != null)
                    {
                        if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.CodigoIBGE)) { oNFe.infNFe.emit.enderEmit.cMun = Convert.ToInt32(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.CodigoIBGE).Trim()); }
                        oNFe.infNFe.emit.enderEmit.xMun = TratarString(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.Nome).Trim());
                        if (notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.Estado != null)
                            oNFe.infNFe.emit.enderEmit.UF = EstadoDBParaEstadoZeus(Funcao.NuloParaString(notaFiscalSaidaViewModel.Empresa.Endereco.End_Cidade.Estado.Codigo).Trim());
                    }
                }
                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Endereco.End_CEP)) { oNFe.infNFe.emit.enderEmit.CEP = notaFiscalSaidaViewModel.Empresa.Endereco.End_CEP.Replace("-", "").Replace(".", "").PadLeft(8, '0'); }
                oNFe.infNFe.emit.enderEmit.cPais = 1058;
                oNFe.infNFe.emit.enderEmit.xPais = notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.Estado.Pais.Nome.Trim();

                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Empresa.Telefone))
                    oNFe.infNFe.emit.enderEmit.fone = Convert.ToInt32(Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Empresa.Telefone));

                // --Destinatário
                if (notaFiscalSaidaViewModel.Cliente != null)
                {
                    oNFe.infNFe.dest = new NFe.Classes.Informacoes.Destinatario.dest(VersaoServico.Versao400);
                    if (notaFiscalSaidaViewModel.Cliente.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Juridica)
                    {
                        oNFe.infNFe.dest.CNPJ = Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Cliente.CNPJ_CPF);
                    }
                    else if (notaFiscalSaidaViewModel.Cliente.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Fisica)
                    {
                        oNFe.infNFe.dest.CPF = Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Cliente.CNPJ_CPF);
                    }
                    else
                        bClienteNaoInformado = true;
                }
                else
                    bClienteNaoInformado = true;

                if (!bClienteNaoInformado)
                {
                    if (oNFe.infNFe.ide.tpAmb == TipoAmbiente.Homologacao)
                        oNFe.infNFe.dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    else
                        oNFe.infNFe.dest.xNome = TratarString(notaFiscalSaidaViewModel.Cliente.Nome);

                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_EMail))
                        oNFe.infNFe.dest.email = notaFiscalSaidaViewModel.Cliente_EMail;

                    if ((!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.InscricaoEstadual)) && (notaFiscalSaidaViewModel.Cliente.InscricaoEstadual.Trim().ToUpper() != "ISENTO"))
                        oNFe.infNFe.dest.IE = notaFiscalSaidaViewModel.Cliente.InscricaoEstadual;
                }

                if ((!bClienteNaoInformado) && (notaFiscalSaidaViewModel.Cliente_Endereco != null) && (notaFiscalSaidaViewModel.TransmitirEnderecoCliente))
                {
                    // --Destinatário Endereço
                    oNFe.infNFe.dest.enderDest = new NFe.Classes.Informacoes.Destinatario.enderDest();
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_Logradouro)) { oNFe.infNFe.dest.enderDest.xLgr = TratarString(notaFiscalSaidaViewModel.Cliente_Endereco.End_Logradouro); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_Numero)) { oNFe.infNFe.dest.enderDest.nro = TratarString(notaFiscalSaidaViewModel.Cliente_Endereco.End_Numero); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_Complemento)) { oNFe.infNFe.dest.enderDest.xCpl = TratarString(notaFiscalSaidaViewModel.Cliente_Endereco.End_Complemento); }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_Bairro)) { oNFe.infNFe.dest.enderDest.xBairro = TratarString(notaFiscalSaidaViewModel.Cliente_Endereco.End_Bairro); }
                    if (notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade != null)
                    {
                        if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.CodigoIBGE))
                            oNFe.infNFe.dest.enderDest.cMun = Convert.ToInt32(notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.CodigoIBGE);
                        oNFe.infNFe.dest.enderDest.xMun = TratarString(notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.Nome);
                        oNFe.infNFe.dest.enderDest.UF = notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.Estado.Codigo;
                        if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Endereco.End_CEP))
                            oNFe.infNFe.dest.enderDest.CEP = notaFiscalSaidaViewModel.Cliente_Endereco.End_CEP.Replace("-", "").Replace(".", "").PadLeft(8, '0');
                        oNFe.infNFe.dest.enderDest.cPais = 1058;
                        oNFe.infNFe.dest.enderDest.xPais = notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade.Estado.Pais.Nome;
                    }
                }
                if (!bClienteNaoInformado)
                {
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente_Telefone))
                        oNFe.infNFe.dest.enderDest.fone = Convert.ToInt32(Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Cliente_Telefone));
                }
                if (oNFe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFCe)
                {
                    if (!bClienteNaoInformado)
                        oNFe.infNFe.dest.indIEDest = NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte;
                }
                else
                {
                    if (oNFe.infNFe.dest != null)
                    {
                        if (String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.InscricaoEstadual) || (notaFiscalSaidaViewModel.Cliente.InscricaoEstadual.Trim().ToUpper() == "ISENTO"))
                        { oNFe.infNFe.dest.indIEDest = NFe.Classes.Informacoes.Destinatario.indIEDest.Isento; }
                        else
                        { oNFe.infNFe.dest.indIEDest = NFe.Classes.Informacoes.Destinatario.indIEDest.ContribuinteICMS; }
                    }
                    else
                    {
                        oNFe.infNFe.dest.indIEDest = NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte;

                        if ((notaFiscalSaidaViewModel.Empresa.TipoContribuinteICMS == NF_TipoContribuinteICMS.ContribuinteICMS) && (!bClienteNaoInformado))
                        {
                            if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.InscricaoEstadual))
                                oNFe.infNFe.dest.IE = notaFiscalSaidaViewModel.Cliente.InscricaoEstadual;

                            if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Cliente.InscricaoMunicipal))
                                oNFe.infNFe.dest.IM = notaFiscalSaidaViewModel.Cliente.InscricaoMunicipal;
                        }
                    }
                }

                // -- Transporte
                if (notaFiscalSaidaViewModel.TransportadoraId == Guid.Empty)
                {
                    oNFe.infNFe.transp = new NFe.Classes.Informacoes.Transporte.transp();
                    oNFe.infNFe.transp.modFrete = NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfSemFrete;
                }
                else
                {
                    oNFe.infNFe.transp = new NFe.Classes.Informacoes.Transporte.transp();
                    oNFe.infNFe.transp.modFrete = (ModalidadeFrete)notaFiscalSaidaViewModel.Transportadora_FreteConta.GetHashCode();

                    if (oNFe.infNFe.transp.modFrete != ModalidadeFrete.mfSemFrete)
                    {
                        oNFe.infNFe.transp.transporta = new NFe.Classes.Informacoes.Transporte.transporta();

                        if ((notaFiscalSaidaViewModel.TransportadoraId != null) && (notaFiscalSaidaViewModel.TransportadoraId != Guid.Empty))
                        {
                            if (notaFiscalSaidaViewModel.Transportadora.TipoPessoa == Funcoes._Enum.TipoPessoa.Juridica)
                                oNFe.infNFe.transp.transporta.CNPJ = Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Transportadora.CNPJ_CPF);
                            else
                                oNFe.infNFe.transp.transporta.CPF = Funcoes._Classes.Texto.SomenteNumero(notaFiscalSaidaViewModel.Transportadora.CNPJ_CPF);

                            oNFe.infNFe.transp.transporta.xNome = Funcoes._Classes.Texto.NuloString(notaFiscalSaidaViewModel.Transportadora.Nome);
                            
                            if (notaFiscalSaidaViewModel.Transportadora.Endereco != null)
                            {
                                oNFe.infNFe.transp.transporta.xEnder = TratarString(Funcoes._Classes.Texto.NuloString(notaFiscalSaidaViewModel.Transportadora.Endereco.End_Logradouro));
                                oNFe.infNFe.transp.transporta.xMun = TratarString(Funcoes._Classes.Texto.NuloString(notaFiscalSaidaViewModel.Transportadora.Endereco.End_Cidade.Nome));
                                oNFe.infNFe.transp.transporta.UF = Funcoes._Classes.Texto.NuloString(notaFiscalSaidaViewModel.Transportadora.Endereco.End_Cidade.Estado.Codigo);
                            }

                            if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.Transportadora.InscricaoEstadual))
                                oNFe.infNFe.transp.transporta.IE = notaFiscalSaidaViewModel.Transportadora.InscricaoEstadual;
                        }
                    }
                }

                if (oNFe.infNFe.transp != null)
                {
                    var vol = new NFe.Classes.Informacoes.Transporte.vol();

                    vol.pesoB = (decimal?)notaFiscalSaidaViewModel.VolumeTransportados_PesoBruto;
                    vol.pesoL = (decimal?)notaFiscalSaidaViewModel.VolumeTransportados_PesoLiquido;
                    vol.qVol = notaFiscalSaidaViewModel.VolumeTransportados_Quantidade;

                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.VolumeTransportados_Especie))
                    {
                        vol.esp = notaFiscalSaidaViewModel.VolumeTransportados_Especie;
                    }
                    if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.VolumeTransportados_Marca))
                    {
                        vol.marca = notaFiscalSaidaViewModel.VolumeTransportados_Marca;
                    }

                    oNFe.infNFe.transp.vol = new List<NFe.Classes.Informacoes.Transporte.vol>();
                    oNFe.infNFe.transp.vol.Add(vol);
                }

                // -- Detalhe
                int nItem = 0;
                OrigemMercadoria origemMercadoriaServico;

                foreach (NotaFiscalSaidaMercadoriaViewModel ntFSMercadoria in notaFiscalSaidaMercadoriaViewModels)
                {
                    nItem++;

                    if (ntFSMercadoria.Mercadoria.Fiscal_TabelaOrigemMercadoriaServico == null)
                    {
                        CaixaMensagem.Informacao("É preciso informa a origem do produto " + ntFSMercadoria.Mercadoria.Nome);
                        return null;
                    }

                    origemMercadoriaServico = (OrigemMercadoria) Convert.ToInt16(ntFSMercadoria.Mercadoria.Fiscal_TabelaOrigemMercadoriaServico.Codigo);

                    oNFE_Det = new NFe.Classes.Informacoes.Detalhe.det();

                    oNFE_Det.nItem = nItem;

                    // -- Detalhe Dados do Produto
                    oNFE_Det.prod = new NFe.Classes.Informacoes.Detalhe.prod();
                    oNFE_Det.prod.cProd = ntFSMercadoria.Mercadoria.Codigo.ToString("000000");

                    if (String.IsNullOrEmpty(ntFSMercadoria.Mercadoria.CodigoBarra))
                        oNFE_Det.prod.cEAN = "SEM GTIN";
                    else
                        oNFE_Det.prod.cEAN = ntFSMercadoria.Mercadoria.CodigoBarra.Trim();

                    if (oNFe.infNFe.ide.tpAmb == TipoAmbiente.Homologacao)
                        oNFE_Det.prod.xProd = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    else
                        oNFE_Det.prod.xProd = ntFSMercadoria.Mercadoria.Nome.Trim();

                    oNFE_Det.prod.NCM = ntFSMercadoria.TabelaNCM.Codigo.Trim();
                    oNFE_Det.prod.CFOP = Convert.ToInt32(ntFSMercadoria.TabelaCFOP.Codigo.Trim());
                    oNFE_Det.prod.uCom = ntFSMercadoria.UnidadeMedida.Codigo.Trim();
                    oNFE_Det.prod.qCom = ntFSMercadoria.Quantidade;
                    oNFE_Det.prod.vUnCom = Convert.ToDecimal(ntFSMercadoria.PrecoUnitario);
                    oNFE_Det.prod.vProd = Convert.ToDecimal(ntFSMercadoria.PrecoTotal);
                    oNFE_Det.prod.vDesc = 0;
                    oNFE_Det.prod.vFrete = Convert.ToDecimal(ntFSMercadoria.ValorFrete);
                    oNFE_Det.prod.vSeg = 0;
                    // -- Detalhe Dados do Produto Tributação
                    if (String.IsNullOrEmpty(ntFSMercadoria.Mercadoria.CodigoBarra))
                        oNFE_Det.prod.cEANTrib = "SEM GTIN";
                    else
                        oNFE_Det.prod.cEANTrib = ntFSMercadoria.Mercadoria.CodigoBarra;
                    oNFE_Det.prod.uTrib = ntFSMercadoria.UnidadeMedida.Codigo;
                    oNFE_Det.prod.qTrib = ntFSMercadoria.Quantidade;
                    oNFE_Det.prod.vUnTrib = Convert.ToDecimal(ntFSMercadoria.PrecoUnitario);
                    // -- Detalhe Dados do Produto Totaliza
                    oNFE_Det.prod.indTot = NFe.Classes.Informacoes.Detalhe.IndicadorTotal.ValorDoItemCompoeTotalNF;

                    // -- Detalhe Impostos
                    oNFE_Det.imposto = new NFe.Classes.Informacoes.Detalhe.Tributacao.imposto();
                    oNFE_Det.imposto.vTotTrib = 0;
                    // -- Detalhe Imposto ICMS
                    oNFE_Det.imposto.ICMS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.ICMS();
                    try
                    {
                        oNFE_Det.imposto.ICMS.TipoICMS = ObterIcmsBasico(oNFe.infNFe.emit.CRT, origemMercadoriaServico, CSTDBParaZeus(ntFSMercadoria.TabelaCST_CSOSN.Codigo),
                                                                         DeterminacaoBaseIcms.DbiPauta, CSOSNDBParaZeus(ntFSMercadoria.TabelaCST_CSOSN.Codigo), ntFSMercadoria.ValorBaseCalculo,
                                                                         ntFSMercadoria.AliquotaICMS, ntFSMercadoria.ValorICMS);
                    }
                    catch (Exception)
                    {
                    }
                    // -- Detalhe Imposto COFINS
                    if (ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS == null)
                        ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS = ntFSMercadoria.Mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINS;

                    //if ((ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS != null) && (ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS.DestacarPIS_COFINS))
                    if (ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS != null)
                    {
                        oNFE_Det.imposto.COFINS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.COFINS();
                        try
                        {
                            oNFE_Det.imposto.COFINS.TipoCOFINS = ObterCofinsBasico(ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS.Percentual,
                                                                                   CSTCOFINSDBParaZeus(ntFSMercadoria.TabelaCST_PIS_COFINS_COFINS.Codigo), ntFSMercadoria.PrecoTotal, ntFSMercadoria.AliquotaCOFINS,
                                                                                   Valor.Percentagem(ntFSMercadoria.PrecoTotal, ntFSMercadoria.AliquotaCOFINS), ntFSMercadoria.Quantidade, ntFSMercadoria.PrecoUnitario);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    // -- Detalhe Imposto PIS
                    if (ntFSMercadoria.TabelaCST_PIS_COFINS_PIS == null)
                        ntFSMercadoria.TabelaCST_PIS_COFINS_PIS = ntFSMercadoria.Mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPIS;

                    //if ((ntFSMercadoria.TabelaCST_PIS_COFINS_PIS != null) && (ntFSMercadoria.TabelaCST_PIS_COFINS_PIS.DestacarPIS_COFINS))
                    if (ntFSMercadoria.TabelaCST_PIS_COFINS_PIS != null)
                    {
                        oNFE_Det.imposto.PIS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.PIS();
                        try
                        {
                            oNFE_Det.imposto.PIS.TipoPIS = ObterPisBasico(ntFSMercadoria.TabelaCST_PIS_COFINS_PIS.Percentual, CSTPISDBParaZeus(ntFSMercadoria.TabelaCST_PIS_COFINS_PIS.Codigo),
                                                                          ntFSMercadoria.PrecoTotal, ntFSMercadoria.AliquotaPIS, Valor.Percentagem(ntFSMercadoria.PrecoTotal, ntFSMercadoria.AliquotaPIS),
                                                                          ntFSMercadoria.Quantidade, ntFSMercadoria.PrecoUnitario);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    // -- Detalhe Imposto IPI
                    // NFC-e não aceita grupo "IPI"
                    if ((notaFiscalSaidaViewModel.Modelo == "55"))
                    {
                        if (ntFSMercadoria.TabelaCST_IPI != null)
                        {
                            oNFE_Det.imposto.IPI = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.IPI();
                            oNFE_Det.imposto.IPI.cEnq = 999;
                            try
                            {
                                oNFE_Det.imposto.IPI.TipoIPI = ObterIPIBasico(CSTIPIDBParaZeus(ntFSMercadoria.TabelaCST_IPI.Codigo), ntFSMercadoria.ValorBaseIPI, ntFSMercadoria.AliquotaIPI, ntFSMercadoria.ValorIPI);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                    oNFe.infNFe.det.Add(oNFE_Det);
                }

                // -- Total
                try
                {
                    oNFe.infNFe.total = GetTotal("4.00", oNFe.infNFe.det);
                    oNFe.infNFe.total.ICMSTot.vFrete = notaFiscalSaidaViewModel.ValorFrete;
                }
                catch (Exception)
                {
                    if (oNFe.infNFe.total == null)
                    {
                        oNFe.infNFe.total = new total();
                    }
                    if (oNFe.infNFe.total.ICMSTot == null)
                    {
                        oNFe.infNFe.total.ICMSTot = new ICMSTot();
                        oNFe.infNFe.total.ICMSTot.vFrete = notaFiscalSaidaViewModel.ValorFrete;
                    }
                }

                // -- Cobrança
                if (oNFe.infNFe.ide.mod == ModeloDocumento.NFe)
                {
                    oNFe.infNFe.cobr = new NFe.Classes.Informacoes.Cobranca.cobr();
                    oNFe.infNFe.cobr.fat = new NFe.Classes.Informacoes.Cobranca.fat();
                    oNFe.infNFe.cobr.fat.nFat = sNF;
                    oNFe.infNFe.cobr.fat.vLiq = oNFe.infNFe.total.ICMSTot.vNF;
                    oNFe.infNFe.cobr.fat.vOrig = oNFe.infNFe.total.ICMSTot.vNF;
                    oNFe.infNFe.cobr.fat.vDesc = 0M;
                }

                if (oNFe.infNFe.ide.mod == ModeloDocumento.NFCe || (oNFe.infNFe.ide.mod == ModeloDocumento.NFe))
                {
                    if ((notaFiscalSaidaPagamentoViewModels == null) || (notaFiscalSaidaPagamentoViewModels.Count() == 0))
                    {
                        oNFE_Pag = new NFe.Classes.Informacoes.Pagamento.pag();
                        oNFE_Pag.detPag = new List<NFe.Classes.Informacoes.Pagamento.detPag>();
                        oNFE_Pag_Det = new NFe.Classes.Informacoes.Pagamento.detPag();
                        oNFE_Pag_Det.tPag = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpSemPagamento;
                        oNFE_Pag_Det.vPag = 0;
                        oNFE_Pag.detPag.Add(oNFE_Pag_Det);

                        oNFe.infNFe.pag = new List<NFe.Classes.Informacoes.Pagamento.pag>();
                        oNFe.infNFe.pag.Add(oNFE_Pag);
                    }
                    else
                        foreach (NotaFiscalSaidaPagamentoViewModel notaFiscalSaidaPagamentoViewModel in notaFiscalSaidaPagamentoViewModels)
                        {
                            oNFe.infNFe.pag = new List<NFe.Classes.Informacoes.Pagamento.pag>();
                            oNFE_Pag = new NFe.Classes.Informacoes.Pagamento.pag();
                            oNFE_Pag.vTroco = 0;
                            // Pagamento Detalhe
                            oNFE_Pag.detPag = new List<NFe.Classes.Informacoes.Pagamento.detPag>();
                            oNFE_Pag_Det = new NFe.Classes.Informacoes.Pagamento.detPag();
                            oNFE_Pag_Det.tPag = FormaPagamentoDBParaZeus(notaFiscalSaidaPagamentoViewModel.FormaPagamento);

                            oNFE_Pag_Det.vPag = notaFiscalSaidaPagamentoViewModel.Valor;

                            if (oNFE_Pag_Det.tPag == NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpCartaoCredito ||
                                oNFE_Pag_Det.tPag == NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpCartaoDebito)
                            {
                                oNFE_Card = new NFe.Classes.Informacoes.Pagamento.card();
                                oNFE_Card.tpIntegra = TipoIntegracaoPagamento.TipNaoIntegrado;
                                //oNFE_Card.CNPJ = oData_02.Rows(iCont).Item("CD_CPF_CNPJ");
                                oNFE_Card.tBand = BandeiraCartao.bcOutros;
                                //oNFE_Card.cAut = oData_02.Rows(iCont).Item("CD_AUTORIZACAO");
                                oNFE_Pag_Det.card = oNFE_Card;
                            }

                            oNFE_Pag.detPag.Add(oNFE_Pag_Det);

                            oNFe.infNFe.pag.Add(oNFE_Pag);
                        }
                }

                if (notaFiscalSaidaReferenciaViewModels != null)
                {
                    List<NFref> oListaNFref = new List<NFref>();
                    NFref oNFref;

                    foreach (NotaFiscalSaidaReferenciaViewModel notaFiscalSaidaReferenciaViewModel in notaFiscalSaidaReferenciaViewModels)
                    {
                        oNFref = new NFref();
                        
                        if (notaFiscalSaidaViewModel.NotaFiscalFinalidadeId == Guid.Parse("93844C9B-2ECD-4DDE-B8C1-7623E9072C03"))
                        {
                            oNFref.refNFe = notaFiscalSaidaReferenciaViewModel.CodigoChaveAcesso;

                            if (sDS_INFORMACOES_ADICIONAIS.Trim() != "") sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS + ". ";
                            sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS + "DEVOLUCAO REF: ";
                        }

                        oListaNFref.Add(oNFref);
                    }

                    oNFe.infNFe.ide.NFref = oListaNFref;
                }

                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.InformacoesComplementaresInteresseContribuinte_Obsersacao))
                    sDS_INFORMACOES_ADICIONAIS = notaFiscalSaidaViewModel.InformacoesComplementaresInteresseContribuinte_Obsersacao.Trim() + ". " + sDS_INFORMACOES_ADICIONAIS;

                if (!String.IsNullOrEmpty(notaFiscalSaidaViewModel.InformacoesAdicionaisInteresseFisco))
                    sDS_INFORMACOES_FISCO = notaFiscalSaidaViewModel.InformacoesAdicionaisInteresseFisco;

                if ((Strings.Trim(sDS_INFORMACOES_ADICIONAIS) != "") || (Strings.Trim(sDS_INFORMACOES_FISCO) != ""))
                {
                    oNFe.infNFe.infAdic = new NFe.Classes.Informacoes.Observacoes.infAdic();

                    if (Strings.Trim(sDS_INFORMACOES_ADICIONAIS) != "")
                    {
                        sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS.Trim();
                        if (sDS_INFORMACOES_ADICIONAIS.Substring(sDS_INFORMACOES_ADICIONAIS.Length - 1) == ".")
                            sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS.Substring(0, sDS_INFORMACOES_ADICIONAIS.Length - 1);
                        oNFe.infNFe.infAdic.infCpl = sDS_INFORMACOES_ADICIONAIS;
                    }

                    if (Strings.Trim(sDS_INFORMACOES_FISCO) != "")
                    {
                        sDS_INFORMACOES_FISCO = sDS_INFORMACOES_FISCO.Trim();
                        if (sDS_INFORMACOES_FISCO.Substring(sDS_INFORMACOES_FISCO.Length - 1) == ".")
                            sDS_INFORMACOES_FISCO = sDS_INFORMACOES_FISCO.Substring(0, sDS_INFORMACOES_FISCO.Length - 1);
                        oNFe.infNFe.infAdic.infAdFisco = sDS_INFORMACOES_FISCO;
                    }
                }

                oNFe.Assina(oConfig);

                if (oNFe.infNFe.ide.mod == ModeloDocumento.NFCe)
                {
                    if (oNFe.infNFeSupl == null)
                    {
                        oNFe.infNFeSupl = new infNFeSupl();
                        oNFe.infNFeSupl.urlChave = oNFe.infNFeSupl.ObterUrlConsulta(oNFe, VersaoQrCode.QrCodeVersao2);

                        /*sCD_NFCe_DetalheVendaNormal = iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_NORMAL;
                        sCD_NFCe_DetalheVendaContigencia = iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA;
                        sCD_NFCe_Token_ID = sESTACAO_TRABALHO_CD_NFCe_Token_ID;
                        sCD_NFCe_Token_CSC = sESTACAO_TRABALHO_CD_NFCe_Token_CSC.ToString().Replace("-", "");
                        sCD_NFCe_Token_CSC = sESTACAO_TRABALHO_CD_NFCe_Token_CSC;

                        oNFe.infNFeSupl.qrCode = oNFe.infNFeSupl.ObterUrlQrCode(oNFe, Val(sESTACAO_TRABALHO_CD_OPT_NFCe_VERSAO_QRCODE), sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);*/
                    }
                }
                /*
                sDS_PATH_XML = FNC_NVL(withBlock.Item("DS_PATH_XML"), "");

                if (FNC_Diretorio_Temporario() != "")
                {
                    try
                    {
                        sAux = FNC_Diretorio_Temporario() + "NF-" + sNF + "-" + withBlock.Item("CD_DOCUMENTOFISCAL_SERIE") + ".xml";
                        oNFe.SalvarArquivoXml(sAux);

                        if (sDS_PATH_XML.Trim() == "")
                            sDS_PATH_XML = FNC_DiretorioSistema_RemoverPath(FNC_DiretorioSistema_GuardarArquivo(sAux));
                        else
                            try
                            {
                                Kill(FNC_DiretorioSistema_AdicionarPath(sDS_PATH_XML));
                                FileCopy(sAux, FNC_DiretorioSistema_AdicionarPath(sDS_PATH_XML));
                            }
                            catch (Exception ex)
                            {
                            }
                    }
                    catch (Exception ex)
                    {
                        CaixaMensagem.Informacao("FNC_Fiscal_DocumentoFiscal_Gerar - SalvarArquivoXml: " + ex.Message);
                    }
                }
                */

                notaFiscalSaidaViewModel.CodigoChaveAcesso = Fiscal_ChaveNFe(oNFe);

                oNFe.Valida(oConfig);

                return oNFe;
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    CaixaMensagem.Informacao(ex.Message + ". " + Funcao.NuloParaString(ex.StackTrace));
                else
                    CaixaMensagem.Informacao(ex.Message + "." + ex.InnerException.Message);
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        private static int GetRandom()
        {
            var rand = new Random();
            return rand.Next(11111111, 99999999);
        }

        public static MDFe.Classes.Informacoes.MDFe Fiscal_ManifestoEletronicoDocumento_Transmitir(ViewModels.EmpresaViewModel empresa,
                                                                                                   ManifestoEletronicoDocumentoViewModel manifestoEletronicoDocumento)
        {
            Fiscal_Configuracao_MDFe();

            var mdfe = new MDFeEletronico();

            if (manifestoEletronicoDocumento != null)
            {
                DFe.Classes.Entidades.Estado oEstado = DFe.Classes.Entidades.Estado.MG;

                MDFeTpRod dadoVeiculo_TipoRodado = MDFeTpRod.Outros;
                MDFeTpCar dadoVeiculo_TipoCarroceria = MDFeTpCar.NaoAplicavel;

                switch (manifestoEletronicoDocumento.DadoVeiculo_TipoRodado)
                {
                    case MDFe_TipoRodado.Truck:
                        dadoVeiculo_TipoRodado = MDFeTpRod.Truck;
                        break;
                    case MDFe_TipoRodado.Toco:
                        dadoVeiculo_TipoRodado = MDFeTpRod.Toco;
                        break;
                    case MDFe_TipoRodado.CavaloMecanico:
                        dadoVeiculo_TipoRodado = MDFeTpRod.CavaloMecanico;
                        break;
                    case MDFe_TipoRodado.VAN:
                        dadoVeiculo_TipoRodado = MDFeTpRod.VAN;
                        break;
                    case MDFe_TipoRodado.Utilitario:
                        dadoVeiculo_TipoRodado = MDFeTpRod.Utilitario;
                        break;
                    case MDFe_TipoRodado.Outros:
                        dadoVeiculo_TipoRodado = MDFeTpRod.Outros;
                        break;
                }

                switch (manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria)
                {
                    case MDFe_TipoCarroceria.NaoAplicavel:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.NaoAplicavel;
                        break;
                    case MDFe_TipoCarroceria.Aberta:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.Aberta;
                        break;
                    case MDFe_TipoCarroceria.FechadaBau:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.FechadaBau;
                        break;
                    case MDFe_TipoCarroceria.Granelera:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.Granelera;
                        break;
                    case MDFe_TipoCarroceria.PortaContainer:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.PortaContainer;
                        break;
                    case MDFe_TipoCarroceria.Sider:
                        dadoVeiculo_TipoCarroceria = MDFeTpCar.Sider;
                        break;
                }

                oEstado = oEstado.SiglaParaEstado(Declaracoes.dados_Empresa_CodigoEstado);

                #region (ide)
                mdfe.InfMDFe.Ide.CUF = oEstado;
                mdfe.InfMDFe.Ide.TpAmb = TipoAmbiente.Producao;
                mdfe.InfMDFe.Ide.TpEmit = MDFeTipoEmitente.PrestadorServicoDeTransporte;
                mdfe.InfMDFe.Ide.Mod = ModeloDocumento.MDFe;
                mdfe.InfMDFe.Ide.Serie = Convert.ToInt16(manifestoEletronicoDocumento.ManifestoEletronicoDocumentoSerie.Serie);
                mdfe.InfMDFe.Ide.NMDF = Convert.ToInt64(manifestoEletronicoDocumento.Numero);
                mdfe.InfMDFe.Ide.CMDF = GetRandom();
                mdfe.InfMDFe.Ide.Modal = MDFeModal.Rodoviario;
                mdfe.InfMDFe.Ide.DhEmi = DateTime.Now;
                mdfe.InfMDFe.Ide.TpEmis = MDFeTipoEmissao.Normal;
                mdfe.InfMDFe.Ide.ProcEmi = MDFeIdentificacaoProcessoEmissao.EmissaoComAplicativoContribuinte;
                mdfe.InfMDFe.Ide.VerProc = "versao28383";
                mdfe.InfMDFe.Ide.UFIni = oEstado.SiglaParaEstado(manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos.FirstOrDefault().Estado.Codigo);
                mdfe.InfMDFe.Ide.UFFim = oEstado.SiglaParaEstado(manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos.LastOrDefault().Estado.Codigo);

                mdfe.InfMDFe.Ide.InfMunCarrega.Add(new MDFeInfMunCarrega
                {
                    CMunCarrega = manifestoEletronicoDocumento.CidadeCarregamento.CodigoIBGE,
                    XMunCarrega = manifestoEletronicoDocumento.CidadeCarregamento.Nome
                });

                #endregion (ide)

                #region dados emitente (emit)
                mdfe.InfMDFe.Emit.CNPJ = Declaracoes.dados_Empresa_CNPJ;
                mdfe.InfMDFe.Emit.IE = empresa.InscricaoEstadual;
                mdfe.InfMDFe.Emit.XNome = empresa.RazaoSocial;
                mdfe.InfMDFe.Emit.XFant = empresa.NomeFantasia;

                mdfe.InfMDFe.Emit.EnderEmit.XLgr = empresa.Endereco.End_Logradouro;
                mdfe.InfMDFe.Emit.EnderEmit.Nro = empresa.Endereco.End_Numero;
                mdfe.InfMDFe.Emit.EnderEmit.XCpl = empresa.Endereco.End_Complemento;
                mdfe.InfMDFe.Emit.EnderEmit.XBairro = empresa.Endereco.End_Bairro;
                mdfe.InfMDFe.Emit.EnderEmit.CMun = Convert.ToInt64(empresa.Endereco.End_Cidade.CodigoIBGE);
                mdfe.InfMDFe.Emit.EnderEmit.XMun = empresa.NomeFantasia;
                mdfe.InfMDFe.Emit.EnderEmit.CEP = long.Parse(empresa.Endereco.End_CEP);
                mdfe.InfMDFe.Emit.EnderEmit.UF = oEstado.SiglaParaEstado(empresa.Endereco.End_Cidade.Estado.Codigo);
                mdfe.InfMDFe.Emit.EnderEmit.Fone = empresa.Telefone;
                mdfe.InfMDFe.Emit.EnderEmit.Email = empresa.EMail;
                #endregion dados emitente (emit)

                #region modal
                //if (MDFeConfiguracao.VersaoWebService.VersaoLayout = VersaoServico.Versao100)
                //{
                //    mdfe.InfMDFe.InfModal.Modal = new MDFeRodo
                //    {
                //        RNTRC = config.Empresa.RNTRC,
                //        VeicTracao = new MDFeVeicTracao
                //        {
                //            Placa = "KKK9888",
                //            RENAVAM = "888888888",
                //            UF = Estado.GO,
                //            Tara = 222,
                //            CapM3 = 222,
                //            CapKG = 22,
                //            Condutor = new List<MDFeCondutor>
                //    {
                //        new MDFeCondutor
                //        {
                //            CPF = "11392381754",
                //            XNome = "Ricardão"
                //        }
                //    },
                //            TpRod = MDFeTpRod.Outros,
                //            TpCar = MDFeTpCar.NaoAplicavel
                //        }
                //    };
                //}


                //if (MDFeConfiguracao.VersaoWebService.VersaoLayout == VersaoServico.Versao300)
                //{
                mdfe.InfMDFe.InfModal.Modal = new MDFeRodo
                    {
                        infANTT = new MDFeInfANTT
                        {
                            RNTRC = manifestoEletronicoDocumento.RNTRCEmitente,

                        //    // não é obrigatorio
                        //    infCIOT = new List<infCIOT>
                        //{
                        //    new infCIOT
                        //    {
                        //        CIOT = "123456789123",
                        //        CNPJ = "21025760000123"
                        //    }
                        //}
                            /*valePed = new MDFeValePed
                            {
                                Disp = new List<MDFeDisp>
                                        {
                                            new MDFeDisp
                                            {
                                                CNPJForn = "21025760000123",
                                                CNPJPg = "21025760000123",
                                                NCompra = "838388383",
                                                vValePed = 100.33m
                                            }
                                        }
                            }*/
                        },

                        VeicTracao = new MDFeVeicTracao
                        {
                            Placa = manifestoEletronicoDocumento.DadoVeiculo_Placa.NumeroPlaca,
                            RENAVAM = manifestoEletronicoDocumento.DadoVeiculo_Placa.CodigoRenavan,
                            UF = oEstado.SiglaParaEstado(manifestoEletronicoDocumento.DadoVeiculo_Estado.Codigo),
                            Tara = (int?)manifestoEletronicoDocumento.DadoVeiculo_TaraKG,
                            CapM3 = (int?)manifestoEletronicoDocumento.DadoVeiculo_CapacidadeM3,
                            CapKG = (int?)manifestoEletronicoDocumento.DadoVeiculo_CapacidadeKG,
                            Condutor = new List<MDFeCondutor>
                        {
                            new MDFeCondutor
                            {
                                CPF = manifestoEletronicoDocumento.Condutor_CPF,
                                XNome = manifestoEletronicoDocumento.Condutor_Nome
                            }
                        },
                            TpRod = dadoVeiculo_TipoRodado,
                            TpCar = dadoVeiculo_TipoCarroceria
                        },

                        lacRodo = new List<MDFeLacre>
                    {
                        new MDFeLacre
                        {
                            NLacre = "lacre01"
                        }
                    }
                    };
                //}

                #endregion modal

                #region infMunDescarga
                manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas.ForEach(n =>
                {
                    mdfe.InfMDFe.InfDoc.InfMunDescarga = new List<MDFeInfMunDescarga>
                    {
                        new MDFeInfMunDescarga
                        {
                            XMunDescarga = n.CidadeDescarga.Nome,
                            CMunDescarga = n.CidadeDescarga.CodigoIBGE,
                            InfNFe = new List<MDFeInfNFe>
                            {
                                new MDFeInfNFe
                                {
                                    ChNFe = n.ChaveAcesso
                                }
                            }
                        }
                    };
                });


                //if (MDFeConfiguracao.VersaoWebService.VersaoLayout == VersaoServico.Versao300)
                //{
                //mdfe.InfMDFe.InfDoc.InfMunDescarga[0].InfCTe[0].Peri = new List<MDFePeri>
                //{
                //    new MDFePeri
                //    {
                //        NONU = "1111",
                //        QTotProd = "quantidade 20"
                //    }
                //};
                //}

                #endregion infMunDescarga

                //#region seg
                ////if (MDFeConfiguracao.VersaoWebService.VersaoLayout == VersaoServico.Versao300)
                ////{
                //    mdfe.InfMDFe.Seg = new List<MDFeSeg>();

                //    mdfe.InfMDFe.Seg.Add(new MDFeSeg
                //    {
                //        InfResp = new MDFeInfResp
                //        {
                //            CNPJ = "21025760000123",
                //            RespSeg = MDFeRespSeg.EmitenteDoMDFe
                //        },
                //        InfSeg = new MDFeInfSeg
                //        {
                //            CNPJ = "21025760000123",
                //            XSeg = "aaaaaaaaaa"
                //        },
                //        NApol = "aaaaaaaaaa",
                //        NAver = new List<string>
                //        {
                //            "aaaaaaaa"
                //        }
                //    });
                ////}

                //#endregion

                //#region Produto Predominante

                //if (MDFeConfiguracao.VersaoWebService.VersaoLayout == VersaoServico.Versao300)
                //{
                //    mdfe.InfMDFe.prodPred = new prodPred
                //    {
                //        tpCarga = tpCarga.CargaGeral,
                //        xProd = "aaaaaaaaaaaaaaaaaaaaa",
                //        infLotacao = new infLotacao
                //        {
                //            infLocalCarrega = new infLocalCarrega
                //            {
                //                CEP = "75950000"
                //            },
                //            infLocalDescarrega = new infLocalDescarrega
                //            {
                //                CEP = "75950000"
                //            }
                //        }
                //    };
                //}

                //#endregion

                #region Totais (tot)
                mdfe.InfMDFe.Tot.QNFe = manifestoEletronicoDocumento.QuantidadeNFe;
                mdfe.InfMDFe.Tot.vCarga = manifestoEletronicoDocumento.ValorTotalCarga;
                mdfe.InfMDFe.Tot.CUnid = MDFeCUnid.KG;
                mdfe.InfMDFe.Tot.QCarga = manifestoEletronicoDocumento.PesoBrutoCarga;
                #endregion Totais (tot)

                #region informações adicionais (infAdic)
                if (String.IsNullOrEmpty(manifestoEletronicoDocumento.InformacoesAdicionaisInteresseFisco))
                {
                    mdfe.InfMDFe.InfAdic = new MDFeInfAdic
                    {
                        InfCpl = manifestoEletronicoDocumento.InformacoesAdicionaisInteresseFisco
                    };
                }
                #endregion

                #region dados responsavel tecnico 
                mdfe.InfMDFe.infRespTec = new infRespTec
                {
                    CNPJ = empresa.Responsaveltecnico_CNPJ,
                    email = empresa.Responsaveltecnico_Email,
                    fone = empresa.Responsaveltecnico_Fone,
                    xContato = empresa.Responsaveltecnico_Contato
                };
                #endregion

                var servicoRecepcao = new MDFe.Servicos.RecepcaoMDFe.ServicoMDFeRecepcao();

                var retornoEnvio = servicoRecepcao.MDFeRecepcao(1, mdfe);
            }

            return mdfe;
        }

        private static total GetTotal(string sVersao, List<det> produtos)
        {
            var icmsTot = new ICMSTot() { vProd = produtos.Sum(p => p.prod.vProd), vDesc = produtos.Sum(p => p.prod.vDesc ?? 0), vTotTrib = produtos.Sum(p => p.imposto.vTotTrib ?? 0) };

            if (sVersao == "4.00")
                icmsTot.vICMSDeson = 0;

            if (sVersao == "4.00")
            {
                icmsTot.vFCPUFDest = 0;
                icmsTot.vICMSUFDest = 0;
                icmsTot.vICMSUFRemet = 0;
                icmsTot.vFCP = 0;
                icmsTot.vFCPST = 0;
                icmsTot.vFCPSTRet = 0;
                icmsTot.vIPIDevol = 0;
            }

            foreach (var produto in produtos)
            {
                if (produto.imposto.IPI != null && produto.imposto.IPI.TipoIPI.GetType() == typeof(IPITrib))
                    icmsTot.vIPI = icmsTot.vIPI + ((IPITrib)produto.imposto.IPI.TipoIPI).vIPI ?? 0;

                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS00))
                {
                    icmsTot.vBC = icmsTot.vBC + ((ICMS00)produto.imposto.ICMS.TipoICMS).vBC;
                    icmsTot.vICMS = icmsTot.vICMS + ((ICMS00)produto.imposto.ICMS.TipoICMS).vICMS;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS10))
                {
                    icmsTot.vBC = icmsTot.vBC + ((ICMS10)produto.imposto.ICMS.TipoICMS).vBC;
                    icmsTot.vICMS = icmsTot.vICMS + ((ICMS10)produto.imposto.ICMS.TipoICMS).vICMS;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS20))
                {
                    icmsTot.vBC = icmsTot.vBC + ((ICMS20)produto.imposto.ICMS.TipoICMS).vBC;
                    icmsTot.vICMS = icmsTot.vICMS + ((ICMS20)produto.imposto.ICMS.TipoICMS).vICMS;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS30))
                {
                    icmsTot.vBCST = icmsTot.vBCST + ((ICMS30)produto.imposto.ICMS.TipoICMS).vBCST;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS40))
                {
                    icmsTot.vICMSDeson = icmsTot.vICMSDeson + ((ICMS40)produto.imposto.ICMS.TipoICMS).vICMSDeson;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS51))
                {
                    icmsTot.vBC = icmsTot.vBC + Funcao.NuloParaValorD(((ICMS51)produto.imposto.ICMS.TipoICMS).vBC);
                    icmsTot.vICMS = icmsTot.vICMS + Funcao.NuloParaValorD(((ICMS51)produto.imposto.ICMS.TipoICMS).vICMS);
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS60))
                {
                    icmsTot.vFCPSTRet = icmsTot.vFCPSTRet + ((ICMS60)produto.imposto.ICMS.TipoICMS).vFCPSTRet;
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS70))
                {
                    icmsTot.vBC = icmsTot.vBC + Funcao.NuloParaValorD(((ICMS70)produto.imposto.ICMS.TipoICMS).vBC);
                    icmsTot.vICMS = icmsTot.vICMS + Funcao.NuloParaValorD(((ICMS70)produto.imposto.ICMS.TipoICMS).vICMS);
                }
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS90))
                {
                    icmsTot.vBC = icmsTot.vBC + Funcao.NuloParaValorD(((ICMS90)produto.imposto.ICMS.TipoICMS).vBC);
                    icmsTot.vICMS = icmsTot.vICMS + Funcao.NuloParaValorD(((ICMS90)produto.imposto.ICMS.TipoICMS).vICMS);
                }

                if (produto.imposto.PIS.TipoPIS.GetType() == typeof(PISAliq))
                {
                    icmsTot.vPIS = icmsTot.vPIS + Funcao.NuloParaValorD(((PISAliq)produto.imposto.PIS.TipoPIS).vPIS);
                }
                if (produto.imposto.PIS.TipoPIS.GetType() == typeof(PISQtde))
                {
                    icmsTot.vPIS = icmsTot.vPIS + Funcao.NuloParaValorD(((PISQtde)produto.imposto.PIS.TipoPIS).vPIS);
                }
                if (produto.imposto.PIS.TipoPIS.GetType() == typeof(PISOutr))
                {
                    icmsTot.vPIS = icmsTot.vPIS + Funcao.NuloParaValorD(((PISOutr)produto.imposto.PIS.TipoPIS).vPIS);
                }
                if (produto.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSAliq))
                {
                    icmsTot.vCOFINS = icmsTot.vCOFINS + Funcao.NuloParaValorD(((COFINSAliq)produto.imposto.COFINS.TipoCOFINS).vCOFINS);
                }
                if (produto.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSQtde))
                {
                    icmsTot.vCOFINS = icmsTot.vCOFINS + Funcao.NuloParaValorD(((COFINSQtde)produto.imposto.COFINS.TipoCOFINS).vCOFINS);
                }
                if (produto.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSOutr))
                {
                    icmsTot.vCOFINS = icmsTot.vCOFINS + Funcao.NuloParaValorD(((COFINSOutr)produto.imposto.COFINS.TipoCOFINS).vCOFINS);
                }

                if (produto.imposto.PIS.TipoPIS.GetType() == typeof(IPITrib))
                {
                    icmsTot.vIPI = icmsTot.vIPI + Funcao.NuloParaValorD(((IPITrib)produto.imposto.IPI.TipoIPI).vIPI);
                    icmsTot.vBC = icmsTot.vBC + Funcao.NuloParaValorD(((IPITrib)produto.imposto.IPI.TipoIPI).vBC);
                }
            }

            icmsTot.vNF = Convert.ToDecimal(icmsTot.vProd - icmsTot.vDesc - icmsTot.vICMSDeson + icmsTot.vST + icmsTot.vFCPST + icmsTot.vFrete + icmsTot.vSeg + icmsTot.vOutro + icmsTot.vII + icmsTot.vIPI + icmsTot.vIPIDevol);
            var t = new total() { ICMSTot = icmsTot };

            return t;
        }

        public static bool Fiscal_DocumentoFiscal_Transmitir(ModeloDocumento eModeloDocumento,
                                                             ref NotaFiscalSaidaViewModel notaFiscalSaidaViewModel,
                                                             ref IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels,
                                                             ref IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels,
                                                             ref IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels,
                                                             ref NotaFiscalSaidaSerieViewModel notaFiscalSaidaSerieViewModel,
                                                             ref string sDS_PATH_XML, 
                                                             ref bool bImpressaoNCFe, 
                                                             bool bImprimirDanfeNFe = false,
                                                             bool SomenteGerarXML = false,
                                                             string xml = "")
        {
            NFe.Classes.NFe oNFe;
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoNFeAutorizacao oNFe_Servico_RetornoNFeAutorizacao;
            NFe.Classes.nfeProc oNFe_Proc;
            NFe.Utils.ConfiguracaoServico oConfig;
            bool bVerificarProtocolo = false;
            bool bProblemaNFe = false;
            string sCD_PROTOCOLO = "";
            string sCD_NFCe_DetalheVendaNormal = "";
            string sCD_NFCe_DetalheVendaContigencia = "";
            string sCD_NFCe_Token_ID = "";
            string sCD_NFCe_Token_CSC = "";
            bool bOk = false;

            try
            {
                oConfig = Fiscal_Configuracao_NFe(eModeloDocumento);
                if (oConfig == null)
                    goto Sair;

                Fiscal_Historico(0, 0, "Início de transmissão");

                if (String.IsNullOrEmpty(xml))
                {
                    oNFe = Fiscal_DocumentoFiscal_Gerar(ref notaFiscalSaidaViewModel,
                                                        ref notaFiscalSaidaMercadoriaViewModels,
                                                        ref notaFiscalSaidaPagamentoViewModels,
                                                        ref notaFiscalSaidaReferenciaViewModels,
                                                        ref notaFiscalSaidaSerieViewModel,
                                                        oConfig,
                                                        ref sCD_NFCe_DetalheVendaNormal,
                                                        ref sCD_NFCe_DetalheVendaContigencia,
                                                        ref sCD_NFCe_Token_ID,
                                                        ref sCD_NFCe_Token_CSC);

                    if (oNFe != null)
                    {
                        xml = Declaracoes.Aplicacao_CaminhoDiretorioTemporaria + (SomenteGerarXML ? "\\gerado.xml" : "\\transmitir.xml");
                        oNFe.SalvarArquivoXml(xml);
                    }
                }

                if ((!String.IsNullOrEmpty(xml)) && !SomenteGerarXML)
                {
                    var retorno = Zeus.Protocolar(xml);

                    notaFiscalSaidaViewModel.DataRetornoSefaz = retorno.dhRegEvento;
                    notaFiscalSaidaViewModel.RetornoSefazCodigo = retorno.Protocolo.CStat.ToString();
                    notaFiscalSaidaViewModel.RetornoSefaz = retorno.Protocolo.XMotivo;

                    if (retorno.Protocolo.NProtocolo != "00")
                    {
                        notaFiscalSaidaViewModel.Protocolo = retorno.Protocolo.NProtocolo;
                        if (notaFiscalSaidaViewModel.DataTransmissao == null)
                            notaFiscalSaidaViewModel.DataTransmissao = retorno.dhRegEvento;
                    }
                    
                    switch (retorno.Protocolo.CStat)
                    {
                        case 302: /* Uso Denegado: Irregularidade fiscal do destinatário */
                            notaFiscalSaidaViewModel.Status = NF_Status.Denegada;
                            break;
                        case 101: /* Cancelamento de NF-e homologado */
                            notaFiscalSaidaViewModel.Status = NF_Status.Cancelado;
                            if (notaFiscalSaidaViewModel.DataCancelamento == null)
                                notaFiscalSaidaViewModel.DataCancelamento = retorno.dhRegEvento;
                            break;
                        case 100: /* Autorizado o uso da NF-e */
                            notaFiscalSaidaViewModel.Status = NF_Status.Transmitida;
                            break;
                        default:
                            notaFiscalSaidaViewModel.Status = NF_Status.Pendente;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                oConfig = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe_Servico = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe_Servico_RetornoNFeAutorizacao = null/* TODO Change to default(_) if this is not a reference type */;

                CaixaMensagem.Informacao(ex.Message);

                goto Sair;
            }

        Sair:
            return bOk;
        }

        public static bool Fiscal_DocumentoFiscal_Visualizar(ModeloDocumento eModeloDocumento,
                                                             ref NotaFiscalSaidaViewModel notaFiscalSaidaViewModel,
                                                             ref IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels,
                                                             ref IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels,
                                                             ref IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels,
                                                             ref NotaFiscalSaidaSerieViewModel notaFiscalSaidaSerieViewModel,
                                                             ref string sDS_PATH_XML,
                                                             bool imprimirCancelado = false)
        {
            NFe.Classes.NFe oNFe;
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoNFeAutorizacao oNFe_Servico_RetornoNFeAutorizacao;
            NFe.Classes.nfeProc oNFe_Proc;
            NFe.Utils.ConfiguracaoServico oConfig;
            string sCD_NFCe_DetalheVendaNormal = "";
            string sCD_NFCe_DetalheVendaContigencia = "";
            string sCD_NFCe_Token_ID = "";
            string sCD_NFCe_Token_CSC = "";
            bool bOk = false;
            string _PATH_DOCFISCAL = "";

            try
            {
                if (notaFiscalSaidaViewModel.Empresa.CNPJ.Length == 13)
                { _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\Enviados\\0" + notaFiscalSaidaViewModel.Empresa.CNPJ; }
                else
                { _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\Enviados\\" + notaFiscalSaidaViewModel.Empresa.CNPJ; }

                if (notaFiscalSaidaViewModel.DataTransmissao != null)
                {
                    DateTime dataTransmissao = (DateTime)notaFiscalSaidaViewModel.DataTransmissao;

                    _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\" + dataTransmissao.Year + "\\" + dataTransmissao.Month.ToString("00") + "\\" + dataTransmissao.Day.ToString("00");
                }

                _PATH_DOCFISCAL = _PATH_DOCFISCAL + "\\" + notaFiscalSaidaViewModel.CodigoChaveAcesso + "-procNfe.xml";
                _PATH_DOCFISCAL = Declaracoes.dados_Path_DocumentoFiscal + "\\" + _PATH_DOCFISCAL;
                _PATH_DOCFISCAL = _PATH_DOCFISCAL.Replace("\\\\", "\\");

                if (File.Exists(_PATH_DOCFISCAL))
                {
                    var data = File.ReadAllText(_PATH_DOCFISCAL);
                    GerarDanfe(data, imprimirCancelado, true);
                }
                else
                {
                    oConfig = Fiscal_Configuracao_NFe(eModeloDocumento);
                    if (oConfig == null)
                        goto Sair;

                    Fiscal_Historico(0, 0, "Início de transmissão");

                    oNFe = Fiscal_DocumentoFiscal_Gerar(ref notaFiscalSaidaViewModel,
                                                        ref notaFiscalSaidaMercadoriaViewModels,
                                                        ref notaFiscalSaidaPagamentoViewModels,
                                                        ref notaFiscalSaidaReferenciaViewModels,
                                                        ref notaFiscalSaidaSerieViewModel,
                                                        oConfig,
                                                        ref sCD_NFCe_DetalheVendaNormal,
                                                        ref sCD_NFCe_DetalheVendaContigencia,
                                                        ref sCD_NFCe_Token_ID,
                                                        ref sCD_NFCe_Token_CSC);

                    if (oNFe != null)
                    {
                        GerarDanfe(oNFe.ObterXmlString(), imprimirCancelado, true);
                    }
                    else
                        goto Sair;
                }
            }
            catch (Exception ex)
            {
                oConfig = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe_Servico = null/* TODO Change to default(_) if this is not a reference type */;
                oNFe_Servico_RetornoNFeAutorizacao = null/* TODO Change to default(_) if this is not a reference type */;

                CaixaMensagem.Informacao(ex.Message);

                goto Sair;
            }

        Sair:
            return bOk;
        }

        private static Csticms CSTDBParaZeus(string CD_CST)
        {
            switch (CD_CST)
            {
                case "00":
                    return Csticms.Cst00;
                    break;
                case "10":
                    return Csticms.Cst10;
                    break;
                case "20":
                    return Csticms.Cst20;
                    break;
                case "30":
                    return Csticms.Cst30;
                    break;
                case "40":
                    return Csticms.Cst40;
                    break;
                case "41":
                    return Csticms.Cst41;
                    break;
                case "50":
                    return Csticms.Cst50;
                    break;
                case "51":
                    return Csticms.Cst51;
                    break;
                case "60":
                    return Csticms.Cst60;
                    break;
                case "70":
                    return Csticms.Cst70;
                    break;
                case "90":
                    return Csticms.Cst90;
                    break;
                default:
                    return 0;
            }
        }

        private static Csosnicms CSOSNDBParaZeus(string CSOSN)
        {
            switch (CSOSN)
            {
                case "101":
                    return Csosnicms.Csosn101;
                case "102":
                    return Csosnicms.Csosn102;
                case "103":
                    return Csosnicms.Csosn103;
                case "300":
                    return Csosnicms.Csosn300;
                case "400":
                    return Csosnicms.Csosn400;
                case "201":
                    return Csosnicms.Csosn201;
                case "202":
                    return Csosnicms.Csosn202;
                case "203":
                    return Csosnicms.Csosn203;
                case "500":
                    return Csosnicms.Csosn500;
                case "900":
                    return Csosnicms.Csosn900;
                default:
                    return 0;
            }
        }

        private static CSTCOFINS CSTCOFINSDBParaZeus(string COFINS)
        {
            switch (COFINS)
            {
                case "01":
                    return CSTCOFINS.cofins01;
                case "02":
                    return CSTCOFINS.cofins02;
                case "03":
                    return CSTCOFINS.cofins03;
                case "04":
                    return CSTCOFINS.cofins04;
                case "05":
                    return CSTCOFINS.cofins05;
                case "06":
                    return CSTCOFINS.cofins06;
                case "07":
                    return CSTCOFINS.cofins07;
                case "08":
                    return CSTCOFINS.cofins08;
                case "09":
                    return CSTCOFINS.cofins09;
                case "49":
                    return CSTCOFINS.cofins49;
                case "50":
                    return CSTCOFINS.cofins50;
                case "51":
                    return CSTCOFINS.cofins51;
                case "52":
                    return CSTCOFINS.cofins52;
                case "53":
                    return CSTCOFINS.cofins53;
                case "54":
                    return CSTCOFINS.cofins54;
                case "55":
                    return CSTCOFINS.cofins55;
                case "56":
                    return CSTCOFINS.cofins56;
                case "60":
                    return CSTCOFINS.cofins60;
                case "61":
                    return CSTCOFINS.cofins61;
                case "62":
                    return CSTCOFINS.cofins62;
                case "63":
                    return CSTCOFINS.cofins63;
                case "64":
                    return CSTCOFINS.cofins64;
                case "65":
                    return CSTCOFINS.cofins65;
                case "66":
                    return CSTCOFINS.cofins66;
                case "67":
                    return CSTCOFINS.cofins67;
                case "70":
                    return CSTCOFINS.cofins70;
                case "71":
                    return CSTCOFINS.cofins71;
                case "72":
                    return CSTCOFINS.cofins72;
                case "73":
                    return CSTCOFINS.cofins73;
                case "74":
                    return CSTCOFINS.cofins74;
                case "75":
                    return CSTCOFINS.cofins75;
                case "98":
                    return CSTCOFINS.cofins98;
                case "99":
                    return CSTCOFINS.cofins99;
                default:
                    return 0;
            }
        }

        private static CSTPIS CSTPISDBParaZeus(string PIS)
        {
            switch (PIS)
            {
                case "01":
                    return CSTPIS.pis01;
                case "02":
                    return CSTPIS.pis02;
                case "03":
                    return CSTPIS.pis03;
                case "04":
                    return CSTPIS.pis04;
                case "05":
                    return CSTPIS.pis05;
                case "06":
                    return CSTPIS.pis06;
                case "07":
                    return CSTPIS.pis07;
                case "08":
                    return CSTPIS.pis08;
                case "09":
                    return CSTPIS.pis09;
                case "49":
                    return CSTPIS.pis49;
                case "50":
                    return CSTPIS.pis50;
                case "51":
                    return CSTPIS.pis51;
                case "52":
                    return CSTPIS.pis52;
                case "53":
                    return CSTPIS.pis53;
                case "54":
                    return CSTPIS.pis54;
                case "55":
                    return CSTPIS.pis55;
                case "56":
                    return CSTPIS.pis56;
                case "60":
                    return CSTPIS.pis60;
                case "61":
                    return CSTPIS.pis61;
                case "62":
                    return CSTPIS.pis62;
                case "63":
                    return CSTPIS.pis63;
                case "64":
                    return CSTPIS.pis64;
                case "65":
                    return CSTPIS.pis65;
                case "66":
                    return CSTPIS.pis66;
                case "67":
                    return CSTPIS.pis67;
                case "70":
                    return CSTPIS.pis70;
                case "71":
                    return CSTPIS.pis71;
                case "72":
                    return CSTPIS.pis72;
                case "73":
                    return CSTPIS.pis73;
                case "74":
                    return CSTPIS.pis74;
                case "75":
                    return CSTPIS.pis75;
                case "98":
                    return CSTPIS.pis98;
                case "99":
                    return CSTPIS.pis99;
                default:
                    return 0;
            }
        }
        private static CSTIPI CSTIPIDBParaZeus(string IPI)
        {
            switch (IPI)
            {
                case "00":
                    return CSTIPI.ipi00;
                case "49":
                    return CSTIPI.ipi49;
                case "50":
                    return CSTIPI.ipi50;
                case "99":
                    return CSTIPI.ipi99;
                case "01":
                    return CSTIPI.ipi01;
                case "02":
                    return CSTIPI.ipi02;
                case "03":
                    return CSTIPI.ipi03;
                case "04":
                    return CSTIPI.ipi04;
                case "05":
                    return CSTIPI.ipi05;
                case "51":
                    return CSTIPI.ipi51;
                case "52":
                    return CSTIPI.ipi52;
                case "53":
                    return CSTIPI.ipi53;
                case "54":
                    return CSTIPI.ipi54;
                case "55":
                    return CSTIPI.ipi55;
                default:
                    return 0;
            }
        }
        private static NFe.Classes.Informacoes.Pagamento.FormaPagamento FormaPagamentoDBParaZeus(Entidade.Modelos.FormaPagamento formaPagamento)
        {
            NFe.Classes.Informacoes.Pagamento.FormaPagamento eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpOutro;

            switch (formaPagamento.NomeInterno.Trim().ToUpper())
            {
                case "DINHEIRO":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpDinheiro;
                        break;
                    }

                case "CARTAOCREDITO":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpCartaoCredito;
                        break;
                    }

                case "CARTAODEBITO":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpCartaoDebito;
                        break;
                    }

                case "CHEQUE":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpCheque;
                        break;
                    }

                case "NOTAPROMISSORIA":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpDuplicataMercantil;
                        break;
                    }

                case "CREDITOCEDIDO":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpDinheiro;
                        break;
                    }

                case "DEPOSITOBANCARIO":
                    {
                        eFormaPagamento = NFe.Classes.Informacoes.Pagamento.FormaPagamento.fpBoletoBancario;
                        break;
                    }
            }

            return eFormaPagamento;
        }
        private static ICMSBasico ObterIcmsBasico(CRT oCrt, 
                                                  NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos.OrigemMercadoria eOrigemMercadoria, 
                                                  Csticms eCST, 
                                                  DeterminacaoBaseIcms emodBC, 
                                                  Csosnicms eCSOSN, 
                                                  decimal vBC, 
                                                  decimal pICMS, 
                                                  decimal vICMS)
        {
            var icmsGeral = new ICMSGeral();

            icmsGeral.orig = eOrigemMercadoria;
            icmsGeral.CST = eCST;
            icmsGeral.modBC = emodBC;
            icmsGeral.CSOSN = eCSOSN;
            icmsGeral.vBC = vBC;
            icmsGeral.pICMS = pICMS;
            icmsGeral.vICMS = vICMS;
            icmsGeral.modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado;

            return icmsGeral.ObterICMSBasico(oCrt);
        }

        private static COFINSBasico ObterCofinsBasico(bool Percentual, CSTCOFINS eCST, decimal vBC, decimal pCOFINS, decimal vCOFINS, decimal qBCProd, decimal vAliqProd)
        {
            var cofinsGeral = new COFINSGeral();

            cofinsGeral.CST = eCST;

            if (Percentual)
            {
                cofinsGeral.vBC = vBC;
                cofinsGeral.pCOFINS = pCOFINS;
                cofinsGeral.vCOFINS = vCOFINS;
            }
            else
            {
                cofinsGeral.vCOFINS = vBC;
                cofinsGeral.qBCProd = qBCProd;
                cofinsGeral.vAliqProd = vAliqProd;
            }

            return cofinsGeral.ObterCOFINSBasico();
        }

        private static PISBasico ObterPisBasico(bool Percentual, CSTPIS eCST, decimal vBC, decimal pPIS, decimal vPIS, decimal qBCProd, decimal vAliqProd)
        {
            var PISGeral = new PISGeral();

            PISGeral.CST = eCST;

            if (Percentual)
            {
                PISGeral.vBC = vBC;
                PISGeral.pPIS = pPIS;
                PISGeral.vPIS = vPIS;
            }
            else
            {
                PISGeral.vPIS = vBC;
                PISGeral.qBCProd = qBCProd;
                PISGeral.vAliqProd = vAliqProd;
            }

            return PISGeral.ObterPISBasico();
        }

        private static IPIBasico ObterIPIBasico(CSTIPI eCST, decimal vBC, decimal pIPI, decimal vIPI)
        {
            var IPIGeral = new IPIGeral() { CST = eCST, vBC = vBC, pIPI = pIPI, vIPI = vIPI };

            // Public Property qUnid As Decimal?
            // Public Property vUnid As Decimal?

            return IPIGeral.ObterIPIBasico();
        }

        public async static void Fiscal_Visualizar(Guid id, MeuDbContext meuDbContext, INotifier notifier)
        {
            try
            {
                NotaFiscalSaidaSerieViewModel notaFiscalSaidaSerieViewModel = new NotaFiscalSaidaSerieViewModel();
                NotaFiscalSaidaViewModel notaFiscalSaidaViewModel = new NotaFiscalSaidaViewModel();
                IEnumerable<NotaFiscalSaidaViewModel> notaFiscalSaidaViewModels;
                IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoria;
                IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamento = new List<NotaFiscalSaidaPagamentoViewModel>();
                IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferencia = new List<NotaFiscalSaidaReferenciaViewModel>();
                string sDS_PATH_XML = "";
                bool bImpressaoNCFe = false;

                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(meuDbContext, notifier))
                {
                    notaFiscalSaidaViewModels = await notaFiscalSaidaController.PesquisarCompleto(p => p.Id == id);
                    notaFiscalSaidaViewModel = notaFiscalSaidaViewModels.FirstOrDefault();
                }
                using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(meuDbContext, notifier))
                {
                    notaFiscalSaidaMercadoria = await notaFiscalSaidaMercadoriaController.PesquisarId(notaFiscalSaidaViewModel.Id);
                }
                using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(meuDbContext, notifier))
                {
                    var notaFiscalSaidaSerieViewModels = await notaFiscalSaidaSerieController.PesquisarSerie(notaFiscalSaidaViewModel.Serie);
                    notaFiscalSaidaSerieViewModel = notaFiscalSaidaSerieViewModels.FirstOrDefault();
                }

                notaFiscalSaidaViewModel.TransmitirEnderecoCliente = (notaFiscalSaidaViewModel.Cliente_Endereco != null);

                foreach (NotaFiscalSaidaViewModel item in notaFiscalSaidaViewModels)
                {
                    notaFiscalSaidaViewModel = item;
                    notaFiscalSaidaPagamento = Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(item.NotaFiscalSaidaPagamento);
                    notaFiscalSaidaReferencia = Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(item.NotaFiscalSaidaReferencia);

                    Fiscal.Fiscal_DocumentoFiscal_Visualizar(ModeloDocumento.NFe,
                                                             ref notaFiscalSaidaViewModel,
                                                             ref notaFiscalSaidaMercadoria,
                                                             ref notaFiscalSaidaPagamento,
                                                             ref notaFiscalSaidaReferencia,
                                                             ref notaFiscalSaidaSerieViewModel,
                                                             ref sDS_PATH_XML,
                                                             notaFiscalSaidaViewModel.Status == NF_Status.Cancelado);
                }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
    }
}