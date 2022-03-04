using Funcoes._Enum;
using System;
using System.Windows.Forms;

public static class Texto_MaskedTextBox
{
	public static void FormatarTipoPessoa(TipoPessoaCliente TipoPessoa, MaskedTextBox Texto)
	{
		switch (TipoPessoa)
        {
			case TipoPessoaCliente.Fisica:
				Texto.Text = "";
				Texto.Mask = "000,000,000-00";
				break;
			case TipoPessoaCliente.Juridica:
				Texto.Text = "";
				Texto.Mask = "00,000,000/0000-00"; ;
				break;
			case TipoPessoaCliente.Especial:
				Texto.Text = "";
				Texto.Mask = "";
				break;
		}
	}

	public static void Limpar(MaskedTextBox Texto)
	{
		Texto.Text = "";
		Texto.Mask = "";
	}
}
