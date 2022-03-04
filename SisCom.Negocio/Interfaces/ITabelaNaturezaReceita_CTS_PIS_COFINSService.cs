using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaNaturezaReceita_CTS_PIS_COFINSService : IDisposable
    {
        Task Adicionar(TabelaNaturezaReceita_CTS_PIS_COFINS TabelaNaturezaReceita_CTS_PIS_COFINS);
        Task Atualizar(TabelaNaturezaReceita_CTS_PIS_COFINS TabelaNaturezaReceita_CTS_PIS_COFINS);
        Task Remover(Guid id);
        Task<List<TabelaNaturezaReceita_CTS_PIS_COFINS>> GetAll(Expression<Func<TabelaNaturezaReceita_CTS_PIS_COFINS, object>> order = null);

        Task<List<TabelaNaturezaReceita_CTS_PIS_COFINS>> Combo(Expression<Func<TabelaNaturezaReceita_CTS_PIS_COFINS, object>> order = null);
        Task<TabelaNaturezaReceita_CTS_PIS_COFINS> GetById(Guid id);

        Task<IPagedList<TabelaNaturezaReceita_CTS_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
