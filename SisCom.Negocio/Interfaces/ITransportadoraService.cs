using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ITransportadoraService : IDisposable
    {
        Task Adicionar(Transportadora unidadeMedida);
        Task Atualizar(Transportadora unidadeMedida);
        Task Excluir(Guid id);
        Task<List<Transportadora>> GetAll(Expression<Func<Transportadora, object>> order = null);

        Task<List<Transportadora>> Combo(Expression<Func<Transportadora, object>> order = null);
        Task<Transportadora> GetById(Guid id);

        Task<IPagedList<Transportadora>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
