using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmVendasConsulta : FormMain
    {
        public frmVendasConsulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmVendasInclusao>();
            form.ShowDialog(this);
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
