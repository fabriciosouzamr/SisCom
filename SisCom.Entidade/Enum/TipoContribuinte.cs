using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum TipoContribuinte
    {
        [Description("1 - Contribuinte ICMS")]
        ContribuinteICMS = 1,
        [Description("2 - Contribuinte Isento de Inscrição")]
        ContribuinteIsentoInscricao = 2,
        [Description("9 - Não Contribuinte")]
        NaoContribuinte = 9
    }
}
