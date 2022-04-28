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
        TransportadoraController transportadoraController;

        public frmCadastroTransportadoras(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            transportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier);
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboTipoPessoa, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPessoa));

            await comboTransportadoraNome_Carregar();
            await comboEstado_Carregar();

            Limpar();

            transportadora = new ViewModels.TransportadoraViewModel();
            await Navegar(Declaracoes.eNavegar.Primeiro);
        }
        void Limpar()
        {
            TipoPessoa_Tratar();
            textNome.Text = "";
            comboPesquisarPesquisa.SelectedIndex =-1;
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

            if (transportadora == null)
            {
                tentarGravar = true;
            }
            else if ((transportadora.Id == Guid.Empty) && (textNome.Text.Trim() == ""))
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
        async Task GravarTransportadora()
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
            
            if (transportadora.Id != Guid.Empty)
            {
                await transportadoraController.Atualizar(transportadora.Id, transportadora);
            }
            else
            {
                transportadora = (await transportadoraController.Adicionar(transportadora));
            }
            await comboTransportadoraNome_Carregar();
        }
        async void Excluir()
        {
            using (TransportadoraController TransportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier))
            {
                await TransportadoraController.Excluir(transportadora.Id);
            }

            await comboTransportadoraNome_Carregar();

            Limpar();
        }
        void CarregarDados()
        {
            if (!FuncaoInterna.NuloModelView(transportadora))
            {
                Limpar();

                textNome.Text = Funcao.NuloParaString(transportadora.Nome);
                comboPesquisarPesquisa.SelectedIndex = -1;
                comboTipoPessoa.SelectedValue = transportadora.TipoPessoa == 0 ? TipoPessoa.Fisica : transportadora.TipoPessoa;
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
        async Task Navegar(Declaracoes.eNavegar Posicao)
        {
            if (TentarGravar())
            {
                await Navegar_PegarTodos(transportadora.Id, Posicao);

                CarregarDados();
            }
        }
        async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            transportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier);

            IEnumerable<TransportadoraViewModel> data = await transportadoraController.ObterTodos();

            TransportadoraViewModel itemAnterior = null;
            TransportadoraViewModel itemRetorno = null;
            bool Proximo = false;

            foreach (TransportadoraViewModel item in data)
            {
                if (Posicao == Declaracoes.eNavegar.Primeiro)
                {
                    itemRetorno = item;
                    break;
                }
                else if (Proximo)
                {
                    itemRetorno = item;
                    break;
                }
                else if (item.Id == Id)
                {
                    switch (Posicao)
                    {
                        case Declaracoes.eNavegar.Anterior:
                            itemRetorno = itemAnterior;
                            break;
                        case Declaracoes.eNavegar.Atual:
                            itemRetorno = item;
                            break;
                        case Declaracoes.eNavegar.Proximo:
                            Proximo = true;
                            break;
                    }
                }

                itemAnterior = item;
            }

            if (Posicao == Declaracoes.eNavegar.Ultimo)
            {
                itemRetorno = itemAnterior;
            }

            if (itemRetorno != null) { transportadora = itemRetorno; }

            data = null;
        }
        #endregion
        #region Botoes
        void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(transportadora.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Anterior);
        }
        void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(transportadora.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Proximo);
        }
        void botaoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
        void botaoNovo_Click(object sender, EventArgs e)
        {
            transportadora = new ViewModels.TransportadoraViewModel();
            Limpar();
        }
        #endregion
        #region Combos
        async Task comboCidade_Carregar(Guid EstadoId)
        {
            Combo_ComboBox.Formatar(comboEnderecoCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));
        }
        async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEnderecoUF,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Nome));
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
            if (!TentarGravar())
            {
                e.Cancel = (!CaixaMensagem.Perguntar("Cadastro em edição! Deseja sair assim mesmo?"));
            }

            this.MeuDbContextDispose();
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
                }
            }
        }
        private void comboTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoPessoa_Tratar();
        }
        private async Task comboTransportadoraNome_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new TransportadoraController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
        }
        private void comboPesquisarPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboPesquisarPesquisa.SelectedIndex != -1) && (comboPesquisarPesquisa.Tag != Declaracoes.ComboBox_Carregando))
            {
                comboPesquisarPesquisa_Carregar();
            }

        }

        private async Task comboPesquisarPesquisa_Carregar()
        {
            IEnumerable<TransportadoraViewModel> transportadoraViewModel = null;

            transportadoraViewModel = await (new TransportadoraController(this.MeuDbContext(), this._notifier)).PesquisarId((Guid)comboPesquisarPesquisa.SelectedValue);

            if (transportadoraViewModel != null)
            {
                TransportadoraViewModel transportadoraViewModeli = null;

                foreach (TransportadoraViewModel item in transportadoraViewModel)
                {
                    transportadoraViewModeli = item;
                    break;
                }
                if (transportadoraViewModeli != null)
                {
                    transportadora = transportadoraViewModeli;
                    CarregarDados();
                }
            }
        }
    }
}
