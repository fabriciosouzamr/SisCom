using Funcoes._Classes;
using Funcoes.Enum;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmComprasConsulta : FormMain
    {
        public frmComprasConsulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }
        private void frmComprasConsulta_Load(object sender, EventArgs e)
        {
            Inicializar();
        }
        private async Task Inicializar()
        {
            Data_DateTimePicker.DateTimePicker_Formatar(dateFiltro_DataInicial);
            Data_DateTimePicker.DateTimePicker_Formatar(dateFiltro_DataFinal);
            Combo_ComboBox.Formatar(comboFiltroTipoData, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_TipoData));
            Combo_ComboBox.Formatar(comboFiltro_Modelo, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Modelo));
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroCFOP_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroEstado_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroFornecedor_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroEmpresa_Carregar());

            Grid_DataGridView.DataGridView_Formatar(gridComprasConsulta);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Data da Entrada");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Data de Emissão");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Nota Fiscal");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Fornecedor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","CFOP");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","UF");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Modelo");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Empresa");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridComprasConsulta, "","Valor");
        }
        private async Task<bool> comboFiltroCFOP_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_CFOP,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCFOPController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboFiltroFornecedor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Fornecedor,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(meuDbContext, this._notifier)).ComboFornecedor(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboFiltroEstado_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Estado,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new EstadoController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboFiltroEmpresa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Empresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(meuDbContext, this._notifier)).Combo(p => p.Unidade));
            }

            return true;
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmComprasInclusao>();
            form.ShowDialog(this);
        }
    }
}
