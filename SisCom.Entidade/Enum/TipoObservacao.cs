using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoObservacao
    {
        [Description("INFORMAÇÃO COMPLEMENTAR")]
        INFORMACAO_COMPLEMENTAR = 1,
        [Description("LANÇAMENTO FISCAL")]
        LANCAMENTO_FISCAL = 2
    }
}