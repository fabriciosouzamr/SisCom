using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IManifestoEletronicoDocumentoService
    {
        Task Adicionar(ManifestoEletronicoDocumento ManifestoEletronicoDocumento);
        Task Atualizar(ManifestoEletronicoDocumento ManifestoEletronicoDocumento);
        Task Excluir(Guid id);
        Task<List<ManifestoEletronicoDocumento>> GetAll(Expression<Func<ManifestoEletronicoDocumento, object>> order = null);
        Task<List<ManifestoEletronicoDocumento>> Combo(Expression<Func<ManifestoEletronicoDocumento, object>> order = null);
        Task<ManifestoEletronicoDocumento> GetById(Guid id);
        Task<IPagedList<ManifestoEletronicoDocumento>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
