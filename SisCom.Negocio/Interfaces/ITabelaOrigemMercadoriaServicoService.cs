using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaOrigemMercadoriaServicoService : IDisposable
    {
        Task Adicionar(TabelaOrigemMercadoriaServico TabelaOrigemMercadoriaServico);
        Task Atualizar(TabelaOrigemMercadoriaServico TabelaOrigemMercadoriaServico);
        Task Remover(Guid id);
        Task<List<TabelaOrigemMercadoriaServico>> GetAll(Expression<Func<TabelaOrigemMercadoriaServico, object>> order = null);

        Task<List<TabelaOrigemMercadoriaServico>> Combo(Expression<Func<TabelaOrigemMercadoriaServico, object>> order = null);
        Task<TabelaOrigemMercadoriaServico> GetById(Guid id);

        Task<IPagedList<TabelaOrigemMercadoriaServico>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
