using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoTransportador
    {
        [XmlEnum("1")]
        PrestadorServicoDeTransporte = 1,
        [XmlEnum("2")]
        TransportadorCargaPropria = 2
    }
}
