using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class Arquivo
    {
        public static string CarregarArquivoXML()
        {
            var filePath = string.Empty;

            try
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Application.StartupPath;
                    openFileDialog.Title = "Selecionar o XML";
                    openFileDialog.Filter = "XML|*.XML";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception)
            {
            }

            return filePath;
        }
    }
}
