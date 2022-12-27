using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoProprietario
    {
        [XmlEnum("0-TAC Agregado")]
        TACAgregado = 1,
        [XmlEnum("1-TAC Independente")]
        TACIndependente = 2,
        [XmlEnum("2 – Outros")]
        Outros = 3
    }
}
