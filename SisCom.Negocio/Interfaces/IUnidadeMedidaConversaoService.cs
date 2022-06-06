using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IUnidadeMedidaConversaoService : IDisposable
    {
        Task Adicionar(UnidadeMedidaConversao UnidadeMedidaConversao);
        Task Atualizar(UnidadeMedidaConversao UnidadeMedidaConversao);
        Task Remover(Guid id);
        Task<List<UnidadeMedidaConversao>> GetAll(Expression<Func<UnidadeMedidaConversao, object>> order = null);

        Task<List<UnidadeMedidaConversao>> Combo(Expression<Func<UnidadeMedidaConversao, object>> order = null);
        Task<UnidadeMedidaConversao> GetById(Guid id);

        Task<IPagedList<UnidadeMedidaConversao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
