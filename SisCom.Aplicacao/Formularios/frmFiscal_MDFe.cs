using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_MDFe : FormMain
    {
        public frmFiscal_MDFe(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa();
            if (Declaracoes.Aplicacao_AlturaTela < this.Height)
                this.Height = Declaracoes.Aplicacao_AlturaTela;

            pnlCentral.Height = this.Height - pnlCentral.Top - 35;
        }
        async Task Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
            await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());
        }
        #region Combo
        private async Task<bool> comboEmpresa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboIdentificacao_Empresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));
            }

            return true;
        }
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboEmpresa_Carregar());

            return true;
        }
        #endregion

        private async Task<bool> Inicializar()
        {
            //try
            //{
            //    Texto_MaskedTextBox.FormatarTipoPessoa(TipoPessoaCliente.Juridica, maskedRemetenteCPFCNPJ);
            //    Texto_MaskedTextBox.FormatarTipoPessoa(TipoPessoaCliente.Juridica, maskedTransportadoraCPFCNPJ);

            //    Limpar();

            //    List<NomeComboViewModel> unidadeMedida;
            //    List<CodigoComboViewModel> tabelaCFOP;
            //    List<CodigoDescricaoComboViewModel> tabelaNCM;
            //    List<CodigoDescricaoComboViewModel> tabelaCST_CSOSN;

            //    DataTable produto = new DataTable();
            //    produto.Columns.Add("ID", typeof(Guid));
            //    produto.Columns.Add("Descricao", typeof(string));
            //    produto.Columns.Add("Codigo", typeof(string));
            //    produto.Columns.Add("CodigoFabricante", typeof(string));
            //    produto.Columns.Add("PesoBruto", typeof(double));
            //    produto.Columns.Add("PesoLiquido", typeof(double));

            //    using (MercadoriaController mercadoriaController = new MercadoriaController(this.MeuDbContext(), this._notifier))
            //    {
            //        IEnumerable<MercadoriaViewModel> ret = await mercadoriaController.ObterTodos();

            //        foreach (var item in ret)
            //        {
            //            produto.Rows.Add(item.Id, item.Nome, item.Codigo, item.CodigoFabricante, item.Estoque_PesoBruto, item.Estoque_PesoLiquido);
            //        }
            //    }
            //    using (UnidadeMedidaController unidadeMedidaController = new UnidadeMedidaController(this.MeuDbContext(), this._notifier))
            //    {
            //        unidadeMedida = (List<NomeComboViewModel>)await unidadeMedidaController.Combo(o => o.Nome);
            //    }
            //    using (TabelaCFOPController tabelaCFOPController = new TabelaCFOPController(this.MeuDbContext(), this._notifier))
            //    {
            //        tabelaCFOP = (List<CodigoComboViewModel>)await tabelaCFOPController.Combo(entradaSaida: EntradaSaida.Saida, o => o.Codigo);
            //    }
            //    using (TabelaNCMController tabelaNCMController = new TabelaNCMController(this.MeuDbContext(), this._notifier))
            //    {
            //        tabelaNCM = (List<CodigoDescricaoComboViewModel>)await tabelaNCMController.Combo(o => o.Codigo);
            //    }
            //    using (TabelaCST_CSOSNController tabelaCST_CSOSNController = new TabelaCST_CSOSNController(this.MeuDbContext(), this._notifier))
            //    {
            //        tabelaCST_CSOSN = (List<CodigoDescricaoComboViewModel>)await tabelaCST_CSOSNController.Combo(o => o.Codigo, w => w.CRT == Declaracoes.dados_Empresa_RegimeTributario.GetHashCode());
            //    }

            //    foreach (CodigoComboViewModel cfop in tabelaCFOP)
            //    {
            //        switch (cfop.Codigo)
            //        {
            //            case "5102":
            //                cfop_5102 = cfop.Id;
            //                break;
            //            case "6102":
            //                cfop_6102 = cfop.Id;
            //                break;
            //        }
            //    }

            //    //Detalhe de Mercadoria
            //    Grid_DataGridView.User_Formatar(gridMercadoria, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Id", "Id", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Código Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Codigo", "Id", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Ref.Sistema", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "CodigoFabricante", "Id", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Mercadoria", Grid_DataGridView.TipoColuna.ComboBox, 100, 0, produto, "Descricao", "Id", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "Descrição", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "NCM", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaNCM, "Codigo", "ID", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "CST/CSOSN", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCST_CSOSN, "Codigo", "ID", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "", "CFOP", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCFOP, "Codigo", "ID", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Medida", "Medida", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, unidadeMedida, "Nome", "ID", readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Quantidade", "Quantidade", Grid_DataGridView.TipoColuna.Numero, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Preço", "Preço", Grid_DataGridView.TipoColuna.Valor, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Total", "Total", Grid_DataGridView.TipoColuna.Valor, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "ICMS", "ICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Valor ICMS", "ValorICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Base de Calc. ICMS", "BaseCalcICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "IPI", "IPI", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Frete", "Frete", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Grid_DataGridView.TipoColuna.Button, 80);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Excluir", "Excluir", Grid_DataGridView.TipoColuna.Button, 80);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "Impostos", "Impostos", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "PesoBruto", "PesoBruto", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "PesoLiquido", "PesoLiquido", Tamanho: 0, Tipo: Grid_DataGridView.TipoColuna.Valor);
            //    Grid_DataGridView.User_ColunaAdicionar(gridMercadoria, "NotaFiscalSaidaId", "NotaFiscalSaidaId", Tamanho: 0);

            //    //Cobrança da Nota
            //    List<NomeComboViewModel> formaPagamento;

            //    using (FormaPagamentoController formaPagamentoController = new FormaPagamentoController(this.MeuDbContext(), this._notifier))
            //    {
            //        formaPagamento = (List<NomeComboViewModel>)await formaPagamentoController.Combo(o => o.Nome);
            //    }

            //    Grid_DataGridView.User_Formatar(gridCobrancaNota, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            //    Grid_DataGridView.User_ColunaAdicionar(gridCobrancaNota, "ID", "ID", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridCobrancaNota, "Pagamento", "MedidaPagamento", Grid_DataGridView.TipoColuna.ComboBox, 200, 0, formaPagamento, "Nome", "ID", false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridCobrancaNota, "Vencimento", "Vencimento", Grid_DataGridView.TipoColuna.Data, 100, 0, readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridCobrancaNota, "Valor", "Valor", Grid_DataGridView.TipoColuna.Valor, 100, 0, readOnly: false);

            //    //Obsrevação
            //    List<CodigoDescricaoComboViewModel> observacao;

            //    using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
            //    {
            //        observacao = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Descricao);
            //    }

            //    Grid_DataGridView.User_Formatar(gridObservacao, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            //    Grid_DataGridView.User_ColunaAdicionar(gridObservacao, "ID", "ID", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridObservacao, "Código", "Código", Grid_DataGridView.TipoColuna.ComboBox, 600, 0, dataSource: observacao,
            //                                                                                                                                      dataSource_Descricao: "Descricao",
            //                                                                                                                                      dataSource_Valor: "ID",
            //                                                                                                                                      dropDownWidth: 400,
            //                                                                                                                                      readOnly: false);

            //    //NF-e
            //    Grid_DataGridView.User_Formatar(gridInfoNFe, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            //    Grid_DataGridView.User_ColunaAdicionar(gridInfoNFe, "ID", "ID", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridInfoNFe, "NF-e/NFC-e Nº", "NF-e/NFC-e Nº", Tamanho: 100, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
            //                                                                                                                dataSource_Descricao: "NotaFiscal",
            //                                                                                                                dataSource_Valor: "ID",
            //                                                                                                                readOnly: false);
            //    Grid_DataGridView.User_ColunaAdicionar(gridInfoNFe, "Chave NF-e/NFC-e", "Chave NF-e/NFC-e", Tamanho: 500, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
            //                                                                                                                      dataSource_Descricao: "CodigoChaveAcesso",
            //                                                                                                                      dataSource_Valor: "ID",
            //                                                                                                                      readOnly: false);

            //    //Venda
            //    Grid_DataGridView.User_Formatar(gridVenda, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            //    Grid_DataGridView.User_ColunaAdicionar(gridVenda, "ID", "ID", Tamanho: 0);
            //    Grid_DataGridView.User_ColunaAdicionar(gridVenda, "Código", "Código", Tamanho: 65);
            //    Grid_DataGridView.User_ColunaAdicionar(gridVenda, "Data da Venda", "Data da Venda", Tamanho: 140, Tipo: Grid_DataGridView.TipoColuna.Data);

            //    notaFiscalSaida = new ViewModels.NotaFiscalSaidaViewModel();
            //}
            //catch (Exception Ex)
            //{
            //    CaixaMensagem.Informacao(Ex.Message);
            //}

            return true;
        }
        private async Task<bool> CarregarDados()
        {
            int linha = -1;
            Guid cfop;

            //if (VendaId != Guid.Empty)
            //{
            //    using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            //    {
            //        notaFiscalSaida = (await notaFiscalSaidaController.ObterTodos(w => w.VendaId == VendaId)).FirstOrDefault();
            //    }

            //    if (notaFiscalSaida == null)
            //    {
            //        using (VendaController vendaController = new VendaController(this.MeuDbContext(), this._notifier))
            //        {
            //            IEnumerable<VendaViewModel> ret = await vendaController.PesquisarId(VendaId);

            //            foreach (VendaViewModel vendaViewModel in ret)
            //            {
            //                dateDataEmissao.Value = vendaViewModel.DataVenda;
            //                if (!Funcao.Nulo(vendaViewModel.ClienteId))
            //                {
            //                    comboRemetente.SelectedValue = vendaViewModel.ClienteId;
            //                    Texto_MaskedTextBox.FormatarTipoPessoa(vendaViewModel.Cliente.TipoPessoa, maskedRemetenteCPFCNPJ);
            //                    if (!String.IsNullOrEmpty(vendaViewModel.Cliente.CNPJ_CPF)) { maskedRemetenteCPFCNPJ.Text = vendaViewModel.Cliente.CNPJ_CPF; }
            //                    if ((vendaViewModel.Cliente.Endereco.End_Cidade != null))
            //                    {
            //                        dadolocal_Cliente_EstadoId = vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId;
            //                        if (!Funcao.Nulo(vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId))
            //                        {
            //                            comboRemetenteUF.SelectedValue = vendaViewModel.Cliente.Endereco.End_Cidade.EstadoId;
            //                            await Assincrono.TaskAsyncAndAwaitAsync(comboRemetenteUF_Tratar());
            //                        }
            //                        if (!Funcao.Nulo(vendaViewModel.Cliente.Endereco.End_CidadeId)) comboRemetenteCidade.SelectedValue = vendaViewModel.Cliente.Endereco.End_CidadeId;
            //                    }
            //                    textRemetenteEndereco.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Logradouro);
            //                    textRemetenteNumero.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Numero);
            //                    textRemetenteBairro.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_Bairro);
            //                    textRemetenteCEP.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Endereco.End_CEP);
            //                    textRemetenteFones.Text = Funcao.NuloParaString(vendaViewModel.Cliente.Telefone);
            //                    textRemetenteEMail.Text = Funcao.NuloParaString(vendaViewModel.Cliente.EMail);
            //                }
            //                if (!Funcao.Nulo(vendaViewModel.EmpresaId)) comboEmpresa.SelectedValue = vendaViewModel.EmpresaId;
            //                numericValorFrete.Value = vendaViewModel.ValorFrete;
            //                numericValorDesconto.Value = vendaViewModel.ValorDesconto;
            //                if (!Funcao.Nulo(vendaViewModel.TransportadoraId))
            //                {
            //                    Texto_MaskedTextBox.FormatarTipoPessoa((TipoPessoaCliente)vendaViewModel.Transportadora.TipoPessoa, maskedRemetenteCPFCNPJ);
            //                    if (!String.IsNullOrEmpty(vendaViewModel.Cliente.CNPJ_CPF)) { maskedRemetenteCPFCNPJ.Text = vendaViewModel.Cliente.CNPJ_CPF; }
            //                    comboTransportadora.SelectedValue = vendaViewModel.TransportadoraId;
            //                }

            //                if ((!Funcao.Nulo(vendaViewModel.VeiculoPlaca01)) && (!Funcao.Nulo(vendaViewModel.VeiculoPlaca01.NumeroPlaca))) textTransportadoraPlaca.Text = vendaViewModel.VeiculoPlaca01.NumeroPlaca;
            //                if (!Funcao.Nulo(vendaViewModel.TabelaOrigemVendaId)) textLocalEntregaRetiradaEndereco.Text = vendaViewModel.EnderecoEntrega;
            //                comboTransportadoraFreteConta.SelectedValue = TransportadoraFreteConta.ContratacaoFreteContaRemetente_CIF;
            //            }

            //            await CarregarSerie(true);
            //        }

            //        Grid_DataGridView.User_LinhaLimpar(gridMercadoria);
            //        gridMercadoria.Rows.Clear();

            //        using (VendaMercadoriaController vendaMercadoriaController = new VendaMercadoriaController(this.MeuDbContext(), this._notifier))
            //        {
            //            IEnumerable<VendaMercadoriaViewModel> ret = await vendaMercadoriaController.PesquisarVendaId(VendaId);

            //            foreach (VendaMercadoriaViewModel vendaMercadoriaViewModel in ret)
            //            {
            //                if (Declaracoes.dados_Empresa_EstadoId == dadolocal_Cliente_EstadoId)
            //                { cfop = cfop_5102; }
            //                else
            //                { cfop = cfop_6102; }

            //                linha = Grid_DataGridView.User_LinhaAdicionar(gridMercadoria,
            //                                                                      new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridMercadoria_CodigoSistema,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Id },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_RefSistema,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Id },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_Mercadoria,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Id },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_Descricao,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Nome },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_Quantidade,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Quantidade },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_Preco,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Preco },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_Total,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Total },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_UnidadeMedida,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.UnidadeMedidaId },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_CFOP,
            //                                                                                                                                     Valor = cfop },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoBruto,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Estoque_PesoBruto },
            //                                                                                                      new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoLiquido,
            //                                                                                                                                     Valor = vendaMercadoriaViewModel.Mercadoria.Estoque_PesoLiquido }}).Index;
            //            }
            //        }

            //        await GravarNotaFiscalSaida(validar: false, recarregar: true);
            //    }

            //    await Assincrono.TaskAsyncAndAwaitAsync(CarregarListaVenda(VendaId));
            //    Editar(true);
            //}

            //if ((notaFiscalSaida != null) && (notaFiscalSaida.Id != Guid.Empty))
            //{
            //    Limpar();

            //    checkValidado.Checked = true;

            //    if (!Funcao.Nulo(notaFiscalSaida.EmpresaId)) comboEmpresa.SelectedValue = notaFiscalSaida.EmpresaId;
            //    if (!Funcao.Nulo(notaFiscalSaida.NaturezaOperacaoId)) comboNaturezaOperacao.SelectedValue = notaFiscalSaida.NaturezaOperacaoId;
            //    if (!Funcao.Nulo(notaFiscalSaida.NotaFiscalFinalidadeId)) comboFinalidade.SelectedValue = notaFiscalSaida.NotaFiscalFinalidadeId;
            //    textNumeroNotaFiscalSaida.Text = Funcao.NuloParaString(notaFiscalSaida.NotaFiscal);
            //    dateDataEmissao.Value = notaFiscalSaida.DataEmissao;
            //    dateDataSaida.Value = notaFiscalSaida.DataSaida;
            //    textHora.Text = Funcao.NuloParaString(notaFiscalSaida.HoraEmissao);
            //    textModelo.Text = Funcao.NuloParaString(notaFiscalSaida.Modelo);
            //    if (!String.IsNullOrEmpty(notaFiscalSaida.Serie)) textSerie.Text = Funcao.NuloParaString(notaFiscalSaida.Serie);
            //    textInfoNFeNFeSubSerie.Text = Funcao.NuloParaString(notaFiscalSaida.SubSerie);
            //    checkStatusCancelado.Checked = (notaFiscalSaida.Status == NF_Status.Cancelado);
            //    checkStatusFinalizada.Checked = (notaFiscalSaida.Status == NF_Status.Transmitida);
            //    checkStatusDenegada.Checked = (notaFiscalSaida.Status == NF_Status.Denegada);
            //    checkStatusInutilizada.Checked = (notaFiscalSaida.Status == NF_Status.Inutilizada);
            //    if (!Funcao.Nulo(notaFiscalSaida.ClienteId)) comboRemetente.SelectedValue = notaFiscalSaida.ClienteId;
            //    maskedRemetenteCPFCNPJ.Text = notaFiscalSaida.CNPJ_CPF;
            //    textRemetenteIE.Text = notaFiscalSaida.IE;

            //    if (notaFiscalSaida.Cliente_Endereco.End_Cidade != null)
            //    {
            //        notaFiscalSaida.Cliente_Endereco.End_Cidade = notaFiscalSaida.Cliente.Endereco.End_Cidade;
            //        notaFiscalSaida.Cliente_Endereco.End_Bairro = notaFiscalSaida.Cliente.Endereco.End_Bairro;
            //        notaFiscalSaida.Cliente_Endereco.End_CEP = notaFiscalSaida.Cliente.Endereco.End_CEP;
            //        notaFiscalSaida.Cliente_Endereco.End_CidadeId = notaFiscalSaida.Cliente.Endereco.End_CidadeId;
            //        notaFiscalSaida.Cliente_Endereco.End_Complemento = notaFiscalSaida.Cliente.Endereco.End_Complemento;
            //        notaFiscalSaida.Cliente_Endereco.End_Logradouro = notaFiscalSaida.Cliente.Endereco.End_Logradouro;
            //        notaFiscalSaida.Cliente_Endereco.End_Numero = notaFiscalSaida.Cliente.Endereco.End_Numero;
            //        notaFiscalSaida.Cliente_Endereco.End_PontoReferencia = notaFiscalSaida.Cliente.Endereco.End_PontoReferencia;
            //        dadolocal_Cliente_EstadoId = notaFiscalSaida.Cliente.Endereco.End_Cidade.EstadoId;
            //    }
            //    else
            //    {
            //        dadolocal_Cliente_EstadoId = Declaracoes.dados_Empresa_EstadoId;
            //    }

            //    if (!String.IsNullOrEmpty(notaFiscalSaida.Cliente_Endereco.End_Logradouro))
            //    {
            //        if ((notaFiscalSaida.Cliente.Endereco.End_Cidade != null))
            //        {
            //            dadolocal_Cliente_EstadoId = notaFiscalSaida.Cliente.Endereco.End_Cidade.EstadoId;
            //            if (!Funcao.Nulo(notaFiscalSaida.Cliente.Endereco.End_Cidade.EstadoId))
            //            {
            //                comboRemetenteUF.SelectedValue = notaFiscalSaida.Cliente.Endereco.End_Cidade.EstadoId;
            //                await Assincrono.TaskAsyncAndAwaitAsync(comboRemetenteUF_Tratar());
            //            }
            //            if (!Funcao.Nulo(notaFiscalSaida.Cliente.Endereco.End_CidadeId)) comboRemetenteCidade.SelectedValue = notaFiscalSaida.Cliente.Endereco.End_CidadeId;
            //        }
            //        textRemetenteEndereco.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.Endereco.End_Logradouro);
            //        textRemetenteNumero.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.Endereco.End_Numero);
            //        textRemetenteBairro.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.Endereco.End_Bairro);
            //        textRemetenteCEP.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.Endereco.End_CEP);
            //        textRemetenteFones.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.Telefone);
            //        textRemetenteEMail.Text = Funcao.NuloParaString(notaFiscalSaida.Cliente.EMail);
            //    }
            //    else
            //    {
            //        await CarregarDadosClientes();
            //    }
            //    numericValorFrete.Value = notaFiscalSaida.ValorFrete;
            //    numericValorSeguro.Value = notaFiscalSaida.ValorSeguro;
            //    numericValorOutrasDespesas.Value = notaFiscalSaida.OutrasDespesas;
            //    numericPercentualDesconto.Value = notaFiscalSaida.PercentualDesconto;
            //    numericValorDesconto.Value = notaFiscalSaida.ValorDesconto;
            //    numericPercentualAliquotaSimplesNacional.Value = notaFiscalSaida.PercentuaAliquotaSimplesNacional;

            //    if (!Funcao.Nulo(notaFiscalSaida.TransportadoraId)) comboTransportadora.SelectedValue = notaFiscalSaida.TransportadoraId;
            //    comboTransportadoraFreteConta.SelectedValue = TransportadoraFrete(notaFiscalSaida.Transportadora_FreteConta);
            //    maskedTransportadoraCPFCNPJ.Text = notaFiscalSaida.Transportadora_CNPJ_CPF;
            //    textTransportadoraPlaca.Text = notaFiscalSaida.Transportadora_Placa;
            //    if (!Funcao.Nulo(notaFiscalSaida.Transportadora_UFId)) comboTransportadoraUF.SelectedValue = notaFiscalSaida.Transportadora_UFId;
            //    textTransportadoraRNTC.Text = Funcao.NuloParaString(notaFiscalSaida.Transportadora_RNTRC);
            //    numericTransportadoraNumeroCarga.Value = notaFiscalSaida.Transportadora_NumeroCarga;
            //    numericVolumeTransportadosQuantidade.Value = notaFiscalSaida.VolumeTransportados_Quantidade;
            //    if (!String.IsNullOrEmpty(notaFiscalSaida.VolumeTransportados_Especie)) textVolumeTransportadosEspecie.Text = notaFiscalSaida.VolumeTransportados_Especie;
            //    if (!String.IsNullOrEmpty(notaFiscalSaida.VolumeTransportados_Marca)) textVolumeTransportadosMarca.Text = notaFiscalSaida.VolumeTransportados_Marca;
            //    numericVolumeTransportadosNumero.Value = notaFiscalSaida.VolumeTransportados_Numero;
            //    numericVolumeTransportadosPesoBruto.Value = (decimal)notaFiscalSaida.VolumeTransportados_PesoBruto;
            //    numericVolumeTransportadosPesoLiquido.Value = (decimal)notaFiscalSaida.VolumeTransportados_PesoLiquido;
            //    comboRegimeTributario.SelectedValue = notaFiscalSaida.RegimeTributario;
            //    richInformacoesAdicionaisInteresseFisco.Text = Funcao.NuloParaString(notaFiscalSaida.InformacoesAdicionaisInteresseFisco);
            //    richInformacoesComplementaresInteresseContribuinte.Text = Funcao.NuloParaString(notaFiscalSaida.InformacoesComplementaresInteresseContribuinte_Obsersacao);
            //    if (!Funcao.Nulo(notaFiscalSaida.InformacoesComplementaresInteresseContribuinte_UFId)) comboInformacoesComplementaresUF.SelectedValue = notaFiscalSaida.InformacoesComplementaresInteresseContribuinte_UFId;
            //    textInformacoesComplementaresLocal.Text = Funcao.NuloParaString(notaFiscalSaida.InformacoesComplementaresInteresseContribuinte_Local);
            //    textInfoNFeChaveNFe.Text = Funcao.NuloParaString(notaFiscalSaida.CodigoChaveAcesso);
            //    textInfoNFeProtocolo.Text = Funcao.NuloParaString(notaFiscalSaida.Protocolo);
            //    comboInfoNFeIndicaPresenca.SelectedValue = notaFiscalSaida.IndicaPresenca;
            //    comboInfoNFeTipoEmissao.SelectedValue = notaFiscalSaida.TipoEmissao;
            //    textEmailDestinoXML.Text = Funcao.NuloParaString(notaFiscalSaida.EmailDestinoXML);

            //    if (!Funcao.Nulo(notaFiscalSaida.TabelaOrigemVendaId)) comboInfoNFeOrigem.SelectedValue = notaFiscalSaida.TabelaOrigemVendaId;

            //    Grid_DataGridView.User_LinhaLimpar(gridMercadoria);
            //    gridMercadoria.Rows.Clear();

            //    using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
            //    {
            //        NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;
            //        IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoriaViewModels;

            //        notaFiscalSaidaMercadoriaViewModels = await notaFiscalSaidaMercadoriaController.PesquisarId(notaFiscalSaida.Id);

            //        foreach (NotaFiscalSaidaMercadoriaViewModel mercadoria in notaFiscalSaidaMercadoriaViewModels)
            //        {
            //            if ((mercadoria.TabelaCFOPId == null) || (mercadoria.TabelaCFOPId == Guid.Empty))
            //            {
            //                if (Declaracoes.dados_Empresa_EstadoId == dadolocal_Cliente_EstadoId)
            //                { cfop = cfop_5102; }
            //                else
            //                { cfop = cfop_6102; }
            //            }
            //            else
            //            {
            //                cfop = (Guid)mercadoria.TabelaCFOPId;
            //            }

            //            linha = Grid_DataGridView.User_LinhaAdicionar(gridMercadoria,
            //                                                                  new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridMercadoria_Id,
            //                                                                                                                                 Valor = mercadoria.Id },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_CodigoSistema,
            //                                                                                                                                 Valor = mercadoria.Mercadoria.Id },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_RefSistema,
            //                                                                                                                                 Valor = mercadoria.Mercadoria.Id },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Mercadoria,
            //                                                                                                                                 Valor = mercadoria.Mercadoria.Id },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Descricao,
            //                                                                                                                                 Valor = mercadoria.Descricao},
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Quantidade,
            //                                                                                                                                 Valor = mercadoria.Quantidade },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Preco,
            //                                                                                                                                 Valor = mercadoria.PrecoUnitario },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Total,
            //                                                                                                                                 Valor = mercadoria.PrecoTotal },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_CFOP,
            //                                                                                                                                 Valor = cfop },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_CST_CSOSN,
            //                                                                                                                                 Valor = mercadoria.TabelaCST_CSOSNId },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_ICMS,
            //                                                                                                                                 Valor = mercadoria.PercentualICMS },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_IPI,
            //                                                                                                                                 Valor = mercadoria.PercentualIPI },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_Frete,
            //                                                                                                                                 Valor = mercadoria.ValorFrete },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoBruto,
            //                                                                                                                                 Valor = mercadoria.Mercadoria.Estoque_PesoBruto },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_PesoLiquido,
            //                                                                                                                                 Valor = mercadoria.Mercadoria.Estoque_PesoLiquido },
            //                                                                                                  new Grid_DataGridView.Coluna { Indice = gridMercadoria_NotaFiscalSaidaId,
            //                                                                                                                                 Valor = mercadoria.NotaFiscalSaidaId }}).Index;

            //            if (mercadoria.TabelaNCMId != null)
            //                gridMercadoria.Rows[linha].Cells[gridMercadoria_NCM].Value = mercadoria.TabelaNCMId;
            //            if (mercadoria.UnidadeMedidaId != null)
            //                gridMercadoria.Rows[linha].Cells[gridMercadoria_UnidadeMedida].Value = mercadoria.UnidadeMedidaId;
            //            if ((cfop != null) && (cfop != Guid.Empty))
            //                gridMercadoria.Rows[linha].Cells[gridMercadoria_CFOP].Value = cfop;

            //            notaFiscalMercadoriaDetalhamentoImposto = new NotaFiscalMercadoriaDetalhamentoImposto();
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo = mercadoria.ValorBaseCalculo;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaICMS = mercadoria.AliquotaICMS;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorICMS = mercadoria.ValorICMS;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaReducao = mercadoria.AliquotaReducao;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria = mercadoria.ValorBaseSubstituicaoTributaria;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria = mercadoria.ValorSubstituicaoTributaria;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorAdicional = mercadoria.ValorAdicional;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaAdicional = mercadoria.AliquotaAdicional;
            //            notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS = mercadoria.TabelaCST_IPIId;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseIPI = mercadoria.ValorBaseIPI;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaIPI = mercadoria.AliquotaIPI;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorIPI = mercadoria.ValorIPI;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS = mercadoria.AliquotaPIS;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS = mercadoria.AliquotaCOFINS;
            //            notaFiscalMercadoriaDetalhamentoImposto.BaseCalculoFCP = mercadoria.BaseCalculoFCP;
            //            notaFiscalMercadoriaDetalhamentoImposto.AliquotaFCP = mercadoria.AliquotaFCP;
            //            notaFiscalMercadoriaDetalhamentoImposto.ValorFCP = mercadoria.ValorFCP;
            //            notaFiscalMercadoriaDetalhamentoImposto.NumeroPedidoCompra = mercadoria.NumeroPedidoCompra;
            //            notaFiscalMercadoriaDetalhamentoImposto.ItemPedidoCompra = mercadoria.ItemPedidoCompra;
            //            notaFiscalMercadoriaDetalhamentoImposto.CSTPIS = mercadoria.TabelaCST_PIS_COFINS_PISId;
            //            notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS = mercadoria.TabelaCST_PIS_COFINS_PISCOFINSId;
            //            gridMercadoria.Rows[linha].Cells[gridMercadoria_Impostos].Value = notaFiscalMercadoriaDetalhamentoImposto;
            //            gridMercadoria.Rows[linha].Cells[gridMercadoria_BaseCalculoICMS].Value = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo;
            //            gridMercadoria.Rows[linha].Cells[gridMercadoria_ValorICMS].Value = notaFiscalMercadoriaDetalhamentoImposto.ValorICMS;

            //            //if (mercadoria.Mercadoria.)
            //        }
            //    }

            //    Grid_DataGridView.User_LinhaLimpar(gridObservacao);

            //    using (NotaFiscalSaidaObservacaoController notaFiscalSaidaObservacaoController = new NotaFiscalSaidaObservacaoController(this.MeuDbContext(), this._notifier))
            //    {
            //        IEnumerable<NotaFiscalSaidaObservacaoViewModel> notaFiscalSaidaObservacaoViewModels;

            //        notaFiscalSaidaObservacaoViewModels = await notaFiscalSaidaObservacaoController.PesquisarId(notaFiscalSaida.Id);

            //        foreach (NotaFiscalSaidaObservacaoViewModel observacao in notaFiscalSaidaObservacaoViewModels)
            //        {
            //            linha = Grid_DataGridView.User_LinhaAdicionar(gridObservacao,
            //                                                                  new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridObservacao_Id,
            //                                                                                                                                  Valor = observacao.Id },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridObservacao_Codigo,
            //                                                                                                                                  Valor = observacao.ObservacaoId }}).Index;
            //        }
            //    }

            //    Grid_DataGridView.User_LinhaLimpar(gridCobrancaNota);

            //    using (NotaFiscalSaidaPagamentoController notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier))
            //    {
            //        IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamentoViewModels;

            //        notaFiscalSaidaPagamentoViewModels = await notaFiscalSaidaPagamentoController.PesquisarId(notaFiscalSaida.Id);

            //        foreach (NotaFiscalSaidaPagamentoViewModel pagamento in notaFiscalSaidaPagamentoViewModels)
            //        {
            //            linha = Grid_DataGridView.User_LinhaAdicionar(gridCobrancaNota,
            //                                                                  new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Id,
            //                                                                                                                                  Valor = pagamento.Id },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_TipoPagamento,
            //                                                                                                                                  Valor = pagamento.FormaPagamentoId },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Vencimento,
            //                                                                                                                                  Valor = pagamento.DataVecimento },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridCobrancaNota_Valor,
            //                                                                                                                                  Valor = pagamento.Valor }}).Index;
            //        }
            //    }

            //    Grid_DataGridView.User_LinhaLimpar(gridInfoNFe);

            //    using (NotaFiscalSaidaReferenciaController notaFiscalSaidaReferenciaController = new NotaFiscalSaidaReferenciaController(this.MeuDbContext(), this._notifier))
            //    {
            //        IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferenciaViewModels;

            //        notaFiscalSaidaReferenciaViewModels = await notaFiscalSaidaReferenciaController.PesquisarId(notaFiscalSaida.Id);

            //        foreach (NotaFiscalSaidaReferenciaViewModel referencia in notaFiscalSaidaReferenciaViewModels)
            //        {
            //            linha = Grid_DataGridView.User_LinhaAdicionar(gridInfoNFe,
            //                                                                  new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridInfoNFe_Id,
            //                                                                                                                                  Valor = referencia.Id },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridInfoNFe_NFe_NFCe,
            //                                                                                                                                  Valor = referencia.NotaFiscal },
            //                                                                                                   new Grid_DataGridView.Coluna { Indice = gridInfoNFe_ChaveNFe_NFCe,
            //                                                                                                                                  Valor = referencia.CodigoChaveAcesso }}).Index;
            //        }
            //    }

            //    if (notaFiscalSaida.VendaId != null)
            //    {
            //        await Assincrono.TaskAsyncAndAwaitAsync(CarregarListaVenda((Guid)notaFiscalSaida.VendaId));
            //    }
            //    else if (VendaId != Guid.Empty)
            //    {
            //        await Assincrono.TaskAsyncAndAwaitAsync(CarregarListaVenda(VendaId));
            //    }

            //    Editar(false);
            //}

            //CalcularMercadoriaPeso();
            //CalcularMercadoriaImpostos();

            //ValidarStatus();

            return true;
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
