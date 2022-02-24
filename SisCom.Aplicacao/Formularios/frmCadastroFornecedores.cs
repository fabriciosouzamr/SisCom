using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroFornecedores : Form
    {
        private readonly DbContext MeuDbContext;
        public frmCadastroFornecedores(DbContext MeuDbContext)
        {
            InitializeComponent();

            this.MeuDbContext = MeuDbContext;

            if (MeuDbContext.Database.GetDbConnection().State == System.Data.ConnectionState.Closed)
                MeuDbContext.Database.OpenConnection();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
