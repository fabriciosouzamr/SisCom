using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalSaidaMercadoria : Entity
    {
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public TabelaNCM TabelaNCM { get; set; }
        public TabelaCST_CSOSN TabelaCST_CSOSN { get; set; }
        public TabelaCFOP TabelaCFOP { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public float Quantidade { get; set; }
        public float PrecoUnitario { get; set; }
        public float PrecoTotal { get; set; }
        public float PercentualICMS { get; set; }
        public float PercentualIPI { get; set; }
        public float PercentualFrete { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? MercadoriaId { get; set; }
        public Guid? TabelaNCMId { get; set; }
        public Guid? TabelaCST_CSOSNId { get; set; }
        public Guid? TabelaCFOPId { get; set; }
        public Guid? UnidadeMedidaId { get; set; }
    }
}
