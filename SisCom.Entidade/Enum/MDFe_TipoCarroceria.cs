using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoCarroceria
    {
        [Description("00 - não aplicável")]
        NaoAplicavel = 0,
        [Description("01 - Aberta")]
        Aberta = 1,
        [Description("02 - Fechada/Baú")]
        FechadaBau = 2,
        [Description("03 - Granelera")]
        Granelera = 3,
        [Description("04 - Porta Container")]
        PortaContainer = 4,
        [Description("05 - Sider")]
        Sider = 5
    }
}
