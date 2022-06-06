using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface INaturezaOperacaoService : IDisposable
    {
        Task Adicionar(NaturezaOperacao NaturezaOperacao);
        Task Atualizar(NaturezaOperacao NaturezaOperacao);
        Task Remover(Guid id);
        Task<List<NaturezaOperacao>> GetAll(Expression<Func<NaturezaOperacao, object>> order = null);
        Task<List<NaturezaOperacao>> Combo(Expression<Func<NaturezaOperacao, object>> order = null);
        Task<NaturezaOperacao> GetById(Guid id);
        Task<IPagedList<NaturezaOperacao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
