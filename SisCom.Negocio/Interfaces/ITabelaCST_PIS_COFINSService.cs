using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaCST_PIS_COFINSService : IDisposable
    {
        Task Adicionar(TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS);
        Task Atualizar(TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS);
        Task Remover(Guid id);
        Task<List<TabelaCST_PIS_COFINS>> GetAll(Expression<Func<TabelaCST_PIS_COFINS, object>> order = null);

        Task<List<TabelaCST_PIS_COFINS>> Combo(Expression<Func<TabelaCST_PIS_COFINS, object>> order = null);
        Task<TabelaCST_PIS_COFINS> GetById(Guid id);

        Task<IPagedList<TabelaCST_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
