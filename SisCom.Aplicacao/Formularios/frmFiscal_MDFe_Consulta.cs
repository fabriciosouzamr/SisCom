using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_MDFe_Consulta : FormMain
    {
        public frmFiscal_MDFe_Consulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {

        }

        private void botaoEditar_Click(object sender, EventArgs e)
        {

        }

        private void botaoTransmitir_Click(object sender, EventArgs e)
        {

        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {

        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_MDFe>();
            form.ShowDialog(this);
        }
    }
}
