using Funcoes.Interfaces;
using SisCom.Infraestrutura.Data.Context;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using System.Threading.Tasks;
using Funcoes._Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Classes;
using System.Collections.Generic;
using SisCom.Aplicacao.ViewModels;
using System.Data;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmVendasInclusao : FormMain
    {
        const int gridProdutos_Id = 0;
        const int gridProdutos_CodigoSistema = 1;
        const int gridProdutos_RefSistema = 2;
        const int gridProdutos_Descricao = 3;
        const int gridProdutos_Medida = 4;
        const int gridProdutos_Quantidade = 5;
        const int gridProdutos_Preco = 6;
        const int gridProdutos_Total = 7;
        const int gridProdutos_Excluir = 8;

        ViewModels.VendaViewModel venda = null;
        bool carregandoDados = false;

        public frmVendasInclusao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            TentarGravar(true);
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Limpar()
        {
            dateDataEntrada.Value = DateTime.Now.Date;
            textHora.Text = DateTime.Now.ToString("HH:mm");
            comboClienteCodigo.SelectedIndex = -1;
            comboClienteNome.SelectedIndex = -1;
            comboVendedor.SelectedIndex = -1;
            comboEmpresa.SelectedIndex = -1;
            numericValorFrete.Value = 0;
            textObservacao.Text = "";

            comboTransportadora.SelectedIndex = -1;
            comboMotorista.SelectedIndex = -1;
            comboPlaca1.SelectedIndex = -1;
            comboPlaca2.SelectedIndex = -1;
            comboPlaca3.SelectedIndex = -1;

            comboOutrosDados_EnderecoEntrega.SelectedIndex = -1;
            comboOutrosDados_Motorista.SelectedIndex = -1;
            comboOutrosDados_Indicador.SelectedIndex = -1;
            numericOutrosDados_KM.Value = 0;
            numericOutrosDados_KMDias.Value = 0;

            textNFCe_Numero.Text = "";
            textNFCe_Protocolo.Text = "";
            textNFCe_Serie.Text = "";
            textNFCe_ChaveNFCe.Text = "";
            dateNFCe_Emissao.Value = DateTime.Now.Date;
            comboNFCe_TipoEmissao.SelectedIndex = -1;

            numericPercentualDesconto.Value = 0;
            numericValorDesconto.Value = 0;
        }
        private async Task CarregarDados()
        {
            if (venda != null)
            {
                carregandoDados = true;

                dateDataEntrada.Value = venda.DataVenda;
                if (!Funcao.Nulo(venda.ClienteId)) comboClienteCodigo.SelectedValue = venda.ClienteId;
                if (!Funcao.Nulo(venda.EmpresaId)) comboEmpresa.SelectedValue = venda.EmpresaId;
                if (!Funcao.Nulo(venda.TabelaOrigemVendaId)) comboOrigemVenda.SelectedValue = venda.TabelaOrigemVendaId;
                if (!Funcao.Nulo(venda.VendedorId)) comboVendedor.SelectedValue = venda.VendedorId;
                if (!Funcao.Nulo(venda.TransportadoraId)) comboTransportadora.SelectedValue = venda.TransportadoraId;
                if (!Funcao.Nulo(venda.MotoristaId)) comboMotorista.SelectedValue = venda.MotoristaId;
                if (!Funcao.Nulo(venda.VeiculoPlaca01Id)) comboPlaca1.SelectedValue = venda.VeiculoPlaca01Id;
                if (!Funcao.Nulo(venda.VeiculoPlaca02Id)) comboPlaca2.SelectedValue = venda.VeiculoPlaca02Id;
                if (!Funcao.Nulo(venda.VeiculoPlaca03Id)) comboPlaca3.SelectedValue = venda.VeiculoPlaca03Id;
                numericValorFrete.Value = venda.ValorFrete;
                numericValorDesconto.Value = venda.ValorDesconto;
                labelTotal.Tag = venda.ValorTotal;
                textObservacao.Text = Funcoes._Classes.Texto.NuloString(venda.Observacao);
                checkOutrosDados_PossuiEntrega.Checked = venda.PosuiEntrega;

                using (VendaMercadoriaController vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<VendaMercadoriaViewModel> ret = await vendaMercadoriaController.PesquisarVendaId(venda.Id);

                    foreach (VendaMercadoriaViewModel vendaMercadoriaViewModel in ret)
                    {
                        Grid_DataGridView.DataGridView_LinhaAdicionar(gridProdutos,
                                                                      new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridProdutos_Id, Valor = vendaMercadoriaViewModel.Id },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_CodigoSistema, Valor = vendaMercadoriaViewModel.MercadoriaId },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_RefSistema, Valor = vendaMercadoriaViewModel.MercadoriaId },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_Descricao, Valor = vendaMercadoriaViewModel.MercadoriaId },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_Medida, Valor = vendaMercadoriaViewModel.UnidadeMedidaId },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_Quantidade, Valor = vendaMercadoriaViewModel.Quantidade },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_Preco, Valor = vendaMercadoriaViewModel.Preco },
                                                                                                      new Grid_DataGridView.Coluna { Indice = gridProdutos_Total, Valor = vendaMercadoriaViewModel.Total }});
                    }
                }

                carregandoDados = false;
            }
        }
        async Task Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
        }
        private async Task<bool> Inicializar()
        {
            try
            {
                Limpar();

                List<NomeComboViewModel> unidadeMedida;

                DataTable produto = new DataTable();
                produto.Columns.Add("ID", typeof(Guid));
                produto.Columns.Add("Descricao", typeof(string));
                produto.Columns.Add("Codigo", typeof(string));
                produto.Columns.Add("CodigoFabricante", typeof(string));

                using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<MercadoriaViewModel> ret = await mercadoriaController.ObterTodos();

                    foreach (var item in ret)
                    {
                        produto.Rows.Add(item.Id, item.Nome, item.Codigo, item.CodigoFabricante);
                    }
                }
                using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
                {
                    unidadeMedida = (List<NomeComboViewModel>)await unidadeMedidaController.Combo();
                }

                //Detalhe de Estoque
                Grid_DataGridView.DataGridView_Formatar(gridProdutos, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Descrição", Grid_DataGridView.TipoColuna.ComboBox, 400, 0, produto, "Descricao", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, unidadeMedida, "Nome", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Preço", "Preço", Grid_DataGridView.TipoColuna.Valor, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Total", "Total", Grid_DataGridView.TipoColuna.Valor, readOnly: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Excluir", "Excluir", Grid_DataGridView.TipoColuna.Button);

                //Cabeçalho
                await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());

                if (comboOrigemVenda.Items.Count == 1) { comboOrigemVenda.SelectedIndex = -1; }

                venda = new ViewModels.VendaViewModel();
                venda.Id = Guid.Empty;
                Navegar(Declaracoes.eNavegar.Primeiro);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

            return true;
        }
        #region Combos
        private async Task<bool> comboVendedor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboVendedor,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new FuncionarioController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboEmpresa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboEmpresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));
            }

            return true;
        }
        private async Task<bool> comboOrigemVenda_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboOrigemVenda,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaOrigemVendaController(this.MeuDbContext(), this._notifier)).Combo());
            }

            return true;
        }
        private async Task<bool> comboClienteOrigem_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboClienteCodigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboCodigo());
            }

            return true;
        }
        private async Task<bool> comboClienteNome_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboClienteNome,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboNome());
            }

            return true;
        }
        #endregion
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboEmpresa_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboVendedor_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboOrigemVenda_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboClienteOrigem_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboClienteNome_Carregar());

            return true;
        }
        private async Task Navegar(Declaracoes.eNavegar posicao)
        {
            if (TentarGravar(false))
            {
                await Navegar_PegarTodos(venda.Id, posicao);
                await CarregarDados();
            }
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            using (VendaController vendaController = new VendaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<VendaViewModel> Data = null;

                Data = await vendaController.ObterTodos();

                VendaViewModel ItemAnterior = null;
                VendaViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (VendaViewModel Item in Data)
                {
                    if (Posicao == Declaracoes.eNavegar.Primeiro)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Proximo)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Item.Id == Id)
                    {
                        switch (Posicao)
                        {
                            case Declaracoes.eNavegar.Anterior:
                                ItemRetorno = ItemAnterior;
                                break;
                            case Declaracoes.eNavegar.Atual:
                                ItemRetorno = Item;
                                break;
                            case Declaracoes.eNavegar.Proximo:
                                Proximo = true;
                                break;
                        }
                    }

                    ItemAnterior = Item;
                }

                if (Posicao == Declaracoes.eNavegar.Ultimo)
                {
                    ItemRetorno = ItemAnterior;
                }

                if (ItemRetorno != null) { venda = ItemRetorno; }
            }
        }

        bool TentarGravar(bool Gravar)
        {
            bool tentarGravar = false;

            if ((venda.Id == Guid.Empty) && (Combo_ComboBox.Selecionado(comboClienteCodigo)) && !(Gravar))
            {
                tentarGravar = true;
            }
            else
            {
                if (!Validacao.Hora_Valido(textHora.Text))
                {
                    CaixaMensagem.Informacao("Informe uma data válida");
                    return false;
                }
                if (!Combo_ComboBox.Selecionado(comboClienteCodigo))
                {
                    CaixaMensagem.Informacao("Selecione o cliente");
                    return false;
                }
                if (!Combo_ComboBox.Selecionado(comboVendedor))
                {
                    CaixaMensagem.Informacao("Selecione o vendedor");
                    return false;
                }
                if (!Combo_ComboBox.Selecionado(comboEmpresa))
                {
                    CaixaMensagem.Informacao("Selecione a empresa");
                    return false;
                }
                if (!Combo_ComboBox.Selecionado(comboOrigemVenda))
                {
                    CaixaMensagem.Informacao("Selecione a origem");
                    return false;
                }
                if (gridProdutos.Rows.Count == 0)
                {
                    CaixaMensagem.Informacao("Informe algum produto");
                    return false;
                }
                foreach (DataGridViewRow row in gridProdutos.Rows)
                {
                    if (row.Cells[gridProdutos_CodigoSistema].Value != null)
                    {
                        if (row.Cells[gridProdutos_Medida].Value == null)
                        {
                            CaixaMensagem.Informacao("Selecione a unidade de medida de cada produto");
                            return false;
                        }
                        if (Funcao.NuloParaValorD(row.Cells[gridProdutos_Total].Value) == 0)
                        {
                            CaixaMensagem.Informacao("Informe o valor total de cada produto");
                            return false;
                        }
                    }
                }

                Assincrono.TaskAsyncAndAwaitAsync(GravarVenda());

                tentarGravar = true;
            }

        Sair:
            return tentarGravar;
        }
        private async Task AdicionarVenda()
        {
            var vendaController = new VendaController(this.MeuDbContext(), this._notifier);
            var vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier);

            venda.DataVenda = DateTime.Parse(dateDataEntrada.Value.ToString("dd/MM/yyyy") + " " + textHora.Text);
            venda.ClienteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboClienteCodigo);
            //venda.VendedorId { get; set; }
            venda.EmpresaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEmpresa);
            venda.TabelaOrigemVendaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboOrigemVenda);
            venda.TransportadoraId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTransportadora);
            venda.VendedorId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboVendedor);
            venda.MotoristaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboMotorista);
            venda.VeiculoPlaca01Id = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboPlaca1);
            venda.VeiculoPlaca02Id = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboPlaca2);
            venda.VeiculoPlaca03Id = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboPlaca3);
            venda.ValorFrete = numericValorFrete.Value;
            venda.ValorDesconto = numericValorDesconto.Value;
            venda.ValorTotal = Funcao.NuloParaValorD(labelTotal.Tag);
            venda.Observacao = textObservacao.Text.Trim() == "" ? textObservacao.Text.Trim() : null;
            //venda.EnderecoEntrega = text
            venda.PosuiEntrega = checkOutrosDados_PossuiEntrega.Checked;

            if (venda.Id != Guid.Empty)
            {
                await vendaController.Atualizar(venda.Id, venda);
            }
            else
            {
                venda.Id = Guid.NewGuid();
                venda = (await vendaController.Adicionar(venda));
            }

            VendaMercadoriaViewModel vendaMercadoriaViewModel;

            foreach (DataGridViewRow row in gridProdutos.Rows)
            {
                if (row.Cells[gridProdutos_CodigoSistema].Value != null)
                {
                    vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier);
                    vendaMercadoriaViewModel = new VendaMercadoriaViewModel();

                    vendaMercadoriaViewModel.VendaId = venda.Id;
                    vendaMercadoriaViewModel.MercadoriaId = (Guid)row.Cells[gridProdutos_CodigoSistema].Value;
                    vendaMercadoriaViewModel.UnidadeMedidaId = (Guid)row.Cells[gridProdutos_Medida].Value;
                    vendaMercadoriaViewModel.Preco = Funcao.NuloParaValorD(row.Cells[gridProdutos_Preco].Value);
                    vendaMercadoriaViewModel.Quantidade = Funcao.NuloParaValorD(row.Cells[gridProdutos_Quantidade].Value);
                    vendaMercadoriaViewModel.Total = Funcao.NuloParaValorD(row.Cells[gridProdutos_Total].Value);

                    if (row.Cells[gridProdutos_CodigoSistema].Value == null)
                    {
                        vendaMercadoriaController.Adicionar(vendaMercadoriaViewModel);
                    }
                    else
                    {
                        vendaMercadoriaViewModel.Id = (Guid)row.Cells[gridProdutos_Id].Value;
                        vendaMercadoriaController.Atualizar(vendaMercadoriaViewModel.Id, vendaMercadoriaViewModel);
                    }
                }
            }

            vendaController = null;
            vendaMercadoriaController = null;
        }
        private async void Excluir()
        {
            var vendaController = new VendaController(this.MeuDbContext(), this._notifier);
            await vendaController.Excluir(venda.Id);
            vendaController = null;
            this.MeuDbContextDispose();

            Limpar();
        }
        private async Task<bool> GravarVenda()
        {
            if (venda == null)
                venda = new ViewModels.VendaViewModel();

            await AdicionarVenda();

            return true;
        }
        private void comboClienteCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo_ComboBox.Selecionado(comboClienteCodigo)) && (comboClienteNome.Items.Count != 0))
                comboClienteNome.SelectedIndex = comboClienteCodigo.SelectedIndex;
        }
        private void comboClienteNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo_ComboBox.Selecionado(comboClienteNome)) && (comboClienteCodigo.Items.Count != 0))
                comboClienteCodigo.SelectedIndex = comboClienteNome.SelectedIndex;
        }
        private void GridProduto_SelecionarProduto(int iLinha, int Coluna, string valor)
        {
            try
            {
                if (Coluna == gridProdutos_CodigoSistema)
                {
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_Descricao].Value = Guid.Parse(valor);
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_RefSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridProdutos_Descricao)
                {
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_RefSistema].Value = Guid.Parse(valor);
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_CodigoSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridProdutos_RefSistema)
                {
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_Descricao].Value = Guid.Parse(valor);
                    gridProdutos.Rows[iLinha].Cells[gridProdutos_CodigoSistema].Value = Guid.Parse(valor);
                }
            }
            catch (Exception)
            {
            }
        }
        private void gridProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == gridProdutos_CodigoSistema) ||
                    (e.ColumnIndex == gridProdutos_Descricao) ||
                    (e.ColumnIndex == gridProdutos_RefSistema))
                {
                    GridProduto_SelecionarProduto(e.RowIndex, e.ColumnIndex, gridProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else if ((e.ColumnIndex == gridProdutos_Quantidade) ||
                         (e.ColumnIndex == gridProdutos_Preco))
                {
                    gridProdutos.Rows[e.RowIndex].Cells[gridProdutos_Total].Value = Funcao.NuloParaNumero(gridProdutos.Rows[e.RowIndex].Cells[gridProdutos_Quantidade].Value) *
                                                                                    Funcao.NuloParaNumero(gridProdutos.Rows[e.RowIndex].Cells[gridProdutos_Preco].Value);
                }

                CalcularSubTotal();
            }
            catch (Exception)
            {
            }
        }
        private void gridProdutos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Grid_DataGridView.DataGridView_KeyPress);
        }
        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == gridProdutos_Excluir) && (e.RowIndex > 0))
            {
                gridProdutos.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void numericPercentualDesconto_ValueChanged(object sender, EventArgs e)
        {
            if (Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total) != 0)
            {
                numericValorDesconto.Value = Valor.Percentagem(Funcao.NuloParaValorD(labelSubTotal.Tag), numericPercentualDesconto.Value);
                CalcularTotal();
            }
        }
        private void numericValorDesconto_ValueChanged(object sender, EventArgs e)
        {
            if (Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total) != 0)
            {
                numericPercentualDesconto.Value = numericValorDesconto.Value / Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total) * 100;
            }
        }
        private void CalcularDesconto()
        {
            if (Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total) != 0)
            {
                if (numericPercentualDesconto.Value != 0)
                {
                    numericValorDesconto.Value = Valor.Percentagem(Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total), numericPercentualDesconto.Value);
                }
                else if (numericValorDesconto.Value != 0)
                {
                    numericPercentualDesconto.Value = numericValorDesconto.Value / Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total) * 100;
                }
            }

            CalcularTotal();
        }
        private void CalcularSubTotal()
        {
            labelSubTotal.Tag = Grid_DataGridView.DataGridView_CalcularColunaValor(gridProdutos, gridProdutos_Total);
            labelSubTotal.Text = "Sub-Total: " + labelSubTotal.Tag.ToString();
            CalcularDesconto();
        }
        private void CalcularTotal()
        {
            labelTotal.Tag = Funcao.NuloParaValorD(labelSubTotal.Tag) - numericValorDesconto.Value;
            labelTotal.Text = "TOTAL: " +  labelTotal.Tag.ToString();
        }
        private void botaoGerarNFe_Click(object sender, EventArgs e)
        {
            if (!TentarGravar(true))
            {
                CaixaMensagem.Informacao("Salve a nota antes de gerar a NF-e");
                return;
            }

            var form = this.ServiceProvider().GetRequiredService<frmFiscal_NotaFiscal>();
            form.VendaId = venda.Id;
            form.ShowDialog(this);
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_NotaFiscal>();
            form.VendaId = venda.Id;
            form.ShowDialog(this);
        }
        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(venda.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Anterior);
        }
        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(venda.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Proximo);
        }
    }
}