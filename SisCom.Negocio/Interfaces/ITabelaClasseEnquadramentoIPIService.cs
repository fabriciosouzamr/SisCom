using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaClasseEnquadramentoIPIService : IDisposable
    {
        Task Adicionar(TabelaClasseEnquadramentoIPI TabelaClasseEnquadramentoIPI);
        Task Atualizar(TabelaClasseEnquadramentoIPI TabelaClasseEnquadramentoIPI);
        Task Remover(Guid id);
        Task<List<TabelaClasseEnquadramentoIPI>> GetAll(Expression<Func<TabelaClasseEnquadramentoIPI, object>> order = null);

        Task<List<TabelaClasseEnquadramentoIPI>> Combo(Expression<Func<TabelaClasseEnquadramentoIPI, object>> order = null);
        Task<TabelaClasseEnquadramentoIPI> GetById(Guid id);

        Task<IPagedList<TabelaClasseEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
