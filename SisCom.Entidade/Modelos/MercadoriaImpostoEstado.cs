using Funcoes._Entity;
using SisCom.Entidade.Modelos;
using System;

namespace SisCom.Entidade.Modelos
{
    public class MercadoriaImpostoEstado : Entity
    {
        public Mercadoria Mercadoria { get; set; }
        public Estado EstadoOrigem { get; set; }
        public Estado EstadoDestino { get; set; }
        public decimal PercentualICMS { get; set; }

        /* EF Relation */
        public Guid? MercadoriaId { get; set; }
        public Guid? EstadoOrigemId { get; set; }
        public Guid? EstadoDestinoId { get; set; }
    }
}
