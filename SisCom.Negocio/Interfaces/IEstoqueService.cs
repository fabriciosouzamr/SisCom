using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IEstoqueService : IDisposable
    {
        Task Adicionar(Estoque Estoque);
        Task Atualizar(Estoque Estoque);
        Task Excluir(Guid id);
        Task<List<Estoque>> GetAll(Expression<Func<Estoque, object>> order = null);
        Task<List<Estoque>> Combo(Expression<Func<Estoque, object>> order = null);
        Task<Estoque> GetById(Guid id);
        Task<IPagedList<Estoque>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
