using Funcoes._Enum;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Context
{
    public class MeuDbContext : DbContext
    {
        private readonly string _connectionString;

        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }

        public MeuDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Almoxarifado> Almoxarifados { get; set; }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<TabelaCFOP> TabelaCFOPs { get; set; }
        public DbSet<TabelaCNAE> TabelaCNAEs { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<GrupoMercadoria> GrupoMercadorias { get; set; }
        public DbSet<GrupoCFOP> GrupoCFOPs { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Similar> Similars { get; set; }
        public DbSet<SubGrupoMercadoria> SubGrupoMercadorias { get; set; }
        public DbSet<TabelaANP> TabelaANPs { get; set; }
        public DbSet<TabelaBeneficioSPED> TabelaBeneficioSPEDs { get; set; }
        public DbSet<TabelaCST_IPI> TabelaCST_IPIs { get; set; }
        public DbSet<TabelaCST_PIS_COFINS> TabelaCSTPIS_PASEP_COFINSs { get; set; }
        public DbSet<TabelaSituacaoTributariaNFCe> TabelaSituacaoTributariaNFCes { get; set; }
        public DbSet<TipoMercadoria> TipoMercadorias { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<VinculoFiscal> VinculoFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()))
            {
                if (property.ClrType == typeof(string))
                    property.SetColumnType("varchar(100)");
                else if (property.ClrType == typeof(float) || property.ClrType == typeof(double) || property.ClrType == typeof(decimal))
                    property.SetDefaultValue(0);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MercadoriaSimilares>()
            //    .HasOne(bc => bc.Mercadoria)
            //    .WithMany(b => b.MercadoriaSimilares)
            //    .HasForeignKey(bc => bc.MercadoriaId);
            //modelBuilder.Entity<MercadoriaSimilares>()
            //    .HasOne(bc => bc.Mercadoria)
            //    .WithMany(b => b.MercadoriaSimilares)
            //    .HasForeignKey(bc => bc.MercadoriaSimilarId);

            Guid PaisId = Guid.NewGuid();

            #region Indices
            modelBuilder
                .Entity<Pessoa>()
                .HasIndex(p => new { p.CNPJ_CPF })
                .HasDatabaseName("idx_pessoas_CNPJ_CPF")
                .HasFillFactor(80)
                .IsUnique();
            #endregion

            modelBuilder
                .Entity<Pais>()
                .HasData(new Pais { Nome = "Brasil", Id = PaisId });

            modelBuilder
                .Entity<Estado>()
                .HasData(new Estado { Nome = "Acre", Codigo = "AC", PaisId = PaisId },
                         new Estado { Nome = "Alagoas", Codigo = "AL", PaisId = PaisId },
                         new Estado { Nome = "Amapá", Codigo = "AP", PaisId = PaisId },
                         new Estado { Nome = "Amazonas", Codigo = "AM", PaisId = PaisId },
                         new Estado { Nome = "Bahia", Codigo = "BA", PaisId = PaisId },
                         new Estado { Nome = "Ceará", Codigo = "CE", PaisId = PaisId },
                         new Estado { Nome = "Distrito Federal", Codigo = "DF", PaisId = PaisId },
                         new Estado { Nome = "Espirito Santo", Codigo = "ES", PaisId = PaisId },
                         new Estado { Nome = "Goias", Codigo = "GO", PaisId = PaisId },
                         new Estado { Nome = "Maranhão", Codigo = "MA", PaisId = PaisId },
                         new Estado { Nome = "Mato Grosso do Sul", Codigo = "MS", PaisId = PaisId },
                         new Estado { Nome = "Mato Grosso", Codigo = "MT", PaisId = PaisId },
                         new Estado { Nome = "Minas Gerais", Codigo = "MG", PaisId = PaisId },
                         new Estado { Nome = "Pará", Codigo = "PA", PaisId = PaisId },
                         new Estado { Nome = "Paraíba", Codigo = "PB", PaisId = PaisId },
                         new Estado { Nome = "Paraná", Codigo = "PR", PaisId = PaisId },
                         new Estado { Nome = "Pernambuco", Codigo = "PE", PaisId = PaisId },
                         new Estado { Nome = "Piauí", Codigo = "PI", PaisId = PaisId },
                         new Estado { Nome = "Rio de Janeiro", Codigo = "RJ", PaisId = PaisId },
                         new Estado { Nome = "Rio Grande do Norte", Codigo = "RN", PaisId = PaisId },
                         new Estado { Nome = "Rio Grande do Sul", Codigo = "RS", PaisId = PaisId },
                         new Estado { Nome = "Rondônia", Codigo = "RO", PaisId = PaisId },
                         new Estado { Nome = "Roraima", Codigo = "RR", PaisId = PaisId },
                         new Estado { Nome = "Santa Catarina", Codigo = "SC", PaisId = PaisId },
                         new Estado { Nome = "São Paulo", Codigo = "SP", PaisId = PaisId },
                         new Estado { Nome = "Sergipe", Codigo = "SE", PaisId = PaisId },
                         new Estado { Nome = "Exterior", Codigo = "EX", PaisId = PaisId });

            modelBuilder
                .Entity<GrupoCFOP>()
                .HasData(new GrupoCFOP { Nome = "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaDentroEstado },
                         new GrupoCFOP { Nome = "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaForaEstado },
                         new GrupoCFOP { Nome = "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaExterior },
                         new GrupoCFOP { Nome = "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaDentroEstado },
                         new GrupoCFOP { Nome = "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaForaEstado },
                         new GrupoCFOP { Nome = "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaExterior });

            modelBuilder
                .Entity<TabelaCST_IPI>()
                .HasData(new TabelaCST_IPI { Codigo = "00", Descricao = "Entrada com Recuperação de Crédito", EntradaSaida = EntradaSaida.Entrada, DestacarIPI = true },
                         new TabelaCST_IPI { Codigo = "01", Descricao = "Entrada Tributável com Alíquota Zero", EntradaSaida = EntradaSaida.Entrada },
                         new TabelaCST_IPI { Codigo = "02", Descricao = "Entrada Isenta", EntradaSaida = EntradaSaida.Entrada },
                         new TabelaCST_IPI { Codigo = "03", Descricao = "Entrada Não-Tributada", EntradaSaida = EntradaSaida.Entrada },
                         new TabelaCST_IPI { Codigo = "04", Descricao = "Entrada Imune", EntradaSaida = EntradaSaida.Entrada },
                         new TabelaCST_IPI { Codigo = "05", Descricao = "Entrada com Suspensão", EntradaSaida = EntradaSaida.Entrada },
                         new TabelaCST_IPI { Codigo = "49", Descricao = "Outras Entradas", EntradaSaida = EntradaSaida.Entrada, DestacarIPI = true },
                         new TabelaCST_IPI { Codigo = "50", Descricao = "Saída Tributada", EntradaSaida = EntradaSaida.Saida, DestacarIPI = true },
                         new TabelaCST_IPI { Codigo = "51", Descricao = "Saída Tributável com Alíquota Zero", EntradaSaida = EntradaSaida.Saida },
                         new TabelaCST_IPI { Codigo = "52", Descricao = "Saída Isenta", EntradaSaida = EntradaSaida.Saida },
                         new TabelaCST_IPI { Codigo = "53", Descricao = "Saída Não-Tributada", EntradaSaida = EntradaSaida.Saida },
                         new TabelaCST_IPI { Codigo = "54", Descricao = "Saída Imune", EntradaSaida = EntradaSaida.Saida },
                         new TabelaCST_IPI { Codigo = "55", Descricao = "Saída com Suspensão", EntradaSaida = EntradaSaida.Saida },
                         new TabelaCST_IPI { Codigo = "99", Descricao = "Outras Saídas", EntradaSaida = EntradaSaida.Saida, DestacarIPI = true });

            modelBuilder
                .Entity<TabelaCST_PIS_COFINS>()
                .HasData(new TabelaCST_PIS_COFINS { Codigo = "01", Descricao = "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", UsaNaSaida = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "02", Descricao = "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", UsaNaSaida = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "03", Descricao = "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", UsaNaSaida = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "04", Descricao = "Operação Tributável (tributação monofásica (alíquota zero))", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "05", Descricao = "Operação Tributável por Substituição Tributária", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "06", Descricao = "Operação Tributável (alíquota zero)", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "07", Descricao = "Operação Isenta da Contribuição", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "08", Descricao = "Operação Sem Incidência da Contribuição", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "09", Descricao = "Operação com Suspensão da Contribuição", UsaNaSaida = true },
                         new TabelaCST_PIS_COFINS { Codigo = "49", Descricao = "Outras Operações de Saída", UsaNaSaida = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "50", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "51", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "52", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "53", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "54", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "55", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "56", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "60", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "61", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "62", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "63", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "64", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "65", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "66", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "67", Descricao = "Crédito Presumido -Outras Operações", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "70", Descricao = "Operação de Aquisição sem Direito a Crédito", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "71", Descricao = "Operação de Aquisição com Isenção", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "72", Descricao = "Operação de Aquisição com Suspensão", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "73", Descricao = "Operação de Aquisição a Alíquota Zero", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "74", Descricao = "Operação de Aquisição sem Incidência da Contribuição", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "75", Descricao = "Operação de Aquisição por Substituição Tributária", UsaNaEntrada = true },
                         new TabelaCST_PIS_COFINS { Codigo = "98", Descricao = "Outras Operações de Entrada", UsaNaEntrada = true, DestacarPIS_COFINS = true },
                         new TabelaCST_PIS_COFINS { Codigo = "99", Descricao = "Outras Operações", UsaNaEntrada = true, UsaNaSaida = true, DestacarPIS_COFINS = true });

            modelBuilder
                .Entity<TipoMercadoria>()
                .HasData(new TipoMercadoria { Nome = "VEÍCULO" },
                         new TipoMercadoria { Nome = "COMBUSTÍVEL" },
                         new TipoMercadoria { Nome = "MEDICAMENTO" },
                         new TipoMercadoria { Nome = "ARMAMENTO" });

            modelBuilder
                .Entity<TabelaSituacaoTributariaNFCe>()
                .HasData(new TabelaSituacaoTributariaNFCe { Descricao = "Normal(% TRIBUTADO)", Codigo = "01" },
                         new TabelaSituacaoTributariaNFCe { Descricao = "Substituição", Codigo = "FF" },
                         new TabelaSituacaoTributariaNFCe { Descricao = "Isento", Codigo = "II" },
                         new TabelaSituacaoTributariaNFCe { Descricao = "Não Incidente", Codigo = "NN" });

            modelBuilder
                .Entity<UnidadeMedida>()
                .HasData(new UnidadeMedida { Nome = "Unidade", Codigo = "UND" },
                         new UnidadeMedida { Nome = "Caixa", Codigo = "CXA" },
                         new UnidadeMedida { Nome = "Peca", Codigo = "PCA" },
                         new UnidadeMedida { Nome = "Metro", Codigo = "MTR" },
                         new UnidadeMedida { Nome = "Kilograma", Codigo = "KG" },
                         new UnidadeMedida { Nome = "Litro ", Codigo = "LTR" },
                         new UnidadeMedida { Nome = "Pacote", Codigo = "PCT" },
                         new UnidadeMedida { Nome = "Saco", Codigo = "SCO" },
                         new UnidadeMedida { Nome = "Frasco", Codigo = "FRC" },
                         new UnidadeMedida { Nome = "Grama", Codigo = "GR" },
                         new UnidadeMedida { Nome = "Fardo", Codigo = "FRD" });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UltimaAtualizacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("UltimaAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UltimaAtualizacao").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
