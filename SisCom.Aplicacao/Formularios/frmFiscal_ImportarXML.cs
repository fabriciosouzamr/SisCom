using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_ImportarXML : FormMain
    {
        const int grdProduto_Descricao = 0;
        const int grdProduto_Unidade = 1;
        const int grdProduto_Quantidade = 2;
        const int grdProduto_Preco = 3;
        const int grdProduto_Frete = 4;
        const int grdProduto_Total = 5;
        const int grdProduto_CodigoFornecedor = 6;
        const int grdProduto_CodigoSistema = 7;
        const int grdProduto_RefSistema = 8;
        const int grdProduto_DescricaoSistema = 9;
        const int grdProduto_QtdeCaixa = 10;
        const int grdProduto_Grupo = 11;
        const int grdProduto_Status = 12;
        const int grdProduto_VinculoFiscal = 13;

        IEnumerable<UnidadeMedidaConversaoViewModel> unidadeMedidaConversao;

        public frmFiscal_ImportarXML(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            InicializaAsync();
        }
        private async Task InicializaAsync()
        {
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

            //Detalhe de Estoque
            Grid_DataGridView.DataGridView_Formatar(gridProduto);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Descrição");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Unidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Quantidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Preço");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Frete");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Total");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Código Fornecedor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Descrição", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Qtde.por Caixa");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Grupo", Grid_DataGridView.TipoColuna.ComboBox);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Status");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridProduto, "", "Vínculo Fiscal", Grid_DataGridView.TipoColuna.ComboBox);

            using (UnidadeMedidaConversaoController unidadeMedidaConversaoController = new UnidadeMedidaConversaoController(this.MeuDbContext(), this._notifier))
            {
                unidadeMedidaConversao = await unidadeMedidaConversaoController.ObterTodos();
            }
            Combo_ComboBox.Formatar(comboNaturezaOperacao,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new NaturezaOperacaoController(this.MeuDbContext(), this._notifier)).Combo(p => p.Nome));
            Combo_ComboBox.Formatar(comboEmpresa,
                                    "ID", "Unidade",
                                    ComboBoxStyle.DropDownList,
                                    await (new EmpresaController(this.MeuDbContext(), this._notifier)).Combo(p => p.Unidade));
            await CarregarComboFornecedor();

        }
        private async Task CarregarComboFornecedor()
        {
            Combo_ComboBox.Formatar(comboFornecedor,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await(new PessoaController(this.MeuDbContext(), this._notifier)).ComboFornecedor(p => p.Nome));
        }
        private void botaoProcurarXML_Click(object sender, EventArgs e)
        {
            string sXMLArquivo = "";
            var nfeProc = Zeus.CarregarNFE_XML(ref sXMLArquivo);
            decimal volumes = 0;
            decimal valores = 0;

            textLocalXML.Text = sXMLArquivo;

            if (nfeProc.NFe != null)
            {
                textAmbiente.Text = ((AmbienteSistemas)(int)nfeProc.NFe.infNFe.ide.tpAmb).GetDescription();
                textChave.Text = nfeProc.NFe.infNFe.Id.Substring(3);
                textNumero.Text = nfeProc.NFe.infNFe.ide.cNF;
                textNumeroSerie.Text = nfeProc.NFe.infNFe.ide.serie.ToString();
                dateDateEmissao.Value = nfeProc.NFe.infNFe.ide.dhEmi.DateTime;
                if (nfeProc.NFe.infNFe.emit.enderEmit != null) textUF.Text = nfeProc.NFe.infNFe.emit.enderEmit.UF.ToString();
                textCNPJ.Text = nfeProc.NFe.infNFe.emit.CNPJ;
                textInscricaoEstadual.Text = nfeProc.NFe.infNFe.emit.IE;
                Forms.comboFornecedor_SelecionarPorCNPJ_CPF(comboFornecedor, nfeProc.NFe.infNFe.emit.CNPJ);

                Grid_DataGridView.DataGridView_LinhaLimpar(gridProduto);

                nfeProc.NFe.infNFe.det.ForEach(d =>
                {
                    volumes = volumes + d.prod.qCom;
                    valores = valores + d.prod.vProd;

                    Grid_DataGridView.DataGridView_LinhaAdicionar(gridProduto,
                                                                  new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdProduto_Descricao,
                                                                                                                                 Valor = d.prod.xProd },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_Unidade,
                                                                                                                                 Valor = d.prod.uCom },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_Quantidade,
                                                                                                                                 Valor = d.prod.qCom,
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Numero },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_Preco,
                                                                                                                                 Valor = d.prod.vUnCom,
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_Frete,
                                                                                                                                 Valor = 0,
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_Total,
                                                                                                                                 Valor = d.prod.vProd,
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_CodigoFornecedor,
                                                                                                                                 Valor = d.prod.cProd,
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Texto },
                                                                                                  new Grid_DataGridView.Coluna { Indice = grdProduto_QtdeCaixa,
                                                                                                                                 Valor = Math.Round(d.prod.qCom * (decimal)0.016667, 2),
                                                                                                                                 Formato = Grid_DataGridView.FormatoColuna.Texto }});
                });

                if (nfeProc.NFe.infNFe.det != null)
                {
                    labelItens.Text = "Itens: " + nfeProc.NFe.infNFe.det.Count.ToString();
                    labelVolumes.Text = "Volumes: " + volumes.ToString();
                    labelTotalProdutos.Text = "Total Produtos: " + valores.ToString();
                }

                labelTotalNFe.Text = "Total NF-e: " + nfeProc.NFe.infNFe.total.ICMSTot.vNF.ToString();

                if (nfeProc.protNFe != null)
                {
                    textProtocolo.Text = nfeProc.protNFe.infProt.nProt;
                }
            }
        }
        private void botaoImportarDanfe_Click(object sender, EventArgs e)
        {
            using (frmFiscal_NuvemFiscal form = this.ServiceProvider().GetRequiredService<frmFiscal_NuvemFiscal>())
                form.ShowDialog(this);
        }
        private void botaoOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textChave.Text))
            {
                CaixaMensagem.Informacao("Informe a chave de acesso da nota fiscal");
                return;
            }
            if (string.IsNullOrEmpty(textNumero.Text))
            {
                CaixaMensagem.Informacao("Informe o número da nota fiscal");
                return;
            }
            if (Funcao.NuloData(dateDateEmissao.Value))
            {
                CaixaMensagem.Informacao("Informe a data de emissão da nota fiscal");
                return;
            }
            if (string.IsNullOrEmpty(textNumeroSerie.Text))
            {
                CaixaMensagem.Informacao("Informe o número de série da nota fiscal");
                return;
            }
            if (comboNaturezaOperacao.SelectedIndex == -1)
            {
                CaixaMensagem.Informacao("Selecione a natureza de operação");
                return;
            }
            if (comboEmpresa.SelectedIndex == -1)
            {
                CaixaMensagem.Informacao("Selecione a empresa");
                return;
            }
            if (comboFornecedor.SelectedIndex == -1)
            {
                CaixaMensagem.Informacao("Selecione o fornecedor");
                return;
            }
            if (gridProduto.Rows.Count == 0)
            {
                CaixaMensagem.Informacao("É preciso pelo menos um produto na nota fiscal");
                return;
            }

            Gravar();

            CaixaMensagem.Informacao("Nota gravada");
        }

        async Task Gravar()
        {
            NotaFiscalEntradaViewModel notaFiscalEntradaViewModel = new NotaFiscalEntradaViewModel();

            using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
            {
                notaFiscalEntradaViewModel.Id = Guid.NewGuid();

                await notaFiscalEntradaController.Adicionar(notaFiscalEntradaViewModel);
            }

            using (NotaFiscalEntradaMercadoriaController notaFiscalEntradaMercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier))
            {
                foreach(DataRow row in gridProduto.Rows)
                {
                    NotaFiscalEntradaMercadoriaViewModel notaFiscalEntradaMercadoriaViewModel = new NotaFiscalEntradaMercadoriaViewModel();

                    notaFiscalEntradaMercadoriaViewModel.QuantidadeCaixas = Convert.ToInt32(row[grdProduto_Quantidade]);
                    notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria = Convert.ToInt32(row[grdProduto_Quantidade]);
                    notaFiscalEntradaMercadoriaViewModel.PrecoPorCaixas = Convert.ToDecimal(row[grdProduto_Quantidade]);
                    notaFiscalEntradaMercadoriaViewModel.PrecoUnitario = Convert.ToDecimal(row[grdProduto_Preco]);
                    notaFiscalEntradaMercadoriaViewModel.PercentualDesconto = 0;
                    notaFiscalEntradaMercadoriaViewModel.ValorDesconto = 0;
                    notaFiscalEntradaMercadoriaViewModel.PrecoTotal = Convert.ToDecimal(row[grdProduto_Total]);
                    notaFiscalEntradaMercadoriaViewModel.PercentualICMS = 0;
                    notaFiscalEntradaMercadoriaViewModel.PercentualIPI = 0;
                    notaFiscalEntradaMercadoriaViewModel.NotaFiscalEntradaId = notaFiscalEntradaViewModel.Id;
                    notaFiscalEntradaMercadoriaViewModel.MercadoriaId = Guid.Parse(row[grdProduto_CodigoSistema].ToString());

                    await notaFiscalEntradaMercadoriaController.Adicionar(notaFiscalEntradaMercadoriaViewModel);
                }
            }
        }
        private void botaoSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoFornecedor_Click(object sender, EventArgs e)
        {
            using (frmCadastroFornecedores form = this.ServiceProvider().GetRequiredService<frmCadastroFornecedores>())
            {
                form.ShowDialog(this);
                
                if (form.Cadastrado)
                { CarregarComboFornecedor(); }
            }
        }

        private void GridProduto_SelecionarProduto(int iLinha, string valor)
        {
            try
            {
                if (Funcao.NuloParaString(gridProduto.Rows[iLinha].Cells[grdProduto_CodigoFornecedor].Value) != valor)
                {
                    gridProduto.Rows[iLinha].Cells[grdProduto_DescricaoSistema].Value = Guid.Parse(valor);
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridProduto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdProduto_CodigoSistema)
                {
                    GridProduto_SelecionarProduto(e.RowIndex, gridProduto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
