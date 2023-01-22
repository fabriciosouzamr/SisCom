using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grid_DataGridView;

namespace SisCom.Aplicacao
{
    public partial class frmCadastroConfiguracao : Form
    {

        const int GridUnidadeMedica_Id = 0;
        const int GridUnidadeMedica_Nome = 1;

        public frmCadastroConfiguracao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        private async void Inicializar()
        {
            Grid_DataGridView.User_Formatar(dataUnidadeMedida);
            Grid_DataGridView.User_ColunaAdicionar(dataUnidadeMedida, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataUnidadeMedida, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres);

            await GridAtualizar();
        }
        private async Task GridAtualizar()
        {
            using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            {
                object Data = await unidadeMedidaController.ObterTodos(p => p.Nome);
                Grid_DataGridView.User_DataSource(dataUnidadeMedida, Data, true);
            }
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
