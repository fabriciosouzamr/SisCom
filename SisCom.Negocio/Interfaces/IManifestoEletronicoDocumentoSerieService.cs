using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IManifestoEletronicoDocumentoSerieService : IDisposable
    {
        Task Adicionar(ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie);
        Task Atualizar(ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie);
        Task Excluir(Guid id);
        Task<List<ManifestoEletronicoDocumentoSerie>> GetAll(Expression<Func<ManifestoEletronicoDocumentoSerie, object>> order = null);

        Task<List<ManifestoEletronicoDocumentoSerie>> Combo(Expression<Func<ManifestoEletronicoDocumentoSerie, object>> order = null);
        Task<ManifestoEletronicoDocumentoSerie> GetById(Guid id);

        Task<IPagedList<ManifestoEletronicoDocumentoSerie>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
