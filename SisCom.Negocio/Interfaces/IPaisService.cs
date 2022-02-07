using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IPaisService : IDisposable
    {
        Task Adicionar(Pais Pais);
        Task Atualizar(Pais Pais);
        Task Remover(Guid id);
        Task<List<Pais>> GetAll();

        Task<List<Pais>> Combo();
        Task<Pais> GetById(Guid id);

        Task<IPagedList<Pais>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
