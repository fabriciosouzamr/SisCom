using System.ComponentModel;

namespace Funcoes.Enum
{
    public enum NF_TipoCertificado
    {
        [Description("A1 Repositorio")]
        TipoCertificadoDigital_A1Repositorio = 1,
        [Description("A1 Arquivo")]
        TipoCertificadoDigital_A1Arquivo = 2,
        [Description("A1 ByteArray")]
        TipoCertificadoDigital_A1ByteArray = 3,
        [Description("A3")]
        TipoCertificadoDigital_A3 = 4
    }
}
