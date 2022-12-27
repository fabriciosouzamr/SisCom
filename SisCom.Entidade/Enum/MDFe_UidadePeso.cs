using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_UidadePeso
    {
        [XmlEnum("01 – KG")]
        KG = 1,
        [XmlEnum("02 - TON")]
        TON = 2
    }
}
