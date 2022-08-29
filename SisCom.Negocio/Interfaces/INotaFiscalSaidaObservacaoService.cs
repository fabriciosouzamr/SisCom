using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaObservacaoService : IDisposable
    {
        Task Adicionar(NotaFiscalSaidaObservacao NotaFiscalSaidaObservacao);
        Task Atualizar(NotaFiscalSaidaObservacao NotaFiscalSaidaObservacao);
        Task Remover(Guid id);
        Task<List<NotaFiscalSaidaObservacao>> GetAll(Expression<Func<NotaFiscalSaidaObservacao, object>> order = null);

        Task<List<NotaFiscalSaidaObservacao>> Combo(Expression<Func<NotaFiscalSaidaObservacao, object>> order = null);
        Task<NotaFiscalSaidaObservacao> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaidaObservacao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
