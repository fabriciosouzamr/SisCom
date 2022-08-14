using Funcoes._Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Entidade.Modelos
{
    public class VendaMercadoria : Entity
    {
		public Venda Venda { get; set; }
		public Mercadoria Mercadoria { get; set; }
		public UnidadeMedida UnidadeMedida { get; set; }
		public decimal Quantidade { get; set; }
		public decimal Preco { get; set; }
		public decimal Total { get; set; }

		/* EF Relation */
		public Guid? VendaId { get; set; }
		public Guid? MercadoriaId { get; set; }
		public Guid? UnidadeMedidaId { get; set; }
	}
}
