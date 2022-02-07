using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanfeSharp
{
    public class FaturaViewModel
    {
        /// <summary>
        /// <para>Número da Fatura</para>
        /// <para>Tag nFat</para>
        /// </summary>
        public String Numero { get; set; }

        /// <summary>
        /// <para>Valor Original da Fatura</para>
        /// <para>Tag vOrig</para>
        /// </summary>
        public String ValorOriginal { get; set; }

        /// <summary>
        /// <para>Valor de Desconto da Fatura</para>
        /// <para>Tag vDesc</para>
        /// </summary>
        public String ValorDesconto { get; set; }

        /// <summary>
        /// <para>Valor Líquido da Fatura</para>
        /// <para>Tag vLiq</para>
        /// </summary>
        public String ValorLiquido { get; set; }
    }
}
