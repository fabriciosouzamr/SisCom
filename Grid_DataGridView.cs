using Funcoes._Entity;
using Funcoes.Interfaces;
using System.Windows.Forms;

public static class Grid_DataGridView
{
    public enum TipoColuna
    {
        TextBox = 1,
        ComboBox = 2,
        CheckBox = 3,
        Button = 4
    }

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

        dataSource = null;
    }

    public static DataGridViewColumn DataGridView_ColunaCriar(DataGridView Grid,
                                                              string Nome,
                                                              string Titulo,
                                                              TipoColuna Tipo = TipoColuna.TextBox,
                                                              int Tamanho = 100,
                                                              int Caracteres = 0)
    {
        switch (Tipo)
        {
            case TipoColuna.TextBox:
                {
                    DataGridViewTextBoxColumn Coluna = new DataGridViewTextBoxColumn();

                    if (Caracteres != 0)
                    {
                        Coluna.MaxInputLength = Caracteres;
                    }
 
                    return Coluna;
                }
            case TipoColuna.ComboBox:
                {
                    DataGridViewComboBoxColumn Coluna = new DataGridViewComboBoxColumn();
                    return Coluna;
                }
            case TipoColuna.Button:
                {
                    DataGridViewButtonColumn Coluna = new DataGridViewButtonColumn();
                    return Coluna;
                }
            case TipoColuna.CheckBox:
                {
                    DataGridViewCheckBoxColumn Coluna = new DataGridViewCheckBoxColumn();
                    return Coluna;
                }
            default:
                {
                    return new DataGridViewColumn();
                }
        }
    }

    public static void DataGridView_ColunaAdicionar(DataGridView Grid,
                                                    string Nome,
                                                    string Titulo,
                                                    TipoColuna Tipo = TipoColuna.TextBox,
                                                    int Tamanho = 100,
                                                    int Caracteres = 0)
    {
        DataGridViewColumn Coluna = DataGridView_ColunaCriar(Grid, Nome, Titulo, Tipo, Tamanho, Caracteres);

        Coluna.Name = Nome;
        Coluna.HeaderText = Titulo;

        Grid.Columns.Add(Coluna);

        if (Tamanho == 0)
        { Grid.Columns[Grid.Columns.Count - 1].Visible = false; }
        else
        { Grid.Columns[Grid.Columns.Count - 1].Width = Tamanho; }

        Grid.Columns[Grid.Columns.Count - 1].DataPropertyName = Nome;
    }

    public static void DataGridView_Carregar(DataGridView Grid, IRepository<Entity> Repository)
    {
        Grid.DataSource = Repository.GetAll();
    }
}
