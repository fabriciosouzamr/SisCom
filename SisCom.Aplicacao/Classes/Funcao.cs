using Funcoes._Enum;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class FuncaoInterna
    {
        public static string Texto(string sMensagem, string[] sParametro = null)
        {
            int iCont = 0;
            string sAux = sMensagem;

            if (sParametro != null)
            {
                foreach (string sTexto in sParametro)
                {
                    iCont++;
                    sMensagem = sMensagem.Replace("[Param" + iCont.ToString("00") + "]", sTexto);
                }

                sAux = sMensagem;
            }

            return sAux;
        }

        public static void comboCidade_Posicionar(ComboBox comboCidade, string Texto)
        {
            foreach (CidadeComboViewModel View in comboCidade.Items)
            {
                if (Funcoes._Classes.Texto.ContainsInsensitive(View.Nome, Texto))
                {
                    comboCidade.SelectedValue = View.Id;
                    return;
                }
            }
        }

       public static void TipoPessoaCliente_Tratar(TipoPessoaCliente tipoPessoaCliente, 
                                                   ComboBox comboContribuinte,
                                                   TextBox textRG, 
                                                   TextBox textInscricaoEstadual)
        {
            switch(tipoPessoaCliente)
            {
                case TipoPessoaCliente.Especial:
                    textRG.Enabled = false;
                    textInscricaoEstadual.Enabled = false;
                    break;
                default:
                    textRG.Enabled = true;
                    textRG.Text = "";
                    textInscricaoEstadual.Enabled = true;
                    textInscricaoEstadual.Text = "";
                    break;
            }
            switch(tipoPessoaCliente)
            {
                case TipoPessoaCliente.Especial:
                case TipoPessoaCliente.Fisica:
                    comboContribuinte.SelectedValue = TipoContribuinte.NaoContribuinte;
                    break;
                default:
                    comboContribuinte.SelectedValue = TipoContribuinte.ContribuinteICMS;
                    break;
            }
        }

        public static void TipoContribuinte_Tratar(TipoContribuinte tipoContribuinte,
                                                   TextBox textInscricaoEstadual)
        {
            switch (tipoContribuinte)
            {
                case TipoContribuinte.ContribuinteICMS:
                    if (textInscricaoEstadual.Text.Trim().ToUpper() == "ISENTO")
                        textInscricaoEstadual.Text = "";
                    break;
                case TipoContribuinte.ContribuinteIsentoInscricao :
                    textInscricaoEstadual.Text = "ISENTO";
                    break;
                case TipoContribuinte.NaoContribuinte:
                    textInscricaoEstadual.Text = "";
                    break;
            }
        }

        public static bool NuloModelView(BaseModelView baseModelView)
        {
            bool ret = false;

            if (baseModelView == null)
            {
                ret = true;
            }
            else if (baseModelView.Id == Guid.Empty)
            {
                ret = true;
            }

            return ret;
        }
    }
}
