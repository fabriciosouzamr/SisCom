using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Texto = Funcoes._Classes.Texto;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_CartaCorrecao : FormMain
    {
        const int gridItens_Nome = 0;
        const int gridItens_Descricao = 1;

        public NotaFiscalSaidaViewModel notaFiscalSaida;

        public frmFiscal_CartaCorrecao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            Grid_DataGridView.User_Formatar(gridItens, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.User_ColunaAdicionar(gridItens, "Itens", "Itens", Tamanho: 100);
            Grid_DataGridView.User_ColunaAdicionar(gridItens, "Descrição", "Descrição", Tamanho: 600, readOnly: false);
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
            checkItem_CodigoCFOP.Checked = false;
            checkItem_DataEmissao.Checked = false;
            checkItem_DataSaida.Checked = false;
            checkItem_DescricaoCFOP.Checked = false;
            checkItem_DescricaoProduto.Checked = false;
            checkItem_Endereco.Checked = false;
            checkItem_EnderecoCobranca.Checked = false;
            checkItem_EnderecoTransportador.Checked = false;
            checkItem_Estado.Checked = false;
            checkItem_FormaPagamento.Checked = false;
            checkItem_InscricaoEstadual.Checked = false;
            checkItem_Municipio.Checked = false;
            checkItem_NomeTransportador.Checked = false;
            checkItem_NumeroEndereco.Checked = false;
            checkItem_Outros.Checked = false;
            checkItem_PesoBrutoPesoLiquido.Checked = false;
            checkItem_RazaoSocial.Checked = false;
            checkItem_UnidadeMedidaProduto.Checked = false;
            checkItem_Vencimento.Checked = false;
            checkItem_Volume.Checked = false;
            Grid_DataGridView.User_LinhaLimpar(gridItens);
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

        private void botaoImprimir_Click(object sender, EventArgs e)
        {

        }

        private void botaoConfimar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        async void Confirmar()
        {
            StringBuilder strings = new StringBuilder();

            if (String.IsNullOrEmpty(textChaveAcesso.Text))
            {
                CaixaMensagem.Informacao("É preciso buscar a nota fiscal a ser corrgida!");
                return;
            }
            if (gridItens.Rows.Count == 0)
            {
                CaixaMensagem.Informacao("Não foi selecionado nenhum item para enviar para correção");
                return;
            }
            foreach (DataGridViewRow row in gridItens.Rows)
            {
                if (Texto.NuloString(row.Cells[gridItens_Nome].Value).Trim() != "")
                {
                    if (Texto.NuloString(row.Cells[gridItens_Descricao].Value).Trim() == "")
                    {
                        CaixaMensagem.Informacao("Não foi informado nenhuma descrição para o item " + row.Cells[gridItens_Nome].Value);
                        return;
                    }

                    strings.Append($"{Texto.NuloString(row.Cells[gridItens_Nome].Value).Trim()} : {Texto.NuloString(row.Cells[gridItens_Descricao].Value).Trim()}");
                }
            }

            notaFiscalSaida.NumeroLoteEnvioSefaz++;

            if (Fiscal.Fiscal_CartaCorrecao(ref notaFiscalSaida, strings.ToString()))
            {
                using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
                {
                    notaFiscalSaida.DescricaoCartaCorrecao = strings.ToString();
                    notaFiscalSaida.DataCartaCorrecao = DateTime.Now;

                    await notaFiscalSaidaController.Atualizar(notaFiscalSaida.Id, notaFiscalSaida);
                }

                CaixaMensagem.Informacao("Carta de correção envaida");
            }
        }

        private void checkItem_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                Grid_DataGridView.User_LinhaAdicionar(gridItens, new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridItens_Nome,
                                                                                                                                         Valor = checkBox.Text },
                                                                                                          new Grid_DataGridView.Coluna { Indice = gridItens_Descricao,
                                                                                                                                         Valor = "" }});
            }
            else
            {
                foreach (DataGridViewRow row in gridItens.Rows)
                {
                    if (row.Cells[gridItens_Nome].Value.ToString() == checkBox.Text)
                    {
                        gridItens.Rows.Remove(row);
                        break;
                    }
                }
            }
        }

        private void frmFiscal_CartaCorrecao_Load(object sender, EventArgs e)
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
