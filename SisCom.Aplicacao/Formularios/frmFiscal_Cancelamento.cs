using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Linq;
using System.Text;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_Cancelamento : FormMain
    {
        public NotaFiscalSaidaViewModel notaFiscalSaida;

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
            if (notaFiscalSaida == null)
            { CaixaMensagem.Informacao("É preciso buscar a nota fiscal"); }
            else
            { Fiscal.Fiscal_Visualizar(notaFiscalSaida.Id, this.MeuDbContext(), this._notifier); }            
        }

        private void botaoConfimar_Click(object sender, EventArgs e)
        {
            Confimar();
        }

        async void Confimar()
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

            notaFiscalSaida.NumeroLoteEnvioSefaz++;

            if (Fiscal.Fiscal_Cancelamento(ref notaFiscalSaida, richJustificativa.Text, strings.ToString()))
            {
                botaoConfimar.Enabled = false;

                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                {
                    notaFiscalSaida.DataCancelamento = DateTime.Now;
                    notaFiscalSaida.Status = Entidade.Enum.NF_Status.Cancelado;
                    notaFiscalSaida.DescricaoCancelamento = richJustificativa.Text;

                    await notaFiscalSaidaController.Atualizar(notaFiscalSaida.Id, notaFiscalSaida);
                }

                CaixaMensagem.Informacao("Cancelamento efeutado");
            }
        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        async void Buscar()
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
                    var notaFiscalSaidas = await notaFiscalSaidaController.PesquisarCompleto(p => p.NotaFiscal == textNumeroNotaFiscal.Text);

                    if (notaFiscalSaidas == null)
                    {
                        CaixaMensagem.Informacao("Nota fiscal não encontrada");
                    }
                    else
                    {
                        notaFiscalSaida = notaFiscalSaidas.FirstOrDefault();

                        if (notaFiscalSaida.Status != Entidade.Enum.NF_Status.Transmitida)
                        {
                            CaixaMensagem.Informacao("A nota fiscall precisa está com o status de transmitida");
                            return;
                        }

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

        private void frmFiscal_Cancelamento_Load(object sender, EventArgs e)
        {
            if (notaFiscalSaida != null)
            {
                textNumeroNotaFiscal.Text = notaFiscalSaida.NotaFiscal;
                textChaveAcesso.Text = notaFiscalSaida.CodigoChaveAcesso;
                textSerie.Text = notaFiscalSaida.Serie;
                textCliente.Text = notaFiscalSaida.Cliente.Nome;
            }
        }
    }
}
