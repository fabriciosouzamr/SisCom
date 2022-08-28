using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Formularios;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using static SisCom.Aplicacao.Classes.Declaracoes;

namespace SisCom.Aplicacao
{
    public partial class frmFiscal_NuvemFiscal_Manifestar : FormMain
    {
        const int grdNotaFiscal_Color = 0;
        const int grdNotaFiscal_NFe = 1;
        const int grdNotaFiscal_Serie = 2;
        const int grdNotaFiscal_DHEmissao = 3;
        const int grdNotaFiscal_VlrNFe = 4;
        const int grdNotaFiscal_ManifestacaoAtual = 5;
        const int grdNotaFiscal_PedidoManifestacao = 6;
        const int grdNotaFiscal_RetornoSefaz = 7;
        const int grdNotaFiscal_CNPJ = 8;
        const int grdNotaFiscal_ChaveAcesso = 9;

        public List<NotaFiscalManifestar> NotasFiscalManifestar;
        public string NuvemFiscal_SerialNumber;

        public frmFiscal_NuvemFiscal_Manifestar(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
        }

        async void Inicializar()
        {
            Combo_ComboBox.Formatar(comboTipoManifestacao, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoManifestar));

            Grid_DataGridView.DataGridView_Formatar(gridNotaFiscal);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "", Grid_DataGridView.TipoColuna.Texto, 30);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Serie");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "D/H Emissão");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Vlr. NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "ManifestacaoAtual");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "PedidoManifestacao");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "RetornoSefaz");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "CNPJ");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "ChaveAcesso");
        }

        public void Carregar()
        {
            if (gridNotaFiscal.Columns.Count == 0) { Inicializar();  }

            foreach (NotaFiscalManifestar notaFiscalManifestar in NotasFiscalManifestar)
            {
                Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
                                                              new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
                                                                                                                             Valor = notaFiscalManifestar.NFe },
                                                                                              new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Serie,
                                                                                                                             Valor = notaFiscalManifestar.Serie },
                                                                                              new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
                                                                                                                             Valor = notaFiscalManifestar.Emissao },
                                                                                              new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
                                                                                                                             Valor = notaFiscalManifestar.Valor },
                                                                                              new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
                                                                                                                             Valor = notaFiscalManifestar.ChaveAcesso },
                                                                                              new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ,
                                                                                                                             Valor = notaFiscalManifestar.CNPJ }})
                    .Cells[grdNotaFiscal_Color].Style.BackColor = imgAguardandoManifestacao.BackColor;
            }
        }

        private void frmFiscal_NuvemFiscal_Manifestar_Load(object sender, EventArgs e)
        {
        }

        private void botaoManifestar_Click(object sender, EventArgs e)
        {
            if (!Combo_ComboBox.Selecionado(comboTipoManifestacao))
            {
                CaixaMensagem.Informacao("Selecione o tipo de manifestação");
                return;
            }

            foreach (DataGridViewRow row in gridNotaFiscal.Rows)
            {
                var retorno = Zeus.Manifestar(row.Cells[grdNotaFiscal_ChaveAcesso].Value.ToString(), 
                                              row.Cells[grdNotaFiscal_CNPJ].Value.ToString(),
                                              ((int)(TipoManifestar)comboTipoManifestacao.SelectedValue).ToString(),
                                              NuvemFiscal_SerialNumber);
                if (retorno.RetEvento.InfEvento.CStat == 128)
                {
                    row.Cells[grdNotaFiscal_Color].Style.BackColor = imgManifestadaSucesso.BackColor;
                }
                else
                {
                    row.Cells[grdNotaFiscal_Color].Style.BackColor = imgManifestacaoRefeitadaSEFAZ.BackColor;
                }
                row.Cells[grdNotaFiscal_RetornoSefaz].Value = retorno.RetEvento.InfEvento.XMotivo;
            }
        }
    }
}