using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaCESTService : IDisposable
    {
        Task Adicionar(TabelaCEST TabelaCEST);
        Task Atualizar(TabelaCEST TabelaCEST);
        Task Remover(Guid id);
        Task<List<TabelaCEST>> GetAll(Expression<Func<TabelaCEST, object>> order = null);

        Task<List<TabelaCEST>> Combo(Expression<Func<TabelaCEST, object>> order = null);
        Task<TabelaCEST> GetById(Guid id);

        Task<IPagedList<TabelaCEST>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
