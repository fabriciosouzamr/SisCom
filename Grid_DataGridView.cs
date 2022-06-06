using Funcoes._Entity;
using Funcoes.Interfaces;
using System;
using System.Globalization;
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

    public enum FormatoColuna
    {
        NaoDefinido = 1,
        Texto = 2,
        Data = 3,
        Numero = 4,
        Valor = 5,
        ValorFormatado = 6,
        Porcentagem = 7
    }

    public class Coluna
    {
        public int Indice;
        public object Valor;
        public FormatoColuna Formato;
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

    private static DataGridViewColumn DataGridView_ColunaCriar(DataGridView Grid,
                                                               string Nome,
                                                               string Titulo,
                                                               TipoColuna Tipo = TipoColuna.TextBox,
                                                               int Tamanho = 100,
                                                               int Caracteres = 0,
                                                               object dataSource = null,
                                                               string dataSource_Descricao = "",
                                                               string dataSource_Valor = "")
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
                    Coluna.DataSource = dataSource;
                    Coluna.DisplayMember = dataSource_Descricao;
                    Coluna.ValueMember = dataSource_Valor;
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
                                                    int Caracteres = 0,
                                                    object dataSource = null,
                                                    string dataSource_Descricao = "",
                                                    string dataSource_Valor = "")
    {
        DataGridViewColumn Coluna = DataGridView_ColunaCriar(Grid,
                                                             Nome,
                                                             Titulo,
                                                             Tipo,
                                                             Tamanho,
                                                             Caracteres,
                                                             dataSource,
                                                             dataSource_Descricao,
                                                             dataSource_Valor);

        Coluna.Name = Nome;
        Coluna.HeaderText = Titulo;

        Grid.Columns.Add(Coluna);

        if (Tamanho == 0)
        { Grid.Columns[Grid.Columns.Count - 1].Visible = false; }
        else
        { Grid.Columns[Grid.Columns.Count - 1].Width = Tamanho; }

        Grid.Columns[Grid.Columns.Count - 1].DataPropertyName = Nome;
    }

    public static void DataGridView_CelularAlimentar(DataGridView grid, int linha, int coluna, object valor)
    {
        grid.Rows[linha].Cells[coluna].Value = valor;
    }

    public static void DataGridView_LinhaLimpar(DataGridView grid)
    {
        grid.Rows.Clear();
    }

    public static void DataGridView_LinhaAdicionar(DataGridView grid, Coluna[] valores)
    {
        int linha = grid.Rows.Add();

        if (valores != null)
        {
            object valor;

            foreach (Coluna coluna in valores)
            {
                valor = null;

                switch (coluna.Formato)
                {
                    case FormatoColuna.Numero:
                    case FormatoColuna.Valor:
                        if (coluna.Valor.GetType() == typeof(int))
                        { valor = coluna.Valor; }
                        else 
                        { valor = Math.Round((decimal)coluna.Valor, 4); }
                        
                        break;
                    case FormatoColuna.ValorFormatado:
                        if (coluna.Valor.GetType() == typeof(int))
                        { valor = ((int)coluna.Valor).ToString("C3", CultureInfo.CurrentCulture); }
                        else
                        { valor = ((decimal)coluna.Valor).ToString("C3", CultureInfo.CurrentCulture); }
                            
                        break;
                    default:
                        valor = coluna.Valor;
                        break;
                }

                DataGridView_CelularAlimentar(grid, linha, coluna.Indice, valor);
            }
        }
    }

    public static void DataGridView_Carregar(DataGridView Grid, IRepository<Entity> Repository)
    {
        Grid.DataSource = Repository.GetAll();
    }
}
