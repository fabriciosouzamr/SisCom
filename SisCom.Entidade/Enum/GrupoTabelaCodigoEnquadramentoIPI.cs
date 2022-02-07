using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum GrupoTabelaCodigoEnquadramentoIPI
    {
        [Description("Imunidade")]
        Imunidade = 1,
        [Description("Suspensão")]
        Suspensao = 2,
        [Description("Isenção")]
        Isencao = 3,
        [Description("Redução")]
        Reducao = 4,
        [Description("Outros")]
        Outros = 5
    }
}
