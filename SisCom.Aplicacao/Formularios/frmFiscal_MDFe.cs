using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
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
            try
            {
                Combo_ComboBox.Formatar(comboIdentificacao_TipoEmissao, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoEmissao));
                Combo_ComboBox.Formatar(comboIdentificacao_TipoTransportador, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoTransportador));
                Combo_ComboBox.Formatar(comboDadosVeiculo_TipoRodado, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoRodado));
                Combo_ComboBox.Formatar(comboDadosVeiculo_TipoCarroceria, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoCarroceria));
                Combo_ComboBox.Formatar(comboDadosVeiculoVeiculoTerceiro_TipoProprietario, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_TipoProprietario));
                Combo_ComboBox.Formatar(comboDadosVeiculoVeiculoTerceiro_TipoProprietario, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_OrigemNota));

                await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
                await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
                await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());
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
                Combo_ComboBox.Formatar(comboIdentificacao_UFCarregamento,"ID", "Codigo",ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo());
                Combo_ComboBox.Formatar(comboIdentificacao_UFDescarga, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo());
                Combo_ComboBox.Formatar(comboDadosVeiculo_UF, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo());
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
                                        await (new VeiculoPlacaController(this.MeuDbContext(), this._notifier)).Combo());            }

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

                List<CodigoDescricaoComboViewModel> estado;

                using (EstadoController observacaoController = new EstadoController(this.MeuDbContext(), this._notifier))
                {
                    estado = (List<CodigoDescricaoComboViewModel>)await observacaoController.Combo(o => o.Codigo);
                }

                Grid_DataGridView.User_Formatar(gridPercurso, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
                Grid_DataGridView.User_ColunaAdicionar(gridPercurso, "U.F.", "U.F.", Tamanho: 100, dataSource: estado,
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
            if ((comboIdentificacao_UFCarregamento.SelectedIndex != -1) && (comboIdentificacao_UFCarregamento.Tag != Declaracoes.ComboBox_Carregando) && Combo_ComboBox.Selecionado(comboIdentificacao_UFDescarga))
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
    }
}