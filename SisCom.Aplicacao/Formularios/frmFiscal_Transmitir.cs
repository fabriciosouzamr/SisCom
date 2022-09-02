using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_Transmitir : FormMain
    {
        const int gridNotaFiscalSaida_Sinal = 0;
        const int gridNotaFiscalSaida_Numero = 1;
        const int gridNotaFiscalSaida_Destinatario = 2;
        const int gridNotaFiscalSaida_CPF_CNPJ = 3;
        const int gridNotaFiscalSaida_Status = 4;
        const int gridNotaFiscalSaida_RetornoSefaz = 5;
        const int gridNotaFiscalSaida_BTN_Transmitir = 6;
        const int gridNotaFiscalSaida_BTN_EMail = 7;

        public frmFiscal_Transmitir(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<bool> Inicializar()
        {
            try
            {
                //Detalhe de Estoque
                Grid_DataGridView.DataGridView_Formatar(gridNotaFiscalSaida, true);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "", Tamanho: 30);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Número", Tamanho: 50);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Destinatário", Tamanho: 300);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "CPF/CNPJ", Tamanho: 100);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Status", Tamanho: 100);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Retorno Sefaz", Tamanho: 300);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "Transmitir", "Transmitir", Grid_DataGridView.TipoColuna.Button, 80);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "E-Mail", "E-Mail", Grid_DataGridView.TipoColuna.Button, 80);

                await Carregar();
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }

            return true;
        }

        async Task<bool> Carregar()
        {
            int linha = 0;

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NotaFiscalSaidaViewModel> ret = await notaFiscalSaidaController.Pesquisar(order: o => o.DataEmissao,
                                                                                                      predicate: p => p.Status == Entidade.Enum.NF_Status.Aberta,
                                                                                                      i =>  i.NaturezaOperacao, c => c.Cliente );

                foreach (var item in ret)
                {
                    linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscalSaida,
                                                                          new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Numero,
                                                                                                                                          Valor = item.NotaFiscal },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Destinatario,
                                                                                                                                          Valor = item.Cliente.Nome },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_CPF_CNPJ,
                                                                                                                                          Valor = item.Cliente.CNPJ_CPF },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_CPF_CNPJ,
                                                                                                                                          Valor = "Espera" }}).Index;
                    gridNotaFiscalSaida.Rows[linha].Cells[gridNotaFiscalSaida_Sinal].Style.BackColor = panelStatusAutorizado.BackColor;
                }
            }

            return true;
        }

        private void gridNotaFiscalSaida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case gridNotaFiscalSaida_BTN_Transmitir:
                    break;
                case gridNotaFiscalSaida_BTN_EMail:
                    break;
            }
        }
    }
}