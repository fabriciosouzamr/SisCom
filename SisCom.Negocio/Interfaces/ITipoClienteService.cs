using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITipoClienteService : IDisposable
    {
        Task Adicionar(TipoCliente TipoCliente);
        Task Atualizar(TipoCliente TipoCliente);
        Task Remover(Guid id);
        Task<List<TipoCliente>> GetAll(Expression<Func<TipoCliente, object>> order = null);
        Task<List<TipoCliente>> Combo(Expression<Func<TipoCliente, object>> order = null);
        Task<TipoCliente> GetById(Guid id);

        Task<IPagedList<TipoCliente>> GetPagedList(FilteredPagedListParameters parameters);
        Task<List<TipoCliente>> GetAll();
    }
}
