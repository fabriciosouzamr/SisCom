using Funcoes.Interfaces;
using Newtonsoft.Json.Linq;
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
    public partial class frmCadastroVeiculoPlaca : Form
    {
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
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private async Task CarregaDados()
        {
            using (VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<VeiculoPlacaViewModel> veiculoPlaca;

                switch(comboPesquisarTipoFiltro.SelectedValue)
                {
                    case TipoPesquisa.Placa:
                        veiculoPlaca = await veiculoPlacaController.ObterTodos(order: o => o.NumeroPlaca);
                        Combo_ComboBox.Formatar(comboPesquisarPesquisa,
                                                "ID", "Nome",
                                                ComboBoxStyle.DropDownList,
                                                veiculoPlaca.Select(s => new NomeComboViewModel { Id = s.Id, Nome = s.NumeroPlaca }));
                        break;
                }
            }
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
        }
        private void comboPesquisarTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
