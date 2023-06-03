using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Funcoes._Classes
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
        public static bool ContainsInsensitive(string source, string search)
        {
            return (new CultureInfo("pt-BR").CompareInfo).IndexOf(source, search, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0;
        }
        public static string SomenteNumero(string valorInicial)
        {
            int number = 0;
            string retorno  = "";

            for (int i = 0; i < valorInicial.Length; i++)
            {
                if (int.TryParse(valorInicial[i].ToString(), out number))
                {
                    retorno += valorInicial[i];
                }
            }

            return retorno;
        }
        public static string PrimeiraMaiuscula(String strString)
        {

            string strResult = "";

            if (strString.Length > 0)
            {
                strResult += strString.Substring(0, 1).ToUpper();
                strResult += strString.Substring(1, strString.Length - 1).ToLower();
            }

            return strResult;
        }
        public static string PrimeiraMaiusculaTodasPalavras(String strString)
        {
            string strResult = "";
            bool booPrimeira = true;

            if (strString.Length > 0)
            {
                for (int intCont = 0; intCont <= strString.Length - 1; intCont++)
                {
                    if ((booPrimeira) && (!strString.Substring(intCont, 1).Equals(" ")))
                    {
                        strResult += strString.Substring(intCont, 1).ToUpper();
                        booPrimeira = false;
                    }
                    else
                    {
                        strResult += strString.Substring(intCont, 1).ToLower();

                        if (strString.Substring(intCont, 1).Equals(" "))
                        {
                            booPrimeira = true;
                        }
                    }
                }
            }

            return strResult;
        }
        public static string Telefone_Tratar(String strString)
        {
            strString = strString.Replace("/", "").Replace("\\", "");

            return strString;
        }

        public static Guid ConverterGuid(object guid)
        {
            try
            {
                return ConverterGuid(guid.ToString());
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static Guid ConverterGuid(string guid)
        {
            try
            {
                return Guid.Parse(guid);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static decimal ConverterDecimal(object valor)
        {
            try
            {
                return decimal.Parse(valor.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ConverterInt(object valor)
        {
            try
            {
                return int.Parse(valor.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double ConverterDouble(string valor)
        {
            try
            {
                return double.Parse(valor.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
