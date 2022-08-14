using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public  interface IVendaService : IDisposable
    {
        Task Adicionar(Venda venda);
        Task Atualizar(Venda venda);
        Task Excluir(Guid id);
        Task<List<Venda>> GetAll(Expression<Func<Venda, object>> order = null);
        Task<List<Venda>> Combo(Expression<Func<Venda, object>> order = null);
        Task<Venda> GetById(Guid id);
        Task<IPagedList<Venda>> GetPagedList(FilteredPagedListParameters parameters);
    }
}