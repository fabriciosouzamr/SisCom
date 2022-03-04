using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaCodigoEnquadramentoIPIService : IDisposable
    {
        Task Adicionar(TabelaCodigoEnquadramentoIPI TabelaCodigoEnquadramentoIPI);
        Task Atualizar(TabelaCodigoEnquadramentoIPI TabelaCodigoEnquadramentoIPI);
        Task Remover(Guid id);
        Task<List<TabelaCodigoEnquadramentoIPI>> GetAll(Expression<Func<TabelaCodigoEnquadramentoIPI, object>> order = null);

        Task<List<TabelaCodigoEnquadramentoIPI>> Combo(Expression<Func<TabelaCodigoEnquadramentoIPI, object>> order = null);
        Task<TabelaCodigoEnquadramentoIPI> GetById(Guid id);

        Task<IPagedList<TabelaCodigoEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
