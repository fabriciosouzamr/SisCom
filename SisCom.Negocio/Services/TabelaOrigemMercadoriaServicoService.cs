using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaOrigemMercadoriaServicoService : BaseService<TabelaOrigemMercadoriaServico>, ITabelaOrigemMercadoriaServicoService
    {
        private readonly ITabelaOrigemMercadoriaServicoRepository _TabelaOrigemMercadoriaServicoRepository;

        public TabelaOrigemMercadoriaServicoService(ITabelaOrigemMercadoriaServicoRepository TabelaOrigemMercadoriaServicoRepository,
                                 INotifier notificador) : base(notificador, TabelaOrigemMercadoriaServicoRepository)
        {
            _TabelaOrigemMercadoriaServicoRepository = TabelaOrigemMercadoriaServicoRepository;
        }

        public Task<IPagedList<TabelaOrigemMercadoriaServico>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaOrigemMercadoriaServicoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaOrigemMercadoriaServicoRepository?.Dispose();
        }

        public Task Adicionar(TabelaOrigemMercadoriaServico TabelaOrigemMercadoriaServico)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaOrigemMercadoriaServico TabelaOrigemMercadoriaServico)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
