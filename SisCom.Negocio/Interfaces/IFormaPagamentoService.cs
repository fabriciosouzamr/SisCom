using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IFormaPagamentoService : IDisposable
    {
        Task Adicionar(FormaPagamento FormaPagamento);
        Task Atualizar(FormaPagamento FormaPagamento);
        Task Remover(Guid id);
        Task<List<FormaPagamento>> GetAll(Expression<Func<FormaPagamento, object>> order = null);
        Task<List<FormaPagamento>> Combo(Expression<Func<FormaPagamento, object>> order = null);
        Task<FormaPagamento> GetById(Guid id);
        Task<IPagedList<FormaPagamento>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
