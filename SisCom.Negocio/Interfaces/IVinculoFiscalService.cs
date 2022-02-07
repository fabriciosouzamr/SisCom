using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IVinculoFiscalService : IDisposable
    {
        Task Adicionar(VinculoFiscal VinculoFiscal);
        Task Atualizar(VinculoFiscal VinculoFiscal);
        Task Remover(Guid id);
        Task<List<VinculoFiscal>> GetAll();

        Task<List<VinculoFiscal>> Combo();
        Task<VinculoFiscal> GetById(Guid id);

        Task<IPagedList<VinculoFiscal>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
