using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grid_DataGridView;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroFabricante : FormMain
    {
        public event EventHandler GravacaoEfetuada;

        const int GridFabricante_Id = 0;
        const int GridFabricante_Nome = 1;

        public frmCadastroFabricante(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        private async void Inicializar()
        {
            Grid_DataGridView.User_Formatar(dataFabricante);
            Grid_DataGridView.User_ColunaAdicionar(dataFabricante, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataFabricante, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres);
            GridAtualizar();
        }
        private async Task GridAtualizar()
        {
            FabricanteController fabricanteController = new FabricanteController(this.MeuDbContext(), this._notifier);
            object Data = await fabricanteController.ObterTodos(p => p.Nome);
            Grid_DataGridView.User_DataSource(dataFabricante, Data, true);
            fabricanteController = null;
            this.MeuDbContextDispose();
        }
        private async Task Gravar(Guid Id, string Nome)
        {
            try
            {
                FabricanteViewModel fabricante = new FabricanteViewModel();
                FabricanteController fabricanteController = new FabricanteController(this.MeuDbContext(), this._notifier);
                fabricante.Nome = Nome;
                fabricante.Id = Id;

                if (fabricante.Id != Guid.Empty)
                {
                    await fabricanteController.Atualizar(fabricante.Id, fabricante);
                }
                else
                {
                    await fabricanteController.Adicionar(fabricante);
                }

                fabricanteController = null;
                this.MeuDbContextDispose();

                GravacaoEfetuada.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Cadatro de Fabricante - Gravar", ex);
            }
        }
        private async void Remover(Guid Id)
        {
            FabricanteController fabricanteController = new FabricanteController(this.MeuDbContext(), this._notifier);
            await fabricanteController.Remover(Id);
            this.MeuDbContextDispose();
        }
        #endregion
        private void dataFabricante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Funcoes._Classes.Texto.NuloString(dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Nome].Value) != "")
            {
                Gravar(Guid.Parse(dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Id].Value.ToString()),
                       dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Nome].Value.ToString());
                //GridAtualizar();
            }
        }
        private void dataFabricante_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataFabricante.Rows.Count != 0)
            {
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GridFabricante_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Texto.Mensagem_Fabricante_Remover,
                                                     new string[] { e.Row.Cells[GridFabricante_Nome].Value.ToString() }))
                    {
                        Remover(Guid.Parse(e.Row.Cells[GridFabricante_Id].Value.ToString()));

                        GridAtualizar();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        #region Botoes
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
