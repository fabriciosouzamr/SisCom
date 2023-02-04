using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grid_DataGridView;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroCondutor : FormMain
    {
        const int GridCondutor_Id = 0;
        const int GridCondutor_CPF_CNPJ = 1;
        const int GridCondutor_Nome = 2;

        public bool Cadastrado = false;

        List<string> condutorRemover = new List<string>();

        public frmCadastroCondutor(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        private async void Inicializar()
        {
            Grid_DataGridView.User_Formatar(dataCondutor, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.User_ColunaAdicionar(dataCondutor, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataCondutor, "CNPJ_CPF", "C.P.F./C.N.P.J.", TipoColuna.Texto, 150, 14, readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(dataCondutor, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres, readOnly: false);

            await GridAtualizar();
        }
        private async Task GridAtualizar()
        {
            using (CondutorController condutorController = new CondutorController(this.MeuDbContext(), this._notifier))
            {
                object Data = await condutorController.ObterTodos(p => p.Nome);
                Grid_DataGridView.User_DataSource(dataCondutor, Data, true);
            }
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void botaoGravar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataCondutor.Rows)
            {
                if (row.Index < dataCondutor.RowCount - 1)
                {
                    if (Funcao.NuloString(row.Cells[GridCondutor_CPF_CNPJ].Value))
                    {
                        CaixaMensagem.Informacao("Informe o C.P.F./C.N.P.J. de todos os condutores");
                        return;
                    }
                    if (Funcao.NuloString(row.Cells[GridCondutor_Nome].Value))
                    {
                        CaixaMensagem.Informacao("Informe o nome de todos os condutores");
                        return;
                    }
                }
            }

            using (CondutorController condutorController = new CondutorController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in dataCondutor.Rows)
                {
                    if (!Funcao.NuloString(row.Cells[GridCondutor_Nome].Value))
                    {
                        CondutorViewModel condutor = new CondutorViewModel();

                        condutor.CNPJ_CPF = row.Cells[GridCondutor_CPF_CNPJ].Value.ToString();
                        condutor.Nome = row.Cells[GridCondutor_Nome].Value.ToString();

                        if (row.Cells[GridCondutor_Id].Value == null)
                        {
                            condutor.Id = Guid.NewGuid();
                            await condutorController.Adicionar(condutor);
                            Cadastrado = true;
                        }
                        else
                        {
                            condutor.Id = Guid.Parse(row.Cells[GridCondutor_Id].Value.ToString());
                            await condutorController.Atualizar(condutor);
                        }
                    }
                }

                foreach (string str in condutorRemover)
                {
                    await condutorController.Remover(Guid.Parse(str));
                }
            }

            CaixaMensagem.Informacao("Gravação Efetuada");
        }
        private void dataCondutor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataCondutor.Rows.Count != 0)
            {
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GridCondutor_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Classes.Texto.Mensagem_UnidadeMedida_Remover,
                                                      new string[] { e.Row.Cells[GridCondutor_Nome].Value.ToString() }))
                    { condutorRemover.Add(e.Row.Cells[GridCondutor_Id].Value.ToString()); }
                    else
                    { e.Cancel = true; }

                }
            }
        }
    }
}