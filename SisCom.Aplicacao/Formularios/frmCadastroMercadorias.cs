using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroMercadorias : FormMain
    {
        ViewModels.MercadoriaViewModel mercadoria = null;
        bool carregandoDados = false;

        const int gridImpostosICMS_ID = 0;
        const int gridImpostosICMS_Codigo = 1;

        enum TipoPesquisa
        {
            [Description("Código")]
            Codigo = 0,
            [Description("Referência")]
            Referencia = 1,
            [Description("Mercadoria")]
            Mercadoria = 3,
            [Description("Observação")]
            Observacao = 4
        }
        public frmCadastroMercadorias(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();

            this.Height = 780;
        }
        #region Combos
        private async Task<bool> comboGrupoProduto_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboGrupoMercadoria,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new GrupoMercadoriaController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboFornecedor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFornecedor,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(meuDbContext, this._notifier)).ComboFornecedor(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboFabricante_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFabricante,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new FabricanteController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboUnidadeMedida_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboEstoque_Unidade,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new UnidadeMedidaController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboTabelaSituacaoTributariaNFCe_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboTributacao_ECFNFCeSituacao,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaSituacaoTributariaNFCeController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboTributacao_ECFNFCeTipoServico_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboTributacao_ECFNFCeTipoServico,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new TipoServicoFiscalController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboTributacaoECFNFCeCFOP_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboTributacaoECFNFCeCFOP,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCFOPController(meuDbContext, this._notifier)).Combo(entradaSaida: Funcoes._Enum.EntradaSaida.Saida, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_VinculoFiscal_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_VinculoFiscal,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new VinculoFiscalController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_Especifico_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_Especifico,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new TipoMercadoriaController(meuDbContext, this._notifier)).Combo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_CodigoANP_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_CodigoANP_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaANPController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_CodigoANP_Descricao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_CodigoANP_Descricao,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaANPController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_NCM_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_NCM,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaNCMController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_CEST_Carregar(Guid tabelaNCMId)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_CEST,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCESTController(meuDbContext, this._notifier)).Combo(tabelaNCMId, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_CST_CSOSN_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_CST_CSOSN_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_CSOSNController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_CST_CSOSN_Descricao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_CST_CSOSN_Descricao,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_CSOSNController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_OrigemMercadoria_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_OrigemMercadoria,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaOrigemMercadoriaServicoController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_Beneficio_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_BeneficioSped,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaBeneficioSPEDController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_IPIController(meuDbContext, this._notifier)).ComboCodigo(Funcoes._Enum.EntradaSaida.Entrada, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_IPIController(meuDbContext, this._notifier)).ComboDescricao(Funcoes._Enum.EntradaSaida.Entrada, p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_PIS_COFINSController(meuDbContext, this._notifier)).ComboCodigoUsaEntrada(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_PIS_COFINSController(meuDbContext, this._notifier)).ComboCodigoUsaEntrada(p => p.Codigo)); ;
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaModalidadeDeterminacaoBCICMSController(meuDbContext, this._notifier)).Combo(Entidade.Enum.TipoModalidadeDeterminacaoBCICMS.BC_ICMS, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaMotivoDesoneracaoICMSController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaModalidadeDeterminacaoBCICMSController(meuDbContext, this._notifier)).Combo(Entidade.Enum.TipoModalidadeDeterminacaoBCICMS.BC_ICMS_ST, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(meuDbContext, this._notifier)).ComboCodigo(Funcoes._Enum.EntradaSaida.Saida, p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_IPIController(meuDbContext, this._notifier)).ComboDescricao(Funcoes._Enum.EntradaSaida.Saida, p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaClasseEnquadramentoIPIController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCodigoEnquadramentoIPIController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaCST_PIS_COFINSController(meuDbContext, this._notifier)).ComboCodigoUsaSaida(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_PIS_COFINSController(meuDbContext, this._notifier)).ComboCodigoUsaSaida(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new GrupoNaturezaReceita_CTS_PIS_COFINSController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_SPED_TipoItem_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_TipoItem,
                                    "ID", "Descricao",
                                    ComboBoxStyle.DropDownList,
                                    await (new TabelaSpedTipoItemController(meuDbContext, this._notifier)).Combo(p => p.Descricao)); ;
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_SPED_CodigoGenero_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_CodigoGenero,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaSpedCodigoGeneroController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private async Task<bool> comboDetalhesFiscais_SPED_CodigoInformacaoAdicional_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDetalhesFiscais_SPED_CodigoInformacaoAdicional,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaSpedInformacaoAdicionalItemController(meuDbContext, this._notifier)).Combo(p => p.Descricao));
            }

            return true;
        }
        private void comboPesquisarPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo))
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedItem).Descricao;
                }
                else
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = "";
                }
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex != -1) comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedValue = comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedValue;
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex != -1) comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedValue = comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedValue;
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo))
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedItem).Descricao;
                }
                else
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = "";
                }
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedIndex != -1) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedValue = comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedValue;
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedIndex != -1) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedValue = comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedValue;
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo))
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedItem).Descricao;
                }
                else
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = "";
                }
        }
        private void comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo))
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedItem).Descricao;
                }
                else
                {
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = "";
                }
        }
        private void comboDetalhesFiscais_NCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (Combo_ComboBox.Selecionado(comboDetalhesFiscais_NCM))
                    NCMCarregarDependentes();
        }
        private void comboDetalhesFiscais_CST_CSOSN_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedIndex != -1) comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedValue = comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedValue;
        }
        private void comboDetalhesFiscais_CST_CSOSN_Descricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoDados)
                if (comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedIndex != -1) comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedValue = comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedValue;
        }
        #endregion
        #region Botoes
        private void botaoFabricante_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroFabricante>();
            form.GravacaoEfetuada += CadastroFabricanteAtualizado;
            form.ShowDialog(this);
        }
        private void botaoGrupoProduto_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroGrupo>();
            form.ShowDialog(this);
        }
        private void botaoSubGrupo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroGrupo>();
            form.ShowDialog(this);
        }
        private void botaoDetalhesFiscais_VinculoFiscal_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasVinculoFiscal()).ShowDialog();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            TentarGravar();
            Close();
        }
        private void botaoDetalhesFiscais_NCM_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasNCM()).ShowDialog();
        }
        private void botaoDetalhesFiscais_CST_CSOSN_Click(object sender, EventArgs e)
        {
            (new frmCadastroMercadoriasCST()).ShowDialog();
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
        private void botaoFornecedor_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroFornecedores>();
            form.ShowDialog(this);
        }
        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(mercadoria.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Anterior);
        }
        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(mercadoria.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Proximo);
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            mercadoria = new ViewModels.MercadoriaViewModel();
            Limpar();
        }
        #endregion
        #region Funcoes
        private void CadastroFabricanteAtualizado(object? sender, EventArgs e)
        {
            comboFabricante_Carregar();
        }
        private async Task Inicializar()
        {
            pnlDadosGerais.Enabled = false;
            tabControl.Enabled = false;

            labelCalculoPreco.Text = Declaracoes.calculoPreco.ToString();
            labelCalculoPrecificacao.Text = Declaracoes.tipoCalculo.ToString();
            numericPreco_numericPreco_PrecoCompra_Calcular();

            try
            {
                tabControl.TabPages.Remove(tabProducao);
                tabControl.TabPages.Remove(tabFotoEspecificacao);
                tabControl.TabPages.Remove(tabIntegracao);
                tabControl.TabPages.Remove(tabSimiliares);

                //Pesquisar
                Combo_ComboBox.Formatar(comboPesquisarTipoFiltro, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPesquisa));

                //Cabeçalho
                await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
                await Assincrono.TaskAsyncAndAwaitAsync(InicializarGridImpostos());

                Limpar();

                mercadoria = new ViewModels.MercadoriaViewModel();
                Navegar(Declaracoes.eNavegar.Primeiro);
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Cadastro de Mercadoria - Inicializar", ex);
            }

            pnlDadosGerais.Enabled = true;
            tabControl.Enabled = true;
        }
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboGrupoProduto_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFornecedor_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFabricante_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboUnidadeMedida_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboTabelaSituacaoTributariaNFCe_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboTributacao_ECFNFCeTipoServico_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboTributacaoECFNFCeCFOP_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_VinculoFiscal_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_Especifico_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_CodigoANP_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_CodigoANP_Descricao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_NCM_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_CST_CSOSN_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_CST_CSOSN_Descricao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_OrigemMercadoria_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_Beneficio_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_SPED_TipoItem_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_SPED_CodigoGenero_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_SPED_CodigoInformacaoAdicional_Carregar());

            return true;
        }
        private async Task<bool> InicializarGridImpostos()
        {
            IEnumerable<EstadoViewModel> estados;

            using (EstadoController estadoController = new EstadoController(this.MeuDbContext(), this._notifier))
            {
                estados = await estadoController.ObterTodos(o => o.Codigo);
            }

            Grid_DataGridView.User_Formatar(gridImpostosICMS, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.User_ColunaAdicionar(gridImpostosICMS, "Id", "Id", Tamanho: 0);
            Grid_DataGridView.User_ColunaAdicionar(gridImpostosICMS, "UF", " ", Tamanho: 30);

            foreach (EstadoViewModel estado in estados)
            {
                Grid_DataGridView.User_ColunaAdicionar(gridImpostosICMS, estado.Codigo, estado.Codigo, Tamanho: 40, 
                                                                                                               Tipo: Grid_DataGridView.TipoColuna.Numero, 
                                                                                                               readOnly: false,
                                                                                                               alinhamento: DataGridViewContentAlignment.MiddleCenter).Tag = estado.Id;
                Grid_DataGridView.User_LinhaAdicionar(gridImpostosICMS, new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridImpostosICMS_ID,
                                                                                                                                                Valor = estado.Id },
                                                                                                                 new Grid_DataGridView.Coluna { Indice = gridImpostosICMS_Codigo,
                                                                                                                                                Valor = estado.Codigo }}).Tag = estado.Id;
            }

            return true;
        }
        private void Limpar()
        {
            //Pesquisar
            comboPesquisarTipoFiltro.SelectedIndex = -1;
            comboPesquisarPesquisa.SelectedIndex = -1;
            //Cabeçalho
            labelCodigoMercadoria.Text = "0000";
            textReferencia.Text = "";
            textCodigoNFe.Text = "";
            textNomeMercadoria.Text = "";
            comboGrupoMercadoria.SelectedIndex = -1;
            comboSubGrupoMercadoria.SelectedIndex = -1;
            comboFornecedor.SelectedIndex = -1;
            comboFabricante.SelectedIndex = -1;
            textObservacao.Text = "";
            //Preço Estoque - Preço
            numericPreco_PrecoCompra.Value = 0;
            numericPreco_ICMSCompra.Value = 0;
            labelPreco_ValorICMSCompra.Text = Valor.Formatar(0);
            numericPreco_ICMSFronteira.Value = 0;
            labelPreco_ValorICMSFronteira.Text = Valor.Formatar(0);
            numericPreco_IPI.Value = 0;
            labelPreco_ValorIPI.Text = Valor.Formatar(0);
            numericPreco_Frete.Value = 0;
            labelPreco_ValorFrete.Text = Valor.Formatar(0);
            numericPreco_Embalagem.Value = 0;
            labelPreco_ValorEmbalagem.Text = Valor.Formatar(0);
            numericPreco_EncFinanceiros.Value = 0;
            labelPreco_ValorEncFinanceiros.Text = Valor.Formatar(0);
            labelPreco_ValorCustoMercadoria.Text = Valor.Formatar(0);
            numericPreco_CustoFixo.Value = 0;
            labelPreco_ValorCustoFixo.Text = Valor.Formatar(0);
            numericPreco_ImpostosFederais.Value = 0;
            labelPreco_ValorImpostosFederais.Text = Valor.Formatar(0);
            numericPreco_ICMSVenda.Value = 0;
            labelPreco_ValorICMSVenda.Text = Valor.Formatar(0);
            numericPreco_Comissao.Value = 0;
            labelPreco_ValorComissao.Text = Valor.Formatar(0);
            numericPreco_Marketing.Value = 0;
            labelPreco_ValorMarketing.Text = Valor.Formatar(0);
            numericPreco_OutrosCustos.Value = 0;
            labelPreco_ValorOutrosCustos.Text = Valor.Formatar(0);
            //Preço Estoque - Ponto Equilíbrio
            labelMargem_PontoEquilibrio.Text = "0000";
            numericMargem_MargemSugerido.Value = 0;
            labelMargem_ValorlMargemSugerido.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoSugerido.Text = Valor.Formatar(0);
            numericMargem_PrecoVenda.Value = 0;
            labelMargem_MargemVenda.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoVenda.Text = Valor.Formatar(0);
            numericMargem_PrecoA.Value = 0;
            labelMargem_MargemPrecoA.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoA.Text = Valor.Formatar(0);
            numericMargem_PrecoB.Value = 0;
            labelMargem_MargemPrecoB.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoB.Text = Valor.Formatar(0);
            numericMargem_PrecoC.Value = 0;
            labelMargem_MargemPrecoC.Text = Valor.Formatar(0);
            labelMargem_ValorPrecoC.Text = Valor.Formatar(0);
            //Preço Estoque - Estoque
            labelEstoque_Quantidade.Text = "0000";
            numericEstoque_EstoqueMinimo.Value = 0;
            comboEstoque_Unidade.SelectedIndex = -1;
            textEstoque_Pratileira.Text = "";
            numericEstoque_PesoBruto.Value = 0;
            numericEstoque_PesoLiquido.Value = 0;
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_UltimaEntrada);
            Data_DateTimePicker.DateTimePicker_Formatar(dateEstoque_AlteracaoPreco);
            //Tributação ECF/NFCe
            comboTributacao_ECFNFCeSituacao.SelectedIndex = -1;
            numericTributacao_ECFNFCeNFCeAliquotaICMS.Value = 0;
            comboTributacao_ECFNFCeTipoServico.SelectedIndex = -1;
            textTributacao_ECFNFCeTipoServicoMunicipal.Text = "";
            //Preço Estoque - Outros
            checkNaoVender.Checked = false;
            checkNaoControlarEstoque.Checked = false;
            checkDesativado.Checked = false;
            //Detalhes Fiscais
            comboDetalhesFiscais_VinculoFiscal.SelectedIndex = -1;
            textDetalhesFiscais_InformacaoAdicional.Text = "";
            comboDetalhesFiscais_Especifico.SelectedIndex = -1;
            comboDetalhesFiscais_CodigoANP_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_CodigoANP_Descricao.SelectedIndex = -1;
            textDetalhesFiscais_CodigoAnvisa.Text = "";
            comboDetalhesFiscais_NCM.SelectedIndex = -1;
            comboDetalhesFiscais_CEST.SelectedIndex = -1;
            comboDetalhesFiscais_OrigemMercadoria.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedIndex = -1;
            comboDetalhesFiscais_BeneficioSped.SelectedIndex = -1;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedIndex = -1;
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = "";
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
            textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedIndex = -1;
            textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = "";
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = 0;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita.SelectedIndex = -1;
            comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita.SelectedIndex = -1;
            //Detalhes Fiscais - SEP
            comboDetalhesFiscais_SPED_TipoItem.SelectedIndex = -1;
            comboDetalhesFiscais_SPED_CodigoGenero.SelectedIndex = -1;
            comboDetalhesFiscais_SPED_CodigoInformacaoAdicional.SelectedIndex = -1;
            //Detalhes Fiscais - Outros.
            numericDetalhesFiscais_OutrosPMC.Value = 0;
            numericDetalhesFiscais_OutrosNVE.Value = 0;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value = 0;
            numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value = 0;
            //Detalhe de Estoque
            Grid_DataGridView.User_Formatar(gridEstoqueEmpresa);
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "Almoxarifado", "Almoxarifado");
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeEstoque", "Quantidade");
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeBloqueada", "Bloqueada");
            Grid_DataGridView.User_Formatar(gridEstoqueEmTransito);
            //Foto e Especificação
            textEspecificacao.Text = "";
            textURL.Text = "";
            checkUsarFoto.Checked = false;
            picFoto.Image = null;
            //Produção
            txtProducao_Configuracao_ValidadeDias.Value = 0;
            chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked = false;
            Grid_DataGridView.User_Formatar(gridProducao_Composicao);
            Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "MercadoriaComponente", "");
            Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "Quantidade", "Quantidade");
            Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "Sequencia", "Sequência");
            Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "PercentualPerdaQuebra", "% Perda/Quebra");
            //Integração
            Grid_DataGridView.User_Formatar(gridIntegracaoEmpresaFornecedor);
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "Fornecedor", "Fornecedor");
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "CodigoFonecedor", "Código");
            Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadePorCaixa", "Quantidade por Caixa");
            //Similares
            Grid_DataGridView.User_Formatar(gridListaMercadoriasSimilares);
            Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "Similar", "Nome");
            Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "Preco", "Preço");
            Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "QuantidadeEmEstoque", "Quantidade em Estoque");
        }
        private async Task CarregarDados()
        {
            if (mercadoria != null)
            {
                carregandoDados = true;
                labelCodigoMercadoria.Text = mercadoria.Codigo.ToString("00000");
                textReferencia.Text = Funcao.NuloParaString(mercadoria.CodigoFabricante);
                textCodigoNFe.Text = Funcao.NuloParaString(mercadoria.CodigoBarra);
                textNomeMercadoria.Text = Funcao.NuloParaString(mercadoria.Nome);
                if (!Funcao.Nulo(mercadoria.GrupoMercadoriaId)) comboGrupoMercadoria.SelectedValue = mercadoria.GrupoMercadoriaId;
                if (!Funcao.Nulo(mercadoria.SubGrupoMercadoriaId)) comboSubGrupoMercadoria.SelectedValue = mercadoria.SubGrupoMercadoriaId;
                if (!Funcao.Nulo(mercadoria.FornecedorId)) comboFornecedor.SelectedValue = mercadoria.FornecedorId;
                if (!Funcao.Nulo(mercadoria.FabricanteId)) comboFabricante.SelectedValue = mercadoria.FabricanteId;
                textObservacao.Text = Funcao.NuloParaString(mercadoria.Observacao);
                //Preço Estoque - Preço
                numericPreco_PrecoCompra.Value = mercadoria.Preco_PrecoCompra;
                numericPreco_ICMSCompra.Value = mercadoria.Preco_ICMS_Compra;
                numericPreco_ICMSFronteira.Value = mercadoria.Preco_PrecoCompra;
                numericPreco_IPI.Value = mercadoria.Preco_IPI;
                numericPreco_Frete.Value = mercadoria.Preco_Frete;
                numericPreco_Embalagem.Value = mercadoria.Preco_Embalagem;
                numericPreco_EncFinanceiros.Value = mercadoria.Preco_EncFinanceiro;
                numericPreco_CustoFixo.Value = mercadoria.Preco_CustoFixo;
                numericPreco_ImpostosFederais.Value = mercadoria.Preco_ImpostoFederais;
                numericPreco_ICMSVenda.Value = mercadoria.Preco_ICMS_Venda;
                numericPreco_Comissao.Value = mercadoria.Preco_Comissao;
                numericPreco_Marketing.Value = mercadoria.Preco_Marketing;
                numericPreco_OutrosCustos.Value = mercadoria.Preco_OutrosCustos;
                numericPreco_numericPreco_PrecoCompra_Calcular();
                //Preço Estoque - Ponto Equilíbrio
                labelMargem_PontoEquilibrio.Text = "0000";
                numericMargem_MargemSugerido.Value = mercadoria.Preco_MargemSugerido;
                labelMargem_ValorPrecoSugerido.Text = Valor.Formatar((double)0);
                numericMargem_PrecoVenda.Value = mercadoria.Preco_PrecoVenda;
                labelMargem_MargemVenda.Text = Valor.Formatar((double)0);
                labelMargem_ValorPrecoVenda.Text = Valor.Formatar((double)numericMargem_PrecoVenda.Value);
                numericMargem_PrecoA.Value = mercadoria.Preco_PrecoA;
                labelMargem_MargemPrecoA.Text = Valor.Formatar((double)0);
                labelMargem_ValorPrecoA.Text = Valor.Formatar((double)numericMargem_PrecoA.Value);
                numericMargem_PrecoB.Value = mercadoria.Preco_PrecoB;
                labelMargem_MargemPrecoB.Text = Valor.Formatar((double)0);
                labelMargem_ValorPrecoB.Text = Valor.Formatar((double)numericMargem_PrecoB.Value);
                numericMargem_PrecoC.Value = mercadoria.Preco_PrecoC;
                labelMargem_MargemPrecoC.Text = Valor.Formatar((double)0);
                labelMargem_ValorPrecoC.Text = Valor.Formatar((double)numericMargem_PrecoC.Value);
                //Preço Estoque - Estoque
                numericEstoque_EstoqueMinimo.Value = (decimal)mercadoria.Estoque_QuantidadeMinimo;
                if (!Funcao.Nulo(mercadoria.Estoque_UnidadeMedidaId)) comboEstoque_Unidade.SelectedValue = mercadoria.Estoque_UnidadeMedidaId;
                textEstoque_Pratileira.Text = mercadoria.Estoque_Pratileira;
                numericEstoque_PesoBruto.Value = (decimal)mercadoria.Estoque_PesoBruto;
                numericEstoque_PesoLiquido.Value = (decimal)mercadoria.Estoque_PesoLiquido;
                if (!Funcao.NuloData(mercadoria.Estoque_UltimaEntrada)) dateEstoque_UltimaEntrada.Value = (DateTime)mercadoria.Estoque_UltimaEntrada;
                if (!Funcao.NuloData(mercadoria.Estoque_AlteracaoPreco)) dateEstoque_AlteracaoPreco.Value = (DateTime)mercadoria.Estoque_AlteracaoPreco;
                //Tributação ECF/NFCe
                if (!Funcao.Nulo(mercadoria.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId)) comboTributacao_ECFNFCeSituacao.SelectedValue = mercadoria.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId;
                numericTributacao_ECFNFCeNFCeAliquotaICMS.Value = mercadoria.Estoque_TributacaoNFCe_AliquotaICMS;
                if (!Funcao.Nulo(mercadoria.Estoque_TributacaoNFCe_TipoServicoFiscalId)) comboTributacao_ECFNFCeTipoServico.SelectedValue = mercadoria.Estoque_TributacaoNFCe_TipoServicoFiscalId;
                textTributacao_ECFNFCeTipoServicoMunicipal.Text = mercadoria.Estoque_TributacaoNFCe_TipoServicoMunicipal;
                //Preço Estoque - Outros
                checkNaoVender.Checked = mercadoria.NaoVender;
                checkNaoControlarEstoque.Checked = mercadoria.NaoControlarEstoque;
                checkDesativado.Checked = !mercadoria.Ativado;
                //Detalhes Fiscais
                if (!Funcao.Nulo(mercadoria.Fiscal_VinculoFiscalId)) comboDetalhesFiscais_VinculoFiscal.SelectedValue = mercadoria.Fiscal_VinculoFiscalId;
                textDetalhesFiscais_InformacaoAdicional.Text = Funcao.NuloParaString(mercadoria.Fiscal_InformacaoAdicional);
                if (!Funcao.Nulo(mercadoria.Fiscal_VinculoFiscalId)) comboDetalhesFiscais_Especifico.SelectedValue = mercadoria.Fiscal_VinculoFiscalId;
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaANPId))
                {
                    comboDetalhesFiscais_CodigoANP_Codigo.SelectedValue = mercadoria.Fiscal_TabelaANPId;
                    comboDetalhesFiscais_CodigoANP_Descricao.SelectedValue = mercadoria.Fiscal_TabelaANPId;
                }
                textDetalhesFiscais_CodigoAnvisa.Text = Funcao.NuloParaString(mercadoria.Fiscal_CodigoAnvisa);
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaNCMId))
                {
                    comboDetalhesFiscais_NCM.SelectedValue = mercadoria.Fiscal_TabelaNCMId;
                    await NCMCarregarDependentes();
                }
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaCESTId)) comboDetalhesFiscais_CEST.SelectedValue = mercadoria.Fiscal_TabelaCESTId;
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaOrigemMercadoriaServicoId)) comboDetalhesFiscais_OrigemMercadoria.SelectedValue = mercadoria.Fiscal_TabelaOrigemMercadoriaServicoId;
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaCST_CSOSNId)) comboDetalhesFiscais_CST_CSOSN_Codigo.SelectedValue = mercadoria.Fiscal_TabelaCST_CSOSNId;
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaCST_CSOSNId)) comboDetalhesFiscais_CST_CSOSN_Descricao.SelectedValue = mercadoria.Fiscal_TabelaCST_CSOSNId;
                if (!Funcao.Nulo(mercadoria.Fiscal_TabelaBeneficioSPEDId)) comboDetalhesFiscais_BeneficioSped.SelectedValue = mercadoria.Fiscal_TabelaBeneficioSPEDId;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
                if (!Funcao.Nulo(mercadoria.Fiscal_NFE_TabelaCST_IPIId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo.SelectedValue = mercadoria.Fiscal_NFE_TabelaCST_IPIId;
                    comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Descricao.SelectedValue = mercadoria.Fiscal_NFE_TabelaCST_IPIId;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value = mercadoria.Fiscal_NFE_IPI_Aliquota;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
                if (!Funcao.Nulo(mercadoria.Fiscal_NFE_TabelaCST_PISId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedValue = mercadoria.Fiscal_NFE_TabelaCST_PISId;
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo.SelectedItem).Descricao;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value = mercadoria.Fiscal_NFE_PIS_Aliquota;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFE_TabelaCST_COFINSId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedValue = mercadoria.Fiscal_NFE_TabelaCST_COFINSId;
                    textDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo.SelectedItem).Descricao;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value = mercadoria.Fiscal_NFE_COFINS_Aliquota;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase.SelectedValue = mercadoria.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value = mercadoria.Fiscal_NFS_ICMS_ValorAdicional;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value = mercadoria.Fiscal_NFS_ICMS_Deferimento;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value = mercadoria.Fiscal_NFS_ICMS_ReducaoBase;
                comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao.SelectedIndex = -1;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase.SelectedValue = mercadoria.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value = mercadoria.Fiscal_NFS_ICMSST_ValorAdicional;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value = mercadoria.Fiscal_NFS_ICMSST_Aliquota;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value = mercadoria.Fiscal_NFS_ICMSST_ReducaoBase;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_IPI_TabelaCST_IPIId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo.SelectedValue = mercadoria.Fiscal_NFS_IPI_TabelaCST_IPIId;
                    comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Descricao.SelectedValue = mercadoria.Fiscal_NFS_IPI_TabelaCST_IPIId;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value = mercadoria.Fiscal_NFS_IPI_ValorAliquota;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento.SelectedValue = mercadoria.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento.SelectedValue = mercadoria.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedValue = mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId;
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo.SelectedItem).Descricao;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value = mercadoria.Fiscal_NFS_PISCOFINS_PIS_ValorAliquota;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId))
                {
                    comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedValue = mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId;
                    textDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Descricao.Text = ((CodigoDescricaoComboViewModel)comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo.SelectedItem).Descricao;
                }
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value = mercadoria.Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita.SelectedValue = mercadoria.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId;
                if (!Funcao.Nulo(mercadoria.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId)) comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita.SelectedValue = mercadoria.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId;
                //Detalhes Fiscais - SEP
                if (!Funcao.Nulo(mercadoria.Fiscal_SPED_TabelaSpedTipoItemId)) comboDetalhesFiscais_SPED_TipoItem.SelectedValue = mercadoria.Fiscal_SPED_TabelaSpedTipoItemId;
                if (!Funcao.Nulo(mercadoria.Fiscal_SPED_TabelaSpedCodigoGeneroId)) comboDetalhesFiscais_SPED_CodigoGenero.SelectedValue = mercadoria.Fiscal_SPED_TabelaSpedCodigoGeneroId;
                if (!Funcao.Nulo(mercadoria.Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId)) comboDetalhesFiscais_SPED_CodigoInformacaoAdicional.SelectedValue = mercadoria.Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId;
                //Detalhes Fiscais - Outros.
                numericDetalhesFiscais_OutrosPMC.Value = mercadoria.Fiscal_OutrosPMC;
                numericDetalhesFiscais_OutrosNVE.Value = mercadoria.Fiscal_OutrosNVE;
                //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value = mercadoria.Fiscal_NFS_TributosFederais;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value = mercadoria.Fiscal_NFS_TributosMunicipais;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value = mercadoria.Fiscal_NFS_TributosEstaduais;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value = mercadoria.Fiscal_NFS_TributosTotal;
                numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value = mercadoria.Fiscal_NFS_ValorTributosTotal;
                //Detalhe de Estoque
                Grid_DataGridView.User_Formatar(gridEstoqueEmpresa);
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "Almoxarifado", "Almoxarifado");
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeEstoque", "Quantidade");
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadeBloqueada", "Bloqueada");
                Grid_DataGridView.User_Formatar(gridEstoqueEmTransito);
                //Foto e Especificação
                textEspecificacao.Text = Funcao.NuloParaString(mercadoria.FotoEspecificacao_Especificacao);
                textURL.Text = Funcao.NuloParaString(mercadoria.FotoEspecificacao_URL); ;
                checkUsarFoto.Checked = mercadoria.FotoEspecificacao_UsarFoto;
                if (!Imagem.NuloImagem(mercadoria.FotoEspecificacao_Imagem)) picFoto.Image = Imagem.ByteArrayToImage(mercadoria.FotoEspecificacao_Imagem);
                //Produção
                txtProducao_Configuracao_ValidadeDias.Value = mercadoria.Producao_Configuracao_ValidadeDias;
                chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked = mercadoria.Producao_Configuracao_NaoBaixarComposicaoVenda;
                Grid_DataGridView.User_Formatar(gridProducao_Composicao);
                Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "MercadoriaComponente", "");
                Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "Quantidade", "Quantidade");
                Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "Sequencia", "Sequência");
                Grid_DataGridView.User_ColunaAdicionar(gridProducao_Composicao, "PercentualPerdaQuebra", "% Perda/Quebra");
                //Integração
                Grid_DataGridView.User_Formatar(gridIntegracaoEmpresaFornecedor);
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "Fornecedor", "Fornecedor");
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "CodigoFonecedor", "Código");
                Grid_DataGridView.User_ColunaAdicionar(gridEstoqueEmpresa, "QuantidadePorCaixa", "Quantidade por Caixa");
                //Similares
                Grid_DataGridView.User_Formatar(gridListaMercadoriasSimilares);
                Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "Similar", "Nome");
                Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "Preco", "Preço");
                Grid_DataGridView.User_ColunaAdicionar(gridListaMercadoriasSimilares, "QuantidadeEmEstoque", "Quantidade em Estoque");

                using (MercadoriaImpostoEstadoController mercadoriaImpostoEstadoController = new MercadoriaImpostoEstadoController(this.MeuDbContext(), this._notifier))
                {
                    var mercadoriaImpostoEstados = await mercadoriaImpostoEstadoController.ObterPorMercadoriaId(mercadoria.Id);

                    foreach (MercadoriaImpostoEstadoViewModel mercadoriaImpostoEstado in mercadoriaImpostoEstados)
                    {
                        foreach (DataGridViewRow row in gridImpostosICMS.Rows)
                        {
                            foreach (DataGridViewCell celula in row.Cells)
                            {
                                if ((row.Tag != null) && (gridImpostosICMS.Columns[celula.ColumnIndex].Tag != null))
                                {
                                    celula.Tag = null;
                                    celula.Value = null;
                                        
                                    if ((mercadoriaImpostoEstado.EstadoOrigemId == Guid.Parse(row.Tag.ToString())) &&
                                        (mercadoriaImpostoEstado.EstadoDestinoId == Guid.Parse(gridImpostosICMS.Columns[celula.ColumnIndex].Tag.ToString())))
                                    {
                                        if (celula.Value != null)
                                            mercadoriaImpostoEstado.PercentualICMS = (decimal)celula.Value;
                                    }
                                }
                            }
                        }
                    }
                }

                using (EstoqueController estoqueController = new EstoqueController(this.MeuDbContext(), this._notifier))
                {
                    var estoque = await estoqueController.Obter(w => w.MercadoriaId == mercadoria.Id);

                    if (estoque.Any())
                    {
                        comboEstoque_Unidade.Enabled = false;
                        labelEstoque_Quantidade.Text = estoque.Sum(s => s.QuantidadeEmEstoque).ToString("0000");
                    }
                }

                carregandoDados = false;
            }
        }
        private async Task<bool> GravarMercadoria()
        {
            if (textNomeMercadoria.Text.Trim() == string.Empty)
            {
                CaixaMensagem.Informacao("Informe o nome da mercadoria!");
                return false;
            }
            if (!Combo_ComboBox.Selecionado(comboDetalhesFiscais_OrigemMercadoria))
            {
                CaixaMensagem.Informacao("Selecione a origem da mercadoria!");
                return false;
            }

            if (mercadoria == null)
                mercadoria = new ViewModels.MercadoriaViewModel();

            mercadoria.CodigoFabricante = Funcao.StringVazioParaNulo(textReferencia.Text);
            mercadoria.CodigoBarra = Funcao.StringVazioParaNulo(textCodigoNFe.Text);
            mercadoria.Nome = Funcao.StringVazioParaNulo(textNomeMercadoria.Text);
            mercadoria.GrupoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboGrupoMercadoria);
            mercadoria.SubGrupoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboSubGrupoMercadoria);
            mercadoria.FornecedorId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFornecedor);
            mercadoria.FabricanteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFabricante);
            mercadoria.Observacao = Funcao.StringVazioParaNulo(textObservacao.Text);
            //Preço Estoque - Preço
            mercadoria.Preco_PrecoCompra = numericPreco_PrecoCompra.Value;
            mercadoria.Preco_ICMS_Compra = numericPreco_ICMSCompra.Value;
            mercadoria.Preco_ICMS_Fronteira = numericPreco_ICMSFronteira.Value;
            mercadoria.Preco_IPI = numericPreco_IPI.Value;
            mercadoria.Preco_Frete = numericPreco_Frete.Value;
            mercadoria.Preco_Embalagem = numericPreco_Embalagem.Value;
            mercadoria.Preco_EncFinanceiro = numericPreco_EncFinanceiros.Value;
            mercadoria.Preco_CustoFixo = numericPreco_CustoFixo.Value;
            mercadoria.Preco_ImpostoFederais = numericPreco_ImpostosFederais.Value;
            mercadoria.Preco_ICMS_Venda = numericPreco_ICMSVenda.Value;
            mercadoria.Preco_Comissao = numericPreco_Comissao.Value;
            mercadoria.Preco_Marketing = numericPreco_Marketing.Value;
            mercadoria.Preco_OutrosCustos = numericPreco_OutrosCustos.Value;
            //Preço Estoque - Ponto Equilíbrio
            mercadoria.Preco_MargemSugerido = numericMargem_MargemSugerido.Value;
            mercadoria.Preco_PrecoVenda = numericMargem_PrecoVenda.Value;
            mercadoria.Preco_PrecoA = numericMargem_PrecoA.Value;
            mercadoria.Preco_PrecoB = numericMargem_PrecoB.Value;
            mercadoria.Preco_PrecoC = numericMargem_PrecoC.Value;
            //Preço Estoque - Estoque
            mercadoria.Estoque_QuantidadeMinimo = (double)numericEstoque_EstoqueMinimo.Value;
            mercadoria.Estoque_UnidadeMedidaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEstoque_Unidade);
            mercadoria.Estoque_Pratileira = Funcao.StringVazioParaNulo(textEstoque_Pratileira.Text);
            mercadoria.Estoque_PesoBruto = (double)numericEstoque_PesoBruto.Value;
            mercadoria.Estoque_PesoLiquido = (double)numericEstoque_PesoLiquido.Value;
            mercadoria.Estoque_UltimaEntrada = dateEstoque_UltimaEntrada.Value;
            mercadoria.Estoque_AlteracaoPreco = dateEstoque_AlteracaoPreco.Value;
            //Tributação ECF/NFCe
            mercadoria.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTributacao_ECFNFCeSituacao);
            mercadoria.Estoque_TributacaoNFCe_AliquotaICMS = numericTributacao_ECFNFCeNFCeAliquotaICMS.Value;
            mercadoria.Estoque_TributacaoNFCe_TipoServicoFiscalId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTributacao_ECFNFCeTipoServico);
            mercadoria.Estoque_TributacaoNFCe_TipoServicoMunicipal = Funcao.StringVazioParaNulo(textTributacao_ECFNFCeTipoServicoMunicipal.Text);
            //Preço Estoque - Outros
            mercadoria.NaoVender = checkNaoVender.Checked;
            mercadoria.NaoControlarEstoque = checkNaoControlarEstoque.Checked;
            mercadoria.Ativado = (!checkDesativado.Checked);
            //Detalhes Fiscais
            mercadoria.Fiscal_VinculoFiscalId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_VinculoFiscal);
            mercadoria.Fiscal_InformacaoAdicional = Funcao.StringVazioParaNulo(textDetalhesFiscais_InformacaoAdicional.Text);
            mercadoria.Fiscal_TipoMercadoriaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_Especifico);
            mercadoria.Fiscal_TabelaANPId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CodigoANP_Codigo);
            mercadoria.Fiscal_CodigoAnvisa = Funcao.StringVazioParaNulo(textDetalhesFiscais_CodigoAnvisa.Text);
            mercadoria.Fiscal_TabelaNCMId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_NCM);
            mercadoria.Fiscal_TabelaCESTId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CEST);
            mercadoria.Fiscal_TabelaOrigemMercadoriaServicoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_OrigemMercadoria);
            mercadoria.Fiscal_TabelaCST_CSOSNId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_CST_CSOSN_Codigo);
            mercadoria.Fiscal_TabelaBeneficioSPEDId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_BeneficioSped);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI
            mercadoria.Fiscal_NFE_TabelaCST_IPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Codigo);
            mercadoria.Fiscal_NFE_IPI_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_IPI_Aliquota.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
            mercadoria.Fiscal_NFE_TabelaCST_PISId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Codigo);
            mercadoria.Fiscal_NFE_PIS_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_PIS_Aliquota.Value;
            mercadoria.Fiscal_NFE_TabelaCST_COFINSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Codigo);
            mercadoria.Fiscal_NFE_COFINS_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisEntrada_COFINS_Aliquota.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
            mercadoria.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_MobilidadeBase);
            mercadoria.Fiscal_NFS_ICMS_ValorAdicional = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Adicional.Value;
            mercadoria.Fiscal_NFS_ICMS_Deferimento = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Deferimento.Value;
            mercadoria.Fiscal_NFS_ICMS_ReducaoBase = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_ReducaoBase.Value;
            mercadoria.Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMS_Desoneracao);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
            mercadoria.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ModalidadeBase);
            mercadoria.Fiscal_NFS_ICMSST_ValorAdicional = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ValorAdicional.Value;
            mercadoria.Fiscal_NFS_ICMSST_Aliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_Aliquota.Value;
            mercadoria.Fiscal_NFS_ICMSST_ReducaoBase = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ICMSST_ReducaoBase.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
            mercadoria.Fiscal_NFS_IPI_TabelaCST_IPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Codigo);
            mercadoria.Fiscal_NFS_IPI_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_Aliquota.Value;
            mercadoria.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_ClasseEnquadramento);
            mercadoria.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_IPI_CodigoEnquadramento);
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PIS_Codigo);
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_PIS_Aliquota.Value;
            mercadoria.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_COFINS_Codigo);
            mercadoria.Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_COFINS_Aliquota.Value;
            mercadoria.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_GrupoNaturezaReceita);
            mercadoria.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_InfoRefNotasFiscaisSaida_PISCOFINS_NaturezaReceita);

            //Detalhes Fiscais - SEP
            mercadoria.Fiscal_SPED_TabelaSpedTipoItemId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_TipoItem);
            mercadoria.Fiscal_SPED_TabelaSpedCodigoGeneroId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_CodigoGenero);
            mercadoria.Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDetalhesFiscais_SPED_CodigoInformacaoAdicional);
            //Detalhes Fiscais - Outros.
            mercadoria.Fiscal_OutrosPMC = numericDetalhesFiscais_OutrosPMC.Value;
            mercadoria.Fiscal_OutrosNVE = numericDetalhesFiscais_OutrosNVE.Value;
            //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
            mercadoria.Fiscal_NFS_TributosFederais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosFederais.Value;
            mercadoria.Fiscal_NFS_TributosMunicipais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosMunicipais.Value;
            mercadoria.Fiscal_NFS_TributosEstaduais = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosEstaduais.Value;
            mercadoria.Fiscal_NFS_TributosTotal = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_TributosTotal.Value;
            mercadoria.Fiscal_NFS_ValorTributosTotal = numericDetalhesFiscais_InfoRefNotasFiscaisSaida_ValorTributosTotal.Value;
            //Detalhe de Estoque
            // >>> gridEstoqueEmpresa;
            // >>> gridEstoqueEmTransito
            //Foto e Especificação
            mercadoria.FotoEspecificacao_Especificacao = Funcao.StringVazioParaNulo(textEspecificacao.Text);
            mercadoria.FotoEspecificacao_URL = Funcao.StringVazioParaNulo(textURL.Text);
            mercadoria.FotoEspecificacao_UsarFoto = checkUsarFoto.Checked;
            mercadoria.FotoEspecificacao_Imagem = Imagem.ImageToByteArray(picFoto.Image);
            //Produção
            mercadoria.Producao_Configuracao_ValidadeDias = (int)txtProducao_Configuracao_ValidadeDias.Value;
            mercadoria.Producao_Configuracao_NaoBaixarComposicaoVenda = chkProducao_Configuracao_NaoBaixarComposicaoVenda.Checked;
            // >>> gridProducao_Composicao
            //Integração
            // >>> gridIntegracaoEmpresaFornecedor
            //Similares
            // >>> gridListaMercadoriasSimilares

            await AdicionarMercadoria();

            return true;
        }
        private async Task AdicionarMercadoria()
        {
            using (var mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
            {
                if (mercadoria.Id != Guid.Empty)
                {
                    await mercadoriaController.Atualizar(mercadoria.Id, mercadoria);
                }
                else
                {
                    mercadoria.Id = Guid.NewGuid();
                    mercadoria = (await mercadoriaController.Adicionar(mercadoria));
                }
            }

            //MercadoriaImpostoEstadoViewModel mercadoriaImpostoEstado;

            //using (MercadoriaImpostoEstadoController mercadoriaImpostoEstadoController = new MercadoriaImpostoEstadoController(this.MeuDbContext(), this._notifier))
            //{
            //    foreach (DataGridViewRow row in gridImpostosICMS.Rows)
            //    {
            //        foreach (DataGridViewCell celula in row.Cells)
            //        {
            //            if (celula.ColumnIndex > 1)
            //            {
            //                mercadoriaImpostoEstado = new MercadoriaImpostoEstadoViewModel();

            //                mercadoriaImpostoEstado.MercadoriaId = mercadoria.Id;
            //                mercadoriaImpostoEstado.EstadoOrigemId = Guid.Parse(row.Tag.ToString());
            //                mercadoriaImpostoEstado.EstadoDestinoId = Guid.Parse(gridImpostosICMS.Columns[celula.ColumnIndex].Tag.ToString());

            //                if (celula.Value != null)
            //                    mercadoriaImpostoEstado.PercentualICMS = Convert.ToDecimal(celula.Value);

            //                try
            //                {
            //                    if (celula.Tag == null)
            //                    {
            //                        mercadoriaImpostoEstado.Id = Guid.NewGuid();
            //                        await mercadoriaImpostoEstadoController.Adicionar(mercadoriaImpostoEstado);
            //                        celula.Tag = mercadoriaImpostoEstado.Id;
            //                    }
            //                    else
            //                    { await mercadoriaImpostoEstadoController.Atualizar(mercadoriaImpostoEstado.Id, mercadoriaImpostoEstado); }
            //                }
            //                catch (Exception)
            //                {
            //                }
            //            }
            //        }
            //    }
            //}
        }
        private async void Excluir()
        {
            var mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier);
            if (await mercadoriaController.Excluir(mercadoria.Id))
            { Limpar(); }
            this.MeuDbContextDispose();
        }
        bool TentarGravar()
        {
            bool tentarGravar = false;

            if (!pnlDadosGerais.Enabled) { goto Sair; }
            if (mercadoria == null) { goto Sair; }

            if ((mercadoria.Id == Guid.Empty) && (textNomeMercadoria.Text.Trim() == ""))
            {
                tentarGravar = true;
            }
            else
            {
                if (textNomeMercadoria.Text == "")
                {
                    CaixaMensagem.Informacao("Informe o nome da mercadoria");
                    goto Sair;
                }

                Assincrono.TaskAsyncAndAwaitAsync(GravarMercadoria());

                tentarGravar = true;
            }

        Sair:
            return tentarGravar;
        }
        private async Task Navegar(Declaracoes.eNavegar posicao)
        {
            if (TentarGravar())
            {
                await Navegar_PegarTodos(mercadoria.Id, posicao);
                await CarregarDados();
            }
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<MercadoriaViewModel> Data = null;

                Data = await mercadoriaController.ObterTodos();

                MercadoriaViewModel ItemAnterior = null;
                MercadoriaViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (MercadoriaViewModel Item in Data)
                {
                    if (Posicao == Declaracoes.eNavegar.Primeiro)
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
                            case Declaracoes.eNavegar.Anterior:
                                ItemRetorno = ItemAnterior;
                                break;
                            case Declaracoes.eNavegar.Atual:
                                ItemRetorno = Item;
                                break;
                            case Declaracoes.eNavegar.Proximo:
                                Proximo = true;
                                break;
                        }
                    }

                    ItemAnterior = Item;
                }

                if (Posicao == Declaracoes.eNavegar.Ultimo)
                {
                    ItemRetorno = ItemAnterior;
                }

                if (ItemRetorno != null) { mercadoria = ItemRetorno; }
            }
        }
        private async Task NCMCarregarDependentes()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboDetalhesFiscais_CEST_Carregar((Guid)comboDetalhesFiscais_NCM.SelectedValue));
        }
        private void labelPreco_ValorCustoFixo_Calcular()
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private decimal CalcularTVA()
        {
            //= SeImed([o] = 0; 0; SeImed(logo2.Formulário!TipoPrecificacao = "TVA"; ((([p1] +[vIPI]) * (1 + ([o] / 100))) * 0, 17) - ([p1] * ([ICMS] / 100)); ([p1] * (([o]) / 100))))
            return 0;
        }
        private decimal numericPreco_PrecoCompra_Valor()
        {
            return Funcao.NuloParaValorD(numericPreco_PrecoCompra.Value);
        }
        private decimal labelMargem_ValorPrecoSugerido_Calcular()
        {
            return Funcao.NuloParaValorD(labelMargem_ValorPrecoSugerido.Tag);
        }
        private void numericPreco_numericPreco_PrecoCompra_Calcular()
        {
            decimal PrecoVendaSugerido = 0;
            decimal precoPontoEquilibrio = 0;
            decimal valorCustoFixo = 0;
            decimal valorImpostoFederal = 0;
            decimal valorIcmsVenda = 0;
            decimal ValorComissao = 0;
            decimal valorMarketing = 0;
            decimal valorOutrosCustos = 0;
            decimal valorTva = 0;
            decimal ValorIPI = 0;
            decimal precoCusto = 0;

            if (Declaracoes.tipoCalculo == Declaracoes.eTipoCalculo.TVA)
            {
                ValorIPI = (numericPreco_PrecoCompra.Value * ((numericPreco_IPI.Value) / 100));
                valorTva = numericPreco_ICMSFronteira.Value == 0 ? 0 : (((numericPreco_PrecoCompra.Value + ValorIPI) * (1 + (numericPreco_ICMSFronteira.Value / 100))) * numericTributacao_ECFNFCeNFCeAliquotaICMS.Value) - (numericPreco_PrecoCompra.Value * (numericPreco_ICMSCompra.Value / 100));
                precoCusto = numericPreco_PrecoCompra.Value + (numericPreco_PrecoCompra.Value * (numericPreco_IPI.Value + numericPreco_Frete.Value + numericPreco_Embalagem.Value + numericPreco_EncFinanceiros.Value) / 100) + valorTva;
            }
            else
            {
                valorTva = (numericPreco_PrecoCompra.Value * (numericPreco_ICMSFronteira.Value / 100));
                precoCusto = numericPreco_PrecoCompra.Value + (numericPreco_PrecoCompra.Value * (((-numericPreco_ICMSCompra.Value + numericPreco_IPI.Value + numericPreco_Frete.Value + numericPreco_Embalagem.Value + numericPreco_EncFinanceiros.Value) / 100)) + valorTva);
            }

            labelPreco_ValorICMSCompra.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_ICMSCompra.Value)) * -1);
            labelPreco_ValorICMSFronteira.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_ICMSFronteira.Value)));
            labelPreco_ValorIPI.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_IPI.Value)));
            labelPreco_ValorFrete.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_Frete.Value)));
            labelPreco_ValorEmbalagem.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_Embalagem.Value)));
            labelPreco_ValorEncFinanceiros.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(numericPreco_PrecoCompra.Value, numericPreco_EncFinanceiros.Value)));

            labelPreco_ValorCustoMercadoria.Tag = precoCusto;
            labelPreco_ValorCustoMercadoria.Text = Valor.Formatar(Funcao.NuloParaValor(precoCusto));

            if (Declaracoes.calculoPreco == Declaracoes.eCalculoPreco.Compra)
            {
                valorCustoFixo = precoCusto * (numericPreco_CustoFixo.Value / 100);
                valorImpostoFederal = precoCusto * (numericPreco_ImpostosFederais.Value / 100);
                valorIcmsVenda = precoCusto * (numericPreco_ICMSVenda.Value / 100);
                ValorComissao = precoCusto * (numericPreco_Comissao.Value / 100);
                valorMarketing = precoCusto * (numericPreco_Marketing.Value / 100);
                valorOutrosCustos = precoCusto * (numericPreco_OutrosCustos.Value / 100);

                precoPontoEquilibrio = (precoCusto + valorCustoFixo + valorImpostoFederal + valorIcmsVenda + ValorComissao + valorMarketing + valorOutrosCustos);
                labelMargem_PontoEquilibrio.Tag = precoPontoEquilibrio;
                labelMargem_PontoEquilibrio.Text = precoPontoEquilibrio.ToString("0.00");

                PrecoVendaSugerido = precoPontoEquilibrio * (1 + (numericMargem_MargemSugerido.Value) / 100);
                labelMargem_ValorPrecoSugerido.Tag = PrecoVendaSugerido;
                labelMargem_ValorPrecoSugerido.Text = PrecoVendaSugerido.ToString("0.00");

                labelMargem_ValorlMargemSugerido.Text = (PrecoVendaSugerido - precoPontoEquilibrio).ToString("0.00");
            }

            labelPreco_ValorCustoFixo.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_CustoFixo.Value)));
            labelPreco_ValorImpostosFederais.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_ImpostosFederais.Value)));
            labelPreco_ValorICMSVenda.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_ICMSVenda.Value)));
            labelPreco_ValorComissao.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_Comissao.Value)));
            labelPreco_ValorMarketing.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_Marketing.Value)));
            labelPreco_ValorOutrosCustos.Text = Valor.Formatar(Funcao.NuloParaValor(Valor.Percentagem(precoCusto, numericPreco_OutrosCustos.Value)));

            numericMargem_PrecoVenda_Carregar();
            numericMargem_PrecoA_Carregar();
            numericMargem_PrecoB_Carregar();
            numericMargem_PrecoC_Carregar();
        }
        private void numericMargem_PrecoVenda_Carregar()
        {
            labelMargem_ValorPrecoVenda.Text = Valor.Formatar(numericMargem_PrecoVenda.Value - Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag));
            if ((numericMargem_PrecoVenda.Value == 0) || (Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) == 0))
            { labelMargem_MargemVenda.Text = "0.00"; }
            else
            { labelMargem_MargemVenda.Text = ((numericMargem_PrecoVenda.Value / Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) - 1) * 100).ToString("0.00"); }
        }
        private void numericMargem_PrecoA_Carregar()
        {
            labelMargem_ValorPrecoA.Text = Valor.Formatar(numericMargem_PrecoA.Value - Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag));
            if ((numericMargem_PrecoA.Value == 0) || (Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) == 0))
            { labelMargem_MargemPrecoA.Text = "0.00"; }
            else
            { labelMargem_MargemPrecoA.Text = ((numericMargem_PrecoA.Value / Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) - 1) * 100).ToString("0.00"); }
        }
        private void numericMargem_PrecoB_Carregar()
        {
            labelMargem_ValorPrecoB.Text = Valor.Formatar(numericMargem_PrecoB.Value - Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag));
            if ((numericMargem_PrecoB.Value == 0) || (Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) == 0))
            { labelMargem_MargemPrecoB.Text = "0.00"; }
            else
            { labelMargem_MargemPrecoB.Text = ((numericMargem_PrecoB.Value / Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) - 1) * 100).ToString("0.00"); }
        }
        private void numericMargem_PrecoC_Carregar()
        {
            labelMargem_ValorPrecoC.Text = Valor.Formatar(numericMargem_PrecoC.Value - Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag));
            if ((numericMargem_PrecoC.Value == 0) || (Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) == 0))
            { labelMargem_MargemPrecoC.Text = "0.00"; }
            else
            { labelMargem_MargemPrecoC.Text = ((numericMargem_PrecoC.Value / Funcao.NuloParaValorD(labelMargem_PontoEquilibrio.Tag) - 1) * 100).ToString("0.00"); }
        }
        #endregion
        private void numericPreco_ICMSCompra_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_ICMSFronteira_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_IPI_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_Frete_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_Embalagem_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_EncFinanceiros_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_CustoFixo_ValueChanged(object sender, EventArgs e)
        {
            labelPreco_ValorCustoFixo_Calcular();
        }
        private void numericPreco_ImpostosFederais_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_ICMSVenda_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_Comissao_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_Marketing_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_OutrosCustos_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericPreco_PrecoCompra_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericMargem_MargemSugerido_ValueChanged(object sender, EventArgs e)
        {
            numericPreco_numericPreco_PrecoCompra_Calcular();
        }
        private void numericMargem_PrecoVenda_ValueChanged(object sender, EventArgs e)
        {
            numericMargem_PrecoVenda_Carregar();
        }
        private void numericMargem_PrecoA_ValueChanged(object sender, EventArgs e)
        {
            numericMargem_PrecoA_Carregar();
        }
        private void numericMargem_PrecoB_ValueChanged(object sender, EventArgs e)
        {
            numericMargem_PrecoB_Carregar();
        }
        private void numericMargem_PrecoC_ValueChanged(object sender, EventArgs e)
        {
            numericMargem_PrecoC_Carregar();
        }
        private void frmCadastroMercadorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TentarGravar())
            {
                e.Cancel = (!CaixaMensagem.Perguntar("Cadastro em edição! Deseja sair assim mesmo?"));
            }

            this.MeuDbContextDispose();
        }

        private void botaoGeradorEtiquetas_Click(object sender, EventArgs e)
        {
            TentarGravar();
        }
    }
}