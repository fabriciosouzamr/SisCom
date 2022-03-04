using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaMotivoDesoneracaoICMSService : IDisposable
    {
        Task Adicionar(TabelaMotivoDesoneracaoICMS TabelaMotivoDesoneracaoICMS);
        Task Atualizar(TabelaMotivoDesoneracaoICMS TabelaMotivoDesoneracaoICMS);
        Task Remover(Guid id);
        Task<List<TabelaMotivoDesoneracaoICMS>> GetAll(Expression<Func<TabelaMotivoDesoneracaoICMS, object>> order = null);

        Task<List<TabelaMotivoDesoneracaoICMS>> Combo(Expression<Func<TabelaMotivoDesoneracaoICMS, object>> order = null);
        Task<TabelaMotivoDesoneracaoICMS> GetById(Guid id);

        Task<IPagedList<TabelaMotivoDesoneracaoICMS>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
