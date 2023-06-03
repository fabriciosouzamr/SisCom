using DFe.Utils;
using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NFe.Classes;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Migrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texto = Funcoes._Classes.Texto;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmComprasInclusao : FormMain
    {
        public Guid notaFiscalEntradaId;

        ViewModels.NotaFiscalEntradaViewModel notaFiscalEntrada = null;
        Declaracoes.eNavegar posicaoNavegacao = Declaracoes.eNavegar.Primeiro;
        bool carregando = false;

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
        const int gridMercadoria_ValorICMS = 13;
        const int gridMercadoria_BaseCalculoICMS = 14;
        const int gridMercadoria_IPI = 15;
        const int gridMercadoria_PesoBruto = 16;
        const int gridMercadoria_PesoLiquido = 17;

        const int gridObservacao_Id = 0;
        const int gridObservacao_Codigo = 1;

        public frmComprasInclusao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
        }
        async Task Inicializa()
        {
            carregando = true;

            //Pesquisar
            Combo_ComboBox.Formatar(comboTipoPagamento, "", "", ComboBoxStyle.DropDownList, null, typeof(NotaFiscalTipoPagamento));
            Combo_ComboBox.Formatar(comboTipoFrete, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoFrete));
            Combo_ComboBox.Formatar(comboFinalidade, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Finalidade));
            Combo_ComboBox.Formatar(comboModelo, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Modelo));

            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
            await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());

            await Navegar(Declaracoes.eNavegar.Ultimo);

            carregando = false;
        }

        private async Task<bool> Inicializar()
        {
            try
            {
                Limpar();

                List<CodigoNomeComboViewModel> unidadeMedida;
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
                    unidadeMedida = (List<CodigoNomeComboViewModel>)await unidadeMedidaController.Combo(o => o.Nome);
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

                //Detalhe de Mercadoria
                Grid_DataGridView.User_Formatar(gridMercadoria, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Id", "Id", Tamanho: 0);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "Id", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "Id", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Mercadoria", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "Id", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Descrição", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "NCM", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaNCM, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "CST/CSOSN", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCST_CSOSN, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "CFOP", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCFOP, "Codigo", "ID", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, unidadeMedida, "Nome", "ID", readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero6, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Preço", "Preço", Grid_DataGridView.TipoColuna.Numero6, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Total", "Total", Grid_DataGridView.TipoColuna.Numero6, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "ICMS", "ICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Valor ICMS", "ValorICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Base de Calc. ICMS", "BaseCalcICMS", Grid_DataGridView.TipoColuna.Numero6, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "IPI", "IPI", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "PesoBruto", "PesoBruto", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);
                Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "PesoLiquido", "PesoLiquido", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);

                //Obsrevação
                List<CodigoDescricaoComboViewModel> observacao;

                using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
                {
                    observacao = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Descricao);
                }

                Grid_DataGridView.User_Formatar(gridObservacao, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.User_ColunaAdicionar(gridObservacao, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.User_ColunaAdicionar(gridObservacao, "Código", "Código", Grid_DataGridView.TipoColuna.ComboBox, 600, 0, dataSource: observacao,
                                                                                                                                          dataSource_Descricao: "Descricao",
                                                                                                                                          dataSource_Valor: "ID",
                                                                                                                                          dropDownWidth: 400,
                                                                                                                                          readOnly: false);

                notaFiscalEntrada = new ViewModels.NotaFiscalEntradaViewModel();
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Nota Fiscal - Inicializar", ex);
            }

            return true;
        }
        private void Limpar()
        {
            Editar(false);

            botaoEditar.Enabled = false;

            dateEntrada.Value = DateTime.Now.Date;
            dateEmissao.Value = DateTime.Now.Date;
            textNotaFiscal.Text = "";
            textSerie.Text = "";
            comboTipoPagamento.SelectedIndex = -1;
            comboModelo.SelectedValue = NF_Modelo.NotaFiscalEletronica;

            comboFornecedor.SelectedIndex = -1;
            labelCNPJ.Text = "";
            labelInscricaoEstadual.Text = "";
            labelCidade.Text = "";
            labelEstado.Text = "";

            comboNaturezaOperacao.SelectedIndex = -1;
            comboTipoFrete.SelectedIndex = -1;
            numericBaseICMSST.Value = 0;
            numericICMSST.Value = 0;

            numericValorSeguro.Value = 0;
            numericDesconto.Value = 0;
            numericValorFrete.Value = 0;
            numericOutrasDespesas.Value = 0;
            numericValorNota.Value = 0;

            textChaveAcesso.Text = "";
            comboEmpresa.SelectedIndex = -1;
            comboPedido.SelectedIndex = -1;
            checkAtualizarPreco.Checked = false;
            checkIgnorarICMSDesonerado.Checked = false;
            labelValidado.Visible = false;

            gridMercadoria.Rows.Clear();

            labelBaseCalculo.Text = "0.00";
            labelValorICMS.Text = "0.00";
            labelICMSSubstituicao.Text = "0.00";
            checkIgnorarICMSDesonerado.Text = "0.00";
            labelItens.Text = "0.00";
            labelVolumes.Text = "0.00";
            labelTotalMercadoria.Text = "0.00";
            labelValorFrete.Text = "0.00";
            labelOutrasDespesas.Text = "0.00";
            labelValorIPI.Text = "0.00";
            labelValorFCPST.Text = "0.00";

            labelTotais.Text = "0";
            labelQuantidade.Text = "0";

            comboImportacaoTipoDocumento.SelectedIndex = -1;
            textImportacaoNumeroDocumento.Text = "";
            textImportacaoNumeroDrawback.Text = "";
            numericImportacaoPIS.Value = 0;
            numericImportacaoCofins.Value = 0;

            textServicoAquisicaoChaveAcesso.Text = "";
            numericServicoAquisicaoValorNota.Value = 0;
            numericServicoAquisicaoICMSDesonaracao.Value = 0;
            textServicoAquisicaoSerie.Text = "";
            textServicoAquisicaoSubSerie.Text = "";
            numericServicoAquisicaoDesconto.Value = 0;
            numericServicoAquisicaoBasePIS.Value = 0;
            numericServicoAquisicaoAliquotaPIS.Value = 0;
            numericServicoAquisicaoValorPIS.Value = 0;
            numericServicoAquisicaoBaseCofins.Value = 0;
            numericServicoAquisicaoAliquotaCofins.Value = 0;
            numericServicoAquisicaoValorCofins.Value = 0;
            numericServicoAquisicaoPISRetFonte.Value = 0;
            numericServicoAquisicaoCofinsRetFonte.Value = 0;
            numericServicoAquisicaoValorISS.Value = 0;

            comboFinalidade.SelectedIndex = -1;
            gridObservacao.Rows.Clear();
        }
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboFornecedor_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboEmpresa_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFinalidade_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboNaturezaOperacao_Carregar());

            return true;
        }
        private async Task<bool> comboFornecedor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFornecedor,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(this.MeuDbContext(), this._notifier)).ComboFornecedor(o => o.Fornecedor));
            }

            return true;
        }
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

        private async Task<bool> CarregarDados()
        {
            int linha = -1;

            if (notaFiscalEntradaId != Guid.Empty)
            {
                using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
                {
                    notaFiscalEntrada = (await notaFiscalEntradaController.PesquisarId(notaFiscalEntradaId)).FirstOrDefault();
                }
            }

            if ((notaFiscalEntrada != null) && (notaFiscalEntrada.Id != Guid.Empty))
            {
                Limpar();

                labelValidado.Visible = true;

                dateEntrada.Value = notaFiscalEntrada.DataEntrada;
                dateEmissao.Value = notaFiscalEntrada.DataEmissao;
                textNotaFiscal.Text = Funcao.NuloParaString(notaFiscalEntrada.NotaFiscal);
                if (!Funcao.Nulo(notaFiscalEntrada.Modelo)) comboModelo.SelectedValue = notaFiscalEntrada.Modelo;
                textSerie.Text = Funcao.NuloParaString(notaFiscalEntrada.Serie);
                if (!Funcao.Nulo(notaFiscalEntrada.TipoPagamento)) comboTipoPagamento.SelectedValue = notaFiscalEntrada.TipoPagamento;
                if (!Funcao.Nulo(notaFiscalEntrada.FornecedorId)) comboFornecedor.SelectedValue = notaFiscalEntrada.FornecedorId;

                if (notaFiscalEntrada.Fornecedor != null)
                {
                    labelCNPJ.Text = notaFiscalEntrada.Fornecedor.CNPJ_CPF;
                    labelInscricaoEstadual.Text = notaFiscalEntrada.Fornecedor.InscricaoEstadual;

                    if ((notaFiscalEntrada.Fornecedor.Endereco != null) && (notaFiscalEntrada.Fornecedor.Endereco.End_Cidade != null))
                    {
                        labelCidade.Text = notaFiscalEntrada.Fornecedor.Endereco.End_Cidade.Nome;
                        if ((notaFiscalEntrada.Fornecedor.Endereco.End_Cidade.Estado != null))
                            labelEstado.Text = notaFiscalEntrada.Fornecedor.Endereco.End_Cidade.Estado.Codigo;
                    }
                }

                if (!Funcao.Nulo(notaFiscalEntrada.NaturezaOperacaoId)) comboNaturezaOperacao.SelectedValue = notaFiscalEntrada.NaturezaOperacaoId;
                comboTipoFrete.SelectedValue = notaFiscalEntrada.TipoFrete;
                numericBaseICMSST.Value = (decimal)notaFiscalEntrada.PercentualBaseICMSST;
                numericICMSST.Value = notaFiscalEntrada.ValorICMSST;
                numericValorSeguro.Value = notaFiscalEntrada.ValorSeguro;
                numericDesconto.Value = notaFiscalEntrada.ValorDesconto;
                numericValorFrete.Value = notaFiscalEntrada.ValorFrete;
                numericOutrasDespesas.Value = notaFiscalEntrada.ValorOutrasDespesas;
                numericValorNota.Value = notaFiscalEntrada.ValorNota;

                textChaveAcesso.Text = notaFiscalEntrada.CodigoChaveAcesso;
                if (!Funcao.Nulo(notaFiscalEntrada.EmpresaId)) comboEmpresa.SelectedValue = notaFiscalEntrada.EmpresaId;

                checkAtualizarPreco.Checked = notaFiscalEntrada.AtualizarPreco;
                checkIgnorarICMSDesonerado.Checked = notaFiscalEntrada.IgnorarICMSDesonerado;

                gridMercadoria.Rows.Clear();

                using (NotaFiscalEntradaMercadoriaController NotaFiscalEntradaMercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    IEnumerable<NotaFiscalEntradaMercadoriaViewModel> NotaFiscalEntradaMercadoriaViewModels;

                    NotaFiscalEntradaMercadoriaViewModels = await NotaFiscalEntradaMercadoriaController.PesquisarId(notaFiscalEntrada.Id);

                    foreach (NotaFiscalEntradaMercadoriaViewModel mercadoria in NotaFiscalEntradaMercadoriaViewModels)
                    {
                        linha = Grid_DataGridView.User_LinhaAdicionar(gridMercadoria,
                                                                              new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridMercadoria_Id,
                                                                                                                                             Valor = mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_CodigoSistema,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_RefSistema,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Mercadoria,
                                                                                                                                             Valor = mercadoria.Mercadoria.Id },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Descricao,
                                                                                                                                             Valor = mercadoria.Mercadoria.Nome},
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Quantidade,
                                                                                                                                             Valor = mercadoria.QuantidadeUnitaria },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Preco,
                                                                                                                                             Valor = mercadoria.PrecoUnitario },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_Total,
                                                                                                                                             Valor = mercadoria.PrecoTotal },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_CFOP,
                                                                                                                                             Valor = mercadoria.CFOPId },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_CST_CSOSN,
                                                                                                                                             Valor = mercadoria.CSTId },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_ICMS,
                                                                                                                                             Valor = mercadoria.PercentualICMS },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_IPI,
                                                                                                                                             Valor = mercadoria.PercentualIPI },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoBruto,
                                                                                                                                             Valor = mercadoria.Mercadoria.Estoque_PesoBruto },
                                                                                                              new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoLiquido,
                                                                                                                                             Valor = mercadoria.Mercadoria.Estoque_PesoLiquido }}).Index;

                        if (mercadoria.NCMId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_NCM].Value = mercadoria.NCMId;
                        if (mercadoria.UnidadeMedidaId != null)
                            gridMercadoria.Rows[linha].Cells[gridMercadoria_UnidadeMedida].Value = mercadoria.UnidadeMedidaId;

                        labelBaseCalculo.Text = notaFiscalEntrada.BaseCalculo.ToString("C");
                        labelValorICMS.Text = notaFiscalEntrada.ValorICMS.ToString("C");
                        labelICMSSubstituicao.Text = notaFiscalEntrada.ValorICMSSubstitucao.ToString("C");
                        labelICMSDesoneracao.Text = notaFiscalEntrada.ValorICMSDesoneracao.ToString("C");
                        labelItens.Text = gridMercadoria.Rows.Count.ToString();
                        labelVolumes.Text = notaFiscalEntrada.Volumes.ToString();
                        labelTotalMercadoria.Text = gridMercadoria.User_CalcularColunaValor(gridMercadoria_Total).ToString("C");
                        labelValorFrete.Text = notaFiscalEntrada.ValorFrete.ToString("C");
                        labelOutrasDespesas.Text = notaFiscalEntrada.ValorOutrasDespesas.ToString("C");
                    }
                }

                gridObservacao.Rows.Clear();

                //using (NotaFiscalEntradaObservacaoController NotaFiscalEntradaObservacaoController = new NotaFiscalEntradaObservacaoController(this.MeuDbContext(), this._notifier))
                //{
                //    IEnumerable<NotaFiscalEntradaObservacaoViewModel> NotaFiscalEntradaObservacaoViewModels;

                //    NotaFiscalEntradaObservacaoViewModels = await NotaFiscalEntradaObservacaoController.PesquisarId(notaFiscalEntrada.Id);

                //    foreach (NotaFiscalEntradaObservacaoViewModel observacao in NotaFiscalEntradaObservacaoViewModels)
                //    {
                //        linha = Grid_DataGridView.User_LinhaAdicionar(gridObservacao,
                //                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridObservacao_Id,
                //                                                                                                                              Valor = observacao.Id },
                //                                                                                               new Grid_DataGridView.Coluna { Indice = gridObservacao_Codigo,
                //                                                                                                                              Valor = observacao.ObservacaoId }}).Index;
                //    }
                //}

                Editar(false);
            }

            ValidarStatus();

            return true;
        }
        void ValidarStatus()
        {
            if (notaFiscalEntrada != null)
            {
                botaoEditar.Enabled = ((notaFiscalEntrada.Status == NF_Status.Pendente) || (notaFiscalEntrada.Status == NF_Status.Finalizada));
                botaoGravar.Enabled = ((notaFiscalEntrada.Status == NF_Status.Pendente) || (notaFiscalEntrada.Status == NF_Status.Finalizada));
                botaoExcluir.Enabled = (notaFiscalEntrada.Status != NF_Status.Cancelado);
            }
            else
            {
                botaoEditar.Enabled = true;
                botaoGravar.Enabled = true;
                botaoExcluir.Enabled = true;
            }
        }

        void Editar(bool editar)
        {
            bool readOnly = !editar;
            #region Edicao
            dateEntrada.Enabled = editar;
            dateEmissao.Enabled = editar;
            textNotaFiscal.ReadOnly = readOnly;
            comboModelo.Enabled = editar;
            textSerie.ReadOnly = readOnly;
            comboTipoPagamento.Enabled = editar;
            comboFornecedor.Enabled = editar;
            botaoFornecedor.Enabled = editar;
            comboNaturezaOperacao.Enabled = editar;
            botaoNaturezaOperacao.Enabled = editar;
            comboTipoFrete.Enabled = editar;
            numericBaseICMSST.ReadOnly = readOnly;
            numericICMSST.ReadOnly = readOnly;
            numericValorSeguro.ReadOnly = readOnly;
            numericDesconto.ReadOnly = readOnly;
            numericValorFrete.ReadOnly = readOnly;
            numericOutrasDespesas.ReadOnly = readOnly;
            numericValorNota.ReadOnly = readOnly;
            textChaveAcesso.ReadOnly = readOnly;
            comboEmpresa.Enabled = editar;
            comboPedido.Enabled = editar;
            checkAtualizarPreco.Enabled = editar;
            checkIgnorarICMSDesonerado.Enabled = editar;
            gridMercadoria.ReadOnly = readOnly;
            comboImportacaoTipoDocumento.Enabled = editar;
            textImportacaoNumeroDocumento.ReadOnly = readOnly;
            textImportacaoNumeroDrawback.ReadOnly = readOnly;
            numericImportacaoPIS.ReadOnly = readOnly;
            numericImportacaoCofins.ReadOnly = readOnly;
            textServicoAquisicaoChaveAcesso.ReadOnly = readOnly;
            numericServicoAquisicaoValorNota.ReadOnly = readOnly;
            numericServicoAquisicaoICMSDesonaracao.ReadOnly = readOnly;
            textServicoAquisicaoSerie.ReadOnly = readOnly;
            textServicoAquisicaoSubSerie.ReadOnly = readOnly;
            numericServicoAquisicaoDesconto.ReadOnly = readOnly;
            numericServicoAquisicaoBasePIS.ReadOnly = readOnly;
            numericServicoAquisicaoAliquotaPIS.ReadOnly = readOnly;
            numericServicoAquisicaoAliquotaCofins.ReadOnly = readOnly;
            numericServicoAquisicaoValorCofins.ReadOnly = readOnly;
            numericServicoAquisicaoPISRetFonte.ReadOnly = readOnly;
            numericServicoAquisicaoCofinsRetFonte.ReadOnly = readOnly;
            numericServicoAquisicaoValorISS.ReadOnly = readOnly;
            comboFinalidade.Enabled = editar;
            gridObservacao.ReadOnly = readOnly;
            #endregion
        }
        private void botaoImportarNFeXML_Click(object sender, System.EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_ImportarXML>();
            form.ShowDialog(this);
        }

        private void botaoNuvemFiscal_Click(object sender, System.EventArgs e)
        {
            string sXML = "";

            using (frmFiscal_NuvemFiscal form = this.ServiceProvider().GetRequiredService<frmFiscal_NuvemFiscal>())
            {
                form.ShowDialog(this);
                sXML = form.sXML;
            }

            if (!String.IsNullOrEmpty(sXML))
            {
                using (frmFiscal_ImportarXML form = this.ServiceProvider().GetRequiredService<frmFiscal_ImportarXML>())
                {
                    form.nfeProc = FuncoesXml.XmlStringParaClasse<nfeProc>(sXML);
                    form.ShowDialog(this);
                }
            }
        }

        private void botaoFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            if (notaFiscalEntrada != null)
                IniciarNavegacao(notaFiscalEntrada.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Anterior);
        }

        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            if (notaFiscalEntrada != null)
                IniciarNavegacao(notaFiscalEntrada.Id == Guid.Empty ? Declaracoes.eNavegar.Primeiro : Declaracoes.eNavegar.Proximo);
        }
        void IniciarNavegacao(Declaracoes.eNavegar posicao)
        {
            posicaoNavegacao = posicao;
            timer1.Stop();
            timer1.Start();
        }
        private async Task Navegar(Declaracoes.eNavegar posicao)
        {
            try
            {
                await Navegar_PegarTodos(notaFiscalEntrada.Id, posicao);
                await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());
            }
            catch (Exception)
            {
            }
        }

        private void botaoEditar_Click(object sender, EventArgs e)
        {
            Editar(true);
        }

        private async void botaoGravar_Click(object sender, EventArgs e)
        {
            if (Funcao.NuloData(dateEntrada.Value))
            {
                CaixaMensagem.Informacao("Informe a data de entrada");
                return;
            }
            if (Funcao.NuloData(dateEmissao.Value))
            {
                CaixaMensagem.Informacao("Informe a data de emissão");
                return;
            }
            if (String.IsNullOrEmpty(textNotaFiscal.Text))
            {
                CaixaMensagem.Informacao("Informe o número da nota fiscal");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboTipoPagamento))
            {
                CaixaMensagem.Informacao("Selecione o tipo de pagamento");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboModelo))
            {
                CaixaMensagem.Informacao("Selecione o modelo");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboFornecedor))
            {
                CaixaMensagem.Informacao("Selecione o fornecedor");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboNaturezaOperacao))
            {
                CaixaMensagem.Informacao("Selecione a natureza de operação");
                return;
            }
            if (!string.IsNullOrEmpty(textChaveAcesso.Text))
            {
                CaixaMensagem.Informacao("Selecione a chave de acesso");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboEmpresa))
            {
                CaixaMensagem.Informacao("Selecione a empresa");
                return;
            }
            if (gridMercadoria.Rows.Count == 0)
            {
                CaixaMensagem.Informacao("Informe os produtos");
                return;
            }

            //private System.Windows.Forms.DataGridView gridMercadoria;
            //private System.Windows.Forms.DataGridView gridPagamento;
            //private System.Windows.Forms.DataGridView gridConferencia;
            //private System.Windows.Forms.DataGridView gridObservacao;

            if (notaFiscalEntrada == null)
                notaFiscalEntrada = new ViewModels.NotaFiscalEntradaViewModel();

            notaFiscalEntrada.EmpresaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEmpresa);
            notaFiscalEntrada.CodigoChaveAcesso = textChaveAcesso.Text;
            notaFiscalEntrada.DataEntrada = dateEntrada.Value;
            notaFiscalEntrada.DataEmissao = dateEmissao.Value;
            notaFiscalEntrada.NotaFiscal = textNotaFiscal.Text;
            notaFiscalEntrada.TipoPagamento = (NotaFiscalTipoPagamento)comboTipoPagamento.SelectedValue;
            notaFiscalEntrada.Modelo = (Funcoes.Enum.NF_Modelo)comboModelo.SelectedValue;
            notaFiscalEntrada.Serie = textSerie.Text;
            notaFiscalEntrada.FornecedorId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboFornecedor);
            notaFiscalEntrada.NaturezaOperacaoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboNaturezaOperacao);
            notaFiscalEntrada.TipoFrete = (TipoFrete)comboTipoFrete.SelectedValue;
            notaFiscalEntrada.PercentualBaseICMSST = (double)numericICMSST.Value;
            notaFiscalEntrada.PercentualBaseICMSST = (double)numericBaseICMSST.Value;
            notaFiscalEntrada.ValorSeguro = numericValorSeguro.Value;
            notaFiscalEntrada.ValorNota = numericValorNota.Value;
            notaFiscalEntrada.ValorOutrasDespesas = numericOutrasDespesas.Value;
            notaFiscalEntrada.ValorFrete = numericValorFrete.Value;
            notaFiscalEntrada.ValorDesconto = numericDesconto.Value;
            notaFiscalEntrada.AtualizarPreco = checkAtualizarPreco.Checked;
            notaFiscalEntrada.IgnorarICMSDesonerado = checkIgnorarICMSDesonerado.Checked;
            if (Combo_ComboBox.Selecionado(comboImportacaoTipoDocumento)) notaFiscalEntrada.Importacao_TipoDocumentoImportacao = (TipoDocumentoImportacao)comboImportacaoTipoDocumento.SelectedValue;
            notaFiscalEntrada.Importacao_NumeroDrawback = textImportacaoNumeroDrawback.Text;
            notaFiscalEntrada.Importacao_NumeroDocumento = textImportacaoNumeroDocumento.Text;
            notaFiscalEntrada.Importacao_ValorCofins = numericImportacaoCofins.Value;
            notaFiscalEntrada.Importacao_ValorPIS = numericImportacaoPIS.Value;
            notaFiscalEntrada.ServicosAquisicao_CodigoChaveAcesso = textServicoAquisicaoChaveAcesso.Text;
            notaFiscalEntrada.ServicosAquisicao_Serie = textServicoAquisicaoSerie.Text;
            notaFiscalEntrada.ServicosAquisicao_SubSerie = textServicoAquisicaoSubSerie.Text;
            notaFiscalEntrada.ServicosAquisicao_PercentualPISRefFonte = (double)numericServicoAquisicaoPISRetFonte.Value;
            notaFiscalEntrada.ServicosAquisicao_PercentualBaseCofins = (double)numericServicoAquisicaoBaseCofins.Value;
            notaFiscalEntrada.ServicosAquisicao_PercentualBasePIS = (double)numericServicoAquisicaoBasePIS.Value;
            notaFiscalEntrada.ServicosAquisicao_ValorISS = numericServicoAquisicaoValorISS.Value;
            notaFiscalEntrada.ServicosAquisicao_AliquotaCofins = (double)numericServicoAquisicaoValorCofins.Value;
            notaFiscalEntrada.ServicosAquisicao_AliquotaCofinsRetFonte = (double)numericServicoAquisicaoCofinsRetFonte.Value;
            notaFiscalEntrada.ServicosAquisicao_AliquotaCofins = (double)numericServicoAquisicaoAliquotaCofins.Value;
            notaFiscalEntrada.ServicosAquisicao_AliquotaPIS = (double)numericServicoAquisicaoAliquotaPIS.Value;
            notaFiscalEntrada.ServicosAquisicao_ValorICMSDesoneracao = numericServicoAquisicaoICMSDesonaracao.Value;
            if (Combo_ComboBox.Selecionado(comboFinalidade)) notaFiscalEntrada.InformacaoAdicionais_Finalidade = (NF_Finalidade)comboFinalidade.SelectedValue;

            using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
            {
                if (notaFiscalEntrada.Id == Guid.Empty)
                {
                    notaFiscalEntrada.Id = Guid.NewGuid();
                    await notaFiscalEntradaController.Adicionar(notaFiscalEntrada);
                }
                else
                    await notaFiscalEntradaController.Atualizar(notaFiscalEntrada.Id, notaFiscalEntrada);
            }

            using (NotaFiscalEntradaMercadoriaController notaFiscalEntradaMercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in gridMercadoria.Rows)
                {
                    if (row.Cells[gridMercadoria_Mercadoria].Value != null)
                    {
                        NotaFiscalEntradaMercadoriaViewModel notaFiscalEntradaMercadoria = new NotaFiscalEntradaMercadoriaViewModel();

                        notaFiscalEntradaMercadoria.NotaFiscalEntradaId = notaFiscalEntradaId;
                        notaFiscalEntradaMercadoria.Id = Texto.ConverterGuid(row.Cells[gridMercadoria_Id].Value);
                        notaFiscalEntradaMercadoria.MercadoriaId = Texto.ConverterGuid(row.Cells[gridMercadoria_CodigoSistema].Value);
                        notaFiscalEntradaMercadoria.CFOPId = Texto.ConverterGuid(row.Cells[gridMercadoria_CFOP].Value);
                        notaFiscalEntradaMercadoria.NCMId = Texto.ConverterGuid(row.Cells[gridMercadoria_NCM].Value);
                        notaFiscalEntradaMercadoria.CSTId = Texto.ConverterGuid(row.Cells[gridMercadoria_CST_CSOSN].Value);
                        notaFiscalEntradaMercadoria.UnidadeMedidaId = Texto.ConverterGuid(row.Cells[gridMercadoria_UnidadeMedida].Value);
                        notaFiscalEntradaMercadoria.QuantidadeCaixas = Texto.ConverterInt(row.Cells[gridMercadoria_Quantidade].Value);
                        notaFiscalEntradaMercadoria.QuantidadeUnitaria = Texto.ConverterInt(row.Cells[gridMercadoria_Quantidade].Value);
                        notaFiscalEntradaMercadoria.PrecoPorCaixas = Texto.ConverterInt(row.Cells[gridMercadoria_Preco].Value);
                        notaFiscalEntradaMercadoria.PrecoUnitario = Texto.ConverterInt(row.Cells[gridMercadoria_Preco].Value);
                        notaFiscalEntradaMercadoria.PrecoTotal = Texto.ConverterInt(row.Cells[gridMercadoria_Total].Value);
                        notaFiscalEntradaMercadoria.PercentualICMS = Texto.ConverterInt(row.Cells[gridMercadoria_ValorICMS].Value);
                        notaFiscalEntradaMercadoria.PercentualIPI = Texto.ConverterInt(row.Cells[gridMercadoria_IPI].Value);

                        if (notaFiscalEntradaMercadoria.Id == Guid.Empty)
                        {
                            notaFiscalEntradaMercadoria.Id = Guid.NewGuid();
                            await notaFiscalEntradaMercadoriaController.Adicionar(notaFiscalEntradaMercadoria);
                            row.Cells[gridMercadoria_Id].Value = notaFiscalEntradaMercadoria.Id;
                        }
                        else
                        { await notaFiscalEntradaMercadoriaController.Atualizar(notaFiscalEntradaMercadoria.Id, notaFiscalEntradaMercadoria); }

                    }
                }

                //foreach (Guid Id in notaFiscalSaidaPagamentoExcluir)
                //{
                //    await notaFiscalSaidaPagamentoController.Excluir(Id);
                //}

                botaoEditar.Enabled = true;
            }
        }

        private async void botaoExcluir_Click(object sender, EventArgs e)
        {
            if (notaFiscalEntradaId == Guid.Empty)
            {
                CaixaMensagem.Informacao("Selecione a nota fiscal de entrada para exclusão");
            }
            else
            {
                if (!CaixaMensagem.Perguntar("Deseja realmente excluir essa nota fiscal de entrada?"))
                    return;

                using (NotaFiscalEntradaFaturaController notaFiscalEntradaFaturaController = new NotaFiscalEntradaFaturaController(this.MeuDbContext(), this._notifier))
                {
                    await notaFiscalEntradaFaturaController.ExcluirTodos(notaFiscalEntradaId);
                }
                using (NotaFiscalEntradaMercadoriaController notaFiscalEntradaMercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier))
                {
                    await notaFiscalEntradaMercadoriaController.ExcluirTodos(notaFiscalEntradaId);
                }
                using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
                {
                    await notaFiscalEntradaController.Excluir(notaFiscalEntradaId);
                }
            }

            Limpar();
        }

        private void botaoImprimir_Click(object sender, EventArgs e)
        {

        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            using (NotaFiscalEntradaController NotaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalEntradaViewModel> data = null;

                data = await NotaFiscalEntradaController.ObterTodos(null, o => Convert.ToInt32(o.NotaFiscal));

                NotaFiscalEntradaViewModel ItemAnterior = null;
                NotaFiscalEntradaViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (NotaFiscalEntradaViewModel Item in data)
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

                if (ItemRetorno != null) { notaFiscalEntrada = ItemRetorno; }
            }
        }
    }
}