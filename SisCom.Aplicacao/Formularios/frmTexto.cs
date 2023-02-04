using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmTexto : Form
    {
        public bool Gravar
        {
            get
            {
                return botaoGravar.Visible;
            }
            set
            {
                botaoGravar.Visible = value;
                richTexto.ReadOnly = (!value);
                richTexto.Enabled = value;
            }
        }
        public int MinimoCaracteres { get; set; }
        public bool Gravou { get; private set; }
        public bool Fechou { get; private set; }

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
            Fechou = true;
            Close();
        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTexto.Text))
            {
                CaixaMensagem.Informacao("É preciso informar o comentário do cancelamento");
                return;
            }
            if (richTexto.Text.Length < MinimoCaracteres)
            {
                CaixaMensagem.Informacao($"É preciso informar um mínimo de {MinimoCaracteres} caracteres");
                return;
            }

            Gravou = true;

            Close();
        }
    }
}
