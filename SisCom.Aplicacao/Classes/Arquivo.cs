using System;
using System.IO;
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

        public static string SalvarAquivoXML(string sNome, string sXML)
        {
            //verifica se existe algo digitado na caixa de texto
            if (string.IsNullOrEmpty(sXML))
            {
                CaixaMensagem.Informacao("Arquivo XML vazio");
                return "";
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Salvar Arquivo XML";
                saveFileDialog.Filter = "XML|*.XML";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.FileName = sNome;
                saveFileDialog.DefaultExt = ".XML";
                saveFileDialog.RestoreDirectory = true;

                DialogResult resultado = saveFileDialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);

                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(sXML);
                    writer.Close();

                    return saveFileDialog.FileName;
                }
                else
                {
                    CaixaMensagem.Informacao("Operação cancelada");
                    return "";
                }
            }
        }

        public static string SelecionarDiretorio()
        {
            string sDiretorio = "";

            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sDiretorio = openFileDialog.SelectedPath;
                }
            }

            return sDiretorio;
        }

        public static string DiretorioMontarCaminhoArquivo(string sDiretorio, string sArquivo)
        {
            return sDiretorio + "\\" + sArquivo;
        }

        public static string ArquivoTemporario(string sArquivo)
        {
            return DiretorioMontarCaminhoArquivo(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria, sArquivo);
        }
    }
}
