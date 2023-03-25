using DanfeSharp.Esquemas.NFe;
using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmFiscal_MDFe : FormMain
    {
        public Guid manifestoEletronicoDocumentoId = Guid.Empty;

        ManifestoEletronicoDocumentoViewModel manifestoEletronicoDocumento = new ManifestoEletronicoDocumentoViewModel();        

        int AdicionarNotasItem_Notas = 1;
        int AdicionarNotasItem_UltimoTop = 1;

        bool CarregandoForm = true;
        bool CarregandoDados = false;

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

                comboIdentificacao_UFCarregamento.SelectedValue = Declaracoes.dados_Empresa_EstadoId;
                await comboIdentificacao_UFCarregamento_Tratar();
                comboIdentificacao_CidadeCarregamento.SelectedValue = Declaracoes.dados_Empresa_CidadeId;
                textDadosVeiculo_Renavam.Text = "0";
                numericDadosVeiculo_CapacidadeKG.Value = 0;
                if (comboIdentificacao_Serie.Items.Count == 1)
                comboIdentificacao_Serie.SelectedIndex = 0;

                comboIdentificacao_TipoTransportador.SelectedValue = MDFe_TipoTransportador.TransportadorCargaPropria;

                await AdicionarNotasItem_Configurar(pnlAdicionarNotasItem01);

                AdicionarNotasItem_UltimoTop = pnlAdicionarNotasItem01.Top;

                CarregandoForm = false;

                if (manifestoEletronicoDocumentoId != Guid.Empty)
                    await Assincrono.TaskAsyncAndAwaitAsync(CarregarDados());
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("MDF-e -  Inicializa", ex);
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
        private async Task<bool> comboUnidadeMedida_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboTotalizadores_UnidadePeso,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new UnidadeMedidaController(this.MeuDbContext(), this._notifier)).Combo(o => o.Codigo));
            }

            return true;
        }
        private async Task<bool> comboCondutor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboCondutor_CPFCNPJCondutor,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        (await (new CondutorController(this.MeuDbContext(), this._notifier)).Combo(o => o.CNPJ_CPF)).Select(s => new CodigoDescricaoComboViewModel() { Id = s.Id, Codigo = s.CNPJ_CPF, Descricao = s.Nome }).ToList());
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
                Combo_ComboBox.Formatar(comboDadosVeiculoVeiculoTerceiro_UFProprietario, "ID", "Codigo", ComboBoxStyle.DropDownList, await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(o => o.Codigo));
            }

            return true;
        }
        private async Task<bool> comboIdentificacao_CidadeCarregamento_Carregar(Guid EstadoId)
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                var id = comboIdentificacao_CidadeCarregamento.SelectedValue;

                await Combo_ComboBox.ComboCidadeEstado_Carregar(comboIdentificacao_CidadeCarregamento, EstadoId, this.MeuDbContext(), this._notifier);

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
                                        await (new VeiculoPlacaController(this.MeuDbContext(), this._notifier)).Combo(o => o.NumeroPlaca));
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
            await Assincrono.TaskAsyncAndAwaitAsync(comboUnidadeMedida_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboCondutor_Carregar());

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
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("MDF-e - Inicializar", ex);
            }

            return true;
        }
        private async Task<bool> CarregarDados()
        {
            try
            {
                CarregandoDados = true;

                using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
                {
                    manifestoEletronicoDocumento = await manifestoEletronicoDocumentoController.PesquisarId(manifestoEletronicoDocumentoId);
                }
                if (manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos == null)
                {
                    using (ManifestoEletronicoDocumentoPercursoController manifestoEletronicoDocumentoPercursoController = new ManifestoEletronicoDocumentoPercursoController(this.MeuDbContext(), this._notifier))
                    {
                        manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos = (List<ManifestoEletronicoDocumentoPercursoViewModel>)await manifestoEletronicoDocumentoPercursoController.ObterTodos(w => w.ManifestoEletronicoDocumentoId == manifestoEletronicoDocumentoId);
                    }
                }
                if (manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas == null)
                {
                    using (ManifestoEletronicoDocumentoNotaController manifestoEletronicoDocumentoNotaController = new ManifestoEletronicoDocumentoNotaController(this.MeuDbContext(), this._notifier))
                    {
                        manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas = (List<ManifestoEletronicoDocumentoNotaViewModel>)await manifestoEletronicoDocumentoNotaController.ObterTodos(w => w.ManifestoEletronicoDocumentoId == manifestoEletronicoDocumentoId);
                    }
                }

                dateIdentificacao_Emissao.Value = manifestoEletronicoDocumento.DataHoraEmissao.Date;
                textIdentificacao_HoraEmissao.Text = manifestoEletronicoDocumento.DataHoraEmissao.ToString("HH:MM");
                if (!Funcao.Nulo(manifestoEletronicoDocumento.TipoEmissao)) { comboIdentificacao_TipoEmissao.SelectedValue = manifestoEletronicoDocumento.TipoEmissao; }
                comboIdentificacao_Serie.SelectedValue = manifestoEletronicoDocumento.ManifestoEletronicoDocumentoSerieId;
                if (!Funcao.Nulo(manifestoEletronicoDocumento.Numero)) { textIdentificacao_Numero.Text = manifestoEletronicoDocumento.Numero; }
                if (!Funcao.Nulo(manifestoEletronicoDocumento.Carga)) { textIdentificacao_Carga.Text = manifestoEletronicoDocumento.Carga; }
                if (!Funcao.Nulo(manifestoEletronicoDocumento.EstadoDescargaId)) { comboIdentificacao_UFDescarga.SelectedValue = manifestoEletronicoDocumento.EstadoDescargaId; }
                if (!Funcao.Nulo(manifestoEletronicoDocumento.EstadoCarregamentoId)) { comboIdentificacao_UFCarregamento.SelectedValue = manifestoEletronicoDocumento.EstadoCarregamentoId; }
                await comboIdentificacao_UFCarregamento_Tratar();
                if (!Funcao.Nulo(manifestoEletronicoDocumento.CidadeCarregamentoId)) { comboIdentificacao_CidadeCarregamento.SelectedValue = manifestoEletronicoDocumento.EstadoCarregamentoId; }
                if (!Funcao.Nulo(manifestoEletronicoDocumento.TipoTransportador)) { comboIdentificacao_TipoTransportador.SelectedValue = manifestoEletronicoDocumento.TipoTransportador; }
                textIdentificacao_RNTRCEmitente.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.RNTRCEmitente);
                Combo_ComboBox.Selecionar(comboDadosVeiculo_Placa, Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculo_NumeroPlaca));
                if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculo_EstadoId)) { comboDadosVeiculo_UF.SelectedValue = manifestoEletronicoDocumento.DadoVeiculo_EstadoId; }
                textDadosVeiculo_Renavam.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculo_Renavam);
                numericDadosVeiculo_TaraKG.Value = (decimal)manifestoEletronicoDocumento.DadoVeiculo_TaraKG;
                numericDadosVeiculo_CapacidadeKG.Value = (decimal)manifestoEletronicoDocumento.DadoVeiculo_CapacidadeKG;
                numericDadosVeiculo_CapacidadeM3.Value = (decimal)manifestoEletronicoDocumento.DadoVeiculo_CapacidadeM3;
                if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculo_TipoRodado)) { comboDadosVeiculo_TipoRodado.SelectedValue = manifestoEletronicoDocumento.DadoVeiculo_TipoRodado; }
                if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria)) { comboDadosVeiculo_TipoCarroceria.SelectedValue = manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria; }

                if (checkDadosVeiculoVceiuloTerceiro_Sim.Checked)
                {
                    textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_NomeProprietario);
                    textDadosVeiculoVeiculoTerceiro_CPFCNPJProprietario.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario);
                    textDadosVeiculoVeiculoTerceiro_IEProprietario.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_IEProprietario);
                    textDadosVeiculoVeiculoTerceiro_IEProprietario.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_RNTRCProprietario);
                    if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria)) { comboDadosVeiculo_TipoCarroceria.SelectedValue = manifestoEletronicoDocumento.DadoVeiculo_TipoCarroceria; }
                    if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_TipoProprietario)) { comboDadosVeiculoVeiculoTerceiro_TipoProprietario.SelectedValue = manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_TipoProprietario; }
                    if (!Funcao.Nulo(manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_EstadoProprietarioId)) { comboDadosVeiculoVeiculoTerceiro_UFProprietario.SelectedValue = manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_EstadoProprietarioId; }
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

                numericTotalizadores_QuantidadeNfe.Value = manifestoEletronicoDocumento.QuantidadeNFe;
                numericTotalizadores_ValorTotalCarga.Value = manifestoEletronicoDocumento.ValorTotalCarga;
                numericTotalizadores_PesoBrutoCarga.Value = manifestoEletronicoDocumento.PesoBrutoCarga;
                if (!Funcao.Nulo(manifestoEletronicoDocumento.UnidadePeso)) { comboTotalizadores_UnidadePeso.SelectedValue = manifestoEletronicoDocumento.UnidadePeso; }
                textCondutor_NomeCondutor.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.Condutor_Nome);
                Combo_ComboBox.Selecionar(comboCondutor_CPFCNPJCondutor, Funcao.NuloParaString(manifestoEletronicoDocumento.Condutor_CPF));
                richInformaoeesAdicionaisInteresseFisco.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.InformacoesAdicionaisInteresseFisco);
                richInformacoesComplementaresInteresseContribuinte.Text = Funcao.NuloParaString(manifestoEletronicoDocumento.InformacoesComplementaresInteresseContribuinte);

                int i = 1;

                if (manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas != null)
                {
                    foreach(ManifestoEletronicoDocumentoNotaViewModel nota in manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas)
                    {
                        Panel pnlAdicionarNotasItem;

                        if (i != 1)
                        {
                            pnlAdicionarNotasItem = await AdicionarNotas();
                            i = (int)pnlAdicionarNotasItem.Tag;
                        }
                        else
                        {
                            pnlAdicionarNotasItem = pnlAdicionarNotasItem01;
                        }

                        ComboBox comboAdicionarNotasItem_Tipo = ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]);

                        if (comboAdicionarNotasItem_Tipo.Items.Count == 0)
                        {
                            Combo_ComboBox.Formatar(comboAdicionarNotasItem_Tipo, "", "", ComboBoxStyle.DropDownList, null, typeof(MDFe_OrigemNota));
                        }

                        comboAdicionarNotasItem_Tipo.SelectedIndex = 2;
                        await comboAdicionarNotasItem_Tipo_Tratar(comboAdicionarNotasItem_Tipo);
                        ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]).SelectedValue = nota.NotaFiscalSaidaId;
                        ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + i.ToString("00"), false)[0]).SelectedValue= nota.NotaFiscalSaidaId;
                        ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), false)[0]).SelectedValue = nota.CidadeDescargaId;
                        ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_ValorNota" + i.ToString("00"), false)[0]).Value = nota.ValorNota;
                        ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_PesoNota" + i.ToString("00"), false)[0]).Value = nota.PesoNota;

                        i++;
                    }
                }

                i = 0;

                if (manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos != null)
                {
                    manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos.OrderBy(o => o.Ordem).ToList().ForEach(async percurso =>
                    {
                        gridPercurso.Rows.Add();
                        gridPercurso.Rows[i].Cells[0].Value = percurso.EstadoId;
                        i++;
                    });
                }

                CarregandoDados = false;
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("MDF-e - Carregar dados", ex);
            }

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
        }

        private async void botaoAdicionarNotas_Click(object sender, EventArgs e)
        {
            await AdicionarNotas();
        }

        async Task<Panel> AdicionarNotas()
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

            pnlAdicionarNotasItem.Tag = AdicionarNotasItem_Notas;
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
            numericAdicionarNotasItem_ValorNota.Maximum = 1000000000;
            numericAdicionarNotasItem_ValorNota.DecimalPlaces = 2;
            numericAdicionarNotasItem_ValorNota.ThousandsSeparator = true;

            numericAdicionarNotasItem_PesoNota.Name = "numericAdicionarNotasItem_PesoNota" + AdicionarNotasItem_Notas.ToString("00");
            pnlAdicionarNotasItem.Controls.Add(numericAdicionarNotasItem_PesoNota);
            numericAdicionarNotasItem_PesoNota.Left = 866;
            numericAdicionarNotasItem_PesoNota.Top = 5;
            numericAdicionarNotasItem_PesoNota.Width = 100;
            numericAdicionarNotasItem_PesoNota.Visible = true;
            numericAdicionarNotasItem_PesoNota.Maximum = 1000000000;
            numericAdicionarNotasItem_PesoNota.ThousandsSeparator = true;

            await AdicionarNotasItem_Configurar(pnlAdicionarNotasItem);

            groupPercurso.Top = groupAdicionarNotas.Top + groupAdicionarNotas.Height;
            groupInformaoeesAdicionaisInteresseFisco.Top = groupPercurso.Top + groupPercurso.Height;
            groupInformacoesComplementaresInteresseContribuinte.Top = groupInformaoeesAdicionaisInteresseFisco.Top + groupInformaoeesAdicionaisInteresseFisco.Height;
            pnlRodape.Top = groupInformacoesComplementaresInteresseContribuinte.Top + groupInformacoesComplementaresInteresseContribuinte.Height;

            return pnlAdicionarNotasItem;
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
            bool limpar = false;

            if (((ComboBox)sender).SelectedIndex > -1)
            {
                if (((ComboBox)sender).SelectedValue is MDFe_OrigemNota.Entrada)
                {
                    using (MeuDbContext meuDbContext = this.MeuDbContext())
                    {
                        Combo_ComboBox.Formatar(((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]),
                                                "ID", "NotaFiscal",
                                                ComboBoxStyle.DropDownList,
                                                await (new NotaFiscalEntradaController(this.MeuDbContext(), this._notifier)).ComboDadosFiscais(o => o.NotaFiscal));
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
                else
                    limpar = true;
            }
            else
                limpar = true;

            if (limpar)
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).DataSource = null;
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).DataSource = null;
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_Cidade" + numerocontrole, true)[0]).SelectedIndex = -1;
                ((NumericUpDown)Controls.Find("numericAdicionarNotasItem_ValorNota" + numerocontrole, true)[0]).Value = 0;
                ((NumericUpDown)Controls.Find("numericAdicionarNotasItem_PesoNota" + numerocontrole, true)[0]).Value = 0;
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_Cidade" + numerocontrole, true)[0]).SelectedIndex =-1;
            }
        }

        private async void comboAdicionarNotasItem_NumeroNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CarregandoDados) return;
            string numerocontrole = ((ComboBox)sender).Name.Substring(("comboAdicionarNotasItem_NumeroNota").Length);
            if (((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedIndex > -1)
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedValue = ((ComboBox)Controls.Find("comboAdicionarNotasItem_NumeroNota" + numerocontrole, true)[0]).SelectedValue;
            }
            else
            {
                ((ComboBox)Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + numerocontrole, true)[0]).SelectedIndex = -1;
            }

            await NotasSelecionadas_Tratart();
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
            TentarGravar();
        }

        async Task TentarGravar()
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
            if (numericDadosVeiculo_TaraKG.Value == 0)
            {
                CaixaMensagem.Informacao("Informe a tara (KG) do veículo");
                return;
            }
            if (numericDadosVeiculo_CapacidadeKG.Value < 0)
            {
                CaixaMensagem.Informacao("Informe a capacidade (KG) do veículo");
                return;
            }
            if (numericDadosVeiculo_CapacidadeM3.Value < 0)
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
                if (String.IsNullOrEmpty(textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text))
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
            if (!Combo_ComboBox.Selecionado(comboCondutor_CPFCNPJCondutor))
            {
                CaixaMensagem.Informacao("Informe um CPF/CNPJ válido do condutor");
                return;
            }
            if (String.IsNullOrEmpty(textCondutor_NomeCondutor.Text))
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
                    if ((MDFe_OrigemNota)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Tipo" + i.ToString("00"), false)[0]).SelectedValue != MDFe_OrigemNota.Todos)
                    {
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
                }
                catch (Exception exception)
                {
                    CaixaMensagem.Informacao("Erro na validação da nota " + i.ToString("00"));
                    return;
                }
                foreach (DataGridViewRow row in gridPercurso.Rows)
                {
                    if ((row.Cells[0].Value == null) && (row.Index < gridPercurso.Rows.Count -1))
                    {
                        CaixaMensagem.Informacao("Selecione o percurso de todas as linhas selecionadas");
                        return;
                    }
                }
            }

            await Gravar();
        }

        async Task Gravar()
        {
            try
            {
                manifestoEletronicoDocumento.EmpresaId = Declaracoes.dados_Empresa_Id;
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
                manifestoEletronicoDocumento.DadoVeiculo_NumeroPlaca = comboDadosVeiculo_Placa.Text;
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
                manifestoEletronicoDocumento.Condutor_CPF = comboCondutor_CPFCNPJCondutor.Text;
                manifestoEletronicoDocumento.InformacoesAdicionaisInteresseFisco = richInformaoeesAdicionaisInteresseFisco.Text;
                manifestoEletronicoDocumento.InformacoesComplementaresInteresseContribuinte = richInformacoesComplementaresInteresseContribuinte.Text;

                using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
                {
                    manifestoEletronicoDocumento.Empresa = null;
                    manifestoEletronicoDocumento.EstadoCarregamento = null;
                    manifestoEletronicoDocumento.CidadeCarregamento = null;
                    manifestoEletronicoDocumento.EstadoDescarga = null;
                    manifestoEletronicoDocumento.DadoVeiculo_Placa = null;
                    manifestoEletronicoDocumento.DadoVeiculo_Estado = null;
                    manifestoEletronicoDocumento.DadoVeiculoVeiculoTerceiros_EstadoProprietario = null;
                    manifestoEletronicoDocumento.DadoVeiculo_Placa = null;
                    manifestoEletronicoDocumento.ManifestoEletronicoDocumentoSerie = null;
                    manifestoEletronicoDocumento.ManifestoEletronicoDocumentoPercursos = null;
                    manifestoEletronicoDocumento.ManifestoEletronicoDocumentoNotas = null;

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
                        NF_ComboViewModel nf_ComboViewModel = new NF_ComboViewModel();

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

                                nf_ComboViewModel = (NF_ComboViewModel)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]).SelectedItem;
                                manifestoEletronicoDocumentoNota.NotaFiscalSaidaId = nf_ComboViewModel.Id;
                                break;
                        }

                        var manifestoEletronicoDocumentoNotapesq = await manifestoEletronicoDocumentoNotaController.ObterTodos(w => w.NumeroNotaFiscal == nf_ComboViewModel.NotaFiscal && w.ManifestoEletronicoDocumentoId == manifestoEletronicoDocumentoId);

                        manifestoEletronicoDocumentoNota.ManifestoEletronicoDocumentoId = manifestoEletronicoDocumento.Id;
                        manifestoEletronicoDocumentoNota.NumeroNotaFiscal = nf_ComboViewModel.NotaFiscal;
                        manifestoEletronicoDocumentoNota.ChaveAcesso = ((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_ChaveAcesso" + i.ToString("00"), false)[0]).Text;
                        manifestoEletronicoDocumentoNota.CidadeDescargaId = Combo_ComboBox.NaoSelecionadoParaNuloGuid((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), false)[0]);
                        manifestoEletronicoDocumentoNota.ValorNota = ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_ValorNota" + i.ToString("00"), false)[0]).Value;
                        manifestoEletronicoDocumentoNota.PesoNota = ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_PesoNota" + i.ToString("00"), false)[0]).Value;

                        if (manifestoEletronicoDocumentoNotapesq.Any())
                        {
                            manifestoEletronicoDocumentoNota.Id = manifestoEletronicoDocumentoNotapesq.FirstOrDefault().Id;
                            await manifestoEletronicoDocumentoNotaController.Atualizar(manifestoEletronicoDocumentoNota.Id, manifestoEletronicoDocumentoNota);
                        }
                        else
                        {
                            manifestoEletronicoDocumentoNota.Id = Guid.NewGuid();
                            await manifestoEletronicoDocumentoNotaController.Adicionar(manifestoEletronicoDocumentoNota);
                        }
                    }
                }

                int ordem = 0;

                using (ManifestoEletronicoDocumentoPercursoController manifestoEletronicoDocumentoPercursoController = new ManifestoEletronicoDocumentoPercursoController(this.MeuDbContext(), this._notifier))
                {
                    foreach (DataGridViewRow row in gridPercurso.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            ordem++;

                            var manifestoEletronicoDocumentoPercursopesq = await manifestoEletronicoDocumentoPercursoController.ObterTodos(w => w.EstadoId == (Guid)row.Cells[0].Value);

                            if (!manifestoEletronicoDocumentoPercursopesq.Any())
                            {
                                manifestoEletronicoDocumentoPercurso = new ManifestoEletronicoDocumentoPercursoViewModel();

                                manifestoEletronicoDocumentoPercurso.Id = Guid.NewGuid();
                                manifestoEletronicoDocumentoPercurso.ManifestoEletronicoDocumentoId = manifestoEletronicoDocumento.Id;
                                manifestoEletronicoDocumentoPercurso.EstadoId = (Guid)row.Cells[0].Value;
                                manifestoEletronicoDocumentoPercurso.Ordem = ordem;

                                await manifestoEletronicoDocumentoPercursoController.Adicionar(manifestoEletronicoDocumentoPercurso);
                            }
                            else
                            {
                                manifestoEletronicoDocumentoPercurso = new ManifestoEletronicoDocumentoPercursoViewModel();

                                manifestoEletronicoDocumentoPercurso.Id = manifestoEletronicoDocumentoPercursopesq.FirstOrDefault().Id;
                                manifestoEletronicoDocumentoPercurso.ManifestoEletronicoDocumentoId = manifestoEletronicoDocumento.Id;
                                manifestoEletronicoDocumentoPercurso.EstadoId = (Guid)row.Cells[0].Value;
                                manifestoEletronicoDocumentoPercurso.Ordem = ordem;

                                await manifestoEletronicoDocumentoPercursoController.Atualizar(manifestoEletronicoDocumentoPercurso.Id, manifestoEletronicoDocumentoPercurso);
                            }
                        }
                    }
                }

                CaixaMensagem.Informacao("Gravação Efetuada");
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("MDF-e - Gravar", ex);
            }
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
            comboCondutor_CPFCNPJCondutor.SelectedIndex = -1;
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

        private void botaoTransmitir_Click(object sender, EventArgs e)
        {
            Transmitir();
        }
        async void Transmitir()
        {
            if (manifestoEletronicoDocumento != null)
            {
                ViewModels.EmpresaViewModel empresa;

                using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
                {
                    empresa = await empresaController.GetById(Declaracoes.dados_Empresa_Id);
                }

                await Fiscal.MDFe_Transmitir(manifestoEletronicoDocumento.Id, this.MeuDbContext(), this._notifier, empresa);

                CaixaMensagem.Informacao("MDF-e transmitido");
            }
        }

        private async Task<bool> NotasSelecionadas_Tratart()
        {
            if (CarregandoDados) return true;

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
                                Guid? notaFiscalSaidaId = ((NF_ComboViewModel)((ComboBox)pnlAdicionarNotasItem.Controls.Find("comboAdicionarNotasItem_NumeroNota" + i.ToString("00"), false)[0]).SelectedItem).Id;

                                if (notaFiscalSaidaId != null)
                                {
                                    IEnumerable<NotaFiscalSaidaViewModel> notaFiscalSaida;

                                    using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                                    {
                                        notaFiscalSaida = await notaFiscalSaidaController.PesquisarCompleto(w => w.Id == (Guid)notaFiscalSaidaId);
                                    }

                                    if (notaFiscalSaida.Any())
                                    {
                                        foreach (object Item in ((ComboBox)Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), true)[0]).Items)
                                        {
                                            if (((CidadeViewModel)Item).Id == notaFiscalSaida.FirstOrDefault().Cliente_Endereco.End_CidadeId)
                                            {
                                                ((ComboBox)Controls.Find("comboAdicionarNotasItem_Cidade" + i.ToString("00"), true)[0]).SelectedItem = Item;
                                                break;
                                            }
                                        }
                                        ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_ValorNota" + i.ToString("00"), false)[0]).Value = notaFiscalSaida.FirstOrDefault().NotaFiscalSaidaMercadoria.Sum(s => s.PrecoTotal);
                                        ((NumericUpDown)pnlAdicionarNotasItem.Controls.Find("numericAdicionarNotasItem_PesoNota" + i.ToString("00"), false)[0]).Value = (decimal)notaFiscalSaida.FirstOrDefault().VolumeTransportados_PesoBruto;

                                        numericTotalizadores_PesoBrutoCarga.Value = numericTotalizadores_PesoBrutoCarga.Value + (decimal)(notaFiscalSaida.FirstOrDefault()).VolumeTransportados_PesoBruto;
                                        numericTotalizadores_QuantidadeNfe.Value = numericTotalizadores_QuantidadeNfe.Value + 1;
                                        numericTotalizadores_ValorTotalCarga.Value = numericTotalizadores_ValorTotalCarga.Value + notaFiscalSaida.FirstOrDefault().NotaFiscalSaidaMercadoria.Sum(s => s.PrecoTotal);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }

                            break;
                    }
                }
            }

            return true;
        }
        private async void comboIdentificacao_Serie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CarregandoDados) { await Serie_Tratar(); }
        }
        async Task Serie_Tratar()
        {
            if ((comboIdentificacao_Serie.SelectedIndex != -1) && (String.IsNullOrEmpty(textIdentificacao_Numero.Text)) && (!CarregandoDados))
            {
                using (ManifestoEletronicoDocumentoSerieController manifestoEletronicoDocumentoSerieController = new ManifestoEletronicoDocumentoSerieController(this.MeuDbContext(), this._notifier))
                {
                    var seriePsq = await manifestoEletronicoDocumentoSerieController.PesquisarSerie(comboIdentificacao_Serie.Text);

                    if (seriePsq != null)
                    {
                        var serie = seriePsq.FirstOrDefault();

                        if (String.IsNullOrEmpty(serie.UltimoNumeroManifestoEletronicoDocumento))
                        { textIdentificacao_Numero.Text = "1"; }
                        else
                        { textIdentificacao_Numero.Text = (Convert.ToInt16(serie.UltimoNumeroManifestoEletronicoDocumento) + 1).ToString(); }

                        serie.UltimoNumeroManifestoEletronicoDocumento = textIdentificacao_Numero.Text;
                        serie.UltimoManifestoEletronicoDocumento = null;
                        await manifestoEletronicoDocumentoSerieController.Atualizar(serie.Id, seriePsq.FirstOrDefault());
                    }
                }
            }
        }
        private async void botaoPlaca_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroVeiculoPlaca>();
            form.ShowDialog(this);

            if (form.Cadastrado) { await Assincrono.TaskAsyncAndAwaitAsync(comboDadosVeiculo_Placa_Carregar()); }
        }
        private async void comboDadosVeiculo_Placa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo_ComboBox.Selecionado(comboDadosVeiculo_Placa)) && (!CarregandoDados))
            {
                using(VeiculoPlacaController veiculoPlacaController = new VeiculoPlacaController(this.MeuDbContext(), this._notifier))
                {
                    var veiculoPlaca = await veiculoPlacaController.GetById((Guid)comboDadosVeiculo_Placa.SelectedValue);

                    if (veiculoPlaca != null)
                    {
                        if (!Funcao.Nulo(veiculoPlaca.EstadoId)) comboDadosVeiculo_UF.SelectedValue = veiculoPlaca.EstadoId;
                        textDadosVeiculo_Renavam.Text = veiculoPlaca.Renavam;
                        if (!Funcao.Nulo(veiculoPlaca.TipoCarroceria)) comboDadosVeiculo_TipoCarroceria.SelectedValue = veiculoPlaca.TipoCarroceria;
                        if (!Funcao.Nulo(veiculoPlaca.TipoRodado)) comboDadosVeiculo_TipoRodado.SelectedValue = veiculoPlaca.TipoRodado;
                        numericDadosVeiculo_CapacidadeKG.Value = (decimal)veiculoPlaca.CapacidadeKG;
                        numericDadosVeiculo_TaraKG.Value = (decimal)veiculoPlaca.TaraKG;
                        numericDadosVeiculo_CapacidadeM3.Value = (decimal)veiculoPlaca.CapacidadeM3;

                        checkDadosVeiculoVceiuloTerceiro_Sim.Checked = (!String.IsNullOrEmpty(veiculoPlaca.Terceiros_NomeProprietario));
                        if (!Funcao.Nulo(veiculoPlaca.Terceiros_TipoProprietario)) comboDadosVeiculoVeiculoTerceiro_TipoProprietario.SelectedValue = veiculoPlaca.Terceiros_TipoProprietario;
                        textDadosVeiculoVeiculoTerceiro_IEProprietario.Text = veiculoPlaca.Terceiros_IEProprietario;
                        textDadosVeiculoVeiculoTerceiro_RNTCProprietario.Text = veiculoPlaca.Terceiros_RNTRCProprietario;
                        textDadosVeiculoVeiculoTerceiro_CPFCNPJProprietario.Text = veiculoPlaca.Terceiros_CPFCNPJProprietario;
                        textDadosVeiculoVeiculoTerceiro_NomeProprietario.Text = veiculoPlaca.Terceiros_NomeProprietario;
                        if (!Funcao.Nulo(veiculoPlaca.Terceiros_EstadoProprietarioId)) comboDadosVeiculoVeiculoTerceiro_UFProprietario.SelectedValue = veiculoPlaca.Terceiros_EstadoProprietarioId;
                    }
                }
            }
        }
        private void comboCondutor_CPFCNPJCondutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!Combo_ComboBox.Selecionado(comboCondutor_CPFCNPJCondutor))  && (!CarregandoDados))
            { textCondutor_NomeCondutor.Text = ""; }
            else
            { textCondutor_NomeCondutor.Text = ((CodigoDescricaoComboViewModel)comboCondutor_CPFCNPJCondutor.SelectedItem).Descricao; }
        }
        private async void botacaoCondutor_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmCadastroCondutor>();
            form.ShowDialog(this);

            if (form.Cadastrado) { await Assincrono.TaskAsyncAndAwaitAsync(comboCondutor_Carregar()); }            
        }
    }
}