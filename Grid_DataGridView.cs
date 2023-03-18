﻿using Funcoes._Classes;
using Funcoes._Entity;
using Funcoes.Interfaces;
using System;
using System.Globalization;
using System.Windows.Forms;

public static class Grid_DataGridView
{
    public enum TipoColuna
    {
        Texto = 1,
        ComboBox = 2,
        CheckBox = 3,
        Button = 4,
        Imagem = 5,
        Link = 6,
        Valor = 7,
        Numero = 8,
        Percentual = 9,
        Data = 10,
        Inteiro = 11,
        Numero6 = 12
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

    public static void User_Formatar(this DataGridView Grid,
                                     bool AllowUserToAddRows = false,
                                     bool AllowUserToDeleteRows = false)
    {
        Grid.AllowUserToAddRows = AllowUserToAddRows;
        Grid.AllowUserToDeleteRows = AllowUserToDeleteRows;
        Grid.Rows.Clear();
    }

    public static void User_DataSource(this DataGridView Grid, object dataSource, bool  allowNew)
    {
        BindingSource binding = new BindingSource();
        binding.DataSource = dataSource;
        binding.AllowNew = allowNew;

        Grid.AutoGenerateColumns = false;
        Grid.DataSource = binding;

        dataSource = null;
    }

    public static decimal User_CalcularColunaValor(this DataGridView Grid,
                                                   int IndiceColuna)
    {
        decimal Valor = 0;

        foreach (DataGridViewRow row in Grid.Rows)
        {
            Valor = Valor + Funcao.NuloParaValorD(row.Cells[IndiceColuna].Value);
        }

        return Valor;
    }

    public static double User_CalcularColuna(this DataGridView Grid, int IndiceColuna)
    {
        double Valor = 0;

        foreach (DataGridViewRow row in Grid.Rows)
        {
            Valor = Valor + Funcao.NuloParaValor(row.Cells[IndiceColuna].Value);
        }

        return Valor;
    }
    public static int User_QuantidadeLinha(this DataGridView Grid, int IndiceColuna)
    {
        int iQuantidade = 0;

        foreach (DataGridViewRow row in Grid.Rows)
        {
            if (row.Cells[IndiceColuna].Value != null)
            {
                iQuantidade++;
            }
        }

        return iQuantidade;
    }

    private static DataGridViewColumn User_ColunaCriar(this DataGridView Grid, string Nome, string Titulo, TipoColuna Tipo = TipoColuna.Texto, int Tamanho = 100, int Caracteres = 0, object dataSource = null,
                                                       string dataSource_Descricao = "", string dataSource_Valor = "", int dropDownWidth = 0)

    {
        switch (Tipo)
        {
            case TipoColuna.Texto:
                {
                    DataGridViewTextBoxColumn Coluna = new DataGridViewTextBoxColumn();

                    if (Caracteres != 0)
                    {
                        Coluna.MaxInputLength = Caracteres;
                    }

                    return Coluna;
                }
            case TipoColuna.Valor:
            case TipoColuna.Numero:
            case TipoColuna.Numero6:
            case TipoColuna.Data:
            case TipoColuna.Percentual:
                {
                    DataGridViewTextBoxColumn Coluna = new DataGridViewTextBoxColumn();

                    return Coluna;
                }
            case TipoColuna.ComboBox:
                {
                    DataGridViewComboBoxColumn Coluna = new DataGridViewComboBoxColumn();
                    Coluna.DataSource = dataSource;
                    Coluna.DisplayMember = dataSource_Descricao;
                    Coluna.ValueMember = dataSource_Valor;
                    if (dropDownWidth != 0) Coluna.DropDownWidth = dropDownWidth;
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
            case TipoColuna.Imagem:
                {
                    DataGridViewImageColumn Coluna = new DataGridViewImageColumn();
                    return Coluna;
                }
            case TipoColuna.Link:
                {
                    DataGridViewLinkColumn Coluna = new DataGridViewLinkColumn();
                    return Coluna;
                }
            default:
                {
                    return new DataGridViewColumn();
                }
        }
    }

    public static DataGridViewColumn User_ColunaAdicionar(DataGridView Grid, string Nome, string Titulo, TipoColuna Tipo = TipoColuna.Texto, int Tamanho = 100, int Caracteres = 0, object dataSource = null, string                                                                 dataSource_Descricao = "", string dataSource_Valor = "", bool readOnly = true, bool wordWrap = false, int dropDownWidth = 0,
                                                          DataGridViewContentAlignment alinhamento = DataGridViewContentAlignment.NotSet)
    {
        DataGridViewColumn Coluna = User_ColunaCriar(Grid,
                                                     Nome,
                                                     Titulo,
                                                     Tipo,
                                                     Tamanho,
                                                     Caracteres,
                                                     dataSource,
                                                     dataSource_Descricao,
                                                     dataSource_Valor, 
                                                     dropDownWidth);

        Coluna.Name = Nome;
        Coluna.HeaderText = Titulo;
        Coluna.ReadOnly = readOnly;
        Coluna.DefaultCellStyle.Alignment = alinhamento;

        switch (Tipo)
        {
            case TipoColuna.Valor:
                Coluna.DefaultCellStyle.Format = "C";
                Coluna.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
                Coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Coluna.ValueType = typeof(decimal);
                break;
            case TipoColuna.Numero:
            case TipoColuna.Percentual:
                Coluna.DefaultCellStyle.Format = "N2";
                Coluna.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
                Coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Coluna.ValueType = typeof(double);
                break;
            case TipoColuna.Numero6:
                Coluna.DefaultCellStyle.Format = "N6";
                Coluna.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");
                Coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Coluna.ValueType = typeof(double);
                break;
            case TipoColuna.Data:
                Coluna.ValueType = typeof(DateTime);
                break;
            case TipoColuna.Texto:
                if (wordWrap) Coluna.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                break;
            case TipoColuna.Inteiro:
                Coluna.ValueType = typeof(int);
                Coluna.DefaultCellStyle.Format = "N";
                break;
        }

        Grid.Columns.Add(Coluna);

        if (Tamanho == 0)
        { Grid.Columns[Grid.Columns.Count - 1].Visible = false; }
        else
        { Grid.Columns[Grid.Columns.Count - 1].Width = Tamanho; }

        Grid.Columns[Grid.Columns.Count - 1].DataPropertyName = Nome;

        return Coluna;
    }

    public static void User_CelularAlimentar(this DataGridView grid, int linha, int coluna, object valor)
    {
        grid.Rows[linha].Cells[coluna].Value = valor;
    }

    public static void User_LinhaLimpar(this DataGridView grid)
    {
        grid.Rows.Clear();
    }

    public static int User_Linhas(this DataGridView grid, int coluna)
    {
        int iCont = 0;

        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.Cells[coluna].Value != null)
                iCont++;
        }

        return iCont;
    }

    public static DataGridViewRow User_LinhaAdicionar(this DataGridView grid, Coluna[] valores)
    {
        if (grid.Columns.Count == 0)
            return new DataGridViewRow();

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

                User_CelularAlimentar(grid, linha, coluna.Indice, valor);
            }
        }

        return grid.Rows[linha];
    }

    public static void User_Carregar(this DataGridView Grid, IRepository<Entity> Repository)
    {
        Grid.DataSource = Repository.GetAll();
    }

    public static void User_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
        {
            e.Handled = true;
        }

        if (e.KeyChar == '.'
            && (sender as TextBox).Text.IndexOf('.') > -1)
        {
            e.Handled = true;
        }
    }
}