using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoOperacaoCFOP
    {
        [Description("Entrada dentro do Estado")]
        EntradaDentroEstado = 1,
        [Description("Entrada fora do Estado")]
        EntradaForaEstado = 2,
        [Description("Entrada do Exterior")]
        EntradaExterior = 3,
        [Description("Saida dentro do Estado")]
        SaidaDentroEstado = 5,
        [Description("Saida fora do Estado")]
        SaidaForaEstado = 6,
        [Description("Saida do Exterior")]
        SaidaExterior = 7,

    }
}
