using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum Veiculo_TipoCarroceria
    {
        [Description("Não aplicável")]
        NaoAplicavel = 1,
        [Description("01 - Aberta")]
        Aberta = 2,
        [Description("02 - Fechada/Baú")]
        FechadaBau = 3,
        [Description("03 - Granelera")]
        Granelera = 4,
        [Description("04 - Porta Container")]
        PortaContainer = 5,
        [Description("05 - Sider")]
        Sider = 6
    }
}
