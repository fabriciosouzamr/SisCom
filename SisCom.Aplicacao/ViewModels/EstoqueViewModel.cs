using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.ViewModels
{
    internal class EstoqueViewModel : BaseModelView
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
