using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IObservacaoService : IDisposable
    {
        Task Adicionar(Observacao Observacao);
        Task Atualizar(Observacao Observacao);
        Task Remover(Guid id);
        Task<List<Observacao>> GetAll(Expression<Func<Observacao, object>> order = null);

        Task<List<Observacao>> Combo(Expression<Func<Observacao, object>> order = null);
        Task<Observacao> GetById(Guid id);

        Task<IPagedList<Observacao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
