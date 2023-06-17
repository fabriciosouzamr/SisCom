using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IEstoqueLancamentoService : IDisposable
    {
        Task Adicionar(EstoqueLancamento EstoqueLancamento);
        Task Atualizar(EstoqueLancamento EstoqueLancamento);
        Task Excluir(Guid id);
        Task<List<EstoqueLancamento>> GetAll(Expression<Func<EstoqueLancamento, object>> order = null);
        Task<List<EstoqueLancamento>> Combo(Expression<Func<EstoqueLancamento, object>> order = null);
        Task<EstoqueLancamento> GetById(Guid id);
        Task<IPagedList<EstoqueLancamento>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
