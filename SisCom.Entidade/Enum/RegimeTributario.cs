using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum RegimeTributario
    {
        [Description("SIMPLES NACIONAL")]
        SimplesNacional = 1,
        [Description("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA")]
        SimplesNacional_ExcessoSublimiteReceitaBruta = 2,
        [Description("REGIME NORMAL")]
        RegimeNormal = 3,
        [Description("SIMPLES NACIONAL - MICROEMPREENDEDOR INDIVIDUAL (MEI)")]
        SimplesNacional_MicroempreendedorIndividual_MEI = 4
    }
}
