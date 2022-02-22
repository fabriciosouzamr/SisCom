using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IEstadoService : IDisposable
    {
        Task Adicionar(Estado Estado);
        Task Atualizar(Estado Estado);
        Task Remover(Guid id);
        Task<List<Estado>> GetAll(Expression<Func<Estado, object>> order = null);

        Task<List<Estado>> Combo(Expression<Func<Estado, object>> order = null);
        Task<Estado> GetById(Guid id);

        Task<IPagedList<Estado>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
