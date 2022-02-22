using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ISubGrupoMercadoriaService : IDisposable
    {
        Task Adicionar(SubGrupoMercadoria SubGrupo);
        Task Atualizar(SubGrupoMercadoria SubGrupo);
        Task Remover(Guid id);
        Task<List<SubGrupoMercadoria>> GetAll(Expression<Func<SubGrupoMercadoria, object>> order = null);

        Task<List<SubGrupoMercadoria>> Combo(Expression<Func<SubGrupoMercadoria, object>> order = null);
        Task<SubGrupoMercadoria> GetById(Guid id);

        Task<IPagedList<SubGrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
