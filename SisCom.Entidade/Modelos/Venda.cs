using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
	public class Venda : Entity
	{
        public int Codigo { get; set; }
        public NF_TipoNotaFiscal TipoNotaFiscal { get; set; }
        public DateTime DataVenda { get; set; }
		public Pessoa Cliente { get; set; }
		public virtual Funcionario Vendedor { get; set; }
		public Empresa Empresa { get; set; }
		public TabelaOrigemVenda TabelaOrigemVenda { get; set; }
		public decimal ValorFrete { get; set; }
		public decimal ValorDesconto { get; set; }
		public decimal ValorTotal { get; set; }
		public string Observacao { get; set; }
		public Transportadora Transportadora { get; set; }
		public Motorista Motorista { get; set; }
		public VeiculoPlaca VeiculoPlaca01 { get; set; }
		public VeiculoPlaca VeiculoPlaca02 { get; set; }
		public VeiculoPlaca VeiculoPlaca03 { get; set; }
		public string EnderecoEntrega { get; set; }
		public bool PosuiEntrega { get; set; }
        public string NumeroPedido { get; set; }

        /* EF Relation */
        public Guid? ClienteId { get; set; }
		public Guid? VendedorId { get; set; }
		public Guid? EmpresaId { get; set; }
		public Guid? TabelaOrigemVendaId { get; set; }
		public Guid? TransportadoraId { get; set; }
		public Guid? MotoristaId { get; set; }
		public Guid? VeiculoPlaca01Id { get; set; }
		public Guid? VeiculoPlaca02Id { get; set; }
		public Guid? VeiculoPlaca03Id { get; set; }
	}
}