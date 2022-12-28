using System.ComponentModel;
using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoTransportador
    {
        [Description("Prestador de Serviço de Transporte")]
        PrestadorServicoDeTransporte = 1,
        [Description("Transportador de Carga Própria")]
        TransportadorCargaPropria = 2
    }
}
