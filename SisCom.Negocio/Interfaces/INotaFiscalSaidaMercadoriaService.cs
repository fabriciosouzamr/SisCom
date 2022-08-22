using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaMercadoriaService : IDisposable
    {
        Task Adicionar(NotaFiscalSaidaMercadoria NotaFiscalSaidaMercadoria);
        Task Atualizar(NotaFiscalSaidaMercadoria NotaFiscalSaidaMercadoria);
        Task Excluir(Guid id);
        Task<List<NotaFiscalSaidaMercadoria>> GetAll(Expression<Func<NotaFiscalSaidaMercadoria, object>> order = null);

        Task<List<NotaFiscalSaidaMercadoria>> Combo(Expression<Func<NotaFiscalSaidaMercadoria, object>> order = null);
        Task<NotaFiscalSaidaMercadoria> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaidaMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
