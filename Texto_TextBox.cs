using System;
using System.Windows.Forms;

public class Texto_TextBox
{
    public static bool ValidaVazio(TextBox text, string Mensagem)
    {
        bool Valido = false;

        if (text.Text.Trim() == "")
        {
            Valido = true;
        }
        else
        {
            CaixaMensagem.Informacao(Mensagem);
        }

        return Valido;
    }
}
