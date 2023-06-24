using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IEstoqueUnidadeMedidaConversaoService : IDisposable
    {
        Task Adicionar(EstoqueUnidadeMedidaConversao estoqueUnidadeMedidaConversao);
        Task Atualizar(EstoqueUnidadeMedidaConversao estoqueUnidadeMedidaConversao);
        Task Excluir(Guid id);
        Task<List<EstoqueUnidadeMedidaConversao>> GetAll(Expression<Func<EstoqueUnidadeMedidaConversao, object>> order = null);
    }
}
