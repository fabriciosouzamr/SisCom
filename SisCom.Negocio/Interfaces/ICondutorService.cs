using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ICondutorService : IDisposable
    {
        Task Adicionar(Condutor Condutor);
        Task Atualizar(Condutor Condutor);
        Task Excluir(Guid id);
        Task<List<Condutor>> GetAll(Expression<Func<Condutor, object>> order = null);
        Task<List<Condutor>> Combo(Expression<Func<Condutor, object>> order = null);
        Task<Condutor> GetById(Guid id);
        Task<IPagedList<Condutor>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
