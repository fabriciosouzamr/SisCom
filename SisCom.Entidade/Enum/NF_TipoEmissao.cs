using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum NF_TipoEmissao
    {
        [Description("1 - Normal")]
        Normal = 1,
        [Description("5 - Contingência com formulário de Segurança")]
        ContingenciaComFormularioSeguranca = 5,
        [Description("9 - Contingência offline da NFC-e")]
        ContingenciaOfflineNFCe = 9
    }
}
