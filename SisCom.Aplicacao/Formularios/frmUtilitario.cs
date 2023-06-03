using SisCom.Aplicacao.Classes;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmUtilitario : Form
    {
        public frmUtilitario()
        {
            InitializeComponent();
        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            
        }

        private void botaoNuvemFiscalDiretorioXMLs_Click(object sender, EventArgs e)
        {
            textImportarCliente_MDB.Text = Arquivo.CarregarArquivoMSAccess();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoImportarCliente_Processar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textImportarCliente_MDB.Text) && (File.Exists(textImportarCliente_MDB.Text)))
            {
                string stringConexao = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                        "Data Source=" + textImportarCliente_MDB.Text + ";" +
                                        "Mode=Share Deny None;";

                System.Data.OleDb.OleDbConnection db = new OleDbConnection(stringConexao);
                db.Open();

                try
                {
                    // Acessa o banco de dados e carrega os dados
                    string consulta = "SELECT [Cadastro de Clientes].[Razão Social], [Cadastro de Clientes].[Nome do Cliente], [Cadastro de Clientes].Endereço, [Cadastro de Clientes].Bairro, dbo_Cidades.Id, [Cadastro de Clientes].[Fone Resid]," +
                                             "[Cadastro de Clientes].Datanasc, [Cadastro de Clientes].CEP, [Cadastro de Clientes].CGC, [Cadastro de Clientes].[Inscrição Estadual], [Cadastro de Clientes].[Ponto de Referência], [Cadastro de Clientes].RG," +
                                             "[Cadastro de Clientes].Num, [Cadastro de Clientes].indIEDest, iif([Cadastro de Clientes].RegimeTributario = 0,null,[Cadastro de Clientes].RegimeTributario) AS RegimeTributario, [Cadastro de Clientes].Pessoa FROM dbo_Cidades";
                    using (OleDbConnection conn = new OleDbConnection(stringConexao))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, conn))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Senha Inválida...");
                    Close();
                }

                db.Close();
                db.Dispose();

                //INSERT INTO dbo_Pessoas(Id, RazaoSocial, Nome, End_Logradouro, End_Bairro, End_CidadeId, Telefone, DataNascimento, End_CEP, CNPJ_CPF, InscricaoEstadual, End_Complemento, RG, End_Numero, TipoContribuinte, RegimeTributario, TipoPessoa)
            }
            else
            {
                MessageBox.Show("Selecione um arquivo de banco de dados válido!");
            }
        }
    }
}
