using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IGrupoNaturezaReceita_CTS_PIS_COFINSService : IDisposable
    {
        Task Adicionar(GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS);
        Task Atualizar(GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS);
        Task Remover(Guid id);
        Task<List<GrupoNaturezaReceita_CTS_PIS_COFINS>> GetAll(Expression<Func<GrupoNaturezaReceita_CTS_PIS_COFINS, object>> order = null);

        Task<List<GrupoNaturezaReceita_CTS_PIS_COFINS>> Combo(Expression<Func<GrupoNaturezaReceita_CTS_PIS_COFINS, object>> order = null);
        Task<GrupoNaturezaReceita_CTS_PIS_COFINS> GetById(Guid id);

        Task<IPagedList<GrupoNaturezaReceita_CTS_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
