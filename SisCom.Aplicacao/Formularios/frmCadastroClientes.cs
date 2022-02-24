using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroClientes : Form
    {
        FormMain FormMain;

        public frmCadastroClientes(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            InitializeComponent();
            FormMain = new FormMain(serviceProvider, dbCtxFactory);
        }

        private void botaoFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void botaoConsultarCNPJ_Click(object sender, System.EventArgs e)
        {
            Forms.formBuscarCNPJCarregar(FormMain._serviceProvider, 
                                         FormMain._dbCtxFactory,
                                         textCPFCNPJ, 
                                         textRazaoSocial, 
                                         textNome, 
                                         textEnderecoCEP, 
                                         textEnderecoLogradouro, 
                                         textEnderecoNumero, 
                                         null, 
                                         textEnderecoBairro, 
                                         comboEnderecoUF, 
                                         comboEnderecoCidade);
        }

        private void botaotEndrecoCEP_Click(object sender, System.EventArgs e)
        {
            API_Consultas.AcoesAPI.CEPRetorno CEPRetorno = API_Consultas.AcoesAPI.ConsultaCEP(textEnderecoCEP.Text);
        }
    }
}
