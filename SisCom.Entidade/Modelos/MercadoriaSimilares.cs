using Funcoes._Entity;
using System;
using System.Collections.Generic;

namespace SisCom.Entidade.Modelos
{
    public class MercadoriaSimilares : Entity
    {
        public Similar Similar { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public Mercadoria MercadoriaSimilar { get; set; }
        public double Preco { get; set; }
        public double QuantidadeEmEstoque { get; set; }

        /* EF Relation */
        public Guid SimilarId { get; set; }
        public Guid MercadoriaId { get; set; }
        public Guid MercadoriaSimilarId { get; set; }
    }
}