using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisCom.Entidade.Enum;
using Funcoes._Classes;
using SisCom.Entidade.Modelos;
using SisCom.Aplicacao.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroClientes : FormMain
    {
        ViewModels.PessoaViewModel pessoa = null;

        enum TipoPesquisa
        {
            [Description("Nome")]
            Nome = 0,
            [Description("Razão Social")]
            RazaoSocial = 1,
            [Description("Código")]
            Codigo = 3,
            [Description("C.P.F./C.N.P.J.")]
            CPF_CNPJ = 4,
            [Description("Fone")]
            Telefone = 5
        }

        public frmCadastroClientes(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        #region Funcoes
        private async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboPesquisarTipoFiltro, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPesquisa));
            Combo_ComboBox.Formatar(comboTipoPessoa, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPessoaCliente));
            Combo_ComboBox.Formatar(comboTipoContribuinte, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoContribuinte));
            Combo_ComboBox.Formatar(comboRegimeTributario, "", "", ComboBoxStyle.DropDownList, null, typeof(RegimeTributario));

            await comboEstado_Carregar();
            await comboVendedor_Carregar();
            await comboTipoCliente_Carregar();

            Limpar();

            labelUsuario.Text = labelUsuario.Tag + " " + Declaracoes.sistema_UsuarioLogado;
            labelLoja.Text = labelLoja.Tag + " " + Declaracoes.sistema_Loja;
        }
        private void Limpar()
        {
            pessoa = new ViewModels.PessoaViewModel();
            comboPesquisarTipoFiltro.SelectedIndex = -1;
            comboPesquisarPesquisa.DataSource = null;
            comboTipoPessoa.SelectedValue = TipoPessoaCliente.Fisica;
            TipoPessoa_Tratar();
            textRG.Text = "";
            dateCadastro.Value = DateTime.Now;
            comboTipoContribuinte.SelectedIndex = -1;
            textInscricaoEstadual.Text = "";
            textInscricaoMunicipal.Text = "";
            textCodigoCliente.Text = "";
            textNome.Text = "";
            textRazaoSocial.Text = "";
            Texto_MaskedTextBox.Limpar(maskedEnderecoCEP);
            textEnderecoLogradouro.Text = "";
            textEnderecoNumero.Text = "";
            textEnderecoBairro.Text = "";
            comboEnderecoUF.SelectedIndex = -1;
            comboEnderecoCidade.SelectedIndex = -1;
            comboEnderecoPais.SelectedIndex = -1;
            textEnderecoPontoReferencia.Text = "";
            textNomeContato.Text = "";
            dateNascimento.Value = dateNascimento.MinDate;
            comboVendedor.SelectedIndex = -1;
            comboTipoCliente.SelectedIndex = -1;
            comboRegimeTributario.SelectedIndex = -1;
            checkSelecionarEtiqueta.Checked = false;
            checkDesativado.Checked = false;
            checkUsarFoto.Checked = false;
            pictureFoto.Image = null;
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
                if (comboPesquisarPesquisa.SelectedIndex ==-1)
                {
                    return;
                }
                pessoaViewModel = await (new PessoaController(this.MeuDbContext(), this._notifier)).PesquisarId((Guid)comboPesquisarPesquisa.SelectedValue);
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
                textRG.Text = Funcao.NuloParaString(pessoa.RG);
                dateCadastro.Value = pessoa.DatCadastro;
                if (!Funcao.Nulo(pessoa.TipoContribuinte)) comboTipoContribuinte.SelectedValue = pessoa.TipoContribuinte;
                textInscricaoEstadual.Text = Funcao.NuloParaString(pessoa.InscricaoEstadual);
                textInscricaoMunicipal.Text = Funcao.NuloParaString(pessoa.InscricaoMunicipal);
                textCodigoCliente.Text = pessoa.Codigo.ToString("00000");
                textNome.Text = Funcao.NuloParaString(pessoa.Nome);
                textRazaoSocial.Text = Funcao.NuloParaString(pessoa.RazaoSocial);
                maskedEnderecoCEP.Text = Funcao.NuloParaString(pessoa.Endereco.End_CEP);
                textEnderecoLogradouro.Text = Funcao.NuloParaString(pessoa.Endereco.End_Logradouro);
                textEnderecoNumero.Text = Funcao.NuloParaString(pessoa.Endereco.End_Numero);
                textEnderecoBairro.Text = Funcao.NuloParaString(pessoa.Endereco.End_Bairro);
                textEnderecoPontoReferencia.Text = Funcao.NuloParaString(pessoa.Endereco.End_PontoReferencia);
                textNomeContato.Text = Funcao.NuloParaString(pessoa.NomeContato);
                dateNascimento.Value = (DateTime)Funcao.NuloParaData(pessoa.DataNascimento, dateNascimento.MinDate);
                if (!Funcao.Nulo(pessoa.VendedorId)) comboVendedor.SelectedValue = pessoa.VendedorId;
                if (!Funcao.Nulo(pessoa.TipoClienteId)) comboTipoCliente.SelectedValue = pessoa.TipoClienteId;
                if (!Funcao.Nulo(pessoa.RegimeTributario)) comboRegimeTributario.SelectedValue = pessoa.RegimeTributario;
                checkSelecionarEtiqueta.Checked = pessoa.SelecionarEtiqueta;
                checkDesativado.Checked = pessoa.Desativado;
                checkUsarFoto.Checked = pessoa.UsarFoto;
                if (!Imagem.NuloImagem(pessoa.Imagem)) pictureFoto.Image = Imagem.ByteArrayToImage(pessoa.Imagem);
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
        private async void GravarPessoa()
        {
            if (!Funcoes._Classes.Validacao.CPFCNPJ_Valido((TipoPessoa)pessoa.TipoPessoa, pessoa.CNPJ_CPF))
            {
                CaixaMensagem.Informacao("C.P.F./C.N.P.J. Inválido");
                return;
            }

            var pessoaController = new PessoaController(this.MeuDbContext(), this._notifier);

            if (pessoa.Id != Guid.Empty)
            {
                await pessoaController.Atualizar(pessoa.Id, pessoa);
            }
            else
            {
                pessoa = (await pessoaController.Adicionar(pessoa));
            }

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
            FuncaoInterna.TipoPessoaCliente_Tratar((TipoPessoaCliente)comboTipoPessoa.SelectedValue,
                                                   comboTipoContribuinte,
                                                   textRG,
                                                   textInscricaoEstadual);
        }
        private void CadastroTipoClienteAtualizado(object? sender, EventArgs e)
        {
            comboTipoCliente_Carregar();
        }
        public async Task comboEnderecoUF_Tratar()
        {
            if ((comboEnderecoUF.SelectedIndex != -1) && (comboEnderecoUF.Tag != Declaracoes.ComboBox_Carregando))
            {
                if (Combo_ComboBox.Selecionado(comboEnderecoUF))
                {
                    await comboCidade_Carregar(Guid.Parse(comboEnderecoUF.SelectedValue.ToString()));
                    await comboPais_Carregar();

                    this.MeuDbContextDispose();
                }
            }
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
        private async Task comboPessoaNome_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboNome(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboPessoaRazaoSocial_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "RazaoSocial",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboRazaoSocial(p => p.RazaoSocial));
            this.MeuDbContextDispose();
        }
        private async Task comboPessoaCodigo_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Codigo));
            this.MeuDbContextDispose();
        }
        private async Task comboPessoaCNPJCPF_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "CNPJ_CPF",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboCPFCNPJ(p => p.CNPJ_CPF));
            this.MeuDbContextDispose();
        }
        private async Task comboPessoaTelefone_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "Telefone",
                                    ComboBoxStyle.DropDownList,
                                    await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboTelefone(p => p.Telefone));
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
        private async Task comboVendedor_Carregar()
        {
            Combo_ComboBox.Formatar(comboVendedor,
                                    "Id", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FuncionarioController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboTipoCliente_Carregar()
        {
            Combo_ComboBox.Formatar(comboTipoCliente,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new TipoClienteController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private void comboContribuinte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoContribuinte.SelectedIndex != -1)
                FuncaoInterna.TipoContribuinte_Tratar((TipoContribuinte)comboTipoContribuinte.SelectedValue,
                                                      textInscricaoEstadual);
        }
        private void comboEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEnderecoUF_Tratar();
        }
        private void comboTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoPessoa.SelectedIndex != -1)
            {
                TipoPessoa_Tratar();
            }
        }
        private void comboPesquisarTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboPesquisarTipoFiltro.SelectedIndex != -1) && (comboPesquisarTipoFiltro.Tag != Declaracoes.ComboBox_Carregando))
            {
                switch (comboPesquisarTipoFiltro.SelectedValue)
                {
                    case TipoPesquisa.Nome:
                        comboPessoaNome_Carregar();
                        break;
                    case TipoPesquisa.RazaoSocial:
                        comboPessoaRazaoSocial_Carregar();
                        break;
                    case TipoPesquisa.Codigo:
                        comboPessoaCodigo_Carregar();
                        break;
                    case TipoPesquisa.CPF_CNPJ:
                        comboPessoaCNPJCPF_Carregar();
                        break;
                    case TipoPesquisa.Telefone:
                        comboPessoaTelefone_Carregar();
                        break;
                }
            }
        }
        private void comboPesquisarPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboPesquisarPesquisa.SelectedIndex != -1) && (comboPesquisarPesquisa.Tag != Declaracoes.ComboBox_Carregando))
            {
                CarregarDados_CNPJCPF_Pesquisa(false, true);
            }
        }
        #endregion
        #region Botaos
        private void botaoConsultarCNPJ_Click(object sender, System.EventArgs e)
        {
            if (pessoa!= null)
            {
                if (pessoa.Id != Guid.Empty)
                {
                    if (!CaixaMensagem.Perguntar("Existe um cadastro em edição. Deseja iniciar outro?"))
                    {
                        return;
                    }
                }
            }

            comboTipoPessoa.SelectedValue = TipoPessoaCliente.Juridica;

            Forms.formBuscarCNPJCarregar(this._serviceProvider,
                                         this._dbCtxFactory,
                                         this._notifier,
                                         maskedCPFCNPJ,
                                         textRazaoSocial,
                                         textNome,
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
            if (textNome.Text.Trim() == string.Empty)
            {
                CaixaMensagem.Informacao("Informe o nome do cliente!");
                return;
            }
            if (comboTipoContribuinte.SelectedIndex == -1)
            {
                CaixaMensagem.Informacao("Selecione o tipo de contribuinte!");
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
            pessoa.RG = Funcao.StringVazioParaNulo(textRG.Text.Trim());
            pessoa.DatCadastro = dateCadastro.Value;
            pessoa.TipoContribuinte = (TipoContribuinte)comboTipoContribuinte.SelectedValue;
            pessoa.InscricaoEstadual = Funcao.StringVazioParaNulo(textInscricaoEstadual.Text);
            pessoa.InscricaoMunicipal = Funcao.StringVazioParaNulo(textInscricaoMunicipal.Text);
            pessoa.Nome = Funcao.StringVazioParaNulo(textNome.Text);
            pessoa.RazaoSocial = Funcao.StringVazioParaNulo(textRazaoSocial.Text);
            pessoa.Endereco.End_CEP = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text));
            pessoa.Endereco.End_Logradouro = Funcao.StringVazioParaNulo(textEnderecoLogradouro.Text);
            pessoa.Endereco.End_Numero = Funcao.StringVazioParaNulo(textEnderecoNumero.Text);
            pessoa.Endereco.End_Bairro = Funcao.StringVazioParaNulo(textEnderecoBairro.Text);
            pessoa.Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEnderecoCidade);
            pessoa.Endereco.End_PontoReferencia = Funcao.StringVazioParaNulo(textEnderecoPontoReferencia.Text);
            pessoa.NomeContato = Funcao.StringVazioParaNulo(textNomeContato.Text);
            pessoa.DataNascimento = Funcao.DataVazioParaNulo(dateNascimento.Value);
            pessoa.VendedorId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboVendedor);
            pessoa.TipoClienteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTipoCliente);
            if (Combo_ComboBox.Selecionado(comboRegimeTributario)) { pessoa.RegimeTributario = (RegimeTributario)comboRegimeTributario.SelectedValue; } else { pessoa.RegimeTributario = null;  }
            pessoa.SelecionarEtiqueta = checkSelecionarEtiqueta.Checked;
            pessoa.Desativado = checkDesativado.Checked;
            pessoa.UsarFoto = checkUsarFoto.Checked;
            pessoa.Imagem = Imagem.ImageToByteArray(pictureFoto.Image);
            pessoa.Observacoes = Funcao.StringVazioParaNulo(textObservacoes.Text);

            GravarPessoa();
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
        private void botaoTipoCliente_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroTipoCliente>();
            form.GravacaoEfetuada += CadastroTipoClienteAtualizado;
            form.ShowDialog(this);
        }
        #endregion
        private void pictureFoto_DoubleClick(object sender, EventArgs e)
        {
            Imagem.CarregarFoto(pictureFoto);
        }
        private void maskedCPFCNPJ_Leave(object sender, EventArgs e)
        {
            if (Validacao.CPFCNPJ_Valido((TipoPessoa)comboTipoPessoa.SelectedValue, maskedCPFCNPJ.Text))
            {
                CarregarDados_CNPJCPF_Pesquisa(true, false);
            }
        }
    }
}
