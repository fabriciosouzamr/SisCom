using System;
using System.Collections.Generic;
using System.Text;

namespace Funcoes
{
    public static class Texto
    {
        public static string NuloString(object valor)
        {
            string retorno = "";

            if (valor != null)
            {
                retorno = valor.ToString();
            }

            return retorno;
        }
    }
}
