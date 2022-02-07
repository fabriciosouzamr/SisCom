using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Funcoes.Classes
{
    public static class Valor
    {
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
    }
}
