using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalEntradaService : IDisposable
    {
        Task Adicionar(NotaFiscalEntrada notaFiscalEntrada);
        Task Atualizar(NotaFiscalEntrada notaFiscalEntrada);
        Task Excluir(Guid id);
        Task<List<NotaFiscalEntrada>> GetAll(Expression<Func<NotaFiscalEntrada, object>> order = null);

        Task<List<NotaFiscalEntrada>> Combo(Expression<Func<NotaFiscalEntrada, object>> order = null);
        Task<NotaFiscalEntrada> GetById(Guid id);

        Task<IPagedList<NotaFiscalEntrada>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
