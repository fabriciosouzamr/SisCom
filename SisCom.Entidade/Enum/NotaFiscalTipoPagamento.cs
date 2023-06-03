using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Entidade.Enum
{
    public enum NotaFiscalTipoPagamento
    {
        [Description("Pagamento à vista")]
        PagamentoAVista = 0,
        [Description("Pagamento a prazo")]
        PagamentoAPrazo = 1,
        [Description("Outros")]
        Outros = 2
    }
}
