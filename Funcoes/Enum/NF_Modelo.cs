using System.ComponentModel;

namespace Funcoes.Enum
{
    public enum NF_Modelo
    {
        [Description("01 Nota Fiscal")]
        NotaFiscal = 1,
        [Description("06 Nota Fiscal/Conta de Energia Elétrica")]
        NotaFiscalContaEnergia = 6,
        [Description("21 Nota Fiscal de Serviço de Comunicação")]
        NotaFiscalServicoComunicacao = 21,
        [Description("22 Nota Fiscal de Serviço de Telecomunicação")]
        NotaFiscalServicoTelecomunicacao = 22,
        [Description("55 Nota Fiscal Eletrônica")]
        NotaFiscalEletronica = 55,
        [Description("00 Nota Fiscal de Serviço")]
        NotaFiscalServico = 0
    }
}
