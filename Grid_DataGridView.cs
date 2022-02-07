using Funcoes.Classes;
using Funcoes.Interfaces;
using System;
using System.Windows.Forms;

public static class Grid_DataGridView
{
    public static void DataGridView_Formatar(DataGridView Grid)
    {
        Grid.AllowUserToAddRows = true;
    }

    public static void DataGridView_DataSource(DataGridView Grid, object dataSource, bool  allowNew)
    {
        BindingSource binding = new BindingSource();
        binding.DataSource = dataSource;
        binding.AllowNew = allowNew;

        Grid.AutoGenerateColumns = false;
        Grid.DataSource = binding;
    }

    public static void DataGridView_ColunaAdicionar(DataGridView Grid,
                                                    string Nome,
                                                    string Titulo,
                                                    int Tamanho = 100,
                                                    int Caracteres = 0)
    {
        Grid.Columns.Add(Nome, Titulo);

        if (Tamanho == 0)
        { Grid.Columns[Grid.Columns.Count - 1].Visible = false; }
        else
        { Grid.Columns[Grid.Columns.Count - 1].Width = Tamanho; }

        Grid.Columns[Grid.Columns.Count - 1].DataPropertyName = Nome;

        if (Caracteres != 0)
        {
            ((DataGridViewTextBoxColumn)Grid.Columns[Grid.Columns.Count - 1]).MaxInputLength = Caracteres;
        }
    }

    public static void DataGridView_Carregar(DataGridView Grid, IRepository<Entity> Repository)
    {
        Grid.DataSource = Repository.GetAll();
    }
}
