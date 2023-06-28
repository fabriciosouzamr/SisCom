using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroEstoque : FormMain
    {
        private const int gridProdutoEstoque_Mercadoria = 0;
        private const int gridProdutoEstoque_QtdeEstoque = 1;

        private const int gridLancamento_Data = 0;
        private const int gridLancamento_EntradaSaida = 1;
        private const int gridLancamento_Quantidade = 2;
        private const int gridLancamento_TipoMovimentacao = 3;
        private const int gridLancamento_Comentario = 4;

        private bool carregando = false;

        public frmCadastroEstoque(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        private async void Inicializar()
        {
            carregando = true;

            Combo_ComboBox.Formatar(comboLancamentoEntradaSaida, "", "", ComboBoxStyle.DropDownList, null, typeof(EntradaSaida));
            Combo_ComboBox.Formatar(comboTipoLancamentoEstoque, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoLancamentoEstoque));

            await comboAlmoxarifado_Carregar();
            await comboMercadoria_Carregar();

            Grid_DataGridView.User_Formatar(gridProdutoEstoque, true);
            Grid_DataGridView.User_ColunaAdicionar(gridProdutoEstoque, "", "Mercadoria", Tamanho: 500);
            Grid_DataGridView.User_ColunaAdicionar(gridProdutoEstoque, "", "Qtde. em Estoque", Tipo: Grid_DataGridView.TipoColuna.Numero);

            Grid_DataGridView.User_Formatar(gridLancamento, true);
            Grid_DataGridView.User_ColunaAdicionar(gridLancamento, "", "Data", Tipo: Grid_DataGridView.TipoColuna.Data);
            Grid_DataGridView.User_ColunaAdicionar(gridLancamento, "", "E/S");
            Grid_DataGridView.User_ColunaAdicionar(gridLancamento, "", "Quantidade", Tipo: Grid_DataGridView.TipoColuna.Numero);
            Grid_DataGridView.User_ColunaAdicionar(gridLancamento, "", "Tipo de Movimentação");
            Grid_DataGridView.User_ColunaAdicionar(gridLancamento, "", "Comentário", Tamanho: 300);

            dateFiltro_DataInicial.Value = DateTime.Now.AddMonths(-1);
            dateFiltro_DataFinal.Value = DateTime.Now;

            Limpar();

            carregando = false;
        }
        #region Combos
        private async Task comboAlmoxarifado_Carregar()
        {
            Combo_ComboBox.Formatar(comboAlmoxarifado,
                "ID", "Nome",
                ComboBoxStyle.DropDownList,
                await (new AlmoxarifadoController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboMercadoria_Carregar()
        {
            Combo_ComboBox.Formatar(comboMercadoria,
                "ID", "Nome",
                ComboBoxStyle.DropDownList,
                await (new MercadoriaController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        #endregion

        private void Limpar()
        {
            textNomeAlmoxarifado.Text = "";
            gridProdutoEstoque.Rows.Clear();
            gridLancamento.Rows.Clear();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {

        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {

        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {

        }

        private async void botaoGravarlancamento_Click(object sender, EventArgs e)
        {
            if (!Combo_ComboBox.Selecionado(comboAlmoxarifado))
            {
                CaixaMensagem.Informacao("Selecione o almoxarifado");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboMercadoria))
            {
                CaixaMensagem.Informacao("Selecione a mercadoria");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboUnidadeMedida))
            {
                CaixaMensagem.Informacao("Selecione a unidade de medida");
                return;
            }
            if (numericLancamentoQuantidade.Value < 0)
            {
                CaixaMensagem.Informacao("Informe a quantidade");
                return;
            }

            using (EstoqueLancamentoController estoqueLancamentoController = new EstoqueLancamentoController(this.MeuDbContext(), this._notifier))
            {
                await estoqueLancamentoController.Adicionar((Guid)comboAlmoxarifado.SelectedValue,
                                                            (Guid)comboMercadoria.SelectedValue,
                                                            (Guid)comboUnidadeMedida.SelectedValue,
                                                            (TipoLancamentoEstoque)comboTipoLancamentoEstoque.SelectedValue,
                                                            (EntradaSaida)comboLancamentoEntradaSaida.SelectedValue,
                                                            dateLancamento.Value,
                                                            (double)numericLancamentoQuantidade.Value,
                                                            textLancamentoComentario.Text);
            }

            CarregarLancamentoEstoque();
        }

        private void botaoNovoLancamento_Click(object sender, EventArgs e)
        {
            dateLancamento.Value = DateTime.Now;
            comboLancamentoEntradaSaida.SelectedItem = EntradaSaida.Entrada;
            comboTipoLancamentoEstoque.SelectedValue = TipoLancamentoEstoque.Ajuste;
            comboUnidadeMedida.SelectedIndex = -1;
            numericLancamentoQuantidade.Value = 0;
            textLancamentoComentario.Text = "";
        }

        private async void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            await CarregarLancamentoEstoque();
        }

        private async void comboAlmoxarifado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (Combo_ComboBox.Selecionado(comboAlmoxarifado) && !carregando)
                await CarregarEstoque();
        }

        private async void comboMercadoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CarregarLancamentoEstoque();
        }

        async Task CarregarLancamentoEstoque()
        {
            gridLancamento.Rows.Clear();

            if (!(Combo_ComboBox.Selecionado(comboAlmoxarifado) && Combo_ComboBox.Selecionado(comboMercadoria) && !carregando))
                return;

            IEnumerable<EstoqueLancamentoViewModel> estoqueLancamentos;

            using (EstoqueLancamentoController estoqueLancamentoController = new EstoqueLancamentoController(this.MeuDbContext(), this._notifier))
            {
                estoqueLancamentos = (await estoqueLancamentoController.Obter(order: o => o.Data, p => p.Estoque.AlmoxarifadoId == (Guid)comboAlmoxarifado.SelectedValue &&
                                                                                                                                             p.Estoque.MercadoriaId == (Guid)comboMercadoria.SelectedValue &&
                                                                                                                                             p.Data.Date >= dateFiltro_DataInicial.Value.Date &&
                                                                                                                                             p.Data.Date <= dateFiltro_DataFinal.Value.Date));
            }

            gridLancamento.Rows.Clear();

            foreach (var estoqueLancamento in estoqueLancamentos)
            {
                Grid_DataGridView.User_LinhaAdicionar(gridLancamento,
                    new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridLancamento_Data,
                                                                                           Valor = estoqueLancamento.Data },
                                                            new Grid_DataGridView.Coluna { Indice = gridLancamento_EntradaSaida,
                                                                                           Valor = estoqueLancamento.EntradaSaida.GetDescription() },
                                                            new Grid_DataGridView.Coluna { Indice = gridLancamento_Quantidade,
                                                                                           Valor = estoqueLancamento.Quantidade },
                                                            new Grid_DataGridView.Coluna { Indice = gridLancamento_TipoMovimentacao,
                                                                                           Valor = estoqueLancamento.TipoLancamentoEstoque.GetDescription() },
                                                            new Grid_DataGridView.Coluna { Indice = gridLancamento_Comentario,
                                                                                           Valor = estoqueLancamento.Comentario }});
            }
        }

        async Task CarregarEstoque()
        {
            IEnumerable<EstoqueViewModel> estoques;

            using (EstoqueController estoqueController = new EstoqueController(this.MeuDbContext(), this._notifier))
            {
                estoques = (await estoqueController.Obter(order: o => o.Mercadoria.Nome, p => p.AlmoxarifadoId == (Guid)comboAlmoxarifado.SelectedValue));
            }

            gridLancamento.Rows.Clear();

            foreach (var estoque in estoques)
            {
                Grid_DataGridView.User_LinhaAdicionar(gridProdutoEstoque,
                                                               new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridProdutoEstoque_Mercadoria,
                                                                                                                                       Valor = estoque.Mercadoria.Nome },
                                                                                                       new Grid_DataGridView.Coluna { Indice = gridProdutoEstoque_QtdeEstoque,
                                                                                                                                      Valor = estoque.QuantidadeEmEstoque }});
            }
        }
    }
}
