using System.ComponentModel;

namespace SisCom.Entidade.Enum
{
    public enum NF_IndicaPresenca
    {
        [Description("Não se aplica")]
        NaoSeAplica = 1,
        [Description("Operação presencial")]
        OperacaoPresencial = 2,
        [Description("Operação não presencial, pela Internet")]
        OperacaoNaoPresencial_PelaInternet = 3,
        [Description("Operação não presencial, pela Teleatendimento")]
        OperacaoNaoPresencial_PelaTeleatendimento = 4,
        [Description("Operação não presencial, Outros")]
        OperacaoNaoPresencial_Outros = 5
    }
}
