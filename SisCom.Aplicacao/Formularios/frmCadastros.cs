using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao
{
    public partial class frmCadastros : Form
    {
        public frmCadastros()
        {
            InitializeComponent();
        }

        private void cmdMercadorias_Click(object sender, EventArgs e)
        {
            frmCadastrosMercadorias Form = new frmCadastrosMercadorias();
            Form.Show();
        }
    }
}
