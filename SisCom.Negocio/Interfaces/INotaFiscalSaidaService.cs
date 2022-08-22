using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INotaFiscalSaidaService : IDisposable
    {
        Task Adicionar(NotaFiscalSaida NotaFiscalSaida);
        Task Atualizar(NotaFiscalSaida NotaFiscalSaida);
        Task Excluir(Guid id);
        Task<List<NotaFiscalSaida>> GetAll(Expression<Func<NotaFiscalSaida, object>> order = null);

        Task<List<NotaFiscalSaida>> Combo(Expression<Func<NotaFiscalSaida, object>> order = null);
        Task<NotaFiscalSaida> GetById(Guid id);

        Task<IPagedList<NotaFiscalSaida>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
