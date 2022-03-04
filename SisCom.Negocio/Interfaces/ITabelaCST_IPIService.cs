using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaCST_IPIService : IDisposable
    {
        Task Adicionar(TabelaCST_IPI TabelaCST_IPI);
        Task Atualizar(TabelaCST_IPI TabelaCST_IPI);
        Task Remover(Guid id);
        Task<List<TabelaCST_IPI>> GetAll(Expression<Func<TabelaCST_IPI, object>> order = null);

        Task<List<TabelaCST_IPI>> Combo(Expression<Func<TabelaCST_IPI, object>> order = null);
        Task<TabelaCST_IPI> GetById(Guid id);

        Task<IPagedList<TabelaCST_IPI>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
