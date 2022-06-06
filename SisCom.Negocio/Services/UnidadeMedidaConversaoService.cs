using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class UnidadeMedidaConversaoService : BaseService<UnidadeMedidaConversao>, IUnidadeMedidaConversaoService
    {
        private readonly IUnidadeMedidaConversaoRepository _UnidadeMedidaConversaoRepository;

        public UnidadeMedidaConversaoService(IUnidadeMedidaConversaoRepository UnidadeMedidaConversaoRepository,
                                 INotifier notificador) : base(notificador, UnidadeMedidaConversaoRepository)
        {
            _UnidadeMedidaConversaoRepository = UnidadeMedidaConversaoRepository;
        }

        public Task<IPagedList<UnidadeMedidaConversao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _UnidadeMedidaConversaoRepository.GetPagedList(f =>
            (
                parameters.Search == null), parameters);
        }
        public Task<List<UnidadeMedidaConversao>> GetAll(Expression<Func<UnidadeMedidaConversao, object>> order = null, params Expression<Func<UnidadeMedidaConversao, object>>[] includes)
        {
            var getAll = _UnidadeMedidaConversaoRepository.GetAll(order, includes);
            return getAll;
        }

        public override void Dispose()
        {
            _UnidadeMedidaConversaoRepository?.Dispose();
        }

        public Task Adicionar(UnidadeMedidaConversao UnidadeMedidaConversao)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(UnidadeMedidaConversao UnidadeMedidaConversao)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
