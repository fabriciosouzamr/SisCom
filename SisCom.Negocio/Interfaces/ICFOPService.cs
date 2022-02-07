using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ICFOPService : IDisposable
    {
        Task Adicionar(TabelaCFOP CFOP);
        Task Atualizar(TabelaCFOP CFOP);
        Task Remover(Guid id);
        Task<List<TabelaCFOP>> GetAll();

        Task<List<TabelaCFOP>> Combo();
        Task<TabelaCFOP> GetById(Guid id);

        Task<IPagedList<TabelaCFOP>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
