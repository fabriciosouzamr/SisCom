using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalFinalidadeService : IDisposable
    {
        Task Adicionar(NotaFiscalFinalidade NotaFiscalFinalidade);
        Task Atualizar(NotaFiscalFinalidade NotaFiscalFinalidade);
        Task Remover(Guid id);
        Task<List<NotaFiscalFinalidade>> GetAll(Expression<Func<NotaFiscalFinalidade, object>> order = null);

        Task<List<NotaFiscalFinalidade>> Combo(Expression<Func<NotaFiscalFinalidade, object>> order = null);
        Task<NotaFiscalFinalidade> GetById(Guid id);

        Task<IPagedList<NotaFiscalFinalidade>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
