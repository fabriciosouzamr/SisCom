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
    public partial class frmCadastroFabricante : Form
    {
        FormMain FormMain;

        public event EventHandler GravacaoEfetuada;

        const int GridFabricante_Id = 0;
        const int GridFabricante_Nome = 1;

        public frmCadastroFabricante(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            InitializeComponent();
            FormMain = new FormMain(serviceProvider, dbCtxFactory);

            Inicializar();
        }

        private async void Inicializar()
        {
            Grid_DataGridView.DataGridView_Formatar(dataFabricante);
            Grid_DataGridView.DataGridView_ColunaAdicionar(dataFabricante, "ID", "ID", 0);
            Grid_DataGridView.DataGridView_ColunaAdicionar(dataFabricante, "Nome", "Nome", TipoColuna.TextBox, 400, Declaracoes.CampoNome_Caracteres);
            GridAtualizar();
        }

        private async Task GridAtualizar()
        {
            FabricanteController fabricanteController = new FabricanteController(FormMain.MeuDbContext());
            object Data = await fabricanteController.ObterTodos(p => p.Nome);
            Grid_DataGridView.DataGridView_DataSource(dataFabricante, Data, true);
            fabricanteController = null;
            FormMain.MeuDbContextDispose();
        }

        private async Task Gravar(Guid Id, string Nome)
        {
            try
            {
                FabricanteViewModel fabricante = new FabricanteViewModel();
                FabricanteController fabricanteController = new FabricanteController(FormMain.MeuDbContext());
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
                FormMain.MeuDbContextDispose();

                GravacaoEfetuada.Invoke(this, EventArgs.Empty);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }

        private async void Remover(Guid Id)
        {
            FabricanteController fabricanteController = new FabricanteController(FormMain.MeuDbContext());
            await fabricanteController.Remover(Id);
            FormMain.MeuDbContextDispose();
        }

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

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCadastrosFabricante_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.Dispose();
        }
    }
}
