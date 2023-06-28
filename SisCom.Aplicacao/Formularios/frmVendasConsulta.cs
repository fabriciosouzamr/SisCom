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
    public partial class frmVendasConsulta : FormMain
    {
        const int gridVenda_ID = 0;
        const int gridVenda_Codigo = 1;
        const int gridVenda_Data = 2;
        const int gridVenda_Pedido = 3;
        const int gridVenda_NFCe = 4;
        const int gridVenda_NFe = 5;
        const int gridVenda_Cliente = 6;
        const int gridVenda_Vendedor = 7;

        public frmVendasConsulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
        }
        async Task Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
        }
        private async Task<bool> Inicializar()
        {
            Combo_ComboBox.Formatar(comboFiltro_Empresa,
                                    "Id", "RazaoSocial",
                                    ComboBoxStyle.DropDownList,
                                    await (new EmpresaController(this.MeuDbContext(), this._notifier)).Combo(p => p.RazaoSocial));
            Combo_ComboBox.Formatar(comboFiltro_Vendedor,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FuncionarioController(this.MeuDbContext(), this._notifier)).ComboVendedor(p => p.Nome));
            Combo_ComboBox.Formatar(comboFiltro_Cliente,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FuncionarioController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));

            //Grid Nota Fiscal Entrada
            Grid_DataGridView.User_Formatar(gridVenda, true);
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "ID", Tamanho: 0);
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "Código");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "Data");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "Pedido");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "NFC - e");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "NF - e");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "Cliente");
            Grid_DataGridView.User_ColunaAdicionar(gridVenda, "", "Vendedor");

            InicializarFiltro();

            return true;
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmVendasInclusao>();
            form.novo = true;
            form.ShowDialog(this);
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        async void Carregar()
        {
            bool valido = false;
            string vendedor;
            string nFe;
            string nFCe;

            var vendaController = new VendaController(this.MeuDbContext(), this._notifier);
            var vendas = await vendaController.ObterTodos(o => o.Codigo);

            gridVenda.Rows.Clear();

            foreach (var venda in vendas)
            {
                valido = true;

                if ((valido) && (!Funcao.NuloData(dateFiltro_DataInicial.Value))) { valido = venda.DataVenda.Date >= dateFiltro_DataInicial.Value; }
                if ((valido) && (!Funcao.NuloData(dateFiltro_DataInicial.Value))) { valido = venda.DataVenda.Date <= dateFiltro_DataFinal.Value; }
                if ((valido) && (!String.IsNullOrEmpty(textFiltro_Pedido.Text)) && (!String.IsNullOrEmpty(venda.NumeroPedido))) { valido = venda.NumeroPedido == textFiltro_Pedido.Text; }
                if ((valido) && (Combo_ComboBox.Selecionado(comboFiltro_Cliente))) { valido = venda.ClienteId == (Guid)comboFiltro_Cliente.SelectedValue; }
                if ((valido) && (Combo_ComboBox.Selecionado(comboFiltro_Vendedor))) { valido = venda.VendedorId == (Guid)comboFiltro_Vendedor.SelectedValue; }

                if (valido)
                {
                    vendedor = "";
                    nFe = "";
                    nFCe = "";

                    if (venda.VendedorId != Guid.Empty)
                        vendedor = venda.Vendedor.Nome;

                    Grid_DataGridView.User_LinhaAdicionar(gridVenda,
                                                                   new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridVenda_ID,
                                                                                                                                   Valor = venda.Id },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_Codigo,
                                                                                                                                   Valor = venda.Codigo },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_Data,
                                                                                                                                   Valor = venda.DataVenda },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_Pedido,
                                                                                                                                   Valor = venda.NumeroPedido },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_NFCe,
                                                                                                                                   Valor = nFCe },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_NFe,
                                                                                                                                   Valor = nFe },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_Cliente,
                                                                                                                                   Valor = venda.Cliente.Nome },
                                                                                                    new Grid_DataGridView.Coluna { Indice = gridVenda_Vendedor,
                                                                                                                                   Valor = vendedor }});
                }
            }
        }

        private void botaoLimparFiltros_Click(object sender, EventArgs e)
        {
            InicializarFiltro();
        }

        private void InicializarFiltro()
        {
            dateFiltro_DataInicial.Value = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day);
            dateFiltro_DataFinal.Value = DateTime.Now.Date;
            textFiltro_Pedido.Text = "";
            textFiltro_NFCe.Text = "";
            textFiltro_NFe.Text = "";
            comboFiltro_Cliente.SelectedIndex = -1;
            comboFiltro_Vendedor.SelectedIndex = -1;

            if (comboFiltro_Empresa.Items.Count == 1)
            { comboFiltro_Empresa.SelectedIndex = 0; }
            else
            { comboFiltro_Empresa.SelectedIndex = -1; }
        }

        private void gridVenda_DoubleClick(object sender, EventArgs e)
        {
            if (gridVenda.CurrentRow != null)
            {
                if (gridVenda.CurrentRow.Cells[gridVenda_ID].Value != null)
                {
                    var form = this.ServiceProvider().GetRequiredService<frmVendasInclusao>();
                    form.vendaId = (Guid)gridVenda.CurrentRow.Cells[gridVenda_ID].Value;
                    form.ShowDialog(this);
                }
            }
        }
    }
}
