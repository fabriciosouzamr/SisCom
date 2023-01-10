using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_Status
    {
        [Description("Criado")]
        Criado = 1,
        [Description("Validado")]
        Validado = 2,
        [Description("Autorizado")]
        Autorizado = 3,
        [Description("Cancelado")]
        Cancelado = 4
    }
}
