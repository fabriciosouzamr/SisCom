using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ICFOPService : IDisposable
    {
        Task Adicionar(TabelaCFOP CFOP);
        Task Atualizar(TabelaCFOP CFOP);
        Task Remover(Guid id);
        Task<List<TabelaCFOP>> GetAll(Expression<Func<TabelaCFOP, object>> order = null);

        Task<List<TabelaCFOP>> Combo(Expression<Func<TabelaCFOP, object>> order = null);
        Task<TabelaCFOP> GetById(Guid id);

        Task<IPagedList<TabelaCFOP>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
