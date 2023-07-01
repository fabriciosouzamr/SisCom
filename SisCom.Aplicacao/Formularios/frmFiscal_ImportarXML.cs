using DFe.Utils;
using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NFe.Classes;
using NFe.Classes.Informacoes.Emitente;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
        const int grdProduto_Item = 14;

        private nfeProc _nfeProc;
        private List<CodigoNomeComboViewModel> _unidadeMedida;

        IEnumerable<UnidadeMedidaConversaoViewModel> unidadeMedidaConversao;
        IEnumerable<TabelaCFOPViewModel> CFOP;
        IEnumerable<TabelaNCMViewModel> NCM;
        IEnumerable<TabelaCST_CSOSNViewModel> CST_CSOSN;

        public frmFiscal_ImportarXML(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializa();
        }

        async Task Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(InicializaAsync());
        }

        public nfeProc nfeProc
        {   get
            {
                return _nfeProc;
            }
            set
            {
                _nfeProc = value;
            }
        }

        private async Task<bool> InicializaAsync()
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
                    produto.Rows.Add(item.Id, Funcao.NuloParaString(item.Nome), Funcao.NuloParaString(item.Codigo), Funcao.NuloParaString(item.CodigoFabricante));
                }
            }
            using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            {
                _unidadeMedida = (List<CodigoNomeComboViewModel>)await unidadeMedidaController.Combo(o => o.Nome);
            }

            Grid_DataGridView.User_Formatar(gridProduto);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Descrição");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, _unidadeMedida, "Nome", "ID", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Quantidade");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Preço");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Frete");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Total");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Código Fornecedor", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "ID", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "ID", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Descrição", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "ID", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Qtde.por Caixa", readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Grupo", Grid_DataGridView.TipoColuna.ComboBox, readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Status");
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Vínculo Fiscal", Grid_DataGridView.TipoColuna.ComboBox, readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridProduto, "", "Item", Grid_DataGridView.TipoColuna.Texto, 0);

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

            CFOP = await(new TabelaCFOPController(this.MeuDbContext(), this._notifier)).ObterTodos();
            NCM = await (new TabelaNCMController(this.MeuDbContext(), this._notifier)).ObterTodos();
            CST_CSOSN = await (new TabelaCST_CSOSNController(this.MeuDbContext(), this._notifier)).ObterTodos();

            comboEmpresa.SelectedValue = Declaracoes.dados_Empresa_Id;

            await CarregarComboFornecedor();

            if (_nfeProc != null)
                Carregar();

            return true;
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
            CarregarXML();
        }

        void CarregarXML()
        {
            string sXMLArquivo = "";

            _nfeProc = Zeus.CarregarNFE_XML(ref sXMLArquivo);

            textLocalXML.Text = sXMLArquivo;

            if (_nfeProc != null)
                Carregar();
        }

        void Carregar()
        { 
            decimal volumes = 0;
            decimal valores = 0;
            Guid unidadeId;

            if (_nfeProc.NFe != null)
            {
                textAmbiente.Text = ((AmbienteSistemas)(int)_nfeProc.NFe.infNFe.ide.tpAmb).GetDescription();
                textChave.Text = Fiscal.Fiscal_ChaveNFe(_nfeProc.NFe);
                textNumero.Text = _nfeProc.NFe.infNFe.ide.cNF;
                textNumeroSerie.Text = _nfeProc.NFe.infNFe.ide.serie.ToString();
                dateDateEmissao.Value = _nfeProc.NFe.infNFe.ide.dhEmi.DateTime;
                if (_nfeProc.NFe.infNFe.emit.enderEmit != null) textUF.Text = _nfeProc.NFe.infNFe.emit.enderEmit.UF.ToString();
                textCNPJ.Text = _nfeProc.NFe.infNFe.emit.CNPJ;
                textInscricaoEstadual.Text = _nfeProc.NFe.infNFe.emit.IE;
                Forms.comboFornecedor_SelecionarPorCNPJ_CPF(comboFornecedor, _nfeProc.NFe.infNFe.emit.CNPJ);

                if (comboFornecedor.SelectedIndex == -1)
                    GravarFornecedor(_nfeProc.NFe.infNFe.emit);

                gridProduto.Rows.Clear();

                _nfeProc.NFe.infNFe.det.ForEach(d =>
                {
                    volumes = volumes + d.prod.qCom;
                    valores = valores + d.prod.vProd;
                    unidadeId = Guid.Empty;

                    foreach (var unidade in _unidadeMedida)
                    {
                        if (unidade.Codigo.ToUpper() == d.prod.uCom.ToUpper())
                        {
                            unidadeId = unidade.Id;
                        }
                    }

                    if (unidadeId == Guid.Empty)
                    {
                        CaixaMensagem.Informacao($"A unidade de medida {d.prod.uCom} não está cadastrada");
                    }

                    Grid_DataGridView.User_LinhaAdicionar(gridProduto,
                                                                  new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdProduto_Descricao,
                                                                                                                                        Valor = d.prod.xProd },
                                                                                                         new Grid_DataGridView.Coluna { Indice = grdProduto_Unidade,
                                                                                                                                        Valor = unidadeId },
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
                                                                                                                                        Valor = d.prod.uCom == "SC" ? d.prod.qCom : Math.Round(d.prod.qCom * (decimal)0.016667, 2),
                                                                                                                                        Formato = Grid_DataGridView.FormatoColuna.Texto },
                                                                                                         new Grid_DataGridView.Coluna { Indice = grdProduto_Item,
                                                                                                                                        Valor = d.nItem } });
                });

                if (_nfeProc.NFe.infNFe.det != null)
                {
                    labelItens.Text = "Itens: " + _nfeProc.NFe.infNFe.det.Count.ToString();
                    labelVolumes.Text = "Volumes: " + volumes.ToString();
                    labelTotalProdutos.Text = "Total Produtos: " + valores.ToString();
                }

                labelTotalNFe.Text = "Total NF-e: " + _nfeProc.NFe.infNFe.total.ICMSTot.vNF.ToString();

                if (_nfeProc.protNFe != null)
                {
                    textProtocolo.Text = _nfeProc.protNFe.infProt.nProt;
                }
            }
        }
        async Task GravarFornecedor(NFe.Classes.Informacoes.Emitente.emit emit)
        {
            if (emit != null)
            {
                using (PessoaController pessoaController = new(this.MeuDbContext(), this._notifier))
                {
                    PessoaViewModel pessoaViewModel;
                    string cnpjCpf = String.Empty;

                    if (!String.IsNullOrEmpty(emit.CNPJ))
                        cnpjCpf = emit.CNPJ;
                    if (!String.IsNullOrEmpty(emit.CPF))
                        cnpjCpf = emit.CPF;

                    pessoaViewModel = (await pessoaController.ObterTodos(predicate: w => w.CNPJ_CPF.Trim() == cnpjCpf.Trim())).FirstOrDefault();

                    if (pessoaViewModel == null)
                    {
                        pessoaViewModel = new()
                        {
                            Fornecedor = true,
                            CNPJ_CPF = cnpjCpf,
                            TipoPessoa = emit.CNPJ == cnpjCpf ? TipoPessoaCliente.Juridica : TipoPessoaCliente.Fisica,
                            RazaoSocial = emit.xNome,
                            Nome = String.IsNullOrEmpty(emit.xFant) ? emit.xNome : emit.xFant,
                            InscricaoEstadual = emit.IE,
                            InscricaoMunicipal = emit.IM,
                            RegimeTributario = (RegimeTributario?)emit.CRT
                        };
                        if (emit.enderEmit != null)
                        {
                            CidadeViewModel cidadeViewModel;
                            using (CidadeController cidadeController = new(this.MeuDbContext(), this._notifier))
                            {
                                cidadeViewModel = (await cidadeController.GetByIbgeCode(emit.enderEmit.cMun.ToString())).FirstOrDefault();
                            }

                            pessoaViewModel.Endereco = new();
                            pessoaViewModel.Endereco.End_Logradouro = emit.enderEmit.xLgr;
                            pessoaViewModel.Endereco.End_Bairro = emit.enderEmit.xBairro;
                            if (cidadeViewModel != null) pessoaViewModel.Endereco.End_CidadeId = cidadeViewModel.Id;
                            pessoaViewModel.Endereco.End_CEP = emit.enderEmit.CEP;
                            pessoaViewModel.Endereco.End_Numero = emit.enderEmit.nro;
                            pessoaViewModel.Endereco.End_Complemento = emit.enderEmit.xCpl;
                        }

                        await pessoaController.Adicionar(pessoaViewModel);
                    }
                    else
                    {
                        pessoaViewModel.Fornecedor = true;
                        await pessoaController.Atualizar(pessoaViewModel.Id, pessoaViewModel);
                    }
                }

                await CarregarComboFornecedor();
                Forms.comboFornecedor_SelecionarPorCNPJ_CPF(comboFornecedor, emit.CNPJ);
            }
        }
        private void botaoImportarDanfe_Click(object sender, EventArgs e)
        {
            using (frmFiscal_NuvemFiscal form = this.ServiceProvider().GetRequiredService<frmFiscal_NuvemFiscal>())
            {
                form.ShowDialog(this);

                if (!String.IsNullOrEmpty(form.sXML))
                {
                    _nfeProc = FuncoesXml.XmlStringParaClasse<nfeProc>(form.sXML);

                    if (_nfeProc != null)
                        Carregar();
                }
            }
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
            for (int i = 0; i < gridProduto.Rows.Count; i++)
            {
                var row = gridProduto.Rows[i];

                if (row.Cells[grdProduto_CodigoSistema].Value == null)
                {
                    CaixaMensagem.Informacao("Selecione o produto interno ref. ao produto " + row.Cells[grdProduto_Descricao].Value.ToString());
                    return;
                }
            }

            Gravar();
        }

        async Task Gravar()
        {
            try
            {
                NotaFiscalEntradaViewModel notaFiscalEntradaViewModel = new NotaFiscalEntradaViewModel();

                using (NotaFiscalEntradaController notaFiscalEntradaController = new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier))
                {
                    if (await notaFiscalEntradaController.PesquisarChaveExiste(textChave.Text))
                    {
                        CaixaMensagem.Informacao("Nota fiscal já cadastrada");
                    }
                    else
                    {
                        notaFiscalEntradaViewModel.Id = Guid.NewGuid();
                        notaFiscalEntradaViewModel.DataEntrada = DateTime.Now;
                        notaFiscalEntradaViewModel.DataEmissao = dateDateEmissao.Value;
                        notaFiscalEntradaViewModel.NotaFiscal = textNumero.Text;
                        notaFiscalEntradaViewModel.Modelo = Funcoes.Enum.NF_Modelo.NotaFiscalEletronica;
                        notaFiscalEntradaViewModel.Serie = textNumeroSerie.Text;
                        notaFiscalEntradaViewModel.FornecedorId = (Guid)comboFornecedor.SelectedValue;
                        notaFiscalEntradaViewModel.NaturezaOperacaoId = (Guid)comboNaturezaOperacao.SelectedValue;
                        notaFiscalEntradaViewModel.EmpresaId = (Guid)comboEmpresa.SelectedValue;
                        notaFiscalEntradaViewModel.TipoFrete = TipoFrete.SemOcorrenciaTransporte;
                        notaFiscalEntradaViewModel.PercentualBaseICMSST = (double)_nfeProc.NFe.infNFe.total.ICMSTot.vBCST;
                        notaFiscalEntradaViewModel.ValorICMSST = _nfeProc.NFe.infNFe.total.ICMSTot.vICMS;
                        notaFiscalEntradaViewModel.ValorSeguro = _nfeProc.NFe.infNFe.total.ICMSTot.vSeg;
                        notaFiscalEntradaViewModel.ValorDesconto = _nfeProc.NFe.infNFe.total.ICMSTot.vDesc;
                        notaFiscalEntradaViewModel.ValorFrete = _nfeProc.NFe.infNFe.total.ICMSTot.vFrete;
                        notaFiscalEntradaViewModel.ValorOutrasDespesas = _nfeProc.NFe.infNFe.total.ICMSTot.vOutro;
                        notaFiscalEntradaViewModel.ValorNota = _nfeProc.NFe.infNFe.total.ICMSTot.vNF;
                        notaFiscalEntradaViewModel.CodigoChaveAcesso = textChave.Text;
                        notaFiscalEntradaViewModel.BaseCalculo = (double)_nfeProc.NFe.infNFe.total.ICMSTot.vBC;
                        notaFiscalEntradaViewModel.ValorICMS = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vICMS);
                        notaFiscalEntradaViewModel.ValorICMSSubstitucao = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vST);
                        notaFiscalEntradaViewModel.ValorICMSDesoneracao = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vICMSDeson);
                        notaFiscalEntradaViewModel.ValorIPI = _nfeProc.NFe.infNFe.total.ICMSTot.vIPI;
                        notaFiscalEntradaViewModel.ValorFCPST = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vFCPST);
                        notaFiscalEntradaViewModel.Volumes = (int)_nfeProc.NFe.infNFe.total.ICMSTot.vIPI;
                        notaFiscalEntradaViewModel.TotalMercadorias = _nfeProc.NFe.infNFe.total.ICMSTot.vProd;
                        notaFiscalEntradaViewModel.TotalNota = _nfeProc.NFe.infNFe.total.ICMSTot.vNF;
                        notaFiscalEntradaViewModel.Importacao_TipoDocumentoImportacao = TipoDocumentoImportacao.DeclaracaoImportacao;
                        notaFiscalEntradaViewModel.InformacaoAdicionais_Finalidade = NF_Finalidade.Normal;
                        notaFiscalEntradaViewModel.ValorFCPST = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vFCPST);
                        notaFiscalEntradaViewModel.Importacao_ValorPIS = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vPIS);
                        notaFiscalEntradaViewModel.Importacao_ValorCofins = Funcao.NuloParaValorD(_nfeProc.NFe.infNFe.total.ICMSTot.vCOFINS);
                        notaFiscalEntradaViewModel.Status = NF_Status.Finalizada;

                        if (_nfeProc != null)
                            notaFiscalEntradaViewModel.xml = _nfeProc.ObterXmlString();

                        await notaFiscalEntradaController.Adicionar(notaFiscalEntradaViewModel);

                        using (NotaFiscalEntradaMercadoriaController notaFiscalEntradaMercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier))
                        {
                            for (int i = 0; i < gridProduto.Rows.Count; i++)
                            {
                                var row = gridProduto.Rows[i];
                                NFe.Classes.Informacoes.Detalhe.det prod = null;

                                foreach (NFe.Classes.Informacoes.Detalhe.det item in _nfeProc.NFe.infNFe.det)
                                {
                                    if (item.nItem == Convert.ToInt16(row.Cells[grdProduto_Item].Value))
                                    {
                                        prod = item;
                                        break;
                                    }
                                }

                                NotaFiscalEntradaMercadoriaViewModel notaFiscalEntradaMercadoriaViewModel = new NotaFiscalEntradaMercadoriaViewModel();
                                notaFiscalEntradaMercadoriaViewModel.NotaFiscalEntradaId = notaFiscalEntradaViewModel.Id;
                                notaFiscalEntradaMercadoriaViewModel.QuantidadeCaixas = Convert.ToInt32(row.Cells[grdProduto_Quantidade].Value);
                                notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria = Convert.ToInt32(row.Cells[grdProduto_Quantidade].Value);
                                notaFiscalEntradaMercadoriaViewModel.PrecoPorCaixas = Convert.ToDecimal(row.Cells[grdProduto_Quantidade].Value);
                                notaFiscalEntradaMercadoriaViewModel.PrecoUnitario = Convert.ToDecimal(row.Cells[grdProduto_Preco].Value);
                                notaFiscalEntradaMercadoriaViewModel.PercentualDesconto = 0;
                                notaFiscalEntradaMercadoriaViewModel.ValorDesconto = Funcao.NuloParaValorD(prod.prod.vDesc);
                                notaFiscalEntradaMercadoriaViewModel.PrecoTotal = Convert.ToDecimal(row.Cells[grdProduto_Total].Value);
                                notaFiscalEntradaMercadoriaViewModel.PercentualICMS = Funcao.NuloParaValorD(Zeus.NFe_Produto_DadosICMS(prod) == null ? 0 : Zeus.NFe_Produto_DadosICMS(prod).vICMS);
                                notaFiscalEntradaMercadoriaViewModel.PercentualIPI = Funcao.NuloParaValorD(Zeus.NFE_Produto_DadosIPI(prod) == null ? 0 : Zeus.NFE_Produto_DadosIPI(prod).vIPI);
                                notaFiscalEntradaMercadoriaViewModel.MercadoriaId = Guid.Parse(row.Cells[grdProduto_CodigoSistema].Value.ToString());
                                notaFiscalEntradaMercadoriaViewModel.UnidadeMedidaId = Guid.Parse(row.Cells[grdProduto_Unidade].Value.ToString());

                                foreach (var item in CFOP)
                                    if (item.Codigo == prod.prod.CFOP.ToString())
                                    {
                                        notaFiscalEntradaMercadoriaViewModel.CFOPId = item.Id;
                                        break;
                                    }
                                foreach (var item in NCM)
                                    if (item.Codigo.Trim() == prod.prod.NCM.Trim())
                                    {
                                        notaFiscalEntradaMercadoriaViewModel.NCMId = item.Id;
                                        break;
                                    }
                                foreach (var item in CST_CSOSN)
                                    if (item.Codigo == Zeus.NFE_Produto_DadosCOFINS(prod).CST.ToString().Replace("cofins", ""))
                                    {
                                        notaFiscalEntradaMercadoriaViewModel.CSTId = item.Id;
                                        break;
                                    }

                                await notaFiscalEntradaMercadoriaController.Adicionar(notaFiscalEntradaMercadoriaViewModel);
                            }
                        }

                        CaixaMensagem.Informacao("Nota gravada");
                    }
                }
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Importar XML - Gravar", ex);
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
        private void GridProduto_SelecionarProduto(int iLinha, int Coluna, string valor)
        {
            try
            {
                if ((Coluna == grdProduto_CodigoSistema) &&
                    (Funcao.NuloParaString(gridProduto.Rows[iLinha].Cells[grdProduto_CodigoFornecedor].Value) != valor))
                {
                    gridProduto.Rows[iLinha].Cells[grdProduto_DescricaoSistema].Value = Guid.Parse(valor);
                    gridProduto.Rows[iLinha].Cells[grdProduto_RefSistema].Value = Guid.Parse(valor);
                }
                if ((Coluna == grdProduto_DescricaoSistema) &&
                    (Funcao.NuloParaString(gridProduto.Rows[iLinha].Cells[grdProduto_DescricaoSistema].Value) != valor))
                {
                    gridProduto.Rows[iLinha].Cells[grdProduto_RefSistema].Value = Guid.Parse(valor);
                    gridProduto.Rows[iLinha].Cells[grdProduto_CodigoSistema].Value = Guid.Parse(valor);
                }
                if ((Coluna == grdProduto_RefSistema) &&
                    (Funcao.NuloParaString(gridProduto.Rows[iLinha].Cells[grdProduto_RefSistema].Value) != valor))
                {
                    gridProduto.Rows[iLinha].Cells[grdProduto_DescricaoSistema].Value = Guid.Parse(valor);
                    gridProduto.Rows[iLinha].Cells[grdProduto_CodigoSistema].Value = Guid.Parse(valor);
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
                if ((e.ColumnIndex == grdProduto_CodigoSistema) || 
                    (e.ColumnIndex == grdProduto_DescricaoSistema) || 
                    (e.ColumnIndex == grdProduto_RefSistema))
                {
                    GridProduto_SelecionarProduto(e.RowIndex, e.ColumnIndex, gridProduto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
