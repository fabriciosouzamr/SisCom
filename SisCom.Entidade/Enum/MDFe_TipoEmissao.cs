using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoEmissao
    {
        [XmlEnum("1")]
        Normal = 1,
        [XmlEnum("2")]
        Contingencia = 2
    }
}
