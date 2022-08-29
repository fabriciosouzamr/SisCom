using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaReferenciaService : IDisposable
    {
        Task Adicionar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia);
        Task Atualizar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia);
        Task Remover(Guid id);
        Task<List<NotaFiscalSaidaReferencia>> GetAll(Expression<Func<NotaFiscalSaidaReferencia, object>> order = null);

        Task<List<NotaFiscalSaidaReferencia>> Combo(Expression<Func<NotaFiscalSaidaReferencia, object>> order = null);
        Task<NotaFiscalSaidaReferencia> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaidaReferencia>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
