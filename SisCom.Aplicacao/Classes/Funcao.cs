﻿using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
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
                    if (textRG != null) textRG.Enabled = false;
                    textInscricaoEstadual.Enabled = false;
                    break;
                default:
                    if (textRG != null) textRG.Enabled = true;
                    if (textRG != null) textRG.Text = "";
                    textInscricaoEstadual.Enabled = true;
                    textInscricaoEstadual.Text = "";
                    break;
            }
            if (comboContribuinte != null)
            {
                switch (tipoPessoaCliente)
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

        public static void dados_Empresa_Carregar()
        {
            Declaracoes.dados_Empresa_Id = Guid.Parse("4BF355E6-49FC-4CA4-CEF6-08DA480E47B4");
            Declaracoes.dados_Empresa_EstadoId = Guid.Parse("A4E895E8-D411-4944-992C-A6871293DA1C");
        }
    }
}
