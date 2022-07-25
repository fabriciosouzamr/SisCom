using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Classes
{
    public static class Processo
    {
        public static List<string> Executar(string fileName, string arguments)
        {
            List<string> retorno = new List<string>();
            Process processo = new Process();

            processo.StartInfo.FileName = fileName;
            processo.StartInfo.Arguments = arguments;
            processo.StartInfo.RedirectStandardOutput = true;
            processo.StartInfo.RedirectStandardError = true;
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.CreateNoWindow = true;
            processo.Start();
            processo.WaitForInputIdle();
            processo.WaitForExit();

            string linha = "";

            while (true)
            {
                linha = processo.StandardOutput.ReadLine();

                if (linha is null) { break; } else { retorno.Add(linha); }
            }

            return retorno;
        }
    }
}
