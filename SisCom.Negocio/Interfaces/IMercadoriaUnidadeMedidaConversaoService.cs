using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IMercadoriaUnidadeMedidaConversaoService : IDisposable
    {
        Task Adicionar(MercadoriaUnidadeMedidaConversao mercadoriaUnidadeMedidaConversao);
        Task Atualizar(MercadoriaUnidadeMedidaConversao mercadoriaUnidadeMedidaConversao);
        Task Excluir(Guid id);
        Task<List<MercadoriaUnidadeMedidaConversao>> GetAll(Expression<Func<MercadoriaUnidadeMedidaConversao, object>> order = null);
    }
}
