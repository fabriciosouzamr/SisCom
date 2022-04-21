using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisCom.Entidade.Modelos;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroTransportadoras : FormMain
    {
        ViewModels.TransportadoraViewModel transportadora = null;

        public frmCadastroTransportadoras(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();

            transportadora = new ViewModels.TransportadoraViewModel();
            Navegar(Declaracoes.Navegar.Primeiro);
        }

        #region Funcoes
        private async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboTipoPessoa, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPessoa));

            await comboEstado_Carregar();

            Limpar();
        }
        void Limpar()
        {
            TipoPessoa_Tratar();
            textNome.Text = "";
            comboPesquisarPesquisa.DataSource = null;
            comboTipoPessoa.SelectedValue = TipoPessoa.Fisica;
            textInscricaoEstadual.Text = "";
            Texto_MaskedTextBox.Limpar(maskedEnderecoCEP);
            textEnderecoLogradouro.Text = "";
            textEnderecoNumero.Text = "";
            textEnderecoBairro.Text = "";
            comboEnderecoUF.SelectedIndex = -1;
            comboEnderecoCidade.SelectedIndex = -1;
            comboEnderecoPais.SelectedIndex = -1;
            textPlaca.Text = "";
            textPlacaCarreta01.Text = "";
            textPlacaCarreta02.Text = "";
            textNomeContato.Text = "";
            textTelefone.Text = "";
        }

        bool TentarGravar()
        {
            bool tentarGravar = false;

            if ((transportadora.Id == Guid.Empty) && (textNome.Text.Trim() == ""))
            {
                tentarGravar = true;
            }
            else
            {
                if (textNome.Text == "")
                {
                    CaixaMensagem.Informacao("Informe o nome da transportadora");
                    goto Sair;
                }
                if (!Validacao.CPFCNPJ_Valido((TipoPessoa)comboTipoPessoa.SelectedValue, Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text)))
                {
                    CaixaMensagem.Informacao("Informe o C.P.F./C.N.P.J!");
                    goto Sair;
                }

                GravarTransportadora();

                tentarGravar = true;
            }


        Sair:
            return tentarGravar;
        }

        private async Task GravarTransportadora()
        {

            if (transportadora.Endereco == null)
                transportadora.Endereco = new Endereco();

            transportadora.Nome = textNome.Text;
            transportadora.TipoPessoa = (TipoPessoa)comboTipoPessoa.SelectedValue;
            transportadora.CNPJ_CPF = Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text);
            transportadora.InscricaoEstadual = Funcao.StringVazioParaNulo(textInscricaoEstadual.Text);
            transportadora.Endereco.End_CEP = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text));
            transportadora.Endereco.End_Logradouro = Funcao.StringVazioParaNulo(textEnderecoLogradouro.Text);
            transportadora.Endereco.End_Numero = Funcao.StringVazioParaNulo(textEnderecoNumero.Text);
            transportadora.Endereco.End_Bairro = Funcao.StringVazioParaNulo(textEnderecoBairro.Text);
            transportadora.Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEnderecoCidade);
            transportadora.NomeContato = Funcao.StringVazioParaNulo(textNomeContato.Text);
            transportadora.PlacaVeiculo = Funcao.StringVazioParaNulo(textPlaca.Text);
            transportadora.PlacaCarreta01 = Funcao.StringVazioParaNulo(textPlacaCarreta01.Text);
            transportadora.PlacaCarreta02 = Funcao.StringVazioParaNulo(textPlacaCarreta02.Text);
            transportadora.Telefone = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.Telefone_Tratar(textTelefone.Text));

            using (TransportadoraController TransportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier))
            {
                if (transportadora.Id != Guid.Empty)
                {
                    await TransportadoraController.Atualizar(transportadora.Id, transportadora);
                }
                else
                {
                    transportadora = (await TransportadoraController.Adicionar(transportadora));
                }
                this.MeuDbContextDispose();
            }
        }
        private async void Excluir()
        {
            using (TransportadoraController TransportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier))
            {
                await TransportadoraController.Excluir(transportadora.Id);
                this.MeuDbContextDispose();
            }

            Limpar();
        }

        void CarregarDados()
        {
            if (transportadora != null)
            {
                Limpar();

                textNome.Text = Funcao.NuloParaString(transportadora.Nome);
                comboPesquisarPesquisa.DataSource = null;
                comboTipoPessoa.SelectedValue = Funcao.SeNulo(transportadora.TipoPessoa, TipoPessoa.Fisica);
                maskedCPFCNPJ.Text = transportadora.CNPJ_CPF;
                textInscricaoEstadual.Text = Funcao.NuloParaString(transportadora.InscricaoEstadual);
                maskedEnderecoCEP.Text = Funcao.NuloParaString(transportadora.Endereco.End_CEP);
                textEnderecoLogradouro.Text = Funcao.NuloParaString(transportadora.Endereco.End_Logradouro);
                textEnderecoNumero.Text = Funcao.NuloParaString(transportadora.Endereco.End_Numero);
                textEnderecoBairro.Text = Funcao.NuloParaString(transportadora.Endereco.End_Bairro);
                textNomeContato.Text = Funcao.NuloParaString(transportadora.NomeContato);
                textPlaca.Text = Funcao.NuloParaString(transportadora.PlacaVeiculo);
                textPlacaCarreta01.Text = Funcao.NuloParaString(transportadora.PlacaCarreta01);
                textPlacaCarreta02.Text = Funcao.NuloParaString(transportadora.PlacaCarreta02);
                textTelefone.Text = Funcao.NuloParaString(transportadora.Telefone);
            }
        }
        private async Task Navegar(Declaracoes.Navegar Posicao)
        {
            if (TentarGravar())
            {
                await Navegar_PegarTodos(transportadora.Id, Posicao);

                CarregarDados();
            }
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.Navegar Posicao)
        {
            using (TransportadoraController TransportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<TransportadoraViewModel> Data = await TransportadoraController.ObterTodos();

                TransportadoraViewModel ItemAnterior = null;
                TransportadoraViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (TransportadoraViewModel Item in Data)
                {
                    if (Posicao == Declaracoes.Navegar.Primeiro)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Proximo)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Item.Id == Id)
                    {
                        switch (Posicao)
                        {
                            case Declaracoes.Navegar.Anterior:
                                ItemRetorno = ItemAnterior;
                                break;
                            case Declaracoes.Navegar.Atual:
                                ItemRetorno = Item;
                                break;
                            case Declaracoes.Navegar.Proximo:
                                Proximo = true;
                                break;
                        }
                    }

                    ItemAnterior = Item;
                }

                if (Posicao == Declaracoes.Navegar.Ultimo)
                {
                    ItemRetorno = ItemAnterior;
                }

                if (ItemRetorno != null) { transportadora = ItemRetorno; }

                this.MeuDbContextDispose();
            }
        }
        #endregion
        #region Botoes
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(transportadora.Id == Guid.Empty ? Declaracoes.Navegar.Primeiro : Declaracoes.Navegar.Anterior);
        }
        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(transportadora.Id == Guid.Empty ? Declaracoes.Navegar.Primeiro : Declaracoes.Navegar.Proximo);
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            transportadora = new ViewModels.TransportadoraViewModel();
            Limpar();
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
        #endregion
        private void frmCadastroTransportadoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            TentarGravar();
        }
        private void TipoPessoa_Tratar()
        {
            if (comboTipoPessoa.SelectedValue != null)
            {
                Texto_MaskedTextBox.Limpar(maskedCPFCNPJ);
                Texto_MaskedTextBox.FormatarTipoPessoa((TipoPessoaCliente)comboTipoPessoa.SelectedValue, maskedCPFCNPJ);
                FuncaoInterna.TipoPessoaCliente_Tratar((TipoPessoaCliente)comboTipoPessoa.SelectedValue, null, null,
                                                       textInscricaoEstadual);
            }
        }
        private void botaoConsultarCNPJ_Click(object sender, EventArgs e)
        {
            if (transportadora != null)
            {
                if (transportadora.Id != Guid.Empty)
                {
                    if (!CaixaMensagem.Perguntar("Existe um cadastro em edição. Deseja iniciar outro?"))
                    {
                        return;
                    }
                }
            }

            comboTipoPessoa.SelectedValue = TipoPessoa.Juridica;

            Forms.formBuscarCNPJCarregar(this._serviceProvider,
                                         this._dbCtxFactory,
                                         this._notifier,
                                         maskedCPFCNPJ,
                                         null,
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
                                        null);
        }
        private void comboEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEnderecoUF_Tratar();
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
        private void comboTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoPessoa_Tratar();
        }
    }
}
