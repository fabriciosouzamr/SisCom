using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum NF_TipoReferencia
    {
        [Description("Cliente")]
        Cliente = 1,
        [Description("Fornecedor")]
        Fornecedor = 2,
        [Description("NFC-e")]
        NFCe = 3
    }
}
