using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IUnidadeMedidaService : IDisposable
    {
        Task Adicionar(UnidadeMedida UnidadeMedida);
        Task Atualizar(UnidadeMedida UnidadeMedida);
        Task Remover(Guid id);
        Task<List<UnidadeMedida>> GetAll(Expression<Func<UnidadeMedida, object>> order = null);

        Task<List<UnidadeMedida>> Combo(Expression<Func<UnidadeMedida, object>> order = null);
        Task<UnidadeMedida> GetById(Guid id);

        Task<IPagedList<UnidadeMedida>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
