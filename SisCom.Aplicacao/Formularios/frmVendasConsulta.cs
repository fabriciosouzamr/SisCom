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
        const int gridNotaFiscalEntrada_ID = 0;
        const int gridNotaFiscalEntrada_Data = 1;
        const int gridNotaFiscalEntrada_Pedido = 2;
        const int gridNotaFiscalEntrada_NFCe = 3;
        const int gridNotaFiscalEntrada_NFe = 4;
        const int gridNotaFiscalEntrada_NúmeroDAV = 5;
        const int gridNotaFiscalEntrada_Cliente = 6;
        const int gridNotaFiscalEntrada_Vendedor = 7;

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
            Grid_DataGridView.DataGridView_Formatar(gridNotaFiscalEntrada, true);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "ID", Tamanho: 0);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Data");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Pedido");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "NFC - e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "NF - e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Número DAV");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Cliente");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Vendedor");

            return true;
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmVendasInclusao>();
            form.ShowDialog(this);
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {

        }

        /*async Task<bool> Carregar()
        {
            bool valido;

            var notaFiscalentradamercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier);
            var notaFiscalentradamercadorias = await notaFiscalentradamercadoriaController.ObterTodos();
        }*/

        private void botaoLimparFiltros_Click(object sender, EventArgs e)
        {
            dateFiltro_DataInicial.Value = DateTime.Now.Date;
            dateFiltro_DataFinal.Value = DateTime.Now.Date;
            textFiltro_Pedido.Text = "";
            textFiltro_NFCe.Text = "";
            textFiltro_NFe.Text = "";
            textFiltro_NumeroDAV.Text = "";
            comboFiltro_Cliente.SelectedIndex = -1;
            comboFiltro_Vendedor.SelectedIndex = -1;
        }
    }
}
