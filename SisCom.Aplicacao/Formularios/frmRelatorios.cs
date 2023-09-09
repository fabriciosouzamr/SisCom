using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmRelatorios : Form
    {
        public frmRelatorios()
        {
            InitializeComponent();
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoConfirmar_Click(object sender, EventArgs e)
        {
            frmRelatorioVisualizar form = new frmRelatorioVisualizar();
            form.tipoRelatorio = TipoRelatorio.NotaFiscalEntrada;
            form.Show();
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            dateDataInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateDataFinal.Value = dateDataInicial.Value.AddMonths(1).AddDays(-1);
        }
    }
}
