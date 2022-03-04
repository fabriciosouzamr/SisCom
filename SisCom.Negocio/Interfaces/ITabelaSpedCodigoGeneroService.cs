using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaSpedCodigoGeneroService : IDisposable
    {
        Task Adicionar(TabelaSpedCodigoGenero TabelaSpedCodigoGenero);
        Task Atualizar(TabelaSpedCodigoGenero TabelaSpedCodigoGenero);
        Task Remover(Guid id);
        Task<List<TabelaSpedCodigoGenero>> GetAll(Expression<Func<TabelaSpedCodigoGenero, object>> order = null);

        Task<List<TabelaSpedCodigoGenero>> Combo(Expression<Func<TabelaSpedCodigoGenero, object>> order = null);
        Task<TabelaSpedCodigoGenero> GetById(Guid id);

        Task<IPagedList<TabelaSpedCodigoGenero>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
