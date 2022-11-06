﻿using Funcoes.Interfaces;
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

        NotaFiscalSaidaViewModel notaFiscalSaida;

        public frmFiscal_CartaCorrecao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            Grid_DataGridView.DataGridView_Formatar(gridItens, AllowUserToAddRows: true, AllowUserToDeleteRows: true);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridItens, "Itens", "Itens", Tamanho: 100);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridItens, "Descrição", "Descrição", Tamanho: 300);
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
            Grid_DataGridView.DataGridView_LinhaLimpar(gridItens);
        }

        private async void botaoBuscar_Click(object sender, EventArgs e)
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

        private void botaoImprimir_Click(object sender, EventArgs e)
        {

        }

        private async void botaoConfimar_Click(object sender, EventArgs e)
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
                if (Texto.NuloString(row.Cells[gridItens_Descricao].Value).Trim() == "")
                {
                    CaixaMensagem.Informacao("Não foi informado nenhuma descrição para o item " + row.Cells[gridItens_Nome].Value);
                    return;
                }

                strings.Append($"{Texto.NuloString(row.Cells[gridItens_Descricao].Value).Trim()} : {Texto.NuloString(row.Cells[gridItens_Descricao].Value).Trim()}");
            }

            Fiscal.Fiscal_CartaCorrecao(notaFiscalSaida, strings.ToString());

            using (NotaFiscalSaidaController notaFiscalSaidaController = new NotaFiscalSaidaController(this.MeuDbContext(), this._notifier))
            {
                await notaFiscalSaidaController.Atualizar(notaFiscalSaida.Id, notaFiscalSaida);
            }
        }

        private void checkItem_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                Grid_DataGridView.DataGridView_LinhaAdicionar(gridItens, new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridItens_Nome,
                                                                                                                                         Valor = checkBox.Text },
                                                                                                          new Grid_DataGridView.Coluna { Indice = gridItens_Descricao,
                                                                                                                                         Valor = "" }});
            }
            else
            {
                foreach (DataGridViewRow row in gridItens.Rows)
                {
                    if (row.Cells[gridItens_Nome].ToString() == checkBox.Text)
                    {
                        gridItens.Rows.Remove(row);
                        break;
                    }
                }
            }
        }
    }
}
