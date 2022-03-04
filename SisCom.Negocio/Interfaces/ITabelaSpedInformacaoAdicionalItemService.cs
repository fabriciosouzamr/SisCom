using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaSpedInformacaoAdicionalItemService : IDisposable
    {
        Task Adicionar(TabelaSpedInformacaoAdicionalItem TabelaSpedInformacaoAdicionalItem);
        Task Atualizar(TabelaSpedInformacaoAdicionalItem TabelaSpedInformacaoAdicionalItem);
        Task Remover(Guid id);
        Task<List<TabelaSpedInformacaoAdicionalItem>> GetAll(Expression<Func<TabelaSpedInformacaoAdicionalItem, object>> order = null);

        Task<List<TabelaSpedInformacaoAdicionalItem>> Combo(Expression<Func<TabelaSpedInformacaoAdicionalItem, object>> order = null);
        Task<TabelaSpedInformacaoAdicionalItem> GetById(Guid id);

        Task<IPagedList<TabelaSpedInformacaoAdicionalItem>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
