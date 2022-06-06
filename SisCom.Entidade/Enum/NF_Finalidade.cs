using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum NF_Finalidade
    {
        [Description("Normal")]
        Normal = 1,
        [Description("Complementar")]
        Complementar = 2,
        [Description("Ajuste")]
        Ajuste = 1,
        [Description("Devolucao")]
        Devolucao = 2
    }
}
