using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITipoMercadoriaService : IDisposable
    {
        Task Adicionar(TipoMercadoria TipoMercadoria);
        Task Atualizar(TipoMercadoria TipoMercadoria);
        Task Remover(Guid id);
        Task<List<TipoMercadoria>> GetAll(Expression<Func<TipoMercadoria, object>> order = null);

        Task<List<TipoMercadoria>> Combo(Expression<Func<TipoMercadoria, object>> order = null);
        Task<TipoMercadoria> GetById(Guid id);

        Task<IPagedList<TipoMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
