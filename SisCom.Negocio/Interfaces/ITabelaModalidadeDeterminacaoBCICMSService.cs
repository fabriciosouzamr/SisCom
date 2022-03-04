using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaModalidadeDeterminacaoBCICMSService : IDisposable
    {
        Task Adicionar(TabelaModalidadeDeterminacaoBCICMS TabelaModalidadeDeterminacaoBCICMS);
        Task Atualizar(TabelaModalidadeDeterminacaoBCICMS TabelaModalidadeDeterminacaoBCICMS);
        Task Remover(Guid id);
        Task<List<TabelaModalidadeDeterminacaoBCICMS>> GetAll(Expression<Func<TabelaModalidadeDeterminacaoBCICMS, object>> order = null);

        Task<List<TabelaModalidadeDeterminacaoBCICMS>> Combo(Expression<Func<TabelaModalidadeDeterminacaoBCICMS, object>> order = null);
        Task<TabelaModalidadeDeterminacaoBCICMS> GetById(Guid id);

        Task<IPagedList<TabelaModalidadeDeterminacaoBCICMS>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
