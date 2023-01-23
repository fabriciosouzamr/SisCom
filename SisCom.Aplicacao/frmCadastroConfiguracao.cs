using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Formularios;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grid_DataGridView;

namespace SisCom.Aplicacao
{
    public partial class frmCadastroConfiguracao : FormMain
    {
        const int GridUnidadeMedica_Id = 0;
        const int GridUnidadeMedica_Codigo = 1;
        const int GridUnidadeMedica_Nome = 2;

        List<string> unidadeMedidaRemover = new List<string>();

        public frmCadastroConfiguracao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        private async void Inicializar()
        {
            Grid_DataGridView.User_Formatar(dataUnidadeMedida, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.User_ColunaAdicionar(dataUnidadeMedida, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataUnidadeMedida, "Codigo", "Código", TipoColuna.Texto, 100, 3, readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(dataUnidadeMedida, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres, readOnly: false);

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
        private async void botaoGravar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataUnidadeMedida.Rows)
            {
                if (row.Index < dataUnidadeMedida.RowCount - 1)
                {
                    if (Funcao.NuloString(row.Cells[GridUnidadeMedica_Codigo].Value))
                    {
                        CaixaMensagem.Informacao("Informe o código de todas as unidades de medida");
                        return;
                    }
                    if (Funcao.NuloString(row.Cells[GridUnidadeMedica_Nome].Value))
                    {
                        CaixaMensagem.Informacao("Informe o nome de todas as unidades de medida");
                        return;
                    }
                }
            }

            using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in dataUnidadeMedida.Rows)
                {
                    if (!Funcao.NuloString(row.Cells[GridUnidadeMedica_Nome].Value))
                    {
                        UnidadeMedidaViewModel unidadeMedida = new UnidadeMedidaViewModel();

                        unidadeMedida.Codigo = row.Cells[GridUnidadeMedica_Codigo].Value.ToString();
                        unidadeMedida.Nome = row.Cells[GridUnidadeMedica_Nome].Value.ToString();

                        if (row.Cells[GridUnidadeMedica_Id].Value == null)
                        {
                            unidadeMedida.Id = Guid.NewGuid();
                            await unidadeMedidaController.Adicionar(unidadeMedida);
                        }
                        else
                        {
                            unidadeMedida.Id = Guid.Parse(row.Cells[GridUnidadeMedica_Id].Value.ToString());
                            await unidadeMedidaController.Atualizar(unidadeMedida);
                        }
                    }
                }

                foreach (string str in unidadeMedidaRemover)
                {
                    await unidadeMedidaController.Remover(Guid.Parse(str));
                }
            }

            CaixaMensagem.Informacao("Gravação Efetuada");
        }
        private void dataUnidadeMedida_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataUnidadeMedida.Rows.Count != 0)
            {
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GridUnidadeMedica_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Classes.Texto.Mensagem_UnidadeMedida_Remover,
                                                      new string[] { e.Row.Cells[GridUnidadeMedica_Nome].Value.ToString() }))
                    { unidadeMedidaRemover.Add(e.Row.Cells[GridUnidadeMedica_Id].Value.ToString());  }
                    else
                    { e.Cancel = true; }

                }
            }
        }
    }
}