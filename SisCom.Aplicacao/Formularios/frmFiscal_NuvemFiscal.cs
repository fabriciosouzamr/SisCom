using DFe.Utils;
using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NFe.Classes;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisCom.Aplicacao.Classes.Declaracoes;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NuvemFiscal : FormMain
    {
        const int grdNotaFiscal_NFe = 0;
        const int grdNotaFiscal_Serie = 1;
        const int grdNotaFiscal_ChaveAcesso = 2;
        const int grdNotaFiscal_CNPJ_CPF = 3;
        const int grdNotaFiscal_IE = 4;
        const int grdNotaFiscal_RazaoSocial = 5;
        const int grdNotaFiscal_DHEmissao = 6;
        const int grdNotaFiscal_VlrNFe = 7;
        const int grdNotaFiscal_SituacaoNFe = 8;
        const int grdNotaFiscal_StatusManifestacao = 9;
        const int grdNotaFiscal_Chk = 10;
        const int grdNotaFiscal_Importar = 11;
        const int grdNotaFiscal_Manifestar = 12;
        const int grdNotaFiscal_Conteudo = 13;

        const string StatusSemManifestar = "Sem manifestar";

        public string sXML = "";

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

        List<NotaFiscalManifestar> notasFiscalManifestar;

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
                                    await (new EmpresaController(this.MeuDbContext(), this._notifier)).ComboNuvemFiscal(p => p.Unidade));

            Grid_DataGridView.DataGridView_Formatar(gridNotaFiscal);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Série");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Chave de Acesso");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "CNPJ/CPF");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "IE");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Razão Social");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "D/H Emissão");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Vlr. NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Situação NF-e");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Manifestação");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "...", Grid_DataGridView.TipoColuna.CheckBox);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Importar", Grid_DataGridView.TipoColuna.Button);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Manifestar", Grid_DataGridView.TipoColuna.Button);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscal, "", "Conteudo", Tamanho: 0);
        }

        private void botaoConsultarNotas_Click(object sender, EventArgs e)
        {
            if (!Combo_ComboBox.Selecionado(comboEmpresa))
            {
                CaixaMensagem.Informacao("Selecione a empresa para pesquisa");
                return;
            }

            ConsultarNotas();
        }

        async void ConsultarNotas()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(Consultar());
            Consultar_Carregar();
        }

        async Task<bool> Consultar()
        {
            string sNSU = "";
            string sChave = "";

            if (string.IsNullOrEmpty(textChaveNFe.Text))
            {
                sNSU = ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NSU;
                sNSU = string.IsNullOrEmpty(sNSU) ? "1" : sNSU;

                var retorno = Zeus.NuvemFiscal(((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).Estado.Codigo,
                                               ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).CNPJ,
                                               sNSU,
                                               ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NuvemFiscal_SerialNumber);

                await (new EmpresaController(this.MeuDbContext(), this._notifier)).AtualizarNSU((Guid)comboEmpresa.SelectedValue, retorno.ultNSU.ToString());

                if (retorno.xMotivo.IndexOf("Rejeicao:") != -1)
                {
                    CaixaMensagem.Informacao(retorno.xMotivo);
                }
            }
            else
            { sChave = textChaveNFe.Text; }

            return true;
        }
        void Consultar_Carregar()
        {
            try
            {
                gridNotaFiscal.Rows.Clear();

                string[] diretorios = Directory.GetFiles(Declaracoes.Externos_Path_NuvemFiscal, "*.xml");

                foreach (string arquivo in diretorios)
                {
                    string conteudo = System.IO.File.ReadAllText(arquivo);
                    var cNFe = string.Empty;
                    var cSerie = string.Empty;
                    var chNFe = string.Empty;
                    var CNPJ_CPF = string.Empty;
                    var IE = string.Empty;
                    var Nome = string.Empty;
                    DateTime DHEmissao = new DateTime();
                    decimal VlrNFe = -1;
                    string SituacaoNFe = string.Empty;
                    string SituacaoMaifestacao = string.Empty;
                    int linha = -1;

                    if (conteudo.StartsWith("<resNFe"))
                    {
                        var retConteudo = FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.resNFe>(conteudo);
                        chNFe = retConteudo.chNFe;
                        CNPJ_CPF = retConteudo.CNPJ;
                        Nome = retConteudo.xNome;
                        DHEmissao = retConteudo.dhEmi;
                        VlrNFe = retConteudo.vNF;
                        conteudo = String.Empty;
                    }
                    else if (conteudo.StartsWith("<procEventoNFe"))
                    {
                        var procEventoNFeConteudo = FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.procEventoNFe>(conteudo);
                        if (procEventoNFeConteudo.retEvento != null)
                        {
                            chNFe = procEventoNFeConteudo.retEvento.infEvento.chNFe;
                            CNPJ_CPF = procEventoNFeConteudo.retEvento.infEvento.CNPJDest;

                            if ((procEventoNFeConteudo.evento.infEvento.tpEvento == TipoManifestar.TeMdCienciaDaOperacao.GetHashCode()) ||
                                (procEventoNFeConteudo.evento.infEvento.tpEvento == TipoManifestar.TeMdConfirmacaoDaOperacao.GetHashCode()) ||
                                (procEventoNFeConteudo.evento.infEvento.tpEvento == TipoManifestar.TeMdDesconhecimentoDaOperacao.GetHashCode()) ||
                                (procEventoNFeConteudo.evento.infEvento.tpEvento == TipoManifestar.TeMdOperacaoNaoRealizada.GetHashCode()))
                            {
                                SituacaoMaifestacao = procEventoNFeConteudo.evento.infEvento.detEvento.descEvento;
                            }
                        }
                        conteudo = String.Empty;
                    }
                    else if (conteudo.StartsWith("<resEvento"))
                    {
                        var resEventoConteudo = FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.resEvento>(conteudo);
                        chNFe = resEventoConteudo.chNFe;
                        conteudo = String.Empty;
                    }
                    else if (conteudo.StartsWith("<nfeProc"))
                    {
                        var resEventoConteudo = FuncoesXml.XmlStringParaClasse<nfeProc>(conteudo);
                        chNFe = resEventoConteudo.protNFe.infProt.chNFe;
                        cNFe = resEventoConteudo.NFe.infNFe.ide.cNF;
                        cSerie = resEventoConteudo.NFe.infNFe.ide.serie.ToString();
                        if (resEventoConteudo.NFe.infNFe.emit.CNPJ == null) { CNPJ_CPF = resEventoConteudo.NFe.infNFe.emit.CPF; } else { CNPJ_CPF = resEventoConteudo.NFe.infNFe.emit.CNPJ; }
                        if (resEventoConteudo.NFe.infNFe.emit.IE != null) IE = resEventoConteudo.NFe.infNFe.emit.IE.ToString();
                        Nome = resEventoConteudo.NFe.infNFe.emit.xNome;
                        DHEmissao = resEventoConteudo.NFe.infNFe.ide.dEmi;
                        VlrNFe = resEventoConteudo.NFe.infNFe.total.ICMSTot.vNF;
                        SituacaoNFe = resEventoConteudo.protNFe.infProt.xMotivo;
                    }

                    if (chNFe != String.Empty)
                    {
                        foreach (DataGridViewRow row in gridNotaFiscal.Rows)
                        {
                            if (row.Cells[grdNotaFiscal_ChaveAcesso].Value.ToString() == chNFe)
                            {
                                linha = row.Index;
                                break;
                            }
                        }

                        if (linha == -1)
                        {
                            linha = Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscal,
                                                                                  new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_ChaveAcesso,
                                                                                                                                                 Valor = chNFe },
                                                                                                                  new Grid_DataGridView.Coluna { Indice = grdNotaFiscal_StatusManifestacao,
                                                                                                                                                 Valor = StatusSemManifestar }}).Index;
                            gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_Importar].Value = "Importar";
                            gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_Manifestar].Value = "Manifestar";
                        }

                        if (linha != -1)
                        {
                            if (cNFe != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_NFe].Value = cNFe;
                            if (cSerie != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_Serie].Value = cSerie;
                            if (chNFe != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_ChaveAcesso].Value = chNFe;
                            if (CNPJ_CPF != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_CNPJ_CPF].Value = CNPJ_CPF;
                            if (IE != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_IE].Value = IE;
                            if (Nome != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_RazaoSocial].Value = Nome;
                            if (DHEmissao != new DateTime()) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_DHEmissao].Value = DHEmissao;
                            if (VlrNFe != -1) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_VlrNFe].Value = VlrNFe;
                            if (SituacaoNFe != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_SituacaoNFe].Value = SituacaoNFe;
                            if (SituacaoMaifestacao != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_StatusManifestacao].Value = SituacaoMaifestacao;
                            if (conteudo != String.Empty) gridNotaFiscal.Rows[linha].Cells[grdNotaFiscal_Conteudo].Value = conteudo;
                        }
                    }
                }

                int Cont = -1;

                while (Cont < gridNotaFiscal.RowCount - 1)
                {
                    foreach (DataGridViewRow row in gridNotaFiscal.Rows)
                    {
                        try
                        {
                            Cont = row.Index;
                            if (Funcao.NuloParaString(row.Cells[grdNotaFiscal_NFe].Value) == "")
                            {
                                Cont = -1;
                                gridNotaFiscal.Rows.Remove(row);
                                break;
                            }
                        }
                        catch (Exception Ex)
                        {
                            Cont = Cont;
                        }
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
            if ((e.ColumnIndex == grdNotaFiscal_Manifestar) && (e.RowIndex > 0))
            {
                if (StatusSemManifestar == gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_StatusManifestacao].Value.ToString())
                {
                    notasFiscalManifestar = new List<NotaFiscalManifestar>();
                    notasFiscalManifestar.Add(new NotaFiscalManifestar
                    {
                        Emissao = Convert.ToDateTime(gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_DHEmissao].Value),
                        Valor = Convert.ToDouble(gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_VlrNFe].Value),
                        NFe = gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_VlrNFe].Value.ToString(),
                        Serie = gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_VlrNFe].Value.ToString(),
                        ChaveAcesso = gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_ChaveAcesso].Value.ToString(),
                        CNPJ = gridNotaFiscal.Rows[e.RowIndex].Cells[grdNotaFiscal_CNPJ_CPF].Value.ToString()
                    });
                    Manifestar();
                }
                else
                {
                    CaixaMensagem.Informacao("NF-e já manifestada");
                }
            }
        }

        private void botaoDownload_Click(object sender, EventArgs e)
        {
            string sDiretorio = Arquivo.SelecionarDiretorio();
            string sArquivo = "";
            bool selecionado = false;

            foreach (DataGridViewRow row in gridNotaFiscal.Rows)
            {
                if ((row.Cells[grdNotaFiscal_Chk].Value != null) && ((bool)row.Cells[grdNotaFiscal_Chk].Value == true))
                {
                    selecionado = true;
                    sArquivo = Arquivo.DiretorioMontarCaminhoArquivo(sDiretorio, row.Cells[grdNotaFiscal_ChaveAcesso].Value.ToString() + ".xml");

                    FileStream fs = new FileStream(sArquivo, FileMode.Create);

                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(row.Cells[grdNotaFiscal_Conteudo].Value);
                    writer.Close();
                }
            }

            if (selecionado) { CaixaMensagem.Informacao("Download realizados"); } else { CaixaMensagem.Informacao("Não foi selecionado nenhum registro para download"); }
        }

        private void botaoImprimirDanfe_Click(object sender, EventArgs e)
        {
            if (gridNotaFiscal.SelectedRows.Count != 0)
            { Fiscal.GerarDanfe(gridNotaFiscal.SelectedRows[0].Cells[grdNotaFiscal_Conteudo].Value.ToString(), false, true); }
            else
            { CaixaMensagem.Informacao("Selecione o registro a ser impresso"); }
        }

        private void botaoManifestar_Click(object sender, EventArgs e)
        {
            bool selecionado = false;
            bool temmanifestada = false;

            notasFiscalManifestar = new List<NotaFiscalManifestar>();

            foreach (DataGridViewRow row in gridNotaFiscal.Rows)
            {
                if ((row.Cells[grdNotaFiscal_Chk].Value != null) && ((bool)row.Cells[grdNotaFiscal_Chk].Value == true))
                {
                    selecionado = true;
                    temmanifestada = ((temmanifestada) || (row.Cells[grdNotaFiscal_StatusManifestacao].Value.ToString() != StatusSemManifestar));

                    if (row.Cells[grdNotaFiscal_StatusManifestacao].Value.ToString() == StatusSemManifestar)
                    {
                        notasFiscalManifestar.Add(new NotaFiscalManifestar
                        {
                            Emissao = Convert.ToDateTime(row.Cells[grdNotaFiscal_DHEmissao].Value),
                            Valor = Convert.ToDouble(row.Cells[grdNotaFiscal_VlrNFe].Value),
                            NFe = row.Cells[grdNotaFiscal_VlrNFe].Value.ToString(),
                            Serie = row.Cells[grdNotaFiscal_VlrNFe].Value.ToString(),
                            ChaveAcesso = row.Cells[grdNotaFiscal_ChaveAcesso].Value.ToString(),
                            CNPJ = row.Cells[grdNotaFiscal_CNPJ_CPF].Value.ToString()
                        });
                    }
                }
            }

            if (temmanifestada) { CaixaMensagem.Informacao("Foi retirada(s) a(s) nota(s) já manifestada(s) do(s) selecionado(s)"); }
            if (selecionado) { Manifestar(); } else { CaixaMensagem.Informacao("Não foi selecionado nenhum registro para download"); }
        }

        private void Manifestar()
        {
            if (!Combo_ComboBox.Selecionado(comboEmpresa))
            {
                CaixaMensagem.Informacao("Selecione a empresa para manifestar");
            }

            using (frmFiscal_NuvemFiscal_Manifestar form = this.ServiceProvider().GetRequiredService<frmFiscal_NuvemFiscal_Manifestar>())
            {
                form.NotasFiscalManifestar = notasFiscalManifestar;
                form.NuvemFiscal_SerialNumber = ((EmpresaNuvemFiscalComboViewModel)comboEmpresa.SelectedItem).NuvemFiscal_SerialNumber;
                form.Carregar();
                form.ShowDialog(this);
            }
        }

        private void cmdSelecionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridNotaFiscal.Rows)
            {
                row.Cells[grdNotaFiscal_Chk].Value = true;
            }
        }

        private void frmFiscal_NuvemFiscal_Load(object sender, EventArgs e)
        {
            datePeriodoInicial.Value = datePeriodoInicial.MinDate;
            datePeriodoFinal.Value = datePeriodoFinal.MaxDate;
        }

        private void botaoFiltrarNotas_Click(object sender, EventArgs e)
        {
            Consultar_Carregar();

            if ((Combo_ComboBox.Selecionado(comboTipoManifestacao)) ||
                (textChaveNFe.Text.Trim() != "") ||
                (textNFe.Text.Trim() != "") ||
                (!Funcao.NuloData(datePeriodoInicial.Value)) ||
                (!Funcao.NuloData(datePeriodoFinal.Value)))
            {
                int Cont = -1;

                while (Cont < gridNotaFiscal.RowCount - 1)
                {
                    foreach (DataGridViewRow row in gridNotaFiscal.Rows)
                    {
                        try
                        {
                            bool Valido = true;
                            Cont = row.Index;

                            if ((Valido) && (Combo_ComboBox.Selecionado(comboTipoManifestacao))) Valido = (Funcao.NuloParaString(row.Cells[grdNotaFiscal_StatusManifestacao].Value) == comboTipoManifestacao.SelectedText);
                            if ((Valido) && (textChaveNFe.Text.Trim() != "")) Valido = (Funcao.NuloParaString(row.Cells[grdNotaFiscal_ChaveAcesso].Value) == textChaveNFe.Text.Trim());
                            if ((Valido) && (textNFe.Text.Trim() != "")) Valido = (Funcao.NuloParaString(row.Cells[grdNotaFiscal_NFe].Value) == textNFe.Text.Trim());
                            if ((Valido)) Valido = ((Funcao.StringParaData(row.Cells[grdNotaFiscal_DHEmissao].Value.ToString(), true) >= datePeriodoInicial.Value) &&
                                                    (Funcao.StringParaData(row.Cells[grdNotaFiscal_DHEmissao].Value.ToString(), true) <= datePeriodoFinal.Value));

                            if (!Valido)
                            {
                                Cont = -1;
                                gridNotaFiscal.Rows.Remove(row);
                                break;
                            }
                        }
                        catch (Exception Ex)
                        {
                            Cont = Cont;
                        }
                    }
                }
            }
            else
            {
                CaixaMensagem.Informacao("É preciso informar alguma informação para o filtro");
            }
        }
    }
}