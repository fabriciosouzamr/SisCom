using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_Status
    {
        [Description("Criado")]
        Criado = 1,
        [Description("Validado")]
        Validado = 2,
        [Description("Transmitido")]
        Transmitido = 3,
        [Description("Cancelado")]
        Cancelado = 4,
        [Description("Autorizado")]
        Autorizado = 5
    }
}
