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
    public partial class frmCadastroMercadoriasCST : Form
    {
        public frmCadastroMercadoriasCST()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            Grid_DataGridView.User_Formatar(gridNCM);
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Descricao", "Descrição");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "CST", "CST");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "CSTEquivalente", "CST Equivalente", Grid_DataGridView.TipoColuna.ComboBox);
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
