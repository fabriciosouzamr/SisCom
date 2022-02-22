using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using Funcoes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public class FormMain : Form
    {
        private readonly IServiceScopeFactory<MeuDbContext> _dbCtxFactory;
        private readonly IServiceProvider serviceProvider;

        IServiceScope<MeuDbContext> scope;

        public FormMain(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            this._dbCtxFactory = dbCtxFactory;
            this.serviceProvider = serviceProvider;
        }

        public MeuDbContext MeuDbContext()
        {
            scope = _dbCtxFactory.CreateScope();

            MeuDbContext MeuDbContext = scope.GetRequiredService();

            if (MeuDbContext.Database.GetDbConnection().State == System.Data.ConnectionState.Closed)
                MeuDbContext.Database.OpenConnection();

            return MeuDbContext;
        }

        public void MeuDbContextDispose()
        {
            scope.Dispose();
        }

        public IServiceProvider ServiceProvider()
        {
            return serviceProvider;
        }
    }
}
