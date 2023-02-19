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
    public partial class frmCadastroBuscarCNPJ : FormMain
    {
        public formBuscarCNPJDados formBuscarCNPJDados;

        public frmCadastroBuscarCNPJ(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();

            dateDataAbertura.Text = "";
            dateDataSituacaoCadastral.Text = "";

            Texto_MaskedTextBox.FormatarTipoPessoa(Funcoes._Enum.TipoPessoaCliente.Juridica, maskedCNPJ);

            comboEstado_Carregar();
        }

        private void botaoConsultar_Click(object sender, EventArgs e)
        {
            ConsultarCNPJ();
        }

        private async Task ConsultarCNPJ()
        {
            if (!Funcoes._Classes.Validacao.CNPJ_Valido(maskedCNPJ.Text))
            {
                CaixaMensagem.Informacao("C.N.P.J. Inválido");
                return;
            }

            CNPJRetorno CNPJRetorno = ReceitaWS.ConsultarCNPJ(Funcoes._Classes.Texto.SomenteNumero(maskedCNPJ.Text));

            if (CNPJRetorno != null)
            {
                textRazaoSocial.Text = CNPJRetorno.nome;
                textNomeFantasia.Text = CNPJRetorno.fantasia;
                maskedEnderecoCEP.Text = CNPJRetorno.cep;
                textEnderecoLogradouro.Text = CNPJRetorno.logradouro;
                textEnderecoNumero.Text = CNPJRetorno.numero;
                textEnderecoComplemento.Text = CNPJRetorno.complemento;
                textEnderecoBairro.Text = CNPJRetorno.bairro;
                Combo_ComboBox.Selecionar(comboEnderecoUF, CNPJRetorno.uf);

                await Classes.Forms.comboCidade_Carregar(this._serviceProvider,
                                                         this._dbCtxFactory,
                                                         this._notifier,
                                                         (Guid)comboEnderecoUF.SelectedValue,
                                                         CNPJRetorno.municipio,
                                                         "",
                                                         comboEnderecoUF,
                                                         comboEnderecoCidade);

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
            formBuscarCNPJDados.CNPJ = maskedCNPJ.Text;
            formBuscarCNPJDados.RazaoSocial = textRazaoSocial.Text;
            formBuscarCNPJDados.NomeFantasia = textNomeFantasia.Text;
            formBuscarCNPJDados.CEP = maskedEnderecoCEP.Text;
            formBuscarCNPJDados.Logradouro = textEnderecoLogradouro.Text;
            formBuscarCNPJDados.Numero = textEnderecoNumero.Text;
            formBuscarCNPJDados.Complemento = textEnderecoComplemento.Text;
            formBuscarCNPJDados.Bairro = textEnderecoBairro.Text;
            if (comboEnderecoUF.SelectedValue != null) { formBuscarCNPJDados.Estado = (Guid)comboEnderecoUF.SelectedValue; }
            if (comboEnderecoCidade.SelectedValue != null) { formBuscarCNPJDados.Cidade = (Guid)comboEnderecoCidade.SelectedValue; }

            Close();
        }

        private void comboEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboEnderecoUF))
            {
                comboCidade_Carregar(Guid.Parse(comboEnderecoUF.SelectedValue.ToString()));
            }
        }

        private async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEnderecoUF,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboCidade_Carregar(Guid EstadoId)
        {
            await Combo_ComboBox.ComboCidadeEstado_Carregar(comboEnderecoCidade, EstadoId, this.MeuDbContext(), this._notifier);
            this.MeuDbContextDispose();
        }

        private void botaoBuscaCEP_Click(object sender, EventArgs e)
        {
            Forms.formBuscarCEPCarregar(this._serviceProvider,
                                        this._dbCtxFactory,
                                        this._notifier,
                                        maskedEnderecoCEP.Text,
                                        textEnderecoLogradouro,
                                        textEnderecoBairro,
                                        comboEnderecoUF,
                                        comboEnderecoCidade,
                                        textEnderecoComplemento);
        }
    }
}
