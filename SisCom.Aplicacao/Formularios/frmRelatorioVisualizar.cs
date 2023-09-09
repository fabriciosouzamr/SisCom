using Microsoft.Reporting.WinForms;
using SisCom.Aplicacao.Classes;
using SisCom.Entidade.Enum;
using System;
using System.Data;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public enum TipoRelatorio
    {
        CartaCorrecao,
        NotaFiscalEntrada
    }

    public partial class frmRelatorioVisualizar : Form
    {
        public TipoRelatorio tipoRelatorio;
        public String[] param;

        public frmRelatorioVisualizar()
        {
            InitializeComponent();
        }

        private void frmRelatorioVisualizar_Load(object sender, EventArgs e)
        {
            DataTable data;
            string sql;

            switch(tipoRelatorio)
            {
                case TipoRelatorio.CartaCorrecao:
                    {
                        sql = "SELECT NFS.Modelo," +
                                     "NFS.Serie," +
                                     "NFS.NotaFiscal," +
                                     "NFS.DataCartaCorrecao," +
                                     "NFS.CodigoChaveAcesso," +
                                     "NFS.DataTransmissao," +
                                     "NFS.NumeroLoteEnvioSefaz," +
                                     "NFS.DescricaoCartaCorrecao," +
                                     "NFS.RetornoCartaCorrecao," +
                                     "NFS.Protocolo," +
                                     "EMP.RazaoSocial Emit_RazaoSocial," +
                                     "EMP.CNPJ Emit_CNPJ," +
                                     "EMP.End_Logradouro Emit_End_Logradouro," +
                                     "EMP.End_Bairro Emit_End_Bairro," +
                                     "EMP.End_CEP Emit_End_CEP," +
                                     "EMPC.Nome Emit_Cidade," +
                                     "EMPE.Codigo Emit_Estado," +
                                     "EMP.InscricaoEstadual Emit_InscricaoEstadual," +
                                     "PES.Nome Desc_Nome," +
                                     "PES.CNPJ_CPF Desc_CNPJ_CPF," +
                                     "PES.End_Logradouro Desc_End_Logradouro," +
                                     "PES.End_Bairro Desc_End_Bairro," +
                                     "PES.End_CEP Desc_End_CEP," +
                                     "PESC.Nome Desc_Cidade," +
                                     "PESE.Codigo Desc_Estado," +
                                     "PES.InscricaoEstadual Desc_InscricaoEstadual" +
                              " FROM NotaFiscalSaidas NFS" +
                               " INNER JOIN Empresas EMP ON EMP.Id = NFS.EmpresaId" +
                                " LEFT JOIN Cidades EMPC ON EMPC.Id = EMP.End_CidadeId" +
                                " LEFT JOIN Estados EMPE ON EMPE.Id = EMPC.EstadoId" +
                               " INNER JOIN Pessoas PES ON PES.Id = NFS.ClienteId" +
                                " LEFT JOIN Cidades PESC ON PESC.Id = PES.End_CidadeId" +
                                " LEFT JOIN Estados PESE ON PESE.Id = PESC.EstadoId" +
                              " WHERE NFS.ID = '" + param[0].ToString() + "'";
                        data = DB.Executar(sql);

                        this.Text = "Carta de Correção";
                        reportViewer1.LocalReport.ReportEmbeddedResource = "SisCom.Aplicacao.Report.Fiscal.CartaCorrecao.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGeral", data));
                        break;
                    }
                case TipoRelatorio.NotaFiscalEntrada:
                    {
                        sql = "WITH NFEI (NotaFiscalEntradaId, ValorItens) AS " +
                              "(SELECT NotaFiscalEntradaId, SUM(PrecoTotal) ValorItens FROM NotaFiscalEntradaMercadorias GROUP BY NotaFiscalEntradaId) " +
                              "SELECT CONCAT(CFOP.Codigo, ' ', NTOP.Nome) NaturezaOperacao," +
                                     "NFET.DataEmissao," +
                                     "NFET.DataEntrada," +
                                     "NFET.NotaFiscal," +
                                     "NFET.Serie," +
                                     "FRNC.Nome Fornecedor," +
                                     "FRNC.CNPJ_CPF," +
                                     "ETFN.Codigo," +
                                     "NFEI.ValorItens," +
                                     "NFET.ValorDesconto," +
                                     "NFET.ValorOutrasDespesas," +
                                     "NFET.BaseCalculo BaseICMS," +
                                     "NFET.ValorICMS," +
                                     "NFET.ValorNota," +
                                     "IIF(NFET.Status = " + NF_Status.Cancelado.GetHashCode() + ", 1, 0) Cancelada," +
                                     "IIF(NFET.Status = " + NF_Status.Denegada.GetHashCode() + ", 1, 0) Denegada," +
                                     "IIF(NFET.Status = " + NF_Status.Inutilizada.GetHashCode() + ", 1, 0) Inutilizada," +
                                     "IIF(NFET.Status NOT IN (" + NF_Status.Inutilizada.GetHashCode() + "," + NF_Status.Cancelado.GetHashCode() + "," + NF_Status.Denegada.GetHashCode() + "), 1, 0) NaoProcessada" +
                              " FROM NotaFiscalEntradas NFET" +
                               " INNER JOIN NaturezaOperacoes NTOP on NTOP.Id = NFET.NaturezaOperacaoId" +
                               " INNER JOIN TabelaCFOPs CFOP on CFOP.Id = NTOP.TabelaCFOPId" +
                               " INNER JOIN Pessoas FRNC on FRNC.Id = NFET.FornecedorId" +
                               " INNER JOIN NFEI on NFEI.NotaFiscalEntradaId = NFET.Id" +
                                " LEFT JOIN Cidades CDFN on CDFN.Id = FRNC.End_CidadeId" +
                                " LEFT JOIN Estados ETFN on ETFN.Id = CDFN.EstadoId";

                        sql = sql +
                              " ORDER BY NFET.NotaFiscal";
                        data = DB.Executar(sql);

                        this.Text = "Carta de Correção";

                        reportViewer1.LocalReport.ReportEmbeddedResource = "SisCom.Aplicacao.Report.Fiscal.NFEntradas.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGeral", data));
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("EmpresaLogada", Declaracoes.dados_Empresa_Nome ),
                                                                                        new ReportParameter("Usuario", Declaracoes.sistema_UsuarioLogado),
                                                                                        new ReportParameter("Emissao", DateTime.Now.ToString()),
                                                                                        new ReportParameter("Empresa", "TODOS"),
                                                                                        new ReportParameter("CFOP", "TODOS"),
                                                                                        new ReportParameter("Pessoa", "TODOS"),
                                                                                        new ReportParameter("DataInicial", "TODOS"),
                                                                                        new ReportParameter("DataFinal", "TODOS") });
                        break;
                    }
                default:
                    return;
            }

            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            reportViewer1.SetPageSettings(setup);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.RefreshReport();
        }
    }
}
