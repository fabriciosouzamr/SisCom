using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_Cancelamento : FormMain
    {
        NotaFiscalSaidaViewModel notaFiscalSaida;

        public frmFiscal_Cancelamento(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Limpar()
        {
            textChaveAcesso.Text = "";
            textCliente.Text = "";
            textSerie.Text = "";
            richJustificativa.Clear();
        }

        private void botaoImprimir_Click(object sender, EventArgs e)
        {

        }

        private async Task botaoConfimar_ClickAsync(object sender, EventArgs e)
        {
            StringBuilder strings = new StringBuilder();

            if (String.IsNullOrEmpty(textChaveAcesso.Text))
            {
                CaixaMensagem.Informacao("É preciso buscar a nota fiscal a ser cancelada!");
                return;
            }
            if (String.IsNullOrEmpty(richJustificativa.Text))
            {
                CaixaMensagem.Informacao("É preciso informar a justificativa!");
                return;
            }

            Fiscal.Fiscal_CartaCorrecao(notaFiscalSaida, strings.ToString());

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                await notaFiscalSaidaController.Atualizar(notaFiscalSaida.Id, notaFiscalSaida);
            }
        }

        private async Task botaoBuscar_ClickAsync(object sender, EventArgs e)
        {
            Limpar();

            if (String.IsNullOrEmpty(textNumeroNotaFiscal.Text))
            {
                CaixaMensagem.Informacao("Informe o número da nota fiscal");
            }
            else
            {
                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                {
                    var notaFiscalSaidas = await notaFiscalSaidaController.PesquisarNotaFiscal(textNumeroNotaFiscal.Text);

                    if (notaFiscalSaidas == null)
                    {
                        CaixaMensagem.Informacao("Nota fiscal não saída");
                    }
                    else
                    {
                        notaFiscalSaida = notaFiscalSaidas.FirstOrDefault();

                        if (notaFiscalSaida.Status == Entidade.Enum.NF_Status.Transmitida)
                        {
                            textChaveAcesso.Text = notaFiscalSaida.CodigoChaveAcesso;
                            textSerie.Text = notaFiscalSaida.Serie;
                            textCliente.Text = notaFiscalSaida.Cliente.Nome;
                        }
                        else
                        {
                            CaixaMensagem.Informacao("Nota fiscal não transmitida");
                        }
                    }
                }
            }
        }
    }
}
