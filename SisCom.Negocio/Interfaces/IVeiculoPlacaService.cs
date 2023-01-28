using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IVeiculoPlacaService : IDisposable
    {
        Task Adicionar(VeiculoPlaca veiculoPlaca);
        Task Atualizar(VeiculoPlaca veiculoPlaca);
        Task Excluir(Guid id);
        Task<List<VeiculoPlaca>> GetAll(Expression<Func<VeiculoPlaca, object>> order = null);
        Task<List<VeiculoPlaca>> Combo(Expression<Func<VeiculoPlaca, object>> order = null);
        Task<VeiculoPlaca> GetById(Guid id);
        Task<IPagedList<VeiculoPlaca>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
