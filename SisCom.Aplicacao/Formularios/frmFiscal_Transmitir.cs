using DFe.Classes.Flags;
using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
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
        const int gridNotaFiscalSaida_Numero = 3;
        const int gridNotaFiscalSaida_Destinatario = 4;
        const int gridNotaFiscalSaida_CPF_CNPJ = 5;
        const int gridNotaFiscalSaida_Status = 6;
        const int gridNotaFiscalSaida_RetornoSefaz = 7;
        const int gridNotaFiscalSaida_BTN_Transmitir = 8;
        const int gridNotaFiscalSaida_BTN_EMail = 9;
        const int gridNotaFiscalSaida_BTN_Cancelar = 10;
        const int gridNotaFiscalSaida_BTN_CartaCorrecao = 11;
        const int gridNotaFiscalSaida_ID_Status = 12;

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

                //Detalhe de Estoque
                Grid_DataGridView.DataGridView_Formatar(gridNotaFiscalSaida, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "ID", "ID", Tamanho: 0);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "...", Grid_DataGridView.TipoColuna.CheckBox, Tamanho: 30, readOnly: false);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "", Tamanho: 30);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Número", Tamanho: 50);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Destinatário", Tamanho: 300);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "CPF/CNPJ", Tamanho: 100);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Status", Tamanho: 100);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Retorno Sefaz", Tamanho: 150);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "Transmitir", "Transmitir", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "E-Mail", "E-Mail", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "Cancelar", "Cancelar", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "C. Correção", "C. Correção", Grid_DataGridView.TipoColuna.Button, 70);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "ID_Status", "ID_Status", Tamanho: 0);

                await Carregar(null, null, null);
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

            return true;
        }

        async Task<bool> Carregar(Entidade.Enum.NF_Status? statusId, DateTime? dataInicial, DateTime? dataFinal)
        {
            int linha = 0;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalSaidaViewModel> ret;

                Grid_DataGridView.DataGridView_LinhaLimpar(gridNotaFiscalSaida);

                if ((statusId != null) || (dataInicial != null) || (dataFinal != null))
                {
                    DateTime dataI = (DateTime)dataInicial;
                    DateTime dataF = (DateTime)dataFinal;

                    ret = await notaFiscalSaidaController.Pesquisar(order: o => o.DataEmissao,
                                                predicate: p => (((statusId == null) || (p.Status == statusId)) && 
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
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscalSaida,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Id,
                                                                                                                                              Valor = item.Id },
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
                        linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscalSaida,
                                                                              new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Id,
                                                                                                                                              Valor = item.Id },
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
            switch (e.ColumnIndex)
            {
                case gridNotaFiscalSaida_BTN_Transmitir:
                    {
                        if (((NF_Status)Convert.ToInt16(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_ID_Status].Value) == NF_Status.Pendente) ||
                            ((NF_Status)Convert.ToInt16(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_ID_Status].Value) == NF_Status.Finalizada))
                        {
                            await Transmitir(gridNotaFiscalSaida.Rows[e.RowIndex], Guid.Parse(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_Id].Value.ToString()));
                        }
                        else
                        {
                            CaixaMensagem.Informacao("Essa venda não pode ser mais transmitida");
                        }
                    }

                    break;
                case gridNotaFiscalSaida_BTN_EMail:
                    break;
                case gridNotaFiscalSaida_BTN_CartaCorrecao:
                case gridNotaFiscalSaida_BTN_Cancelar:
                    Cancamento_CartaCorrecao(Guid.Parse(gridNotaFiscalSaida.Rows[e.RowIndex].Cells[gridNotaFiscalSaida_Id].Value.ToString()), e.ColumnIndex);
                    break;
            }
        }

        async void Cancamento_CartaCorrecao(Guid id, int coluna)
        {
            NotaFiscalSaidaViewModel notaFiscalSaida;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                notaFiscalSaida = (NotaFiscalSaidaViewModel)await notaFiscalSaidaController.PesquisarId(id);
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

        async Task Transmitir(DataGridViewRow row, Guid id)
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
                notaFiscalSaidaViewModels = await notaFiscalSaidaController.PesquisarCompletoId(id);
                notaFiscalSaidaViewModel = notaFiscalSaidaViewModels.FirstOrDefault();
            }
            using (NotaFiscalSaidaMercadoriaController notaFiscalSaidaMercadoriaController = new NotaFiscalSaidaMercadoriaController(this.MeuDbContext(), this._notifier))
            {
                notaFiscalSaidaMercadoria = await notaFiscalSaidaMercadoriaController.PesquisarId(notaFiscalSaidaViewModel.Id);
            }
            using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(this.MeuDbContext(), this._notifier))
            {
                var notaFiscalSaidaSerieViewModels = await notaFiscalSaidaSerieController.PesquisarSerie(notaFiscalSaidaViewModel.Serie);
                notaFiscalSaidaSerieViewModel = notaFiscalSaidaSerieViewModels.FirstOrDefault();
            }

            notaFiscalSaidaViewModel.TransmitirEnderecoCliente = (notaFiscalSaidaViewModel.Cliente_Endereco != null);

            foreach (NotaFiscalSaidaViewModel item in notaFiscalSaidaViewModels)
            {
                notaFiscalSaidaViewModel = item;
                notaFiscalSaidaPagamento = Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(item.NotaFiscalSaidaPagamento);
                notaFiscalSaidaReferencia = Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(item.NotaFiscalSaidaReferencia);

                Fiscal.Fiscal_DocumentoFiscal_Transmitir(ModeloDocumento.NFe,
                                                         ref notaFiscalSaidaViewModel,
                                                         ref notaFiscalSaidaMercadoria,
                                                         ref notaFiscalSaidaPagamento,
                                                         ref notaFiscalSaidaReferencia,
                                                         ref notaFiscalSaidaSerieViewModel,
                                                         ref sDS_PATH_XML,
                                                         ref bImpressaoNCFe,
                                                         false);
            }

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

            using (NotaFiscalSaidaSerieController notaFiscalSaidaSerieController = new NotaFiscalSaidaSerieController(this.MeuDbContext(), this._notifier))
            {
                await notaFiscalSaidaSerieController.Atualizar(notaFiscalSaidaSerieViewModel.Id, notaFiscalSaidaSerieViewModel);
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
                        await Transmitir(row, (Guid)row.Cells[gridNotaFiscalSaida_Id].Value);
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
    }
}