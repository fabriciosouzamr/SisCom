using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastro : FormMain
    {
        public frmCadastro(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
        }
        private void cmdMercadorias_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroMercadorias>();
            form.ShowDialog(this);
        }
        private void cmdClientes_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroClientes>();
            form.ShowDialog(this);
        }
        private void cmdFuncionarioPermissoes_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroFuncionarios>();
            form.ShowDialog(this);
        }
        private void cmdTransportadoras_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroTransportadoras>();
            form.Show(this);
        }
        private void cmdConfiguracoesGerais_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroConfiguracao>();
            form.ShowDialog(this);
        }
        private void cmdEmpresas_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroEmpresas>();
            form.ShowDialog(this);
        }
    }
}
