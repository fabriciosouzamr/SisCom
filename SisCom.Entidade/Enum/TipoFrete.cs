using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoFrete
    {
        [Description("0-Contratação do Frete por conta do Remetente(CIF)")]
        ContratacaoFreteContaRemetente_CIF = 0,
        [Description("1-Contratação do Frete por conta do Destinatário(FOB)")]
        ContratacaoFreteContaDestinatario_FOB = 1,
        [Description("2-Contratação do Frete por conta de Terceiros")]
        ContratacaoFreteContaTerceiros = 2,
        [Description("3-Transporte Próprio por conta do Remetente")]
        TransporteProprioContaRemetente = 3,
        [Description("4-Transporte Próprio por conta do Destinatário")]
        TransporteProprioContaDestinatario = 4,
        [Description("9-Sem Ocorrência de Transporte")]
        SemOcorrenciaTransporte = 9,
    }
}
