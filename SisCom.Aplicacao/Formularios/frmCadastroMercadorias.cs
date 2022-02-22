using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroMercadorias : Form
    {
        FormMain FormMain;

        public frmCadastroMercadorias(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            InitializeComponent();
            FormMain = new FormMain(serviceProvider, dbCtxFactory);
            Inicializar();
        }

        #region Combos
        private void comboPesquisarTipoFiltro_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarTipoFiltro, "", "", ComboBoxStyle.DropDown,
                                    new string[] { "Código", "Mercadoria", "Referência", "Observação" });
        }
        private async Task comboGrupoProduto_Carregar()
        {
            Combo_ComboBox.Formatar(comboGrupoProduto,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new GrupoMercadoriaController(FormMain.MeuDbContext())).Combo(p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
        private async Task comboFornecedor_Carregar()
        {
            Combo_ComboBox.Formatar(comboFornecedor,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(FormMain.MeuDbContext())).ComboFornecedor(p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
        private async Task comboFabricante_Carregar()
        {
            Combo_ComboBox.Formatar(comboFabricante,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FabricanteController(FormMain.MeuDbContext())).Combo(p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
        #endregion

        #region Botoes
        private void botaoFabricante_Click(object sender, EventArgs e)
        {
            var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroFabricante>();
            form.GravacaoEfetuada += CadastroFabricanteAtualizado;
            form.ShowDialog(this);
        }

        private void botaoGrupoProduto_Click(object sender, EventArgs e)
        {
            (new frmCadastroGrupo()).ShowDialog();
        }

        private void botaoSubGrupo_Click(object sender, EventArgs e)
        {

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

        #endregion

        #region Funcoes
        private void CadastroFabricanteAtualizado(object? sender, EventArgs e)
        {
            comboFabricante_Carregar();
        }

        private async void Inicializar()
        {
            LimparTela();

            //Pesquisar
            comboPesquisarTipoFiltro_Carregar();

            //Cabeçalho
            await comboGrupoProduto_Carregar();
            await comboFornecedor_Carregar();
            await comboFabricante_Carregar();
        }

        private void LimparTela()
        {
            //Pesquisar
            comboPesquisarTipoFiltro.SelectedIndex = -1;
            comboPesquisarPesquisa.SelectedIndex = -1;
            //Cabeçalho
            labelCodigoMercadoria.Text = "0000";
            textReferencia.Text = "";
            textCodigoNFe.Text = "";
            textMercadoria.Text = "";
            comboGrupoProduto.SelectedIndex = -1;
            comboSubGrupo.SelectedIndex = -1;
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
            numericEstoque_PrecoBruto.Value = 0;
            numericEstoque_PrecoLiquido.Value = 0;
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_UltimaEntrada);
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_AlteracaoPreco);
            //Tributação ECF/NFCe
            comboTributacao_ECFNFCeSituacao.SelectedIndex = -1;
            numericTributacao_ECFNFCeNFCeAliquota.Value = 0;
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
            comboDetalhesFiscais_Beneficio.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.SelectedIndex = -1;
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
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = 0;
            comboGrupoProduto.SelectedIndex = -1;
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
        #endregion

        private void frmCadastrosMercadorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.Dispose();
        }
    }
}
