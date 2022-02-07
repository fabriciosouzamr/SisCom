using DanfeSharp.Modelo;
using System;
using System.Globalization;
using System.Linq;

namespace DanfeSharp.Blocos
{
    internal class BlocoDuplicataFatura : BlocoBase
    {
        public override string Cabecalho => "FATURA: Número: " + ViewModel.Duplicatas[0].Fatura.Numero +
                                                   " Valor Orig: " + String.Format("{0:c}", ViewModel.Duplicatas[0].Fatura.ValorOriginal) +
                                                   " Desc: " + String.Format("{0:c}", ViewModel.Duplicatas[0].Fatura.ValorDesconto) +
                                                   " Valor Líq: " + String.Format("{0:c}", ViewModel.Duplicatas[0].Fatura.ValorLiquido);
        public override PosicaoBloco Posicao => PosicaoBloco.Topo;

        public BlocoDuplicataFatura(DanfeViewModel viewModel, Estilo estilo) : base(viewModel, estilo)
        {
            var de = viewModel.Duplicatas.Select(x => new Duplicata(estilo, x)).ToList();
            var eh = de.First().Height;

            int numeroElementosLinha = ViewModel.IsPaisagem ? 7 : 6;
            int i = 0;

            while (i < de.Count)
            {
                FlexibleLine fl = new FlexibleLine(Width, eh);

                int i2;
                for (i2 = 0; i2 < numeroElementosLinha && i < de.Count; i2++, i++)
                {
                    fl.ComElemento(de[i]);
                }

                for(; i2 < numeroElementosLinha; i2++)                
                    fl.ComElemento(new ElementoVazio());               

                fl.ComLargurasIguais();
                MainVerticalStack.Add(fl);
            }
        }
    }
}
