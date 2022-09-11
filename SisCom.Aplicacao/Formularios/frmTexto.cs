using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmTexto : Form
    {
        public string Texto 
        {   get
            {
                return richTexto.Text;
            }
            set
            {
                richTexto.Text = value;
            }
        }

        public frmTexto()
        {
            InitializeComponent();

            richTexto.Text = Texto;
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
