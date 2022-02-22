using Microsoft.Extensions.DependencyInjection;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            #region Cidade
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();
            #endregion
            #region Estado
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            #endregion
            #region Estado
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEstadoService, EstadoService>();
            #endregion
            #region Fabricante
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            #endregion
            #region Grupo       
            services.AddScoped<IGrupoMercadoriaRepository, GrupoRepository>();
            services.AddScoped<IGrupoMercadoriaService, GrupoMercadoriaService>();
            #endregion
            #region Pais
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IPaisService, PaisService>();
            #endregion
            #region Pessoa
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            #endregion
            #region SubGrupo       
            services.AddScoped<ISubGrupoMercadoriaRepository, SubGrupoRepository>();
            services.AddScoped<ISubGrupoMercadoriaService, SubGrupoMercadoriaService>();
            #endregion
            #region UnidadeMedida
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
            #endregion
            #region VinculoFiscal
            services.AddScoped<IVinculoFiscalRepository, VinculoFiscalRepository>();
            services.AddScoped<IVinculoFiscalService, VinculoFiscalService>();
            #endregion
            //            services.AddScoped<IUserRepository, UserRepository>();
            //            services.AddScoped<IUserManualRepository, UserManualRepository>();
            //            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            //            services.AddScoped<IPermissionRepository, PermissionRepository>();
            //            services.AddScoped<INotifier, Notifier>();
            //            services.AddScoped<ICustomLogger, CustomLogger>();
            //            services.AddScoped<IUserService, UserService>();
            //            services.AddScoped<IUserManualService, UserManualService>();
            //            services.AddScoped<IUserProfileService, UserProfileService>();
            //            services.AddScoped<IPermissionService, PermissionService>();
            //            services.AddScoped<INotifier, Notifier>();
            //            services.AddScoped<ICustomLogger, CustomLogger>();
            //            services.AddScoped<IUserService, UserService>();
            //            services.AddScoped<IUserManualService, UserManualService>();
            //            services.AddScoped<IUserProfileService, UserProfileService>();
            //            services.AddScoped<IPermissionService, PermissionService>();

            return services;
        }
    }
}
