using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmRelatorios : FormMain
    {
        public frmRelatorios(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            CarregarCombos();
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoConfirmar_Click(object sender, EventArgs e)
        {
            frmRelatorioVisualizar form = new frmRelatorioVisualizar();

            if (radioRelatorio_NotaFiscalEntrada.Checked)
            {
                form.tipoRelatorio = TipoRelatorio.NotaFiscalEntrada;
            }
            else if (radioRelatorio_NotaFiscalSaida.Checked)
            {
                form.tipoRelatorio = TipoRelatorio.NotaFiscalSaida;
            }

            form.param = new string[] { Funcao.NuloParaString(comboEmpresa.SelectedValue),
                                        Funcao.NuloParaString(comboCliente.SelectedValue),
                                        Funcao.NuloParaString(comboCFOP.SelectedValue),
                                        Funcao.NuloParaString(comboPessoa.SelectedValue),
                                        dateDataInicial.Text,
                                        dateDataFinal.Text,
                                        comboEmpresa.Text,
                                        comboCliente.Text,
                                        comboCFOP.Text,
                                        comboPessoa.Text};
            form.Show();
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            dateDataInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateDataFinal.Value = dateDataInicial.Value.AddMonths(1).AddDays(-1);
        }

        async Task CarregarCombos()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboEmpresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));
                Combo_ComboBox.Formatar(comboCFOP,
                                        "Id", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new NaturezaOperacaoController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
                Combo_ComboBox.Formatar(comboCliente,
                                        "Id", "RazaoSocial",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboRazaoSocial(p => p.RazaoSocial));
                Combo_ComboBox.Formatar(comboPessoa,
                                        "Id", "RazaoSocial",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboRazaoSocial(p => p.RazaoSocial, w => w.Fornecedor));
            }

        }
    }
}
