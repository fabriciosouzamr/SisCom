using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IManifestoEletronicoDocumentoPercursoService
    {
        Task Adicionar(ManifestoEletronicoDocumentoPercurso ManifestoEletronicoDocumentoPercurso);
        Task Atualizar(ManifestoEletronicoDocumentoPercurso ManifestoEletronicoDocumentoPercurso);
        Task Excluir(Guid id);
        Task<List<ManifestoEletronicoDocumentoPercurso>> GetAll(Expression<Func<ManifestoEletronicoDocumentoPercurso, object>> order = null);
        Task<List<ManifestoEletronicoDocumentoPercurso>> Combo(Expression<Func<ManifestoEletronicoDocumentoPercurso, object>> order = null);
        Task<ManifestoEletronicoDocumentoPercurso> GetById(Guid id);
        Task<IPagedList<ManifestoEletronicoDocumentoPercurso>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
