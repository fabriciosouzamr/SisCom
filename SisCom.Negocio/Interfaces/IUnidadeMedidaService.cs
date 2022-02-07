using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IUnidadeMedidaService : IDisposable
    {
        Task Adicionar(UnidadeMedida UnidadeMedida);
        Task Atualizar(UnidadeMedida UnidadeMedida);
        Task Remover(Guid id);
        Task<List<UnidadeMedida>> GetAll();

        Task<List<UnidadeMedida>> Combo();
        Task<UnidadeMedida> GetById(Guid id);

        Task<IPagedList<UnidadeMedida>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
