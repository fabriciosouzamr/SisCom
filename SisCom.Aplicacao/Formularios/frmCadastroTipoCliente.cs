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
    public partial class frmCadastroTipoCliente : FormMain
    {
        public event EventHandler GravacaoEfetuada;

        const int GridTipoCliente_Id = 0;
        const int GridTipoCliente_Nome = 1;

        public frmCadastroTipoCliente(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        private async void Inicializar()
        {
            Grid_DataGridView.User_Formatar(dataTipoCliente);
            Grid_DataGridView.User_ColunaAdicionar(dataTipoCliente, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataTipoCliente, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres);
            GridAtualizar();
        }

        private async Task GridAtualizar()
        {
            TipoClienteController TipoClienteController = new TipoClienteController(this.MeuDbContext(), this._notifier);
            object Data = await TipoClienteController.ObterTodos(p => p.Nome);
            Grid_DataGridView.User_DataSource(dataTipoCliente, Data, true);
            TipoClienteController = null;
            this.MeuDbContextDispose();
        }
        private async Task Gravar(Guid Id, string Nome)
        {
            try
            {
                TipoClienteViewModel TipoCliente = new TipoClienteViewModel();
                TipoClienteController TipoClienteController = new TipoClienteController(this.MeuDbContext(), this._notifier);
                TipoCliente.Nome = Nome;
                TipoCliente.Id = Id;

                if (TipoCliente.Id != Guid.Empty)
                {
                    await TipoClienteController.Atualizar(TipoCliente.Id, TipoCliente);
                }
                else
                {
                    await TipoClienteController.Adicionar(TipoCliente);
                }

                TipoClienteController = null;
                this.MeuDbContextDispose();

                GravacaoEfetuada.Invoke(this, EventArgs.Empty);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private async void Remover(Guid Id)
        {
            TipoClienteController TipoClienteController = new TipoClienteController(this.MeuDbContext(), this._notifier);
            await TipoClienteController.Remover(Id);
            this.MeuDbContextDispose();
        }
        #endregion

        private void dataTipoCliente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Funcoes._Classes.Texto.NuloString(dataTipoCliente.Rows[e.RowIndex].Cells[GridTipoCliente_Nome].Value) != "")
            {
                Gravar(Guid.Parse(dataTipoCliente.Rows[e.RowIndex].Cells[GridTipoCliente_Id].Value.ToString()),
                       dataTipoCliente.Rows[e.RowIndex].Cells[GridTipoCliente_Nome].Value.ToString());
                //GridAtualizar();
            }
        }
        private void dataTipoCliente_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataTipoCliente.Rows.Count != 0)
            {
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GridTipoCliente_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Texto.Mensagem_TipoCliente_Remover,
                                                     new string[] { e.Row.Cells[GridTipoCliente_Nome].Value.ToString() }))
                    {
                        Remover(Guid.Parse(e.Row.Cells[GridTipoCliente_Id].Value.ToString()));

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
