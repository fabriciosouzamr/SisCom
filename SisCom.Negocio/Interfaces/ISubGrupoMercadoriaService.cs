using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ISubGrupoMercadoriaService : IDisposable
    {
        Task Adicionar(SubGrupoMercadoria SubGrupo);
        Task Atualizar(SubGrupoMercadoria SubGrupo);
        Task Remover(Guid id);
        Task<List<SubGrupoMercadoria>> GetAll();

        Task<List<SubGrupoMercadoria>> Combo();
        Task<SubGrupoMercadoria> GetById(Guid id);

        Task<IPagedList<SubGrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
