﻿using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using System;
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
    }
}
