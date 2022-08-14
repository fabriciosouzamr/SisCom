using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IVendaMercadoriaService : IDisposable
    {
        Task Adicionar(VendaMercadoria vendaMercadoria);
        Task Atualizar(VendaMercadoria vendaMercadoria);
        Task Excluir(Guid id);
        Task<List<VendaMercadoria>> GetAll(Expression<Func<VendaMercadoria, object>> order = null);
        Task<List<VendaMercadoria>> Combo(Expression<Func<VendaMercadoria, object>> order = null);
        Task<VendaMercadoria> GetById(Guid id);
        Task<IPagedList<VendaMercadoria>> GetPagedList(FilteredPagedListParameters parameters);
    }
}