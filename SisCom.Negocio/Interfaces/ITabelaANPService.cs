using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaANPService : IDisposable
    {
        Task Adicionar(TabelaANP TabelaANP);
        Task Atualizar(TabelaANP TabelaANP);
        Task Remover(Guid id);
        Task<List<TabelaANP>> GetAll(Expression<Func<TabelaANP, object>> order = null);

        Task<List<TabelaANP>> Combo(Expression<Func<TabelaANP, object>> order = null);
        Task<TabelaANP> GetById(Guid id);

        Task<IPagedList<TabelaANP>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
