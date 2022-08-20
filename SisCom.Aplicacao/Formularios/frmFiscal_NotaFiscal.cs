using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NotaFiscal : FormMain
    {          
        public Guid VendaId;

        enum RegimeTributario
        {
            [Description("SIMPLES NACIONAL")]
            SIMPLES_NACIONAL = 1,
            [Description("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA")]
            SIMPLES_NACIONAL_EXCESSO_SUBLIMITE_RECEITA_BRUTA = 2,
            [Description("NORMAL")]
            NORMAL = 3
        }

        enum TransportadoraFreteConta
        {
            [Description("0-Contratação do Frete por conta do Remetente(CIF)")]
            ContratacaoFreteContaRemetente_CIF = 0,
            [Description("1-Contratação do Frete por conta do Destinatário(FOB)")]
            ContratacaoFreteContaDestinatario_FOB = 1,
            [Description("2-Contratação do Frete por conta de Terceiros")]
            ContratacaoFreteContaTerceiros = 2,
            [Description("3-Transporte Próprio por conta do Remetente")]
            TransporteProprioContaRemetente = 3,
            [Description("4-Transporte Próprio por conta do Destinatário")]
            TransporteProprioContaDestinatario = 4,
            [Description("9-Sem Ocorrência de Transporte")]
            SemOcorrenciaTransporte = 9
        }

        public frmFiscal_NotaFiscal(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
        }

        async Task Inicializa()
        {
            //Pesquisar
            Combo_ComboBox.Formatar(comboRegimeTributario, "", "", ComboBoxStyle.DropDownList, null, typeof(RegimeTributario));
            Combo_ComboBox.Formatar(comboTransportadoraFreteConta, "", "", ComboBoxStyle.DropDownList, null, typeof(TransportadoraFreteConta));
            Combo_ComboBox.Formatar(comboInfoNFeIndicaPresenca, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_IndicaPresenca));
            Combo_ComboBox.Formatar(comboInfoNFeOperacao, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Operacao));
            Combo_ComboBox.Formatar(comboInfoNFeTipoEmissao, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_TipoEmissao));

            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
        }

        private async Task<bool> Inicializar()
        {
            try
            {
                Limpar();

                List<NomeComboViewModel> unidadeMedida;

                DataTable produto = new DataTable();
                produto.Columns.Add("ID", typeof(Guid));
                produto.Columns.Add("Descricao", typeof(string));
                produto.Columns.Add("Codigo", typeof(string));
                produto.Columns.Add("CodigoFabricante", typeof(string));

                using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<MercadoriaViewModel> ret = await mercadoriaController.ObterTodos();

                    foreach (var item in ret)
                    {
                        produto.Rows.Add(item.Id, item.Nome, item.Codigo, item.CodigoFabricante);
                    }
                }
                using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
                {
                    unidadeMedida = (List<NomeComboViewModel>)await unidadeMedidaController.Combo();
                }

                ////Detalhe de Estoque
                //Grid_DataGridView.DataGridView_Formatar(gridProdutos, true);
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "ID");
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "ID");
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "", "Descrição", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "ID");
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, unidadeMedida, "Nome", "ID");
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero);
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Preço", "Preço", Grid_DataGridView.TipoColuna.Valor);
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Total", "Total", Grid_DataGridView.TipoColuna.Valor, readOnly: true);
                //Grid_DataGridView.DataGridView_ColunaAdicionar(gridProdutos, "Excluir", "Excluir", Grid_DataGridView.TipoColuna.Button);

                ////Cabeçalho
                //await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());

                //if (comboOrigemVenda.Items.Count == 1) { comboOrigemVenda.SelectedIndex = -1; }

                //venda = new ViewModels.VendaViewModel();
                //venda.Id = Guid.Empty;
                //Navegar(Declaracoes.eNavegar.Primeiro);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

            return true;
        }
        private void Limpar()
        {
            datePeriodoInicial.Value = DateTime.Now.Date;
            textHora.Text = DateTime.Now.ToString("HH:mm");
            //comboClienteCodigo.SelectedIndex = -1;
            //comboClienteNome.SelectedIndex = -1;
            //comboFornecedor.SelectedIndex = -1;
            //comboEmpresa.SelectedIndex = -1;
            //numericValorFrete.Value = 0;
            //textObservacao.Text = "";

            //comboTransportadora.SelectedIndex = -1;
            //comboMotorista.SelectedIndex = -1;
            //comboPlaca1.SelectedIndex = -1;
            //comboPlaca2.SelectedIndex = -1;
            //comboPlaca3.SelectedIndex = -1;

            //comboOutrosDados_EnderecoEntrega.SelectedIndex = -1;
            //comboOutrosDados_Motorista.SelectedIndex = -1;
            //comboOutrosDados_Indicador.SelectedIndex = -1;
            //numericOutrosDados_KM.Value = 0;
            //numericOutrosDados_KMDias.Value = 0;

            //textNFCe_Numero.Text = "";
            //textNFCe_Protocolo.Text = "";
            //textNFCe_Serie.Text = "";
            //textNFCe_ChaveNFCe.Text = "";
            //dateNFCe_Emissao.Value = DateTime.Now.Date;
            //comboNFCe_TipoEmissao.SelectedIndex = -1;

            numericPercentualDesconto.Value = 0;
            numericValorDesconto.Value = 0;
        }
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboEmpresa_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboOrigemVenda_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboRemetente_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboCliente_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFinalidade_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboNaturezaOperacao_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboEstado_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboTransportadora_Carregar());

            comboInfoNFeFidelidade.DataSource = comboFinalidade.DataSource;
            comboInfoNFeFidelidade.ValueMember = comboFinalidade.ValueMember;
            comboInfoNFeFidelidade.DisplayMember = comboFinalidade.DisplayMember;
            comboInfoNFeFidelidade.DropDownStyle = comboFinalidade.DropDownStyle;

            return true;
        }
        #region Combos
        //private System.Windows.Forms.ComboBox comboInfoNFeIndicaPresenca;
        //private System.Windows.Forms.ComboBox comboInfoNFeNFeModelo;
        //private System.Windows.Forms.ComboBox comboInfoNFeOperacao;
        //private System.Windows.Forms.ComboBox comboInfoNFeOrigem;
        //private System.Windows.Forms.ComboBox comboInfoNFeTipoEmissao;
        //private System.Windows.Forms.ComboBox comboInformacoesComplementaresUF;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaBairro;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaChaveNFe;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaCidade;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaPais;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaUF;
        //private System.Windows.Forms.ComboBox comboObservacaoTipoPagamento
        //private System.Windows.Forms.ComboBox comboTransportadora;
        //private System.Windows.Forms.ComboBox comboTransportadoraFreteConta;

        private async Task<bool> comboEmpresa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboEmpresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));
            }

            return true;
        }
        private async Task<bool> comboOrigemVenda_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboOrigem,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaOrigemVendaController(this.MeuDbContext(), this._notifier)).Combo());
            }

            return true;
        }
        private async Task<bool> comboRemetente_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboRemetente,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboNome());
            }

            return true;
        }
        private async Task<bool> comboCliente_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboCliente,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboNome());
            }

            return true;
        }
        private async Task<bool> comboFinalidade_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFinalidade,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new NotaFiscalFinalidadeController(this.MeuDbContext(), this._notifier)).Combo());
            }

            return true;
        }
        private async Task<bool> comboNaturezaOperacao_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboNaturezaOperacao,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new NaturezaOperacaoController(this.MeuDbContext(), this._notifier)).Combo());
            }

            return true;
        }
        private async Task<bool> comboEstado_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboRemetenteUF,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboCidade_Carregar(Guid EstadoId)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboRemetenteCidade,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboTransportadora_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboTransportadora,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new TransportadoraController(this.MeuDbContext(), this._notifier)).Combo());
            }

            return true;
        }
        #endregion
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_Transmitir>();
            form.ShowDialog(this);
        }
        private void comboRemetenteUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboRemetenteUF.SelectedIndex != -1) && (comboRemetenteUF.Tag != Declaracoes.ComboBox_Carregando))
            {
                if (Combo_ComboBox.Selecionado(comboRemetenteUF))
                {
                    comboRemetenteUF_Tratar();
                }
            }
        }
        private async void comboRemetenteUF_Tratar()
        {
            await comboCidade_Carregar(Guid.Parse(comboRemetenteUF.SelectedValue.ToString()));
            await comboPais_Carregar();
        }
        private async Task comboPais_Carregar()
        {
            if (comboRemetenteUF.SelectedIndex != -1)
            {
                Guid PaisId = (await (new EstadoController(this.MeuDbContext(), this._notifier)).GetById((Guid)comboRemetenteUF.SelectedValue)).PaisId;

                Combo_ComboBox.Formatar(comboRemetentePais,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PaisController(this.MeuDbContext(), this._notifier)).ComboId(PaisId));

                comboRemetentePais.SelectedValue = PaisId;
            }
        }
    }
}