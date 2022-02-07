using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Configuration;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao
{
    namespace VStyles
    {

        static class Program
        {
            public static IConfiguration Configuration { get; }

            private static void ConfigureServices(ServiceCollection services)
            {
                services.AddLogging(configure => configure.AddConsole());

                services.AddDbContext<MeuDbContext>(options =>
                {
                    options.UseSqlServer(SisCom.Aplicacao.Properties.Resources.DefaultConnection);
                });

                services.AddEntityFrameworkSqlServer()
                   .AddDbContext<MeuDbContext>(options =>
                      options.UseSqlServer(SisCom.Aplicacao.Properties.Resources.DefaultConnection));

                services.AddScoped(c => Configuration);

                //services.AddAutoMapper
                services.AddIdentityConfig(Configuration);
                services.AddAppConfig();
                //services.AddAutoMapper(typeof(AutomapperConfig));
                services.AddLoggingConfig(Configuration);
                services.ResolveDependencies();

                services.AddScoped<frmMDI>();
            }

            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var services = new ServiceCollection();

                ConfigureServices(services);

                Declaracoes.dbContext = new MeuDbContext(SisCom.Aplicacao.Properties.Resources.DefaultConnection);

                Declaracoes.configuration = new MapperConfiguration(cfg =>
                {
                    #region Cidade
                    cfg.CreateMap<CidadeViewModel, Cidade>().ReverseMap();
                    cfg.CreateMap<Cidade, CidadeComboViewModel>();
                    #endregion
                    #region Estado
                    cfg.CreateMap<EstadoViewModel, Estado>().ReverseMap();
                    #endregion
                    #region Grupo
                    cfg.CreateMap<GrupoMercadoriaViewModel, GrupoMercadoria>().ReverseMap();
                    cfg.CreateMap<GrupoMercadoriaComboViewModel, GrupoMercadoria>().ReverseMap();
                    #endregion
                    #region Pais
                    cfg.CreateMap<PaisViewModel, Pais>().ReverseMap();
                    #endregion
                    #region Pessoa
                    cfg.CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
                    cfg.CreateMap<PessoaComboViewModel, Pessoa>().ReverseMap();
                    #endregion
                    #region SubGrupo
                    cfg.CreateMap<SubGrupoMercadoriaViewModel, SubGrupoMercadoria>().ReverseMap();
                    cfg.CreateMap<SubGrupoMercadoriaComboViewModel, SubGrupoMercadoria>().ReverseMap();
                    #endregion
                    #region UnidadeMedida
                    cfg.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>().ReverseMap();
                    #endregion
                    #region VinculoFiscal
                    cfg.CreateMap<VinculoFiscalViewModel, VinculoFiscal>().ReverseMap();
                    #endregion
                });
                Declaracoes.mapper = new Mapper(Declaracoes.configuration);

                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {
                    var frmMDI = serviceProvider.GetRequiredService<frmMDI>();
                    Application.Run(frmMDI);
                }
            }
        }
    }

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
    {
        MeuDbContext IDesignTimeDbContextFactory<MeuDbContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MeuDbContext>();
            var connectionString = SisCom.Aplicacao.Properties.Resources.DefaultConnection;

            builder.UseSqlServer(connectionString);

            return new MeuDbContext(builder.Options);
        }
    }
}