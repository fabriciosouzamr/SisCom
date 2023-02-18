using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IPaisService : IDisposable
    {
        Task Adicionar(Pais Pais);
        Task Atualizar(Pais Pais);
        Task Excluir(Guid id);
        Task<List<Pais>> GetAll(Expression<Func<Pais, object>> order = null);

        Task<List<Pais>> Combo(Expression<Func<Pais, object>> order = null);
        Task<Pais> GetById(Guid id);

        Task<IPagedList<Pais>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
