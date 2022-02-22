using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class MercadoriaComposicao : Entity

    {
        public Mercadoria Mercadoria { get; set; }
        public Mercadoria MercadoriaComponente { get; set; }
        public double  Quantidade { get; set; }
        public int Sequencia { get; set; }
        public double PercentualPerdaQuebra { get; set; }

        /* EF Relation */
        public Guid MercadoriaId { get; set; }
        public Guid MercadoriaComponenteId { get; set; }
    }
}
