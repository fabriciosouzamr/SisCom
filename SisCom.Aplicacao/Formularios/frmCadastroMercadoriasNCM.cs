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
    public partial class frmCadastroMercadoriasNCM : Form
    {
        public frmCadastroMercadoriasNCM()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            Grid_DataGridView.User_Formatar(gridNCM);
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "CodigoNCM", "Código NCM");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "DescricaoNCM", "Descrição NCM");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "GrupoNCM", "Grupo NCM");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Grupo", "Grupo", Grid_DataGridView.TipoColuna.ComboBox);
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Subgrupo", "Subgrupo", Grid_DataGridView.TipoColuna.ComboBox);
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Federal", "Federal");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Importado", "Importado");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Municipal", "Municipal");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Municipal", "Municipal");
            Grid_DataGridView.User_ColunaAdicionar(gridNCM, "Atualizar", "Atualizar", Grid_DataGridView.TipoColuna.Button);
        }

        private void botaoFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
