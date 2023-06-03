﻿using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class Arquivo
    {
        public static string[] CarregarArquivosXML()
        {
            string[] filePath = null;

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
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileNames;
                    }
                }
            }
            catch (Exception)
            {
            }

            return filePath;
        }

        public static string CarregarArquivoXML()
        {
            return CarregarArquivo("Selecionar o XML", "XML|*.XML");
        }

        public static string CarregarArquivoMSAccess()
        {
            return CarregarArquivo("Selecionar o Banco de Dados", "Banco de Dados|*.mdb");
        }

        public static string CarregarArquivo(string title, string filter)
        {
            var filePath = string.Empty;

            try
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Application.StartupPath;
                    openFileDialog.Title = title;
                    openFileDialog.Filter = filter;
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Multiselect = false;

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
        public static string Diretorio_Tratar(string sPath)
        {
            if (Strings.Right(sPath.Trim(), 1) != @"\")
                return sPath.Trim() + @"\";
            else
                return sPath.Trim();
        }
        public static string DiretorioSistema_RemoverPath(string sArquivo)
        {
            if (Strings.Trim(sArquivo) == "" | sArquivo == null)
                return sArquivo;
            else if (Strings.Mid(sArquivo, 1, Strings.Len(Declaracoes.Aplicacao_PathRepositorioArquivo)) == Declaracoes.Aplicacao_PathRepositorioArquivo)
                return Strings.Mid(sArquivo, Strings.Len(Diretorio_Tratar(Declaracoes.Aplicacao_PathRepositorioArquivo)) + 1);
            else
                return sArquivo;
        }

        public static string DiretorioSistema_AdicionarPath(string sArquivo)
        {
            if (Strings.Trim(sArquivo) == "" | Declaracoes.Aplicacao_PathRepositorioArquivo == "")
                return "";
            else if (Strings.Mid(sArquivo, Strings.Len(Declaracoes.Aplicacao_PathRepositorioArquivo)) == Declaracoes.Aplicacao_PathRepositorioArquivo)
                return sArquivo;
            else
                return Diretorio_Tratar(Declaracoes.Aplicacao_PathRepositorioArquivo) + sArquivo;
        }

        public static string CriarArquivoTexto(string texto, string nomearquivo = "temporario.txt")
        {
            string arquivo = Path.Combine(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria , nomearquivo);

            if (File.Exists(arquivo)) File.Delete(arquivo);

            StreamWriter valor = new StreamWriter(arquivo, true, Encoding.ASCII);

            valor.Write(texto);

            valor.Close();
            valor.Dispose();

            return arquivo;
        }
    }
}