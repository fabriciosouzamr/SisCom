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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texto = Funcoes._Classes.Texto;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NotaFiscal : FormMain
    {
        ViewModels.NotaFiscalSaidaViewModel notafiscalsaida = null;
        public Guid VendaId;
        
        const int gridMercadoria_Id = 0;
        const int gridMercadoria_CodigoSistema = 1;
        const int gridMercadoria_RefSistema = 2;
        const int gridMercadoria_Mercadoria = 3;
        const int gridMercadoria_Descricao = 4;
        const int gridMercadoria_NCM = 5;
        const int gridMercadoria_CST_CSOSN = 6;
        const int gridMercadoria_CFOP = 7;
        const int gridMercadoria_UnidadeMedida = 8;
        const int gridMercadoria_Quantidade = 9;
        const int gridMercadoria_Preco = 10;
        const int gridMercadoria_Total = 11;
        const int gridMercadoria_ICMS = 12;
        const int gridMercadoria_IPI = 13;
        const int gridMercadoria_Frete = 14;
        const int gridMercadoria_BTN_Impostos = 15;
        const int gridMercadoria_BTN_Excluir = 16;
        const int gridMercadoria_Impostos = 17;
        const int gridMercadoria_PesoBruto = 18;
        const int gridMercadoria_PesoLiquido = 19;
         
        const int gridCobrancaNota_Id = 0;
        const int gridCobrancaNota_TipoPagamento = 1;
        const int gridCobrancaNota_Vencimento = 2;
        const int gridCobrancaNota_Valor = 3;

        const int gridObservacao_Id = 0;
        const int gridObservacao_Codigo = 1;
        const int gridObservacao_Descricao = 2;

        const int gridInfoNFe_Id = 0;
        const int gridInfoNFe_NFe_NFCe = 1;
        const int gridInfoNFe_ChaveNFe_NFCe = 2;

        const int gridVenda_ID = 0;
        const int gridVenda_Codigo = 1;
        const int gridVenda_DataVenda = 2;

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

        Guid dadolocal_Cliente_EstadoId = Guid.Empty;
        Guid cfop_5102 = Guid.Parse("BFDC3E42-3DF4-4463-A866-07684FBAC021");
        Guid cfop_6102 = Guid.Parse("40CBC68C-DFA2-4FE2-B819-9036FF92C360");

        List<Guid> notaFiscalSaidaObservacaoExcluir;
        List<Guid> notaFiscalSaidaMercadoriaExcluir;
        List<Guid> notaFiscalSaidaPagamentoExcluir;
        List<Guid> notaFiscalSaidaReferenciaExcluir;

        IEnumerable<MercadoriaImpostoEstadoViewModel> mercadoriaImpostoEstado;

        bool carregando = false;

        public frmFiscal_NotaFiscal(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
        }
        async Task Inicializa()
        {
            carregando = true;

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
            comboRegimeTributario.SelectedValue = Declaracoes.dados_Empresa_RegimeTributario;

            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
            await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());

            if (textSerie.Text.Trim() == "")
            {
                using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
                {
                    var empresa = (await empresaController.GetById(Declaracoes.dados_Empresa_Id));

                    if (empresa != null)
                    {
                        textSerie.Text = Funcao.NuloParaString(empresa.NFE_Serie);
                    }
                }
            }

            if (textNumeroNotaFiscalSaida.Text.Trim() == "")
            {
                using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(this.MeuDbContext(), this._notifier))
                {
                    var notaFiscalSaidaSerie = (await notaFiscalSaidaSerieController.PesquisarSerie(textSerie.Text)).FirstOrDefault();

                    if (notaFiscalSaidaSerie != null)
                    {
                        if (String.IsNullOrEmpty(notaFiscalSaidaSerie.UltimaNotaFiscal))
                        { textNumeroNotaFiscalSaida.Text = "1"; }
                        else
                        { textNumeroNotaFiscalSaida.Text = (Convert.ToInt16(notaFiscalSaidaSerie.UltimaNotaFiscal) + 1).ToString(); }
                    }
                }
            }

            carregando = false;
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
                produto.Columns.Add("PesoBruto", typeof(double));
                produto.Columns.Add("PesoLiquido", typeof(double));

                using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<MercadoriaViewModel> ret = await mercadoriaController.ObterTodos();

                    foreach (var item in ret)
                    {
                        produto.Rows.Add(item.Id, item.Nome, item.Codigo, item.CodigoFabricante, item.Estoque_PesoBruto, item.Estoque_PesoLiquido);
                    }
                }
                using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
                {
                    unidadeMedida = (List<NomeComboViewModel>)await unidadeMedidaController.Combo(o => o.Nome);
                }
                using (TabelaCFOPController tabelaCFOPController = new TabelaCFOPController(this.MeuDbContext(), this._notifier))
                {
                    tabelaCFOP = (List<CodigoComboViewModel>)await tabelaCFOPController.Combo(entradaSaida: EntradaSaida.Saida, o => o.Codigo);
                }
                using (TabelaNCMController tabelaNCMController = new TabelaNCMController(this.MeuDbContext(), this._notifier))
                {
                    tabelaNCM = (List<CodigoDescricaoComboViewModel>)await tabelaNCMController.Combo(o => o.Codigo);
                }
                using (TabelaCST_CSOSNController tabelaCST_CSOSNController = new TabelaCST_CSOSNController(this.MeuDbContext(), this._notifier))
                {
                    tabelaCST_CSOSN = (List<CodigoDescricaoComboViewModel>)await tabelaCST_CSOSNController.Combo(o => o.Codigo, w => w.CRT == Declaracoes.dados_Empresa_RegimeTributario.GetHashCode());
                }

                foreach(CodigoComboViewModel cfop in tabelaCFOP)
                {
                    switch(cfop.Codigo)
                    {
                        case "5102":
                            cfop_5102 = cfop.Id;
                            break;
                        case "6102":
                            cfop_6102 = cfop.Id;
                            break;
                    }
                }

                //Detalhe de Mercadoria
                Grid_DataGridView.DataGridView_Formatar(gridMercadoria, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Id", "Id", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "Id", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "Id", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Mercadoria", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "Id", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "Descrição", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "NCM", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaNCM, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "CST/CSOSN", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCST_CSOSN, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "", "CFOP", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCFOP, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, unidadeMedida, "Nome", "ID", readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Preço", "Preço", Grid_DataGridView.TipoColuna.Valor, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Total", "Total", Grid_DataGridView.TipoColuna.Valor, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "ICMS", "ICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "IPI", "IPI", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Frete", "Frete", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Grid_DataGridView.TipoColuna.Button, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Excluir", "Excluir", Grid_DataGridView.TipoColuna.Button, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "PesoBruto", "PesoBruto", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridMercadoria, "PesoLiquido", "PesoLiquido", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);

                //Cobrança da Nota
                List<NomeComboViewModel> formaPagamento;

                using (FormaPagamentoController formaPagamentoController = new FormaPagamentoController(this.MeuDbContext(), this._notifier))
                {
                    formaPagamento = (List<NomeComboViewModel>)await formaPagamentoController.Combo(o => o.Nome);
                }

                Grid_DataGridView.DataGridView_Formatar(gridCobrancaNota, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Pagamento", "MedidaPagamento", Grid_DataGridView.TipoColuna.ComboBox, 200, 0, formaPagamento, "Nome", "ID", false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Vencimento", "Vencimento", Grid_DataGridView.TipoColuna.Data, 100, 0, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridCobrancaNota, "Valor", "Valor", Grid_DataGridView.TipoColuna.Valor, 100, 0, readOnly: false);

                //Obsrevação
                List<CodigoDescricaoComboViewModel> observacao;

                using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
                {
                    observacao = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Descricao);
                }

                Grid_DataGridView.DataGridView_Formatar(gridObservacao, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "Código", "Código", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, dataSource: observacao,
                                                                                                                                                  dataSource_Descricao: "Descricao",
                                                                                                                                                  dataSource_Valor: "ID",
                                                                                                                                                  dropDownWidth: 400,
                                                                                                                                                  readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "Descrição", "Descrição", Grid_DataGridView.TipoColuna.Texto, 400, 0, readOnly: false);

                //NF-e
                Grid_DataGridView.DataGridView_Formatar(gridInfoNFe, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "NF-e/NFC-e Nº", "NF-e/NFC-e Nº", Tamanho: 100, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
                                                                                                                            dataSource_Descricao: "NotaFiscal",
                                                                                                                            dataSource_Valor: "ID",
                                                                                                                            readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridInfoNFe, "Chave NF-e/NFC-e", "Chave NF-e/NFC-e", Tamanho: 500, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
                                                                                                                                  dataSource_Descricao: "CodigoChaveAcesso",
                                                                                                                                  dataSource_Valor: "ID",
                                                                                                                                  readOnly: false);

                //Venda
                Grid_DataGridView.DataGridView_Formatar(gridVenda, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridVenda, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridVenda, "Código", "Código", Tamanho: 65);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridVenda, "Data da Venda", "Data da Venda", Tamanho: 140, Tipo: Grid_DataGridView.TipoColuna.Data);

                notafiscalsaida = new ViewModels.NotaFiscalSaidaViewModel();
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

            return true;
        }
        private void Limpar()
        {
            Editar(false);

            datePeriodoInicial.Value = DateTime.Now.Date;
            textHora.Text = DateTime.Now.ToString("HH:mm");

            comboNaturezaOperacao.SelectedIndex = -1;

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
            numericPercentualAliquotaSimplesNacional.Value = 0;
            comboTransportadora.SelectedIndex = -1;
            comboTransportadoraFreteConta.SelectedIndex = -1;
            Texto_MaskedTextBox.Limpar(maskedTransportadoraCPFCNPJ);
            textTransportadoraPlaca.Text = "";
            comboTransportadoraUF.SelectedIndex = -1;
            textTransportadoraRNTC.Text = "";
            numericTransportadoraNumeroCarga.Value = 0;
            comboRegimeTributario.SelectedValue = Declaracoes.dados_Empresa_RegimeTributario;
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

            gridVenda.Rows.Clear();

            textInfoNFeChaveNFe.Text = "";
            textInfoNFeProtocolo.Text = "";
            textInfoNFeNFeSerie.Text = "";
            textInfoNFeNFeSubSerie.Text = "";

            gridAutorizarXML.Rows.Clear();

            labelDataNotaFiscalSaida.Text = "00000";
            labelDataNotaFiscalSaida.Text = "";
            labelSubTotal.Text = "0.00";
            labelTotal.Text = "0.00";
            checkValidado.Checked = false;

            notaFiscalSaidaObservacaoExcluir = new List<Guid>();
            notaFiscalSaidaMercadoriaExcluir = new List<Guid>();
            notaFiscalSaidaPagamentoExcluir = new List<Guid>();
            notaFiscalSaidaReferenciaExcluir = new List<Guid>();
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

            comboFinalidade.SelectedValue = Guid.Parse("C22B45E8-CCB4-4D85-84BD-76C7290F7905");

            foreach (ComboNaturezaOperacaoViewModel item in comboNaturezaOperacao.Items)
            {
                if ((Declaracoes.dados_Empresa_EstadoId == dadolocal_Cliente_EstadoId) || (dadolocal_Cliente_EstadoId == Guid.Empty))
                { 
                    if (item.TabelaCFOPId == cfop_5102)
                    {
                        comboNaturezaOperacao.SelectedValue = item.Id;
                        break;
                    }
                }
                else
                { 
                    if (item.TabelaCFOPId == cfop_6102)
                    {
                        comboNaturezaOperacao.SelectedValue = item.Id;
                        break;
                    }
                }
            }

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
            comboTransportadoraUF.SelectedIndex = -1;

            return true;
        }
        private async Task<bool> comboCidade_Carregar(Guid EstadoId)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                var id = comboRemetenteCidade.SelectedValue;

                Combo_ComboBox.Formatar(comboRemetenteCidade,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));

                if (id != null) comboRemetenteCidade.SelectedValue = id;
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
                                        await (new TransportadoraController(this.MeuDbContext(), this._notifier)).Combo(o => o.Nome));
            }

            return true;
        }
        #endregion
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            TentarGravar();
            Close();
        }
        private async void comboRemetenteUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboRemetenteUF.SelectedIndex != -1) && (comboRemetenteUF.Tag != Declaracoes.ComboBox_Carregando))
            {
                if (Combo_ComboBox.Selecionado(comboRemetenteUF))
                {
                    await Assincrono.TaskAsyncAndAwaitAsync(comboRemetenteUF_Tratar());
                }
            }
        }
        private async Task<bool> comboRemetenteUF_Tratar()
        {
            await comboCidade_Carregar(Guid.Parse(comboRemetenteUF.SelectedValue.ToString()));
            await comboPais_Carregar();

            return true;
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
        private async Task<bool> CarregarDados()
        {
            int linha = -1;
            Guid cfop;

            if (VendaId != Guid.Empty)
            {
                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                {
                    notafiscalsaida = (await notaFiscalSaidaController.ObterTodos(w => w.VendaId == VendaId)).FirstOrDefault();
                }

                if (notafiscalsaida == null)
                {
                    using (VendaController vendaController = new VendaController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<VendaViewModel> ret = await vendaController.PesquisarId(VendaId);

                        foreach (VendaViewModel vendaViewModel in ret)
                        {
                            dateDataEmissao.Value = vendaViewModel.DataVenda;
                            if (!Funcao.Nulo(vendaViewModel.ClienteId))
                            {
                                comboRemetente.SelectedValue = vendaViewModel.ClienteId;
                                Texto_MaskedTextBox.FormatarTipoPessoa(vendaViewModel.Cliente.TipoPessoa, maskedRemetenteCPFCNPJ);
                                if (!String.IsNullOrEmpty(vendaViewModel.Cliente.CNPJ_CPF)) { maskedRemetenteCPFCNPJ.Text = vendaViewModel.Cliente.CNPJ_CPF; }
                                if ((vendaViewModel.Cliente.Endereco.End_Cidade != null))
                                {
                                    dadolocal_Cliente_EstadoId = vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId;
                                    if (!Funcao.Nulo(vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId))
                                    {
                                        comboRemetenteUF.SelectedValue = vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId;
                                        await Assincrono.TaskAsyncAndAwaitAsync(comboRemetenteUF_Tratar());
                                    }
                                    if (!Funcao.Nulo(vendaViewModel.Cliente.Endereco.End_CidadeId)) comboRemetenteCidade.SelectedValue = vendaViewModel.Cliente.Endereco.End_CidadeId;
                                }
                                textRemetenteEndereco.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Logradouro);
                                textRemetenteNumero.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Numero);
                                textRemetenteBairro.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Bairro);
                                textRemetenteCEP.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_CEP);
                                textRemetenteFones.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Telefone);
                                textRemetenteEMail.Text = Funcao.NuloParaString(vendaViewModel.Cliente.EMail);
                            }
                            if (!Funcao.Nulo(vendaViewModel.EmpresaId)) comboEmpresa.SelectedValue = vendaViewModel.EmpresaId;
                            numericValorFrete.Value = vendaViewModel.ValorFrete;
                            numericValorDesconto.Value = vendaViewModel.ValorDesconto;
                            if (!Funcao.Nulo(vendaViewModel.TransportadoraId))
                            {
                                Texto_MaskedTextBox.FormatarTipoPessoa((TipoPessoaCliente)vendaViewModel.Transportadora.TipoPessoa, maskedRemetenteCPFCNPJ);
                                if (!String.IsNullOrEmpty(vendaViewModel.Cliente.CNPJ_CPF)) { maskedRemetenteCPFCNPJ.Text = vendaViewModel.Cliente.CNPJ_CPF; }
                                comboTransportadora.SelectedValue = vendaViewModel.TransportadoraId;
                            }

                            if ((!Funcao.Nulo(vendaViewModel.VeiculoPlaca01)) && (!Funcao.Nulo(vendaViewModel.VeiculoPlaca01.NumeroPlaca))) textTransportadoraPlaca.Text = vendaViewModel.VeiculoPlaca01.NumeroPlaca;
                            if (!Funcao.Nulo(vendaViewModel.TabelaOrigemVendaId)) textLocalEntregaRetiradaEndereco.Text = vendaViewModel.EnderecoEntrega;
                        }
                    }

                    Grid_DataGridView.DataGridView_LinhaLimpar(gridMercadoria);

                    using (VendaMercadoriaController vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<VendaMercadoriaViewModel> ret = await vendaMercadoriaController.PesquisarVendaId(VendaId);

                        foreach (VendaMercadoriaViewModel vendaMercadoriaViewModel in ret)
                        {
                            if (Declaracoes.dados_Empresa_EstadoId == dadolocal_Cliente_EstadoId)
                            { cfop = cfop_5102; }
                            else
                            { cfop = cfop_6102; }

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
                                                                                                                                                 Valor = vendaMercadoriaViewModel.Total },
                                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_CFOP,
                                                                                                                                                 Valor = cfop },
                                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoBruto,
                                                                                                                                                 Valor = vendaMercadoriaViewModel.Mercadoria.Estoque_PesoBruto },
                                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoLiquido,
                                                                                                                                                 Valor = vendaMercadoriaViewModel.Mercadoria.Estoque_PesoLiquido }}).Index;
                        }
                    }

                    await GravarMercadoria(validar: false);
                }

                await Assincrono.TaskAsyncAndAwaitAsync(CarregarListaVenda(VendaId));
                Editar(true);
            }

            if ((notafiscalsaida != null) && (notafiscalsaida.Id != Guid.Empty))
            {
                Limpar();

                checkValidado.Checked = true;

                if (!Funcao.Nulo(notafiscalsaida.EmpresaId)) comboEmpresa.SelectedValue = notafiscalsaida.EmpresaId;
                if (!Funcao.Nulo(notafiscalsaida.NaturezaOperacaoId)) comboNaturezaOperacao.SelectedValue = notafiscalsaida.NaturezaOperacaoId;
                if (!Funcao.Nulo(notafiscalsaida.NotaFiscalFinalidadeId)) comboFinalidade.SelectedValue = notafiscalsaida.NotaFiscalFinalidadeId;
                textNumeroNotaFiscalSaida.Text = Funcao.NuloParaString(notafiscalsaida.NotaFiscal);
                dateDataEmissao.Value = notafiscalsaida.DataEmissao;
                dateDataSaida.Value = notafiscalsaida.DataSaida;
                textHora.Text = Funcao.NuloParaString(notafiscalsaida.HoraEmissao);
                textModelo.Text = Funcao.NuloParaString(notafiscalsaida.Modelo);
                textSerie.Text = Funcao.NuloParaString(notafiscalsaida.Serie);
                textInfoNFeNFeSubSerie.Text = Funcao.NuloParaString(notafiscalsaida.SubSerie);
                checkStatusCancelado.Checked = (notafiscalsaida.Status == NF_Status.Cancelado);
                checkStatusFinalizada.Checked = (notafiscalsaida.Status == NF_Status.Finalizada);
                checkStatusDenegada.Checked = (notafiscalsaida.Status == NF_Status.Denegada);
                checkStatusInutilizada.Checked = (notafiscalsaida.Status == NF_Status.Inutilizada);
                if (!Funcao.Nulo(notafiscalsaida.ClienteId)) comboRemetente.SelectedValue = notafiscalsaida.ClienteId;
                maskedRemetenteCPFCNPJ.Text = notafiscalsaida.CNPJ_CPF;
                textRemetenteIE.Text = notafiscalsaida.IE;

                if (notafiscalsaida.Cliente_Endereco.End_Cidade == null)
                {
                    notafiscalsaida.Cliente_Endereco.End_Cidade = notafiscalsaida.Cliente.Endereco.End_Cidade;
                    notafiscalsaida.Cliente_Endereco.End_Bairro = notafiscalsaida.Cliente.Endereco.End_Bairro;
                    notafiscalsaida.Cliente_Endereco.End_CEP = notafiscalsaida.Cliente.Endereco.End_CEP;
                    notafiscalsaida.Cliente_Endereco.End_CidadeId = notafiscalsaida.Cliente.Endereco.End_CidadeId;
                    notafiscalsaida.Cliente_Endereco.End_Complemento = notafiscalsaida.Cliente.Endereco.End_Complemento;
                    notafiscalsaida.Cliente_Endereco.End_Logradouro = notafiscalsaida.Cliente.Endereco.End_Logradouro;
                    notafiscalsaida.Cliente_Endereco.End_Numero = notafiscalsaida.Cliente.Endereco.End_Numero;
                    notafiscalsaida.Cliente_Endereco.End_PontoReferencia = notafiscalsaida.Cliente.Endereco.End_PontoReferencia;
                    dadolocal_Cliente_EstadoId = notafiscalsaida.Cliente.Endereco.End_Cidade.EstadoId;
                }
                else
                {
                    dadolocal_Cliente_EstadoId = notafiscalsaida.Cliente_Endereco.End_Cidade.EstadoId;
                }

                if (!String.IsNullOrEmpty(notafiscalsaida.Cliente_Endereco.End_Logradouro))
                {
                    textRemetenteEndereco.Text = Funcao.NuloParaString(notafiscalsaida.Cliente_Endereco.End_Logradouro);
                    textRemetenteNumero.Text = Funcao.NuloParaString(notafiscalsaida.Cliente_Endereco.End_Numero);
                    textRemetenteFones.Text = Funcao.NuloParaString(notafiscalsaida.Cliente_Telefone);
                    textRemetenteEMail.Text = Funcao.NuloParaString(notafiscalsaida.Cliente_EMail);
                    if (notafiscalsaida.Cliente_Endereco.End_Cidade != null)
                    {
                        if (notafiscalsaida.Cliente_Endereco.End_Cidade.Estado != null)
                        {
                            if (!Funcao.Nulo(notafiscalsaida.Cliente_Endereco.End_Cidade.Estado.Id)) comboRemetenteUF.SelectedValue = notafiscalsaida.Cliente_Endereco.End_Cidade.Estado.Id;
                            await comboRemetenteUF_Tratar();
                        }
                        if (!Funcao.Nulo(notafiscalsaida.Cliente_Endereco.End_CidadeId)) comboRemetenteCidade.SelectedValue = notafiscalsaida.Cliente_Endereco.End_CidadeId;
                    }
                }
                else
                {
                    await CarregarDadosClientes();
                }
                numericValorFrete.Value = notafiscalsaida.ValorFrete;
                numericValorSeguro.Value = notafiscalsaida.ValorSeguro;
                numericValorOutrasDespesas.Value = notafiscalsaida.OutrasDespesas;
                numericPercentualDesconto.Value = notafiscalsaida.PercentualDesconto;
                numericValorDesconto.Value = notafiscalsaida.ValorDesconto;
                numericPercentualAliquotaSimplesNacional.Value = notafiscalsaida.PercentuaAliquotaSimplesNacional;

                if (!Funcao.Nulo(notafiscalsaida.TransportadoraId)) comboTransportadora.SelectedValue = notafiscalsaida.TransportadoraId;
                comboTransportadoraFreteConta.SelectedValue = notafiscalsaida.Transportadora_FreteConta;
                maskedTransportadoraCPFCNPJ.Text = notafiscalsaida.Transportadora_CNPJ_CPF;
                textTransportadoraPlaca.Text = notafiscalsaida.Transportadora_Placa;
                if (!Funcao.Nulo(notafiscalsaida.Transportadora_UFId)) comboTransportadoraUF.SelectedValue = notafiscalsaida.Transportadora_UFId;
                textTransportadoraRNTC.Text = Funcao.NuloParaString(notafiscalsaida.Transportadora_RNTRC);
                numericTransportadoraNumeroCarga.Value = notafiscalsaida.Transportadora_NumeroCarga;
                numericVolumeTransportadosQuantidade.Value = notafiscalsaida.VolumeTransportados_Quantidade;
                textVolumeTransportadosEspecie.Text = notafiscalsaida.VolumeTransportados_Especie;
                textVolumeTransportadosMarca.Text = notafiscalsaida.VolumeTransportados_Marca;
                numericVolumeTransportadosNumero.Value = notafiscalsaida.VolumeTransportados_Numero;
                numericVolumeTransportadosPesoBruto.Value = (decimal)notafiscalsaida.VolumeTransportados_PesoBruto;
                numericVolumeTransportadosPesoLiquido.Value = (decimal)notafiscalsaida.VolumeTransportados_PesoLiquido;
                comboRegimeTributario.SelectedValue = notafiscalsaida.RegimeTributario;
                richInformacoesAdicionaisInteresseFisco.Text = Funcao.NuloParaString(notafiscalsaida.InformacoesAdicionaisInteresseFisco);
                richInformacoesComplementaresInteresseContribuinte.Text = Funcao.NuloParaString(notafiscalsaida.InformacoesComplementaresInteresseContribuinte_Obsersacao);
                if (!Funcao.Nulo(notafiscalsaida.InformacoesComplementaresInteresseContribuinte_UFId)) comboInformacoesComplementaresUF.SelectedValue = notafiscalsaida.InformacoesComplementaresInteresseContribuinte_UFId;
                textInformacoesComplementaresLocal.Text = Funcao.NuloParaString(notafiscalsaida.InformacoesComplementaresInteresseContribuinte_Local);
                textInfoNFeChaveNFe.Text = Funcao.NuloParaString(notafiscalsaida.CodigoChaveAcesso);
                textInfoNFeProtocolo.Text = Funcao.NuloParaString(notafiscalsaida.Protocolo);
                comboInfoNFeIndicaPresenca.SelectedValue = notafiscalsaida.IndicaPresenca;
                comboInfoNFeTipoEmissao.SelectedValue = notafiscalsaida.TipoEmissao;
                textEmailDestinoXML.Text = Funcao.NuloParaString(notafiscalsaida.EmailDestinoXML);

                if (!Funcao.Nulo(notafiscalsaida.TabelaOrigemVendaId)) comboInfoNFeOrigem.SelectedValue = notafiscalsaida.TabelaOrigemVendaId;

                Grid_DataGridView.DataGridView_LinhaLimpar(gridMercadoria);

                using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;
                    IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels;

                    notaFiscalSaidaMercadoriaViewModels = await notaFiscalSaidaMercadoriaController.PesquisarId(notafiscalsaida.Id);

                    foreach (NotaFiscalSaidaMercadoriaViewModel mercadoria in notaFiscalSaidaMercadoriaViewModels)
                    {
                        if ((mercadoria.TabelaCFOPId == null) || (mercadoria.TabelaCFOPId == Guid.Empty))
                        {
                            if (Declaracoes.dados_Empresa_EstadoId == dadolocal_Cliente_EstadoId )
                            { cfop = cfop_5102;  }
                            else
                            { cfop = cfop_6102; }
                        }
                        else
                        {
                            cfop = (Guid)mercadoria.TabelaCFOPId;
                        }

                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridMercadoria,
                                                                              new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridMercadoria_Id,
                                                                                                                                             Valor = mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_CodigoSistema,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_RefSistema,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Mercadoria,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Descricao,
                                                                                                                                             Valor = mercadoria.Descricao},
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Quantidade,
                                                                                                                                             Valor = mercadoria.Quantidade },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Preco,
                                                                                                                                             Valor = mercadoria.PrecoUnitario },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Total,
                                                                                                                                             Valor = mercadoria.PrecoTotal },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_CFOP,
                                                                                                                                             Valor = cfop },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_ICMS,
                                                                                                                                             Valor = mercadoria.PercentualICMS },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_IPI,
                                                                                                                                             Valor = mercadoria.PercentualIPI },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Frete,
                                                                                                                                             Valor = mercadoria.ValorFrete },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoBruto,
                                                                                                                                             Valor = mercadoria.Mercadoria.Estoque_PesoBruto },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoLiquido,
                                                                                                                                             Valor = mercadoria.Mercadoria.Estoque_PesoLiquido }}).Index;

                        if (mercadoria.TabelaNCMId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_NCM].Value = mercadoria.TabelaNCMId;
                        if (mercadoria.TabelaCST_CSOSNId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_CST_CSOSN].Value = mercadoria.TabelaCST_CSOSNId;
                        if (mercadoria.TabelaCST_CSOSNId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_CFOP].Value = mercadoria.TabelaCST_CSOSNId;
                        if (mercadoria.UnidadeMedidaId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_UnidadeMedida].Value = mercadoria.UnidadeMedidaId;
                        if ((cfop != null) && (cfop != Guid.Empty))
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_CFOP].Value = cfop;

                        notaFiscalMercadoriaDetalhamentoImposto = new NotaFiscalMercadoriaDetalhamentoImposto();
                        notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo = mercadoria.ValorBaseCalculo;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaICMS = mercadoria.AliquotaICMS;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorICMS = mercadoria.ValorICMS;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaReducao = mercadoria.AliquotaReducao;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria = mercadoria.ValorBaseSubstituicaoTributaria;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria = mercadoria.ValorSubstituicaoTributaria;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorAdicional = mercadoria.ValorAdicional;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaAdicional = mercadoria.AliquotaAdicional;
                        notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS = mercadoria.TabelaCST_IPIId;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorBaseIPI = mercadoria.ValorBaseIPI;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaIPI = mercadoria.AliquotaIPI;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorIPI = mercadoria.ValorIPI;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS = mercadoria.AliquotaPIS;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS = mercadoria.AliquotaCOFINS;
                        notaFiscalMercadoriaDetalhamentoImposto.BaseCalculoFCP = mercadoria.BaseCalculoFCP;
                        notaFiscalMercadoriaDetalhamentoImposto.AliquotaFCP = mercadoria.AliquotaFCP;
                        notaFiscalMercadoriaDetalhamentoImposto.ValorFCP = mercadoria.ValorFCP;
                        notaFiscalMercadoriaDetalhamentoImposto.NumeroPedidoCompra = mercadoria.NumeroPedidoCompra;
                        notaFiscalMercadoriaDetalhamentoImposto.ItemPedidoCompra = mercadoria.ItemPedidoCompra;
                        notaFiscalMercadoriaDetalhamentoImposto.CSTPIS = mercadoria.TabelaCST_PIS_COFINS_PISId;
                        notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS = mercadoria.TabelaCST_PIS_COFINS_PISCOFINSId;
                        gridMercadoria.Rows[linha].Cells[gridMercadoria_Impostos].Value = notaFiscalMercadoriaDetalhamentoImposto;
                    }
                }

                Grid_DataGridView.DataGridView_LinhaLimpar(gridObservacao);

                using (NotaFiscalSaidaObservacaoController notaFiscalSaidaObservacaoController = new NotaFiscalSaidaObservacaoController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<NotaFiscalSaidaObservacaoViewModel> notaFiscalSaidaObservacaoViewModels;

                    notaFiscalSaidaObservacaoViewModels = await notaFiscalSaidaObservacaoController.PesquisarId(notafiscalsaida.Id);

                    foreach (NotaFiscalSaidaObservacaoViewModel observacao in notaFiscalSaidaObservacaoViewModels)
                    {
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridObservacao,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridObservacao_Id,
                                                                                                                                              Valor = observacao.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridObservacao_Codigo,
                                                                                                                                              Valor = observacao.ObservacaoId },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridObservacao_Descricao,
                                                                                                                                              Valor = observacao.Descricao }}).Index;
                    }
                }

                Grid_DataGridView.DataGridView_LinhaLimpar(gridCobrancaNota);

                using (NotaFiscalSaidaPagamentoController notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels;

                    notaFiscalSaidaPagamentoViewModels = await notaFiscalSaidaPagamentoController.PesquisarId(notafiscalsaida.Id);

                    foreach (NotaFiscalSaidaPagamentoViewModel pagamento in notaFiscalSaidaPagamentoViewModels)
                    {
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridCobrancaNota,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Id,
                                                                                                                                              Valor = pagamento.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_TipoPagamento,
                                                                                                                                              Valor = pagamento.FormaPagamentoId },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Vencimento,
                                                                                                                                              Valor = pagamento.DataVecimento },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Valor,
                                                                                                                                              Valor = pagamento.Valor }}).Index;
                    }
                }

                Grid_DataGridView.DataGridView_LinhaLimpar(gridInfoNFe);

                using (NotaFiscalSaidaReferenciaController notaFiscalSaidaReferenciaController = new NotaFiscalSaidaReferenciaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels;

                    notaFiscalSaidaReferenciaViewModels = await notaFiscalSaidaReferenciaController.PesquisarId(notafiscalsaida.Id);

                    foreach (NotaFiscalSaidaReferenciaViewModel referencia in notaFiscalSaidaReferenciaViewModels)
                    {
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridInfoNFe,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridInfoNFe_Id,
                                                                                                                                              Valor = referencia.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridInfoNFe_NFe_NFCe,
                                                                                                                                              Valor = referencia.NotaFiscal },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridInfoNFe_ChaveNFe_NFCe,
                                                                                                                                              Valor = referencia.CodigoChaveAcesso }}).Index;
                    }
                }

                if (notafiscalsaida.VendaId != null)
                await Assincrono.TaskAsyncAndAwaitAsync(CarregarListaVenda((Guid)notafiscalsaida.VendaId));

                Editar(false);
            }

            CalcularMercadoriaPeso();
            CalcularMercadoriaImpostos();

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
            if (Funcao.NuloData(dateDataEmissao.Value))
            {
                CaixaMensagem.Informacao("Informa uma data de emissão válida");
                return false;
            }
            if (Funcao.NuloData(dateDataSaida.Value))
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
            if (!Combo_ComboBox.Selecionado(comboRegimeTributario))
            {
                CaixaMensagem.Informacao("Selecione o regime tributário");
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
            Excluir();
        }

        async Task Excluir()
        {
            try
            {
                Editar(false);

                if ((notafiscalsaida != null) && (notafiscalsaida.Id != Guid.Empty))
                {
                    if (!CaixaMensagem.Perguntar("Deseja excluir a nota fiscal?")) return;

                    using (NotaFiscalSaidaObservacaoController notaFiscalSaidaObservacaoController = new NotaFiscalSaidaObservacaoController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<NotaFiscalSaidaObservacaoViewModel> notaFiscalSaidaObservacaoViewModels;

                        notaFiscalSaidaObservacaoViewModels = await notaFiscalSaidaObservacaoController.PesquisarId(notafiscalsaida.Id);

                        foreach (NotaFiscalSaidaObservacaoViewModel observacao in notaFiscalSaidaObservacaoViewModels)
                        {
                            await notaFiscalSaidaObservacaoController.Excluir(observacao.Id);
                        }
                    }
                    using (NotaFiscalSaidaPagamentoController notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels;

                        notaFiscalSaidaPagamentoViewModels = await notaFiscalSaidaPagamentoController.PesquisarId(notafiscalsaida.Id);

                        foreach (NotaFiscalSaidaPagamentoViewModel pagamento in notaFiscalSaidaPagamentoViewModels)
                        {
                            await notaFiscalSaidaPagamentoController.Excluir(pagamento.Id);
                        }
                    }
                    using (NotaFiscalSaidaReferenciaController notaFiscalSaidaReferenciaController = new NotaFiscalSaidaReferenciaController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels;

                        notaFiscalSaidaReferenciaViewModels = await notaFiscalSaidaReferenciaController.PesquisarId(notafiscalsaida.Id);

                        foreach (NotaFiscalSaidaReferenciaViewModel referencia in notaFiscalSaidaReferenciaViewModels)
                        {
                            await notaFiscalSaidaReferenciaController.Excluir(referencia.Id);
                        }
                    }
                    using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
                    {
                        IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels;

                        notaFiscalSaidaMercadoriaViewModels = await notaFiscalSaidaMercadoriaController.PesquisarId(notafiscalsaida.Id);

                        foreach (NotaFiscalSaidaMercadoriaViewModel mercadoria in notaFiscalSaidaMercadoriaViewModels)
                        {
                            await notaFiscalSaidaMercadoriaController.Excluir(mercadoria.Id);
                        }
                    }
                    using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                    {
                        await notaFiscalSaidaController.Excluir(notafiscalsaida.Id);
                    }

                    CaixaMensagem.Informacao("Exclusão Efeutada");
                }

                Limpar();

                notafiscalsaida.Id = Guid.Empty;
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {

        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            Editar(true);

            CaixaMensagem.Informacao("Hablitada a edição");
        }
        private void botaoExportarOutrasNFe_Click(object sender, EventArgs e)
        {

        }
        private void botaoImportarXMLNFe_Click(object sender, EventArgs e)
        {

        }
        private void botaoImportarXMLLote_Click(object sender, EventArgs e)
        {
            var ret = Arquivo.CarregarArquivosXML();
            string arquivo = "";

            if (ret != null)
            {
                foreach (var xml in ret)
                {
                    arquivo = xml;

                    var nfe = Zeus.CarregarNFE_XML(ref arquivo);

                    using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                    {
                        //notaFiscalSaidaController.Adicionar
                    }
                }
            }
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
                await CarregarDados();
            }
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalSaidaViewModel> data = null;

                data = await notaFiscalSaidaController.ObterTodos();

                NotaFiscalSaidaViewModel ItemAnterior = null;
                NotaFiscalSaidaViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (NotaFiscalSaidaViewModel Item in data)
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
            else { return NF_Status.Pendente; }
        }
        private async Task<bool> GravarMercadoria(bool mensagemexportada = false, bool validar = true)
        {
            if (validar)
            {
                if (!ValidarDados()) return false;
            }

            if (notafiscalsaida == null)
                notafiscalsaida = new ViewModels.NotaFiscalSaidaViewModel();

            await AdicionarNotaFiscalSaida();

            Editar(false);
            checkValidado.Checked = true;

            if (mensagemexportada) CaixaMensagem.Informacao("Exportada");

            return true;
        }
        private async Task AdicionarNotaFiscalSaida()
        {
            var notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier);

            notafiscalsaida.EmpresaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEmpresa);
            notafiscalsaida.NaturezaOperacaoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboNaturezaOperacao);
            notafiscalsaida.NotaFiscalFinalidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFinalidade);
            //notafiscalsaida.NotaFiscal = labelNumeroNotaFiscalSaida.Text;
            notafiscalsaida.DataEmissao = dateDataEmissao.Value;
            notafiscalsaida.DataSaida = dateDataSaida.Value;
            notafiscalsaida.HoraEmissao = textHora.Text;
            notafiscalsaida.Modelo = textModelo.Text;
            notafiscalsaida.Serie = textInfoNFeNFeSerie.Text;
            notafiscalsaida.SubSerie = textInfoNFeNFeSubSerie.Text;
            notafiscalsaida.Status = Status();
            notafiscalsaida.ClienteId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboRemetente);
            notafiscalsaida.CNPJ_CPF = Texto.SomenteNumero(maskedRemetenteCPFCNPJ.Text);
            notafiscalsaida.IE = textRemetenteIE.Text;
            notafiscalsaida.Cliente_Endereco = new Entidade.Modelos.Endereco();
            notafiscalsaida.Cliente_Endereco.End_CEP = textRemetenteCEP.Text;
            notafiscalsaida.Cliente_Endereco.End_Logradouro = textRemetenteEndereco.Text;
            notafiscalsaida.Cliente_Endereco.End_Numero = textRemetenteNumero.Text;
            notafiscalsaida.Cliente_Endereco.End_Bairro = textRemetenteBairro.Text;
            notafiscalsaida.Cliente_Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboRemetenteCidade);
            notafiscalsaida.Cliente_Telefone = textRemetenteFones.Text;
            notafiscalsaida.Cliente_EMail = textLocalEntregaRetiradaEMail.Text;
            notafiscalsaida.ValorFrete = numericValorFrete.Value;
            notafiscalsaida.ValorSeguro = numericValorSeguro.Value;
            notafiscalsaida.OutrasDespesas = numericValorOutrasDespesas.Value;
            notafiscalsaida.ValorDesconto = numericValorDesconto.Value;
            notafiscalsaida.PercentualDesconto = numericPercentualDesconto.Value;
            notafiscalsaida.PercentuaAliquotaSimplesNacional = numericPercentualAliquotaSimplesNacional.Value;
            notafiscalsaida.TransportadoraId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboTransportadora);
            notafiscalsaida.Transportadora_FreteConta = TipoFrete.SemOcorrenciaTransporte;
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
            if (VendaId != Guid.Empty) { notafiscalsaida.VendaId = VendaId; }

            if (notafiscalsaida.Id != Guid.Empty)
            {
                await notaFiscalSaidaController.Atualizar(notafiscalsaida.Id, notafiscalsaida);
            }
            else
            {
                notafiscalsaida.Id = Guid.NewGuid();
                notafiscalsaida.Status = NF_Status.Finalizada;
                notafiscalsaida = (await notaFiscalSaidaController.Adicionar(notafiscalsaida));
            }

            NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;

            foreach (DataGridViewRow row in gridMercadoria.Rows)
            {
                using (var notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    if (row.Cells[gridMercadoria_CodigoSistema].Value != null)
                    {
                        NotaFiscalSaidaMercadoriaViewModel notaFiscalSaidaMercadoriaViewModel = new NotaFiscalSaidaMercadoriaViewModel();
                        if (row.Cells[gridMercadoria_Id].Value != null)
                        { notaFiscalSaidaMercadoriaViewModel.Id = Guid.Parse(row.Cells[gridMercadoria_Id].Value.ToString()); }
                        notaFiscalSaidaMercadoriaViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                        notaFiscalSaidaMercadoriaViewModel.MercadoriaId = Guid.Parse(row.Cells[gridMercadoria_CodigoSistema].Value.ToString());
                        notaFiscalSaidaMercadoriaViewModel.TabelaNCMId = (Guid)row.Cells[gridMercadoria_NCM].Value;
                        notaFiscalSaidaMercadoriaViewModel.TabelaCST_CSOSNId = (Guid)row.Cells[gridMercadoria_CST_CSOSN].Value;
                        notaFiscalSaidaMercadoriaViewModel.TabelaCFOPId = (Guid)row.Cells[gridMercadoria_CFOP].Value;
                        if (row.Cells[gridMercadoria_UnidadeMedida].Value != null)
                        notaFiscalSaidaMercadoriaViewModel.UnidadeMedidaId = (Guid)row.Cells[gridMercadoria_UnidadeMedida].Value;
                        notaFiscalSaidaMercadoriaViewModel.Descricao = row.Cells[gridMercadoria_Descricao].Value.ToString();
                        notaFiscalSaidaMercadoriaViewModel.Quantidade = Funcao.NuloParaValorD(row.Cells[gridMercadoria_Quantidade].Value);
                        notaFiscalSaidaMercadoriaViewModel.PrecoUnitario = Funcao.NuloParaValorD(row.Cells[gridMercadoria_Preco].Value);
                        notaFiscalSaidaMercadoriaViewModel.PrecoTotal = Funcao.NuloParaValorD(row.Cells[gridMercadoria_Total].Value);
                        notaFiscalSaidaMercadoriaViewModel.PercentualICMS = Funcao.NuloParaValorD(row.Cells[gridMercadoria_ICMS].Value);
                        notaFiscalSaidaMercadoriaViewModel.PercentualIPI = Funcao.NuloParaValorD(row.Cells[gridMercadoria_IPI].Value);
                        notaFiscalSaidaMercadoriaViewModel.ValorFrete = Funcao.NuloParaValorD(row.Cells[gridMercadoria_Frete].Value);

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
                            notaFiscalSaidaMercadoriaViewModel.TabelaCST_PIS_COFINS_PISId = notaFiscalMercadoriaDetalhamentoImposto.CSTPIS;
                            notaFiscalSaidaMercadoriaViewModel.TabelaCST_PIS_COFINS_PISCOFINSId = notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS;
                        }

                        if (notaFiscalSaidaMercadoriaViewModel.Id == Guid.Empty)
                        { await notaFiscalSaidaMercadoriaController.Adicionar(notaFiscalSaidaMercadoriaViewModel); }
                        else
                        { await notaFiscalSaidaMercadoriaController.Atualizar(notaFiscalSaidaMercadoriaViewModel.Id, notaFiscalSaidaMercadoriaViewModel); }
                    }

                    foreach (Guid Id in notaFiscalSaidaMercadoriaExcluir)
                    {
                        await notaFiscalSaidaMercadoriaController.Excluir(Id);
                    }
                }
            }

            foreach (DataGridViewRow row in gridObservacao.Rows)
            {
                using (NotaFiscalSaidaObservacaoController notaFiscalSaidaObservacaoController = new NotaFiscalSaidaObservacaoController(this.MeuDbContext(), this._notifier))
                {
                    if (row.Cells[gridObservacao_Codigo].Value != null)
                    {
                        NotaFiscalSaidaObservacaoViewModel notaFiscalSaidaObservacaoViewModel = new NotaFiscalSaidaObservacaoViewModel();

                        if (row.Cells[gridObservacao_Id].Value != null)
                        { notaFiscalSaidaObservacaoViewModel.Id = Guid.Parse(row.Cells[gridObservacao_Id].Value.ToString()); }

                        notaFiscalSaidaObservacaoViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                        notaFiscalSaidaObservacaoViewModel.Descricao = row.Cells[gridObservacao_Descricao].Value.ToString();
                        if (row.Cells[gridObservacao_Codigo].Value != null) notaFiscalSaidaObservacaoViewModel.ObservacaoId = Guid.Parse(row.Cells[gridObservacao_Codigo].Value.ToString());

                        if (notaFiscalSaidaObservacaoViewModel.Id == Guid.Empty)
                        { await notaFiscalSaidaObservacaoController.Adicionar(notaFiscalSaidaObservacaoViewModel); }
                        else
                        { await notaFiscalSaidaObservacaoController.Atualizar(notaFiscalSaidaObservacaoViewModel.Id, notaFiscalSaidaObservacaoViewModel); }

                        foreach (Guid Id in notaFiscalSaidaObservacaoExcluir)
                        {
                            await notaFiscalSaidaObservacaoController.Excluir(Id);
                        }
                    }
                }
            }

            foreach (DataGridViewRow row in gridCobrancaNota.Rows)
            {
                using (NotaFiscalSaidaPagamentoController notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier))
                {
                    if (row.Cells[gridCobrancaNota_TipoPagamento].Value != null)
                    {
                        NotaFiscalSaidaPagamentoViewModel notaFiscalSaidaPagamentoViewModel = new NotaFiscalSaidaPagamentoViewModel();

                        notaFiscalSaidaPagamentoViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;
                        notaFiscalSaidaPagamentoViewModel.DataVecimento = Convert.ToDateTime(row.Cells[gridCobrancaNota_Vencimento].Value);
                        notaFiscalSaidaPagamentoViewModel.Valor = Convert.ToDecimal(row.Cells[gridCobrancaNota_Valor].Value);
                        notaFiscalSaidaPagamentoViewModel.FormaPagamentoId = (Guid)row.Cells[gridCobrancaNota_TipoPagamento].Value;

                        if (notaFiscalSaidaPagamentoViewModel.Id == Guid.Empty)
                            await notaFiscalSaidaPagamentoController.Adicionar(notaFiscalSaidaPagamentoViewModel);
                        else
                            await notaFiscalSaidaPagamentoController.Atualizar(notaFiscalSaidaPagamentoViewModel.Id, notaFiscalSaidaPagamentoViewModel);

                        foreach (Guid Id in notaFiscalSaidaPagamentoExcluir)
                        {
                            await notaFiscalSaidaPagamentoController.Excluir(Id);
                        }
                    }
                }
            }

            foreach (DataGridViewRow row in gridInfoNFe.Rows)
            {
                using (NotaFiscalSaidaReferenciaController notaFiscalSaidaReferenciaController = new NotaFiscalSaidaReferenciaController(this.MeuDbContext(), this._notifier))
                {
                    NotaFiscalSaidaReferenciaViewModel notaFiscalSaidaReferenciaViewModel = new NotaFiscalSaidaReferenciaViewModel();

                    if (row.Cells[gridInfoNFe_Id].Value != null)
                        notaFiscalSaidaReferenciaViewModel.Id = Guid.Parse(row.Cells[gridInfoNFe_Id].Value.ToString());
                    notaFiscalSaidaReferenciaViewModel.NotaFiscal = row.Cells[gridInfoNFe_NFe_NFCe].Value.ToString();
                    notaFiscalSaidaReferenciaViewModel.CodigoChaveAcesso = row.Cells[gridInfoNFe_ChaveNFe_NFCe].Value.ToString();
                    notaFiscalSaidaReferenciaViewModel.NotaFiscalSaidaId = notafiscalsaida.Id;

                    if (notaFiscalSaidaReferenciaViewModel.Id == Guid.Empty)
                        await notaFiscalSaidaReferenciaController.Adicionar(notaFiscalSaidaReferenciaViewModel);
                    else
                        await notaFiscalSaidaReferenciaController.Atualizar(notaFiscalSaidaReferenciaViewModel.Id, notaFiscalSaidaReferenciaViewModel);

                    foreach (Guid Id in notaFiscalSaidaReferenciaExcluir)
                    {
                        await notaFiscalSaidaReferenciaController.Excluir(Id);
                    }
                }
            }

            notaFiscalSaidaController.Dispose();
            
            VendaId = Guid.Empty;

            await CarregarDados();

            this.MeuDbContextDispose();
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
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_Mercadoria].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_RefSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridMercadoria_Mercadoria)
                {
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_RefSistema].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_CodigoSistema].Value = Guid.Parse(valor);
                }
                if (Coluna == gridMercadoria_RefSistema)
                {
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_Mercadoria].Value = Guid.Parse(valor);
                    gridMercadoria.Rows[iLinha].Cells[gridMercadoria_CodigoSistema].Value = Guid.Parse(valor);
                }
            }
            catch (Exception)
            {
            }
        }
        private async void gridMercadoria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == gridMercadoria_CodigoSistema) ||
                    (e.ColumnIndex == gridMercadoria_Mercadoria) ||
                    (e.ColumnIndex == gridMercadoria_RefSistema))
                {
                    GridProduto_SelecionarProduto(e.RowIndex, e.ColumnIndex, gridMercadoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    if (mercadoriaImpostoEstado != null)
                        foreach (MercadoriaImpostoEstadoViewModel impostoestado in mercadoriaImpostoEstado)
                        {
                            if (impostoestado.Mercadoria.Id == (Guid)gridMercadoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                                gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_ICMS].Value = impostoestado.PercentualICMS_Destino;
                        }
                    if (gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_CFOP].Value == null)
                    {
                        if ((dadolocal_Cliente_EstadoId == Guid.Empty) || (dadolocal_Cliente_EstadoId == Declaracoes.dados_Empresa_EstadoId))
                        {
                            gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_CFOP].Value = cfop_5102;
                        }
                        else
                        {
                            gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_CFOP].Value = cfop_6102;
                        }
                    }
                    using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
                    {
                        var mercadoria = (await mercadoriaController.PesquisarId(Guid.Parse(gridMercadoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))).FirstOrDefault();

                        if (mercadoria != null)
                        {
                            gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_NCM].Value = mercadoria.Fiscal_TabelaNCMId;
                            gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_CST_CSOSN].Value = mercadoria.Fiscal_TabelaCST_CSOSNId;
                            gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_UnidadeMedida].Value = mercadoria.Estoque_UnidadeMedidaId;
                        }
                    }    

                    if ((gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Descricao].Value == null) &&
                        (gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Mercadoria].Value != null))
                    {
                        gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Descricao].Value = gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Mercadoria].EditedFormattedValue;
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
                    if ((gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value != null) && (gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Descricao].Value != null))
                        form.notaFiscalMercadoriaDetalhamentoImposto = (NotaFiscalMercadoriaDetalhamentoImposto)gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value;
                    form.Produto = gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Descricao].Value.ToString();
                    try { form.ValorTotal = Funcao.NuloParaValorD(gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Total].Value); }
                    catch (Exception) { }
                    form.FormatarAsync();
                    form.ShowDialog(this);
                    gridMercadoria.Rows[e.RowIndex].Cells[gridMercadoria_Impostos].Value = form.notaFiscalMercadoriaDetalhamentoImposto;
                }
            }

            CalcularMercadoriaImpostos();
        }
        private void CalcularMercadoriaPeso()
        {
            numericVolumeTransportadosPesoBruto.Value = Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_Quantidade) *
                                                        Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_PesoBruto);
            numericVolumeTransportadosPesoLiquido.Value = Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_Quantidade) *
                                                          Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_PesoLiquido);
        }
        private void CalcularMercadoriaImpostos()
        {
            labelMercadoriaVolume.Tag = 0;
            labelMercadoriaValorFrete.Tag = 0;
            labelMercadoriaValorSeguro.Tag = 0;
            labelMercadoriaOutrasDespesas.Tag = 0;
            labelMercadoriaValorICMSDesoneracao.Tag = 0;
            labelMercadoriaBaseCalculo.Tag = 0;
            labelMercadoriaValorICMS.Tag = 0;
            labelMercadoriaBaseSubstituicao.Tag = 0;
            labelMercadoriaICMSSubstituicao.Tag = 0;

            labelMercadoriaItens.Tag = gridMercadoria.Rows.Count.ToString();
            labelMercadoriaTotalMercadoria.Tag = Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_Total);
            labelMercadoriaValorIPI.Tag = Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_IPI);
            labelMercadoriaTotalNota.Tag = Grid_DataGridView.DataGridView_CalcularColunaValor(gridMercadoria, gridMercadoria_Total);

            foreach (DataGridViewRow row in gridMercadoria.Rows)
            {
                if (row.Cells[gridMercadoria_Impostos].Value != null)
                {
                    NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;

                    notaFiscalMercadoriaDetalhamentoImposto = (NotaFiscalMercadoriaDetalhamentoImposto)row.Cells[gridMercadoria_Impostos].Value;
                    labelMercadoriaBaseCalculo.Tag = Convert.ToDecimal(labelMercadoriaBaseCalculo.Tag) + notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo;
                    labelMercadoriaValorICMS.Tag = Convert.ToDecimal(labelMercadoriaBaseCalculo.Tag) + notaFiscalMercadoriaDetalhamentoImposto.ValorICMS;
                    labelMercadoriaBaseSubstituicao.Tag = Convert.ToDecimal(labelMercadoriaBaseCalculo.Tag) + notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria;
                    labelMercadoriaICMSSubstituicao.Tag = Convert.ToDecimal(labelMercadoriaICMSSubstituicao.Tag) + notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria;
                }
            }

            labelMercadoriaBaseCalculo.Text = Convert.ToDecimal(labelMercadoriaBaseCalculo.Tag).ToString("0.00");
            labelMercadoriaValorICMS.Text = Convert.ToDecimal(labelMercadoriaValorICMS.Tag).ToString("c");
            labelMercadoriaBaseSubstituicao.Text = Convert.ToDecimal(labelMercadoriaBaseSubstituicao.Tag).ToString("0.00");
            labelMercadoriaICMSSubstituicao.Text = Convert.ToDecimal(labelMercadoriaICMSSubstituicao.Tag).ToString("c");
            labelMercadoriaItens.Text = labelMercadoriaItens.Tag.ToString();
            labelMercadoriaVolume.Text = labelMercadoriaVolume.Tag.ToString();
            labelMercadoriaValorFrete.Text = Convert.ToDecimal(labelMercadoriaValorFrete.Tag).ToString("c");
            labelMercadoriaValorSeguro.Text = Convert.ToDecimal(labelMercadoriaValorSeguro.Tag).ToString("c");
            labelMercadoriaOutrasDespesas.Text = Convert.ToDecimal(labelMercadoriaOutrasDespesas.Tag).ToString("c");
            labelMercadoriaValorICMSDesoneracao.Text = Convert.ToDecimal(labelMercadoriaValorICMSDesoneracao.Tag).ToString("c");

            labelMercadoriaTotalMercadoria.Text = Convert.ToDecimal(labelMercadoriaTotalMercadoria.Tag).ToString("c");
            labelMercadoriaValorIPI.Text = Convert.ToDecimal(labelMercadoriaValorIPI.Tag).ToString("c");
            labelMercadoriaTotalNota.Text = Convert.ToDecimal(labelMercadoriaTotalNota.Tag).ToString("c");
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
            if (!carregando)
            {
                using (PessoaController pessoaController = new PessoaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<PessoaViewModel> ret = await pessoaController.PesquisarId((Guid)comboRemetente.SelectedValue);

                    foreach (PessoaViewModel pessoaViewModel in ret)
                    {
                        dadolocal_Cliente_EstadoId = pessoaViewModel.Endereco.End_Cidade.EstadoId;
                        Texto_MaskedTextBox.FormatarTipoPessoa(pessoaViewModel.TipoPessoa, maskedRemetenteCPFCNPJ);
                        if (!String.IsNullOrEmpty(pessoaViewModel.CNPJ_CPF)) { maskedRemetenteCPFCNPJ.Text = pessoaViewModel.CNPJ_CPF; }
                        textRemetenteEndereco.Text = Funcao.NuloParaString(pessoaViewModel.Endereco.End_Logradouro);
                        textRemetenteNumero.Text = Funcao.NuloParaString(pessoaViewModel.Endereco.End_Numero);
                        textRemetenteBairro.Text = Funcao.NuloParaString(pessoaViewModel.Endereco.End_Bairro);
                        if (!Funcao.Nulo(pessoaViewModel.Endereco.End_Cidade.EstadoId)) comboRemetenteUF.SelectedValue = pessoaViewModel.Endereco.End_Cidade.EstadoId;
                        if (!Funcao.Nulo(pessoaViewModel.Endereco.End_CidadeId)) comboRemetenteCidade.SelectedValue = pessoaViewModel.Endereco.End_CidadeId;
                        textRemetenteCEP.Text = Funcao.NuloParaString(pessoaViewModel.Endereco.End_CEP);
                        textRemetenteIE.Text = Funcao.NuloParaString(pessoaViewModel.InscricaoEstadual);
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
        }
        private void botaoCadastroObservacoes_Click(object sender, EventArgs e)
        {
            CadastroObservacoes();
        }

        async Task CadastroObservacoes()
        {
            using (frmCadastroObservacao form = ServiceProvider().GetRequiredService<frmCadastroObservacao>())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }

            IEnumerable<CodigoDescricaoComboViewModel> observacao;

            using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
            {
                observacao = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Descricao);
            }

            ((DataGridViewComboBoxColumn)gridObservacao.Columns[gridObservacao_Codigo]).DataSource = observacao;
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
                                comboViewModel = (List<NF_ComboViewModel>)await notaFiscalEntradaController.ComboChave(o => o.CodigoChaveAcesso);
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
        private void botaoExportarNFe_Click(object sender, EventArgs e)
        {
            ExportarNFe();
        }
        async Task ExportarNFe()
        {
            await GravarMercadoria(mensagemexportada: true);
        }

        private void botaoTransmitir_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_Transmitir>();
            form.ShowDialog(this);
        }

        private async void botaoClonarNFe_Click(object sender, EventArgs e)
        {
            NotaFiscalSaidaViewModel _notaFiscalSaida;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                _notaFiscalSaida = (await notaFiscalSaidaController.PesquisarCompletoId(notafiscalsaida.Id)).FirstOrDefault();

                _notaFiscalSaida.Id = Guid.NewGuid();
                _notaFiscalSaida.Empresa = null;
                _notaFiscalSaida.NaturezaOperacao = null;
                _notaFiscalSaida.NotaFiscalFinalidade = null;
                _notaFiscalSaida.Cliente = null;
                _notaFiscalSaida.Cliente_Endereco.End_Cidade = null;
                _notaFiscalSaida.Transportadora = null;
                _notaFiscalSaida.Vendedor = null;
                _notaFiscalSaida.Transportadora_CNPJ_CPF = null;
                _notaFiscalSaida.Transportadora_UF = null;
                _notaFiscalSaida.Venda = null;
                _notaFiscalSaida.VendaId = null;

                for (int i = 0; i < _notaFiscalSaida.NotaFiscalSaidaMercadoria.Count; i++)
                {
                    _notaFiscalSaida.NotaFiscalSaidaMercadoria[i].Id = Guid.NewGuid();
                }
                for (int i = 0; i < _notaFiscalSaida.NotaFiscalSaidaObservacao.Count; i++)
                {
                    _notaFiscalSaida.NotaFiscalSaidaObservacao[i].Id = Guid.NewGuid();
                }
                for (int i = 0; i < _notaFiscalSaida.NotaFiscalSaidaReferencia.Count; i++)
                {
                    _notaFiscalSaida.NotaFiscalSaidaReferencia[i].Id = Guid.NewGuid();
                }
                for (int i = 0; i < _notaFiscalSaida.NotaFiscalSaidaPagamento.Count; i++)
                {
                    _notaFiscalSaida.NotaFiscalSaidaPagamento[i].Id = Guid.NewGuid();
                }

                if (!String.IsNullOrEmpty(_notaFiscalSaida.Serie))
                {
                    using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(this.MeuDbContext(), this._notifier))
                    {
                        _notaFiscalSaida.NotaFiscal = await notaFiscalSaidaSerieController.NovoNumeroNotaFiscal(_notaFiscalSaida.Serie);
                    }
                }

                await notaFiscalSaidaController.Adicionar(_notaFiscalSaida);

                notafiscalsaida = (await notaFiscalSaidaController.PesquisarCompletoId(_notaFiscalSaida.Id)).FirstOrDefault();
            }

            await CarregarDados();

            CaixaMensagem.Informacao("Nota Fiscal Clonada");
        }

        private void botaoImprimirEtiquetas_Click(object sender, EventArgs e)
        {

        }

        async Task<bool> CarregarListaVenda(Guid id)
        {
            Grid_DataGridView.DataGridView_LinhaLimpar(gridVenda);

            using (VendaController vendaController = new VendaController(this.MeuDbContext(), this._notifier))
            {
                var vendas = (await vendaController.PesquisarId(id));

                foreach (var venda in vendas)
                {
                    Grid_DataGridView.DataGridView_LinhaAdicionar(gridVenda,
                                                                  new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridVenda_ID,
                                                                                                                                  Valor = venda.Id },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridVenda_Codigo,
                                                                                                                                  Valor = venda.Codigo },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridVenda_DataVenda,
                                                                                                                                  Valor = venda.DataVenda }});
                }
            }

            return true;
        }

        void Editar(bool editar)
        {
            tbcGeral.Enabled = editar;
            botaoExportarNFe.Enabled = editar;
        }

        private void gridVenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridVenda.CurrentRow != null)
            {
                var form = this.ServiceProvider().GetRequiredService<frmVendasInclusao>();
                form.vendaId = (Guid)gridVenda.CurrentRow.Cells[gridVenda_ID].Value;
                form.ShowDialog(this);
            }
        }

        private void botaoCadastrarTransportadora_Click(object sender, EventArgs e)
        {
            CadastrarTransportadora();
        }

        async Task CadastrarTransportadora()
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroTransportadoras>();
            form.ShowDialog(this);

            Thread.Sleep(5000);

            await Assincrono.TaskAsyncAndAwaitAsync(comboTransportadora_Carregar());

            if (form.tranpotadoraId != Guid.Empty)
            { comboTransportadora.SelectedValue = form.tranpotadoraId; }
        }

        private void botaoCadastrarNatureza_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroNaturezaOperacao>();
            form.ShowDialog(this);

            Thread.Sleep(5000);
        }

        private void gridMercadoria_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[gridMercadoria_Id].Value != null)
                notaFiscalSaidaMercadoriaExcluir.Add(Guid.Parse(e.Row.Cells[gridMercadoria_Id].Value.ToString()));
        }

        private void gridObservacao_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[gridObservacao_Id].Value != null)
                notaFiscalSaidaObservacaoExcluir.Add(Guid.Parse(e.Row.Cells[gridObservacao_Id].Value.ToString()));
        }

        private void gridCobrancaNota_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[gridCobrancaNota_Id].Value != null)
                notaFiscalSaidaPagamentoExcluir.Add(Guid.Parse(e.Row.Cells[gridCobrancaNota_Id].Value.ToString()));
        }

        private void gridInfoNFe_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[gridInfoNFe_Id].Value != null)
                notaFiscalSaidaReferenciaExcluir.Add(Guid.Parse(e.Row.Cells[gridInfoNFe_Id].Value.ToString()));
        }

        private void gridAutorizarXML_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void comboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboTransportadora_Tratar();
        }

        async void comboTransportadora_Tratar()
        {
            if ((Combo_ComboBox.Selecionado(comboTransportadora)) && !carregando)
            {
                using(TransportadoraController transportadoraController = new TransportadoraController(this.MeuDbContext(), this._notifier))
                {
                    var transportadora = (await transportadoraController.PesquisarId((Guid)comboTransportadora.SelectedValue)).FirstOrDefault();

                    maskedTransportadoraCPFCNPJ.Text = Texto.NuloString(transportadora.CNPJ_CPF);
                    textTransportadoraPlaca.Text = Texto.NuloString(transportadora.PlacaVeiculo);

                    if ((transportadora.Endereco != null) && (transportadora.Endereco.End_Cidade != null))
                    {
                        comboTransportadoraUF.SelectedValue = transportadora.Endereco.End_Cidade.EstadoId;
                    }
                }
            }
        }

        private void comboNaturezaOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo_ComboBox.Selecionado(comboNaturezaOperacao)) && (!carregando))
            {
                for (int i = 0; i < gridMercadoria.Rows.Count; i++)
                {
                    if (gridMercadoria.Rows[i].Cells[gridMercadoria_Descricao].Value != null)
                    {
                        if (((ComboNaturezaOperacaoViewModel)comboNaturezaOperacao.SelectedItem).TabelaCFOPId != null)
                            gridMercadoria.Rows[i].Cells[gridMercadoria_CFOP].Value = ((ComboNaturezaOperacaoViewModel)comboNaturezaOperacao.SelectedItem).TabelaCFOPId;
                    }
                }
            }
        }
    }
}