using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum NF_Status
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Cancelado")]
        Cancelado = 2,
        [Description("Finalizada")]
        Finalizada = 3,
        [Description("Denegada")]
        Denegada = 4,
        [Description("Inutilizada")]
        Inutilizada = 5,
        [Description("Transmitida")]
        Transmitida = 6
    }
}
