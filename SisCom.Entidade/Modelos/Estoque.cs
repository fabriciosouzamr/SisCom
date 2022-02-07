using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Estoque : Entity
    {
        public Almoxarifado Almoxarifado { get; set; }
        public Mercadoria Mercadoria { get; set; }

        public double QuantidadeEmEstoque { get; set; }
        public double QuantidadeBloqueada { get; set; }

        /* EF Relation */
        public Guid AlmoxarifadoId { get; set; }
        public Guid MercadoriaId { get; set; }
    }
}