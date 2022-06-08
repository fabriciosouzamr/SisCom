using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalEntradaMercadoriaService : IDisposable
    {
        Task Adicionar(NotaFiscalEntradaMercadoria notaFiscalEntradaMercadoria);
        Task Atualizar(NotaFiscalEntradaMercadoria notaFiscalEntradaMercadoria);
        Task Excluir(Guid id);
        Task<List<NotaFiscalEntradaMercadoria>> GetAll(Expression<Func<NotaFiscalEntradaMercadoria, object>> order = null);

        Task<List<NotaFiscalEntradaMercadoria>> Combo(Expression<Func<NotaFiscalEntradaMercadoria, object>> order = null);
        Task<NotaFiscalEntradaMercadoria> GetById(Guid id);

        Task<IPagedList<NotaFiscalEntradaMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
