using System.Collections.Generic;
using System.Diagnostics;

namespace SisCom.Aplicacao.Classes
{
    public static class Processo
    {
        public static List<string> Executar(string fileName, string arguments)
        {
            List<string> retorno = new List<string>();
            Process processo = new Process();

            try
            {
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
            }
            catch (System.Exception Ex)
            {
                var erro = Ex.Message;
            }

            return retorno;
        }
    }
}
