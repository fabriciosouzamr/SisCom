using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        Task Adicionar(Cidade Cidade);
        Task Atualizar(Cidade Cidade);
        Task Remover(Guid id);
        Task<List<Cidade>> GetAll();

        Task<List<Cidade>> Combo(Expression<Func<Cidade, object>> order = null);
        Task<Cidade> GetById(Guid id);

        Task<IPagedList<Cidade>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
