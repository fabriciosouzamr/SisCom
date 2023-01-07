using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SisCom.Aplicacao
{
    public partial class frmMDI : FormMain
    {
        public frmMDI(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }
        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.Text = Declaracoes.Aplicacao_Nome + " - Versão " + Application.ProductVersion.ToString();

            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Declaracoes.Aplicacao_AlturaTela = this.Height;
            Declaracoes.Aplicacao_LarguraTela = this.Width;
            toolUsuario.Text = Declaracoes.sistema_UsuarioLogado;
            toolScreen.Text = $"{Screen.PrimaryScreen.Bounds.Height}X{Screen.PrimaryScreen.Bounds.Width}";
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            FecharSistema();
        }
        private void FecharSistema()
        {
            Close();
        }
        private void cmdCadastro_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastro>();
            form.ShowDialog(this);
        }
        private void cmdCompras_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmComprasConsulta>();
            form.ShowDialog(this);
        }
        private void cmdVendas_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmVendasConsulta>();
            form.ShowDialog(this);
        }
        private void botaoNota_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_NotaFiscal>();
            form.ShowDialog(this);
        }

        private void cmdMDFe_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_MDFe_Consulta>();
            form.ShowDialog(this);
        }
    }
}