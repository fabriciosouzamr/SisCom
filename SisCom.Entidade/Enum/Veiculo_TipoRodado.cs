using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum Veiculo_TipoRodado
    {
        [Description("Não aplicável")]
        NaoAplicavel = 1,
        [Description("01 - Truck")]
        Truck = 2,
        [Description("02 - Toco")]
        Toco = 3,
        [Description("03 - Cavalo Mecânico")]
        CavaloMecanico =4,
        [Description("04 - VAN")]
        VAN = 5,
        [Description("05 - Utilitário")]
        Utilitario = 6,
        [Description("06 - Outros")]
        Outros = 7
    }
}
