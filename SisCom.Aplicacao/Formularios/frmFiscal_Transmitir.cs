using DFe.Classes.Flags;
using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Entidade.Enum;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grid_DataGridView;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_Transmitir : FormMain
    {
        const int gridNotaFiscalSaida_Id = 0;
        const int gridNotaFiscalSaida_Chk = 1;
        const int gridNotaFiscalSaida_Sinal = 2;
        const int gridNotaFiscalSaida_DataEmissao = 3;
        const int gridNotaFiscalSaida_Numero = 4;
        const int gridNotaFiscalSaida_Destinatario = 5;
        const int gridNotaFiscalSaida_CPF_CNPJ = 6;
        const int gridNotaFiscalSaida_Status = 7;
        const int gridNotaFiscalSaida_RetornoSefaz = 8;
        const int gridNotaFiscalSaida_BTN_Transmitir = 9;
        const int gridNotaFiscalSaida_BTN_EMail = 10;
        const int gridNotaFiscalSaida_BTN_Cancelar = 11;
        const int gridNotaFiscalSaida_BTN_CartaCorrecao = 12;
        const int gridNotaFiscalSaida_BTN_GerarXML = 13;
        const int gridNotaFiscalSaida_ID_Status = 14;

        public frmFiscal_Transmitir(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();

            labelValidade.Text = labelValidade.Text + " " + Fiscal.Certificado_DataExpiracao();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<bool> Inicializar()
        {
            try
            {
                Combo_ComboBox.Formatar(comboStatusVenda, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Status));

                Grid_DataGridView.User_Formatar(gridNotaFiscalSaida, false);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "...", Grid_DataGridView.TipoColuna.CheckBox, Tamanho: 30, readOnly: false);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "", Tamanho: 30);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "Data de Emissão", Tamanho: 120);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "Número", Tamanho: 60);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "Destinatário", Tamanho: 300);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "CPF/CNPJ", Tamanho: 100);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "Status", Tamanho: 100);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "", "Retorno Sefaz", Tamanho: 150);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "Transmitir", "Transmitir", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "E-Mail", "E-Mail", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "Cancelar", "Cancelar", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "C. Correção", "C. Correção", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "Gerar XML", "Gerar XML", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.User_ColunaAdicionar(gridNotaFiscalSaida, "ID_Status", "ID_Status", Tamanho: 0);

                comboStatusVenda.SelectedValue = NF_Status.Todos;

                await Carregar(NF_Status.Todos, DateTime.Now.Date, DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Nota Fiscal - Transmitir - Inicializar", ex);
            }

            return true;
        }
        async Task<bool> Carregar(Entidade.Enum.NF_Status? statusId, DateTime? dataInicial, DateTime? dataFinal)
        {
            int linha = 0;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalSaidaViewModel> ret;

                gridNotaFiscalSaida.Rows.Clear();

                if ((statusId != null) || (dataInicial != null) || (dataFinal != null))
                {
                    DateTime dataI = (DateTime)dataInicial;
                    DateTime dataF = (DateTime)dataFinal;

                    ret = await notaFiscalSaidaController.Pesquisar(order: o => o.DataEmissao,
                                                predicate: p => (((statusId == null) || (p.Status == statusId) || (statusId == NF_Status.Todos)) &&
                                                                 (p.DataEmissao.Date >= dataI.Date) &&
                                                                 (p.DataEmissao.Date <= dataF.Date)),
                                                i => i.NaturezaOperacao, c => c.Cliente); ;
                }
                else
                {
                    ret = await notaFiscalSaidaController.Pesquisar(order: o => o.DataEmissao,
                                                                    predicate: p => ((p.Status == Entidade.Enum.NF_Status.Pendente) ||
                                                                                     (p.Status == Entidade.Enum.NF_Status.Finalizada)),
                                                                    i => i.NaturezaOperacao, c => c.Cliente);
                }

                foreach (var item in ret)
                {
                    if (item.Cliente == null)
                    {
                        linha = Grid_DataGridView.User_LinhaAdicionar(gridNotaFiscalSaida,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Id,
                                                                                                                                              Valor = item.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_DataEmissao,
                                                                                                                                              Valor = item.DataEmissao },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Numero,
                                                                                                                                              Valor = item.NotaFiscal },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Status,
                                                                                                                                              Valor = item.Status.GetDescription() },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_RetornoSefaz,
                                                                                                                                              Valor = item.RetornoSefaz },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_ID_Status,
                                                                                                                                              Valor = item.Status.GetHashCode() }}).Index;
                    }
                    else
                    {
                        linha = Grid_DataGridView.User_LinhaAdicionar(gridNotaFiscalSaida,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Id,
                                                                                                                                              Valor = item.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_DataEmissao,
                                                                                                                                              Valor = item.DataEmissao },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Numero,
                                                                                                                                              Valor = item.NotaFiscal },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Destinatario,
                                                                                                                                              Valor = item.Cliente.Nome },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_CPF_CNPJ,
                                                                                                                                              Valor = item.Cliente.CNPJ_CPF },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Status,
                                                                                                                                              Valor = item.Status.GetDescription() },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_RetornoSefaz,
                                                                                                                                              Valor = item.RetornoSefaz },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_ID_Status,
                                                                                                                                              Valor = item.Status.GetHashCode() }}).Index;
                    }

                    switch (item.Status)
                    {
                        case NF_Status.Finalizada:
                            gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusPendente.BackColor;
                            break;
                        case NF_Status.Pendente:
                            gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusRejeicao.BackColor;
                            break;
                        case NF_Status.Cancelado:
                            gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusCancelado.BackColor;
                            break;
                        case NF_Status.Denegada:
                            gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusDenegado.BackColor;
                            break;
                        case NF_Status.Inutilizada:
                        case NF_Status.Transmitida:
                            gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusAutorizado.BackColor;
                            break;
                    }
                }
            }

            return true;
        }

        private void gridNotaFiscalSaida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridNotaFiscalSaida(e);
        }

        async void GridNotaFiscalSaida(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 &&
                (gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_Id].Value != null) &&
                (gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_CPF_CNPJ].Value.ToString() != ""))
            {
                switch (e.ColumnIndex)
                {
                    case gridNotaFiscalSaida_BTN_Transmitir:
                    case gridNotaFiscalSaida_BTN_GerarXML:
                        {
                            await Transmitir(row: gridNotaFiscalSaida.Rows[e.RowIndex],
                                             id: Guid.Parse(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_Id].Value.ToString()),
                                             somenteGerarXML: e.ColumnIndex == gridNotaFiscalSaida_BTN_GerarXML,
                                             exibirmensagem: true);
                        }

                        if (e.ColumnIndex == gridNotaFiscalSaida_BTN_GerarXML)
                        { CaixaMensagem.Informacao("XML gerado"); }
                        else
                        { Carregar((NF_Status?)comboStatusVenda.SelectedValue, dateDataVendaInicial.Value, dateDataVendaFinal.Value); }

                        break;
                    case gridNotaFiscalSaida_BTN_EMail:
                        break;
                    case gridNotaFiscalSaida_BTN_CartaCorrecao:
                    case gridNotaFiscalSaida_BTN_Cancelar:
                        Cancamento_CartaCorrecao(Guid.Parse(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_Id].Value.ToString()), e.ColumnIndex);
                        { Carregar((NF_Status?)comboStatusVenda.SelectedValue, dateDataVendaInicial.Value, dateDataVendaFinal.Value); }
                        break;
                }
            }
        }

        async Task Cancamento_CartaCorrecao(Guid id, int coluna)
        {
            NotaFiscalSaidaViewModel notaFiscalSaida;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                var notaFiscalSaidas = await notaFiscalSaidaController.PesquisarCompleto(p => p.Id == id);
                notaFiscalSaida = notaFiscalSaidas.FirstOrDefault();
            }

            if (notaFiscalSaida.Status != NF_Status.Transmitida)
            {
                CaixaMensagem.Informacao("Nota fiscal não transmitida");
                return;
            }

            switch (coluna)
            {
                case gridNotaFiscalSaida_BTN_CartaCorrecao:
                    var formCartaCorrecao = this.ServiceProvider().GetRequiredService<frmFiscal_CartaCorrecao>();
                    formCartaCorrecao.notaFiscalSaida = notaFiscalSaida;
                    formCartaCorrecao.ShowDialog();
                    formCartaCorrecao.Dispose();
                    break;
                case gridNotaFiscalSaida_BTN_Cancelar:
                    var formCancelamento = this.ServiceProvider().GetRequiredService<frmFiscal_Cancelamento>();
                    formCancelamento.notaFiscalSaida = notaFiscalSaida;
                    formCancelamento.ShowDialog();
                    formCancelamento.Dispose();
                    break;
            }
        }

        async Task Transmitir(DataGridViewRow row, Guid id, bool somenteGerarXML = false, string xml = "", bool exibirmensagem = false)
        {
            try
            {
                NotaFiscalSaidaSerieViewModel notaFiscalSaidaSerieViewModel = new NotaFiscalSaidaSerieViewModel();
                NotaFiscalSaidaViewModel notaFiscalSaidaViewModel = new NotaFiscalSaidaViewModel();
                IEnumerable<NotaFiscalSaidaViewModel> notaFiscalSaidaViewModels;
                IEnumerable<NotaFiscalSaidaMercadoriaViewModel> notaFiscalSaidaMercadoria;
                IEnumerable<NotaFiscalSaidaPagamentoViewModel> notaFiscalSaidaPagamento = new List<NotaFiscalSaidaPagamentoViewModel>();
                IEnumerable<NotaFiscalSaidaReferenciaViewModel> notaFiscalSaidaReferencia = new List<NotaFiscalSaidaReferenciaViewModel>();
                string sDS_PATH_XML = "";
                bool bImpressaoNCFe = false;

                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                {
                    notaFiscalSaidaViewModels = await notaFiscalSaidaController.PesquisarCompleto(p => p.Id == id);
                    notaFiscalSaidaViewModel = notaFiscalSaidaViewModels.FirstOrDefault();
                }
                if (notaFiscalSaidaViewModel.Status == NF_Status.Cancelado)
                {
                    if (exibirmensagem) CaixaMensagem.Informacao("Nota fiscal cancelada");
                }
                else if (notaFiscalSaidaViewModel.Status == NF_Status.Transmitida)
                {
                    if (exibirmensagem) CaixaMensagem.Informacao("Nota fiscal já transmitida");
                }
                else if (notaFiscalSaidaViewModel.Status == NF_Status.Denegada)
                {
                    if (exibirmensagem) CaixaMensagem.Informacao("Nota fiscal denegada");
                }
                else
                {
                    using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
                    {
                        notaFiscalSaidaMercadoria = await notaFiscalSaidaMercadoriaController.PesquisarId(notaFiscalSaidaViewModel.Id);
                    }
                    using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(this.MeuDbContext(), this._notifier))
                    {
                        var notaFiscalSaidaSerieViewModels = await notaFiscalSaidaSerieController.PesquisarSerie(notaFiscalSaidaViewModel.Serie);
                        notaFiscalSaidaSerieViewModel = notaFiscalSaidaSerieViewModels.FirstOrDefault();
                    }
                    using (NotaFiscalSaidaPagamentoController notaFiscalSaidaPagamentoController = new NotaFiscalSaidaPagamentoController(this.MeuDbContext(), this._notifier))
                    {
                        notaFiscalSaidaPagamento = await notaFiscalSaidaPagamentoController.PesquisarId(notaFiscalSaidaViewModel.Id);
                    }

                    notaFiscalSaidaViewModel.TransmitirEnderecoCliente = (notaFiscalSaidaViewModel.Cliente_Endereco != null);

                    foreach (NotaFiscalSaidaViewModel item in notaFiscalSaidaViewModels)
                    {
                        notaFiscalSaidaViewModel = item;
                        notaFiscalSaidaReferencia = Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(item.NotaFiscalSaidaReferencia);

                        if (Validacao.Data_AdicionarHora(notaFiscalSaidaViewModel.DataSaida, notaFiscalSaidaViewModel.HoraEmissao) < DateTime.Now)
                        {
                            DateTime data = DateTime.Now.AddMinutes(2);
                            notaFiscalSaidaViewModel.DataSaida = data.Date;
                            notaFiscalSaidaViewModel.HoraEmissao = $"{data.Hour.ToString("00")}:{data.Minute.ToString("00")}";
                        }

                        Fiscal.Fiscal_DocumentoFiscal_Transmitir(eModeloDocumento: ModeloDocumento.NFe,
                                                                 notaFiscalSaidaViewModel: ref notaFiscalSaidaViewModel,
                                                                 notaFiscalSaidaMercadoriaViewModels: ref notaFiscalSaidaMercadoria,
                                                                 notaFiscalSaidaPagamentoViewModels: ref notaFiscalSaidaPagamento,
                                                                 notaFiscalSaidaReferenciaViewModels: ref notaFiscalSaidaReferencia,
                                                                 notaFiscalSaidaSerieViewModel: ref notaFiscalSaidaSerieViewModel,
                                                                 sDS_PATH_XML: ref sDS_PATH_XML,
                                                                 bImpressaoNCFe: ref bImpressaoNCFe,
                                                                 bImprimirDanfeNFe: false,
                                                                 SomenteGerarXML: somenteGerarXML,
                                                                 xml: xml);
                    }

                    if (!somenteGerarXML)
                    {
                        if (row != null)
                        {
                            row.Cells[gridNotaFiscalSaida_RetornoSefaz].Value = notaFiscalSaidaViewModel.RetornoSefaz;
                        }

                        using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                        {
                            notaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade = null;
                            notaFiscalSaidaViewModel.Empresa = null;
                            notaFiscalSaidaViewModel.NaturezaOperacao = null;
                            notaFiscalSaidaViewModel.NotaFiscalFinalidade = null;
                            notaFiscalSaidaViewModel.Cliente = null;
                            notaFiscalSaidaViewModel.Transportadora = null;
                            notaFiscalSaidaViewModel.Transportadora_UF = null;
                            notaFiscalSaidaViewModel.InformacoesComplementaresInteresseContribuinte_UF = null;
                            notaFiscalSaidaViewModel.NotaFiscalSaidaMercadoria = null;
                            notaFiscalSaidaViewModel.NotaFiscalSaidaPagamento = null;
                            notaFiscalSaidaViewModel.NotaFiscalSaidaReferencia = null;
                            notaFiscalSaidaViewModel.NotaFiscalSaidaObservacao = null;

                            await notaFiscalSaidaController.Atualizar(notaFiscalSaidaViewModel.Id, notaFiscalSaidaViewModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CaixaMensagem.Informacao("Fiscal Transmitir", ex);
            }
        }

        private void gridNotaFiscalSaida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == gridNotaFiscalSaida_RetornoSefaz) && (e.RowIndex > -1))
            {
                if (!Funcoes._Classes.Funcao.NuloString(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    frmTexto frmTexto = new frmTexto();
                    frmTexto.Texto = gridNotaFiscalSaida.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    frmTexto.ShowDialog();
                }
            }
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            if ((Funcoes._Classes.Funcao.NuloData(dateDataVendaInicial.Value)) || (Funcoes._Classes.Funcao.NuloData(dateDataVendaFinal.Value)))
            {
                CaixaMensagem.Informacao("Informe um período válido");
                return;
            }
            if (dateDataVendaInicial.Value.Date > dateDataVendaFinal.Value.Date)
            {
                CaixaMensagem.Informacao("Informe um período válido");
                return;
            }

            if (Combo_ComboBox.Selecionado(comboStatusVenda))
            { Carregar((NF_Status?)comboStatusVenda.SelectedValue, dateDataVendaInicial.Value, dateDataVendaFinal.Value); }
            else
            { Carregar(null, dateDataVendaInicial.Value, dateDataVendaFinal.Value); }
        }

        private void botaoLimparFiltros_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        void Limpar()
        {
            comboStatusVenda.SelectedIndex = -1;
            dateDataVendaInicial.Value = DateTime.Now.Date;
            dateDataVendaFinal.Value = DateTime.Now.Date;
        }

        private void comboStatusVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                comboStatusVenda.SelectedIndex = -1;
        }

        private void botaoTransmitirNotas_Click(object sender, EventArgs e)
        {
            TransmitirNotas();
        }

        async Task TransmitirNotas()
        {
            foreach (DataGridViewRow row in gridNotaFiscalSaida.Rows)
            {
                if ((row.Cells[gridNotaFiscalSaida_Chk].Value != null) && ((bool)row.Cells[gridNotaFiscalSaida_Chk].Value))
                {
                    if (((NF_Status)Convert.ToInt16(row.Cells[gridNotaFiscalSaida_ID_Status].Value) == NF_Status.Pendente) ||
                        ((NF_Status)Convert.ToInt16(row.Cells[gridNotaFiscalSaida_ID_Status].Value) == NF_Status.Finalizada))
                    {
                        await Transmitir(row: row,
                                         id: (Guid)row.Cells[gridNotaFiscalSaida_Id].Value,
                                         exibirmensagem: true);
                    }
                }
            }
        }

        private void botaoMarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridNotaFiscalSaida.Rows)
            {
                if (row.Cells[gridNotaFiscalSaida_Id].Value != null)
                    row.Cells[gridNotaFiscalSaida_Chk].Value = true;
            }
        }

        private void botaoDesmarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridNotaFiscalSaida.Rows)
            {
                row.Cells[gridNotaFiscalSaida_Chk].Value = false;
            }
        }

        private void botaoImprimirNota_Click(object sender, EventArgs e)
        {
            if (gridNotaFiscalSaida.CurrentRow != null)
            {
                Fiscal.Fiscal_Visualizar((Guid)gridNotaFiscalSaida.CurrentRow.Cells[gridNotaFiscalSaida_Id].Value, this.MeuDbContext(), this._notifier);
            }
            else
            {
                CaixaMensagem.Informacao("Selecione a nota a ser impressa");
            }
        }

        private void botaoCancelarNota_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_Cancelamento>();
            form.ShowDialog();
        }

        private void botaoCartaCorrecaoNota_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_CartaCorrecao>();
            form.ShowDialog();
        }

        private void botaoTransmitirXML_Click(object sender, EventArgs e)
        {
            TransmitirXML();
        }

        private async Task TransmitirXML()
        {
            string xml = "";
            var nfe = Zeus.CarregarNFE_XML(ref xml);

            string sChaveNFe = Fiscal.Fiscal_ChaveNFe(nfe.NFe);

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                var notafiscalsaida = await notaFiscalSaidaController.PesquisarChave(sChaveNFe);

                if ((notafiscalsaida == null) || (!notafiscalsaida.Any()))
                {
                    CaixaMensagem.Informacao("Nota fiscal não encontrada");
                }
                else
                {
                    await Transmitir(row: null,
                                     id: notafiscalsaida.FirstOrDefault().Id,
                                     somenteGerarXML: false,
                                     xml: xml,
                                     exibirmensagem: true);
                }
            }
        }

        private async void uscTipoEmissor_TipoEmissorSelecionado(object sender, TipoEmissor tipoEmissor)
        {
            var empresa = await (new EmpresaController(this.MeuDbContext(), this._notifier)).GetById(Declaracoes.dados_Empresa_Id);

            empresa.NuvemFiscal_TipoEmirssor = tipoEmissor;

            await (new EmpresaController(this.MeuDbContext(), this._notifier)).Atualizar(empresa.Id, empresa);
        }
    }
}