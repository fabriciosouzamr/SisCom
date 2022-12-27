using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoRodado
    {
        [XmlEnum("01 - Truck")]
        Truck = 1,
        [XmlEnum("02 - Toco")]
        Toco = 2,
        [XmlEnum("03 - Cavalo Mecânico")]
        CavaloMecanico = 3,
        [XmlEnum("04 - VAN")]
        VAN = 4,
        [XmlEnum("05 - Utilitário")]
        Utilitario = 5,
        [XmlEnum("06 - Outros")]
        Outros = 6
    }
}