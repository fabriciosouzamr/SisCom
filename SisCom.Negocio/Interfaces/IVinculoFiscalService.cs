using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IVinculoFiscalService : IDisposable
    {
        Task Adicionar(VinculoFiscal VinculoFiscal);
        Task Atualizar(VinculoFiscal VinculoFiscal);
        Task Remover(Guid id);
        Task<List<VinculoFiscal>> GetAll(Expression<Func<VinculoFiscal, object>> order = null);

        Task<List<VinculoFiscal>> Combo(Expression<Func<VinculoFiscal, object>> order = null);
        Task<VinculoFiscal> GetById(Guid id);

        Task<IPagedList<VinculoFiscal>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
