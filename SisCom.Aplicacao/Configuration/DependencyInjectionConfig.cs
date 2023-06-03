using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;

namespace SisCom.Aplicacao.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IServiceScopeFactory<>), typeof(ServiceScopeFactory<>));
            services.AddScoped<MeuDbContext, MeuDbContext>();
            services.AddScoped<INotifier, Notifier>();

            #region Fromularios
            services.AddSingleton<frmMDI>();
            services.AddTransient<frmLogin>();
            services.AddTransient<frmCadastro>();
            services.AddTransient<frmCadastroCondutor>();
            services.AddTransient<frmCadastroConfiguracao>();
            services.AddTransient<frmCadastroGrupo>();
            services.AddTransient<frmCadastroFabricante>();
            services.AddTransient<frmCadastroFornecedores>();
            services.AddTransient<frmCadastroMercadorias>();
            services.AddTransient<frmCadastroMercadoriasVinculoFiscal>();
            services.AddTransient<frmCadastroMercadoriasNCM>();
            services.AddTransient<frmCadastroMercadoriasCST>();
            services.AddTransient<frmCadastroClientes>();
            services.AddTransient<frmCadastroFuncionarios>();
            services.AddTransient<frmCadastroObservacao>();
            services.AddTransient<frmCadastroTransportadoras>();
            services.AddTransient<frmCadastroTipoCliente>();
            services.AddTransient<frmCadastroEmpresas>();
            services.AddTransient<frmCadastroBuscarCNPJ>();
            services.AddTransient<frmCadastroNaturezaOperacao>();
            services.AddTransient<frmCadastroVeiculoPlaca>();
            services.AddTransient<frmComprasConsulta>();
            services.AddTransient<frmComprasInclusao>();
            services.AddTransient<frmFiscal_ImportarXML>();
            services.AddTransient<frmFiscal_MDFe>();
            services.AddTransient<frmFiscal_MDFe_Consulta>();
            services.AddTransient<frmFiscal_NotaFiscal>();
            services.AddTransient<frmFiscal_NotaFiscal_Impostos>();
            services.AddTransient<frmFiscal_NuvemFiscal>();
            services.AddTransient<frmFiscal_NuvemFiscal_Manifestar>();
            services.AddTransient<frmVendasConsulta>();
            services.AddTransient<frmVendasInclusao>();
            services.AddTransient<frmFiscal_Transmitir>();
            services.AddTransient<frmFiscal_Cancelamento>();
            services.AddTransient<frmFiscal_CartaCorrecao>();
            services.AddTransient<frmUtilitario>();
            #endregion

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
            #region Funcionario
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            #endregion
            #region Grupo       
            services.AddScoped<IGrupoMercadoriaRepository, GrupoRepository>();
            services.AddScoped<IGrupoMercadoriaService, GrupoMercadoriaService>();
            #endregion
            #region GrupoNaturezaReceita_CTS_PIS_COFINS
            services.AddScoped<IGrupoNaturezaReceita_CTS_PIS_COFINSRepository, GrupoNaturezaReceita_CTS_PIS_COFINSRepository>();
            services.AddScoped<IGrupoNaturezaReceita_CTS_PIS_COFINSService, GrupoNaturezaReceita_CTS_PIS_COFINSService>();
            #endregion
            #region Mercadoria
            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            services.AddScoped<IMercadoriaService, MercadoriaService>();
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
            #region TabelaANP
            services.AddScoped<ITabelaANPRepository, TabelaANPRepository>();
            services.AddScoped<ITabelaANPService, TabelaANPService>();
            #endregion
            #region TabelaBeneficioSPED
            services.AddScoped<ITabelaBeneficioSPEDRepository, TabelaBeneficioSPEDRepository>();
            services.AddScoped<ITabelaBeneficioSPEDService, TabelaBeneficioSPEDService>();
            #endregion
            #region TabelaCEST
            services.AddScoped<ITabelaCESTRepository, TabelaCESTRepository>();
            services.AddScoped<ITabelaCESTService, TabelaCESTService>();
            #endregion
            #region TabelaCFOP
            services.AddScoped<ITabelaCFOPRepository, TabelaCFOPRepository>();
            services.AddScoped<ITabelaCFOPService, TabelaCFOPService>();
            #endregion
            #region TabelaClasseEnquadramentoIPI
            services.AddScoped<ITabelaClasseEnquadramentoIPIRepository, TabelaClasseEnquadramentoIPIRepository>();
            services.AddScoped<ITabelaClasseEnquadramentoIPIService, TabelaClasseEnquadramentoIPIService>();
            #endregion
            #region TabelaCodigoEnquadramentoIPIs
            services.AddScoped<ITabelaCodigoEnquadramentoIPIRepository, TabelaCodigoEnquadramentoIPIRepository>();
            services.AddScoped<ITabelaCodigoEnquadramentoIPIService, TabelaCodigoEnquadramentoIPIService>();
            #endregion
            #region TabelaCST_CSOSN
            services.AddScoped<ITabelaCST_CSOSNRepository, TabelaCST_CSOSNRepository>();
            services.AddScoped<ITabelaCST_CSOSNService, TabelaCST_CSOSNService>();
            #endregion
            #region TabelaCST_PIS_COFINS
            services.AddScoped<ITabelaCST_PIS_COFINSRepository, TabelaCST_PIS_COFINSRepository>();
            services.AddScoped<ITabelaCST_PIS_COFINSService, TabelaCST_PIS_COFINSService>();
            #endregion
            #region TabelaCST_IPI
            services.AddScoped<ITabelaCST_IPIRepository, TabelaCST_IPIRepository>();
            services.AddScoped<ITabelaCST_IPIService, TabelaCST_IPIService>();
            #endregion
            #region TabelaNCM
            services.AddScoped<ITabelaNCMRepository, TabelaNCMRepository>();
            services.AddScoped<ITabelaNCMService, TabelaNCMService>();
            #endregion
            #region TabelaModalidadeDeterminacaoBCICMS
            services.AddScoped<ITabelaModalidadeDeterminacaoBCICMSRepository, TabelaModalidadeDeterminacaoBCICMSRepository>();
            services.AddScoped<ITabelaModalidadeDeterminacaoBCICMSService, TabelaModalidadeDeterminacaoBCICMSService>();
            #endregion
            #region TabelaMotivoDesoneracaoICMS
            services.AddScoped<ITabelaMotivoDesoneracaoICMSRepository, TabelaMotivoDesoneracaoICMSRepository>();
            services.AddScoped<ITabelaMotivoDesoneracaoICMSService, TabelaMotivoDesoneracaoICMSService>();
            #endregion
            #region TabelaNaturezaReceita_CTS_PIS_COFINS
            services.AddScoped<ITabelaNaturezaReceita_CTS_PIS_COFINSRepository, TabelaNaturezaReceita_CTS_PIS_COFINSRepository>();
            services.AddScoped<ITabelaNaturezaReceita_CTS_PIS_COFINSService, TabelaNaturezaReceita_CTS_PIS_COFINSService>();
            #endregion
            #region TabelaOrigemMercadoriaServico
            services.AddScoped<ITabelaOrigemMercadoriaServicoRepository, TabelaOrigemMercadoriaServicoRepository>();
            services.AddScoped<ITabelaOrigemMercadoriaServicoService, TabelaOrigemMercadoriaServicoService>();
            #endregion
            #region TabelaSpedCodigoGenero
            services.AddScoped<ITabelaSpedCodigoGeneroRepository, TabelaSpedCodigoGeneroRepository>();
            services.AddScoped<ITabelaSpedCodigoGeneroService, TabelaSpedCodigoGeneroService>();
            #endregion
            #region TabelaSpedInformacaoAdicionalItem
            services.AddScoped<ITabelaSpedInformacaoAdicionalItemRepository, TabelaSpedInformacaoAdicionalItemRepository>();
            services.AddScoped<ITabelaSpedInformacaoAdicionalItemService, TabelaSpedInformacaoAdicionalItemService>();
            #endregion
            #region TabelaSpedTipoItem
            services.AddScoped<ITabelaSpedTipoItemRepository, TabelaSpedTipoItemRepository>();
            services.AddScoped<ITabelaSpedTipoItemService, TabelaSpedTipoItemService>();
            #endregion
            #region TabelaSituacaoTributariaNFCe
            services.AddScoped<ITabelaSituacaoTributariaNFCeRepository, TabelaSituacaoTributariaNFCeRepository>();
            services.AddScoped<ITabelaSituacaoTributariaNFCeService, TabelaSituacaoTributariaNFCeService>();
            #endregion
            #region TipoMercadoria
            services.AddScoped<ITipoMercadoriaRepository, TipoMercadoriaRepository>();
            services.AddScoped<ITipoMercadoriaService, TipoMercadoriaService>();
            #endregion
            #region TipoServicoFiscal
            services.AddScoped<ITipoServicoFiscalRepository, TipoServicoFiscalRepository>();
            services.AddScoped<ITipoServicoFiscalService, TipoServicoFiscalService>();
            #endregion
            #region Transportadora
            services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
            services.AddScoped<ITransportadoraService, TransportadoraService>();
            #endregion
            #region VinculoFiscal
            services.AddScoped<IVinculoFiscalRepository, VinculoFiscalRepository>();
            services.AddScoped<IVinculoFiscalService, VinculoFiscalService>();
            #endregion
            #region Venda
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
            #endregion
            //            services.AddScoped<IUserRepository, UserRepository>();
            //            services.AddScoped<IUserManualRepository, UserManualRepository>();
            //            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            //            services.AddScoped<IPermissionRepository, PermissionRepository>();
            //            services.AddScoped<ICustomLogger, CustomLogger>();
            //            services.AddScoped<IUserService, UserService>();
            //            services.AddScoped<IUserManualService, UserManualService>();
            //            services.AddScoped<IUserProfileService, UserProfileService>();
            //            services.AddScoped<IPermissionService, PermissionService>();
            //            services.AddScoped<ICustomLogger, CustomLogger>();
            //            services.AddScoped<IUserService, UserService>();
            //            services.AddScoped<IUserManualService, UserManualService>();
            //            services.AddScoped<IUserProfileService, UserProfileService>();
            //            services.AddScoped<IPermissionService, PermissionService>();

            return services;
        }
    }
}
