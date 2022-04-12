using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IMercadoriaService : IDisposable
    {
        Task Adicionar(Mercadoria Mercadoria);
        Task Atualizar(Mercadoria Mercadoria);
        Task Excluir(Guid id);
        Task<List<Mercadoria>> GetAll(Expression<Func<Mercadoria, object>> order = null);
        Task<List<Mercadoria>> Combo(Expression<Func<Mercadoria, object>> order = null);
        Task<Mercadoria> GetById(Guid id);
        Task<IPagedList<Mercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
