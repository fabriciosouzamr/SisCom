using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class FiscalEstadoIcms : Entity
    {
        public Estado EstadoOrigem { get; set; }
        public Estado EstadoDestino { get; set; }
        public decimal Icms { get; set; }

        /* EF Relation */
        public Guid EstadoOrigemId { get; set; }
        public Guid EstadoDestinoId { get; set; }
    }
}