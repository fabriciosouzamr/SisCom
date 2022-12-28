using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoProprietario
    {
        [Description("0-TAC Agregado")]
        TACAgregado = 1,
        [Description("1-TAC Independente")]
        TACIndependente = 2,
        [Description("2 – Outros")]
        Outros = 3
    }
}
