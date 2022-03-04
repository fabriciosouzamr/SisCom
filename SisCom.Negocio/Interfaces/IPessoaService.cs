using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task Adicionar(Pessoa Pessoa);
        Task Atualizar(Pessoa Pessoa);
        Task Excluir(Guid id);
        Task<List<Pessoa>> GetAll(Expression<Func<Pessoa, object>> order = null);

        Task<List<Pessoa>> Combo(Expression<Func<Pessoa, object>> order = null);
        Task<List<Pessoa>> ComboFornecedor(Expression<Func<Pessoa, object>> order = null);
        Task<Pessoa> GetById(Guid id);

        Task<IPagedList<Pessoa>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
