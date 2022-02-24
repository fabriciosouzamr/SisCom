using Funcoes.Interfaces;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public class formBuscarCNPJDados
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Guid Estado { get; set; }
        public Guid Cidade { get; set; }
    }

    public static class Forms
    {
        public static void formBuscarCNPJCarregar(IServiceProvider serviceProvider, 
                                                  IServiceScopeFactory<MeuDbContext> dbCtxFactory,
                                                  TextBox textCNPJ,
                                                  TextBox textRazaoSocial, 
                                                  TextBox textNome,
                                                  TextBox textEndrecoCEP,
                                                  TextBox textEndrecoLogradouro,
                                                  TextBox textEndrecoNumero,
                                                  TextBox textEndrecoComplmento,
                                                  TextBox textEndrecoBairro,
                                                  ComboBox comboEndrecoUF,
                                                  ComboBox comboEndrecoCidade)
        {
            using (frmCadastroBuscarCNPJ form = new frmCadastroBuscarCNPJ(serviceProvider, dbCtxFactory))
            {
                form.ShowDialog();
                
                if (form.formBuscarCNPJDados != null )
                {
                    textCNPJ.Text = form.formBuscarCNPJDados.RazaoSocial;
                    textRazaoSocial.Text = form.formBuscarCNPJDados.RazaoSocial;
                    textNome.Text = form.formBuscarCNPJDados.NomeFantasia;
                    textEndrecoCEP.Text = form.formBuscarCNPJDados.CEP;
                    textEndrecoLogradouro.Text = form.formBuscarCNPJDados.Logradouro;
                    textEndrecoNumero.Text = form.formBuscarCNPJDados.Numero;
                    if (textEndrecoComplmento != null) { textEndrecoComplmento.Text = form.formBuscarCNPJDados.Complemento; }
                    textEndrecoBairro.Text = form.formBuscarCNPJDados.Bairro;
                    comboEndrecoUF.SelectedValue = form.formBuscarCNPJDados.Estado;
                    comboEndrecoCidade.SelectedValue = form.formBuscarCNPJDados.Cidade;
                }
                else
                {
                    CaixaMensagem.Informacao("CNPJ não encontrado");
                }
            }
        }
    }
}
