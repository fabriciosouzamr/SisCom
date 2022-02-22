using AutoMapper;
using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SisCom.Aplicacao.Configuration;
using SisCom.Aplicacao.Formularios;
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
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var host = Host.CreateDefaultBuilder()
                                .ConfigureAppConfiguration((context, builder) =>
                                {
                                    // Add other configuration files...
                                    builder.AddJsonFile("appsettings.json", optional: true);
                                })
                                .ConfigureServices((context, services) =>
                                {
                                    ConfigureServices(context.Configuration, services);
                                })
                                .ConfigureLogging(logging =>
                                {
                                    // Add other loggers...
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
                    #endregion
                    #region Estado
                    cfg.CreateMap<EstadoViewModel, Estado>().ReverseMap();
                    cfg.CreateMap<Estado, EstadoComboViewModel>();
                    cfg.CreateMap<Estado, EstadoCodigoComboViewModel>();
                    #endregion
                    #region Fabricante
                    cfg.CreateMap<FabricanteViewModel, Fabricante>().ReverseMap();
                    #endregion
                    #region Grupo
                    cfg.CreateMap<GrupoMercadoriaViewModel, GrupoMercadoria>().ReverseMap();
                    cfg.CreateMap<GrupoMercadoria, GrupoMercadoriaComboViewModel>();
                    #endregion
                    #region Pais
                    cfg.CreateMap<PaisViewModel, Pais>().ReverseMap();
                    #endregion
                    #region Pessoa
                    cfg.CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
                    cfg.CreateMap<Pessoa, PessoaComboViewModel>();
                    #endregion
                    #region SubGrupo
                    cfg.CreateMap<SubGrupoMercadoriaViewModel, SubGrupoMercadoria>().ReverseMap();
                    cfg.CreateMap<SubGrupoMercadoria, SubGrupoMercadoriaComboViewModel>();
                    #endregion
                    #region UnidadeMedida
                    cfg.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>().ReverseMap();
                    #endregion
                    #region VinculoFiscal
                    cfg.CreateMap<VinculoFiscalViewModel, VinculoFiscal>().ReverseMap();
                    #endregion
                });
                SisCom.Aplicacao.Classes.Declaracoes.mapper = new Mapper(SisCom.Aplicacao.Classes.Declaracoes.configuration);

                var services = host.Services;
                var frmMDI = services.GetRequiredService<frmMDI>();
                Application.Run(frmMDI);
            }

            private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
            {
                services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
                services.AddDbContext<MeuDbContext>(options =>
                {
                    options.UseSqlServer(SisCom.Aplicacao.Properties.Resources.DefaultConnection);
                });
                //services.AddEntityFrameworkSqlServer()
                //    .AddDbContext<MeuDbContext>(options => options.UseSqlServer(SisCom.Aplicacao.Properties.Resources.DefaultConnection));
                services.AddSingleton(typeof(IServiceScopeFactory<>), typeof(ServiceScopeFactory<>));
                services.AddScoped<MeuDbContext, MeuDbContext>();
                services.AddSingleton<frmMDI>();
                services.AddTransient<frmCadastro>();
                services.AddTransient<frmCadastroFabricante>();
                services.AddTransient<frmCadastroMercadorias>();
                services.AddTransient<frmCadastroMercadoriasVinculoFiscal>();
                services.AddTransient<frmCadastroMercadoriasNCM>();
                services.AddTransient<frmCadastroMercadoriasCST>();
                services.AddTransient<frmCadastroClientes>();
                services.AddTransient<frmCadastroFuncionarios>();
                services.AddTransient<frmCadastroTransportadoras>();
                services.AddTransient<frmCadastroEmpresas>();
                services.ResolveDependencies();
            }
        }

        public class MeuDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
        {
            public MeuDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MeuDbContext>();
                optionsBuilder.UseSqlServer(SisCom.Aplicacao.Properties.Resources.DefaultConnection);

                return new MeuDbContext(optionsBuilder.Options);
            }
        }
    }
}