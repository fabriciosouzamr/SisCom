using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaOrigemVendaService : IDisposable
    {
        Task Adicionar(TabelaOrigemVenda TabelaOrigemVenda);
        Task Atualizar(TabelaOrigemVenda TabelaOrigemVenda);
        Task Remover(Guid id);
        Task<List<TabelaOrigemVenda>> GetAll(Expression<Func<TabelaOrigemVenda, object>> order = null);

        Task<List<TabelaOrigemVenda>> Combo(Expression<Func<TabelaOrigemVenda, object>> order = null);
        Task<TabelaOrigemVenda> GetById(Guid id);

        Task<IPagedList<TabelaOrigemVenda>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
