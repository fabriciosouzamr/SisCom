using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastro : Form
    {
        FormMain FormMain;

    public frmCadastro(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
    {
        InitializeComponent();
        FormMain = new FormMain(serviceProvider, dbCtxFactory);
    }

    private void cmdMercadorias_Click(object sender, EventArgs e)
    {
        var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroMercadorias>();
        form.ShowDialog(this);
    }

    private void frmCadastros_FormClosing(object sender, FormClosingEventArgs e)
    {
        FormMain.Dispose();
    }

    private void cmdClientes_Click(object sender, EventArgs e)
    {
        var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroClientes>();
        form.ShowDialog(this);
    }

    private void cmdFuncionarioPermissoes_Click(object sender, EventArgs e)
    {
        var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroFuncionarios>();
        form.ShowDialog(this);
    }

    private void cmdTransportadoras_Click(object sender, EventArgs e)
    {
        var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroTransportadoras>();
        form.ShowDialog(this);
    }

    private void cmdConfiguracoesGerais_Click(object sender, EventArgs e)
    {

    }

    private void cmdEmpresas_Click(object sender, EventArgs e)
    {
        var form = FormMain.ServiceProvider().GetRequiredService<frmCadastroEmpresas>();
        form.ShowDialog(this);
    }
}
}
