using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IGrupoMercadoriaService : IDisposable
    {
        Task Adicionar(GrupoMercadoria GrupoProduto);
        Task Atualizar(GrupoMercadoria GrupoProduto);
        Task Remover(Guid id);
        Task<List<GrupoMercadoria>> GetAll();

        Task<List<GrupoMercadoria>> Combo();
        Task<GrupoMercadoria> GetById(Guid id);

        Task<IPagedList<GrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
