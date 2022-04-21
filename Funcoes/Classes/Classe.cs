using Funcoes._Entity;
using System;

namespace Funcoes._Classes
{
    public static class Funcao
    {
        public static bool Nulo(object Valor)
        {
            bool ret = false;

            if (Valor == null)
            {
                ret = true;
            }
            else if (Valor == DBNull.Value)
            {
                Valor = true;
            }

            return ret;
        }
        public static object SeNulo(object Valor, object Retorno)
        {
            if (Nulo(Valor))
            {
                Valor = Retorno;
            }

            return Valor;
        }
        public static bool NuloString(object Valor)
        {
            bool ret = false;

            if (Nulo(Valor))
            {
                ret = true;
            }
            else if (String.IsNullOrEmpty((string)Valor))
            {
                ret = true;
            }

            return ret;
        }
        public static bool NuloData(object Valor)
        {
            bool ret = false;

            if (Nulo(Valor))
            {
                ret = true;
            }
            else if (((DateTime)Valor == new DateTime(1753,1,1)) || ((DateTime)Valor == new DateTime()) || ((DateTime)Valor == DateTime.MinValue))
            {
                ret = true;
            }

            return ret;
        }
        public static string NuloParaString(object Valor)
        {
            return SeNulo(Valor, "").ToString();
        }
        public static string? StringVazioParaNulo(string Valor)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                return null;
            }
            else
            {
                return Valor;
            }
        }
        public static int NuloParaNumero(object Valor)
        {
            return Convert.ToInt32(SeNulo(Valor, 0));
        }
        public static double NuloParaValor(object Valor)
        {
            return Convert.ToDouble(SeNulo(Valor, 0));
        }
        public static DateTime NuloParaData(object Valor, Nullable<DateTime> Padrao = null)
        {
            if (NuloData(Valor))
            {
                if (Padrao == null)
                {
                    Valor = new DateTime();
                }
                else
                {
                    Valor = Padrao;
                }
            }

            return (DateTime)Valor;
        }
        public static DateTime? DataVazioParaNulo(DateTime Valor)
        {
            if (NuloData(Valor))
            {
                return null;
            }
            else
            {
                return Valor;
            }
        }
        public static bool NuloEntity(Entity entity)
        {
            bool ret = false;

            if (entity == null)
            {
                ret = true;
            }
            else if (entity.Id == Guid.Empty)
            {
                ret = true;
            }

            return ret;
        }
    }
} 