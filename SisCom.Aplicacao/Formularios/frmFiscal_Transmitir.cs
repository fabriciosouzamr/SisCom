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
        const int gridNotaFiscalSaida_NumeroNotaFiscal = 0;
        const int gridNotaFiscalSaida_Destinatario = 1;
        const int gridNotaFiscalSaida_DataEmissao = 2;
        const int gridNotaFiscalSaida_NaturezaOperacao = 3;

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
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Número Nota Fiscal");
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Destinatário", Tamanho: 300);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Data de Emissão", Tamanho: 100);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "", "Natureza de Operação", Tamanho: 300);
                Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalSaida, "Transmitir", "Transmitir", Grid_DataGridView.TipoColuna.Button, 80);

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
                                                                          new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_NumeroNotaFiscal,
                                                                                                                                          Valor = item.NumeroNotaFiscalSaida },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_Destinatario,
                                                                                                                                          Valor = item.Cliente.Nome },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_DataEmissao,
                                                                                                                                          Valor = item.DataEmissao },
                                                                                                           new Grid_DataGridView.Coluna { Indice = gridNotaFiscalSaida_NaturezaOperacao,
                                                                                                                                          Valor = item.NaturezaOperacao.Nome }}).Index;
                }
            }

            return true;
        }
    }
}
