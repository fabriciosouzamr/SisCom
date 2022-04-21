using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IFuncionarioService : IDisposable
    {
        Task Adicionar(Funcionario Funcionario);
        Task Atualizar(Funcionario Funcionario);
        Task Excluir(Guid id);
        Task<List<Funcionario>> GetAll(Expression<Func<Funcionario, object>> order = null);

        Task<List<Funcionario>> Combo(Expression<Func<Funcionario, object>> order = null);
        Task<Funcionario> GetById(Guid id);

        Task<IPagedList<Funcionario>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
