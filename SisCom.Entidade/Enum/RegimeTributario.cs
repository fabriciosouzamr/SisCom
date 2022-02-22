using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum RegimeTributario
    {
        [Description("NORMAL")]
        Normal = 1,
        [Description("SIMPLES NACIONAL")]
        SimplesNacional = 2,
        [Description("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA")]
        SimplesNacional_ExcessoSublimiteReceitaBruta = 3
    }
}
