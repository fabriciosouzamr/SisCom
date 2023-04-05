using Microsoft.Reporting.WinForms;
using SisCom.Aplicacao.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public enum TipoRelatorio
    {
        CartaCorrecao
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

                        var setup = reportViewer1.GetPageSettings();
                        setup.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
                        reportViewer1.SetPageSettings(setup);
                        reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        reportViewer1.RefreshReport();
                        break;
                    }
            }
        }
    }
}
