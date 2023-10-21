using AutoMapper;
using Funcoes.Interfaces;
using Funcoes.Notifications;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SisCom.Aplicacao.Classes
{
    public static class Declaracoes
    {
        public static MeuDbContext dbContext;
        public static MapperConfiguration configuration;
        public static Mapper mapper;

        public const string Aplicacao_Nome = "Sistema Comercial";
        public const string Aplicacao_CaminhoFoto = "\\fotos\\";
        public static string Aplicacao_CaminhoDiretorioTemporaria = "\\temp\\";
        public static string Aplicacao_PathRepositorioArquivo = "";
        public static int Aplicacao_AlturaTela = 0;
        public static int Aplicacao_LarguraTela = 0;

        public static string Estacao_CD_OPT_NFCe_DETALHE_VENDA_NORMAL = "";
        public static string Estacao_TRABALHO_CD_OPT_NFCe_DETALHE_VENDA_CONTIGENCIA = "";
        public static string Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_PATH_ARQUIVO = "";
        public static string Estacao_TRABALHO_DS_CERTIFICADO_DIGITAL_SENHA = "";
        public static DFe.Utils.TipoCertificado Estacao_TRABALHO_ID_OPT_CERTIFICADO_DIGITAL_TIPO = DFe.Utils.TipoCertificado.A1Repositorio;

        public const int CampoNome_Caracteres = 100;

        public static string sistema_UsuarioLogado = "Administrador";
        public static string sistema_Loja = "Loja Teste";
        public static Guid sistema_almoxarifado = Guid.Parse("1F1BF45B-20EF-4E07-9BE3-C59D828C3FE3");

        public static object ComboBox_Carregando = 1;

        public static eTipoCalculo tipoCalculo = eTipoCalculo.Padrao;
        public static eCalculoPreco calculoPreco = eCalculoPreco.Compra;

        public static string externos_SisCom_Aplicacao_FW = "";
        public static string externos_Path_Schemas = "";
        public static string externos_Path_NuvemFiscal_Vendas = "";
        public static string externos_Path_NuvemFiscal_Compras = "";
        public static string externos_Path_NuvemFiscal_MDFe = "";

        public static Guid dados_Empresa_Id;
        public static Guid dados_Empresa_EstadoId;
        public static Guid dados_Empresa_CidadeId;
        public static string dados_Empresa_CodigoEstado;
        public static string dados_Empresa_SerialNumber;
        public static TipoEmissor dados_Empresa_TipoEmirssor = TipoEmissor.Normal;
        public static string dados_Empresa_CNPJ;
        public static string dados_Empresa_Nome;
        public static RegimeTributario dados_Empresa_RegimeTributario = RegimeTributario.SimplesNacional;
        public static FuncionarioViewModel dados_funcionario;
        public static byte[]? dados_Empresa_Logotipo;
        public static string dados_Empresa_PathLogomarca = "";
        public static string dados_Path_DocumentoFiscal = "";
        public static bool login_Valido = false;

        public enum eNavegar
        {
            Primeiro,
            Anterior,
            Atual,
            Proximo,
            Ultimo
        }

        public enum eTipoCalculo
        {
            Padrao = 1,
            TVA = 2
        }

        public enum eCalculoPreco
        {
            Compra = 1,
            Venda = 2
        }

        public enum TipoManifestar
        {
            [Description("Confirmacao da Operacao")]
            TeMdConfirmacaoDaOperacao = 210200,
            [Description("Ciencia da Operacao")]
            TeMdCienciaDaOperacao = 210210,
            [Description("Desconhecimento da Operacao")]
            TeMdDesconhecimentoDaOperacao = 210220,
            [Description("Operacao nao Realizada")]
            TeMdOperacaoNaoRealizada = 210240
        }
    }

    public class NotaFiscalManifestar
    {
        public string NFe { set; get; }
        public string Serie { set; get; }
        public DateTime Emissao { set; get; }
        public double Valor { set; get; }
        public string ChaveAcesso { get; set; }
        public string CNPJ { get; set; }
    }
    public class NotaFiscalMercadoriaDetalhamentoImposto
    {
        public decimal Preco { set; get; }
        public decimal ValorBaseCalculo { set; get; }
        public decimal AliquotaICMS { set; get; }
        public decimal ValorICMS { set; get; }
        public decimal AliquotaReducao { set; get; }
        public decimal ValorBaseSubstituicaoTributaria { set; get; }
        public decimal ValorSubstituicaoTributaria { set; get; }
        public decimal ValorAdicional { set; get; }
        public decimal AliquotaAdicional { set; get; }
        public Guid? CSTIPI { set; get; }
        public decimal ValorBaseIPI { set; get; }
        public decimal AliquotaIPI { set; get; }
        public decimal ValorIPI { set; get; }
        public Guid? CSTPIS { set; get; }
        public decimal AliquotaPIS { set; get; }
        public Guid? CSTCOFINS { set; get; }
        public decimal AliquotaCOFINS { set; get; }
        public decimal BaseCalculoFCP { set; get; }
        public decimal AliquotaFCP { set; get; }
        public decimal ValorFCP { set; get; }
        public string NumeroPedidoCompra { set; get; }
        public string ItemPedidoCompra { set; get; }
    }

    public static class Texto
    {
        public static string Mensagem_Fabricante_Remover = "Deseja remover o fabricante [Param01]?";
        public static string Mensagem_TipoCliente_Remover = "Deseja remover o tipo de cliente [Param01]?";
        public static string Mensagem_UnidadeMedida_Remover = "Deseja remover a unidade medida [Param01]?";
        public static string Mensagem_Pais_Remover = "Deseja remover o país [Param01]?";
        public static string Mensagem_Grupo_NaoSelecionado = "Não foi selecionado nenhum grupo!";
        public static string Mensagem_Grupo_Remover = "Deseja remover o grupo [Param01]?";
    }

    public class Notifier : INotifier
    {
        public List<Notification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(Notification notification)
        {
            CaixaMensagem.Informacao(notification.Key);
        }

        public void Handle(string notification)
        {
            CaixaMensagem.Informacao(notification);
        }

        public bool HasNotification()
        {
            throw new NotImplementedException();
        }
    }

    public enum enOpcoes_NFe_StatusProcessamento
    {
        [XmlEnum("100")]
        AutorizadoUsoNFe = 100,
        [XmlEnum("101")]
        CancelamentoNFeHomologado = 101,
        [XmlEnum("102")]
        InutilizacaoNumeroHomologado = 102,
        [XmlEnum("103")]
        LoteRecebidoComSucesso = 103,
        [XmlEnum("104")]
        LotePocessado = 104,
        [XmlEnum("105")]
        LoteProcessamento = 105,
        [XmlEnum("106")]
        LoteNaoLocalizado = 106,
        [XmlEnum("107")]
        ServicoSVCOperacao = 107,
        [XmlEnum("108")]
        Rejeicao_ServicoParalisadoMomentaneamente_CurtoPrazo = 108,
        [XmlEnum("109")]
        ServicoParalisadoPrevisao = 109,
        [XmlEnum("110")]
        Rejeicao_UsoDenegado = 110,
        [XmlEnum("111")]
        ConsultaCadastroComUmaOcorrencia = 111,
        [XmlEnum("112")]
        ConsultaCadastroComMaisUmaOcorrencia = 112,
        [XmlEnum("113")]
        SVCProcessoDesativacaoSVCSeraDesabilitadaSEFAZ = 113,
        [XmlEnum("114")]
        SVCDesabilitadaSEFAZOrigem = 114,
        [XmlEnum("128")]
        LoteEventoProcessado = 128,
        [XmlEnum("135")]
        EventoRegistradoVinculadoNFe = 135,
        [XmlEnum("136")]
        EventoRegistradoMasNaoVinculadoNFe = 136,
        [XmlEnum("201")]
        Rejeicao_ONumeroMaximoNumeracaoNFeAInutilizarUtrapassouLimite = 201,
        [XmlEnum("202")]
        Rejeicao_FalhaReconhecimentoAutoriaIntegridadeArquivoDigital = 202,
        [XmlEnum("203")]
        Rejeicao_EmissorNaoHabilitadoParaEmissaoNFe = 203,
        [XmlEnum("204")]
        Rejeicao_DuplicidadeNFe_999999999999999999999999999999999 = 204,
        [XmlEnum("205")]
        Rejeicao_NFeEstaDenegadaBaseDadosSEFAZ = 205,
        [XmlEnum("206")]
        Rejeicao_NFeJaEstaInutilizadaBaseDadosSEFAZ = 206,
        [XmlEnum("207")]
        Rejeicao_CNPJEmitenteInvalido = 207,
        [XmlEnum("208")]
        Rejeicao_CNPJDestinatarioInvalido = 208,
        [XmlEnum("209")]
        Rejeicao_IE_EmitenteInvalida = 209,
        [XmlEnum("210")]
        Rejeicao_IE_DestinatarioInvalida = 210,
        [XmlEnum("211")]
        Rejeicao_IE_SubstitutoInvalida = 211,
        [XmlEnum("212")]
        Rejeicao_DataEmissaoNFePosteriorDataRecebimento = 212,
        [XmlEnum("213")]
        Rejeicao_CNPJ_BaseEmitenteDifereCNPJ_BaseCertificadoDigital = 213,
        [XmlEnum("214")]
        Rejeicao_TamanhoMensagemExcedeuLimiteEstabelecido = 214,
        [XmlEnum("215")]
        Rejeicao_FalhaSchemaXML = 215,
        [XmlEnum("216")]
        Rejeicao_ChaveAcessoDifereCadastrada = 216,
        [XmlEnum("217")]
        Rejeicao_NFeNaoConstaBaseDadosSEFAZ = 217,
        [XmlEnum("218")]
        Rejeicao_NFeJaEstaCanceladaBaseDadosSEFAZ = 218,
        [XmlEnum("219")]
        Rejeicao_CirculacaoNFeVerificada = 219,
        [XmlEnum("220")]
        Rejeicao_NFeAutorizadaHaMais7Dias_168Horas = 220,
        [XmlEnum("221")]
        Rejeicao_ConfirmadoRecebimentoNFePeloDestinatario = 221,
        [XmlEnum("222")]
        Rejeicao_ProtocoloAutorizacaoUsoDifereCadastrado = 222,
        [XmlEnum("223")]
        Rejeicao_CNPJTransmissorLoteDifereCNPJTransmissorConsulta = 223,
        [XmlEnum("224")]
        Rejeicao_AFaixaInicialMaiorAFaixaFinal = 224,
        [XmlEnum("225")]
        Rejeicao_FalhaSchemaXMLNFe = 225,
        [XmlEnum("226")]
        Rejeicao_CodigoUFEmitenteDivergeUFAutorizadora = 226,
        [XmlEnum("227")]
        Rejeicao_ErroChaveAcesso_CampoIDFaltaLiteralNFe = 227,
        [XmlEnum("228")]
        Rejeicao_DataEmissaoMuitoAtrasada = 228,
        [XmlEnum("229")]
        Rejeicao_IEEmitenteNaoinformada = 229,
        [XmlEnum("230")]
        Rejeicao_IEEmitenteNaocadastrada = 230,
        [XmlEnum("231")]
        Rejeicao_IEEmitenteNaovinculadaCNPJ = 231,
        [XmlEnum("232")]
        Rejeicao_IEDestinatarioNaoinformada = 232,
        [XmlEnum("233")]
        Rejeicao_IEDestinatarioNaocadastrada = 233,
        [XmlEnum("234")]
        Rejeicao_IEDestinatarioNaovinculadaCNPJ = 234,
        [XmlEnum("235")]
        Rejeicao_InscricaoSUFRAMAInvalida = 235,
        [XmlEnum("236")]
        Rejeicao_ChaveAcessoDigitoVerificadorInvalido = 236,
        [XmlEnum("237")]
        Rejeicao_CPFDestinatarioInvalido = 237,
        [XmlEnum("238")]
        Rejeicao_Cabecalho_VersaoArquivoXMLSuperiorVersaoVigente = 238,
        [XmlEnum("239")]
        Rejeicao_Cabecalho_VersaoArquivoXMLNaoSuportada = 239,
        [XmlEnum("240")]
        Rejeicao_CancelamentoInutilizacaoIrregularidadeFiscalEmitente = 240,
        [XmlEnum("241")]
        Rejeicao_UmNumeroDaFaixaJaFoiUtilizado = 241,
        [XmlEnum("242")]
        Rejeicao_Cabecalho_FalhaSchemaXML = 242,
        [XmlEnum("243")]
        Rejeicao_XMLMalFormado = 243,
        [XmlEnum("244")]
        Rejeicao_CNPJCertificadoDigitalDifereCNPJMatrizDoCNPJEmitente = 244,
        [XmlEnum("245")]
        Rejeicao_CNPJEmitenteNaocadastrado = 245,
        [XmlEnum("246")]
        Rejeicao_CNPJDestinatarioNaocadastrado = 246,
        [XmlEnum("247")]
        Rejeicao_SiglaUFEmitenteDivergeUFAutorizadora = 247,
        [XmlEnum("248")]
        Rejeicao_UFReciboDivergeUFAutorizadora = 248,
        [XmlEnum("249")]
        Rejeicao_UFChaveAcessoDivergeUFAutorizadora = 249,
        [XmlEnum("250")]
        Rejeicao_UFDivergeUFAutorizadora = 250,
        [XmlEnum("251")]
        Rejeicao_UFMunicipioDestinatarioNaoPertenceSUFRAMA = 251,
        [XmlEnum("252")]
        Rejeicao_AmbienteInformadoDivergeAmbienteRecebimento = 252,
        [XmlEnum("253")]
        Rejeicao_DigitoVerificadorChaveAcessoCompostaInvalida = 253,
        [XmlEnum("254")]
        Rejeicao_NFeComplementarNaoPossuiNFReferenciada = 254,
        [XmlEnum("255")]
        Rejeicao_NFeComplementarPossuiMaisUmaNFReferenciada = 255,
        [XmlEnum("256")]
        Rejeicao_UmaNFeDaFaixaJaEstaInutilizadaBaseDadosSEFAZ = 256,
        [XmlEnum("257")]
        Rejeicao_SolicitanteNaohabilitadoParaEmissaoNFe = 257,
        [XmlEnum("258")]
        Rejeicao_CNPJConsultaInvalido = 258,
        [XmlEnum("259")]
        Rejeicao_CNPJConsultaNaoCadastradoComoContribuinteUF = 259,
        [XmlEnum("260")]
        Rejeicao_IEConsultaInvalida = 260,
        [XmlEnum("261")]
        Rejeicao_IEConsultaNaocadastradaComoContribuinteUF = 261,
        [XmlEnum("262")]
        Rejeicao_UFNaoForneceConsultaPorCPF = 262,
        [XmlEnum("263")]
        Rejeicao_CPFConsultaInvalido = 263,
        [XmlEnum("264")]
        Rejeicao_CPFConsultaNaoCadastradoComoContribuinteUF = 264,
        [XmlEnum("265")]
        Rejeicao_SiglaUFConsultaDifereUFWebService = 265,
        [XmlEnum("266")]
        Rejeicao_SerieUtilizadaNaoPermitidaWebService = 266,
        [XmlEnum("267")]
        Rejeicao_NFComplementarReferenciaNFeInexistente = 267,
        [XmlEnum("268")]
        Rejeicao_NFComplementarReferenciaOutraNFeComplementar = 268,
        [XmlEnum("269")]
        Rejeicao_CNPJEmitenteNFComplementarDifereCNPJNFReferenciada = 269,
        [XmlEnum("270")]
        Rejeicao_CodigoMunicipioFatoGeradorDigitoInvalido = 270,
        [XmlEnum("271")]
        Rejeicao_CodigoMunicipioFatoGeradorDifereUFEmitente = 271,
        [XmlEnum("272")]
        Rejeicao_CodigoMunicipioEmitenteDigitoInvalido = 272,
        [XmlEnum("273")]
        Rejeicao_CodigoMunicipioEmitenteDifereUFEmitente = 273,
        [XmlEnum("274")]
        Rejeicao_CodigoMunicipioDestinatarioDigitoInvalido = 274,
        [XmlEnum("275")]
        Rejeicao_CodigoMunicipioDestinatarioDifereUFDestinatario = 275,
        [XmlEnum("276")]
        Rejeicao_CodigoMunicipioLocalRetirada_DigitoInvalido = 276,
        [XmlEnum("277")]
        Rejeicao_CodigoMunicipioLocalRetirada_DfereUFLocalRetirada = 277,
        [XmlEnum("278")]
        Rejeicao_CodigoMunicipioLocalEntrega_DigitoInvalido = 278,
        [XmlEnum("279")]
        Rejeicao_CodigoMunicipioLocalEntrega_DifereUFLocalEntrega = 279,
        [XmlEnum("280")]
        Rejeicao_CertificadoTransmissorInvalido = 280,
        [XmlEnum("281")]
        Rejeicao_CertificadoTransmissorDataValidade = 281,
        [XmlEnum("282")]
        Rejeicao_CertificadoTransmissorSemCNPJ = 282,
        [XmlEnum("283")]
        Rejeicao_CertificadoTransmissorErroCadeiaCertificacao = 283,
        [XmlEnum("284")]
        Rejeicao_CertificadoTransmissorRevogado = 284,
        [XmlEnum("285")]
        Rejeicao_CertificadoTransmissorDifereICPBrasil = 285,
        [XmlEnum("286")]
        Rejeicao_CertificadoTransmissorErroAcessoLCR = 286,
        [XmlEnum("287")]
        Rejeicao_CodigoMunicipioFG_ISSQNDigitoInvalido = 287,
        [XmlEnum("288")]
        Rejeicao_CodigoMunicipioFG_TransporteiígitoInvalido = 288,
        [XmlEnum("289")]
        Rejeicao_CodigoInformadaDivergeUFSolicitada = 289,
        [XmlEnum("290")]
        Rejeicao_CertificadoAssinaturaInvalido = 290,
        [XmlEnum("291")]
        Rejeicao_CertificadoAssinaturaDataValidade = 291,
        [XmlEnum("292")]
        Rejeicao_CertificadoAssinaturaSemCNPJ = 292,
        [XmlEnum("293")]
        Rejeicao_CertificadoAssinaturaErroCadeiaCertificacao = 293,
        [XmlEnum("294")]
        Rejeicao_CertificadoAssinaturaRevogado = 294,
        [XmlEnum("295")]
        Rejeicao_CertificadoAssinaturaDifereICPBrasil = 295,
        [XmlEnum("296")]
        Rejeicao_CertificadoAssinaturaErroAcessoLCR = 296,
        [XmlEnum("297")]
        Rejeicao_AssinaturaDifereCalculado = 297,
        [XmlEnum("298")]
        Rejeicao_AssinaturaDiferePadraoProjeto = 298,
        [XmlEnum("299")]
        Rejeicao_XMLAreaCabecalhoComCodificacaoDiferenteUTF8 = 299,
        [XmlEnum("301")]
        UsoDenegadoIrregularidadeFiscalEmitente = 301,
        [XmlEnum("302")]
        UsoDenegadoIrregularidadeFiscalDestinatario = 302,
        [XmlEnum("355")]
        Rejeicao_InformarLocalSaidaDoPaisCasoExportacao,
        [XmlEnum("401")]
        Rejeicao_CPFRemetenteInvalido = 401,
        [XmlEnum("402")]
        Rejeicao_XMLAreaDadosComCodificacaoDiferenteUTF8 = 402,
        [XmlEnum("403")]
        Rejeicao_OGrupoInformacoesNFeAvulsaDeUsoExclusivoFisco = 403,
        [XmlEnum("404")]
        Rejeicao_UsoPrefixoNamespaceNaoPermitido = 404,
        [XmlEnum("405")]
        Rejeicao_CodigoPaisEmitente_DigitoInvalido = 405,
        [XmlEnum("406")]
        Rejeicao_CodigoPaisDestinatario_DigitoInvalido = 406,
        [XmlEnum("407")]
        Rejeicao_OCPFSoPodeSerInformadoCampoEmitenteParaNFeAvulsa = 407,
        [XmlEnum("409")]
        Rejeicao_Campo_cUF_InexistenteElemento_nfeCabecMsgSOAPHeader = 409,
        [XmlEnum("410")]
        Rejeicao_UFInformadaCampo_cUFNao_AtendidaWebService = 410,
        [XmlEnum("411")]
        Rejeicao_CampoVersaoDadosInexistenteElemento_nfeCabecMsgSOAPHeader = 411,
        [XmlEnum("453")]
        Rejeicao_AnoInutilizacaoNaoPodeSersuperiorAnoAtual = 453,
        [XmlEnum("454")]
        Rejeicao_AnoInutilizacaoNaoPodeSerinferior2006 = 454,
        [XmlEnum("478")]
        Rejeicao_LocalEntregaNaoinformadoFaturamentoDiretoVeiculosNovos = 478,
        [XmlEnum("502")]
        Rejeicao_ErroChaveAcesso_CampoIDNaoCorrespondeAConcatenacao = 502,
        [XmlEnum("503")]
        Rejeicao_SerieUtilizadaForaDaFaixaPermitidaSCAN_900_999 = 503,
        [XmlEnum("504")]
        Rejeicao_DataEntradaSaidaPosteriorPermitido = 504,
        [XmlEnum("505")]
        Rejeicao_DataEntradaSaidaAnteriorPermitido = 505,
        [XmlEnum("506")]
        Rejeicao_DataSaidaMenorQueDataEmissao = 506,
        [XmlEnum("507")]
        Rejeicao_OCNPJDestinatarioRemetenteNaoDeveSerInformadoOperacao = 507,
        [XmlEnum("508")]
        Rejeicao_OCPFDestinatarioRemetenteNaoDeveSerInformadoOperacao = 508,
        [XmlEnum("509")]
        Rejeicao_OCNPJConteudoNuloSoValidoOperacaoExterior = 509,
        [XmlEnum("510")]
        Rejeicao_OperacaoExteriorCodigoPaisDestinatario1058_Brasil_ouNao = 510,
        [XmlEnum("511")]
        Rejeicao_NaoOperaçaoExteriorCodigoPaisDestinatarioDifere1058Brasil = 511,
        [XmlEnum("512")]
        Rejeicao_CNPJLocalRetiradaInvalido = 512,
        [XmlEnum("513")]
        Rejeicao_CodigoMunicipioLocalRetiradaDeveSer_9999999_UFRetirada_EX = 513,
        [XmlEnum("514")]
        Rejeicao_CNPJLocalEntregaInvalido = 514,
        [XmlEnum("515")]
        Rejeicao_CodigoMunicipioLocalEntregaDeveSer_9999999_UFEntrega_EX = 515,
        [XmlEnum("516")]
        Rejeicao_ObrigatoriaInformacaoNCM_Genero = 516,
        [XmlEnum("517")]
        Rejeicao_InformacaoNCMDifereInformacaoGenero = 517,
        [XmlEnum("518")]
        Rejeicao_CFOPEntradaNFeSaida = 518,
        [XmlEnum("519")]
        Rejeicao_CFOPSaidaNFeEntrada = 519,
        [XmlEnum("520")]
        Rejeicao_CFOPOperacaoExteriorUFDestinatarioDifereEX = 520,
        [XmlEnum("521")]
        Rejeicao_CFOPNaoEDeOperacaoComExteriorUFDestinatarioEX = 521,
        [XmlEnum("522")]
        Rejeicao_CFOPOperacaoEstadualUFEmitenteDifereUFDestinatario = 522,
        [XmlEnum("523")]
        Rejeicao_CFOPNaoEOperacaoEstadualUFEmitenteIgualUFDestinatario = 523,
        [XmlEnum("524")]
        Rejeicao_CFOPOperacaoComExteriorENaoInformadoNCM = 524,
        [XmlEnum("525")]
        Rejeicao_CFOPImportacaoENaoInformadDadosDI = 525,
        [XmlEnum("526")]
        Rejeicao_CFOPExportacaoENaoInformadoLocalEmbarque = 526,
        [XmlEnum("527")]
        Rejeicao_OperacaoExportacaoComInformacaoICMSIncompativel = 527,
        [XmlEnum("528")]
        Rejeicao_ValorICMSDifereProdutoBCAliquota = 528,
        [XmlEnum("529")]
        Rejeicao_NCMInformacaoObrigatoriaParaProdutoTributadopeloIPI = 529,
        [XmlEnum("530")]
        Rejeicao_OperacaoComTibutacaoISSQNinformarInscricaoMunicipal = 530,
        [XmlEnum("531")]
        Rejeicao_TotalBCICMSDifereSomatorioDosItens = 531,
        [XmlEnum("532")]
        Rejeicao_TotalICMSDifereSomatorioDosItens = 532,
        [XmlEnum("533")]
        Rejeicao_TotalBCICMS_STDifereSomatorioItens = 533,
        [XmlEnum("534")]
        Rejeicao_TotalICMS_STDifereSomatorioItens = 534,
        [XmlEnum("535")]
        Rejeicao_TotalFreteDifereSomatorioItens = 535,
        [XmlEnum("536")]
        Rejeicao_TotalSeguroDifereSomatorioItens = 536,
        [XmlEnum("537")]
        Rejeicao_TotalDescontoDifereSomatorioItens = 537,
        [XmlEnum("538")]
        Rejeicao_TotalIPIDifereSomatorioItens = 538,
        [XmlEnum("539")]
        Rejeicao_DuplicidadeNFecomDiferencaChaveAcesso = 539,
        [XmlEnum("540")]
        Rejeicao_CPFLocalRetiradaInvalido = 540,
        [XmlEnum("541")]
        Rejeicao_CPFLocalEntregaInvalido = 541,
        [XmlEnum("542")]
        Rejeicao_CNPJTransportadorInvalido = 542,
        [XmlEnum("543")]
        Rejeicao_CPFTransportadorInvalido = 543,
        [XmlEnum("544")]
        Rejeicao_IETransportadorInvalido = 544,
        [XmlEnum("545")]
        Rejeicao_NotaFiscalEmitidaContingencia = 545,
        [XmlEnum("546")]
        Rejeicao_ErroChaveAcesso_CampoID_FaltaLiteralNFe = 546,
        [XmlEnum("547")]
        Rejeicao_DígitoVerificadorChaveAcessoNFeReferenciadaInvalido = 547,
        [XmlEnum("548")]
        Rejeicao_CNPJ_NFReferenciadaInvalido = 548,
        [XmlEnum("549")]
        Rejeicao_CNPJ_NFReferenciadaProdutorInvalido = 549,
        [XmlEnum("550")]
        Rejeicao_CPF_NFReferenciadaProdutorInvalido = 550,
        [XmlEnum("551")]
        Rejeicao_IE_NFReferenciadaProdutorInvalido = 551,
        [XmlEnum("552")]
        Rejeicao_DigitoVerificadorChaveAcessoCTeReferenciadoInvalido = 552,
        [XmlEnum("553")]
        Rejeicao_TipoAutorizadorReciboDivergeOrgaoAutorizador = 553,
        [XmlEnum("554")]
        Rejeicao_SerieDifereDaFaixa_0_899 = 554,
        [XmlEnum("555")]
        Rejeicao_TipoAutorizadorProtocoloDivergeOrgaoAutorizador = 555,
        [XmlEnum("556")]
        Rejeicao_JustificativaEntradaContingenciaNaoDeveSerInformadaParaTipo = 556,
        [XmlEnum("557")]
        Rejeicao_AJustificativaEntradaContingenciaDeveSerInformada = 557,
        [XmlEnum("558")]
        Rejeicao_DataEntradaContingenciaPosteriorDataEmissao = 558,
        [XmlEnum("559")]
        Rejeicao_UFTransportadorNaoInformado = 559,
        [XmlEnum("560")]
        Rejeicao_CNPJBaseEmitenteDifereCNPJBasePrimeiraNFeLoteRecebido = 560,
        [XmlEnum("561")]
        Rejeicao_MesEmissaoInformadoChaveAcessoDifereMesEmissaoNFe = 561,
        [XmlEnum("562")]
        Rejeicao_CodigoNumericoInformadoChaveAcessoDifereCodigoNumericoDa = 562,
        [XmlEnum("999")]
        Rejeicao_ErroNaoCatalogadoInformarMensagemErroCapturadoTratamentoDa = 999,
        [XmlEnum("124")]
        EPEC_Autorizado = 124,
        [XmlEnum("137")]
        NenhumDocumentoLocalizadoDestinatario = 137,
        [XmlEnum("138")]
        DocumentoLocalizadoParaDestinatario = 138,
        [XmlEnum("139")]
        PedidoDownloadProcessado = 139,
        [XmlEnum("140")]
        DownloadDisponibilizado = 140,
        [XmlEnum("142")]
        AmbienteContingenciaEPECBloqueadoEmitente = 142,
        [XmlEnum("150")]
        AutorizadoNFeAutorizacaoForaPrazo = 150,
        [XmlEnum("151")]
        CancelamentoNFeHomologadoForaPrazo = 151,
        [XmlEnum("303")]
        UsoDenegado_DestinatarioNaoHabilitadoAOperarNaUF = 303,
        [XmlEnum("304")]
        Rejeicao_PedidoCancelamentoNFeComEventoSuframa = 304,
        [XmlEnum("315")]
        Rejeicao_DataEmissaoAnteriorInicioAutorizacaoNotaFiscalUF = 315,
        [XmlEnum("316")]
        Rejeicao_NotaFiscalReferenciadaComAMesmaChaveAcessoNotaFiscalAtual = 316
    }
}
