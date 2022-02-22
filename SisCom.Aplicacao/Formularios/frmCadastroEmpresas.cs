using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroEmpresas : Form
    {
        FormMain FormMain;
        Guid EmpresaId = Guid.Empty;
        bool Editado = false;

        public frmCadastroEmpresas(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory)
        {
            InitializeComponent();
            FormMain = new FormMain(serviceProvider, dbCtxFactory);

            Inicializar();
        }

        #region Combos
        private async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEstado,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(FormMain.MeuDbContext())).Combo(p => p.Nome));
            FormMain.MeuDbContextDispose();
        }
        private async Task comboPesquisar_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisa,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await(new EmpresaController(FormMain.MeuDbContext())).Combo());
            FormMain.MeuDbContextDispose();
        }
        private async Task comboCidade_Carregar(Guid EstadoId)
        {
            Combo_ComboBox.Formatar(comboCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(FormMain.MeuDbContext())).ComboEstado(EstadoId, p => p.Nome)) ;
            FormMain.MeuDbContextDispose();
        }
        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboEstado))
            {
                comboCidade_Carregar(Guid.Parse(comboEstado.SelectedValue.ToString()));
            }
        }
        #endregion

        #region Botoes
        private void botaoExcluir_ClickAsync(object sender, EventArgs e)
        {
            Excluir();
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoBuscaCEP_Click(object sender, EventArgs e)
        {

        }
        private void botaoBuscarLogomarca_Click(object sender, EventArgs e)
        {

        }
        private void botaoRetirarLogomarca_Click(object sender, EventArgs e)
        {

        }
        private void botaoSelecionarCertificado_Click(object sender, EventArgs e)
        {

        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            if (Texto_TextBox.ValidaVazio(textUnidade, "")) return;
        }
        #endregion

        #region Funcoes
        private async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboRegimeTributario, "", "", ComboBoxStyle.DropDownList, null, typeof(RegimeTributario));
            Combo_ComboBox.Formatar(comboNFEAmbiente, "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));
            Combo_ComboBox.Formatar(comboNFEVersaoLayout, "", "", ComboBoxStyle.DropDownList, null, typeof(NFE_Layout));
            Combo_ComboBox.Formatar(comboSpedGrupoInventario, "", "", ComboBoxStyle.DropDownList, null, typeof(Sped_TipoGeracaoInventario));
            Combo_ComboBox.Formatar(comboMDFeAmbiente , "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));
            Combo_ComboBox.Formatar(comboMDFeTipoEmissor, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoEmissor));
            Combo_ComboBox.Formatar(comboNuvemFiscalAmbienteWebService, "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));

            await comboEstado_Carregar();
           // await comboPesquisar_Carregar();

            Limpar();
        }
        private void Limpar()
        {
            EmpresaId = Guid.Empty;
            comboPesquisa.SelectedIndex =-1;
            labelEmpresa.Text = "";
            textUnidade.Text = "";
            textRazaoSocial.Text = "";
            textNomeFantasia.Text = "";
            textCNPJ.Text = "";
            textInscricaoMunicipal.Text = "";
            textInscricaoEstadual.Text = "";
            textInscricaoEstadualSubTributaria.Text = "";
            textEndereco.Text = "";
            textNumero.Text = "";
            textBairro.Text = "";
            textCEP.Text = ""; 
            comboEstado.SelectedIndex = -1;
            comboCidade.SelectedIndex = -1;
            textTelefone.Text = "";
            textEmail.Text = "";
            comboRegimeTributario.SelectedIndex = -1;
            numericCreditoSimplesNacional.Value  = 0;
            comboNFEAmbiente.SelectedIndex = -1;
            comboNFEVersaoLayout.SelectedIndex = -1;
            textNFESerie.Text = "";
            textNFEVersaoEmissor.Text  = "";
            textCaminhoLogomarca.Text = "";
            pictureLogomarca.Image = null;
            comboSpedGrupoInventario.SelectedIndex = -1;
            textMDFeSerie.Text = "";
            comboMDFeAmbiente.SelectedIndex =-1;
            comboMDFeTipoEmissor.SelectedIndex =-1;
            textNuvemFiscalCertificado.Text = "";
            checkUtilizarNuvemFiscal.Checked = false;
            comboNuvemFiscalAmbienteWebService.SelectedIndex =-1;
            Editado = false;
        }
        private async Task Excluir()
        {
            if (EmpresaId == Guid.Empty)
            {
                CaixaMensagem.Informacao("Seleciona a empresa a ser excluída");
            }
            else
            {
                if (CaixaMensagem.Perguntar("Deseja realmente excluir essa empresa?"))
                {
                    try
                    {
                        await (new FabricanteController(FormMain.MeuDbContext())).Remover(EmpresaId);
                        FormMain.MeuDbContextDispose();
                    }
                    catch (Exception Ex)
                    {

                        CaixaMensagem.Informacao(Ex.Message);
                    }
                }
            }
        }
        private async Task Gravar()
        {

        }
        private void textoTextChanged(object sender, EventArgs e)
        {
            Editado = true;
        }
        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Editado = true;
        }
        #endregion

        private void frmCadastroEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Editado)
            {
                if (CaixaMensagem.Perguntar("Existem dados não salvos, pretendem sair sem salvá-los?"))
                {
                    e.Cancel = true;
                    return;
                }
            }

            FormMain.Dispose();
        }
    }
}
