using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class VendaMercadoriaViewModel
	{
        [Key]
		public Guid Id { get; set; }
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