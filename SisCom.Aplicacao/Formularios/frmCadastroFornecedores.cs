using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroFornecedores : FormMain
    {
        public bool Cadastrado = false;

        ViewModels.PessoaViewModel pessoa = null;
        public frmCadastroFornecedores(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        private async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboTipoPessoa, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPessoaCliente));

            await comboEstado_Carregar();

            Limpar();

            labelUsuario.Text = labelUsuario.Tag + " " + Declaracoes.sistema_UsuarioLogado;
        }
        private void Limpar()
        {
            pessoa = new ViewModels.PessoaViewModel();
            comboPesquisarNome.SelectedIndex = -1;
            comboPesquisarCNPJ.DataSource = null;
            comboTipoPessoa.SelectedValue = TipoPessoaCliente.Fisica;
            TipoPessoa_Tratar();
            textInscricaoEstadual.Text = "";
            textInscricaoMunicipal.Text = "";
            textRazaoSocial.Text = "";
            textNomeFantasia.Text = "";
            Texto_MaskedTextBox.Limpar(maskedEnderecoCEP);
            textEnderecoLogradouro.Text = "";
            textEnderecoNumero.Text = "";
            textEnderecoBairro.Text = "";
            comboEnderecoUF.SelectedIndex = -1;
            comboEnderecoCidade.SelectedIndex = -1;
            comboEnderecoPais.SelectedIndex = -1;
            textEnderecoPontoReferencia.Text = "";
            textTelefone.Text = "";
            textFax.Text = "";
            textNomeContato.Text = "";
            textEMail.Text = "";
            textSite.Text = "";
            textRepresentante.Text = "";
            textObservacoes.Text = "";
        }
        private async void CarregarDados_CNPJCPF_Pesquisa(bool CarregarPorCNPJ, bool CarregarPorPesquisa)
        {
            IEnumerable<PessoaViewModel> pessoaViewModel = null;
            bool Carregar = false;

            if (CarregarPorCNPJ)
            {
                pessoaViewModel = await (new PessoaController(this.MeuDbContext(), this._notifier)).PesquisarCNPJCPF(Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text));
            }
            else if (CarregarPorPesquisa)
            {
                if (comboPesquisarCNPJ.SelectedIndex == -1)
                {
                    return;
                }
                pessoaViewModel = await (new PessoaController(this.MeuDbContext(), this._notifier)).PesquisarId((Guid)comboPesquisarCNPJ.SelectedValue);
            }
            if (pessoaViewModel != null)
            {
                PessoaViewModel pessoai = null;

                foreach (PessoaViewModel item in pessoaViewModel)
                {
                    pessoai = item;
                    break;
                }
                if (pessoai != null)
                {
                    if (CarregarPorPesquisa)
                    {
                        Carregar = true;
                    }
                    else
                    {
                        if (CaixaMensagem.Perguntar("Já existe cadastro criado para esse C.P.F./C.N.P.J. Deseja carregar para edição?"))
                        {
                            Carregar = true;
                        }
                        else
                        {
                            Texto_MaskedTextBox.Limpar(maskedCPFCNPJ);
                            maskedCPFCNPJ.Focus();
                            pessoa = null;
                        }
                    }
                    if (Carregar)
                    {
                        pessoa = pessoai;
                        CarregarDados();
                    }
                }
            }
        }
        private async void CarregarDados()
        {
            if (pessoa != null)
            {
                comboTipoPessoa.SelectedValue = pessoa.TipoPessoa;
                maskedCPFCNPJ.Text = pessoa.CNPJ_CPF;
                textInscricaoEstadual.Text = Funcao.NuloParaString(pessoa.InscricaoEstadual);
                textInscricaoMunicipal.Text = Funcao.NuloParaString(pessoa.InscricaoMunicipal);
                textNomeFantasia.Text = Funcao.NuloParaString(pessoa.Nome);
                textRazaoSocial.Text = Funcao.NuloParaString(pessoa.RazaoSocial);
                maskedEnderecoCEP.Text = Funcao.NuloParaString(pessoa.Endereco.End_CEP);
                textEnderecoLogradouro.Text = Funcao.NuloParaString(pessoa.Endereco.End_Logradouro);
                textEnderecoNumero.Text = Funcao.NuloParaString(pessoa.Endereco.End_Numero);
                textEnderecoBairro.Text = Funcao.NuloParaString(pessoa.Endereco.End_Bairro);
                textEnderecoPontoReferencia.Text = Funcao.NuloParaString(pessoa.Endereco.End_PontoReferencia);
                textTelefone.Text = Funcao.NuloParaString(pessoa.Telefone);
                textFax.Text = Funcao.NuloParaString(pessoa.FAX);
                textNomeContato.Text = Funcao.NuloParaString(pessoa.NomeContato);
                textEMail.Text = Funcao.NuloParaString(pessoa.EMail);
                textSite.Text = Funcao.NuloParaString(pessoa.Site);
                textRepresentante.Text = Funcao.NuloParaString(pessoa.Representante);
                textObservacoes.Text = Funcao.NuloParaString(pessoa.Observacoes);

                if (!Funcao.Nulo(pessoa.Endereco.End_CidadeId)) Combo_ComboBox.ComboCidade_Carregar(this._serviceProvider,
                                                                                                    this._dbCtxFactory,
                                                                                                    this._notifier,
                                                                                                    pessoa.Endereco.End_CidadeId,
                                                                                                    comboEnderecoCidade,
                                                                                                    comboEnderecoUF,
                                                                                                    comboEnderecoPais);
                this.MeuDbContextDispose();
            }
        }
        private async void AdicionarPessoa()
        {
            var pessoaController = new PessoaController(this.MeuDbContext(), this._notifier);

            if (pessoa.Id != Guid.Empty)
            {
                await pessoaController.Atualizar(pessoa.Id, pessoa);
            }
            else
            {
                pessoa = (await pessoaController.Adicionar(pessoa));
            }

            Cadastrado = true;

            pessoaController = null;

            this.MeuDbContextDispose();
        }
        private async void Excluir()
        {
            var pessoaController = new PessoaController(this.MeuDbContext(), this._notifier);
            await pessoaController.Excluir(pessoa.Id);
            pessoaController = null;
            this.MeuDbContextDispose();

            Limpar();
        }
        private void TipoPessoa_Tratar()
        {
            Texto_MaskedTextBox.FormatarTipoPessoa((TipoPessoaCliente)comboTipoPessoa.SelectedValue, maskedCPFCNPJ);
        }
        #endregion
        #region Combos
        private async Task comboCidade_Carregar(Guid EstadoId)
        {
            Combo_ComboBox.Formatar(comboEnderecoCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEnderecoUF,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboPais_Carregar()
        {
            if (comboEnderecoUF.SelectedIndex != -1)
            {
                Guid PaisId = (await (new EstadoController(this.MeuDbContext(), this._notifier)).GetById((Guid)comboEnderecoUF.SelectedValue)).PaisId;

                Combo_ComboBox.Formatar(comboEnderecoPais,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PaisController(this.MeuDbContext(), this._notifier)).ComboId(PaisId));

                comboEnderecoPais.SelectedValue = PaisId;
            }
        }
        private void comboEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboEnderecoUF.SelectedIndex != -1) && (comboEnderecoUF.Tag != Declaracoes.ComboBox_Carregando))
            {
                if (Combo_ComboBox.Selecionado(comboEnderecoUF))
                {
                    comboCidade_Carregar(Guid.Parse(comboEnderecoUF.SelectedValue.ToString()));
                    comboPais_Carregar();
                }
            }
        }
        private void comboPesquisarCNPJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboPesquisarCNPJ.SelectedIndex != -1) && (comboPesquisarCNPJ.Tag != Declaracoes.ComboBox_Carregando))
            {
                CarregarDados_CNPJCPF_Pesquisa(false, true);
            }
        }
        #endregion
        #region Botaos
        private void botaoConsultarCNPJ_Click(object sender, System.EventArgs e)
        {
            if ((pessoa != null ) && (pessoa.Id != Guid.Empty))
            {
                if (!CaixaMensagem.Perguntar("Existe um cadastro em edição. Deseja iniciar outro?"))
                {
                    return;
                }
            }

            comboTipoPessoa.SelectedValue = TipoPessoaCliente.Juridica;

            Forms.formBuscarCNPJCarregar(this._serviceProvider,
                                         this._dbCtxFactory,
                                         this._notifier,
                                         maskedCPFCNPJ,
                                         textRazaoSocial,
                                         textNomeFantasia,
                                         maskedEnderecoCEP,
                                         textEnderecoLogradouro,
                                         textEnderecoNumero,
                                         null,
                                         textEnderecoBairro,
                                         comboEnderecoUF,
                                         comboEnderecoCidade);
        }
        private void botaotEndrecoCEP_Click(object sender, System.EventArgs e)
        {
            Forms.formBuscarCEPCarregar(this._serviceProvider,
                                        this._dbCtxFactory,
                                        this._notifier,
                                        maskedEnderecoCEP.Text,
                                        textEnderecoLogradouro,
                                        textEnderecoBairro,
                                        comboEnderecoUF,
                                        comboEnderecoCidade,
                                        textEnderecoPontoReferencia);
        }
        private void botaoFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            if (!Validacao.CPFCNPJ_Valido((TipoPessoa)comboTipoPessoa.SelectedValue, Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text)))
            {
                CaixaMensagem.Informacao("Informe o C.P.F./C.N.P.J!");
                return;
            }
            if (textNomeFantasia.Text.Trim() == string.Empty)
            {
                CaixaMensagem.Informacao("Informe o nome de fantasia!");
                return;
            }
            if (!Validacao.CEP_Valido(maskedEnderecoCEP.Text) && (Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text) != ""))
            {
                CaixaMensagem.Informacao("Infome um C.E.P. válido!");
                return;
            }

            if (pessoa == null)
                pessoa = new ViewModels.PessoaViewModel();
            if (pessoa.Endereco == null)
                pessoa.Endereco = new Endereco();

            pessoa.TipoPessoa = (TipoPessoaCliente)comboTipoPessoa.SelectedValue;
            pessoa.CNPJ_CPF = Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text);
            pessoa.InscricaoEstadual = Funcao.StringVazioParaNulo(textInscricaoEstadual.Text);
            pessoa.InscricaoMunicipal = Funcao.StringVazioParaNulo(textInscricaoMunicipal.Text);
            pessoa.Nome = Funcao.StringVazioParaNulo(textNomeFantasia.Text);
            pessoa.RazaoSocial = Funcao.StringVazioParaNulo(textRazaoSocial.Text);
            pessoa.Endereco.End_CEP = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text));
            pessoa.Endereco.End_Logradouro = Funcao.StringVazioParaNulo(textEnderecoLogradouro.Text);
            pessoa.Endereco.End_Numero = Funcao.StringVazioParaNulo(textEnderecoNumero.Text);
            pessoa.Endereco.End_Bairro = Funcao.StringVazioParaNulo(textEnderecoBairro.Text);
            pessoa.Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEnderecoCidade);
            pessoa.Endereco.End_PontoReferencia = Funcao.StringVazioParaNulo(textEnderecoPontoReferencia.Text);
            pessoa.Telefone = Funcao.StringVazioParaNulo(textTelefone.Text);
            pessoa.FAX = Funcao.StringVazioParaNulo(textFax.Text);
            pessoa.NomeContato = Funcao.StringVazioParaNulo(textNomeContato.Text);
            pessoa.EMail = Funcao.StringVazioParaNulo(textEMail.Text);
            pessoa.Site = Funcao.StringVazioParaNulo(textSite.Text);
            pessoa.Representante = Funcao.StringVazioParaNulo(textRepresentante.Text);
            pessoa.Observacoes = Funcao.StringVazioParaNulo(textObservacoes.Text);
            pessoa.Fornecedor = true;

            AdicionarPessoa();
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            if (!FuncaoInterna.NuloModelView(pessoa))
            {
                if (CaixaMensagem.Perguntar("Deseja excluir esse cliente?"))
                {
                    Excluir();
                }
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o cliente que deseja excluir;");
            }
        }
        #endregion
        private void maskedCPFCNPJ_Leave(object sender, EventArgs e)
        {
            if (Validacao.CPFCNPJ_Valido((TipoPessoa)comboTipoPessoa.SelectedValue, maskedCPFCNPJ.Text))
            {
                CarregarDados_CNPJCPF_Pesquisa(true, false);
            }
        }
        private void comboTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoPessoa_Tratar();
        }
    }
}
