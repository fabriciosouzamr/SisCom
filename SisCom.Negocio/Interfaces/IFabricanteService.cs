using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IFabricanteService : IDisposable
    {
        Task Adicionar(Fabricante Fabricante);
        Task Atualizar(Fabricante Fabricante);
        Task Remover(Guid id);
        Task<List<Fabricante>> GetAll(Expression<Func<Fabricante, object>> order = null);
        Task<List<Fabricante>> Combo(Expression<Func<Fabricante, object>> order = null);
        Task<Fabricante> GetById(Guid id);

        Task<IPagedList<Fabricante>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
