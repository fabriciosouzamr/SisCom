using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Classes
{
    public static class FuncaoInterna
    {
        public static string Texto(string sMensagem, string[] sParametro = null)
        {
            int iCont = 0;
            string sAux = sMensagem;

            if (sParametro != null)
            {
                foreach (string sTexto in sParametro)
                {
                    iCont++;
                    sMensagem = sMensagem.Replace("[Param" + iCont.ToString("00") + "]", sTexto);
                }

                sAux = sMensagem;
            }

            return sAux;
        }
    }
}
