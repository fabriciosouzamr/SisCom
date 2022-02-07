using SisCom.Aplicacao.Classes;
using System;
using System.Windows.Forms;

public static class CaixaMensagem
{
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
