using SisCom.Aplicacao.Classes;
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
    public partial class frmFiscal_MDFe : Form
    {
        public frmFiscal_MDFe()
        {
            InitializeComponent();
            if (Declaracoes.Aplicacao_AlturaTela < this.Height)
                this.Height = Declaracoes.Aplicacao_AlturaTela;

            pnlCentral.Height = this.Height - pnlCentral.Top - 35;
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
