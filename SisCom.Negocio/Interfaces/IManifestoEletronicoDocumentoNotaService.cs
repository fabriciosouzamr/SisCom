using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IManifestoEletronicoDocumentoNotaService
    {
        Task Adicionar(ManifestoEletronicoDocumentoNota ManifestoEletronicoDocumentoNota);
        Task Atualizar(ManifestoEletronicoDocumentoNota ManifestoEletronicoDocumentoNota);
        Task Excluir(Guid id);
        Task<List<ManifestoEletronicoDocumentoNota>> GetAll(Expression<Func<ManifestoEletronicoDocumentoNota, object>> order = null);
        Task<List<ManifestoEletronicoDocumentoNota>> Combo(Expression<Func<ManifestoEletronicoDocumentoNota, object>> order = null);
        Task<ManifestoEletronicoDocumentoNota> GetById(Guid id);
        Task<IPagedList<ManifestoEletronicoDocumentoNota>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
