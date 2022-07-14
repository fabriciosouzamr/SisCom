using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using SisCom.Aplicacao.Classes;
using System.IO;
using DFe.Utils;
using NFe.Classes;
using NFe.Servicos.Retorno;

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
        const int grdNotaFiscal_Importar = 8;
        const int grdNotaFiscal_Conteudo = 9;

        public string sXML = "";

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
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Contéudo", Tamanho: 0);
        }

        private void botaoConsultarNotas_Click(object sender, EventArgs e)
        {
            //Consultar();
            Consultar_Carregar();
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

            string sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = Declaracoes.Externos_SisCom_Aplicacao_FW;
            pInfo.Arguments = "GO 46268326000103 1 417B2205054DEFE4";
            Process p = Process.Start(pInfo);
            p.WaitForInputIdle();
            p.WaitForExit();
            MessageBox.Show("Code continuing...");

            //ZeusZW.NuvemFiscal_SerialNumber = ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NuvemFiscal_SerialNumber;
            //ZeusZW.PATH_SCHEMAS = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
            //ZeusZW.PATH_SCHEMAS = "C://Fabricio//Pessoal//Projetos//SisMattos//Schemas";

            //var empresa = await (new EmpresaController(this.MeuDbContext(), this._notifier)).GetById((Guid)comboEmpresa.SelectedValue);

            //retorno = SisCom.Aplicacao.Classes.Zeus.NuvemFiscal(empresa.Endereco.End_Cidade.Estado.Codigo,
            //                             empresa.CNPJ,
            //                             sNSU,
            //                             sChave);

            //if ((retorno != null) && (retorno.Retorno.loteDistDFeInt != null))
            //{
            //    foreach (loteDistDFeInt item in retorno.Retorno.loteDistDFeInt)
            //    {
            //        if (item.NfeProc != null)
            //        {
            //            Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
            //                                                          new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
            //                                                                                                                         Valor = item.NfeProc.NFe.infNFe.Id.Substring(3) },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
            //                                                                                                                         Valor = item.NfeProc.NFe.infNFe.ide.cNF},
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ_CPF,
            //                                                                                                                         Valor = String.IsNullOrEmpty(item.NfeProc.NFe.infNFe.emit.CNPJ)? item.NfeProc.NFe.infNFe.emit.CPF : item.NfeProc.NFe.infNFe.emit.CNPJ },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Nome,
            //                                                                                                                         Valor = item.NfeProc.NFe.infNFe.emit.xNome },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
            //                                                                                                                         Valor = item.NfeProc.NFe.infNFe.ide.dhEmi,
            //                                                                                                                         Formato = Grid_DataGridView.FormatoColuna.Data },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
            //                                                                                                                         Valor = item.NfeProc.NFe.infNFe.total.ICMSTot.vNF,
            //                                                                                                                         Formato = Grid_DataGridView.FormatoColuna.Valor },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Protocolo,
            //                                                                                                                         Valor = item.NfeProc.protNFe.infProt.nProt },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_SituacaoNFe,
            //                                                                                                                         Valor = item.NfeProc.protNFe.infProt.xMotivo }});
            //        }
            //        else if (item.ResNFe != null)
            //        {
            //            Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
            //                                                          new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
            //                                                                                                                         Valor = item.ResNFe.chNFe },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
            //                                                                                                                         Valor = item.ResNFe.chNFe },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ_CPF,
            //                                                                                                                         Valor = String.IsNullOrEmpty(item.ResNFe.CNPJ)? item.ResNFe.CPF : item.ResNFe.CNPJ },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Nome,
            //                                                                                                                         Valor = item.ResNFe.xNome },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
            //                                                                                                                         Valor = item.ResNFe.dhEmi,
            //                                                                                                                         Formato = Grid_DataGridView.FormatoColuna.Data },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
            //                                                                                                                         Valor = item.ResNFe.vNF,
            //                                                                                                                         Formato = Grid_DataGridView.FormatoColuna.Valor },
            //                                                                                          new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Protocolo,
            //                                                                                                                         Valor = item.ResNFe.nProt }});

            //        }
            //    }
            //}
        }
        void Consultar_Carregar()
        {
            try
            {
                string[] diretorios = Directory.GetFiles(Declaracoes.Externos_Path_NuvemFiscal, "*.xml");

                Console.WriteLine("Diretórios:");
                foreach (string arquivo in diretorios)
                {
                    string conteudo = System.IO.File.ReadAllText(arquivo);
                    var chNFe = string.Empty;
                    var cNFe = string.Empty;
                    var CNPJ_CPF = string.Empty;
                    var Nome = string.Empty;
                    DateTime DHEmissao = new DateTime();
                    decimal VlrNFe = 0;
                    string Protocolo = string.Empty;
                    string SituacaoNFe = string.Empty;

                    if (conteudo.StartsWith("<resNFe"))
                    {
                        var retConteudo =
                            FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.resNFe>(conteudo);
                        chNFe = retConteudo.chNFe;
                        CNPJ_CPF = retConteudo.CNPJ;
                        Nome = retConteudo.xNome;
                        DHEmissao = retConteudo.dhEmi;
                        VlrNFe = retConteudo.vNF;
                        Protocolo = retConteudo.nProt.ToString();
                    }
                    else if (conteudo.StartsWith("<procEventoNFe"))
                    {
                        var procEventoNFeConteudo =
                            FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.procEventoNFe>(conteudo);
                        chNFe = procEventoNFeConteudo.retEvento.infEvento.chNFe;
                        CNPJ_CPF = procEventoNFeConteudo.retEvento.infEvento.CNPJDest;
                    }
                    else if (conteudo.StartsWith("<resEvento"))
                    {
                        var resEventoConteudo =
                            FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.resEvento>(conteudo);
                        chNFe = resEventoConteudo.chNFe;
                    }
                    else if (conteudo.StartsWith("<nfeProc"))
                    {
                        var resEventoConteudo =
                            FuncoesXml.XmlStringParaClasse<nfeProc>(conteudo);
                        chNFe = resEventoConteudo.protNFe.infProt.chNFe;
                        cNFe = resEventoConteudo.NFe.infNFe.ide.cNF;
                        if (resEventoConteudo.NFe.infNFe.emit.CNPJ == null) { CNPJ_CPF = resEventoConteudo.NFe.infNFe.emit.CPF; } else { CNPJ_CPF = resEventoConteudo.NFe.infNFe.emit.CNPJ; }
                        Nome = resEventoConteudo.NFe.infNFe.emit.xNome;
                        DHEmissao = resEventoConteudo.NFe.infNFe.ide.dEmi;
                        VlrNFe = resEventoConteudo.NFe.infNFe.total.ICMSTot.vNF;
                        Protocolo = resEventoConteudo.protNFe.infProt.nProt;
                        SituacaoNFe = "NF-e";
                    }

                    if (SituacaoNFe != String.Empty)
                    {
                        Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
                                                                      new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
                                                                                                                                     Valor = chNFe },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_NFe,
                                                                                                                                     Valor = cNFe },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_CNPJ_CPF,
                                                                                                                                     Valor = CNPJ_CPF },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Nome,
                                                                                                                                     Valor = Nome },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_DHEmissao,
                                                                                                                                     Valor = DHEmissao,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Data },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_VlrNFe,
                                                                                                                                     Valor = VlrNFe,
                                                                                                                                     Formato = Grid_DataGridView.FormatoColuna.Valor },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Protocolo,
                                                                                                                                     Valor = Protocolo },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_SituacaoNFe,
                                                                                                                                     Valor = SituacaoNFe },
                                                                                                      new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_Conteudo,
                                                                                                                                     Valor = conteudo }});
                    }
                }
            }
            catch (Exception Ex)
            {
                CaixaMensagem.Informacao(Ex.Message);
            }
        }

        private void gridNotaFiscal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == grdNotaFiscal_Importar) && (e.RowIndex > 0))
            {
                sXML = gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_Conteudo].Value.ToString();
                Close();
            }
        }
    }
}
