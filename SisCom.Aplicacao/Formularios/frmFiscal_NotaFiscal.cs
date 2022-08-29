using Funcoes._Classes;
using Funcoes._Enum;
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
        ViewModels.NotaFiscalSaidaViewModel notafiscalsaida = null;
        public Guid VendaId;

        const int gridMercadoria_CodigoSistema = 0;
        const int gridMercadoria_RefSistema = 1;
        const int gridMercadoria_Mercadoria = 2;
        const int gridMercadoria_Descricao = 3;
        const int gridMercadoria_NCM = 4;
        const int gridMercadoria_CST_CSOSN = 5;
        const int gridMercadoria_CFOP = 6;
        const int gridMercadoria_Medida = 7;
        const int gridMercadoria_Quantidade = 8;
        const int gridMercadoria_Preco = 9;
        const int gridMercadoria_Total = 10;
        const int gridMercadoria_ICMS = 11;
        const int gridMercadoria_IPI = 12;
        const int gridMercadoria_Frete = 13;
        const int gridMercadoria_BTN_Impostos = 14;
        const int gridMercadoria_BTN_Excluir = 15;
        const int gridMercadoria_Impostos = 16;

        const int gridCobrancaNota_TipoPagamento = 0;
        const int gridCobrancaNota_Vencimento = 1;
        const int gridCobrancaNota_Valor = 2;

        const int gridObservacao_ID = 0;
        const int gridObservacao_Codigo = 1;
        const int gridObservacao_Descricao = 2;

        const int gridInfoNFe_ID = 0;
        const int gridInfoNFe_NFe_NFCe  = 1;
        const int gridInfoNFe_ChaveNFe_NFCe = 2;

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
        enum NFModelo
        {
            [Description("SIMPLES NACIONAL")]
            SIMPLES_NACIONAL = 1,
            [Description("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA")]
            SIMPLES_NACIONAL_EXCESSO_SUBLIMITE_RECEITA_BRUTA = 2,
            [Description("NORMAL")]
            NORMAL = 3
        }
        enum TipoPagamento
        {
            [Description("A VISTA")]
            A_VISTA = 1,
            [Description("A PRAZO")]
            A_PRAZO = 2,
            [Description("OUTROS")]
            OUTROS = 3
        }
        enum TipoNotaReferenciada
        {
            [Description("Cliente")]
            Cliente = 1,
            [Description("Fornecedor")]
            Fornecedor = 2,
            [Description("NFC-e")]
            NFCe = 3
        }

        Guid dadolocal_Cliente_EstadoId;

        IEnumerable<MercadoriaImpostoEstadoViewModel> mercadoriaImpostoEstado;

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
            Combo_ComboBox.Formatar(comboInfoNFeNFeModelo, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Modelo));
            Combo_ComboBox.Formatar(comboCobrancaNotaTipoPagamento, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoPagamento));
            Combo_ComboBox.Formatar(comboInfoNFeOrigem, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoNotaReferenciada));

            comboInfoNFeOrigem.SelectedIndex = -1;

            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
            await Assincrono.TaskAsyncAndAwaitAsync(CarregarVenda());
        }
        private async Task<bool> Inicializar()
        {
            try
            {
                Texto_MaskedTextBox.FormatarTipoPessoa(TipoPessoaCliente.Juridica, maskedRemetenteCPFCNPJ);
                Texto_MaskedTextBox.FormatarTipoPessoa(TipoPessoaCliente.Juridica, maskedTransportadoraCPFCNPJ);

                Limpar();

                List<NomeComboViewModel> unidadeMedida;
                List<CodigoComboViewModel> tabelaCFOP;
                List<CodigoDescricaoComboViewModel> tabelaNCM;
                List<CodigoDescricaoComboViewModel> tabelaCST_CSOSN;

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
                    unidadeMedida = (List<NomeComboViewModel>)await unidadeMedidaController.Combo(o => o.Nome);
                }
                using (TabelaCFOPController tabelaCFOPController = new TabelaCFOPController(this.MeuDbContext(), this._notifier))
                {
                    tabelaCFOP = (List<CodigoComboViewModel>)await tabelaCFOPController.Combo(o => o.Codigo);
                }
                using (TabelaNCMController tabelaNCMController = new TabelaNCMController(this.MeuDbContext(), this._notifier))
                {
                    tabelaNCM = (List<CodigoDescricaoComboViewModel>)await tabelaNCMController.Combo(o => o.Codigo);
                }
                using (TabelaCST_CSOSNController tabelaCST_CSOSNController = new TabelaCST_CSOSNController(this.MeuDbContext(), this._notifier))
                {
                    tabelaCST_CSOSN = (List<CodigoDescricaoComboViewModel>)await tabelaCST_CSOSNController.Combo(o => o.Codigo);
                }

                //Detalhe de Mercadoria
                Grid_DataGridView.DataGridView_Formatar(gridMercadoria, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "Id");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "Id");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Mercadoria", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "Id");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Descrição");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "NCM", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaNCM, "Codigo", "ID");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "CST/CSOSN", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCST_CSOSN, "Codigo", "ID");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "CFOP", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCFOP, "Codigo", "ID");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, unidadeMedida, "Nome", "ID");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Preço", "Preço", Grid_DataGridView.TipoColuna.Valor, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Total", "Total", Grid_DataGridView.TipoColuna.Valor, 80, readOnly: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "ICMS", "ICMS", Grid_DataGridView.TipoColuna.Percentual, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "IPI", "IPI", Grid_DataGridView.TipoColuna.Percentual, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Frete", "Frete", Grid_DataGridView.TipoColuna.Percentual, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Grid_DataGridView.TipoColuna.Button, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Excluir", "Excluir", Grid_DataGridView.TipoColuna.Button, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Tamanho: 0);

                //Cobrança da Nota
                List<NomeComboViewModel> formaPagamento;

                using (FormaPagamentoController formaPagamentoController = new FormaPagamentoController(this.MeuDbContext(), this._notifier))
                {
                    formaPagamento = (List<NomeComboViewModel>)await formaPagamentoController.Combo(o => o.Nome);
                }

                Grid_DataGridView.DataGridView_Formatar(gridCobrancaNota, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Pagamento", "MedidaPagamento", Grid_DataGridView.TipoColuna.ComboBox, 200, 0, formaPagamento, "Nome", "ID", false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Vencimento", "Vencimento", Grid_DataGridView.TipoColuna.Data, 100, 0, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Valor", "Valor", Grid_DataGridView.TipoColuna.Valor, 100, 0, readOnly: false);

                //Obsrevação
                List<CodigoDescricaoComboViewModel> observacao;

                using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
                {
                    observacao = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Descricao);
                }

                Grid_DataGridView.DataGridView_Formatar(gridObservacao, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "Código", "Código", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, dataSource: observacao, 
                                                                                                                                                  dataSource_Descricao: "Descricao",
                                                                                                                                                  dataSource_Valor: "ID",
                                                                                                                                                  dropDownWidth: 400,
                                                                                                                                                  readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "Descrição", "Descrição", Grid_DataGridView.TipoColuna.Texto, 400, 0, readOnly: false);

                //NF-e
                Grid_DataGridView.DataGridView_Formatar(gridInfoNFe, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "NF-e/NFC-e Nº", "NF-e/NFC-e Nº", Tamanho: 100, Tipo: Grid_DataGridView.TipoColuna.ComboBox, 
                                                                                                                            dataSource_Descricao: "NotaFiscal",
                                                                                                                            dataSource_Valor: "ID", 
                                                                                                                            readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "Chave NF-e/NFC-e", "Chave NF-e/NFC-e", Tamanho: 500, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
                                                                                                                                  dataSource_Descricao: "CodigoChaveAcesso",
                                                                                                                                  dataSource_Valor: "ID", 
                                                                                                                                  readOnly: false);

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

            comboNaturezaOperacao.SelectedIndex = -1;

            comboRegimeTributario.SelectedValue = RegimeTributario.NORMAL;
            comboInfoNFeIndicaPresenca.SelectedValue = NF_IndicaPresenca.OperacaoPresencial;
            comboInfoNFeOperacao.SelectedValue = NF_Operacao.Normal;
            comboInfoNFeTipoEmissao.SelectedValue = NF_TipoEmissao.Normal;
            comboInfoNFeNFeModelo.SelectedValue = NF_Modelo.NotaFiscalEletronica;
            textModelo.Text = comboInfoNFeNFeModelo.Text;

            checkStatusCancelado.Checked = false;
            checkStatusFinalizada.Checked = false;
            checkStatusDenegada.Checked = false;
            checkStatusInutilizada.Checked = false;

            comboRemetente.SelectedIndex = -1;
            Texto_MaskedTextBox.Limpar(maskedRemetenteCPFCNPJ);
            textRemetenteIE.Text = "";
            textRemetenteEndereco.Text = "";
            textRemetenteNumero.Text = "";
            comboRemetenteUF.SelectedIndex = -1;
            comboRemetenteCidade.SelectedIndex = -1;
            textRemetenteBairro.Text = "";
            textRemetenteCEP.Text = "";
            comboRemetentePais.SelectedIndex = -1;
            textRemetenteFones.Text = "";
            textRemetenteEMail.Text = "";
            numericValorFrete.Value = 0;
            numericValorSeguro.Value = 0;
            numericValorOutrasDespesas.Value = 0;
            numericPercentualDesconto.Value = 0;
            numericValorDesconto.Value = 0;
            numericAliquotaSimplesNacional.Value = 0;
            comboTransportadora.SelectedIndex = -1;
            comboTransportadoraFreteConta.SelectedIndex = -1;
            Texto_MaskedTextBox.Limpar(maskedTransportadoraCPFCNPJ);
            textTransportadoraPlaca.Text = "";
            comboTransportadoraUF.SelectedIndex = -1;
            textTransportadoraRNTC.Text = "";
            numericTransportadoraNumeroCarga.Value = 0;
            comboRegimeTributario.SelectedIndex = -1;
            numericVolumeTransportadosQuantidade.Value = 0;
            textVolumeTransportadosEspecie.Text = "";
            textVolumeTransportadosMarca.Text = "";
            numericVolumeTransportadosNumero.Value = 0;
            numericVolumeTransportadosPesoBruto.Value = 0;
            numericVolumeTransportadosPesoLiquido.Value = 0;

            gridMercadoria.Rows.Clear();
            labelMercadoriaBaseCalculo.Text = "0.00";
            labelMercadoriaValorICMS.Text = "0.00";
            labelMercadoriaBaseSubstituicao.Text = "0.00";
            labelMercadoriaItens.Text = "0.00";
            labelMercadoriaVolume.Text = "0.00";
            labelMercadoriaTotalMercadoria.Text = "0.00";
            labelMercadoriaValorFrete.Text = "0.00";
            labelMercadoriaValorSeguro.Text = "0.00";
            labelMercadoriaOutrasDespesas.Text = "0.00";
            labelMercadoriaValorIPI.Text = "0.00";
            labelMercadoriaValorICMSDesoneracao.Text = "0.00";
            labelMercadoriaTotalNota.Text = "0.00";

            gridObservacao.Rows.Clear();
            richInformacoesComplementaresInteresseContribuinte.Text = "";
            richInformacoesAdicionaisInteresseFisco.Text = "";
            comboInformacoesComplementaresUF.SelectedIndex = -1;
            textInformacoesComplementaresLocal.Text = "";

            comboCobrancaNotaTipoPagamento.SelectedIndex = -1;
            gridObservacao.Rows.Clear();

            textInfoNFeChaveNFe.Text = "";
            textInfoNFeProtocolo.Text = "";
            textInfoNFeNFeSerie.Text = "";
            textInfoNFeNFeSubSerie.Text = "";

            gridAutorizarXML.Rows.Clear();

            labelDataNotaFiscalSaida.Text = "00000";
            labelDataNotaFiscalSaida.Text = "";
            labelSubTotal.Text = "0.00";
            labelTotal.Text = "0.00";
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
        //private System.Windows.Forms.ComboBox comboInformacoesComplementaresUF;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaBairro;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaChaveNFe;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaCidade;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaPais;
        //private System.Windows.Forms.ComboBox comboLocalEntregaRetiradaUF;
        //private System.Windows.Forms.ComboBox comboObservacaoTipoPagamento

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

            comboTransportadoraUF.ValueMember = comboRemetenteUF.ValueMember;
            comboTransportadoraUF.DisplayMember = comboRemetenteUF.DisplayMember;
            comboTransportadoraUF.DataSource = comboRemetenteUF.DataSource;

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
            TentarGravar();
            Close();
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {
            //GravarMercadoria();

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
        private async Task<bool> CarregarVenda()
        {
            int linha = -1;

            if (VendaId != Guid.Empty)
            {
                using (VendaController vendaController = new VendaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<VendaViewModel> ret = await vendaController.PesquisarId(VendaId);

                    foreach (VendaViewModel vendaViewModel in ret)
                    {
                        dateDataEmissao.Value = vendaViewModel.DataVenda;
                        if (!Funcao.Nulo(vendaViewModel.ClienteId)) comboRemetente.SelectedValue = vendaViewModel.ClienteId;
                        if (!Funcao.Nulo(vendaViewModel.EmpresaId)) comboEmpresa.SelectedValue = vendaViewModel.EmpresaId;
                        numericValorFrete.Value = vendaViewModel.ValorFrete;
                        numericValorDesconto.Value = vendaViewModel.ValorDesconto;
                        if (!Funcao.Nulo(vendaViewModel.TransportadoraId)) comboTransportadora.SelectedValue = vendaViewModel.TransportadoraId;
                        if ((!Funcao.Nulo(vendaViewModel.VeiculoPlaca01)) && (!Funcao.Nulo(vendaViewModel.VeiculoPlaca01.NumeroPlaca))) textTransportadoraPlaca.Text = vendaViewModel.VeiculoPlaca01.NumeroPlaca;
                        if (!Funcao.Nulo(vendaViewModel.TabelaOrigemVendaId)) textLocalEntregaRetiradaEndereco.Text = vendaViewModel.EnderecoEntrega;
                    }
                }

                using (VendaMercadoriaController vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<VendaMercadoriaViewModel> ret = await vendaMercadoriaController.PesquisarVendaId(VendaId);

                    foreach (VendaMercadoriaViewModel vendaMercadoriaViewModel in ret)
                    {
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridMercadoria,
                                                                              new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridMercadoria_CodigoSistema,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_RefSistema,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Mercadoria,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Descricao,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Mercadoria.Nome },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Quantidade,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Quantidade },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Preco,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Preco },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Total,
                                                                                                                                             Valor = vendaMercadoriaViewModel.Total }}).Index; }
                }
            }

            return true;
        }
        private void gridMercadoria_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private bool ValidarDados()
        {
            if (!Combo_ComboBox.Selecionado(comboNaturezaOperacao))
            {
                CaixaMensagem.Informacao("Selecione a natureza de operação");
                return false;
            }
            if (!Combo_ComboBox.Selecionado(comboFinalidade))
            {
                CaixaMensagem.Informacao("Selecione a finalidade");
                return false;
            }
            if (!Funcao.NuloData(dateDataEmissao.Value))
            {
                CaixaMensagem.Informacao("Informa uma data de emissão válida");
                return false;
            }
            if (!Funcao.NuloData(dateDataSaida.Value))
            {
                CaixaMensagem.Informacao("Informa uma data de saída válida");
                return false;
            }
            if (textSerie.Text.Trim() == "")
            {
                CaixaMensagem.Informacao("Informa uma série válida");
                return false;
            }
            if (textModelo.Text.Trim() == "")
            {
                CaixaMensagem.Informacao("Informa um modelo válido");
                return false;
            }

            return true;
        }

        private void comboInfoNFeFidelidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboFinalidade.SelectedValue = comboInfoNFeFidelidade.SelectedValue;
            }
            catch (Exception)
            {
            }
        }

        private void comboFinalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboInfoNFeFidelidade.SelectedValue = comboFinalidade.SelectedValue;
            }
            catch (Exception)
            {
            }
        }

        private void textSerie_TextChanged(object sender, EventArgs e)
        {
            textInfoNFeNFeSerie.Text = textSerie.Text;
        }
        private void textInfoNFeNFeSerie_TextChanged(object sender, EventArgs e)
        {
            textInfoNFeNFeSerie.Text = textSerie.Text;
        }
        private void botaoExcluir_Click(object sender, EventArgs e)
        {

        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {

        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {

        }
        private void botaoImprimir_Click(object sender, EventArgs e)
        {

        }
        private void botaoExportarOutrasNFe_Click(object sender, EventArgs e)
        {

        }
        private void botaoImportarXMLNFe_Click(object sender, EventArgs e)
        {

        }
        private void botaoImportarXMLLote_Click(object sender, EventArgs e)
        {

        }
        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(notafiscalsaida.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Anterior);
        }
        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(notafiscalsaida.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Proximo);
        }
        private async Task Navegar(Declaracoes.eNavegar posicao)
        {
            if (TentarGravar())
            {
                await Navegar_PegarTodos(notafiscalsaida.Id, posicao);
                await CarregarVenda();
            }
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalSaidaViewModel> Data = null;

                Data = await notaFiscalSaidaController.ObterTodos();

                NotaFiscalSaidaViewModel ItemAnterior = null;
                NotaFiscalSaidaViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (NotaFiscalSaidaViewModel Item in Data)
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

                if (ItemRetorno != null) { notafiscalsaida = ItemRetorno; }
            }
        }
        bool TentarGravar()
        {
            bool tentarGravar = false;

            if (notafiscalsaida == null) { goto Sair; }

            if ((notafiscalsaida.Id == Guid.Empty) && (!Combo_ComboBox.Selecionado(comboNaturezaOperacao)))
            {
                tentarGravar = true;
            }
            else
            {
                if (!Combo_ComboBox.Selecionado(comboNaturezaOperacao))
                {
                    CaixaMensagem.Informacao("Informe a natureza de operação");
                    goto Sair;
                }

                Assincrono.TaskAsyncAndAwaitAsync(GravarMercadoria());

                tentarGravar = true;
            }

        Sair:
            return tentarGravar;
        }
        NF_Status Status()
        {
            if (checkStatusCancelado.Checked) { return NF_Status.Cancelado; }
            else if (checkStatusDenegada.Checked) { return NF_Status.Denegada; }
            else if (checkStatusFinalizada.Checked) { return NF_Status.Finalizada; }
            else if (checkStatusInutilizada.Checked) { return NF_Status.Inutilizada; }
            else { return NF_Status.Aberta; }
        }
        private async Task<bool> GravarMercadoria()
        {
            if (notafiscalsaida == null)
                notafiscalsaida = new ViewModels.NotaFiscalSaidaViewModel();

            await AdicionarNotaFiscalSaida();

            return true;
        }
        private async Task AdicionarNotaFiscalSaida()
        {
            var notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier);
            var notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier);
            var notaFiscalSaidaObservacaoController = new NotaFiscalSaidaObservacaoController(this.MeuDbContext(), this._notifier);
            var notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier);
            var notaFiscalSaidaReferenciaController = new NotaFiscalSaidaReferenciaController(this.MeuDbContext(), this._notifier);

            notafiscalsaida.EmpresaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEmpresa);
            notafiscalsaida.NaturezaOperacaoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboNaturezaOperacao);
            notafiscalsaida.NotaFiscalFinalidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFinalidade);
            notafiscalsaida.NotaFiscal = labelNumeroNotaFiscalSaida.Text;
            notafiscalsaida.DataEmissao = dateDataEmissao.Value;
            notafiscalsaida.DataSaida = dateDataSaida.Value;
            notafiscalsaida.HoraEmissao = textHora.Text;
            notafiscalsaida.Modelo = textModelo.Text;
            notafiscalsaida.Serie = textInfoNFeNFeSubSerie.Text;
            notafiscalsaida.SubSerie = textInfoNFeNFeSubSerie.Text;
            notafiscalsaida.Status = Status();
            notafiscalsaida.ClienteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboRemetente);
            notafiscalsaida.CNPJ_CPF = maskedRemetenteCPFCNPJ.Text;
            notafiscalsaida.IE = textRemetenteIE.Text;
            notafiscalsaida.Endereco = new Entidade.Modelos.Endereco();
            notafiscalsaida.Endereco.End_CEP = textRemetenteCEP.Text;
            notafiscalsaida.Endereco.End_Logradouro = textRemetenteEndereco.Text;
            notafiscalsaida.Endereco.End_Numero = textRemetenteNumero.Text;
            notafiscalsaida.Endereco.End_Bairro = textRemetenteBairro.Text;
            notafiscalsaida.Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboRemetenteCidade);
            notafiscalsaida.Telefone = textRemetenteFones.Text;
            notafiscalsaida.EMail = textLocalEntregaRetiradaEMail.Text;
            notafiscalsaida.ValorFrete = numericValorFrete.Value;
            notafiscalsaida.ValorSeguro = numericValorSeguro.Value;
            notafiscalsaida.OutrasDespesas = numericValorOutrasDespesas.Value;
            notafiscalsaida.ValorDesconto = numericValorDesconto.Value;
            notafiscalsaida.PercentualDesconto = numericPercentualDesconto.Value;
            notafiscalsaida.PercentuaAliquotaSimplesNacional = numericAliquotaSimplesNacional.Value;
            notafiscalsaida.TransportadoraId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTransportadora);
            if (Combo_ComboBox.Selecionado(comboTransportadoraFreteConta)) notafiscalsaida.Transportadora_FreteConta = (TipoFrete)comboTransportadoraFreteConta.SelectedValue;
            notafiscalsaida.Transportadora_CNPJ_CPF = Funcoes._Classes.Texto.SomenteNumero(maskedTransportadoraCPFCNPJ.Text);
            notafiscalsaida.Transportadora_Placa = textTransportadoraPlaca.Text;
            notafiscalsaida.Transportadora_UFId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTransportadoraUF);
            notafiscalsaida.Transportadora_RNTRC = textTransportadoraRNTC.Text;
            notafiscalsaida.Transportadora_NumeroCarga = Funcao.NuloParaNumero(numericTransportadoraNumeroCarga.Value);
            notafiscalsaida.VolumeTransportados_Quantidade = Funcao.NuloParaNumero(numericVolumeTransportadosQuantidade.Value);
            notafiscalsaida.VolumeTransportados_Especie = textVolumeTransportadosEspecie.Text;
            notafiscalsaida.VolumeTransportados_Marca = textVolumeTransportadosMarca.Text;
            notafiscalsaida.VolumeTransportados_Numero = Funcao.NuloParaNumero(numericVolumeTransportadosNumero.Value);
            notafiscalsaida.VolumeTransportados_PesoBruto = Funcao.NuloParaNumero(numericVolumeTransportadosPesoBruto.Value);
            notafiscalsaida.VolumeTransportados_PesoLiquido = Funcao.NuloParaNumero(numericVolumeTransportadosPesoLiquido.Value);
            if (Combo_ComboBox.Selecionado(comboRegimeTributario)) { notafiscalsaida.RegimeTributario = (Entidade.Enum.RegimeTributario)comboRegimeTributario.SelectedValue; }
            notafiscalsaida.ObservacaoDocumento = "";
            notafiscalsaida.InformacoesAdicionaisInteresseFisco = richInformacoesAdicionaisInteresseFisco.Text;
            notafiscalsaida.InformacoesComplementaresInteresseContribuinte_Obsersacao = richInformacoesComplementaresInteresseContribuinte.Text;
            notafiscalsaida.InformacoesComplementaresInteresseContribuinte_UFId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboInformacoesComplementaresUF);
            notafiscalsaida.InformacoesComplementaresInteresseContribuinte_Local = textInformacoesComplementaresLocal.Text;
            notafiscalsaida.CodigoChaveAcesso = textInfoNFeChaveNFe.Text;
            notafiscalsaida.Protocolo = textInfoNFeProtocolo.Text;
            notafiscalsaida.IndicaPresenca = (NF_IndicaPresenca)comboInfoNFeIndicaPresenca.SelectedValue;
            notafiscalsaida.TipoEmissao = (NF_TipoEmissao)comboInfoNFeTipoEmissao.SelectedValue;
            notafiscalsaida.Operacao = (NF_Operacao)comboInfoNFeOperacao.SelectedValue;
            notafiscalsaida.EmailDestinoXML = textEmailDestinoXML.Text;

            if (notafiscalsaida.Id != Guid.Empty)
            {
                await notaFiscalSaidaController.Atualizar(notafiscalsaida.Id, notafiscalsaida);
            }
            else
            {
                notafiscalsaida = (await notaFiscalSaidaController.Adicionar(notafiscalsaida));
            }

            NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;

            foreach (DataGridViewRow row in gridMercadoria.Rows)
            {
                NotaFiscalSaidaMercadoriaViewModel notaFiscalSaidaMercadoriaViewModel = new NotaFiscalSaidaMercadoriaViewModel();

                notaFiscalSaidaMercadoriaViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                notaFiscalSaidaMercadoriaViewModel.MercadoriaId = Guid.Parse(row.Cells[gridMercadoria_CodigoSistema].Value.ToString());
                notaFiscalSaidaMercadoriaViewModel.TabelaNCMId = (Guid)row.Cells[gridMercadoria_NCM].Value;
                notaFiscalSaidaMercadoriaViewModel.TabelaCST_CSOSNId = (Guid)row.Cells[gridMercadoria_CST_CSOSN].Value;
                notaFiscalSaidaMercadoriaViewModel.TabelaCFOPId = (Guid)row.Cells[gridMercadoria_CFOP].Value;
                notaFiscalSaidaMercadoriaViewModel.UnidadeMedidaId = (Guid)row.Cells[gridMercadoria_Medida].Value;
                notaFiscalSaidaMercadoriaViewModel.Descricao = row.Cells[gridMercadoria_Descricao].Value.ToString();
                notaFiscalSaidaMercadoriaViewModel.Quantidade = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_Quantidade].Value);
                notaFiscalSaidaMercadoriaViewModel.PrecoUnitario = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_Preco].Value);
                notaFiscalSaidaMercadoriaViewModel.PrecoTotal = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_Total].Value);
                notaFiscalSaidaMercadoriaViewModel.PercentualICMS = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_ICMS].Value);
                notaFiscalSaidaMercadoriaViewModel.PercentualIPI = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_IPI].Value);
                notaFiscalSaidaMercadoriaViewModel.PercentualFrete = (float)Funcao.NuloParaValorD(row.Cells[gridMercadoria_Frete].Value);

                if (row.Cells[gridMercadoria_Impostos].Value != null)
                {
                    notaFiscalMercadoriaDetalhamentoImposto = (NotaFiscalMercadoriaDetalhamentoImposto)row.Cells[gridMercadoria_Impostos].Value;
                    notaFiscalSaidaMercadoriaViewModel.ValorBaseCalculo = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaICMS = notaFiscalMercadoriaDetalhamentoImposto.AliquotaICMS;
                    notaFiscalSaidaMercadoriaViewModel.ValorICMS = notaFiscalMercadoriaDetalhamentoImposto.ValorICMS;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaReducao = notaFiscalMercadoriaDetalhamentoImposto.AliquotaReducao;
                    notaFiscalSaidaMercadoriaViewModel.ValorBaseSubstituicaoTributaria = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria;
                    notaFiscalSaidaMercadoriaViewModel.ValorSubstituicaoTributaria = notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria;
                    notaFiscalSaidaMercadoriaViewModel.ValorAdicional = notaFiscalMercadoriaDetalhamentoImposto.ValorAdicional;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaAdicional = notaFiscalMercadoriaDetalhamentoImposto.AliquotaAdicional;
                    notaFiscalSaidaMercadoriaViewModel.TabelaCST_IPIId = notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS;
                    notaFiscalSaidaMercadoriaViewModel.ValorBaseIPI = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseIPI;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaIPI = notaFiscalMercadoriaDetalhamentoImposto.AliquotaIPI;
                    notaFiscalSaidaMercadoriaViewModel.ValorIPI = notaFiscalMercadoriaDetalhamentoImposto.ValorIPI;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaPIS = notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaCOFINS = notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS;
                    notaFiscalSaidaMercadoriaViewModel.BaseCalculoFCP = notaFiscalMercadoriaDetalhamentoImposto.BaseCalculoFCP;
                    notaFiscalSaidaMercadoriaViewModel.AliquotaFCP = notaFiscalMercadoriaDetalhamentoImposto.AliquotaFCP;
                    notaFiscalSaidaMercadoriaViewModel.ValorFCP = notaFiscalMercadoriaDetalhamentoImposto.ValorFCP;
                    notaFiscalSaidaMercadoriaViewModel.NumeroPedidoCompra = notaFiscalMercadoriaDetalhamentoImposto.NumeroPedidoCompra;
                    notaFiscalSaidaMercadoriaViewModel.ItemPedidoCompra = notaFiscalMercadoriaDetalhamentoImposto.ItemPedidoCompra;
                    notaFiscalSaidaMercadoriaViewModel.TabelaCST_PIS_COFINS_PISId = notaFiscalMercadoriaDetalhamentoImposto.CSTPIS ;
                    notaFiscalSaidaMercadoriaViewModel.TabelaCST_PIS_COFINS_PISCOFINSId = notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS;
                }

                await notaFiscalSaidaMercadoriaController.Adicionar(notaFiscalSaidaMercadoriaViewModel);
            }

            foreach (DataGridViewRow row in gridObservacao.Rows)
            {
                NotaFiscalSaidaObservacaoViewModel notaFiscalSaidaObservacaoViewModel = new NotaFiscalSaidaObservacaoViewModel();

                notaFiscalSaidaObservacaoViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                notaFiscalSaidaObservacaoViewModel.Descricao = row.Cells[gridObservacao_Descricao].Value.ToString();
                if (row.Cells[gridObservacao_ID].Value != null) notaFiscalSaidaObservacaoViewModel.ObservacaoId = Guid.Parse(row.Cells[gridObservacao_ID].Value.ToString());

                await notaFiscalSaidaObservacaoController.Adicionar(notaFiscalSaidaObservacaoViewModel);
            }

            foreach (DataGridViewRow row in gridCobrancaNota.Rows)
            {
                NotaFiscalSaidaPagamentoViewModel NotaFiscalSaidaPagamentoViewModel = new NotaFiscalSaidaPagamentoViewModel();

                NotaFiscalSaidaPagamentoViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                NotaFiscalSaidaPagamentoViewModel.DataVecimento = Convert.ToDateTime(row.Cells[gridCobrancaNota_Vencimento].Value);
                NotaFiscalSaidaPagamentoViewModel.Valor = Convert.ToDecimal(row.Cells[gridCobrancaNota_Valor].Value);
                NotaFiscalSaidaPagamentoViewModel.FormaPagamentoId = (Guid)row.Cells[gridCobrancaNota_TipoPagamento].Value;

                await notaFiscalSaidaPagamentoController.Adicionar(NotaFiscalSaidaPagamentoViewModel);
            }

            foreach (DataGridViewRow row in gridCobrancaNota.Rows)
            {
                NotaFiscalSaidaReferenciaViewModel NotaFiscalSaidaReferenciaViewModel = new NotaFiscalSaidaReferenciaViewModel();

                NotaFiscalSaidaReferenciaViewModel.NotaFiscal = row.Cells[gridInfoNFe_NFe_NFCe].Value.ToString();
                NotaFiscalSaidaReferenciaViewModel.CodigoChaveAcesso = row.Cells[gridInfoNFe_ChaveNFe_NFCe].Value.ToString();
                NotaFiscalSaidaReferenciaViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;

                await notaFiscalSaidaReferenciaController.Adicionar(NotaFiscalSaidaReferenciaViewModel);
            }

            notaFiscalSaidaController.Dispose();
            notaFiscalSaidaMercadoriaController.Dispose();
            notafiscalsaida = null;

            this.MeuDbContextDispose();
        }
        private async void Excluir()
        {
            /*var mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier);
            await mercadoriaController.Excluir(mercadoria.Id);
            mercadoriaController = null;
            this.MeuDbContextDispose();*/

            Limpar();
        }

        private void frmFiscal_NotaFiscal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TentarGravar())
            {
                e.Cancel = (!CaixaMensagem.Perguntar("Cadastro em edição! Deseja sair assim mesmo?"));
            }

            this.MeuDbContextDispose();
        }
        private void GridProduto_SelecionarProduto(int iLinha, int Coluna, string valor)
        {
            try
            {
                if (Coluna == gridMercadoria_CodigoSistema)
                {
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_Descricao].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_RefSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridMercadoria_Descricao)
                {
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_RefSistema].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_CodigoSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridMercadoria_RefSistema)
                {
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_Descricao].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_CodigoSistema].Value = Guid.Parse(valor);
                }
            }
            catch (Exception)
            {
            }
        }
        private void gridMercadoria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == gridMercadoria_CodigoSistema) ||
                    (e.ColumnIndex == gridMercadoria_Descricao) ||
                    (e.ColumnIndex == gridMercadoria_RefSistema))
                {
                    GridProduto_SelecionarProduto(e.RowIndex, e.ColumnIndex, gridMercadoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    if (mercadoriaImpostoEstado != null)
                    foreach(MercadoriaImpostoEstadoViewModel impostoestado in mercadoriaImpostoEstado)
                    {
                        if (impostoestado.Mercadoria.Id == (Guid)gridMercadoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                        gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_ICMS].Value = impostoestado.PercentualICMS_Destino;
                    }
                }
                else if ((e.ColumnIndex == gridMercadoria_Quantidade) ||
                         (e.ColumnIndex == gridMercadoria_Preco))
                {
                    gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Total].Value = Funcao.NuloParaNumero(gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Quantidade].Value) *
                                                                                        Funcao.NuloParaNumero(gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Preco].Value);
                }
            }
            catch (Exception)
            {
            }
        }
        private void gridMercadoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == gridMercadoria_BTN_Impostos) && (e.RowIndex > -1))
            {
                using (frmFiscal_NotaFiscal_Impostos form = ServiceProvider().GetRequiredService<frmFiscal_NotaFiscal_Impostos>())
                {
                    if (gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value != null)
                    form.notaFiscalMercadoriaDetalhamentoImposto = (NotaFiscalMercadoriaDetalhamentoImposto)gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value;
                    form.Produto = gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Descricao].Value.ToString();
                    try { form.ValorTotal = Funcao.NuloParaValorD(gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Total].Value); }
                    catch (Exception) { }
                    form.FormatarAsync();
                    form.ShowDialog(this);
                    gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value = form.notaFiscalMercadoriaDetalhamentoImposto;
                }
            }
        }

        private void gridCobrancaNota_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            labelCobrancaNotaTotal.Text = labelCobrancaNotaTotal.Tag.ToString() + " " + Grid_DataGridView.DataGridView_CalcularColunaValor(gridCobrancaNota, gridCobrancaNota_Valor).ToString("c");
            labelCobrancaNotaQuantidade.Text = labelCobrancaNotaQuantidade.Tag.ToString() + " " + Grid_DataGridView.DataGridView_QuantidadeLinha(gridCobrancaNota, gridCobrancaNota_TipoPagamento).ToString();
        }

        private void gridCobrancaNota_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            labelCobrancaNotaQuantidade.Text = labelCobrancaNotaQuantidade.Tag.ToString() + " " + Grid_DataGridView.DataGridView_QuantidadeLinha(gridCobrancaNota, gridCobrancaNota_TipoPagamento).ToString();
        }

        private void comboRemetente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboRemetente))
            {
                CarregarDadosClientes();
            }
        }

        private async Task CarregarDadosClientes()
        {
            using (PessoaController pessoaController = new PessoaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<PessoaViewModel> ret = await pessoaController.PesquisarId((Guid)comboRemetente.SelectedValue);

                foreach (PessoaViewModel pessoaViewModel in ret)
                {
                    dadolocal_Cliente_EstadoId = pessoaViewModel.Endereco.End_Cidade.Estado.Id;
                }
            }

            if (dadolocal_Cliente_EstadoId != Guid.Empty)
            {
                using (MercadoriaImpostoEstadoController mercadoriaImpostoEstadoController = new MercadoriaImpostoEstadoController(this.MeuDbContext(), this._notifier))
                {
                    mercadoriaImpostoEstado = await mercadoriaImpostoEstadoController.ObterPorEstadosId(Declaracoes.dados_Empresa_EstadoId, 
                                                                                                        dadolocal_Cliente_EstadoId);
                }
            }
        }

        private void botaoCadastroObservacoes_Click(object sender, EventArgs e)
        {
            using (frmCadastroObservacao form = ServiceProvider().GetRequiredService<frmCadastroObservacao>())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void gridObservacao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridObservacao_Codigo)
            {
                gridObservacao.Rows[e.RowIndex].Cells[gridObservacao_Descricao].Value = gridObservacao.Rows[e.RowIndex].Cells[gridObservacao_Codigo].EditedFormattedValue;
            }
        }

        private void botaoAtualizarInfoComplementoObservacao_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridObservacao.Rows)
            {
                if (richInformacoesComplementaresInteresseContribuinte.Text.Trim() != "")
                    richInformacoesComplementaresInteresseContribuinte.Text = richInformacoesComplementaresInteresseContribuinte.Text + Environment.NewLine;

                richInformacoesComplementaresInteresseContribuinte.Text = richInformacoesComplementaresInteresseContribuinte.Text + row.Cells[gridObservacao_Descricao].Value;
            }
        }

        private void comboInfoNFeOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboInfoNFeOrigem_Tratar();
        }

        async void comboInfoNFeOrigem_Tratar()
        {
            if (comboInfoNFeOrigem.SelectedIndex != -1)
            {
                try
                {
                    List<NF_ComboViewModel> comboViewModel = new List<NF_ComboViewModel>();

                    switch ((TipoNotaReferenciada)comboInfoNFeOrigem.SelectedValue)
                    {
                        case TipoNotaReferenciada.Cliente:
                            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                            {
                                comboViewModel = (List<NF_ComboViewModel>)await notaFiscalSaidaController.ComboChave(o => o.CodigoChaveAcesso);
                            }
                            break;
                        case TipoNotaReferenciada.Fornecedor:
                            using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
                            {
                                comboViewModel = (List<NF_ComboViewModel>)await notaFiscalEntradaController.Combo(o => o.CodigoChaveAcesso);
                            }
                            break;
                        case TipoNotaReferenciada.NFCe:
                            return;
                            break;
                    }

                    ((DataGridViewComboBoxColumn)gridInfoNFe.Columns[gridInfoNFe_NFe_NFCe]).DataSource = comboViewModel;
                    ((DataGridViewComboBoxColumn)gridInfoNFe.Columns[gridInfoNFe_ChaveNFe_NFCe]).DataSource = comboViewModel;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}