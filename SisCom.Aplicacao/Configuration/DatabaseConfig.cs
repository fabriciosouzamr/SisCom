using MeuProjeto.Infrastructure.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Configuration
{
    public static class  DatabaseConfig
    {
        public static bool BancoDadosConectavel(IServiceProvider _serviceProvider, bool criarautomatico)
        {
            bool conectavel = false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var meuDbContext = scope.ServiceProvider.GetRequiredService<MeuDbContext>();

                conectavel = meuDbContext.Database.CanConnect();

                if (!conectavel)
                {
                    try
                    {
                        meuDbContext.Database.EnsureCreated();
                        conectavel = true;
                    }
                    catch (Exception Ex)
                    {
                        CaixaMensagem.Informacao(Ex.Message);
                    }
                }
            }

            return conectavel;
        }

        public static async Task Configure(IServiceProvider _serviceProvider, string _seedPath = "")
        {
            try
            {
            if (string.IsNullOrEmpty(_seedPath))
            {
                _seedPath = String.Format(Application.ExecutablePath + "{0}Data{0}Seed{0}", Path.DirectorySeparatorChar);
            }

            CaixaMensagem.Informacao(_seedPath);
            
            using (var scope = _serviceProvider.CreateScope())
            {
                var meuDbContext = scope.ServiceProvider.GetRequiredService<MeuDbContext>();

                if (await meuDbContext.AllMigrationsApplied())
                {
                    await meuDbContext.EnsureSeeded(scope, _seedPath);
                }
            }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

        }
    }
}
