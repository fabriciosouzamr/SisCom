using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        Task Adicionar(Cidade Cidade);
        Task Atualizar(Cidade Cidade);
        Task Remover(Guid id);
        Task<List<Cidade>> GetAll();

        Task<List<Cidade>> Combo();
        Task<Cidade> GetById(Guid id);

        Task<IPagedList<Cidade>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
