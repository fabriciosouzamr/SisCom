using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoCarroceria
    {
        [XmlEnum("00 - não aplicável")]
        NaoAplicavel = 0,
        [XmlEnum("01 - Aberta")]
        Aberta = 1,
        [XmlEnum("02 - Fechada/Baú")]
        FechadaBau = 2,
        [XmlEnum("03 - Granelera")]
        Granelera = 3,
        [XmlEnum("04 - Porta Container")]
        PortaContainer = 4,
        [XmlEnum("05 - Sider")]
        Sider = 5
    }
}
