using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaSituacaoTributariaNFCeService : IDisposable
    {
        Task Adicionar(TabelaSituacaoTributariaNFCe TabelaSituacaoTributariaNFCe);
        Task Atualizar(TabelaSituacaoTributariaNFCe TabelaSituacaoTributariaNFCe);
        Task Remover(Guid id);
        Task<List<TabelaSituacaoTributariaNFCe>> GetAll(Expression<Func<TabelaSituacaoTributariaNFCe, object>> order = null);

        Task<List<TabelaSituacaoTributariaNFCe>> Combo(Expression<Func<TabelaSituacaoTributariaNFCe, object>> order = null);
        Task<TabelaSituacaoTributariaNFCe> GetById(Guid id);

        Task<IPagedList<TabelaSituacaoTributariaNFCe>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
