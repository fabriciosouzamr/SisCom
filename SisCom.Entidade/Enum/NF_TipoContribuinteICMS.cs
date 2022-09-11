using System.ComponentModel;
using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum NF_TipoContribuinteICMS
    {
        [Description("Contribuinte ICMS")]
        [XmlEnum("1")]
        ContribuinteICMS = 1,
        [Description("Contribuinte isento de inscrição")]
        [XmlEnum("2")]
        Isento = 2,
        [Description("Não Contribuinte")]
        [XmlEnum("9")]
        NaoContribuinte = 9
    }
}