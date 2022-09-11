using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NotaFiscalSaidaMercadoriaController : IDisposable
    {
        static NotaFiscalSaidaMercadoriaService _NotaFiscalSaidaMercadoriaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalSaidaMercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalSaidaMercadoriaService = new NotaFiscalSaidaMercadoriaService(new NotaFiscalSaidaMercadoriaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalSaidaMercadoriaViewModel> Adicionar(NotaFiscalSaidaMercadoriaViewModel NotaFiscalSaidaMercadoriaViewModel)
        {
            var NotaFiscalSaidaMercadoria = Declaracoes.mapper.Map<NotaFiscalSaidaMercadoria>(NotaFiscalSaidaMercadoriaViewModel);

            await _NotaFiscalSaidaMercadoriaService.Adicionar(NotaFiscalSaidaMercadoria);

            return Declaracoes.mapper.Map<NotaFiscalSaidaMercadoriaViewModel>(NotaFiscalSaidaMercadoria);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalSaidaMercadoriaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalSaidaMercadoriaViewModel> Atualizar(Guid id, NotaFiscalSaidaMercadoriaViewModel NotaFiscalSaidaMercadoriaViewModel)
        {
            await _NotaFiscalSaidaMercadoriaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaMercadoria>(NotaFiscalSaidaMercadoriaViewModel));

            return NotaFiscalSaidaMercadoriaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaMercadoriaService.GetAll(null, null, i => i.NotaFiscalSaida,
                                                                                        i => i.TabelaCFOP,
                                                                                        f => f.NotaFiscalSaida.Cliente,
                                                                                        fe => fe.NotaFiscalSaida.Cliente.Endereco.End_Cidade.Estado,
                                                                                        e => e.NotaFiscalSaida.Empresa); ; ;
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalSaidaMercadoriaService.GetAll(null, p => p.NotaFiscalSaidaId == Id, i => i.Mercadoria,
                                                                                                              i => i.Mercadoria.GrupoMercadoria,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceita,
                                                                                                              i => i.Mercadoria.Fabricante,
                                                                                                              i => i.Mercadoria.Fornecedor,
                                                                                                              i => i.Mercadoria.SubGrupoMercadoria,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaANP,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaBeneficioSPED,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaCEST,
                                                                                                              i => i.Mercadoria.Estoque_TributacaoNFCe_TabelaCFOP,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPI,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPI,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaCST_CSOSN,
                                                                                                              i => i.Mercadoria.Fiscal_NFE_TabelaCST_IPI,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_IPI_TabelaCST_IPI,
                                                                                                              i => i.Mercadoria.Fiscal_NFE_TabelaCST_COFINS ,
                                                                                                              i => i.Mercadoria.Fiscal_NFE_TabelaCST_PIS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPIS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMS,
                                                                                                              i => i.Mercadoria.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceita,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaNCM,
                                                                                                              i => i.Mercadoria.Fiscal_TabelaOrigemMercadoriaServico,
                                                                                                              i => i.Mercadoria.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCe,
                                                                                                              i => i.Mercadoria.Fiscal_SPED_TabelaSpedCodigoGenero,
                                                                                                              i => i.Mercadoria.Fiscal_SPED_TabelaSpedInformacaoAdicionalItem,
                                                                                                              i => i.Mercadoria.Fiscal_SPED_TabelaSpedTipoItem,
                                                                                                              i => i.Mercadoria.Fiscal_TipoMercadoria,
                                                                                                              i => i.Mercadoria.Estoque_TributacaoNFCe_TipoServicoFiscal,
                                                                                                              i => i.Mercadoria.Estoque_UnidadeMedidaMedida ,
                                                                                                              i => i.Mercadoria.Fiscal_VinculoFiscal,
                                                                                                              i => i.TabelaCFOP,
                                                                                                              i => i.TabelaCST_CSOSN,
                                                                                                              i => i.TabelaCST_IPI,
                                                                                                              i => i.TabelaCST_PIS_COFINS_COFINS,
                                                                                                              i => i.TabelaCST_PIS_COFINS_PIS,
                                                                                                              i => i.TabelaNCM,
                                                                                                              i => i.UnidadeMedida);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaMercadoria, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaMercadoriaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}