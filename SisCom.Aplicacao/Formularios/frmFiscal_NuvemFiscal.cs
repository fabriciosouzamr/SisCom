using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using NFe.Servicos.Retorno;
using NFe.Classes.Servicos.DistribuicaoDFe;
using ZeusZW = SisCom.Aplicacao_FW.Classes.Zeus;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NuvemFiscal : FormMain
    {
        const int grdNotaFiscal_ChaveAcesso = 0;
        const int grdNotaFiscal_NFe = 1;
        const int grdNotaFiscal_CNPJ_CPF = 2;
        const int grdNotaFiscal_Nome = 3;
        const int grdNotaFiscal_DHEmissao = 4;
        const int grdNotaFiscal_VlrNFe = 5;
        const int grdNotaFiscal_Protocolo = 6;
        const int grdNotaFiscal_SituacaoNFe = 7;

        EmpresaViewModel empresa;

        enum TipoManifestacao
        {
            [Description("Todas")]
            Codigo = 0,
            [Description("Manifestação")]
            Manifestacao = 1,
            [Description("Sem manifestação")]
            SemManifestacao = 2,
            [Description("Desconhecida")]
            Desconhecida = 3,
            [Description("Confirmação da Operação")]
            ConfirmacaoOperacao = 4,
            [Description("Ciência da Operação")]
            CienciaOperacao = 5,
            [Description("Desconhecimento da Operação")]
            DesconhecimentoOperacao = 6,
            [Description("Operação não Realizada")]
            OperacaoRealizada = 7
        }

        enum DataPesquisa
        {
            [Description("Data Pesquisa")]
            DataPesquisa = 0,
            [Description("Data Emissão")]
            DataEmissao = 1
        }

        enum TipoNSU
        {
            [Description("A partir do último NSU")]
            APartirUltimoNSU = 0,
            [Description("Último 3 meses")]
            Ultimo3Meses = 1
        }
        
        enum TLS
        {
            [Description("TLS 1.1")]
            TLS_11 = 0,
            [Description("TLS 2.0")]
            TLS_20 = 1
        }

        RetornoNfeDistDFeInt retorno;

        public frmFiscal_NuvemFiscal(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        async void Inicializar()
        {
            Combo_ComboBox.Formatar(comboTipoManifestacao, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoManifestacao));
            Combo_ComboBox.Formatar(comboTipoData, "", "", ComboBoxStyle.DropDownList, null, typeof(DataPesquisa));
            Combo_ComboBox.Formatar(comboTipoNSU, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoNSU));
            Combo_ComboBox.Formatar(comboTipoTLS, "", "", ComboBoxStyle.DropDownList, null, typeof(TLS));

            datePeriodoInicial.Value = DateTime.Now.Date;
            datePeriodoFinal.Value = DateTime.Now.Date;

            Combo_ComboBox.Formatar(comboEmpresa,
                                    "ID", "Unidade",
                                    ComboBoxStyle.DropDownList,
                                    await(new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));

            Grid_DataGridView.DataGridView_Formatar(gridNotaFiscal);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Chave de Acesso");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "CNPJ/CPF");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Nome");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "D/H Emissão");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Vlr. NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Protocolo");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Situação NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Importar", Grid_DataGridView.TipoColuna.Button);
        }

        private void botaoConsultarNotas_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        async void Consultar()
        {
            if (comboEmpresa.SelectedIndex == -1)
            {
                CaixaMensagem.Informacao("Selecione a empresa");
                return;
            }

            string sNSU = "";
            string sChave = "";

            if (string.IsNullOrEmpty(textChaveNFe.Text))
            { 
                sNSU = ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NSU;
                sNSU = string.IsNullOrEmpty(sNSU) ? "1" : sNSU;
            }
            else
            { sChave = textChaveNFe.Text; }

            ZeusZW.NuvemFiscal_SerialNumber = ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NuvemFiscal_SerialNumber;
            ZeusZW.PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
            ZeusZW.PATH_SCHEMAS = "C://Fabricio//Pessoal//Projetos//SisMattos//Schemas";

            var empresa = await (new EmpresaController(this.MeuDbContext(), this._notifier)).GetById((Guid)comboEmpresa.SelectedValue);

            retorno = SisCom.Aplicacao.Classes.Zeus.NuvemFiscal(empresa.Endereco.End_Cidade.Estado.Codigo,
                                         empresa.CNPJ,
                                         sNSU,
                                         sChave);

            if ((retorno != null) && (retorno.Retorno.loteDistDFeInt != null))
            {
                foreach (loteDistDFeInt item in retorno.Retorno.loteDistDFeInt)
                {
                    if (item.NfeProc != null)
                    {
                        Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
                                                                      new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
                                                                                                                                     Valor = item.NfeProc.NFe.infNFe.Id.Substring(3) },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
                                                                                                                                     Valor = item.NfeProc.NFe.infNFe.ide.cNF},
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ_CPF,
                                                                                                                                     Valor = String.IsNullOrEmpty(item.NfeProc.NFe.infNFe.emit.CNPJ)? item.NfeProc.NFe.infNFe.emit.CPF : item.NfeProc.NFe.infNFe.emit.CNPJ },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Nome,
                                                                                                                                     Valor = item.NfeProc.NFe.infNFe.emit.xNome },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
                                                                                                                                     Valor = item.NfeProc.NFe.infNFe.ide.dhEmi,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Data },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
                                                                                                                                     Valor = item.NfeProc.NFe.infNFe.total.ICMSTot.vNF,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Protocolo,
                                                                                                                                     Valor = item.NfeProc.protNFe.infProt.nProt },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_SituacaoNFe,
                                                                                                                                     Valor = item.NfeProc.protNFe.infProt.xMotivo }});
                    }
                    else if (item.ResNFe != null)
                    {
                        Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
                                                                      new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
                                                                                                                                     Valor = item.ResNFe.chNFe },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
                                                                                                                                     Valor = item.ResNFe.chNFe },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ_CPF,
                                                                                                                                     Valor = String.IsNullOrEmpty(item.ResNFe.CNPJ)? item.ResNFe.CPF : item.ResNFe.CNPJ },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Nome,
                                                                                                                                     Valor = item.ResNFe.xNome },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
                                                                                                                                     Valor = item.ResNFe.dhEmi,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Data },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
                                                                                                                                     Valor = item.ResNFe.vNF,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Protocolo,
                                                                                                                                     Valor = item.ResNFe.nProt }});

                    }
                }
            }
        }
    }
}
