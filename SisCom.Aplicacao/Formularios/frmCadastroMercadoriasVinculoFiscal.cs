using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroMercadoriasVinculoFiscal : Form
    {
        public frmCadastroMercadoriasVinculoFiscal()
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Funcoes
        private async void Inicializar()
        {
            LimparTela();
        }

        private void LimparTela()
        {
            //Pesquisar
            comboPesquisarPesquisa.SelectedIndex = -1;
            //Tributação ECF/NFCe
            comboTributacao_ECFNFCeSituacao.SelectedIndex = -1;
            numericTributacao_ECFNFCeNFCeAliquota.Value = 0;
            comboTributacao_ECFNFCeTipoServico.SelectedIndex = -1;
            //Detalhes Fiscais
            comboDetalhesFiscais_Especifico.SelectedIndex = -1;
            comboDetalhesFiscais_NCM.SelectedIndex = -1;
            comboDetalhesFiscais_CEST.SelectedIndex = -1;
            comboDetalhesFiscais_Origem.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita.SelectedIndex = -1;
            //Detalhes Fiscais - SEP
            comboDetalhesFiscais_SPED_TipoItem.SelectedIndex = -1;
            comboDetalhesFiscais_SPED_CodigoGenero.SelectedIndex = -1;
            //Detalhes Fiscais - Outros.
            numericDetalhesFiscais_OutrosPMC.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value = 0;
            //Mercadorias
            Grid_DataGridView.User_Formatar(gridMercadorias);
            Grid_DataGridView.User_ColunaAdicionar(gridMercadorias, "Código", "Codigo");
            Grid_DataGridView.User_ColunaAdicionar(gridMercadorias, "Referência", "Referencia");
            Grid_DataGridView.User_ColunaAdicionar(gridMercadorias, "Mercadoria", "Mercadoria");
            Grid_DataGridView.User_Formatar(gridMercadorias);
            //Produção
        }
        #endregion

        private void frmCadastrosMercadoriasVinculoFiscal_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void botaoDetalhesFiscais_NCM_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasNCM()).ShowDialog();
        }

        private void botaoDetalhesFiscais_CST_CSOSN_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasCST()).ShowDialog();
        }

        private void botaoFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
