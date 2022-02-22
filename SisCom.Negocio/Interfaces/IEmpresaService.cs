using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IEmpresaService : IDisposable
    {
        Task Adicionar(Empresa Empresa);
        Task Atualizar(Empresa Empresa);
        Task Remover(Guid id);
        Task<List<Empresa>> GetAll(Expression<Func<Empresa, object>> order = null);

        Task<List<Empresa>> Combo(Expression<Func<Empresa, object>> order = null);
        Task<Empresa> GetById(Guid id);

        Task<IPagedList<Empresa>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
