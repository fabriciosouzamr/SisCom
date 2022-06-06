using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class UnidadeMedidaConversao : Entity
    {
        public UnidadeMedida UnidadeMedidaA { get; set; }
        public UnidadeMedida UnidadeMedidaB { get; set; }
        public decimal Conversor { get; set; }

        /* EF Relation */
        public Guid UnidadeMedidaAId { get; set; }
        public Guid UnidadeMedidaBId { get; set; }
    }
}