using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaPagamentoService : IDisposable
    {
        Task Adicionar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento);
        Task Atualizar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento);
        Task Excluir(Guid id);
        Task<List<NotaFiscalSaidaPagamento>> GetAll(Expression<Func<NotaFiscalSaidaPagamento, object>> order = null);

        Task<List<NotaFiscalSaidaPagamento>> Combo(Expression<Func<NotaFiscalSaidaPagamento, object>> order = null);
        Task<NotaFiscalSaidaPagamento> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaidaPagamento>> GetPagedList(FilteredPagedListParameters parameters);
    }
}