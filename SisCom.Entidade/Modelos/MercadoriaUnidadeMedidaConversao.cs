using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class MercadoriaUnidadeMedidaConversao : Entity
    {
        public Guid MercadoriaId { get; set; }
        public Guid UnidadeMedidaId { get; set; }
        public double FatorConversao { get; set; }
    }
}
