using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
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
            Grid_DataGridView.DataGridView_Formatar(grdProduto);
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Descrição");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Unidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Quantidade");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Preço");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Frete");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Total");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Código Fornecedor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Descrição", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "ID");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Qtde.por Caixa");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Grupo", Grid_DataGridView.TipoColuna.ComboBox);
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Status");
            Grid_DataGridView.DataGridView_ColunaAdicionar(grdProduto, "", "Vínculo Fiscal", Grid_DataGridView.TipoColuna.ComboBox);

            using (UnidadeMedidaConversaoController unidadeMedidaConversaoController = new UnidadeMedidaConversaoController(this.MeuDbContext(), this._notifier))
            {
                unidadeMedidaConversao = await unidadeMedidaConversaoController.ObterTodos();
            }
        }
        private void botaoProcurarXML_Click(object sender, EventArgs e)
        {
            var nfeProc = Zeus.CarregarNFE_XML();
            decimal volumes = 0;
            decimal valores = 0;
            
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

                Grid_DataGridView.DataGridView_LinhaLimpar(grdProduto);

                nfeProc.NFe.infNFe.det.ForEach(d =>
                {
                    volumes = volumes + d.prod.qCom;
                    valores = valores + d.prod.vProd;

                    Grid_DataGridView.DataGridView_LinhaAdicionar(grdProduto,
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

        }
        private void botaoOk_Click(object sender, EventArgs e)
        {

        }
        private void botaoSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
