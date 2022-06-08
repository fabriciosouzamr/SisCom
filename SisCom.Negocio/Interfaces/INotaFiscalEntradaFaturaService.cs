using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalEntradaFaturaService : IDisposable
    {
        Task Adicionar(NotaFiscalEntradaFatura notaFiscalEntradaFatura);
        Task Atualizar(NotaFiscalEntradaFatura notaFiscalEntradaFatura);
        Task Excluir(Guid id);
        Task<List<NotaFiscalEntradaFatura>> GetAll(Expression<Func<NotaFiscalEntradaFatura, object>> order = null);

        Task<List<NotaFiscalEntradaFatura>> Combo(Expression<Func<NotaFiscalEntradaFatura, object>> order = null);
        Task<NotaFiscalEntradaFatura> GetById(Guid id);

        Task<IPagedList<NotaFiscalEntradaFatura>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
