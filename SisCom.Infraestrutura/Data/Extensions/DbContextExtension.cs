using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Funcoes._Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;

namespace MeuProjeto.Infrastructure.Data.Extensions
{
    public static class DbContextExtension
    {
        private const string seedPath = "..{0}SisCom.Infrastructure{0}Data{0}Seed{0}";

        public static async Task<bool> AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            if (context.Database.GetPendingMigrations().Count() > 0)
            {
                context.Database.Migrate();
            }

            return !total.Except(applied).Any();
        }

        public static async Task EnsureSeeded(this MeuDbContext context, IServiceScope scope, string _seedPath = "")
        {
            if (string.IsNullOrEmpty(_seedPath))
            {
                _seedPath = seedPath;
            }

            await SeedScripts(context, _seedPath);
            await AddRange<Pais>(context, _seedPath);
            await AddRange<Estado>(context, _seedPath);
            await AddRange<Funcionario>(context, _seedPath);
            await AddRange<GrupoCFOP>(context, _seedPath);
            await AddRange<TabelaBeneficioSPED>(context, _seedPath);
            await AddRange<TabelaCFOP>(context, _seedPath);
            await AddRange<TabelaCST_IPI>(context, _seedPath);
            await AddRange<TabelaCST_PIS_COFINS>(context, _seedPath);
            await AddRange<TabelaNCM>(context, _seedPath);
            await AddRange<TabelaSituacaoTributariaNFCe>(context, _seedPath);
            await AddRange<TipoCliente>(context, _seedPath);
            await AddRange<TipoMercadoria>(context, _seedPath);
            await AddRange<UnidadeMedida>(context, _seedPath);

            await context.SaveChangesAsync();
        }

        private static async Task SeedScripts(MeuDbContext context, string _seedPath = "")
        {
            var directory = String.Format(_seedPath + "Scripts", Path.DirectorySeparatorChar);
            foreach (var path in Directory.GetFiles(directory, "*.sql"))
            {
                var sql = await File.ReadAllTextAsync(path);
                var emptyparams = new SqlParameter[] { };
                await context.Database.ExecuteSqlRawAsync(sql, emptyparams);
            }
        }
        private static async Task AddRange<TEntity>(MeuDbContext context, string _seedPath = "") where TEntity : Entity
        {
            try
            {
                var db = context.Set<TEntity>();
                var path = _seedPath + typeof(TEntity).Name + ".json";
                path = String.Format(path, Path.DirectorySeparatorChar);

                var items = await ReadFromJson<TEntity>(path);
                items = items.Where(u => !db.AsNoTracking().Any(m => m.Id == u.Id)).ToList();

                if (items.Count > 0)
                {
                    await db.AddRangeAsync(items);
                }
            }
            catch (Exception Ex)
            {
            }
        }

        private static async Task<List<TEntity>> ReadFromJson<TEntity>(string path)
        {
            return JsonConvert.DeserializeObject<List<TEntity>>(await File.ReadAllTextAsync(path));
        }
    }
}
