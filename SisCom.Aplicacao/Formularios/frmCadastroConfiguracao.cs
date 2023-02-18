using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Formularios;
using SisCom.Aplicacao.ViewModels;
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
        const int GridUnidadeMedida_Id = 0;
        const int GridUnidadeMedida_Codigo = 1;
        const int GriUnidadeMedida_Nome = 2;

        const int GridPais_Id = 0;
        const int GridPais_Nome = 1;

        List<string> unidadeMedidaRemover = new List<string>();
        List<string> paisRemover = new List<string>();

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

            Grid_DataGridView.User_Formatar(dataPais, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.User_ColunaAdicionar(dataPais, "ID", "ID", TipoColuna.Texto, 0);
            Grid_DataGridView.User_ColunaAdicionar(dataPais, "Nome", "Nome", TipoColuna.Texto, 400, Declaracoes.CampoNome_Caracteres, readOnly: false);

            await GridAtualizar();
        }
        private async Task GridAtualizar()
        {
            using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            {
                object Data = await unidadeMedidaController.ObterTodos(p => p.Nome);
                Grid_DataGridView.User_DataSource(dataUnidadeMedida, Data, true);
            }
            using (PaisController paisController = new PaisController(this.MeuDbContext(), this._notifier))
            {
                object Data = await paisController.ObterTodos(p => p.Nome);
                Grid_DataGridView.User_DataSource(dataPais, Data, true);
            }
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void botaoGravar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataPais.Rows)
            {
                if (row.Index < dataPais.RowCount - 1)
                {
                    if (Funcao.NuloString(row.Cells[GridPais_Nome].Value))
                    {
                        CaixaMensagem.Informacao("Informe o nome de todos os paises");
                        return;
                    }
                }
            }
            foreach (DataGridViewRow row in dataUnidadeMedida.Rows)
            {
                if (row.Index < dataUnidadeMedida.RowCount - 1)
                {
                    if (Funcao.NuloString(row.Cells[GridUnidadeMedida_Codigo].Value))
                    {
                        CaixaMensagem.Informacao("Informe o código de todas as unidades de medida");
                        return;
                    }
                    if (Funcao.NuloString(row.Cells[GriUnidadeMedida_Nome].Value))
                    {
                        CaixaMensagem.Informacao("Informe o nome de todas as unidades de medida");
                        return;
                    }
                }
            }

            using (PaisController paisController = new PaisController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in dataPais.Rows)
                {
                    if (!Funcao.NuloString(row.Cells[GridPais_Nome].Value))
                    {
                        PaisViewModel pais = new PaisViewModel();

                        pais.Nome = row.Cells[GridPais_Nome].Value.ToString();

                        if (row.Cells[GridPais_Id].Value == null)
                        {
                            pais.Id = Guid.NewGuid();
                            await paisController.Adicionar(pais);
                        }
                        else
                        {
                            pais.Id = Guid.Parse(row.Cells[GridPais_Id].Value.ToString());
                            await paisController.Atualizar(pais);
                        }
                    }
                }

                foreach (string str in unidadeMedidaRemover)
                {
                    await paisController.Remover(Guid.Parse(str));
                }
            }

            using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in dataUnidadeMedida.Rows)
                {
                    if (!Funcao.NuloString(row.Cells[GriUnidadeMedida_Nome].Value))
                    {
                        UnidadeMedidaViewModel unidadeMedida = new UnidadeMedidaViewModel();

                        unidadeMedida.Codigo = row.Cells[GridUnidadeMedida_Codigo].Value.ToString();
                        unidadeMedida.Nome = row.Cells[GriUnidadeMedida_Nome].Value.ToString();

                        if (row.Cells[GridUnidadeMedida_Id].Value == null)
                        {
                            unidadeMedida.Id = Guid.NewGuid();
                            await unidadeMedidaController.Adicionar(unidadeMedida);
                        }
                        else
                        {
                            unidadeMedida.Id = Guid.Parse(row.Cells[GridUnidadeMedida_Id].Value.ToString());
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
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GriUnidadeMedida_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Classes.Texto.Mensagem_UnidadeMedida_Remover,
                                                      new string[] { e.Row.Cells[GriUnidadeMedida_Nome].Value.ToString() }))
                    { unidadeMedidaRemover.Add(e.Row.Cells[GridUnidadeMedida_Id].Value.ToString());  }
                    else
                    { e.Cancel = true; }

                }
            }
        }
        private void dataPais_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataPais.Rows.Count != 0)
            {
                if (Funcoes._Classes.Texto.NuloString(e.Row.Cells[GridPais_Nome].Value) != "")
                {
                    if (CaixaMensagem.PerguntarTexto(Classes.Texto.Mensagem_Pais_Remover,
                                                      new string[] { e.Row.Cells[GridPais_Nome].Value.ToString() }))
                    { paisRemover.Add(e.Row.Cells[GridPais_Id].Value.ToString()); }
                    else
                    { e.Cancel = true; }

                }
            }
        }
    }
}