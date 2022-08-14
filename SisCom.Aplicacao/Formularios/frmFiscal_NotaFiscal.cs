using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NotaFiscal : FormMain
    {
        public Guid VendaId;

        public frmFiscal_NotaFiscal(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_Transmitir>();
            form.ShowDialog(this);
        }
    }
}
