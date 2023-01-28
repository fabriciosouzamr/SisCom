using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroVeiculoPlaca : FormMain
    {
        public bool Cadastrado = false;

        bool carregado = false;

        Guid veiculoPlacaId = Guid.Empty;

        enum TipoPesquisa
        {
            [Description("Placa do Veículo")]
            Placa = 1,
            [Description("Renavem do Veículo")]
            Renavem = 2,
            [Description("Nome do Proprietário")]
            NomeProprietario = 3,
            [Description("CPF/CNPJ do Proprietário")]
            CPF_CNPJProprietario = 4
        }
        public frmCadastroVeiculoPlaca(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        private async Task Inicializar()
        {
            try
            {
                //Pesquisar
                Combo_ComboBox.Formatar(comboPesquisarTipoFiltro, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPesquisa));
                Combo_ComboBox.Formatar(comboTipoCarroceria, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoCarroceria));
                Combo_ComboBox.Formatar(comboVeiculoTerceiro_TipoProprietario, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoProprietario));

                comboPesquisarTipoFiltro.SelectedValue = TipoPesquisa.Placa;

                await CarregaDados();
                await comboUF_Carregar();

                Limpar();
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private async Task<bool> comboUF_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboUF, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
                Combo_ComboBox.Formatar(comboVeiculoTerceiro_UFProprietario, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
            }

            return true;
        }
        private async Task CarregaDados()
        {
            Limpar();

            if ((comboPesquisarPesquisa.SelectedIndex != -1) && (carregado))
            {
                using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
                {
                    var veiculoPlaca = await veiculoPlacaController.GetById((Guid)comboPesquisarPesquisa.SelectedValue);

                    veiculoPlacaId = veiculoPlaca.Id;
                    textPlaca.Text = veiculoPlaca.NumeroPlaca;
                    if (!Funcao.Nulo(veiculoPlaca.EstadoId)) comboUF.SelectedValue = veiculoPlaca.EstadoId;
                    if (!Funcao.Nulo(veiculoPlaca.Terceiros_TipoProprietario)) comboVeiculoTerceiro_TipoProprietario.SelectedValue = veiculoPlaca.Terceiros_TipoProprietario;
                    textVeiculoTerceiro_IEProprietario.Text = veiculoPlaca.Terceiros_IEProprietario;
                    textVeiculoTerceiro_RNTCProprietario.Text = veiculoPlaca.Terceiros_RNTRCProprietario;
                    textVeiculoTerceiro_CPFCNPJProprietario.Text = veiculoPlaca.Terceiros_CPFCNPJProprietario;
                    textVeiculoTerceiro_NomeProprietario.Text = veiculoPlaca.Terceiros_NomeProprietario;
                    numericCapacidadeM3.Value = (decimal)veiculoPlaca.CapacidadeM3;
                    textRenavam.Text = veiculoPlaca.Renavam;
                    if (!Funcao.Nulo(veiculoPlaca.TipoCarroceria)) comboTipoCarroceria.SelectedValue = veiculoPlaca.TipoCarroceria;
                    if (!Funcao.Nulo(veiculoPlaca.TipoRodado)) comboTipoRodado.SelectedValue = veiculoPlaca.TipoRodado;
                    numericCapacidadeKG.Value = (decimal)veiculoPlaca.CapacidadeKG;
                    numericTaraKG.Value = (decimal)veiculoPlaca.TaraKG;
                    if (!Funcao.Nulo(veiculoPlaca.Terceiros_EstadoProprietarioId)) comboVeiculoTerceiro_UFProprietario.SelectedValue = veiculoPlaca.Terceiros_EstadoProprietarioId;
                }
            }
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private async void botaoGravar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPlaca.Text))
            {
                CaixaMensagem.Informacao("Informe a placa");
                return;
            }
            if (checkDadosVeiculoVeiculoTerceiro_Sim.Checked)
            {
                if (string.IsNullOrEmpty(textVeiculoTerceiro_NomeProprietario.Text))
                {
                    CaixaMensagem.Informacao("Informe o nome do proprietário");
                    return;
                }
                if (string.IsNullOrEmpty(textVeiculoTerceiro_CPFCNPJProprietario.Text))
                {
                    CaixaMensagem.Informacao("Informe um C.P.F./C.N.P.J. proprietário");
                    return;
                }
            }
            
            try
            {
                VeiculoPlacaViewModel veiculoPlaca = new VeiculoPlacaViewModel();

                veiculoPlaca.Id = veiculoPlacaId;
                veiculoPlaca.NumeroPlaca = textPlaca.Text.Trim();
                veiculoPlaca.EstadoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboUF);
                if (comboVeiculoTerceiro_TipoProprietario.SelectedIndex != -1) { veiculoPlaca.Terceiros_TipoProprietario = (MDFe_TipoProprietario)comboVeiculoTerceiro_TipoProprietario.SelectedValue; };
                veiculoPlaca.Terceiros_IEProprietario = textVeiculoTerceiro_IEProprietario.Text.Trim();
                veiculoPlaca.Terceiros_RNTRCProprietario = textVeiculoTerceiro_RNTCProprietario.Text.Trim();
                veiculoPlaca.Terceiros_CPFCNPJProprietario = textVeiculoTerceiro_CPFCNPJProprietario.Text.Trim();
                veiculoPlaca.Terceiros_NomeProprietario = textVeiculoTerceiro_NomeProprietario.Text.Trim();
                veiculoPlaca.CapacidadeM3 = (double)numericCapacidadeM3.Value;
                veiculoPlaca.Renavam = textRenavam.Text.Trim();
                if (comboTipoCarroceria.SelectedIndex != -1) { veiculoPlaca.TipoCarroceria = (MDFe_TipoCarroceria)comboTipoCarroceria.SelectedValue; }
                if (comboTipoRodado.SelectedIndex != -1) { veiculoPlaca.TipoRodado = (MDFe_TipoRodado)comboTipoRodado.SelectedValue; }
                veiculoPlaca.CapacidadeKG = (double)numericCapacidadeKG.Value;
                veiculoPlaca.TaraKG = (double)numericTaraKG.Value;
                veiculoPlaca.Terceiros_EstadoProprietarioId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboVeiculoTerceiro_UFProprietario);

                using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
                {
                    if (veiculoPlaca.Id == Guid.Empty)
                    {
                        Cadastrado = true;
                        await veiculoPlacaController.Adicionar(veiculoPlaca);

                        await PesquisarTipoFiltro();
                    }
                    else
                    {
                        await veiculoPlacaController.Atualizar(veiculoPlaca.Id, veiculoPlaca);
                    }
                }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void comboPesquisarTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            await PesquisarTipoFiltro();
        }

        private async Task PesquisarTipoFiltro()
        {
            Limpar();

            using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<VeiculoPlacaViewModel> veiculoPlaca;

                switch (comboPesquisarTipoFiltro.SelectedValue)
                {
                    case TipoPesquisa.Placa:
                        veiculoPlaca = await veiculoPlacaController.ObterTodos(order: o => o.NumeroPlaca);
                        Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                                "ID", "Nome",
                                                ComboBoxStyle.DropDownList,
                                                veiculoPlaca.Select(s => new NomeComboViewModel { Id = s.Id, Nome = s.NumeroPlaca }).ToList());
                        break;
                    case TipoPesquisa.Renavem:
                        veiculoPlaca = await veiculoPlacaController.ObterTodos(order: o => o.Renavam, predicate: w => !String.IsNullOrEmpty(w.Renavam));
                        Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                                "ID", "Nome",
                                                ComboBoxStyle.DropDownList,
                                                veiculoPlaca.Select(s => new NomeComboViewModel { Id = s.Id, Nome = s.Renavam }).ToList());
                        break;
                    case TipoPesquisa.CPF_CNPJProprietario:
                        veiculoPlaca = await veiculoPlacaController.ObterTodos(order: o => o.Terceiros_CPFCNPJProprietario, predicate: w => !String.IsNullOrEmpty(w.Terceiros_CPFCNPJProprietario));
                        Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                                "ID", "Nome",
                                                ComboBoxStyle.DropDownList,
                                                veiculoPlaca.Select(s => new NomeComboViewModel { Id = s.Id, Nome = s.Terceiros_CPFCNPJProprietario }).ToList());
                        break;
                    case TipoPesquisa.NomeProprietario:
                        veiculoPlaca = await veiculoPlacaController.ObterTodos(order: o => o.Terceiros_NomeProprietario, predicate: w => !String.IsNullOrEmpty(w.Terceiros_NomeProprietario));
                        Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                                "ID", "Nome",
                                                ComboBoxStyle.DropDownList,
                                                veiculoPlaca.Select(s => new NomeComboViewModel { Id = s.Id, Nome = s.Terceiros_NomeProprietario }).ToList());
                        break;
                }
            }
        }
        private void Limpar()
        {
            veiculoPlacaId = Guid.Empty;
            textPlaca.Text = "";
            checkDadosVeiculoVeiculoTerceiro_Sim.Checked = false;
            numericCapacidadeM3.Value = 0;
            textRenavam.Text = "";
            comboTipoCarroceria.SelectedValue = MDFe_TipoCarroceria.NaoAplicavel;
            numericCapacidadeKG.Value = 0;
            numericTaraKG.Value = 0;
            comboUF.SelectedIndex =-1;
            comboTipoRodado.SelectedValue = MDFe_TipoRodado.Outros;
            LimparVeiculoTerceiro();
        }
        private void LimparVeiculoTerceiro(bool limparTudo = true)
        {
            if (limparTudo) { checkDadosVeiculoVeiculoTerceiro_Sim.Checked = false; }
            groupVeículoTerceiro.Enabled = false;
            comboVeiculoTerceiro_UFProprietario.SelectedIndex = -1;
            comboVeiculoTerceiro_TipoProprietario.SelectedValue = MDFe_TipoProprietario.Outros;
            textVeiculoTerceiro_IEProprietario.Text = "";
            textVeiculoTerceiro_RNTCProprietario.Text = "";
            textVeiculoTerceiro_CPFCNPJProprietario.Text = "";
            textVeiculoTerceiro_NomeProprietario.Text = "";
        }
        private async void comboPesquisarPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CarregaDados();
        }

        private void checkDadosVeiculoVeiculoTerceiro_Sim_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkDadosVeiculoVeiculoTerceiro_Sim.Checked)
            {
                LimparVeiculoTerceiro(false);
            }
        }
    }
}
