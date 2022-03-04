using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITipoServicoFiscalService : IDisposable
    {
        Task Adicionar(TipoServicoFiscal TipoServicoFiscal);
        Task Atualizar(TipoServicoFiscal TipoServicoFiscal);
        Task Remover(Guid id);
        Task<List<TipoServicoFiscal>> GetAll(Expression<Func<TipoServicoFiscal, object>> order = null);

        Task<List<TipoServicoFiscal>> Combo(Expression<Func<TipoServicoFiscal, object>> order = null);
        Task<TipoServicoFiscal> GetById(Guid id);

        Task<IPagedList<TipoServicoFiscal>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
