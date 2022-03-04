using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITabelaBeneficioSPEDService : IDisposable
    {
        Task Adicionar(TabelaBeneficioSPED TabelaBeneficioSPED);
        Task Atualizar(TabelaBeneficioSPED TabelaBeneficioSPED);
        Task Remover(Guid id);
        Task<List<TabelaBeneficioSPED>> GetAll(Expression<Func<TabelaBeneficioSPED, object>> order = null);

        Task<List<TabelaBeneficioSPED>> Combo(Expression<Func<TabelaBeneficioSPED, object>> order = null);
        Task<TabelaBeneficioSPED> GetById(Guid id);

        Task<IPagedList<TabelaBeneficioSPED>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
