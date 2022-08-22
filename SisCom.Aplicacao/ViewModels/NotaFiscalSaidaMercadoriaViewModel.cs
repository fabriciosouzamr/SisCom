using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalSaidaMercadoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public TabelaNCM TabelaNCM { get; set; }
        public TabelaCST_CSOSN TabelaCST_CSOSN { get; set; }
        public TabelaCFOP TabelaCFOP { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public string Descricao { get; set; }
        public float Quantidade { get; set; }
        public float PrecoUnitario { get; set; }
        public float PrecoTotal { get; set; }
        public float PercentualICMS { get; set; }
        public float PercentualIPI { get; set; }
        public float PercentualFrete { get; set; }

        public decimal ValorBaseCalculo { set; get; }
        public decimal AliquotaICMS { set; get; }
        public decimal ValorICMS { set; get; }
        public decimal AliquotaReducao { set; get; }
        public decimal ValorBaseSubstituicaoTributaria { set; get; }
        public decimal ValorSubstituicaoTributaria { set; get; }
        public decimal ValorAdicional { set; get; }
        public decimal AliquotaAdicional { set; get; }
        public TabelaCST_IPI TabelaCST_IPI { set; get; }
        public decimal ValorBaseIPI { set; get; }
        public decimal AliquotaIPI { set; get; }
        public decimal ValorIPI { set; get; }
        public TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS_PIS { set; get; }
        public decimal AliquotaPIS { set; get; }
        public TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS_PISCOFINS { set; get; }
        public decimal AliquotaCOFINS { set; get; }
        public decimal BaseCalculoFCP { set; get; }
        public decimal AliquotaFCP { set; get; }
        public decimal ValorFCP { set; get; }
        public string NumeroPedidoCompra { set; get; }
        public string ItemPedidoCompra { set; get; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? MercadoriaId { get; set; }
        public Guid? TabelaNCMId { get; set; }
        public Guid? TabelaCST_CSOSNId { get; set; }
        public Guid? TabelaCFOPId { get; set; }
        public Guid? UnidadeMedidaId { get; set; }
        public Guid? TabelaCST_IPIId { set; get; }
        public Guid? TabelaCST_PIS_COFINS_PISId { set; get; }
        public Guid? TabelaCST_PIS_COFINS_PISCOFINSId { set; get; }
    }
}