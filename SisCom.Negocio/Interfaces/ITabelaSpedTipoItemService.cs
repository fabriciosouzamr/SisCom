using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaSpedTipoItemService : IDisposable
    {
        Task Adicionar(TabelaSpedTipoItem TabelaSpedTipoItem);
        Task Atualizar(TabelaSpedTipoItem TabelaSpedTipoItem);
        Task Remover(Guid id);
        Task<List<TabelaSpedTipoItem>> GetAll(Expression<Func<TabelaSpedTipoItem, object>> order = null);

        Task<List<TabelaSpedTipoItem>> Combo(Expression<Func<TabelaSpedTipoItem, object>> order = null);
        Task<TabelaSpedTipoItem> GetById(Guid id);

        Task<IPagedList<TabelaSpedTipoItem>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
