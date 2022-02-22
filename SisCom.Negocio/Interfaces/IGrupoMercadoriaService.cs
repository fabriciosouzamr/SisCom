using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IGrupoMercadoriaService : IDisposable
    {
        Task Adicionar(GrupoMercadoria GrupoProduto);
        Task Atualizar(GrupoMercadoria GrupoProduto);
        Task Remover(Guid id);
        Task<List<GrupoMercadoria>> GetAll(Expression<Func<GrupoMercadoria, object>> order = null);

        Task<List<GrupoMercadoria>> Combo(Expression<Func<GrupoMercadoria, object>> order = null);
        Task<GrupoMercadoria> GetById(Guid id);

        Task<IPagedList<GrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
