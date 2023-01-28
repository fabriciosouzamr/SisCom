using Funcoes.Interfaces;
using Newtonsoft.Json.Linq;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
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

                Limpar();
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private async Task CarregaDados()
        {
            Limpar();

            if (comboPesquisarPesquisa.SelectedIndex != -1)
            {
                using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
                {
                    var veiculoPlaca = veiculoPlacaController.GetById((Guid)comboPesquisarPesquisa.SelectedValue);
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
                if (comboVeiculoTerceiro_TipoProprietario.SelectedIndex == -1) { veiculoPlaca.Terceiros_TipoProprietario = (MDFe_TipoProprietario)comboVeiculoTerceiro_TipoProprietario.SelectedValue; };
                veiculoPlaca.Terceiros_IEProprietario = textVeiculoTerceiro_IEProprietario.Text.Trim();
                veiculoPlaca.Terceiros_RNTRCProprietario = textVeiculoTerceiro_RNTCProprietario.Text.Trim();
                veiculoPlaca.Terceiros_CPFCNPJProprietario = textVeiculoTerceiro_CPFCNPJProprietario.Text.Trim();
                veiculoPlaca.Terceiros_NomeProprietario = textVeiculoTerceiro_NomeProprietario.Text.Trim();
                veiculoPlaca.CapacidadeM3 = (double)numericCapacidadeM3.Value;
                veiculoPlaca.Renavam = textRenavam.Text.Trim();
                if (comboTipoCarroceria.SelectedIndex == -1) { veiculoPlaca.TipoCarroceria = (MDFe_TipoCarroceria)comboTipoCarroceria.SelectedValue; }
                if (comboTipoRodado.SelectedIndex == -1) { veiculoPlaca.TipoRodado = (MDFe_TipoRodado)comboTipoRodado.SelectedValue; }
                veiculoPlaca.CapacidadeKG = (double)numericCapacidadeKG.Value;
                veiculoPlaca.TaraKG = (double)numericTaraKG.Value;
                veiculoPlaca.Terceiros_EstadoProprietarioId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboVeiculoTerceiro_UFProprietario);

                using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
                {
                    if (veiculoPlaca.Id == Guid.Empty)
                    {
                        await veiculoPlacaController.Adicionar(veiculoPlaca);
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
        private void LimparVeiculoTerceiro()
        {
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

        private void checkDadosVeiculoVceiuloTerceiro_Sim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDadosVeiculoVeiculoTerceiro_Sim.Checked)
            {
                LimparVeiculoTerceiro();
            }
        }
    }
}
