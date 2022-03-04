using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaNCMService : IDisposable
    {
        Task Adicionar(TabelaNCM TabelaNCM);
        Task Atualizar(TabelaNCM TabelaNCM);
        Task Remover(Guid id);
        Task<List<TabelaNCM>> GetAll(Expression<Func<TabelaNCM, object>> order = null);

        Task<List<TabelaNCM>> Combo(Expression<Func<TabelaNCM, object>> order = null);
        Task<TabelaNCM> GetById(Guid id);

        Task<IPagedList<TabelaNCM>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
