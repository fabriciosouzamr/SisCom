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
                        //meuDbContext.Database.EnsureCreated();
                        conectavel = true;
                    }
                    catch (Exception Ex)
                    {
                        CaixaMensagem.Informacao("BancoDadosConectavel", Ex);
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
                    _seedPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "Seed");
                }

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
                CaixaMensagem.Informacao("Database configure" + Ex);
            }
        }
    }
}
