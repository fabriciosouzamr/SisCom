using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static API_Consultas.AcoesAPI;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroBuscarCNPJ : Form
    {
        public formBuscarCNPJDados formBuscarCNPJDados;
        FormMain FormMain;

        public frmCadastroBuscarCNPJ(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            InitializeComponent();
            FormMain = new FormMain(serviceProvider, dbCtxFactory);

            dateDataAbertura.Text = "";
            dateDataSituacaoCadastral.Text = "";

            comboEstado_Carregar();
        }

        private void botaoConsultar_Click(object sender, EventArgs e)
        {
            ConsultarCNPJ();
        }

        private void ConsultarCNPJ()
        {
            CNPJRetorno CNPJRetorno = ReceitaWS.ConsultarCNPJ(textCNPJ.Text);

            if (CNPJRetorno != null)
            {
                textRazaoSocial.Text = CNPJRetorno.nome;
                textNomeFantasia.Text = CNPJRetorno.fantasia;
                textEnderecoCEP.Text = CNPJRetorno.cep;
                textEnderecoLogradouro.Text = CNPJRetorno.logradouro;
                textEnderecoNumero.Text = CNPJRetorno.numero;
                textEnderecoComplemento.Text = CNPJRetorno.complemento;
                textEnderecoBairro.Text = CNPJRetorno.bairro;
                Combo_ComboBox.Selecionar(comboEnderecoEstado, CNPJRetorno.uf, 1);
                Combo_ComboBox.Selecionar(comboEnderecoCidade, CNPJRetorno.municipio, 1);
                dateDataAbertura.Text = CNPJRetorno.abertura;
                dateDataSituacaoCadastral.Text = CNPJRetorno.data_situacao;
                textSituacaoCadastral.Text = CNPJRetorno.situacao;
                textMotivoSituacaoCadastral.Text = CNPJRetorno.motivo_situacao;
            }

            CNPJRetorno = null;
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoConfirmar_Click(object sender, EventArgs e)
        {
            if (textRazaoSocial.Text.Trim() =="" )
            {
                CaixaMensagem.Informacao("É preciso carregar os dados da empresa");
                return;
            }

            formBuscarCNPJDados = new formBuscarCNPJDados();
            formBuscarCNPJDados.CNPJ = textCNPJ.Text;
            formBuscarCNPJDados.RazaoSocial = textRazaoSocial.Text;
            formBuscarCNPJDados.NomeFantasia = textNomeFantasia.Text;
            formBuscarCNPJDados.CEP = textEnderecoCEP.Text;
            formBuscarCNPJDados.Logradouro = textEnderecoLogradouro.Text;
            formBuscarCNPJDados.Numero = textEnderecoNumero.Text;
            formBuscarCNPJDados.Complemento = textEnderecoComplemento.Text;
            formBuscarCNPJDados.Bairro = textEnderecoBairro.Text;
            if (comboEnderecoEstado.SelectedValue != null) { formBuscarCNPJDados.Estado = (Guid)comboEnderecoEstado.SelectedValue; }
            if (comboEnderecoCidade.SelectedValue != null) { formBuscarCNPJDados.Cidade = (Guid)comboEnderecoCidade.SelectedValue; }

            Close();
        }

        private void comboEnderecoEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboEnderecoEstado))
            {
                comboCidade_Carregar(Guid.Parse(comboEnderecoEstado.SelectedValue.ToString()));
            }
        }

        private async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEnderecoEstado,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(FormMain.MeuDbContext())).ComboCodigo(p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
        private async Task comboCidade_Carregar(Guid EstadoId)
        {
            Combo_ComboBox.Formatar(comboEnderecoCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(FormMain.MeuDbContext())).ComboEstado(EstadoId, p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
    }
}
