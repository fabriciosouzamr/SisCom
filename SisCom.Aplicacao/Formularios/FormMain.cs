using Funcoes.Interfaces;
using Microsoft.EntityFrameworkCore;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public class FormMain : Form
    {
        public readonly IServiceScopeFactory<MeuDbContext> _dbCtxFactory;
        public readonly IServiceProvider _serviceProvider;
        public readonly INotifier _notifier;

        IServiceScope<MeuDbContext> scope;

        public FormMain(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier)
        {
            this._dbCtxFactory = dbCtxFactory;
            this._serviceProvider = serviceProvider;
            this._notifier = notifier;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            return this._serviceProvider;
        }

        public IServiceScopeFactory<MeuDbContext> dbCtxFactory()
        {
            return this._dbCtxFactory;
        }
    }
}
