using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmComprasInclusao : FormMain
    {
        public frmComprasInclusao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoImportarNFeXML_Click(object sender, System.EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_ImportarXML>();
            form.ShowDialog(this);
        }

        private void botaoNuvemFiscal_Click(object sender, System.EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_NuvemFiscal>();
            form.ShowDialog(this);
        }

        private void botaoFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
