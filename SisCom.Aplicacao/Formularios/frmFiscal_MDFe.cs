using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_MDFe : Form
    {
        ManifestoEletronicoDocumentoViewModel manifestoEletronicoDocumento = new ManifestoEletronicoDocumentoViewModel();

        int AdicionarNotasItem_Notas = 1;
        int AdicionarNotasItem_UltimoTop = 1;

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
            try
            {
                Combo_ComboBox.Formatar(comboIdentificacao_TipoEmissao, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoEmissao));
                Combo_ComboBox.Formatar(comboIdentificacao_TipoTransportador, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoTransportador));
                Combo_ComboBox.Formatar(comboDadosVeiculo_TipoRodado, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoRodado));
                Combo_ComboBox.Formatar(comboDadosVeiculo_TipoCarroceria, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoCarroceria));
                Combo_ComboBox.Formatar(comboDadosVeiculoVeiculoTerceiro_TipoProprietario, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoProprietario));

                comboIdentificacao_TipoEmissao.SelectedValue = MDFe_TipoEmissao.Normal;

                await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
                await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
                await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());

                AdicionarNotasItem_Configurar(pnlAdicionarNotasItem01);

                AdicionarNotasItem_UltimoTop = pnlAdicionarNotasItem01.Top;
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }
        #region Combo
        private async Task<bool> comboSerie_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboIdentificacao_Serie,
                                        "ID", "Serie",
                                        ComboBoxStyle.DropDownList,
                                        await (new ManifestoEletronicoDocumentoSerieController(this.MeuDbContext(), this._notifier)).Combo(w => w.EmpresaId == Declaracoes.dados_Empresa_Id));
            }

            return true;
        }
        private async Task<bool> comboUF_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboIdentificacao_UFCarregamento,"ID", "Codigo",ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
                Combo_ComboBox.Formatar(comboIdentificacao_UFDescarga, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
                Combo_ComboBox.Formatar(comboDadosVeiculo_UF, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
            }

            return true;
        }
        private async Task<bool> comboIdentificacao_CidadeCarregamento_Carregar(Guid EstadoId)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                var id = comboIdentificacao_CidadeCarregamento.SelectedValue;

                Combo_ComboBox.Formatar(comboIdentificacao_CidadeCarregamento,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));

                if (id != null) comboIdentificacao_CidadeCarregamento.SelectedValue = id;
            }

            return true;
        }
        private async Task<bool> comboDadosVeiculo_Placa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboDadosVeiculo_Placa,
                                        "ID", "NumeroPlaca",
                                        ComboBoxStyle.DropDownList,
                                        await (new VeiculoPlacaController(this.MeuDbContext(), this._notifier)).Combo());            
            }

            return true;
        }
        private async Task<bool> comboCidade_Carregar(ComboBox comboAdicionarNotasItem_Cidade)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboAdicionarNotasItem_Cidade,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new CidadeController(this.MeuDbContext(), this._notifier)).ObterTodos(o => o.Nome));
            }

            return true;
        }
        #endregion
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboSerie_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboUF_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboDadosVeiculo_Placa_Carregar());

            return true;
        }

        private async Task<bool> Inicializar()
        {
            try
            {
                dateIdentificacao_Emissao.Value = DateTime.Now;
                textIdentificacao_HoraEmissao.Text = DateTime.Now.ToShortTimeString();

                List<CodigoNomeComboViewModel> estado;

                using (EstadoController observacaoController = new EstadoController(this.MeuDbContext(), this._notifier))
                {
                    estado = (List<CodigoNomeComboViewModel>)await observacaoController.ComboCodigo(o => o.Codigo);
                }

                Grid_DataGridView.User_Formatar(gridPercurso, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.User_ColunaAdicionar(gridPercurso, "U.F.", "U.F.", Tamanho: 100, Tipo: Grid_DataGridView.TipoColuna.ComboBox,
                                                                                                   dataSource: estado,
                                                                                                   dataSource_Descricao: "Codigo",
                                                                                                   dataSource_Valor: "ID",
                                                                                                   dropDownWidth: 400,
                                                                                                   readOnly: false);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

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
        private async void comboIdentificacao_UFCarregamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboIdentificacao_UFCarregamento.SelectedIndex != -1) && (comboIdentificacao_UFCarregamento.Tag != Declaracoes.ComboBox_Carregando) && Combo_ComboBox.Selecionado(comboIdentificacao_UFCarregamento))
            {
                await Assincrono.TaskAsyncAndAwaitAsync(comboIdentificacao_UFCarregamento_Tratar());
            }
        }
        private async Task<bool> comboIdentificacao_UFCarregamento_Tratar()
        {
            await comboIdentificacao_CidadeCarregamento_Carregar(Guid.Parse(comboIdentificacao_UFCarregamento.SelectedValue.ToString()));

            return true;
        }

        private void picPercurso_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string estado = "";

            if ((e.Location.X >= 115) && (e.Location.X <= 260) && (e.Location.Y >= 145) && (e.Location.Y <= 260))
            {
                estado = "AM";
            }
            else
            {
                estado = $"X{e.Location.X}-Y{e.Location.Y}";
            }

            //label37.Text = estado;
        }

        private void botaoAdicionarNotas_Click(object sender, EventArgs e)
        {
            Panel pnlAdicionarNotasItem = new Panel();
            ComboBox comboAdicionarNotasItem_Tipo = new ComboBox();
            ComboBox comboAdicionarNotasItem_NumeroNota = new ComboBox();
            ComboBox comboAdicionarNotasItem_ChaveAcesso = new ComboBox();
            ComboBox comboAdicionarNotasItem_Cidade = new ComboBox();
            Label labelAdicionarNotasItem_UF = new Label();
            NumericUpDown numericAdicionarNotasItem_ValorNota = new NumericUpDown();
            NumericUpDown numericAdicionarNotasItem_PesoNota = new NumericUpDown();

            AdicionarNotasItem_Notas++;

            pnlAdicionarNotasItem.Name = "pnlAdicionarNotasItem" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotas.Controls.Add(pnlAdicionarNotasItem);
            pnlAdicionarNotasItem.Left = 0;
            pnlAdicionarNotasItem.Width = 971;
            pnlAdicionarNotasItem.Height = 33;
            pnlAdicionarNotasItem.Visible = true;
            pnlAdicionarNotasItem.Top = AdicionarNotasItem_UltimoTop + pnlAdicionarNotasItem.Height + 1;
            AdicionarNotasItem_UltimoTop = pnlAdicionarNotasItem.Top;
            pnlAdicionarNotas.Height = pnlAdicionarNotasItem.Top + pnlAdicionarNotasItem.Height + 3;
            groupAdicionarNotas.Height = pnlAdicionarNotas.Height + 13;

            comboAdicionarNotasItem_Tipo.Name = "comboAdicionarNotasItem_Tipo" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(comboAdicionarNotasItem_Tipo);
            comboAdicionarNotasItem_Tipo.Left = 5;
            comboAdicionarNotasItem_Tipo.Top = 5;
            comboAdicionarNotasItem_Tipo.Width = 70;
            comboAdicionarNotasItem_Tipo.SelectedIndexChanged += new System.EventHandler(this.comboAdicionarNotasItem_Tipo_SelectedIndexChanged);
            comboAdicionarNotasItem_Tipo.Visible = true;

            comboAdicionarNotasItem_NumeroNota.Name = "comboAdicionarNotasItem_NumeroNota" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(comboAdicionarNotasItem_NumeroNota);
            comboAdicionarNotasItem_NumeroNota.Left = 81;
            comboAdicionarNotasItem_NumeroNota.Top = 5;
            comboAdicionarNotasItem_NumeroNota.Width = 90;
            comboAdicionarNotasItem_NumeroNota.SelectedIndexChanged += new System.EventHandler(this.comboAdicionarNotasItem_NumeroNota_SelectedIndexChanged);
            comboAdicionarNotasItem_NumeroNota.Visible = true;

            comboAdicionarNotasItem_ChaveAcesso.Name = "comboAdicionarNotasItem_ChaveAcesso" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(comboAdicionarNotasItem_ChaveAcesso);
            comboAdicionarNotasItem_ChaveAcesso.Left = 177;
            comboAdicionarNotasItem_ChaveAcesso.Top = 5;
            comboAdicionarNotasItem_ChaveAcesso.Width = 290;
            comboAdicionarNotasItem_ChaveAcesso.SelectedIndexChanged += new System.EventHandler(this.comboAdicionarNotasItem_ChaveAcesso_SelectedIndexChanged);
            comboAdicionarNotasItem_ChaveAcesso.Visible = true;

            comboAdicionarNotasItem_Cidade.Name = "comboAdicionarNotasItem_Cidade" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(comboAdicionarNotasItem_Cidade);
            comboAdicionarNotasItem_Cidade.Left = 473;
            comboAdicionarNotasItem_Cidade.Top = 5;
            comboAdicionarNotasItem_Cidade.Width = 240;
            comboAdicionarNotasItem_Cidade.SelectedIndexChanged += new System.EventHandler(this.comboAdicionarNotasItem_Cidade_SelectedIndexChanged);
            comboAdicionarNotasItem_Cidade.Visible = true;

            labelAdicionarNotasItem_UF.Name = "labelAdicionarNotasItem_UF" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(labelAdicionarNotasItem_UF);
            labelAdicionarNotasItem_UF.Left = 719;
            labelAdicionarNotasItem_UF.Top = 5;
            labelAdicionarNotasItem_UF.Width = 35;
            labelAdicionarNotasItem_UF.Height = 23;
            labelAdicionarNotasItem_UF.BorderStyle = labelAdicionarNotasItem_UF01.BorderStyle;
            labelAdicionarNotasItem_UF.BackColor = labelAdicionarNotasItem_UF01.BackColor;
            labelAdicionarNotasItem_UF.Visible = true;

            numericAdicionarNotasItem_ValorNota.Name = "numericAdicionarNotasItem_ValorNota" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(numericAdicionarNotasItem_ValorNota);
            numericAdicionarNotasItem_ValorNota.Left = 760;
            numericAdicionarNotasItem_ValorNota.Top = 5;
            numericAdicionarNotasItem_ValorNota.Width = 100;
            numericAdicionarNotasItem_ValorNota.Visible = true;

            numericAdicionarNotasItem_PesoNota.Name = "numericAdicionarNotasItem_PesoNota" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(numericAdicionarNotasItem_PesoNota);
            numericAdicionarNotasItem_PesoNota.Left = 866;
            numericAdicionarNotasItem_PesoNota.Top = 5;
            numericAdicionarNotasItem_PesoNota.Width = 100;
            numericAdicionarNotasItem_PesoNota.Visible = true;

            AdicionarNotasItem_Configurar(pnlAdicionarNotasItem);

            groupPercurso.Top = groupAdicionarNotas.Top + groupAdicionarNotas.Height;
            groupInformaoeesAdicionaisInteresseFisco.Top = groupPercurso.Top + groupPercurso.Height;
            groupInformacoesComplementaresInteresseContribuinte.Top = groupInformaoeesAdicionaisInteresseFisco.Top + groupInformaoeesAdicionaisInteresseFisco.Height;
            pnlRodape.Top = groupInformacoesComplementaresInteresseContribuinte.Top + groupInformacoesComplementaresInteresseContribuinte.Height;
        }
        async Task AdicionarNotasItem_Configurar(Panel pnlAdicionarNotasItem)
        {
            foreach (Control control in pnlAdicionarNotasItem.Controls)
            {
                if (control.Name.Contains("comboAdicionarNotasItem_Tipo"))
                {
                    Combo_ComboBox.Formatar((ComboBox)control, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_OrigemNota));
                }
                else if (control.Name.Contains("comboAdicionarNotasItem_Cidade"))
                {
                    await comboCidade_Carregar((ComboBox)control);
                }
            }
        }
        private void comboAdicionarNotasItem_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAdicionarNotasItem_Tipo_Tratar(sender);
        }
        async Task comboAdicionarNotasItem_Tipo_Tratar(object sender)
        {
            string numerocontrole = ((ComboBox)sender).Name.Substring(("comboAdicionarNotasItem_Tipo").Length);

            if (((ComboBox)sender).SelectedIndex > -1)
            {
                if (((ComboBox)sender).SelectedValue is MDFe_OrigemNota.Entrada)
                {
                    using (MeuDbContext meuDbContext = this.MeuDbContext())
                    {
                        Combo_ComboBox.Formatar(((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]),
                                                "ID", "NotaFiscal",
                                                ComboBoxStyle.DropDownList,
                                                await(new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier)).ComboDadosFiscais(o => o.NotaFiscal));
                        Combo_ComboBox.Formatar(((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]),
                                                "ID", "CodigoChaveAcesso",
                                                ComboBoxStyle.DropDownList,
                                                await (new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier)).ComboDadosFiscais(o => o.CodigoChaveAcesso));
                    }
                }               
                else if (((ComboBox)sender).SelectedValue is MDFe_OrigemNota.Saida)
                {
                    using (MeuDbContext meuDbContext = this.MeuDbContext())
                    {
                        Combo_ComboBox.Formatar(((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]),
                                                "ID", "NotaFiscal",
                                                ComboBoxStyle.DropDownList,
                                                await (new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier)).ComboDadosFiscais(o => o.NotaFiscal));
                        Combo_ComboBox.Formatar(((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]),
                                                "ID", "CodigoChaveAcesso",
                                                ComboBoxStyle.DropDownList,
                                                await (new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier)).ComboDadosFiscais(o => o.CodigoChaveAcesso));
                    }
                }
            }
            else
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).DataSource = null;
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).DataSource = null;
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_Cidade" + numerocontrole, true)[0]).SelectedIndex = -1;
                ((NumericUpDown)Controls.Find("numericAdicionarNotasItem_ValorNota" + numerocontrole, true)[0]).Value = 0;
                ((NumericUpDown)Controls.Find("numericAdicionarNotasItem_PesoNota" + numerocontrole, true)[0]).Value = 0;
            }
        }

        private void comboAdicionarNotasItem_NumeroNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numerocontrole = ((ComboBox)sender).Name.Substring(("comboAdicionarNotasItem_NumeroNota").Length);
            if (((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedIndex > -1)
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedValue = ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedValue;
            }
            else
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedIndex = -1;
            }

            CalcularTotais();
        }
        private void comboAdicionarNotasItem_ChaveAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numerocontrole = ((ComboBox)sender).Name.Substring(("comboAdicionarNotasItem_ChaveAcesso").Length);
            if (((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedIndex > -1)
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedValue = ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedValue;
            }
            else
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedIndex = -1;
            }
        }

        private void comboAdicionarNotasItem_Cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numerocontrole = ((ComboBox)sender).Name.Substring(("comboAdicionarNotasItem_Cidade").Length);

            if (((ComboBox)sender).SelectedIndex > -1)
            {
                ((Label)Controls.Find("labelAdicionarNotasItem_UF" + numerocontrole, true)[0]).Text = ((CidadeViewModel)((ComboBox)sender).SelectedItem).Estado.Codigo;
            }
            else
            {
                ((Label)Controls.Find("labelAdicionarNotasItem_UF" + numerocontrole, true)[0]).Text = "";
            }
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {

        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            if (Funcoes._Classes.Funcao.NuloData(dateIdentificacao_Emissao.Value))
            {
                CaixaMensagem.Informacao("Informe a data de emissão");
                return;
            }
            if (!Funcoes._Classes.Validacao.Hora_Valido(textIdentificacao_HoraEmissao.Text))
            {
                CaixaMensagem.Informacao("Informe a hora de emissão");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboIdentificacao_Serie))
            {
                CaixaMensagem.Informacao("Selecione a série do MDF-e");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboIdentificacao_TipoEmissao))
            {
                CaixaMensagem.Informacao("Selecione tipo de emissão");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboIdentificacao_UFCarregamento))
            {
                CaixaMensagem.Informacao("Selecione U.F. Carregamento");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboIdentificacao_UFDescarga))
            {
                CaixaMensagem.Informacao("Selecione U.F. Descarga");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboIdentificacao_TipoTransportador))
            {
                CaixaMensagem.Informacao("Selecione Tipo de Transportador");
                return;
            }
            if (!String.IsNullOrEmpty(textIdentificacao_RNTRCEmitente.Text))
            {
                CaixaMensagem.Informacao("Informe o RNTRC Emitente");
                return;
            }
            if (!String.IsNullOrEmpty(textIdentificacao_RNTRCEmitente.Text))
            {
                CaixaMensagem.Informacao("Informe o RNTRC Emitente");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboDadosVeiculo_Placa))
            {
                CaixaMensagem.Informacao("Selecione a placa do veículo");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboDadosVeiculo_UF))
            {
                CaixaMensagem.Informacao("Selecione a U.F. do veículo");
                return;
            }
            if (!String.IsNullOrEmpty(textDadosVeiculo_Renavam.Text))
            {
                CaixaMensagem.Informacao("Informe o renavam do veículo");
                return;
            }
            if (numericDadosVeiculo_TaraKG.Value == 0)
            {
                CaixaMensagem.Informacao("Informe a tara (KG) do veículo");
                return;
            }
            if (numericDadosVeiculo_CapacidadeKG.Value == 0)
            {
                CaixaMensagem.Informacao("Informe a capacidade (KG) do veículo");
                return;
            }
            if (numericDadosVeiculo_CapacidadeM3.Value == 0)
            {
                CaixaMensagem.Informacao("Informe a capacidade (M3) do veículo");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboDadosVeiculo_TipoRodado))
            {
                CaixaMensagem.Informacao("Selecione o tipo do rodado do veículo");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboDadosVeiculo_TipoCarroceria))
            {
                CaixaMensagem.Informacao("Selecione o tipo da carroceria do veículo");
                return;
            }
            if (checkDadosVeiculoVceiuloTerceiro_Sim.Checked)
            {
                if (!String.IsNullOrEmpty(textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text))
                {
                    CaixaMensagem.Informacao("Informe o nome do proprietário do Veículo");
                    return;
                }
                if (!Validacao.CPFCNPJ_Valido(textDadosVeiculoVeiculoTerceiro_CPFCNPJProprietario.Text))
                {
                    CaixaMensagem.Informacao("Informe um CPF/CNPJ válido do proprietário do Veículo");
                }
                if (!Combo_ComboBox.Selecionado(comboDadosVeiculoVeiculoTerceiro_TipoProprietario))
                {
                    CaixaMensagem.Informacao("Selecione o tipo do proprietário do Veículo");
                    return;
                }
                if (!Combo_ComboBox.Selecionado(comboDadosVeiculoVeiculoTerceiro_UFProprietario))
                {
                    CaixaMensagem.Informacao("Selecione a U.F. do proprietário do Veículo");
                    return;
                }
            }
            if (!Validacao.CPFCNPJ_Valido(textCondutor_CPFCNPJCondutor.Text))
            {
                CaixaMensagem.Informacao("Informe um CPF/CNPJ válido do condutor");
                return;
            }
            if (!String.IsNullOrEmpty(textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text))
            {
                CaixaMensagem.Informacao("Informe o nome do condutor");
                return;
            }

            for (int i = 1; i <= AdicionarNotasItem_Notas; i++)
            {
                try
                {
                    Panel pnlAdicionarNotasItem = (Panel)this.Controls.Find("pnlAdicionarNotasItem" + i.ToString("00"), true)[0];

                    if (!Combo_ComboBox.Selecionado((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]))
                    {
                        CaixaMensagem.Informacao("Selecione a origem da nota fiscal " + i.ToString("00"));
                        return;
                    }
                    if (!Combo_ComboBox.Selecionado((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]))
                    {
                        CaixaMensagem.Informacao("Selecione o número da nota fiscal " + i.ToString("00"));
                        return;
                    }
                    if (!Combo_ComboBox.Selecionado((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + i.ToString("00"), false)[0]))
                    {
                        CaixaMensagem.Informacao("Selecione a chave de acesso da nota fiscal " + i.ToString("00"));
                        return;
                    }
                    if (!Combo_ComboBox.Selecionado((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), false)[0]))
                    {
                        CaixaMensagem.Informacao("Selecione o município da nota fiscal " + i.ToString("00"));
                        return;
                    }
                    if (((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_ValorNota" + i.ToString("00"), false)[0]).Value == 0)
                    {
                        CaixaMensagem.Informacao("Informe o valor da nota fiscal " + i.ToString("00"));
                        return;
                    }
                    if (((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_PesoNota" + i.ToString("00"), false)[0]).Value == 0)
                    {
                        CaixaMensagem.Informacao("Informe o peso bruto da nota fiscal " + i.ToString("00"));
                        return;
                    }
                }
                catch (Exception exception)
                {
                    CaixaMensagem.Informacao("Erro na validação da nota " + i.ToString("00"));
                    return;
                }
                foreach (DataGridViewRow row in gridPercurso.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        CaixaMensagem.Informacao("Selecione o percurso de todas as linhas selecionadas");
                        return;
                    }
                }
            }

            Gravar();
        }

        async Task Gravar()
        { 
            manifestoEletronicoDocumento.DataHoraEmissao = Validacao.Data_AdicionarHora(dateIdentificacao_Emissao.Value, textIdentificacao_HoraEmissao.Text);
            manifestoEletronicoDocumento.TipoEmissao = (MDFe_TipoEmissao)comboIdentificacao_TipoEmissao.SelectedValue;
            manifestoEletronicoDocumento.ManifestoEletronicoDocumentoSerieId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboIdentificacao_Serie);
            manifestoEletronicoDocumento.Numero = textIdentificacao_Numero.Text;
            manifestoEletronicoDocumento.Carga = textIdentificacao_Carga.Text;
            manifestoEletronicoDocumento.EstadoDescargaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboIdentificacao_UFDescarga);
            manifestoEletronicoDocumento.EstadoCarregamentoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboIdentificacao_UFCarregamento);
            manifestoEletronicoDocumento.CidadeCarregamentoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboIdentificacao_CidadeCarregamento);
            manifestoEletronicoDocumento.TipoTransportador = (MDFe_TipoTransportador?)comboIdentificacao_TipoTransportador.SelectedValue;
            manifestoEletronicoDocumento.RNTRCEmitente = textIdentificacao_RNTRCEmitente.Text;
            manifestoEletronicoDocumento.DadoVeiculo_PlacaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDadosVeiculo_Placa);
            manifestoEletronicoDocumento.DadoVeiculo_EstadoId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDadosVeiculo_UF);
            manifestoEletronicoDocumento.DadoVeiculo_Renavam = textDadosVeiculo_Renavam.Text;
            manifestoEletronicoDocumento.DadoVeiculo_TaraKG = (double)numericDadosVeiculo_TaraKG.Value;
            manifestoEletronicoDocumento.DadoVeiculo_CapacidadeKG = (double)numericDadosVeiculo_CapacidadeKG.Value;
            manifestoEletronicoDocumento.DadoVeiculo_CapacidadeM3 = (double)numericDadosVeiculo_CapacidadeM3.Value;
            manifestoEletronicoDocumento.DadoVeiculo_TipoRodado = (MDFe_TipoRodado?)comboDadosVeiculo_TipoRodado.SelectedValue;
            manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria = (MDFe_TipoCarroceria?)comboDadosVeiculo_TipoCarroceria.SelectedValue;
            if (checkDadosVeiculoVceiuloTerceiro_Sim.Checked)
            {
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_NomeProprietario = textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario = textDadosVeiculoVeiculoTerceiro_CPFCNPJProprietario.Text;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_IEProprietario = textDadosVeiculoVeiculoTerceiro_IEProprietario.Text;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_RNTRCProprietario = textDadosVeiculoVeiculoTerceiro_IEProprietario.Text;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_TipoProprietario = (MDFe_TipoProprietario?)comboDadosVeiculoVeiculoTerceiro_TipoProprietario.SelectedValue;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_EstadoProprietarioId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboDadosVeiculoVeiculoTerceiro_UFProprietario);
            }
            else
            {
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_NomeProprietario = null;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario = null;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_IEProprietario = null;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_RNTRCProprietario = null;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_TipoProprietario = null;
                manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_EstadoProprietario = null;
            }

            manifestoEletronicoDocumento.QuantidadeNFe = (int)numericTotalizadores_QuantidadeNfe.Value;
            manifestoEletronicoDocumento.ValorTotalCarga = numericTotalizadores_ValorTotalCarga.Value;
            manifestoEletronicoDocumento.PesoBrutoCarga = numericTotalizadores_PesoBrutoCarga.Value;
            manifestoEletronicoDocumento.UnidadePeso = (MDFe_UidadePeso?)comboTotalizadores_UnidadePeso.SelectedValue;

            manifestoEletronicoDocumento.Condutor_Nome = textCondutor_NomeCondutor.Text;
            manifestoEletronicoDocumento.Condutor_CPF = textCondutor_CPFCNPJCondutor.Text;

            manifestoEletronicoDocumento.InformacoesAdicionaisInteresseFisco = richInformaoeesAdicionaisInteresseFisco.Text;
            manifestoEletronicoDocumento.InformacoesComplementaresInteresseContribuinte = richInformacoesComplementaresInteresseContribuinte.Text;

            using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
            {
                if (manifestoEletronicoDocumento.Id == Guid.Empty) 
                {
                    manifestoEletronicoDocumento.Id = Guid.NewGuid();
                    await manifestoEletronicoDocumentoController.Adicionar(manifestoEletronicoDocumento);
                }
                else
                {
                    await manifestoEletronicoDocumentoController.Atualizar(manifestoEletronicoDocumento.Id, manifestoEletronicoDocumento);
                }
            }

            ManifestoEletronicoDocumentoNotaViewModel manifestoEletronicoDocumentoNota;
            ManifestoEletronicoDocumentoPercursoViewModel manifestoEletronicoDocumentoPercurso;

            using (ManifestoEletronicoDocumentoNotaController manifestoEletronicoDocumentoNotaController = new ManifestoEletronicoDocumentoNotaController(this.MeuDbContext(), this._notifier))
            {
                for (int i = 1; i <= AdicionarNotasItem_Notas; i++)
                {
                    manifestoEletronicoDocumentoNota = new ManifestoEletronicoDocumentoNotaViewModel();

                    Panel pnlAdicionarNotasItem = (Panel)this.Controls.Find("pnlAdicionarNotasItem" + i.ToString("00"), true)[0];

                    manifestoEletronicoDocumentoNota.Id = Guid.NewGuid();

                    switch ((MDFe_TipoManifestoEletronicoDocumentoNotas)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedValue)
                    {
                        case MDFe_TipoManifestoEletronicoDocumentoNotas.Entrada:
                            manifestoEletronicoDocumentoNota.TipoManifestoEletronicoDocumentoNotas = MDFe_TipoManifestoEletronicoDocumentoNotas.Entrada;
                            manifestoEletronicoDocumentoNota.NotaFiscalEntradaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]);
                            break;
                        case MDFe_TipoManifestoEletronicoDocumentoNotas.Saida:
                            manifestoEletronicoDocumentoNota.TipoManifestoEletronicoDocumentoNotas = MDFe_TipoManifestoEletronicoDocumentoNotas.Saida;
                            manifestoEletronicoDocumentoNota.NotaFiscalSaidaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]);
                            break;
                    }

                    manifestoEletronicoDocumentoNota.ManifestoEletronicoDocumentoId = manifestoEletronicoDocumento.Id;
                    manifestoEletronicoDocumentoNota.NumeroNotaFiscal = ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).Text;
                    manifestoEletronicoDocumentoNota.ChaveAcesso = ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + i.ToString("00"), false)[0]).Text;
                    manifestoEletronicoDocumentoNota.CidadeDescargaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), false)[0]);
                    manifestoEletronicoDocumentoNota.ValorNota = ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_ValorNota" + i.ToString("00"), false)[0]).Value;
                    manifestoEletronicoDocumentoNota.PesoNota = ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_PesoNota" + i.ToString("00"), false)[0]).Value;

                    await manifestoEletronicoDocumentoNotaController.Adicionar(manifestoEletronicoDocumentoNota);
                }
            }

            using (ManifestoEletronicoDocumentoPercursoController manifestoEletronicoDocumentoPercursoController = new ManifestoEletronicoDocumentoPercursoController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in gridPercurso.Rows)
                {
                    manifestoEletronicoDocumentoPercurso = new ManifestoEletronicoDocumentoPercursoViewModel();

                    manifestoEletronicoDocumentoPercurso.Id = Guid.NewGuid();
                    manifestoEletronicoDocumentoPercurso.ManifestoEletronicoDocumentoId = manifestoEletronicoDocumento.Id;
                    manifestoEletronicoDocumentoPercurso.EstadoId = (Guid)row.Cells[0].Value;

                    await manifestoEletronicoDocumentoPercursoController.Adicionar(manifestoEletronicoDocumentoPercurso);
                }
            }

            CaixaMensagem.Informacao("Gravação Efetuada");
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        void Limpar()
        {
            checkAutorizacao_SatusAutorizado.Checked = false;
            checkAutorizacao_SatusCancelado.Checked = false;
            checkAutorizacao_SatusEncerramento.Checked = false;
            checkAutorizacao_SatusValidado.Checked = false;
            checkDadosVeiculoVceiuloTerceiro_Sim.Checked = false;

            comboDadosVeiculo_Placa.SelectedIndex =-1;
            comboDadosVeiculo_TipoCarroceria.SelectedIndex = -1;
            comboDadosVeiculo_TipoRodado.SelectedIndex = -1;
            comboDadosVeiculo_UF.SelectedIndex = -1;
            comboDadosVeiculoVeiculoTerceiro_TipoProprietario.SelectedIndex = -1;
            comboDadosVeiculoVeiculoTerceiro_UFProprietario.SelectedIndex = -1;
            comboIdentificacao_CidadeCarregamento.DataSource = null;
            comboIdentificacao_Serie.SelectedIndex = -1;
            comboIdentificacao_TipoEmissao.SelectedIndex = -1;
            comboIdentificacao_TipoTransportador.SelectedIndex = -1;
            comboIdentificacao_UFCarregamento.SelectedIndex = -1;
            comboIdentificacao_UFDescarga.SelectedIndex = -1;
            comboTotalizadores_UnidadePeso.SelectedIndex = -1;

            gridPercurso.Rows.Clear();

            dateIdentificacao_Emissao.Value = DateTime.Now;

            numericAdicionarNotasItem_PesoNota01.Value = 0;
            numericAdicionarNotasItem_ValorNota01.Value = 0;
            numericDadosVeiculo_CapacidadeKG.Value = 0;
            numericDadosVeiculo_CapacidadeM3.Value = 0;
            numericDadosVeiculo_TaraKG.Value = 0;
            textIdentificacao_Numero.Text = "0";
            numericTotalizadores_PesoBrutoCarga.Value = 0;
            numericTotalizadores_QuantidadeNfe.Value = 0;
            numericTotalizadores_ValorTotalCarga.Value = 0;

            richInformacoesComplementaresInteresseContribuinte.Text = "";
            richInformaoeesAdicionaisInteresseFisco.Text = "";

            textDadosVeiculoVeiculoTerceiro_IEProprietario.Text = "";
            textAutorizacao_ChaveAutorizacao.Text = "";
            textAutorizacao_DataHoraAutorizazacao.Text = "";
            textAutorizacao_DtaHoraEncerramento.Text = "";
            textAutorizacao_Protocolo.Text = "";
            textCondutor_CPFCNPJCondutor.Text = "";
            textCondutor_NomeCondutor.Text = "";
            textDadosVeiculo_Renavam.Text = "";
            textDadosVeiculoVeiculoTerceiro_CPFCNPJProprietario.Text = "";
            textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text = "";
            textDadosVeiculoVeiculoTerceiro_RNTCProprietario.Text = "";
            textIdentificacao_Carga.Text = "";
            textIdentificacao_HoraEmissao.Text = "";
            textIdentificacao_RNTRCEmitente.Text = "";

            //pnlAdicionarNotas;
            //pnlAdicionarNotasItem01;

            //comboAdicionarNotasItem_ChaveAcesso01.;
            //comboAdicionarNotasItem_Cidade01;
            //comboAdicionarNotasItem_NumeroNota01;
            //comboAdicionarNotasItem_Tipo01;
            //labelAdicionarNotasItem_UF01;
        }

        private void comboDadosVeiculo_Placa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botaoTransmitir_Click(object sender, EventArgs e)
        {

        }

        private void CalcularTotais()
        {
            numericTotalizadores_PesoBrutoCarga.Value = 0;
            numericTotalizadores_QuantidadeNfe.Value = 0;
            numericTotalizadores_ValorTotalCarga.Value = 0;

            for (int i = 1; i <= AdicionarNotasItem_Notas; i++)
            {
                Panel pnlAdicionarNotasItem = (Panel)this.Controls.Find("pnlAdicionarNotasItem" + i.ToString("00"), true)[0];

                if (((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedIndex != -1)
                {
                    switch ((MDFe_TipoManifestoEletronicoDocumentoNotas)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedValue)
                    {
                        case MDFe_TipoManifestoEletronicoDocumentoNotas.Entrada:
                            NotaFiscalEntrada notaFiscalEntrada = (NotaFiscalEntrada)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedItem;
                            break;
                        case MDFe_TipoManifestoEletronicoDocumentoNotas.Saida:
                            try
                            {
                                NotaFiscalSaida notaFiscalSaida = (NotaFiscalSaida)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedItem;
                                numericTotalizadores_PesoBrutoCarga.Value = numericTotalizadores_PesoBrutoCarga.Value + (decimal)notaFiscalSaida.VolumeTransportados_PesoBruto;
                                numericTotalizadores_QuantidadeNfe.Value = numericTotalizadores_QuantidadeNfe.Value + 1;
                                numericTotalizadores_ValorTotalCarga.Value = numericTotalizadores_ValorTotalCarga.Value + notaFiscalSaida.NotaFiscalSaidaMercadoria.Sum(s => s.PrecoTotal);
                            }
                            catch (Exception)
                            {
                            }

                            break;
                    }
                }
            }
        }
    }
}