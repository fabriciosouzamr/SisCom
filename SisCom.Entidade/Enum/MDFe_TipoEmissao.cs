using System.ComponentModel;
using System.Xml.Serialization;

namespace SisCom.Entidade.Enum
{
    public enum MDFe_TipoEmissao
    {
        [Description("Normal")]
        Normal = 1,
        [Description("Contingência")]
        Contingencia = 2
    }
}
