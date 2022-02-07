using SisCom.Aplicacao.Classes;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.Text = Declaracoes.Aplicacao_Nome + " - Versão " + Application.ProductVersion.ToString();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            FecharSistema();
        }

        private void FecharSistema()
        {
            Close();
        }

        private void cmdCadastro_Click(object sender, EventArgs e)
        {
            frmCadastros Form = new frmCadastros();
            Form.Show();
        }
    }
}
