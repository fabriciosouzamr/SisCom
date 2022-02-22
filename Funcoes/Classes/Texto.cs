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
    }
}
