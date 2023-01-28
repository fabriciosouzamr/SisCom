using Funcoes.Interfaces;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroVeiculoPlaca : FormMain
    {

        enum TipoPesquisa
        {
            [Description("Placa do Veículo")]
            Placa = 0,
            [Description("Renavem do Veículo")]
            Renavem = 1,
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
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private async Task CarregaDados()
        {

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
