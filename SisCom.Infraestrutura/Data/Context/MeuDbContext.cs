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
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        public DbSet<Almoxarifado> Almoxarifados { get; set; }
        public DbSet<Condutor> Condutores { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<TabelaCNAE> TabelaCNAEs { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<EstoqueUnidadeMedidaConversao> EstoqueUnidadeMedidaConversaos { get; set; }
        public DbSet<EstoqueLancamento> EstoqueLancamentos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<GrupoMercadoria> GrupoMercadorias { get; set; }
        public DbSet<GrupoNaturezaReceita_CTS_PIS_COFINS> GrupoNaturezaReceita_CTS_PIS_COFINSs { get; set; }
        public DbSet<GrupoCFOP> GrupoCFOPs { get; set; }
        public DbSet<ManifestoEletronicoDocumento> ManifestoEletronicoDocumentos { get; set; }
        public DbSet<ManifestoEletronicoDocumentoNota> ManifestoEletronicoDocumentoNotas { get; set; }
        public DbSet<ManifestoEletronicoDocumentoPercurso> ManifestoEletronicoDocumentoPercursos { get; set; }
        public DbSet<ManifestoEletronicoDocumentoSerie> ManifestoEletronicoDocumentoSeries { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<MercadoriaComposicao> MercadoriaComposicaos { get; set; }
        public DbSet<MercadoriaImpostoEstado> MercadoriaImpostoEstados { get; set; }
        public DbSet<MercadoriaFornecedor> MercadoriaFornecedores { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<NaturezaOperacao> NaturezaOperacoes { get; set; }
        public DbSet<NotaFiscalEntradaFatura> NotaFiscalEntradaFaturas { get; set; }
        public DbSet<NotaFiscalEntradaMercadoria> NotaFiscalEntradaMercadorias { get; set; }
        public DbSet<NotaFiscalEntrada> NotaFiscalEntradas { get; set; }
        public DbSet<NotaFiscalFinalidade> NotaFiscalFinalidades { get; set; }
        public DbSet<NotaFiscalSaida> NotaFiscalSaidas { get; set; }
        public DbSet<NotaFiscalSaidaMercadoria> NotaFiscalSaidaMercadorias { get; set; }
        public DbSet<NotaFiscalSaidaObservacao> NotaFiscalSaidaObservacaos { get; set; }
        public DbSet<NotaFiscalSaidaPagamento> NotaFiscalSaidaPagamentos { get; set; }
        public DbSet<NotaFiscalSaidaSerie> NotaFiscalSaidaSeries { get; set; }
        public DbSet<NotaFiscalSaidaReferencia> NotaFiscalSaidaReferencias { get; set; }
        public DbSet<Observacao> Observacaos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Similar> Similars { get; set; }
        public DbSet<SubGrupoMercadoria> SubGrupoMercadorias { get; set; }
        public DbSet<SubGrupoNaturezaReceita_CTS_PIS_COFINS> SubGrupoNaturezaReceita_CTS_PIS_COFINSs { get; set; }
        public DbSet<TabelaANP> TabelaANPs { get; set; }
        public DbSet<TabelaBeneficioSPED> TabelaBeneficioSPEDs { get; set; }
        public DbSet<TabelaCEST> TabelaCESTs { get; set; }
        public DbSet<TabelaClasseEnquadramentoIPI> TabelaClasseEnquadramentoIPIs { get; set; }
        public DbSet<TabelaCodigoEnquadramentoIPI> TabelaCodigoEnquadramentoIPIs { get; set; }
        public DbSet<TabelaCFOP> TabelaCFOPs { get; set; }
        public DbSet<TabelaCST_CSOSN> TabelaCST_CSOSNs { get; set; }
        public DbSet<TabelaCST_IPI> TabelaCST_IPIs { get; set; }
        public DbSet<TabelaCST_PIS_COFINS> TabelaCST_PIS_COFINSs { get; set; }
        public DbSet<TabelaNCM> TabelaNCMs { get; set; }
        public DbSet<TabelaModalidadeDeterminacaoBCICMS> TabelaModalidadeDeterminacaoBCICMSs { get; set; }
        public DbSet<TabelaMotivoDesoneracaoICMS> TabelaMotivoDesoneracaoICMSs { get; set; }
        public DbSet<TabelaNaturezaReceita_CTS_PIS_COFINS> TabelaNaturezaReceita_CTS_PIS_COFINSs { get; set; }
        public DbSet<TabelaOrigemMercadoriaServico> TabelaOrigemMercadoriaServicos { get; set; }
        public DbSet<TabelaOrigemVenda> TabelaOrigemVendas { get; set; }
        public DbSet<TabelaSituacaoTributariaNFCe> TabelaSituacaoTributariaNFCes { get; set; }
        public DbSet<TabelaSpedCodigoGenero> TabelaSpedCodigoGeneros { get; set; }
        public DbSet<TabelaSpedInformacaoAdicionalItem> TabelaSpedInformacaoAdicionalItems { get; set; }
        public DbSet<TabelaSpedTipoItem> TabelaSpedTipoItems { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<TipoServicoFiscal> TipoServicoFiscais { get; set; }
        public DbSet<TipoMercadoria> TipoMercadorias { get; set; }
        public DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<UnidadeMedidaConversao> UnidadeMedidaConversoes { get; set; }
        public DbSet<VeiculoPlaca> VeiculoPlacas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaMercadoria> VendaMercadorias { get; set; }
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

            Function.RegistarFuncoes(modelBuilder);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MercadoriaSimilares>()
            //    .HasOne(bc => bc.Mercadoria)
            //    .WithMany(b => b.MercadoriaSimilares)
            //    .HasForeignKey(bc => bc.MercadoriaId);
            //modelBuilder.Entity<MercadoriaSimilares>()
            //    .HasOne(bc => bc.Mercadoria)
            //    .WithMany(b => b.MercadoriaSimilares)
            //    .HasForeignKey(bc => bc.MercadoriaSimilarId);

            //#region HasData
            //Guid PaisId = Guid.NewGuid();

            //modelBuilder
            //    .Entity<Pais>()
            //    .HasData(new Pais { Nome = "Brasil", Id = PaisId, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<Estado>()
            //    .HasData(new Estado { Nome = "Acre", Codigo = "AC", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Alagoas", Codigo = "AL", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Amapá", Codigo = "AP", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Amazonas", Codigo = "AM", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Bahia", Codigo = "BA", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Ceará", Codigo = "CE", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Distrito Federal", Codigo = "DF", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Espirito Santo", Codigo = "ES", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Goias", Codigo = "GO", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Maranhão", Codigo = "MA", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Mato Grosso do Sul", Codigo = "MS", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Mato Grosso", Codigo = "MT", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Minas Gerais", Codigo = "MG", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Pará", Codigo = "PA", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Paraíba", Codigo = "PB", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Paraná", Codigo = "PR", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Pernambuco", Codigo = "PE", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Piauí", Codigo = "PI", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Rio de Janeiro", Codigo = "RJ", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Rio Grande do Norte", Codigo = "RN", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Rio Grande do Sul", Codigo = "RS", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Rondônia", Codigo = "RO", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Roraima", Codigo = "RR", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Santa Catarina", Codigo = "SC", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "São Paulo", Codigo = "SP", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Sergipe", Codigo = "SE", PaisId = PaisId, UltimaAtualizacao = DateTime.Now },
            //             new Estado { Nome = "Exterior", Codigo = "EX", PaisId = PaisId, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<Funcionario>()
            //    .HasData(new Funcionario { Nome = "Administrador", Senha = "1234", AcessoFinanceiro = true, AcessoFiscal = true, Administrador = true, Desativado = true, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<GrupoCFOP>()
            //    .HasData(new GrupoCFOP { Nome = "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaDentroEstado, UltimaAtualizacao = DateTime.Now },
            //             new GrupoCFOP { Nome = "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaForaEstado, UltimaAtualizacao = DateTime.Now },
            //             new GrupoCFOP { Nome = "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", TipoOperacaoCFOP = TipoOperacaoCFOP.EntradaExterior, UltimaAtualizacao = DateTime.Now },
            //             new GrupoCFOP { Nome = "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaDentroEstado, UltimaAtualizacao = DateTime.Now },
            //             new GrupoCFOP { Nome = "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaForaEstado, UltimaAtualizacao = DateTime.Now },
            //             new GrupoCFOP { Nome = "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", TipoOperacaoCFOP = TipoOperacaoCFOP.SaidaExterior, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<TabelaCST_IPI>()
            //    .HasData(new TabelaCST_IPI { Codigo = "00", Descricao = "Entrada com Recuperação de Crédito", EntradaSaida = EntradaSaida.Entrada, DestacarIPI = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "01", Descricao = "Entrada Tributável com Alíquota Zero", EntradaSaida = EntradaSaida.Entrada, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "02", Descricao = "Entrada Isenta", EntradaSaida = EntradaSaida.Entrada, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "03", Descricao = "Entrada Não-Tributada", EntradaSaida = EntradaSaida.Entrada, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "04", Descricao = "Entrada Imune", EntradaSaida = EntradaSaida.Entrada, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "05", Descricao = "Entrada com Suspensão", EntradaSaida = EntradaSaida.Entrada, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "49", Descricao = "Outras Entradas", EntradaSaida = EntradaSaida.Entrada, DestacarIPI = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "50", Descricao = "Saída Tributada", EntradaSaida = EntradaSaida.Saida, DestacarIPI = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "51", Descricao = "Saída Tributável com Alíquota Zero", EntradaSaida = EntradaSaida.Saida, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "52", Descricao = "Saída Isenta", EntradaSaida = EntradaSaida.Saida, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "53", Descricao = "Saída Não-Tributada", EntradaSaida = EntradaSaida.Saida, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "54", Descricao = "Saída Imune", EntradaSaida = EntradaSaida.Saida, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "55", Descricao = "Saída com Suspensão", EntradaSaida = EntradaSaida.Saida, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_IPI { Codigo = "99", Descricao = "Outras Saídas", EntradaSaida = EntradaSaida.Saida, DestacarIPI = true, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<TabelaCST_PIS_COFINS>()
            //    .HasData(new TabelaCST_PIS_COFINS { Codigo = "01", Descricao = "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", UsaNaSaida = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "02", Descricao = "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", UsaNaSaida = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "03", Descricao = "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", UsaNaSaida = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "04", Descricao = "Operação Tributável (tributação monofásica (alíquota zero))", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "05", Descricao = "Operação Tributável por Substituição Tributária", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "06", Descricao = "Operação Tributável (alíquota zero)", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "07", Descricao = "Operação Isenta da Contribuição", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "08", Descricao = "Operação Sem Incidência da Contribuição", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "09", Descricao = "Operação com Suspensão da Contribuição", UsaNaSaida = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "49", Descricao = "Outras Operações de Saída", UsaNaSaida = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "50", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "51", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "52", Descricao = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "53", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "54", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "55", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "56", Descricao = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "60", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "61", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "62", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "63", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "64", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "65", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "66", Descricao = "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "67", Descricao = "Crédito Presumido -Outras Operações", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "70", Descricao = "Operação de Aquisição sem Direito a Crédito", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "71", Descricao = "Operação de Aquisição com Isenção", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "72", Descricao = "Operação de Aquisição com Suspensão", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "73", Descricao = "Operação de Aquisição a Alíquota Zero", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "74", Descricao = "Operação de Aquisição sem Incidência da Contribuição", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "75", Descricao = "Operação de Aquisição por Substituição Tributária", UsaNaEntrada = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "98", Descricao = "Outras Operações de Entrada", UsaNaEntrada = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now },
            //             new TabelaCST_PIS_COFINS { Codigo = "99", Descricao = "Outras Operações", UsaNaEntrada = true, UsaNaSaida = true, DestacarPIS_COFINS = true, UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<TabelaSituacaoTributariaNFCe>()
            //    .HasData(new TabelaSituacaoTributariaNFCe { Descricao = "Normal(% TRIBUTADO)", Codigo = "01", UltimaAtualizacao = DateTime.Now },
            //             new TabelaSituacaoTributariaNFCe { Descricao = "Substituição", Codigo = "FF", UltimaAtualizacao = DateTime.Now },
            //             new TabelaSituacaoTributariaNFCe { Descricao = "Isento", Codigo = "II", UltimaAtualizacao = DateTime.Now },
            //             new TabelaSituacaoTributariaNFCe { Descricao = "Não Incidente", Codigo = "NN", UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<TipoCliente>()
            //    .HasData(new TipoCliente { Nome = "CONSUMIDOR" });
            //modelBuilder
            //    .Entity<TipoMercadoria>()
            //    .HasData(new TipoMercadoria { Nome = "VEÍCULO", UltimaAtualizacao = DateTime.Now },
            //             new TipoMercadoria { Nome = "COMBUSTÍVEL", UltimaAtualizacao = DateTime.Now },
            //             new TipoMercadoria { Nome = "MEDICAMENTO", UltimaAtualizacao = DateTime.Now },
            //             new TipoMercadoria { Nome = "ARMAMENTO", UltimaAtualizacao = DateTime.Now });

            //modelBuilder
            //    .Entity<UnidadeMedida>()
            //    .HasData(new UnidadeMedida { Nome = "Unidade", Codigo = "UND", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Caixa", Codigo = "CXA", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Peca", Codigo = "PCA", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Metro", Codigo = "MTR", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Kilograma", Codigo = "KG", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Litro ", Codigo = "LTR", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Pacote", Codigo = "PCT", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Saco", Codigo = "SCO", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Frasco", Codigo = "FRC", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Grama", Codigo = "GR", UltimaAtualizacao = DateTime.Now },
            //             new UnidadeMedida { Nome = "Fardo", Codigo = "FRD", UltimaAtualizacao = DateTime.Now });
            //#endregion
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
        public override int SaveChanges()
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

            return base.SaveChanges();
        }
    }
}
