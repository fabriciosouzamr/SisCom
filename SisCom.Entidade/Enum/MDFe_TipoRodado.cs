using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoRodado
    {
        [Description("01 - Truck")]
        Truck = 1,
        [Description("02 - Toco")]
        Toco = 2,
        [Description("03 - Cavalo Mecânico")]
        CavaloMecanico = 3,
        [Description("04 - VAN")]
        VAN = 4,
        [Description("05 - Utilitário")]
        Utilitario = 5,
        [Description("06 - Outros")]
        Outros = 6
    }
}