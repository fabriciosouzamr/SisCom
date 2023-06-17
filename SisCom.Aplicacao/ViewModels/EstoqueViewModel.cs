using SisCom.Entidade.Modelos;
using System;

namespace SisCom.Aplicacao.ViewModels
{
    public class EstoqueViewModel : BaseModelView
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
