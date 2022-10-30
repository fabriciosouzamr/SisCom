using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace SisCom.Negocio.Interfaces
{
    public interface IMercadoriaImpostoEstadoService : IDisposable
    {
        Task Adicionar(MercadoriaImpostoEstado MercadoriaImpostoEstado);
        Task Atualizar(MercadoriaImpostoEstado MercadoriaImpostoEstado);
        Task Remover(Guid id);
        Task<List<MercadoriaImpostoEstado>> GetAll(Expression<Func<MercadoriaImpostoEstado, object>> order = null);
        Task<MercadoriaImpostoEstado> GetById(Guid id);
        Task<IPagedList<MercadoriaImpostoEstado>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
