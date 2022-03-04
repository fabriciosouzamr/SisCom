using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaCST_CSOSNService : IDisposable
    {
        Task Adicionar(TabelaCST_CSOSN TabelaCST_CSOSN);
        Task Atualizar(TabelaCST_CSOSN TabelaCST_CSOSN);
        Task Remover(Guid id);
        Task<List<TabelaCST_CSOSN>> GetAll(Expression<Func<TabelaCST_CSOSN, object>> order = null);

        Task<List<TabelaCST_CSOSN>> Combo(Expression<Func<TabelaCST_CSOSN, object>> order = null);
        Task<TabelaCST_CSOSN> GetById(Guid id);

        Task<IPagedList<TabelaCST_CSOSN>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
