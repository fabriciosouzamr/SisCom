using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroMercadorias : FormMain
    {
        ViewModels.MercadoriaViewModel mercadoria = null;

        enum TipoPesquisa
        {
            [Description("Código")]
            Codigo = 0,
            [Description("Referência")]
            Referencia = 1,
            [Description("Mercadoria")]
            Mercadoria = 3,
            [Description("Observação")]
            Observacao = 4
        }
        public frmCadastroMercadorias(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Combos
        private async Task comboGrupoProduto_Carregar()
        {
            Combo_ComboBox.Formatar(comboGrupoMercadoria,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new GrupoMercadoriaController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboFornecedor_Carregar()
        {
            Combo_ComboBox.Formatar(comboFornecedor,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboFornecedor(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboFabricante_Carregar()
        {
            Combo_ComboBox.Formatar(comboFabricante,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FabricanteController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboUnidadeMedida_Carregar()
        {
            Combo_ComboBox.Formatar(comboEstoque_Unidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new UnidadeMedidaController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboTabelaSituacaoTributariaNFCe_Carregar()
        {
            Combo_ComboBox.Formatar(comboTributacao_ECFNFCeSituacao,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaSituacaoTributariaNFCeController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboTributacao_ECFNFCeTipoServico_Carregar()
        {
            Combo_ComboBox.Formatar(comboTributacao_ECFNFCeTipoServico,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new TipoServicoFiscalController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboTributacaoECFNFCeCFOP_Carregar()
        {
            Combo_ComboBox.Formatar(comboTributacaoECFNFCeCFOP,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCFOPController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_VinculoFiscal_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_VinculoFiscal,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new VinculoFiscalController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_Especifico_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_Especifico,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new TipoMercadoriaController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_CodigoANP_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_CodigoANP_Codigo,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaANPController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_NCM_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_NCM,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaNCMController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_CEST_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_CEST,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCESTController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_CST_CSOSN_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_CST_CSOSN_Codigo,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_CSOSNController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao ));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_Beneficio_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_BeneficioSped,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaBeneficioSPEDController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(this.MeuDbContext(), this._notifier)).ComboCodigo(Funcoes._Enum.EntradaSaida.Entrada, p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(this.MeuDbContext(), this._notifier)).ComboDescricao(Funcoes._Enum.EntradaSaida.Entrada, p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaEntrada(p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaEntrada(p => p.Codigo)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaModalidadeDeterminacaoBCICMSController(this.MeuDbContext(), this._notifier)).Combo(Entidade.Enum.TipoModalidadeDeterminacaoBCICMS.BC_ICMS, p => p.Codigo)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaMotivoDesoneracaoICMSController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaModalidadeDeterminacaoBCICMSController(this.MeuDbContext(), this._notifier)).Combo(Entidade.Enum.TipoModalidadeDeterminacaoBCICMS.BC_ICMS_ST, p => p.Codigo)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(this.MeuDbContext(), this._notifier)).ComboCodigo(Funcoes._Enum.EntradaSaida.Saida, p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(this.MeuDbContext(), this._notifier)).ComboDescricao(Funcoes._Enum.EntradaSaida.Saida, p => p.Descricao));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaClasseEnquadramentoIPIController(this.MeuDbContext(), this._notifier)).Combo(p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCodigoEnquadramentoIPIController(this.MeuDbContext(), this._notifier)).Combo(p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaSaida(p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaSaida(p => p.Codigo)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_SPED_TipoItem_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_TipoItem,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaSpedTipoItemController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_SPED_CodigoGenero_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_CodigoGenero,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaSpedCodigoGeneroController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao)); ;
            this.MeuDbContextDispose();
        }
        private async Task comboDetalhesFiscais_SPED_CodigoInformacaoAdicional_Carregar()
        {
            Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_CodigoInformacaoAdicional,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaSpedInformacaoAdicionalItemController(this.MeuDbContext(), this._notifier)).Combo(p => p.Descricao)); ;
            this.MeuDbContextDispose();
        }
        #endregion
        #region Botoes
        private void botaoFabricante_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroFabricante>();
            form.GravacaoEfetuada += CadastroFabricanteAtualizado;
            form.ShowDialog(this);
        }
        private void botaoGrupoProduto_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroGrupo>();
            form.ShowDialog(this);
        }
        private void botaoSubGrupo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroGrupo>();
            form.ShowDialog(this);
        }
        private void botaoDetalhesFiscais_VinculoFiscal_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasVinculoFiscal()).ShowDialog();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoDetalhesFiscais_NCM_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasNCM()).ShowDialog();
        }
        private void botaoDetalhesFiscais_CST_CSOSN_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasCST()).ShowDialog();
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            if (textNomeMercadoria.Text.Trim() == string.Empty)
            {
                CaixaMensagem.Informacao("Informe o nome do cliente!");
                return;
            }

            if (mercadoria == null)
                mercadoria = new ViewModels.MercadoriaViewModel();

            mercadoria.CodigoFabricante = Funcao.StringVazioParaNulo(textReferencia.Text);
            mercadoria.CodigoBarra = Funcao.StringVazioParaNulo(textCodigoNFe.Text);
            mercadoria.Nome = Funcao.StringVazioParaNulo(textNomeMercadoria.Text);
            mercadoria.GrupoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboGrupoMercadoria);
            mercadoria.SubGrupoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboSubGrupoMercadoria);
            mercadoria.FornecedorId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFornecedor);
            mercadoria.FabricanteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFabricante);
            mercadoria.Observacao = Funcao.StringVazioParaNulo(textObservacao.Text);
            //Preço Estoque - Preço
            mercadoria.Preco_PrecoCompra = numericPreco_PrecoCompra.Value;
            mercadoria.Preco_ICMS_Compra = numericPreco_ICMSCompra.Value;
            mercadoria.Preco_ICMS_Fronteira = numericPreco_ICMSFronteira.Value;
            mercadoria.Preco_IPI = numericPreco_IPI.Value;
            mercadoria.Preco_Frete = numericPreco_Frete.Value;
            mercadoria.Preco_Embalagem = numericPreco_Embalagem.Value;
            mercadoria.Preco_EncFinanceiro = numericPreco_EncFinanceiros.Value;
            mercadoria.Preco_CustoFixo = numericPreco_CustoFixo.Value;
            mercadoria.Preco_ImpostoFederais = numericPreco_ImpostosFederais.Value;
            mercadoria.Preco_ICMS_Venda = numericPreco_ICMSVenda.Value;
            mercadoria.Preco_Comissao = numericPreco_Comissao.Value;
            mercadoria.Preco_Marketing = numericPreco_Marketing.Value;
            mercadoria.Preco_OutrosCustos = numericPreco_OutrosCustos.Value;
            //Preço Estoque - Ponto Equilíbrio
            mercadoria.Preco_MargemSugerido = numericMargem_MargemSugerido.Value;
            mercadoria.Preco_PrecoVenda = numericMargem_PrecoVenda.Value;
            mercadoria.Preco_PrecoA = numericMargem_PrecoA.Value;
            mercadoria.Preco_PrecoB = numericMargem_PrecoB.Value;
            mercadoria.Preco_PrecoC = numericMargem_PrecoC.Value;
            //Preço Estoque - Estoque
            mercadoria.Estoque_QuantidadeMinimo = (double)numericEstoque_EstoqueMinimo.Value;
            mercadoria.Estoque_UnidadeMedidaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEstoque_Unidade);
            mercadoria.Estoque_Pratileira = Funcao.StringVazioParaNulo(textEstoque_Pratileira.Text);
            mercadoria.Estoque_PesoBruto = (double)numericEstoque_PesoBruto.Value;
            mercadoria.Estoque_PesoLiquido = (double)numericEstoque_PesoLiquido.Value;
            mercadoria.Estoque_UltimaEntrada = dateEstoque_UltimaEntrada.Value;
            mercadoria.Estoque_AlteracaoPreco = dateEstoque_AlteracaoPreco.Value;
            //Tributação ECF/NFCe
            mercadoria.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTributacao_ECFNFCeSituacao);
            mercadoria.Estoque_TributacaoNFCe_AliquotaICMS = numericTributacao_ECFNFCeNFCeAliquotaICMS.Value;
            mercadoria.Estoque_TributacaoNFCe_TipoServicoFiscalId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTributacao_ECFNFCeTipoServico);
            mercadoria.Estoque_TributacaoNFCe_TipoServicoMunicipal = Funcao.StringVazioParaNulo(textTributacao_ECFNFCeTipoServicoMunicipal.Text);
            //Preço Estoque - Outros
            mercadoria.NaoVender = checkNaoVender.Checked;
            mercadoria.NaoControlarEstoque = checkNaoControlarEstoque.Checked;
            mercadoria.Ativado = (!checkDesativado.Checked);
            //Detalhes Fiscais
            mercadoria.Fiscal_VinculoFiscalId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_VinculoFiscal);
            mercadoria.Fiscal_InformacaoAdicional = Funcao.StringVazioParaNulo(textDetalhesFiscais_InformacaoAdicional.Text);
            mercadoria.Fiscal_TipoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_Especifico);
            mercadoria.Fiscal_TabelaANPId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CodigoANP_Codigo);
            mercadoria.Fiscal_CodigoAnvisa = Funcao.StringVazioParaNulo(textDetalhesFiscais_CodigoAnvisa.Text);
            mercadoria.Fiscal_TabelaNCMId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_NCM);
            mercadoria.Fiscal_TabelaCESTId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CEST);
            mercadoria.Fiscal_TabelaOrigemMercadoriaServicoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_Origem);
            mercadoria.Fiscal_TabelaCST_CSOSNId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CST_CSOSN_Codigo);
            mercadoria.Fiscal_TabelaBeneficioSPEDId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_BeneficioSped);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI
            mercadoria.Fiscal_NFE_TabelaCST_IPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo);
            mercadoria.Fiscal_NFE_IPI_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            mercadoria.Fiscal_NFE_TabelaCST_PISId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo);
            mercadoria.Fiscal_NFE_PIS_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value;
            mercadoria.Fiscal_NFE_TabelaCST_COFINSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo);
            mercadoria.Fiscal_NFE_COFINS_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
            mercadoria.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase);
            mercadoria.Fiscal_NFS_ICMS_ValorAdicional = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value;
            mercadoria.Fiscal_NFS_ICMS_Deferimento = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value;
            mercadoria.Fiscal_NFS_ICMS_ReducaoBase = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value;
            mercadoria.Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
            mercadoria.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase);
            mercadoria.Fiscal_NFS_ICMSST_ValorAdicional = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value;
            mercadoria.Fiscal_NFS_ICMSST_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value;
            mercadoria.Fiscal_NFS_ICMSST_ReducaoBase = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
            mercadoria.Fiscal_NFS_IPI_TabelaCST_IPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo);
            mercadoria.Fiscal_NFS_IPI_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value;
            mercadoria.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento);
            mercadoria.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo);
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value;
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo);
            mercadoria.Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value;
            mercadoria.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita);
            mercadoria.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita);

            //Detalhes Fiscais - SEP
            mercadoria.Fiscal_SPED_TabelaSpedTipoItemId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_TipoItem);
            mercadoria.Fiscal_SPED_TabelaSpedCodigoGeneroId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_CodigoGenero);
            mercadoria.Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_CodigoInformacaoAdicional);
            //Detalhes Fiscais - Outros.
            mercadoria.Fiscal_OutrosPMC = numericDetalhesFiscais_OutrosPMC.Value;
            mercadoria.Fiscal_OutrosNVE = numericDetalhesFiscais_OutrosNVE.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
            mercadoria.Fiscal_NFS_TributosFederais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value;
            mercadoria.Fiscal_NFS_TributosMunicipais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value;
            mercadoria.Fiscal_NFS_TributosEstaduais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value;
            mercadoria.Fiscal_NFS_TributosTotal = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value;
            mercadoria.Fiscal_NFS_ValorTributosTotal = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value;
            //Detalhe de Estoque
            // >>> gridEstoqueEmpresa;
            // >>> gridEstoqueEmTransito
            //Foto e Especificação
            mercadoria.FotoEspecificacao_Especificacao = Funcao.StringVazioParaNulo(textEspecificacao.Text);
            mercadoria.FotoEspecificacao_URL = Funcao.StringVazioParaNulo(textURL.Text);
            mercadoria.FotoEspecificacao_UsarFoto = checkUsarFoto.Checked;
            mercadoria.FotoEspecificacao_Imagem = Imagem.ImageToByteArray(picFoto.Image);
            //Produção
            mercadoria.Producao_Configuracao_ValidadeDias = (int)txtProducao_Configuracao_ValidadeDias.Value;
            mercadoria.Producao_Configuracao_NaoBaixarComposicaoVenda = chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked;
            // >>> gridProducao_Composicao
            //Integração
            // >>> gridIntegracaoEmpresaFornecedor
            //Similares
            // >>> gridListaMercadoriasSimilares

            Adicionarmercadoria();
        }
        #endregion
        #region Funcoes
        private void CadastroFabricanteAtualizado(object? sender, EventArgs e)
        {
            comboFabricante_Carregar();
        }

        private async void Inicializar()
        {
            tabControl.TabPages.Remove(tabProducao);
            tabControl.TabPages.Remove(tabFotoEspecificacao);
            tabControl.TabPages.Remove(tabIntegracao);
            tabControl.TabPages.Remove(tabSimiliares);

            //Pesquisar
            Combo_ComboBox.Formatar(comboPesquisarTipoFiltro, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPesquisa));

            //Cabeçalho
            await comboGrupoProduto_Carregar();
            await comboFornecedor_Carregar();
            await comboFabricante_Carregar();
            await comboUnidadeMedida_Carregar();
            await comboTabelaSituacaoTributariaNFCe_Carregar();
            await comboTributacao_ECFNFCeTipoServico_Carregar();
            await comboTributacaoECFNFCeCFOP_Carregar();
            await comboDetalhesFiscais_VinculoFiscal_Carregar();
            await comboDetalhesFiscais_Especifico_Carregar();
            await comboDetalhesFiscais_CodigoANP_Codigo_Carregar();
            await comboDetalhesFiscais_CEST_Carregar();
            await comboDetalhesFiscais_CST_CSOSN_Codigo_Carregar();
            await comboDetalhesFiscais_Beneficio_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo_Carregar();
            await comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo_Carregar();
            await comboDetalhesFiscais_SPED_TipoItem_Carregar();
            await comboDetalhesFiscais_SPED_CodigoGenero_Carregar();
            await comboDetalhesFiscais_SPED_CodigoInformacaoAdicional_Carregar();

            Limpar();
        }

        private void Limpar()
        {
            //Pesquisar
            comboPesquisarTipoFiltro.SelectedIndex = -1;
            comboPesquisarPesquisa.SelectedIndex = -1;
            //Cabeçalho
            labelCodigoMercadoria.Text = "0000";
            textReferencia.Text = "";
            textCodigoNFe.Text = "";
            textNomeMercadoria.Text = "";
            comboGrupoMercadoria.SelectedIndex = -1;
            comboSubGrupoMercadoria.SelectedIndex = -1;
            comboFornecedor.SelectedIndex = -1;
            comboFabricante.SelectedIndex = -1;
            textObservacao.Text = "";
            //Preço Estoque - Preço
            numericPreco_PrecoCompra.Value = 0;
            numericPreco_ICMSCompra.Value = 0;
            labelPreco_ValorICMSCompra.Text = Valor.Formatar(0);
            numericPreco_ICMSFronteira.Value = 0;
            labelPreco_ValorICMSFronteira.Text = Valor.Formatar(0);
            numericPreco_IPI.Value = 0;
            labelPreco_ValorIPI.Text = Valor.Formatar(0);
            numericPreco_Frete.Value = 0;
            labelPreco_ValorFrete.Text = Valor.Formatar(0);
            numericPreco_Embalagem.Value = 0;
            labelPreco_ValorEmbalagem.Text = Valor.Formatar(0);
            numericPreco_EncFinanceiros.Value = 0;
            labelPreco_ValorEncFinanceiros.Text = Valor.Formatar(0);
            labelPreco_ValorCustoMercadoria.Text = Valor.Formatar(0);
            numericPreco_CustoFixo.Value = 0;
            labelPreco_ValorCustoFixo.Text = Valor.Formatar(0);
            numericPreco_ImpostosFederais.Value = 0;
            labelPreco_ValorImpostosFederais.Text = Valor.Formatar(0);
            numericPreco_ICMSVenda.Value = 0;
            labelPreco_ValorICMSVenda.Text = Valor.Formatar(0);
            numericPreco_Comissao.Value = 0;
            labelPreco_ValorComissao.Text = Valor.Formatar(0);
            numericPreco_Marketing.Value = 0;
            labelPreco_ValorMarketing.Text = Valor.Formatar(0);
            numericPreco_OutrosCustos.Value = 0;
            labelPreco_ValorOutrosCustos.Text = Valor.Formatar(0);
            //Preço Estoque - Ponto Equilíbrio
            labelMargem_PontoEquilibrio.Text = "0000";
            numericMargem_MargemSugerido.Value = 0;
            labelMargem_ValorlMargemSugerido.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoSugerido.Text = Valor.Formatar(0);
            numericMargem_PrecoVenda.Value = 0;
            labelMargem_MargemVenda.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoVenda.Text = Valor.Formatar(0);
            numericMargem_PrecoA.Value = 0;
            labelMargem_MargemPrecoA.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoA.Text = Valor.Formatar(0);
            numericMargem_PrecoB.Value = 0;
            labelMargem_MargemPrecoB.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoB.Text = Valor.Formatar(0);
            numericMargem_PrecoC.Value = 0;
            labelMargem_MargemPrecoC.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoC.Text = Valor.Formatar(0);
            //Preço Estoque - Estoque
            labelEstoque_Quantidade.Text = "0000";
            numericEstoque_EstoqueMinimo.Value = 0;
            comboEstoque_Unidade.SelectedIndex = -1;
            textEstoque_Pratileira.Text = "";
            numericEstoque_PesoBruto.Value = 0;
            numericEstoque_PesoLiquido.Value = 0;
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_UltimaEntrada);
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_AlteracaoPreco);
            //Tributação ECF/NFCe
            comboTributacao_ECFNFCeSituacao.SelectedIndex = -1;
            numericTributacao_ECFNFCeNFCeAliquotaICMS.Value = 0;
            comboTributacao_ECFNFCeTipoServico.SelectedIndex = -1;
            textTributacao_ECFNFCeTipoServicoMunicipal.Text = "";
            //Preço Estoque - Outros
            labelCalculoPreco.Text = "0000";
            labelCalculoPrecificacao.Text = "0000";
            checkNaoVender.Checked = false;
            checkNaoControlarEstoque.Checked = false;
            checkDesativado.Checked = false;
            //Detalhes Fiscais
            comboDetalhesFiscais_VinculoFiscal.SelectedIndex = -1;
            textDetalhesFiscais_InformacaoAdicional.Text = "";
            comboDetalhesFiscais_Especifico.SelectedIndex = -1;
            comboDetalhesFiscais_CodigoANP_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_CodigoANPDescricao.SelectedIndex = -1;
            textDetalhesFiscais_CodigoAnvisa.Text = "";
            comboDetalhesFiscais_NCM.SelectedIndex = -1;
            comboDetalhesFiscais_CEST.SelectedIndex = -1;
            comboDetalhesFiscais_Origem.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedIndex = -1;
            comboDetalhesFiscais_BeneficioSped.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita.SelectedIndex = -1;
            //Detalhes Fiscais - SEP
            comboDetalhesFiscais_SPED_TipoItem.SelectedIndex = -1;
            comboDetalhesFiscais_SPED_CodigoGenero.SelectedIndex = -1;
            comboDetalhesFiscais_SPED_CodigoInformacaoAdicional.SelectedIndex = -1;
            //Detalhes Fiscais - Outros.
            numericDetalhesFiscais_OutrosPMC.Value = 0;
            numericDetalhesFiscais_OutrosNVE.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value = 0;
            //Detalhe de Estoque
            Grid_DataGridView.DataGridView_Formatar(gridEstoqueEmpresa);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "Almoxarifado", "Almoxarifado");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeEstoque", "Quantidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeBloqueada", "Bloqueada");
            Grid_DataGridView.DataGridView_Formatar(gridEstoqueEmTransito);
            //Foto e Especificação
            textEspecificacao.Text = "";
            textURL.Text = "";
            checkUsarFoto.Checked = false;
            picFoto.Image = null;
            //Produção
            txtProducao_Configuracao_ValidadeDias.Value = 0;
            chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked = false;
            Grid_DataGridView.DataGridView_Formatar(gridProducao_Composicao);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "MercadoriaComponente", "");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "Quantidade", "Quantidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "Sequencia", "Sequência");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "PercentualPerdaQuebra", "% Perda/Quebra");
            //Integração
            Grid_DataGridView.DataGridView_Formatar(gridIntegracaoEmpresaFornecedor);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "Fornecedor", "Fornecedor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "CodigoFonecedor", "Código");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadePorCaixa", "Quantidade por Caixa");
            //Similares
            Grid_DataGridView.DataGridView_Formatar(gridListaMercadoriasSimilares);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "Similar", "Nome");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "Preco", "Preço");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "QuantidadeEmEstoque", "Quantidade em Estoque");
        }
        private async void CarregarDados()
        {
            if (mercadoria != null)
            {
                labelCodigoMercadoria.Text = mercadoria.Codigo.ToString("00000");
                textReferencia.Text = Funcao.NuloParaString(mercadoria.CodigoFabricante);
                textCodigoNFe.Text = Funcao.NuloParaString(mercadoria.CodigoBarra);
                textNomeMercadoria.Text = Funcao.NuloParaString(mercadoria.Nome);
                comboGrupoMercadoria.SelectedIndex = -1;
                comboSubGrupoMercadoria.SelectedIndex = -1;
                comboFornecedor.SelectedIndex = -1;
                comboFabricante.SelectedIndex = -1;
                textObservacao.Text = "";
                //Preço Estoque - Preço
                numericPreco_PrecoCompra.Value = 0;
                numericPreco_ICMSCompra.Value = 0;
                labelPreco_ValorICMSCompra.Text = Valor.Formatar(0);
                numericPreco_ICMSFronteira.Value = 0;
                labelPreco_ValorICMSFronteira.Text = Valor.Formatar(0);
                numericPreco_IPI.Value = 0;
                labelPreco_ValorIPI.Text = Valor.Formatar(0);
                numericPreco_Frete.Value = 0;
                labelPreco_ValorFrete.Text = Valor.Formatar(0);
                numericPreco_Embalagem.Value = 0;
                labelPreco_ValorEmbalagem.Text = Valor.Formatar(0);
                numericPreco_EncFinanceiros.Value = 0;
                labelPreco_ValorEncFinanceiros.Text = Valor.Formatar(0);
                labelPreco_ValorCustoMercadoria.Text = Valor.Formatar(0);
                numericPreco_CustoFixo.Value = 0;
                labelPreco_ValorCustoFixo.Text = Valor.Formatar(0);
                numericPreco_ImpostosFederais.Value = 0;
                labelPreco_ValorImpostosFederais.Text = Valor.Formatar(0);
                numericPreco_ICMSVenda.Value = 0;
                labelPreco_ValorICMSVenda.Text = Valor.Formatar(0);
                numericPreco_Comissao.Value = 0;
                labelPreco_ValorComissao.Text = Valor.Formatar(0);
                numericPreco_Marketing.Value = 0;
                labelPreco_ValorMarketing.Text = Valor.Formatar(0);
                numericPreco_OutrosCustos.Value = 0;
                labelPreco_ValorOutrosCustos.Text = Valor.Formatar(0);
                //Preço Estoque - Ponto Equilíbrio
                labelMargem_PontoEquilibrio.Text = "0000";
                numericMargem_MargemSugerido.Value = 0;
                labelMargem_ValorlMargemSugerido.Text = Valor.Formatar(0);
                labelMargem_ValorPrecoSugerido.Text = Valor.Formatar(0);
                numericMargem_PrecoVenda.Value = 0;
                labelMargem_MargemVenda.Text = Valor.Formatar(0);
                labelMargem_ValorPrecoVenda.Text = Valor.Formatar(0);
                numericMargem_PrecoA.Value = 0;
                labelMargem_MargemPrecoA.Text = Valor.Formatar(0);
                labelMargem_ValorPrecoA.Text = Valor.Formatar(0);
                numericMargem_PrecoB.Value = 0;
                labelMargem_MargemPrecoB.Text = Valor.Formatar(0);
                labelMargem_ValorPrecoB.Text = Valor.Formatar(0);
                numericMargem_PrecoC.Value = 0;
                labelMargem_MargemPrecoC.Text = Valor.Formatar(0);
                labelMargem_ValorPrecoC.Text = Valor.Formatar(0);
                //Preço Estoque - Estoque
                labelEstoque_Quantidade.Text = "0000";
                numericEstoque_EstoqueMinimo.Value = 0;
                comboEstoque_Unidade.SelectedIndex = -1;
                textEstoque_Pratileira.Text = "";
                numericEstoque_PesoBruto.Value = 0;
                numericEstoque_PesoLiquido.Value = 0;
                Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_UltimaEntrada);
                Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_AlteracaoPreco);
                //Tributação ECF/NFCe
                comboTributacao_ECFNFCeSituacao.SelectedIndex = -1;
                numericTributacao_ECFNFCeNFCeAliquotaICMS.Value = 0;
                comboTributacao_ECFNFCeTipoServico.SelectedIndex = -1;
                textTributacao_ECFNFCeTipoServicoMunicipal.Text = "";
                //Preço Estoque - Outros
                labelCalculoPreco.Text = "0000";
                labelCalculoPrecificacao.Text = "0000";
                checkNaoVender.Checked = false;
                checkNaoControlarEstoque.Checked = false;
                checkDesativado.Checked = false;
                //Detalhes Fiscais
                comboDetalhesFiscais_VinculoFiscal.SelectedIndex = -1;
                textDetalhesFiscais_InformacaoAdicional.Text = "";
                comboDetalhesFiscais_Especifico.SelectedIndex = -1;
                comboDetalhesFiscais_CodigoANP_Codigo.SelectedIndex = -1;
                comboDetalhesFiscais_CodigoANPDescricao.SelectedIndex = -1;
                textDetalhesFiscais_CodigoAnvisa.Text = "";
                comboDetalhesFiscais_NCM.SelectedIndex = -1;
                comboDetalhesFiscais_CEST.SelectedIndex = -1;
                comboDetalhesFiscais_Origem.SelectedIndex = -1;
                comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedIndex = -1;
                comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedIndex = -1;
                comboDetalhesFiscais_BeneficioSped.SelectedIndex = -1;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
                comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex = -1;
                comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex = -1;
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = 0;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
                comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedIndex = -1;
                textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = "";
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = 0;
                comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedIndex = -1;
                textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = "";
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value = 0;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase.SelectedIndex = -1;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value = 0;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao.SelectedIndex = -1;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase.SelectedIndex = -1;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value = 0;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedIndex = -1;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedIndex = -1;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value = 0;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento.SelectedIndex = -1;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento.SelectedIndex = -1;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedIndex = -1;
                textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = "";
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = 0;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedIndex = -1;
                textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = "";
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = 0;
                comboGrupoMercadoria.SelectedIndex = -1;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita.SelectedIndex = -1;
                //Detalhes Fiscais - SEP
                comboDetalhesFiscais_SPED_TipoItem.SelectedIndex = -1;
                comboDetalhesFiscais_SPED_CodigoGenero.SelectedIndex = -1;
                comboDetalhesFiscais_SPED_CodigoInformacaoAdicional.SelectedIndex = -1;
                //Detalhes Fiscais - Outros.
                numericDetalhesFiscais_OutrosPMC.Value = 0;
                numericDetalhesFiscais_OutrosNVE.Value = 0;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value = 0;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value = 0;
                //Detalhe de Estoque
                Grid_DataGridView.DataGridView_Formatar(gridEstoqueEmpresa);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "Almoxarifado", "Almoxarifado");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeEstoque", "Quantidade");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeBloqueada", "Bloqueada");
                Grid_DataGridView.DataGridView_Formatar(gridEstoqueEmTransito);
                //Foto e Especificação
                textEspecificacao.Text = "";
                textURL.Text = "";
                checkUsarFoto.Checked = false;
                picFoto.Image = null;
                //Produção
                txtProducao_Configuracao_ValidadeDias.Value = 0;
                chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked = false;
                Grid_DataGridView.DataGridView_Formatar(gridProducao_Composicao);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "MercadoriaComponente", "");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "Quantidade", "Quantidade");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "Sequencia", "Sequência");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProducao_Composicao, "PercentualPerdaQuebra", "% Perda/Quebra");
                //Integração
                Grid_DataGridView.DataGridView_Formatar(gridIntegracaoEmpresaFornecedor);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "Fornecedor", "Fornecedor");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "CodigoFonecedor", "Código");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadePorCaixa", "Quantidade por Caixa");
                //Similares
                Grid_DataGridView.DataGridView_Formatar(gridListaMercadoriasSimilares);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "Similar", "Nome");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "Preco", "Preço");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridListaMercadoriasSimilares, "QuantidadeEmEstoque", "Quantidade em Estoque");
                this.MeuDbContextDispose();
            }
        }
        private async void Adicionarmercadoria()
        {
            var mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier);

            if (mercadoria.Id != Guid.Empty)
            {
                await mercadoriaController.Atualizar(mercadoria.Id, mercadoria);
            }
            else
            {
                mercadoria = (await mercadoriaController.Adicionar(mercadoria));
            }

            mercadoriaController = null;

            this.MeuDbContextDispose();
        }
        private async void Excluir()
        {
            var mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier);
            await mercadoriaController.Excluir(mercadoria.Id);
            mercadoriaController = null;
            this.MeuDbContextDispose();

            Limpar();
        }
        #endregion

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void comboPesquisarPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void botaoFornecedor_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroFornecedores>();
            form.ShowDialog(this);
        }

        private void comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo))
            {
                textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedItem).Descricao;
            }
            else
            {
                textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = "";
            }
        }
    }
}
