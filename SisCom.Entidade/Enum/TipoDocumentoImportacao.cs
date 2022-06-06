using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoDocumentoImportacao
    {
        [Description("0-Declaração de importação")]
        DeclaracaoImportacao = 1,
        [Description("1-Declaração simplificada de importação")]
        DeclaraçãoSimplificadaImportacao = 2,
    }
}
