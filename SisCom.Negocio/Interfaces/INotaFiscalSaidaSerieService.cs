using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaSerieService : IDisposable
    {
        Task Adicionar(NotaFiscalSaidaSerie NotaFiscalSaidaSerie);
        Task Atualizar(NotaFiscalSaidaSerie NotaFiscalSaidaSerie);
        Task Excluir(Guid id);
        Task<List<NotaFiscalSaidaSerie>> GetAll(Expression<Func<NotaFiscalSaidaSerie, object>> order = null);

        Task<List<NotaFiscalSaidaSerie>> Combo(Expression<Func<NotaFiscalSaidaSerie, object>> order = null);
        Task<NotaFiscalSaidaSerie> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaidaSerie>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
