using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Configuration;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SisCom.Aplicacao
{
    namespace VStyles
    {
        static class Program
        {
            static AppSettings appSettings;
            private static string appSettingsPath;
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                try
                {
                    IConfigurationRoot configBuilder;
                    ILoggingBuilder loggingBuilder;

                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "appsettings.json");
                    Declaracoes.Externos_SisCom_Aplicacao_FW = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\SisCom.Aplicacao_FW\\", "SisCom.Aplicacao_FW.exe");

                    using (StreamReader file = File.OpenText(appSettingsPath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        appSettings = (AppSettings)serializer.Deserialize(file, typeof(AppSettings));
                    }

                    var host = Host.CreateDefaultBuilder()
                                    .ConfigureHostConfiguration(builder =>
                                    {
                                        builder.SetBasePath(Directory.GetCurrentDirectory());
                                        builder.AddJsonFile(appSettingsPath);
                                        builder.AddEnvironmentVariables();
                                        configBuilder = builder.Build();

                                        var rest = configBuilder.GetSection("ConnectionStrings")["DefaultConnection"];
                                        JsonSerializer serializer = new JsonSerializer();
                                    //appSettings = (AppSettings)serializer.Deserialize(rest, typeof(AppSettings));
                                })
                                    .ConfigureAppConfiguration((context, builder) =>
                                    {
                                    // Add other configuration files...
                                })
                                    .ConfigureServices((context, services) =>
                                    {
                                        ConfigureServices(context.Configuration, services);
                                    })
                                    .ConfigureLogging(logging =>
                                    {
                                        logging.ClearProviders();
                                        logging.AddConsole();
                                    })
                                    .Build();

                    SisCom.Aplicacao.Classes.Declaracoes.configuration = new MapperConfiguration(cfg =>
                    {
                        #region Cidade
                        cfg.CreateMap<CidadeViewModel, Cidade>().ReverseMap();
                        cfg.CreateMap<Cidade, CidadeComboViewModel>();
                        #endregion
                        #region Empresa
                        cfg.CreateMap<EmpresaViewModel, Empresa>().ReverseMap();
                        cfg.CreateMap<Empresa, EmpresaComboViewModel>();
                        cfg.CreateMap<Empresa, EmpresaNuvemFiscalComboViewModel>().
                            ForPath(Est => Est.Estado, Emp => Emp.MapFrom(src => src.Endereco.End_Cidade.Estado));
                        #endregion
                        #region Estado
                        cfg.CreateMap<EstadoViewModel, Estado>().ReverseMap();
                        cfg.CreateMap<Estado, CodigoNomeComboViewModel>();
                        #endregion
                        #region Fabricante
                        cfg.CreateMap<FabricanteViewModel, Fabricante>().ReverseMap();
                        cfg.CreateMap<Fabricante, NomeComboViewModel>();
                        #endregion
                        #region Funcionario
                        cfg.CreateMap<FuncionarioViewModel, Funcionario>().ReverseMap();
                        cfg.CreateMap<Funcionario, NomeComboViewModel>();
                        #endregion
                        #region Grupo
                        cfg.CreateMap<GrupoMercadoriaViewModel, GrupoMercadoria>().ReverseMap();
                        cfg.CreateMap<GrupoMercadoria, NomeComboViewModel>();
                        #endregion
                        #region GrupoNaturezaReceita_CTS_PIS_COFINS
                        cfg.CreateMap<GrupoNaturezaReceita_CTS_PIS_COFINSViewModel, GrupoNaturezaReceita_CTS_PIS_COFINS>().ReverseMap();
                        cfg.CreateMap<GrupoNaturezaReceita_CTS_PIS_COFINS, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region Mercadoria
                        cfg.CreateMap<MercadoriaViewModel, Mercadoria>().ReverseMap();
                        #endregion
                        #region NaturezaOperacao
                        cfg.CreateMap<NaturezaOperacaoViewModel, NaturezaOperacao>().ReverseMap();
                        cfg.CreateMap<NaturezaOperacao, NomeComboViewModel>();
                        #endregion
                        #region NotaFiscalEntrada
                        cfg.CreateMap<NotaFiscalEntradaViewModel, NotaFiscalEntrada>().ReverseMap();
                        #endregion
                        #region NotaFiscalEntradaFatura
                        cfg.CreateMap<NotaFiscalEntradaFaturaViewModel, NotaFiscalEntradaFatura>().ReverseMap();
                        #endregion
                        #region NotaFiscalEntradaMercadoria
                        cfg.CreateMap<NotaFiscalEntradaMercadoriaViewModel, NotaFiscalEntradaMercadoria>().ReverseMap();
                        #endregion
                        #region Pais
                        cfg.CreateMap<PaisViewModel, Pais>().ReverseMap();
                        #endregion
                        #region Pessoa
                        cfg.CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
                        cfg.CreateMap<Pessoa, PessoaComboNomeViewModel>();
                        cfg.CreateMap<Pessoa, PessoaComboRazaoViewModel>();
                        cfg.CreateMap<Pessoa, PessoaComboCodigoViewModel>();
                        cfg.CreateMap<Pessoa, PessoaComboCPFCNPJViewModel>();
                        cfg.CreateMap<Pessoa, PessoaComboTelefoneViewModel>();
                        #endregion
                        #region SubGrupo
                        cfg.CreateMap<SubGrupoMercadoriaViewModel, SubGrupoMercadoria>().ReverseMap();
                        cfg.CreateMap<SubGrupoMercadoria, SubGrupoMercadoriaComboViewModel>();
                        #endregion
                        #region TipoCliente
                        cfg.CreateMap<TipoClienteViewModel, TipoCliente>().ReverseMap();
                        cfg.CreateMap<TipoCliente, TipoClienteComboViewModel>();
                        #endregion
                        #region UnidadeMedida
                        cfg.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>().ReverseMap();
                        #endregion
                        #region TabelaANP
                        cfg.CreateMap<TabelaANPViewModel, TabelaANP>().ReverseMap();
                        cfg.CreateMap<TabelaANP, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaBeneficioSPED
                        cfg.CreateMap<TabelaBeneficioSPEDViewModel, TabelaBeneficioSPED>().ReverseMap();
                        cfg.CreateMap<TabelaBeneficioSPED, CodigoComboViewModel>();
                        #endregion
                        #region TabelaCEST
                        cfg.CreateMap<TabelaCESTViewModel, TabelaCEST>().ReverseMap();
                        cfg.CreateMap<TabelaCEST, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaClasseEnquadramentoIPI
                        cfg.CreateMap<TabelaClasseEnquadramentoIPIViewModel, TabelaClasseEnquadramentoIPI>().ReverseMap();
                        cfg.CreateMap<TabelaClasseEnquadramentoIPI, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaCodigoEnquadramentoIPI
                        cfg.CreateMap<TabelaCodigoEnquadramentoIPIViewModel, TabelaCodigoEnquadramentoIPI>().ReverseMap();
                        cfg.CreateMap<TabelaCodigoEnquadramentoIPI, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaCFOP
                        cfg.CreateMap<TabelaCFOPViewModel, TabelaCFOP>().ReverseMap();
                        cfg.CreateMap<TabelaCFOP, CodigoComboViewModel>();
                        #endregion
                        #region TabelaCST_CSOSN
                        cfg.CreateMap<TabelaCST_CSOSNViewModel, TabelaCST_CSOSN>().ReverseMap();
                        cfg.CreateMap<TabelaCST_CSOSN, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaCST_PIS_COFINS
                        cfg.CreateMap<TabelaCST_PIS_COFINSViewModel, TabelaCST_PIS_COFINS>().ReverseMap();
                        cfg.CreateMap<TabelaCST_PIS_COFINS, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaCST_IPI
                        cfg.CreateMap<TabelaCST_IPIViewModel, TabelaCST_IPI>().ReverseMap();
                        cfg.CreateMap<TabelaCST_IPI, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaModalidadeDeterminacaoBCICMS
                        cfg.CreateMap<TabelaModalidadeDeterminacaoBCICMSViewModel, TabelaModalidadeDeterminacaoBCICMS>().ReverseMap();
                        cfg.CreateMap<TabelaModalidadeDeterminacaoBCICMS, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaMotivoDesoneracaoICMS
                        cfg.CreateMap<TabelaMotivoDesoneracaoICMSViewModel, TabelaMotivoDesoneracaoICMS>().ReverseMap();
                        cfg.CreateMap<TabelaMotivoDesoneracaoICMS, DescricaoComboViewModel>();
                        #endregion
                        #region TabelaOrigemMercadoriaServico
                        cfg.CreateMap<TabelaOrigemMercadoriaServicoViewModel, TabelaOrigemMercadoriaServico>().ReverseMap();
                        cfg.CreateMap<TabelaOrigemMercadoriaServico, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaOrigemVenda
                        cfg.CreateMap<TabelaOrigemVendaViewModel, TabelaOrigemVenda>().ReverseMap();
                        cfg.CreateMap<TabelaOrigemVenda, DescricaoComboViewModel>();
                        #endregion
                        #region TabelaNCM
                        cfg.CreateMap<TabelaNCMViewModel, TabelaNCM>().ReverseMap();
                        cfg.CreateMap<TabelaNCM, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaSpedCodigoGenero
                        cfg.CreateMap<TabelaSpedCodigoGeneroViewModel, TabelaSpedCodigoGenero>().ReverseMap();
                        cfg.CreateMap<TabelaSpedCodigoGenero, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaSituacaoTributariaNFCe
                        cfg.CreateMap<TabelaSituacaoTributariaNFCeViewModel, TabelaSituacaoTributariaNFCe>().ReverseMap();
                        cfg.CreateMap<TabelaSituacaoTributariaNFCe, DescricaoComboViewModel>();
                        #endregion
                        #region TabelaSpedInformacaoAdicionalItem
                        cfg.CreateMap<TabelaSpedInformacaoAdicionalItemViewModel, TabelaSpedInformacaoAdicionalItem>().ReverseMap();
                        cfg.CreateMap<TabelaSpedInformacaoAdicionalItem, CodigoDescricaoComboViewModel>();
                        #endregion
                        #region TabelaSpedTipoItem
                        cfg.CreateMap<TabelaSpedTipoItemViewModel, TabelaSpedTipoItem>().ReverseMap();
                        cfg.CreateMap<TabelaSpedTipoItem, DescricaoComboViewModel>();
                        #endregion
                        #region Transportadora
                        cfg.CreateMap<TransportadoraViewModel, Transportadora>().ReverseMap();
                        cfg.CreateMap<Transportadora, NomeComboViewModel>();
                        #endregion
                        #region TipoMercadoria
                        cfg.CreateMap<TipoMercadoriaViewModel, TipoMercadoria>().ReverseMap();
                        cfg.CreateMap<TipoMercadoria, NomeComboViewModel>();
                        #endregion
                        #region TipoServicoFiscal
                        cfg.CreateMap<TipoServicoFiscalViewModel, TipoServicoFiscal>().ReverseMap();
                        cfg.CreateMap<UnidadeMedida, NomeComboViewModel>();
                        #endregion
                        #region UnidadeMedida
                        cfg.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>().ReverseMap();
                        cfg.CreateMap<UnidadeMedida, NomeComboViewModel>();
                        #endregion
                        #region UnidadeMedidaConversao
                        cfg.CreateMap<UnidadeMedidaConversaoViewModel, UnidadeMedidaConversao>().ReverseMap();
                        #endregion
                        #region Venda
                        cfg.CreateMap<VendaViewModel, Venda>().ReverseMap();
                        #endregion
                        #region VendaMercadoria
                        cfg.CreateMap<VendaMercadoriaViewModel, VendaMercadoria>().ReverseMap();
                        #endregion
                        #region VinculoFiscal
                        cfg.CreateMap<VinculoFiscalViewModel, VinculoFiscal>().ReverseMap();
                        cfg.CreateMap<VinculoFiscal, NomeComboViewModel>();
                        #endregion
                    });
                    SisCom.Aplicacao.Classes.Declaracoes.mapper = new Mapper(SisCom.Aplicacao.Classes.Declaracoes.configuration);

                    Diretorios_Verificar();

                    var services = host.Services;

                    DatabaseConfig_Configure(services);

                    if (!DatabaseConfig.BancoDadosConectavel(services, true))
                    {
                        CaixaMensagem.Informacao("Não foi possível conectar no banco de dados." + appSettings.ConnectionStrings.DefaultConnection);
                    }

                    var frmMDI = services.GetRequiredService<frmMDI>();
                    Application.Run(frmMDI);
                }
                catch (Exception Ex)
                {
                    CaixaMensagem.Informacao(Ex.Message);
                }
            }
            private static async void DatabaseConfig_Configure(IServiceProvider services)
            {
                var seedPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "Seed");
                await DatabaseConfig.Configure(services, seedPath);
            }
            private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
            {
                services.AddDbContext<MeuDbContext>(options =>
                {
                    options.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection);
                    options.LogTo(Console.WriteLine);
                }); ;
                services.ResolveDependencies();
            }
            private static void Diretorios_Verificar()
            {
                if (!Directory.Exists(Declaracoes.Aplicacao_CaminhoFoto))
                {
                    Directory.CreateDirectory(Declaracoes.Aplicacao_CaminhoFoto);
                }

                Declaracoes.Aplicacao_CaminhoDiretorioTemporaria = Path.Combine(Directory.GetCurrentDirectory(), "temp");
                Declaracoes.Externos_Path_Schemas = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\Schemas");
                Declaracoes.Externos_Path_NuvemFiscal = Path.Combine(Directory.GetCurrentDirectory(), "Externos\\NuvemFiscal");
                if (!Directory.Exists(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria)) { Directory.CreateDirectory(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria); }
                if (!Directory.Exists(Declaracoes.Externos_Path_Schemas)) { Directory.CreateDirectory(Declaracoes.Externos_Path_Schemas); }
                if (!Directory.Exists(Declaracoes.Externos_Path_NuvemFiscal)) { Directory.CreateDirectory(Declaracoes.Externos_Path_NuvemFiscal); }
            }
        }
        public class MeuDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
        {
            public MeuDbContext CreateDbContext(string[] args)
            {
                AppSettings appSettings;

                var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "appsettings.json");
                using (StreamReader file = File.OpenText(appSettingsPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    appSettings = (AppSettings)serializer.Deserialize(file, typeof(AppSettings));
                }

                var optionsBuilder = new DbContextOptionsBuilder<MeuDbContext>();
                optionsBuilder.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection);
                optionsBuilder.EnableSensitiveDataLogging(true);

                return new MeuDbContext(optionsBuilder.Options);
            }
        }
    }
}