using Funcoes.Classes;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using System;
using System.Data;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastrosFabricante : Form
    {
        //fabricanteController; //= new FabricanteController();

        //const int GridFabricante_Id = 0;
        //const int GridFabricante_Nome = 1;

        //public frmCadastrosFabricante()
        //{
        //    InitializeComponent();

        //    Inicializar();
        //}

        //private async void Inicializar()
        //{
        //    Grid_DataGridView.DataGridView_Formatar(dataFabricante);
        //    Grid_DataGridView.DataGridView_ColunaAdicionar(dataFabricante, "ID", "ID");
        //    Grid_DataGridView.DataGridView_ColunaAdicionar(dataFabricante, "Nome", "Nome", 400, Declaracoes.CampoNome_Caracteres);
        //    GridAtualizar();
        //}

        //private async void GridAtualizar()
        //{
        //    object Data = await fabricanteController.ObterTodos();
        //    Grid_DataGridView.DataGridView_DataSource(dataFabricante, Data, true);
        //    Data = null;
        //}

        //private async void Gravar(Guid Id, string Nome)
        //{
        //    FabricanteViewModel fabricante = new FabricanteViewModel();

        //    fabricante.Nome = Nome;
        //    fabricante.Id = Id;

        //    if (fabricante.Id != Guid.Empty)
        //    {
        //        await fabricanteController.Atualizar(fabricante.Id, fabricante);
        //    }
        //    else
        //    {
        //        await fabricanteController.Adicionar(fabricante);
        //    }

        //    fabricante = null;
        //}

        //private async void Remover(Guid Id)
        //{
        //    await fabricanteController.Remover(Id);
        //}

        //private void botaoFechar_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}

        //private void dataFabricante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (Funcoes.Texto.NuloString(dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Nome].Value) != "")
        //    {
        //        Gravar(Guid.Parse(dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Id].Value.ToString()),
        //               dataFabricante.Rows[e.RowIndex].Cells[GridFabricante_Nome].Value.ToString());
        //        // GridAtualizar();
        //    }
        //}

        //private void dataFabricante_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    if (dataFabricante.Rows.Count != 0)
        //    {
        //        if (Funcoes.Texto.NuloString(e.Row.Cells[GridFabricante_Nome].Value) != "")
        //        {
        //            if (CaixaMensagem.PerguntarTexto(Texto.Mensagem_Fabricante_Remover,
        //                                             new string[] { e.Row.Cells[GridFabricante_Nome].Value.ToString() }))
        //            {
        //                Remover(Guid.Parse(e.Row.Cells[GridFabricante_Id].Value.ToString()));

        //                //GridAtualizar();
        //            }
        //            else
        //            {
        //                e.Cancel = true;
        //            }
        //        }
        //    }
        //}
    }
}
