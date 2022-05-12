using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Threading;

namespace Funcoes.Enum
{
    public static class Arquivos
    {
		public static void ExcluirArquivosDiretorio(string CaminhoDiretorio, bool DeletarSomenteNoDiretorio = false)
		{
			try
			{
				if (Operators.CompareString(CaminhoDiretorio, "", TextCompare: false) == 0)
				{
					return;
				}
				CaminhoDiretorio += ((Operators.CompareString(Strings.Right(CaminhoDiretorio, 1), "\\", TextCompare: false) == 0) ? "" : "\\");
				if (!Directory.Exists(CaminhoDiretorio))
				{
					return;
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(CaminhoDiretorio);
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				foreach (DirectoryInfo directoryInfo2 in directories)
				{
					directoryInfo2.Delete(recursive: true);
				}
				if (!DeletarSomenteNoDiretorio)
				{
					FileInfo[] files = directoryInfo.GetFiles();
					foreach (FileInfo fileInfo in files)
					{
						fileInfo.Delete();
					}
				}
				directoryInfo = null;
				Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}
}
