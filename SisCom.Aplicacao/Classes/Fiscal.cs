using DanfeSharp.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFe.Danfe.Base.NFCe;
using NFe.Utils.NFe;
using NFeZeus = NFe.Classes.NFe;
using DFe.Classes.Flags;
using NFe.Classes;
using NFe.Danfe.Nativo.NFCe;
using NFe.Danfe.Base;
using NFe.Utils;
using DFe.Classes.Entidades;
using DFe.Classes.Extensoes;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using System.Net;
using DFe.Utils;
using NFe.Servicos.Retorno;
using Microsoft.VisualBasic;
using NFe.Servicos;
using System.Data;
using SisCom.Aplicacao.ViewModels;

namespace SisCom.Aplicacao.Classes
{
    public static class Fiscal
    {
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

            if(abrirArquivo) { System.Diagnostics.Process.Start("explorer.exe", sDanfe); }
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

        private static ConfiguracaoDanfeNfce Fiscal_Configuracao_NCFe()
        {
            /*ConfiguracaoDanfeNfce oConfig;
            NfceDetalheVendaNormal oDetalheVendaNormal = NfceDetalheVendaNormal.UmaLinha;
            NfceDetalheVendaContigencia oDetalheVendaContigencia = NfceDetalheVendaContigencia.UmaLinha;
            
            if (Declaracoes.Estacao_CD_OPT_NFCe_DETALHE_VENDA_NORMAL.Trim() != "")
                oDetalheVendaNormal = Convert.ToInt16(Declaracoes.Estacao_CD_OPT_NFCe_DETALHE_VENDA_NORMAL);
            if (sESTACAO_TRABALHO_CD_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA.Trim() != "")
                oDetalheVendaContigencia = Val(sESTACAO_TRABALHO_CD_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA);

            oConfig = new ConfiguracaoDanfeNfce(oDetalheVendaNormal, oDetalheVendaContigencia);

            if (sEMPRESA_DS_PATH_IMAGEM.Trim() != "")
            {
                Image oImagem = Image.FromFile(sEMPRESA_DS_PATH_IMAGEM);
                MemoryStream oStream;

                oConfig.Logomarca = new byte[] { };

                oStream = new MemoryStream();
                oImagem.Save(oStream, ImageFormat.Png);
                oStream.Close();
                oConfig.Logomarca = oStream.ToArray();
            }

            return oConfig;*/
            return null;
        }

        private static NFe.Utils.ConfiguracaoServico Fiscal_Configuracao(ModeloDocumento eModeloDocumento = ModeloDocumento.NFe)
        {
            NFe.Utils.ConfiguracaoServico oConfig = new NFe.Utils.ConfiguracaoServico();
            System.Security.Cryptography.X509Certificates.X509Certificate2 oCert;
            Estado oEstado  =  Estado.MG;
            DFe.Utils.TipoCertificado iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO = TipoCertificado.A1Repositorio;

            oEstado = oEstado.SiglaParaEstado(Declaracoes.Estacao_CD_EMPRESA_UF);

            oConfig = ConfiguracaoServico.Instancia;

            {
                var withBlock = oConfig;
                withBlock.tpAmb = TipoAmbiente.Producao;
                withBlock.tpEmis = TipoEmissao.teNormal;
                withBlock.ProtocoloDeSeguranca = ServicePointManager.SecurityProtocol;
                withBlock.Certificado = new ConfiguracaoCertificado();

                switch (iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO)
                {
                    case TipoCertificado.A1Arquivo:
                        withBlock.Certificado.TipoCertificado = TipoCertificado.A1Arquivo;
                        withBlock.Certificado.Arquivo = Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO;
                        withBlock.Certificado.Senha = Declaracoes.Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA;
                        break;
                    case TipoCertificado.A1ByteArray:
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        withBlock.Certificado.TipoCertificado = TipoCertificado.A1ByteArray;
                        withBlock.Certificado.ArrayBytesArquivo = oCert.GetRawCertData();
                        withBlock.Certificado.Serial = oCert.GetSerialNumberString();
                        break;
                    case TipoCertificado.A1Repositorio:
                        oCert = CertificadoDigitalUtils.ListareObterDoRepositorio();
                        withBlock.Certificado.TipoCertificado = TipoCertificado.A1Repositorio;
                        withBlock.Certificado.Serial = oCert.SerialNumber;
                        break;
                    case TipoCertificado.A3:
                        withBlock.Certificado.TipoCertificado = TipoCertificado.A3;
                        break;
                }

                withBlock.Certificado.CacheId = "58A13AD9C6A41D4B";
                withBlock.Certificado.ManterDadosEmCache = true;
                withBlock.Certificado.SignatureMethodSignedXml = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                withBlock.Certificado.DigestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1";
                withBlock.TimeOut = 30000;
                withBlock.cUF = oEstado;
                withBlock.tpEmis = TipoEmissao.teNormal;
                withBlock.ModeloDocumento = eModeloDocumento;
                withBlock.VersaoLayout = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoRecepcaoEventoCceCancelamento = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoRecepcaoEventoEpec = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoRecepcaoEventoManifestacaoDestinatario = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeRecepcao = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeRetRecepcao = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeConsultaCadastro = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeInutilizacao = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeConsultaProtocolo = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeStatusServico = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNFeAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNFeRetAutorizacao = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNFeDistribuicaoDFe = DFe.Classes.Flags.VersaoServico.Versao100;
                withBlock.VersaoNfeConsultaDest = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfeDownloadNF = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.VersaoNfceAministracaoCSC = DFe.Classes.Flags.VersaoServico.Versao400;
                withBlock.ProtocoloDeSeguranca = SecurityProtocolType.Tls12;
                withBlock.DiretorioSchemas = Declaracoes.Estacao_TRABALHO_DS_DOCUMENTOFISCAL_PATH_SCHEMAS;
                withBlock.SalvarXmlServicos = true;
                withBlock.DiretorioSalvarXml = Declaracoes.Aplicacao_CaminhoDiretorioTemporaria;
            }

            return oConfig;
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

                oConfig = Fiscal_Configuracao();
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

                oConfig = Fiscal_Configuracao();
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
        private static bool Fiscal_DocumentoFiscal_Protocolo(NFe.Classes.NFe oNFe, int iSQ_DOCUMENTOFISCAL, NFe.Utils.ConfiguracaoServico oConfig, ref string sCD_PROTOCOLO, ref string sNFe_Arquivo)
        {
            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoNfeConsultaProtocolo oNFe_Servico_Retorno;
            NFe.Classes.nfeProc oNFe_Proc;

            string sNFe_Chave;
            bool bOk = false;

            int iCont;

            sNFe_Chave = oNFe.infNFe.Id.Substring(3);

            Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Solicitação de protocolo");

            if (string.IsNullOrEmpty(sNFe_Chave))
            {
                Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Solicitação de protocolo - A Chave da NFe não foi encontrada no arquivo", null/* Conversion error: Set to default value for this argument */, false);
                goto Sair;
            }
            if (sNFe_Chave.Trim().Length != 44)
            {
                Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Solicitação de protocolo - Chave deve conter 44 caracteres", null/* Conversion error: Set to default value for this argument */, false);
                goto Sair;
            }

            for (iCont = 1; iCont <= 5; iCont++)
            {
                oNFe_Servico = new ServicosNFe(oConfig);
                oNFe_Servico_Retorno = oNFe_Servico.NfeConsultaProtocolo(sNFe_Chave);
                Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), iSQ_DOCUMENTOFISCAL, "Solicitação de protocolo - Retorno - " + "Chave de Acesso: " + oNFe_Servico_Retorno.Retorno.chNFe);

                oNFe_Proc = new nfeProc();
                oNFe_Proc.NFe = oNFe;
                oNFe_Proc.protNFe = new NFe.Classes.Protocolo.protNFe();
                oNFe_Proc.protNFe = oNFe_Servico_Retorno.Retorno.protNFe;
                oNFe_Proc.versao = oNFe_Servico_Retorno.Retorno.versao;

                if (Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()) == enOpcoes_NFe_StatusProcessamento.Rejeicao_NFeNaoConstaBaseDadosSEFAZ)
                {
                    if (iCont == 5)
                        Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), iSQ_DOCUMENTOFISCAL, "NFe Não Consta na Base Dados do SEFAZ");
                }
                else
                {
                    Fiscal_Historico(Fiscal_NFe_StatusProcessamento(oNFe_Servico_Retorno.Retorno.cStat.ToString()), iSQ_DOCUMENTOFISCAL, "Solicitação de protocolo - Retorno - " + "Chave de Acesso: " + oNFe_Proc.protNFe.infProt.chNFe + "Protocolo nº: " + oNFe_Proc.protNFe.infProt.nProt + "Motivo: " + oNFe_Proc.protNFe.infProt.xMotivo);
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
            ;
            return bOk;
        }
        private static void Fiscal_Historico(enOpcoes_NFe_StatusProcessamento iErro, int iSQ_DOCUMENTOFISCAL, string sDS_HISTORICO, string sCD_HISTORICO = "", bool bExibirMensagem = false)
        {
            //Historico_Incluir(enOpcoes.Processo_Historico_Cadastro_CadastroDocumentoFiscal.GetHashCode(), enOpcoes.Processo_Acao_Transmissao.GetHashCode(), iErro, iSQ_DOCUMENTOFISCAL, sDS_HISTORICO, sCD_HISTORICO);

            if (bExibirMensagem)
                CaixaMensagem.Informacao(sDS_HISTORICO);
        }
        private static void Fiscal_DocumentoFiscal_Serie_Emissao_NumeroAtual(int iSQ_DOCUMENTOFISCAL_SERIE, string sCD_DOCUMENTOFISCAL)
        {
            string sSqlText;

            //sSqlText = DBMontar_SP("SP_DOCUMENTOFISCAL_SERIE_EMISSAO_NUMEROATUAL_UPD", false, "@SQ_DOCUMENTOFISCAL_SERIE", "@CD_ULTIMAEMISSAO_NUMERO");
            //DBExecutar(sSqlText, DBParametro_Montar("SQ_DOCUMENTOFISCAL_SERIE", iSQ_DOCUMENTOFISCAL_SERIE), DBParametro_Montar("CD_ULTIMAEMISSAO_NUMERO", sCD_DOCUMENTOFISCAL));
        }
        /*        private static void Fiscal_DocumentoFiscal_Status(int iSQ_DOCUMENTOFISCAL, string sCD_DOCUMENTOFISCAL, enOpcoes eID_OPT_STATUS, enOpcoes eID_OPT_CERTIFICADO_DIGITAL_AMBIENTE, string sCD_CHAVE_NFE = "", string sCD_PROTOCOLO = "", string sDS_PATH_XML = "")
                {
                    string sSqlText;

                    sSqlText = DBMontar_SP("SP_DOCUMENTOFISCAL_SERIE_STATUS_UPD", false, "@SQ_DOCUMENTOFISCAL", "@CD_DOCUMENTOFISCAL", "@ID_OPT_STATUS", "@ID_OPT_CERTIFICADO_DIGITAL_AMBIENTE", "@CD_CHAVE_NFE", "@CD_PROTOCOLO", "@DS_PATH_XML");
                    DBExecutar(sSqlText, DBParametro_Montar("SQ_DOCUMENTOFISCAL", iSQ_DOCUMENTOFISCAL), DBParametro_Montar("CD_DOCUMENTOFISCAL", sCD_DOCUMENTOFISCAL), DBParametro_Montar("ID_OPT_STATUS", eID_OPT_STATUS.GetHashCode()), DBParametro_Montar("ID_OPT_CERTIFICADO_DIGITAL_AMBIENTE", eID_OPT_CERTIFICADO_DIGITAL_AMBIENTE.GetHashCode()), DBParametro_Montar("CD_CHAVE_NFE", FNC_NuloString(sCD_CHAVE_NFE, false)), DBParametro_Montar("CD_PROTOCOLO", FNC_NuloString(sCD_PROTOCOLO, false)), DBParametro_Montar("DS_PATH_XML", FNC_NuloString(sDS_PATH_XML, false)));
                }*/
        public static bool FNC_Fiscal_DocumentoFiscal_Transmitir_Validar(int iSQ_DOCUMENTOFISCAL)
        {
            DataTable oData;
            string sSqlText;
            int iCont;
            string sAux = "";
            bool bOk = false;

            /*if (iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO == 0 | (iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO == enOpcoes.TipoCertificadoDigital_A1Arquivo.GetHashCode() & (FNC_NuloString(sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO).Trim() == "" | FNC_NuloString(sESTACAO_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA).Trim() == "))
            {
                CaixaMensagem.Informacao("Dados do certificado digital não informado");
                goto Sair;
            }*/
            /*if (Declaracoes.Estacao_TRABALHO_DS_DOCUMENTOFISCAL_PATH_SCHEMAS.Trim() == "")
            {
                CaixaMensagem.Informacao("Pasta de Schema no NF-e/NFC-e não informada");
                goto Sair;
            }

            /*sSqlText = "SELECT *" + " FROM VW_DOCUMENTOFISCAL_GERAR" + " WHERE SQ_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL;
            oData = DBQuery(sSqlText);*/

            /*if (objDataTable_Vazio(oData))
            {
                CaixaMensagem.Informacao("Documento Fiscal não encontrado");
                goto Sair;
            }
            else
            {
                {
                    var withBlock = oData.Rows(0);
                    if (withBlock.Item("ID_OPT_STATUS") == enOpcoes.StatusDocumentoFiscal_Transmitido.GetHashCode())
                    {
                        CaixaMensagem.Informacao("Documento Fiscal já transmitido");
                        goto Sair;
                    }
                    if (withBlock.Item("ID_OPT_STATUS") == enOpcoes.StatusDocumentoFiscal_Cancelado.GetHashCode())
                    {
                        CaixaMensagem.Informacao("Documento Fiscal cancelado");
                        goto Sair;
                    }
                    if (!FNC_In(withBlock.Item("ID_DOCUMENTOFISCAL_TIPO"), enTipoDocumentoFiscal.Entrada_NotaFiscalEntrada.GetHashCode(), enTipoDocumentoFiscal.Saida_NotaFiscalSaida.GetHashCode(), enTipoDocumentoFiscal.Saida_CupomFiscalEletronico.GetHashCode()))
                    {
                        CaixaMensagem.Informacao("Somente Nota Fiscal de Entrada e Nota Fiscal Saída e Cupom Fiscal pode ser transmitido(a)");
                        goto Sair;
                    }
                    if (FNC_NVL(withBlock.Item("CD_SERVICO_MODELO"), "") == "")
                    {
                        CaixaMensagem.Informacao("Modelo de serviço do documento fiscal não informado");
                        goto Sair;
                    }
                    switch (FNC_NVL(withBlock.Item("CD_SERVICO_MODELO"), ""))
                    {
                        case object _ when const_NFe_ModeloServico_NFe:
                            {
                                break;
                            }

                        case object _ when const_NFe_ModeloServico_NFCe:
                            {
                                if (FNC_NVL(sESTACAO_TRABALHO_CD_NFCe_Token_CSC, "").Trim() == "")
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
                                }

                                break;
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
                    if (FNC_NVL(withBlock.Item("IC_EXIBIR_ENDERECO"), "N") == "S")
                    {
                        if (FNC_NVL(withBlock.Item("NO_PESSOA_BAIRRO"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar o bairro do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("NO_PESSOA_CIDADE"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar a cidade do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("CD_PESSOA_UF"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar a U.F. do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("NO_PESSOA_PAIS"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar o país do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("CD_PESSOA_CIDADE_IBGE"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar o código do IBGE da cidade do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("CD_PESSOA_UF_IBGE"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar o código do IBGE da U.F. do endereço da pessoa");
                            goto Sair;
                        }
                        if (FNC_NVL(withBlock.Item("CD_PESSOA_CEP"), "") == "")
                        {
                            CaixaMensagem.Informacao("É preciso informar o código do C.E.P. do endereço da pessoa");
                            goto Sair;
                        }
                        else if (FNC_SoNumero(withBlock.Item("CD_PESSOA_CEP")).Length != const_Formatos_CEP_Tamanho)
                        {
                            CaixaMensagem.Informacao("o código do C.E.P. do endereço da pessoa está em formato incorreto");
                            goto Sair;
                        }
                    }
                }

                sSqlText = "SELECT * FROM VW_DOCUMENTOFISCAL_PRODUTO_GERAR" + " WHERE ID_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL + " ORDER BY NO_PRODUTO";
                oData = DBQuery(sSqlText);

                for (iCont = 0; iCont <= oData.Rows.Count - 1; iCont++)
                {
                    {
                        var withBlock = oData.Rows(iCont);
                        if (FNC_CampoNulo(oData.Rows(iCont).Item("CD_CST))
                            FNC_Str_Adicionar(sAux, oData.Rows(iCont).Item("NO_PRODUTO") + " - CST COFINS não informado para o produto", Constants.vbCrLf);
                        if (FNC_CampoNulo(oData.Rows(iCont).Item("CD_NCM))
                            FNC_Str_Adicionar(sAux, oData.Rows(iCont).Item("NO_PRODUTO") + " - NCM não informado para o produto", Constants.vbCrLf);
                    }
                }

                if (sAux.Trim() != "")
                {
                    sAux = "O(s) produto(s) listado(s) abaixo estão com algum problema de cadastro ou lançamento" + Constants.vbCrLf + Constants.vbCrLf + sAux;

                    CaixaMensagem.Informacao(sAux);
                }

                bOk = (sAux.Trim() == "");
            }*/
//        Sair:
            ;
            return bOk;
        }
        public static bool FNC_Fiscal_DocumentoFiscal_Cancelar(int iSQ_DOCUMENTOFISCAL, ModeloDocumento eModeloDocumento, string sJustificativa = "")
        {
            return false;
/*            NFe.Servicos.ServicosNFe oNFe_Servico;
            NFe.Servicos.Retorno.RetornoRecepcaoEvento oNFe_Servico_RetornoRecepcaoEvento;
            NFe.Utils.ConfiguracaoServico oConfig;
            bool bOk = false;
            string sSqlText;
            DataTable oData;

            if (iSQ_DOCUMENTOFISCAL == 0)
            {
                CaixaMensagem.Informacao("Informe o documento fiscal a ser corrigir");
                goto Sair;
            }
            if (sJustificativa.Trim() == "")
            {
                CaixaMensagem.Informacao("Informe a descrição da correção");
                goto Sair;
            }

            oConfig = FNC_Fiscal_Configuracao(eModeloDocumento);
            if (oConfig == null)
                goto Sair;

            oNFe_Servico = new ServicosNFe(oConfig);

            sSqlText = "SELECT * FROM VW_DOCUMENTOFISCAL WHERE SQ_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL;
            oData = DBQuery(sSqlText);

            if (objDataTable_Vazio(oData))
                CaixaMensagem.Informacao("Documento Fiscal não encontrado");
            else
            {
                var withBlock = oData.Rows(0);
                oNFe_Servico_RetornoRecepcaoEvento = oNFe_Servico.RecepcaoEventoCancelamento(1, 1, withBlock.Item("CD_PROTOCOLO"), withBlock.Item("CD_CHAVE_NFE"), sJustificativa, FNC_SoNumero(sEMPRESA_DADOS_CNPJ));

                if (FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat) == enOpcoes_NFe_StatusProcessamento.EventoRegistradoVinculadoNFe | FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat) == enOpcoes_NFe_StatusProcessamento.LoteEventoProcessado)
                {
                    FNC_Fiscal_Historico(FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.cStat), iSQ_DOCUMENTOFISCAL, oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.xMotivo + Constants.vbCrLf, withBlock.Item("CD_DOCUMENTOFISCAL"));

                    if (FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.cStat) == enOpcoes_NFe_StatusProcessamento.CancelamentoNFeHomologado | FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.cStat) == enOpcoes_NFe_StatusProcessamento.EventoRegistradoVinculadoNFe)
                    {
                        bOk = true;
                        FormCadastroDocumentoFiscal_Cancelamento_Gravar(iSQ_DOCUMENTOFISCAL, sJustificativa);
                    }
                    else
                        FNC_Fiscal_Historico(FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.cStat), iSQ_DOCUMENTOFISCAL, oNFe_Servico_RetornoRecepcaoEvento.Retorno.retEvento(0).infEvento.xMotivo + Constants.vbCrLf, withBlock.Item("CD_DOCUMENTOFISCAL"));
                }
                else
                    FNC_Fiscal_Historico(FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoRecepcaoEvento.Retorno.cStat), iSQ_DOCUMENTOFISCAL, oNFe_Servico_RetornoRecepcaoEvento.Retorno.xMotivo + Constants.vbCrLf, withBlock.Item("CD_DOCUMENTOFISCAL"));
            }

        Sair:
            ;
            return bOk;*/
        }
        //public static bool Fiscal_DocumentoFiscal_Transmitir(string ChaveNfe, ModeloDocumento eModeloDocumento, ref string sDS_PATH_XML, ref bool bImpressaoNCFe, bool bImprimirDanfeNFe = false)
        //{
        //    NFe.Classes.NFe oNFe;
        //    NFe.Servicos.ServicosNFe oNFe_Servico;
        //    NFe.Servicos.Retorno.RetornoNFeAutorizacao oNFe_Servico_RetornoNFeAutorizacao;
        //    NFe.Classes.nfeProc oNFe_Proc;
        //    NFe.Utils.ConfiguracaoServico oConfig;
        //    bool bVerificarProtocolo = false;
        //    bool bProblemaNFe = false;
        //    string sCD_PROTOCOLO = "";
        //    string sCD_NFCe_DetalheVendaNormal = "";
        //    string sCD_NFCe_DetalheVendaContigencia = "";
        //    string sCD_NFCe_Token_ID = "";
        //    string sCD_NFCe_Token_CSC = "";
        //    bool bOk = false;

        //    try
        //    {
        //        oConfig = Fiscal_Configuracao(eModeloDocumento);
        //        if (oConfig == null)
        //            goto Sair;

        //        Fiscal_Historico(0, 0, "Início de transmissão");

        //        oNFe = Fiscal_DocumentoFiscal_Gerar(iSQ_DOCUMENTOFISCAL, oConfig, sCD_NFCe_DetalheVendaNormal, sCD_NFCe_DetalheVendaContigencia, sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);

        //        Application.DoEvents();

        //        if (!oNFe == null)
        //        {
        //            if (Strings.Trim(sCD_CHAVE_NFE) != "")
        //            {
        //                oNFe_Proc = FNC_Fiscal_DocumentoFiscal_AssociarProtocolo(oConfig, oNFe, sCD_CHAVE_NFE);
        //                oNFe = oNFe_Proc.NFe;

        //                if (!oNFe_Proc.protNFe == null)
        //                    bVerificarProtocolo = true;
        //            }

        //            if (!bVerificarProtocolo)
        //            {
        //                FNC_Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Solicitação de autorização");
        //                oNFe_Servico = new ServicosNFe(oConfig);
        //                oNFe_Servico_RetornoNFeAutorizacao = oNFe_Servico.NFeAutorizacao(Convert.ToInt32("1"), IIf(oNFe.infNFe.ide.mod == ModeloDocumento.NFCe, IndicadorSincronizacao.Sincrono, IndicadorSincronizacao.Assincrono), new List<NFeZeus>(new NFeZeus[] { oNFe }), true);
        //                try
        //                {
        //                    FNC_Fiscal_Historico(FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoNFeAutorizacao.Retorno.cStat), iSQ_DOCUMENTOFISCAL, "Solicitação de autorização - " + oNFe_Servico_RetornoNFeAutorizacao.Retorno.xMotivo + " - Recibo: " + oNFe_Servico_RetornoNFeAutorizacao.Retorno.infRec.nRec);
        //                }
        //                catch (Exception ex)
        //                {
        //                    FNC_Fiscal_Historico(FNC_Fiscal_NFe_StatusProcessamento(oNFe_Servico_RetornoNFeAutorizacao.Retorno.cStat), iSQ_DOCUMENTOFISCAL, "Solicitação de autorização - " + oNFe_Servico_RetornoNFeAutorizacao.Retorno.xMotivo + " - Recibo: " + oNFe_Servico_RetornoNFeAutorizacao.Retorno.protNFe.infProt.nProt);
        //                }

        //                Application.DoEvents();
        //                Application.DoEvents();

        //                bVerificarProtocolo = (!oNFe_Servico_RetornoNFeAutorizacao.Retorno == null) & (!bProblemaNFe);
        //            }

        //            if (bVerificarProtocolo)
        //            {
        //                if (FNC_Fiscal_DocumentoFiscal_Protocolo(oNFe, iSQ_DOCUMENTOFISCAL, oConfig, sCD_PROTOCOLO, sDS_PATH_XML))
        //                {
        //                    FNC_Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Salvar XML");

        //                    string sAux;

        //                    try
        //                    {
        //                        sAux = FNC_DiretorioSistema_RemoverPath(FNC_DiretorioSistema_GuardarArquivo(sDS_PATH_XML));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        sAux = sDS_PATH_XML;
        //                    }

        //                    sDS_PATH_XML = sAux;

        //                    FNC_Fiscal_DocumentoFiscal_Status(iSQ_DOCUMENTOFISCAL, oNFe.infNFe.ide.nNF, enOpcoes.StatusDocumentoFiscal_Transmitido.GetHashCode(), iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_AMBIENTE, oNFe.infNFe.Id.Substring(3), sCD_PROTOCOLO, sDS_PATH_XML);

        //                    switch (eModeloDocumento)
        //                    {
        //                        case object _ when ModeloDocumento.NFe:
        //                            {
        //                                if (bImprimirDanfeNFe)
        //                                    FNC_Fiscal_Danfe_GerarPDF(FNC_DiretorioSistema_AdicionarPath(sDS_PATH_XML), true);
        //                                break;
        //                            }

        //                        case object _ when ModeloDocumento.NFCe:
        //                            {
        //                                if (bImpressaoNCFe & bESTACAO_TRABALHO_IC_IMPRIME_DANFENCFE_AUTOMATICAMENTE)
        //                                    FNC_Fiscal_Danfe_ImprimirNCFe(sDS_PATH_XML, sCD_NFCe_DetalheVendaNormal, sCD_NFCe_DetalheVendaContigencia, sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);
        //                                else
        //                                {
        //                                }

        //                                break;
        //                            }
        //                    }

        //                    bOk = true;

        //                    oNFe_Servico = null/* TODO Change to default(_) if this is not a reference type */;
        //                }
        //                else
        //                    FNC_Fiscal_DocumentoFiscal_ChaveNFE(iSQ_DOCUMENTOFISCAL, oNFe.infNFe.Id.Substring(3));
        //            }
        //        }
        //        else
        //            goto Sair;
        //    }
        //    catch (Exception ex)
        //    {
        //        oConfig = null/* TODO Change to default(_) if this is not a reference type */;
        //        oNFe = null/* TODO Change to default(_) if this is not a reference type */;
        //        oNFe_Servico = null/* TODO Change to default(_) if this is not a reference type */;
        //        oNFe_Servico_RetornoNFeAutorizacao = null/* TODO Change to default(_) if this is not a reference type */;

        //        CaixaMensagem.Informacao(ex.Message);

        //        goto Sair;
        //    }

        //Sair:
        //    ;
        //    if (!bOk)
        //        CaixaMensagem.Informacao("Houve algum problema na transmissão. É necessário verificar o histórico da mesma");

        //    return bOk;
        //}
        //private static NFe.Classes.NFe Fiscal_DocumentoFiscal_Gerar(NotaFiscalSaidaViewModel notaFiscalSaidaView, NFe.Utils.ConfiguracaoServico oConfig, ref string sCD_NFCe_DetalheVendaNormal, ref string                                                                                 sCD_NFCe_DetalheVendaContigencia, ref string sCD_NFCe_Token_ID, ref string sCD_NFCe_Token_CSC)
        //{
        //    NFe.Classes.NFe oNFe;
        //    NFe.Classes.Informacoes.Detalhe.det oNFE_Det;
        //    NFe.Classes.Informacoes.Cobranca.dup oNFE_Dup = null/* TODO Change to default(_) if this is not a reference type */;
        //    NFe.Classes.Informacoes.Pagamento.pag oNFE_Pag;
        //    NFe.Classes.Informacoes.Pagamento.card oNFE_Card;
        //    NFe.Classes.Informacoes.Pagamento.detPag oNFE_Pag_Det;
        //    NFe.Classes.Informacoes.autXML oNFE_autXML;
        //    string sSqlText;
        //    int iCont;
        //    string sDS_PATH_XML;
        //    string sAux;
        //    bool bClienteNaoInformado;

        //    string sNF;
        //    string sDS_INFORMACOES_ADICIONAIS = "";

        //    try
        //    {
        //        {
        //            if (Funcoes._Classes.Texto.NuloString(notaFiscalSaidaView.Serie) == "")
        //            {
        //                CaixaMensagem.Informacao("O número de série do documento não foi informado");
        //                return null;
        //            }
        //            if (Funcoes._Classes.Funcao.Nulo(notaFiscalSaidaView.IE))
        //            {
        //                CaixaMensagem.Informacao("Inscrição Estadual não foi informado para a empresa que está transmitindo o documento fiscal");
        //                return null;
        //            }
        //            if (Funcoes._Classes.Funcao.Nulo(CD_OPT_CRT))
        //            {
        //                CaixaMensagem.Informacao("É preciso informar o C.R.T. (Código de Regime Tributário)");
        //                return null;
        //            }
        //            if (Funcoes._Classes.Funcao.Nulo(CD_EMPRESA_UF))
        //            {
        //                CaixaMensagem.Informacao("Endereço da empresa não cadastrado");
        //                return null;
        //            }
        //            if (withBlock.Item("CD_SERVICO_MODELO") != const_NFe_ModeloServico_NFCe)
        //            {
        //                if (Funcoes._Classes.Funcao.Nulo(CD_PESSOA_UF")) & FNC_NVL(withBlock.Item("IC_EXIBIR_ENDERECO"), "N") == "S")
        //                {
        //                    CaixaMensagem.Informacao("Endereço do destinatário não cadastrado");
        //                    return null;
        //                }
        //            }

        //            if (Funcoes._Classes.Funcao.Nulo(CD_DOCUMENTOFISCAL))
        //            {
        //                FNC_Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Criação do XML do documento fiscal");

        //                sSqlText = "SELECT dbo.FC_DOCUMENTOFISCAL_SERIE_EMISSAO_NOVONUMERO(" + withBlock.Item("ID_DOCUMENTOFISCAL_SERIE") + ")";
        //                sNF = DBQuery_ValorUnico(sSqlText);

        //                FNC_Fiscal_DocumentoFiscal_Serie_Emissao_NumeroAtual(withBlock.Item("ID_DOCUMENTOFISCAL_SERIE"), sNF);

        //                FNC_Fiscal_DocumentoFiscal_Status(iSQ_DOCUMENTOFISCAL, sNF, enOpcoes.StatusDocumentoFiscal_Transmitindo.GetHashCode(), iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_AMBIENTE, null/* TODO Change to default(_) if this is not a reference type */, null/* Conversion error: Set to default value for this argument */, null/* TODO Change to default(_) if this is not a reference type */);
        //            }
        //            else
        //            {
        //                FNC_Fiscal_Historico(0, iSQ_DOCUMENTOFISCAL, "Correção do XML do documento fiscal");

        //                sNF = withBlock.Item("CD_DOCUMENTOFISCAL");
        //            }

        //            oNFe = new NFe.Classes.NFe();

        //            oNFe.infNFe = new NFe.Classes.Informacoes.infNFe();
        //            oNFe.infNFe.versao = withBlock.Item("CD_SERVICO_VERSAO");
        //            oNFe.infNFe.ide = new NFe.Classes.Informacoes.Identificacao.ide();
        //            oNFe.infNFe.ide.cUF = Val(withBlock.Item("CD_EMPRESA_UF_IBGE"));
        //            oNFe.infNFe.ide.natOp = withBlock.Item("NO_NATUREZAOPERACAO").ToString().Trim();
        //            oNFe.infNFe.ide.mod = withBlock.Item("CD_SERVICO_MODELO");
        //            oNFe.infNFe.ide.serie = Val(withBlock.Item("CD_DOCUMENTOFISCAL_SERIE"));
        //            oNFe.infNFe.ide.nNF = sNF;
        //            oNFe.infNFe.ide.tpNF = Val(withBlock.Item("CD_OPT_NFE_TIPOOPERACAO"));
        //            oNFe.infNFe.ide.cMunFG = Val(withBlock.Item("CD_EMPRESA_CIDADE_IBGE")).ToString().Trim();
        //            oNFe.infNFe.ide.tpEmis = Val(withBlock.Item("CD_OPT_NFE_FORMATOEMISSAO"));
        //            oNFe.infNFe.ide.tpImp = Val(withBlock.Item("CD_OPT_NFE_FORMATOIMPRESSAODANFE"));
        //            oNFe.infNFe.ide.cNF = "1" + FNC_StrZero(withBlock.Item("SQ_DOCUMENTOFISCAL"), 7);
        //            oNFe.infNFe.ide.tpAmb = oConfig.tpAmb;
        //            oNFe.infNFe.ide.finNFe = FNC_NVL(Val(withBlock.Item("CD_OPT_FINALIDADE")), NFe.Classes.Informacoes.Identificacao.Tipos.FinalidadeNFe.fnNormal);
        //            oNFe.infNFe.ide.verProc = "4.000";

        //            if (oNFe.infNFe.ide.tpEmis != NFe.Classes.Informacoes.Identificacao.Tipos.TipoEmissao.teNormal)
        //            {
        //                oNFe.infNFe.ide.dhCont = DateTime.Now;
        //                oNFe.infNFe.ide.xJust = "TESTE DE CONTIGÊNCIA PARA NFe/NFCe";
        //            }

        //            if (FNC_NVL(withBlock.Item("CD_EMPRESA_BACEN"), "") != FNC_NVL(withBlock.Item("CD_PESSOA_BACEN"), ""))
        //                oNFe.infNFe.ide.idDest = DestinoOperacao.doExterior;
        //            else if (FNC_NVL(withBlock.Item("CD_EMPRESA_UF"), "") != FNC_NVL(withBlock.Item("CD_PESSOA_UF"), ""))
        //                oNFe.infNFe.ide.idDest = DestinoOperacao.doInterestadual;
        //            else
        //                oNFe.infNFe.ide.idDest = DestinoOperacao.doInterna;

        //            if (oNFe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFCe)
        //                oNFe.infNFe.ide.idDest = DestinoOperacao.doInterna;
        //            else
        //            {
        //            }
        //            oNFe.infNFe.ide.dhEmi = DateTime.Now;

        //            // Mude aqui para enviar a nfe vinculada ao EPEC, V3.10
        //            if (oNFe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFe)
        //                oNFe.infNFe.ide.dhSaiEnt = DateTime.Now;

        //            oNFe.infNFe.ide.procEmi = NFe.Classes.Informacoes.Identificacao.Tipos.ProcessoEmissao.peAplicativoContribuinte;

        //            if (objDataTable_CampoVazio(withBlock.Item("CD_PESSOA_UF))
        //            {
        //                oNFe.infNFe.ide.indFinal = NFe.Classes.Informacoes.Identificacao.Tipos.ConsumidorFinal.cfConsumidorFinal;
        //                oNFe.infNFe.ide.indPres = NFe.Classes.Informacoes.Identificacao.Tipos.PresencaComprador.pcPresencial;
        //            }
        //            else if (withBlock.Item("CD_PESSOA_UF") == withBlock.Item("CD_EMPRESA_UF"))
        //            {
        //                oNFe.infNFe.ide.indFinal = NFe.Classes.Informacoes.Identificacao.Tipos.ConsumidorFinal.cfConsumidorFinal;

        //                if (FNC_NVL(withBlock.Item("ID_DOCUMENTOFISCAL_TIPO"), 0) == enTipoDocumentoFiscal.Saida_CupomFiscalEletronico)
        //                    oNFe.infNFe.ide.indPres = NFe.Classes.Informacoes.Identificacao.Tipos.PresencaComprador.pcPresencial;
        //                else
        //                    oNFe.infNFe.ide.indPres = NFe.Classes.Informacoes.Identificacao.Tipos.PresencaComprador.pcPresencial;
        //            }
        //            else
        //            {
        //                oNFe.infNFe.ide.indPres = NFe.Classes.Informacoes.Identificacao.Tipos.PresencaComprador.pcOutros;

        //                if (FNC_NVL(withBlock.Item("CD_OPT_PJ_CONTRIBUICAO_ICMS_PS"), 0) == NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte.GetHashCode())
        //                    oNFe.infNFe.ide.indFinal = NFe.Classes.Informacoes.Identificacao.Tipos.ConsumidorFinal.cfConsumidorFinal;
        //                else
        //                    oNFe.infNFe.ide.indFinal = NFe.Classes.Informacoes.Identificacao.Tipos.ConsumidorFinal.cfNao;
        //            }

        //            if (!FNC_CampoNulo(withBlock.Item("ID_OPT_FISICO_JURIDICO_RESPONSAVELCONTABIL))
        //            {
        //                oNFE_autXML = new autXML();
        //                oNFE_autXML.CNPJ = "";
        //                oNFE_autXML.CPF = "";

        //                switch (withBlock.Item("ID_OPT_FISICO_JURIDICO_RESPONSAVELCONTABIL"))
        //                {
        //                    case object _ when enOpcoes.FisicoJuridico_Fisico.GetHashCode():
        //                        {
        //                            oNFE_autXML.CPF = Trim(withBlock.Item("CD_CPF_CNPJ_PESSOA_RESPONSAVELCONTABIL"));
        //                            break;
        //                        }

        //                    case object _ when enOpcoes.FisicoJuridico_Juridico.GetHashCode():
        //                        {
        //                            oNFE_autXML.CNPJ = Trim(withBlock.Item("CD_CPF_CNPJ_PESSOA_RESPONSAVELCONTABIL"));
        //                            break;
        //                        }
        //                }

        //                oNFe.infNFe.autXML = new List<autXML>(new autXML[] { oNFE_autXML });
        //            }

        //            // -- Emitente
        //            oNFe.infNFe.emit = new NFe.Classes.Informacoes.Emitente.emit();
        //            oNFe.infNFe.emit.CNPJ = FNC_StrZero(withBlock.Item("CD_EMPRESA_CNPJ"), 14).ToString().Trim();
        //            oNFe.infNFe.emit.xNome = withBlock.Item("NO_EMPRESA").ToString().Trim();
        //            oNFe.infNFe.emit.xFant = withBlock.Item("NO_FANTASIA_REDUZIDO").ToString().Trim();
        //            oNFe.infNFe.emit.IE = FNC_SoNumero(FNC_NVL(withBlock.Item("CD_EMPRESA_PJ_IE"), "")).ToString().Trim();
        //            if (!FNC_CampoNulo(withBlock.Item("CD_EMPRESA_PJ_IM))
        //            {
        //                oNFe.infNFe.emit.IM = FNC_SoNumero(withBlock.Item("CD_EMPRESA_PJ_IM")).ToString().Trim();
        //                oNFe.infNFe.emit.CNAE = FNC_SoNumero(FNC_NVL(withBlock.Item("CD_EMPRESA_CNAE"), "")).ToString().Trim();
        //            }
        //            else
        //                oNFe.infNFe.emit.IM = "ISENTO";
        //            oNFe.infNFe.emit.IEST = null;
        //            oNFe.infNFe.emit.CRT = FNC_SoNumero(FNC_NVL(withBlock.Item("CD_OPT_CRT"), "")).ToString().Trim();
        //            // -- Emitente Endereço
        //            oNFe.infNFe.emit.enderEmit = new NFe.Classes.Informacoes.Emitente.enderEmit();
        //            oNFe.infNFe.emit.enderEmit.xLgr = FNC_NVL(withBlock.Item("DS_EMPRESA_LOGRADOURO"), "").ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.nro = FNC_Endereco_TratarNumero(withBlock.Item("NR_EMPRESA_LOGRADOURO")).ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.xCpl = FNC_NVL(withBlock.Item("DS_EMPRESA_COMPLEMENTO"), "").ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.xBairro = FNC_NVL(withBlock.Item("NO_EMPRESA_BAIRRO"), "").ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.cMun = FNC_NVL(withBlock.Item("CD_EMPRESA_CIDADE_IBGE"), "").ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.xMun = FNC_NVL(withBlock.Item("NO_EMPRESA_CIDADE"), "").ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.UF = Val(withBlock.Item("CD_EMPRESA_UF_IBGE"));
        //            if (!objDataTable_CampoVazio(withBlock.Item("CD_EMPRESA_CEP))
        //                oNFe.infNFe.emit.enderEmit.CEP = FNC_StrZero(FNC_SoNumero(Trim(FNC_NVL(withBlock.Item("CD_EMPRESA_CEP"), ")), 8);
        //            oNFe.infNFe.emit.enderEmit.cPais = Trim(FNC_NVL(withBlock.Item("CD_EMPRESA_BACEN"), "")).ToString().Trim();
        //            oNFe.infNFe.emit.enderEmit.xPais = Trim(FNC_NVL(withBlock.Item("NO_EMPRESA_PAIS"), "")).ToString().Trim();

        //            if (FNC_SoNumero(Trim(FNC_NVL(withBlock.Item("CD_EMPRESA_TELEFONE"), ")) != "")
        //                oNFe.infNFe.emit.enderEmit.fone = FNC_SoNumero(Trim(FNC_NVL(withBlock.Item("CD_EMPRESA_TELEFONE"), "));

        //            // --Destinatário
        //            if (FNC_NVL(withBlock.Item("IC_EXIBIR_PESSOA"), "S") == "S")
        //            {
        //                if (withBlock.Item("ID_OPT_FISICO_JURIDICO") == enOpcoes.FisicoJuridico_Juridico.GetHashCode())
        //                {
        //                    oNFe.infNFe.dest = new NFe.Classes.Informacoes.Destinatario.dest(withBlock.Item("CD_SERVICO_VERSAO"));
        //                    oNFe.infNFe.dest.CNPJ = FNC_StrZero(FNC_SoNumero(withBlock.Item("CD_CPF_CNPJ")), 14).ToString().Trim();
        //                }
        //                else if (FNC_SoNumero(withBlock.Item("CD_CPF_CNPJ")) != "00000000000")
        //                {
        //                    oNFe.infNFe.dest = new NFe.Classes.Informacoes.Destinatario.dest(withBlock.Item("CD_SERVICO_VERSAO"));
        //                    oNFe.infNFe.dest.CPF = FNC_StrZero(FNC_SoNumero(withBlock.Item("CD_CPF_CNPJ")), 11).ToString().Trim();
        //                }
        //                else
        //                    bClienteNaoInformado = true;
        //            }
        //            else
        //                bClienteNaoInformado = true;

        //            if (!bClienteNaoInformado)
        //            {
        //                if (oNFe.infNFe.ide.tpAmb == TipoAmbiente.Homologacao)
        //                    oNFe.infNFe.dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
        //                else
        //                    oNFe.infNFe.dest.xNome = withBlock.Item("NO_PESSOA").ToString().Trim();
        //                if (!FNC_CampoNulo(withBlock.Item("DS_PESSOA_EMAIL))
        //                    oNFe.infNFe.dest.email = FNC_NVL(withBlock.Item("DS_PESSOA_EMAIL"), "").ToString().Trim();
        //            }

        //            if (!objDataTable_CampoVazio(withBlock.Item("ID_ENDERECO")) & !bClienteNaoInformado & FNC_NVL(withBlock.Item("IC_EXIBIR_ENDERECO"), "S") == "S")
        //            {
        //                // --Destinatário Endereço
        //                oNFe.infNFe.dest.enderDest = new NFe.Classes.Informacoes.Destinatario.enderDest();
        //                oNFe.infNFe.dest.enderDest.xLgr = FNC_NVL(withBlock.Item("DS_PESSOA_LOGRADOURO"), " ").ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.nro = FNC_Endereco_TratarNumero(withBlock.Item("NR_PESSOA_LOGRADOURO")).ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.xCpl = FNC_NVL(withBlock.Item("DS_PESSOA_COMPLEMENTO"), " ").ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.xBairro = withBlock.Item("NO_PESSOA_BAIRRO").ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.cMun = withBlock.Item("CD_PESSOA_CIDADE_IBGE").ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.xMun = withBlock.Item("NO_PESSOA_CIDADE").ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.UF = withBlock.Item("CD_PESSOA_UF");
        //                if (!FNC_CampoNulo(withBlock.Item("CD_PESSOA_CEP))
        //                    oNFe.infNFe.dest.enderDest.CEP = FNC_StrZero(FNC_SoNumero(withBlock.Item("CD_PESSOA_CEP")), const_Formatos_CEP_Tamanho);
        //                oNFe.infNFe.dest.enderDest.cPais = Trim(FNC_NVL(withBlock.Item("CD_PESSOA_BACEN"), "")).ToString().Trim();
        //                oNFe.infNFe.dest.enderDest.xPais = Trim(FNC_NVL(withBlock.Item("NO_PESSOA_PAIS"), "")).ToString().Trim();
        //            }
        //            if (!bClienteNaoInformado)
        //            {
        //                if (!FNC_CampoNulo(withBlock.Item("CD_PESSOA_TELEFONE))
        //                    oNFe.infNFe.dest.enderDest.fone = Trim(FNC_SoNumero(FNC_NVL(withBlock.Item("CD_PESSOA_TELEFONE"), "));
        //            }

        //            if (oNFe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFCe)
        //            {
        //                if (!bClienteNaoInformado)
        //                    oNFe.infNFe.dest.indIEDest = NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte;
        //            }
        //            else
        //            {
        //                if (!oNFe.infNFe.dest == null)
        //                    oNFe.infNFe.dest.indIEDest = Val(FNC_NVL(withBlock.Item("CD_OPT_PJ_CONTRIBUICAO_ICMS_PS"), NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte.ToString()));

        //                if (FNC_NVL(withBlock.Item("CD_OPT_PJ_CONTRIBUICAO_ICMS_PS"), NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte) == NFe.Classes.Informacoes.Destinatario.indIEDest.ContribuinteICMS & !bClienteNaoInformado)
        //                {
        //                    if (!FNC_CampoNulo(withBlock.Item("CD_PJ_IE))
        //                        oNFe.infNFe.dest.IE = FNC_NVL(withBlock.Item("CD_PJ_IE"), "").ToString().Trim();
        //                    if (!FNC_CampoNulo(withBlock.Item("CD_PJ_IM))
        //                        oNFe.infNFe.dest.IM = withBlock.Item("CD_PJ_IM").ToString().Trim();
        //                }
        //            }

        //            // --Destinatário Endereço Retirada
        //            if (!objDataTable_CampoVazio(withBlock.Item("ID_ENDERECO_RETIRADA))
        //            {
        //                if (FNC_NVL(withBlock.Item("ID_ENDERECO"), 0) != FNC_NVL(withBlock.Item("ID_ENDERECO_RETIRADA"), 0))
        //                {
        //                    oNFe.infNFe.retirada = new NFe.Classes.Informacoes.retirada();
        //                    oNFe.infNFe.retirada.xLgr = withBlock.Item("DS_PESSOA_RETIRADA_LOGRADOURO").ToString().Trim();
        //                    oNFe.infNFe.retirada.nro = FNC_NVL(withBlock.Item("NR_PESSOA_RETIRADA_LOGRADOURO"), " ").ToString().Trim();
        //                    oNFe.infNFe.retirada.xCpl = withBlock.Item("DS_PESSOA_RETIRADA_COMPLEMENTO").ToString().Trim();
        //                    oNFe.infNFe.retirada.xBairro = withBlock.Item("NO_PESSOA_RETIRADA_BAIRRO").ToString().Trim();
        //                    oNFe.infNFe.retirada.cMun = withBlock.Item("CD_PESSOA_RETIRADA_CIDADE_IBGE").ToString().Trim();
        //                    oNFe.infNFe.retirada.xMun = withBlock.Item("NO_PESSOA_RETIRADA_CIDADE").ToString().Trim();
        //                    oNFe.infNFe.retirada.UF = withBlock.Item("CD_PESSOA_RETIRADA_UF").ToString().Trim();
        //                }
        //            }

        //            // -- Transporte
        //            if (FNC_NVL(withBlock.Item("ID_DOCUMENTOFISCAL_TIPO"), 0) == enTipoDocumentoFiscal.Saida_CupomFiscalEletronico)
        //            {
        //                oNFe.infNFe.transp = new NFe.Classes.Informacoes.Transporte.transp();
        //                oNFe.infNFe.transp.modFrete = NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfSemFrete;
        //            }
        //            else
        //            {
        //                oNFe.infNFe.transp = new NFe.Classes.Informacoes.Transporte.transp();
        //                oNFe.infNFe.transp.modFrete = Val(FNC_NVL(withBlock.Item("CD_OPT_FRETE"), enOpcoes.TipoFrete_SemFrete.GetHashCode()));
        //                oNFe.infNFe.transp.modFrete = NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfSemFrete;

        //                if (FNC_NVL(withBlock.Item("CD_OPT_FRETE"), enOpcoes.TipoFrete_SemFrete.GetHashCode()) != enOpcoes.TipoFrete_SemFrete)
        //                {
        //                    oNFe.infNFe.transp.transporta = new NFe.Classes.Informacoes.Transporte.transporta();

        //                    if (!FNC_CampoNulo(withBlock.Item("ID_PESSOA_TRANSPORTADORA))
        //                    {
        //                        if (FNC_NVL(withBlock.Item("ID_OPT_TRANSPORTADORA_FISICO_JURIDICO"), 0) == enOpcoes.FisicoJuridico_Juridico.GetHashCode())
        //                            oNFe.infNFe.transp.transporta.CNPJ = FNC_StrZero(withBlock.Item("CD_TRANSPORTADORA_CPF_CNPJ"), 14).ToString().Trim();
        //                        else
        //                            oNFe.infNFe.transp.transporta.CPF = FNC_StrZero(FNC_SoNumero(withBlock.Item("CD_TRANSPORTADORA_CPF_CNPJ")), 11).ToString().Trim();

        //                        oNFe.infNFe.transp.transporta.xNome = FNC_NVL(withBlock.Item("NO_TRANSPORTADORA"), "").ToString().Trim();
        //                        oNFe.infNFe.transp.transporta.xEnder = FNC_NVL(withBlock.Item("DS_TRANSPORTADORA_LOGRADOURO_COMPLETO"), "").ToString().Trim();
        //                        oNFe.infNFe.transp.transporta.xMun = FNC_NVL(withBlock.Item("NO_TRANSPORTADORA_CIDADE"), "").ToString().Trim();
        //                        oNFe.infNFe.transp.transporta.UF = FNC_NVL(withBlock.Item("CD_TRANSPORTADORA_UF"), "").ToString().Trim();

        //                        if (FNC_NVL(withBlock.Item("CD_OPT_TRANSPORTADORA_PJ_CONTRIBUICAO_ICMS"), NFe.Classes.Informacoes.Destinatario.indIEDest.NaoContribuinte) == NFe.Classes.Informacoes.Destinatario.indIEDest.ContribuinteICMS)
        //                            oNFe.infNFe.transp.transporta.IE = withBlock.Item("CD_PJ_IE").ToString().Trim();
        //                    }
        //                }
        //            }

        //            // -- Detalhe
        //            sSqlText = "SELECT * FROM VW_DOCUMENTOFISCAL_PRODUTO_GERAR" + " WHERE ID_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL + " AND ID_OPT_STATUS NOT IN (" + enOpcoes.StatusItemDocumentoFiscal_Cancelado.GetHashCode().ToString + ")";
        //            oData_02 = DBQuery(sSqlText);

        //            for (iCont = 0; iCont <= oData_02.Rows.Count - 1; iCont++)
        //            {
        //                if (FNC_CampoNulo(oData_02.Rows(iCont).Item("CD_OPT_ORIGEMPRODUTO))
        //                {
        //                    CaixaMensagem.Informacao("É preciso informa a origem do produto " + oData_02.Rows(iCont).Item("NO_PRODUTO"));
        //                    return null;
        //                }

        //                oNFE_Det = new NFe.Classes.Informacoes.Detalhe.det();

        //                oNFE_Det.nItem = iCont + 1;

        //                // -- Detalhe Dados do Produto
        //                oNFE_Det.prod = new NFe.Classes.Informacoes.Detalhe.prod();
        //                oNFE_Det.prod.cProd = oData_02.Rows(iCont).Item("CD_PRODUTO").ToString().Trim();

        //                if (FNC_NVL(oData_02.Rows(iCont).Item("IC_REGISTRADO_GTIN"), "N") == "S")
        //                    oNFE_Det.prod.cEAN = oData_02.Rows(iCont).Item("CD_BARRA_FABRICANTE").ToString().Trim();
        //                else
        //                    oNFE_Det.prod.cEAN = const_NFe_ProdutoSemGTIN;

        //                if (oNFe.infNFe.ide.tpAmb == TipoAmbiente.Homologacao)
        //                    oNFE_Det.prod.xProd = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
        //                else
        //                    oNFE_Det.prod.xProd = oData_02.Rows(iCont).Item("NO_PRODUTO").ToString().Trim();

        //                oNFE_Det.prod.NCM = FNC_SoNumero(oData_02.Rows(iCont).Item("CD_NCM")).ToString().Trim();
        //                oNFE_Det.prod.CFOP = oData_02.Rows(iCont).Item("CD_CFOP").ToString().Trim();
        //                oNFE_Det.prod.uCom = oData_02.Rows(iCont).Item("CD_UNIDADEMEDIDA").ToString().Trim();
        //                oNFE_Det.prod.qCom = oData_02.Rows(iCont).Item("QT_PRODUTO");
        //                oNFE_Det.prod.vUnCom = oData_02.Rows(iCont).Item("VL_UNITARIO");
        //                oNFE_Det.prod.vProd = oData_02.Rows(iCont).Item("QT_PRODUTO") * oData_02.Rows(iCont).Item("VL_UNITARIO");
        //                if (FNC_NVL(oData_02.Rows(iCont).Item("VL_DESCONTO"), 0) > 0)
        //                    oNFE_Det.prod.vDesc = oData_02.Rows(iCont).Item("VL_DESCONTO");
        //                oNFE_Det.prod.vFrete = System.Convert.ToDouble(FNC_NVL(oData_02.Rows(iCont).Item("VL_FRETE"), 0));
        //                oNFE_Det.prod.vSeg = System.Convert.ToDouble(FNC_NVL(oData_02.Rows(iCont).Item("VL_SEGURO"), 0));
        //                // -- Detalhe Dados do Produto Tributação
        //                if (FNC_NVL(oData_02.Rows(iCont).Item("IC_REGISTRADO_GTIN"), "N") == "S")
        //                    oNFE_Det.prod.cEANTrib = oData_02.Rows(iCont).Item("CD_BARRA_FABRICANTE").ToString().Trim();
        //                else
        //                    oNFE_Det.prod.cEANTrib = const_NFe_ProdutoSemGTIN;
        //                oNFE_Det.prod.uTrib = oData_02.Rows(iCont).Item("CD_UNIDADEMEDIDA").ToString().Trim();
        //                oNFE_Det.prod.qTrib = oData_02.Rows(iCont).Item("QT_PRODUTO");
        //                oNFE_Det.prod.vUnTrib = oData_02.Rows(iCont).Item("VL_UNITARIO");
        //                // -- Detalhe Dados do Produto Totaliza
        //                oNFE_Det.prod.indTot = IIf(FNC_NVL(oData_02.Rows(iCont).Item("IC_TOTALIZA"), "N") == "S", NFe.Classes.Informacoes.Detalhe.IndicadorTotal.ValorDoItemNaoCompoeTotalNF, NFe.Classes.Informacoes.Detalhe.IndicadorTotal.ValorDoItemCompoeTotalNF);

        //                // -- Detalhe Impostos
        //                oNFE_Det.imposto = new NFe.Classes.Informacoes.Detalhe.Tributacao.imposto();
        //                oNFE_Det.imposto.vTotTrib = 0;
        //                // -- Detalhe Imposto ICMS
        //                oNFE_Det.imposto.ICMS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.ICMS();
        //                oNFE_Det.imposto.ICMS.TipoICMS = ObterIcmsBasico(Val(withBlock.Item("CD_OPT_CRT")), oData_02.Rows(iCont).Item("CD_OPT_ORIGEMPRODUTO"), oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST"), oData_02.Rows(iCont).Item("CD_OPT_MODALIDADE_BC_ICMS"), oData_02.Rows(iCont).Item("CD_CSOSN"), FNC_Porcentagem(FNC_NVL(oData_02.Rows(iCont).Item("VL_TOTAL"), 0), Val(FNC_NVL(oData_02.Rows(iCont).Item("PC_BASE_ICMS"), 0))), Val(FNC_NVL(oData_02.Rows(iCont).Item("PC_ICMS"), 0)), Val(FNC_NVL(oData_02.Rows(iCont).Item("VL_ICMS"), 0)));
        //                // -- Detalhe Imposto COFINS
        //                if (!objDataTable_CampoVazio(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_COFINS))
        //                {
        //                    oNFE_Det.imposto.COFINS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.COFINS();
        //                    oNFE_Det.imposto.COFINS.TipoCOFINS = ObterCofinsBasico(Val(FNC_NVL(oData_02.Rows(iCont).Item("ID_CST_COFINS_OPT_TIPOCALCULO"), 0)), Val(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_COFINS")), FNC_NVL(oData_02.Rows(iCont).Item("VL_TOTAL"), 0), FNC_NVL(oData_02.Rows(iCont).Item("PC_COFINS"), 0), FNC_NVL(oData_02.Rows(iCont).Item("VL_COFINS"), 0), FNC_NVL(oData_02.Rows(iCont).Item("QT_PRODUTO"), 0), FNC_NVL(oData_02.Rows(iCont).Item("VL_UNITARIO"), 0));
        //                }
        //                // -- Detalhe Imposto PIS
        //                if (!objDataTable_CampoVazio(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_PIS))
        //                {
        //                    oNFE_Det.imposto.PIS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.PIS();
        //                    oNFE_Det.imposto.PIS.TipoPIS = ObterPisBasico(Val(FNC_NVL(oData_02.Rows(iCont).Item("ID_CST_PIS_OPT_TIPOCALCULO"), 0)), Val(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_PIS")), System.Convert.ToDouble(FNC_NVL(oData_02.Rows(iCont).Item("VL_TOTAL"), 0)), System.Convert.ToDouble(FNC_NVL(oData_02.Rows(iCont).Item("PC_PIS"), 0)), System.Convert.ToDouble(FNC_NVL(oData_02.Rows(iCont).Item("VL_PIS"), 0)), FNC_NVL(oData_02.Rows(iCont).Item("QT_PRODUTO"), 0), FNC_NVL(oData_02.Rows(iCont).Item("VL_UNITARIO"), 0));
        //                }
        //                // -- Detalhe Imposto IPI
        //                // NFC-e não aceita grupo "IPI"
        //                if ((withBlock.Item("CD_SERVICO_MODELO") == const_NFe_ModeloServico_NFe))
        //                {
        //                    if (!objDataTable_CampoVazio(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_IPI))
        //                    {
        //                        oNFE_Det.imposto.IPI = new NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.IPI();
        //                        oNFE_Det.imposto.IPI.cEnq = 999;
        //                        oNFE_Det.imposto.IPI.TipoIPI = ObterIPIBasico(Val(oData_02.Rows(iCont).Item("CD_REF_PROJETOZEUS_CST_IPI")), FNC_NVL(oData_02.Rows(iCont).Item("VL_TOTAL"), 0), FNC_NVL(oData_02.Rows(iCont).Item("PC_IPI"), 0), FNC_NVL(oData_02.Rows(iCont).Item("VL_IPI"), 0));
        //                    }
        //                }

        //                oNFe.infNFe.det.Add(oNFE_Det);
        //            }

        //            // -- Total
        //            oNFe.infNFe.total = GetTotal(withBlock.Item("CD_SERVICO_VERSAO"), oNFe.infNFe.det);

        //            // -- Cobrança
        //            if (oNFe.infNFe.ide.mod == ModeloDocumento.NFe & (withBlock.Item("CD_SERVICO_VERSAO") == const_NFe_VersaoServico_ve310 | withBlock.Item("CD_SERVICO_VERSAO") == const_NFe_VersaoServico_ve400))
        //            {
        //                oNFe.infNFe.cobr = new NFe.Classes.Informacoes.Cobranca.cobr();
        //                oNFe.infNFe.cobr.fat = new NFe.Classes.Informacoes.Cobranca.fat();
        //                oNFe.infNFe.cobr.fat.nFat = sNF;
        //                oNFe.infNFe.cobr.fat.vLiq = oNFe.infNFe.total.ICMSTot.vNF;
        //                oNFe.infNFe.cobr.fat.vOrig = oNFe.infNFe.total.ICMSTot.vNF;
        //                oNFe.infNFe.cobr.fat.vDesc = 0M;
        //            }

        //            if (oNFe.infNFe.ide.mod == ModeloDocumento.NFCe | (oNFe.infNFe.ide.mod == ModeloDocumento.NFe & withBlock.Item("CD_SERVICO_VERSAO") == const_NFe_VersaoServico_ve400))
        //            {
        //                sSqlText = "SELECT PEDPG.ID_FORMAPAGAMENTO, PEDPG.VL_PAGAMENTO, ADMFN.CD_CPF_CNPJ, ADMFN.CD_AUTORIZACAO" + " FROM TB_DOCUMENTOFISCAL DCFSC" + " INNER JOIN TB_PEDIDO_PAGAMENTO PEDPG ON PEDPG.SQ_PEDIDO_PAGAMENTO = DCFSC.ID_PEDIDO_PAGAMENTO" + " LEFT JOIN TB_FORMAPAGAMENTO FPGTO ON FPGTO.SQ_FORMAPAGAMENTO = PEDPG.ID_FORMAPAGAMENTO" + " LEFT JOIN VW_ADMINISTRADOORAFINANCEIRA ADMFN ON ADMFN.ID_ADMINISTRADOORAFINANCEIRA = FPGTO.ID_ADMINISTRADOORA_MAQUINA_CARTAO" + " WHERE DCFSC.SQ_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL.ToString();
        //                oData_02 = DBQuery(sSqlText);

        //                if (objDataTable_Vazio(oData_02))
        //                {
        //                    oNFE_Pag = new NFe.Classes.Informacoes.Pagamento.pag();
        //                    oNFE_Pag.detPag = new List<NFe.Classes.Informacoes.Pagamento.detPag>();
        //                    oNFE_Pag_Det = new NFe.Classes.Informacoes.Pagamento.detPag();
        //                    oNFE_Pag_Det.tPag = FormaPagamento.fpSemPagamento;
        //                    oNFE_Pag_Det.vPag = 0;
        //                    oNFE_Pag.detPag.Add(oNFE_Pag_Det);

        //                    oNFe.infNFe.pag = new List<NFe.Classes.Informacoes.Pagamento.pag>();
        //                    oNFe.infNFe.pag.Add(oNFE_Pag);
        //                }
        //                else
        //                    for (iCont = 0; iCont <= oData_02.Rows.Count - 1; iCont++)
        //                    {
        //                        // Pagamento
        //                        if (withBlock.Item("CD_SERVICO_VERSAO") != const_NFe_VersaoServico_ve400)
        //                        {
        //                            oNFe.infNFe.pag = new List<NFe.Classes.Informacoes.Pagamento.pag>();
        //                            oNFE_Pag = new NFe.Classes.Informacoes.Pagamento.pag();
        //                            oNFE_Pag.tPag = FNC_Fiscal_DocumentoFiscal_FormaPagamento(Val(oData_02.Rows(iCont).Item("ID_FORMAPAGAMENTO));
        //                            oNFE_Pag.vPag = oData_02.Rows(iCont).Item("VL_PAGAMENTO");
        //                        }
        //                        else
        //                        {
        //                            oNFe.infNFe.pag = new List<NFe.Classes.Informacoes.Pagamento.pag>();
        //                            oNFE_Pag = new NFe.Classes.Informacoes.Pagamento.pag();
        //                            oNFE_Pag.vTroco = 0;
        //                            // Pagamento Detalhe
        //                            oNFE_Pag.detPag = new List<NFe.Classes.Informacoes.Pagamento.detPag>();
        //                            oNFE_Pag_Det = new NFe.Classes.Informacoes.Pagamento.detPag();
        //                            oNFE_Pag_Det.tPag = FNC_Fiscal_DocumentoFiscal_FormaPagamento(Val(oData_02.Rows(iCont).Item("ID_FORMAPAGAMENTO));
        //                            oNFE_Pag_Det.vPag = oData_02.Rows(iCont).Item("VL_PAGAMENTO");

        //                            if (oNFE_Pag_Det.tPag == FormaPagamento.fpCartaoCredito | oNFE_Pag_Det.tPag == FormaPagamento.fpCartaoDebito)
        //                            {
        //                                oNFE_Card = new NFe.Classes.Informacoes.Pagamento.card();
        //                                oNFE_Card.tpIntegra = TipoIntegracaoPagamento.TipNaoIntegrado;
        //                                oNFE_Card.CNPJ = oData_02.Rows(iCont).Item("CD_CPF_CNPJ");
        //                                oNFE_Card.tBand = BandeiraCartao.bcOutros;
        //                                oNFE_Card.cAut = oData_02.Rows(iCont).Item("CD_AUTORIZACAO");
        //                                oNFE_Pag_Det.card = oNFE_Card;
        //                            }

        //                            oNFE_Pag.detPag.Add(oNFE_Pag_Det);

        //                            oNFe.infNFe.pag.Add(oNFE_Pag);
        //                        }
        //                    }
        //            }

        //            if (FNC_NVL(withBlock.Item("ID_OPT_TIPO_REFERENCIA"), 0) != enOpcoes.TipoReferenciaNaturezaOperacao_NaoReferenciar.GetHashCode())
        //            {
        //                List<NFref> oListaNFref = new List<NFref>();
        //                NFref oNFref;

        //                // -- Notas refênciadas
        //                sSqlText = "SELECT * FROM TB_DOCUMENTOFISCAL_REFERENCIA" + " WHERE ID_DOCUMENTOFISCAL = " + iSQ_DOCUMENTOFISCAL;
        //                oData_02 = DBQuery(sSqlText);

        //                for (iCont = 0; iCont <= oData_02.Rows.Count - 1; iCont++)
        //                {
        //                    oNFref = new NFref();

        //                    if (FNC_NVL(withBlock.Item("ID_OPT_FINALIDADE"), 0) == enOpcoes.Finalidade_NFe_DevolucaoRetorno.GetHashCode())
        //                    {
        //                        switch (FNC_NVL(withBlock.Item("ID_OPT_TIPO_REFERENCIA"), 0))
        //                        {
        //                            case object _ when enOpcoes.TipoReferenciaNaturezaOperacao_ReferenciarNFe:
        //                                {
        //                                    oNFref.refNFe = oData_02.Rows(0).Item("CD_CHAVE_NFE_REFENCENCIA").ToString().Trim();

        //                                    FNC_Str_Adicionar(sDS_INFORMACOES_ADICIONAIS, "DEVOLUCAO REF: " + oNFref.refNFe, ". ");
        //                                    break;
        //                                }
        //                        }
        //                    }

        //                    oListaNFref.Add(oNFref);
        //                }

        //                oNFe.infNFe.ide.NFref = oListaNFref;
        //            }

        //            if (!FNC_CampoNulo(FNC_NuloString(FNC_NVL(withBlock.Item("DS_INFORMACOES_ADICIONAIS"), ""), false)))
        //                sDS_INFORMACOES_ADICIONAIS = FNC_NVL(withBlock.Item("DS_INFORMACOES_ADICIONAIS"), "") + ". " + sDS_INFORMACOES_ADICIONAIS;

        //            if (Strings.Trim(sDS_INFORMACOES_ADICIONAIS) != "")
        //            {
        //                oNFe.infNFe.infAdic = new NFe.Classes.Informacoes.Observacoes.infAdic();
        //                sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS.Trim();
        //                if (sDS_INFORMACOES_ADICIONAIS.Substring(sDS_INFORMACOES_ADICIONAIS.Length - 1) == ".")
        //                    sDS_INFORMACOES_ADICIONAIS = sDS_INFORMACOES_ADICIONAIS.Substring(0, sDS_INFORMACOES_ADICIONAIS.Length - 1);
        //                oNFe.infNFe.infAdic.infCpl = sDS_INFORMACOES_ADICIONAIS;
        //            }

        //            oNFe.Assina(oConfig);

        //            if (oNFe.infNFe.ide.mod == ModeloDocumento.NFCe)
        //            {
        //                if (oNFe.infNFeSupl == null)
        //                {
        //                    oNFe.infNFeSupl = new infNFeSupl();
        //                    if (withBlock.Item("CD_SERVICO_VERSAO") == const_NFe_VersaoServico_ve400)
        //                        oNFe.infNFeSupl.urlChave = oNFe.infNFeSupl.ObterUrlConsulta(oNFe, Val(sESTACAO_TRABALHO_CD_OPT_NFCe_VERSAO_QRCODE));

        //                    sCD_NFCe_DetalheVendaNormal = iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_NORMAL;
        //                    sCD_NFCe_DetalheVendaContigencia = iESTACAO_TRABALHO_ID_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA;
        //                    sCD_NFCe_Token_ID = sESTACAO_TRABALHO_CD_NFCe_Token_ID;
        //                    sCD_NFCe_Token_CSC = sESTACAO_TRABALHO_CD_NFCe_Token_CSC.ToString().Replace("-", "");
        //                    sCD_NFCe_Token_CSC = sESTACAO_TRABALHO_CD_NFCe_Token_CSC;

        //                    oNFe.infNFeSupl.qrCode = oNFe.infNFeSupl.ObterUrlQrCode(oNFe, Val(sESTACAO_TRABALHO_CD_OPT_NFCe_VERSAO_QRCODE), sCD_NFCe_Token_ID, sCD_NFCe_Token_CSC);
        //                }
        //            }

        //            sDS_PATH_XML = FNC_NVL(withBlock.Item("DS_PATH_XML"), "");

        //            if (FNC_Diretorio_Temporario() != "")
        //            {
        //                try
        //                {
        //                    sAux = FNC_Diretorio_Temporario() + "NF-" + sNF + "-" + withBlock.Item("CD_DOCUMENTOFISCAL_SERIE") + ".xml";
        //                    oNFe.SalvarArquivoXml(sAux);

        //                    if (sDS_PATH_XML.Trim() == "")
        //                        sDS_PATH_XML = FNC_DiretorioSistema_RemoverPath(FNC_DiretorioSistema_GuardarArquivo(sAux));
        //                    else
        //                        try
        //                        {
        //                            Kill(FNC_DiretorioSistema_AdicionarPath(sDS_PATH_XML));
        //                            FileCopy(sAux, FNC_DiretorioSistema_AdicionarPath(sDS_PATH_XML));
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                        }
        //                }
        //                catch (Exception ex)
        //                {
        //                    CaixaMensagem.Informacao("FNC_Fiscal_DocumentoFiscal_Gerar - SalvarArquivoXml: " + ex.Message);
        //                }
        //            }

        //            oNFe.Valida(oConfig);

        //            FNC_Fiscal_DocumentoFiscal_Status(iSQ_DOCUMENTOFISCAL, sNF, enOpcoes.StatusDocumentoFiscal_Transmitindo.GetHashCode(), iESTACAO_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_AMBIENTE, oNFe.infNFe.Id.Substring(3), null/* Conversion error: Set to default value for this argument */, sDS_PATH_XML);
        //        }

        //        return oNFe;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException == null)
        //            CaixaMensagem.Informacao(ex.Message);
        //        else
        //            CaixaMensagem.Informacao(ex.Message + "." + ex.InnerException.Message);
        //        return null/* TODO Change to default(_) if this is not a reference type */;
        //    }
        //}
    }
}
