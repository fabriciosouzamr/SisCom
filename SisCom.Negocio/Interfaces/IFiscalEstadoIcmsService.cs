using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IFiscalEstadoIcmsService
    {
        Task Adicionar(FiscalEstadoIcms FiscalEstadoIcms);
        Task Atualizar(FiscalEstadoIcms FiscalEstadoIcms);
        Task Excluir(Guid id);
        Task<List<FiscalEstadoIcms>> GetAll(Expression<Func<FiscalEstadoIcms, object>> order = null);
        Task<List<FiscalEstadoIcms>> Combo(Expression<Func<FiscalEstadoIcms, object>> order = null);
        Task<FiscalEstadoIcms> GetById(Guid id);
    }
}
