using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoLancamentoEstoque
    {
        [Description("Movimentação")]
        Movimentacao,
        [Description("Ajuste")]
        Ajuste,
        [Description("Balanço")]
        Balanco
    }
}
