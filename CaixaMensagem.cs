using Funcoes._Classes;
using SisCom.Aplicacao.Classes;
using System;
using System.Windows.Forms;

public static class CaixaMensagem
{
	public static void Informacao(string local, Exception ex)
	{
        string sMensagem = $"{local} - {ex.Message}";

        try
        {

            if (ex.InnerException == null)
            {
                if (!String.IsNullOrWhiteSpace(ex.StackTrace))
                {
                    sMensagem = $"{sMensagem} ({ex.StackTrace})";
                }
            }
            else
                sMensagem = $"{sMensagem} ({ex.InnerException.Message})";
            MessageBox.Show(sMensagem);
        }
        catch (Exception ex1)
        {
            MessageBox.Show($"{local} - {ex1.Message}");
        }
    }
    public static void Informacao(string sMensagem)
    {
        MessageBox.Show(sMensagem);
    }

    public static bool Perguntar(string sMensagem)
    {
		return (MessageBox.Show(sMensagem, "", MessageBoxButtons.YesNo) == DialogResult.Yes);
    }

	public static bool PerguntarTexto(string sTexto, string[] sParametro = null)
    {
		return CaixaMensagem.Perguntar(FuncaoInterna.Texto(sTexto, sParametro));

	}
}
