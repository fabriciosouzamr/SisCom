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
            bool ret = false;

            try
            {
                //var applied = context.GetService<IHistoryRepository>()
                //    .GetAppliedMigrations()
                //    .Select(m => m.MigrationId);

                //var total = context.GetService<IMigrationsAssembly>()
                //    .Migrations
                //    .Select(m => m.Key);

                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }

                ret = true;
            }
            catch (Exception Ex)
            {
                var ex = Ex.Message;
            }

            return ret;
        }

        public static async Task EnsureSeeded(this MeuDbContext context, IServiceScope scope, string _seedPath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(_seedPath))
                {
                    _seedPath = seedPath;
                }

                await SeedScripts(context, _seedPath);
                if (!context.Paises.Any()) AddRangeSync<Pais>(context, _seedPath);
                if (!context.Estados.Any()) AddRangeSync<Estado>(context, _seedPath);
                if (!context.Funcionarios.Any()) AddRangeSync<Funcionario>(context, _seedPath);
                if (!context.GrupoCFOPs.Any()) AddRangeSync<GrupoCFOP>(context, _seedPath);
                if (!context.NotaFiscalFinalidades.Any()) AddRangeSync<NotaFiscalFinalidade>(context, _seedPath);
                if (!context.SubGrupoNaturezaReceita_CTS_PIS_COFINSs.Any()) AddRangeSync<SubGrupoNaturezaReceita_CTS_PIS_COFINS>(context, _seedPath);
                if (!context.TipoClientes.Any()) AddRangeSync<TipoCliente>(context, _seedPath);
                if (!context.TipoMercadorias.Any()) AddRangeSync<TipoMercadoria>(context, _seedPath);
                if (!context.UnidadeMedidas.Any()) AddRangeSync<UnidadeMedida>(context, _seedPath);
                if (!context.TabelaCFOPs.Any()) AddRangeSync<TabelaCFOP>(context, _seedPath);
                if (!context.TabelaNCMs.Any()) AddRangeSync<TabelaNCM>(context, _seedPath);
                if (!context.TabelaCST_IPIs.Any()) AddRangeSync<TabelaCST_IPI>(context, _seedPath);
                if (!context.TabelaCST_PIS_COFINSs.Any()) AddRangeSync<TabelaCST_PIS_COFINS>(context, _seedPath);
                if (!context.GrupoNaturezaReceita_CTS_PIS_COFINSs.Any()) AddRangeSync<GrupoNaturezaReceita_CTS_PIS_COFINS>(context, _seedPath);
                if (!context.TabelaClasseEnquadramentoIPIs.Any()) AddRangeSync<TabelaClasseEnquadramentoIPI>(context, _seedPath);
                if (!context.TabelaCodigoEnquadramentoIPIs.Any()) AddRangeSync<TabelaCodigoEnquadramentoIPI>(context, _seedPath);
                if (!context.TabelaCESTs.Any()) AddRangeSync<TabelaCEST>(context, _seedPath);
                if (!context.TabelaModalidadeDeterminacaoBCICMSs.Any()) AddRangeSync<TabelaModalidadeDeterminacaoBCICMS>(context, _seedPath);
                if (!context.TabelaOrigemMercadoriaServicos.Any()) AddRangeSync<TabelaOrigemMercadoriaServico>(context, _seedPath);
                if (!context.TabelaOrigemVendas.Any()) AddRangeSync<TabelaOrigemVenda>(context, _seedPath);
                if (!context.TabelaSituacaoTributariaNFCes.Any()) AddRangeSync<TabelaSituacaoTributariaNFCe>(context, _seedPath);
                if (!context.TabelaSpedCodigoGeneros.Any()) AddRangeSync<TabelaSpedCodigoGenero>(context, _seedPath);
                if (!context.TabelaSpedInformacaoAdicionalItems.Any()) AddRangeSync<TabelaSpedInformacaoAdicionalItem>(context, _seedPath);
                if (!context.TabelaSpedTipoItems.Any()) AddRangeSync<TabelaSpedTipoItem>(context, _seedPath);
                if (!context.TabelaANPs.Any()) AddRangeSync<TabelaANP>(context, _seedPath);
                if (!context.TabelaBeneficioSPEDs.Any()) AddRangeSync<TabelaBeneficioSPED>(context, _seedPath);
                if (!context.TabelaCST_CSOSNs.Any()) AddRangeSync<TabelaCST_CSOSN>(context, _seedPath);
                if (!context.TabelaMotivoDesoneracaoICMSs.Any()) AddRangeSync<TabelaMotivoDesoneracaoICMS>(context, _seedPath);
                if (!context.UnidadeMedidaConversoes.Any()) AddRangeSync<UnidadeMedidaConversao>(context, _seedPath);
                if (!context.NaturezaOperacoes.Any()) AddRangeSync<NaturezaOperacao>(context, _seedPath);

                await context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                _seedPath = seedPath;
            }
        }

        private static async Task SeedScripts(MeuDbContext context, string _seedPath = "")
        {
            var directory = _seedPath;
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
                var path = Path.Combine(_seedPath, typeof(TEntity).Name + ".json");

                var items = await ReadFromJson<TEntity>(path);
                items = items.Where(u => !db.AsNoTracking().Any(m => m.Id == u.Id)).ToList();

                if (items.Count > 0)
                {
                    await db.AddRangeAsync(items);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                var ex = Ex.Message;
            }
        }
        private static void AddRangeSync<TEntity>(MeuDbContext context, string _seedPath = "") where TEntity : Entity
        {
            try
            {
                var db = context.Set<TEntity>();
                var path = Path.Combine(_seedPath, typeof(TEntity).Name + ".json");

                var items = ReadFromJsonSync<TEntity>(path);
                items = items.Where(u => !db.AsNoTracking().Any(m => m.Id == u.Id)).ToList();

                if (items.Count > 0)
                {
                    db.AddRangeAsync(items);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                var ex = Ex.Message;
            }
        }

        private static async Task<List<TEntity>> ReadFromJson<TEntity>(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<TEntity>>(await File.ReadAllTextAsync(path));
            }
            catch (Exception Ex)
            {
                var ex = Ex.Message;
                return null;
            }
        }

        private static List<TEntity> ReadFromJsonSync<TEntity>(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<TEntity>>(File.ReadAllText(path));
            }
            catch (Exception Ex)
            {
                var ex = Ex.Message;
                return null;
            }
        }
    }
}
