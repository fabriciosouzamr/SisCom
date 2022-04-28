using System;
using System.Globalization;

namespace Funcoes._Classes
{
    public static class Valor
    {
        public static string Formatar(int Valor)
        {
            return Formatar((double)Valor);
        }
        public static string Formatar(decimal Valor)
        {
            return Formatar((double)Valor);
        }
        public static string Formatar(double Valor)
        {
            string Ret = "";

            try
            {
                Ret = Valor.ToString("C2", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                Ret = 0.ToString("C2", CultureInfo.CurrentCulture);
            }

            return Ret;
        }

        public static decimal Percentagem(Decimal Valor, Decimal Percentual)
        {
            if (Funcao.NuloParaValorD(Valor) == 0)
            {
                return 0;
            }
            else
            {
                return Valor * Funcao.NuloParaValorD(Percentual) / 100;
            }
        }
    }
}
