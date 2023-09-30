using Microsoft.Reporting.WinForms;
using SisCom.Aplicacao.Classes;
using SisCom.Entidade.Enum;
using System;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public enum TipoRelatorio
    {
        ApuracaoICMS,
        CartaCorrecao,
        NotaFiscalEntrada,
        NotaFiscalSaida
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
                        sql = "WITH NFEI (NotaFiscalEntradaId, ValorItens, Quantidade) AS " +
                              "(SELECT NotaFiscalEntradaId, SUM(PrecoTotal) ValorItens, SUM(QuantidadeCaixas) Quantidade FROM NotaFiscalEntradaMercadorias GROUP BY NotaFiscalEntradaId) " +
                              "SELECT CONCAT(CFOP.Codigo, ' ', NTOP.Nome) NaturezaOperacao," +
                                     "NFET.DataEmissao," +
                                     "NFET.DataEntrada," +
                                     "NFET.NotaFiscal," +
                                     "NFET.Serie," +
                                     "FRNC.Nome Fornecedor," +
                                     "FRNC.CNPJ_CPF," +
                                     "ETFN.Codigo," +
                                     "NFEI.ValorItens," +
                                     "NFEI.Quantidade," +
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
                                " LEFT JOIN Estados ETFN on ETFN.Id = CDFN.EstadoId" +
                              " WHERE NFET.DataEmissao >= '" + param[4] + "'" +
                                " AND NFET.DataEmissao <= '" + param[5] + "'";

                        if (!string.IsNullOrEmpty(param[3].ToString()))
                        {
                            sql = sql + " AND NFET.FornecedorId = '" + param[3] + "'";
                        }
                        if (!string.IsNullOrEmpty(param[2].ToString()))
                        {
                            sql = sql + " AND NTOP.Id = '" + param[2] + "'";
                        }

                        sql = sql +
                              " ORDER BY NFET.NotaFiscal";
                        data = DB.Executar(sql);

                        this.Text = "Nota Fiscal de Entrada";

                        reportViewer1.LocalReport.ReportEmbeddedResource = "SisCom.Aplicacao.Report.Fiscal.NFEntradas.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGeral", data));
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("EmpresaLogada", Declaracoes.dados_Empresa_Nome ),
                                                                                        new ReportParameter("Usuario", Declaracoes.sistema_UsuarioLogado),
                                                                                        new ReportParameter("Emissao", DateTime.Now.ToString()),
                                                                                        new ReportParameter("Empresa", string.IsNullOrEmpty(param[6]) ? "TODOS" : param[6]),
                                                                                        new ReportParameter("CFOP", string.IsNullOrEmpty(param[8]) ? "TODOS" : param[8]),
                                                                                        new ReportParameter("Pessoa", string.IsNullOrEmpty(param[9]) ? "TODOS" : param[9]),
                                                                                        new ReportParameter("DataInicial", param[4]),
                                                                                        new ReportParameter("DataFinal", param[5]),
                                                                                        new ReportParameter("PessoaRotulo", "Fornecedor"),
                                                                                        new ReportParameter("TipoNotaFiscal", "Entrada")});
                        break;
                    }
                case TipoRelatorio.NotaFiscalSaida:
                    {
                        sql = "WITH NFEI (NotaFiscalSaidaId, ValorItens, Quantidade, BaseCalculo, ValorICMS, ValorNota) AS " +
                              "(SELECT NotaFiscalSaidaId, SUM(PrecoTotal) ValorItens, SUM(Quantidade) Quantidade, Sum(ValorBaseCalculo) BaseCalculo, SUM(ValorICMS) ValorICMS, SUM(PrecoTotal) ValorNota FROM NotaFiscalSaidaMercadorias GROUP BY NotaFiscalSaidaId)" +
                              "SELECT CONCAT(CFOP.Codigo, ' ', NTOP.Nome) NaturezaOperacao,NFET.DataEmissao,NFET.DataEmissao DataEntrada, NFET.NotaFiscal,NFET.Serie,FRNC.Nome Fornecedor, FRNC.CNPJ_CPF,ETFN.Codigo,NFEI.ValorItens,NFEI.Quantidade,NFET.ValorDesconto," +
                                     "NFET.ValorFrete + NFET.ValorSeguro ValorOutrasDespesas,NFEI.BaseCalculo BaseICMS, NFEI.ValorICMS,NFEI.ValorNota,IIF(NFET.Status = 2, 1, 0) Cancelada,IIF(NFET.Status = 4, 1, 0) Denegada,IIF(NFET.Status = 5, 1, 0) Inutilizada," + 
                                     "IIF(NFET.Status NOT IN(5, 2, 4), 1, 0) NaoProcessada" +
                              " FROM NotaFiscalSaidas NFET" +
                               " INNER JOIN NaturezaOperacoes NTOP on NTOP.Id = NFET.NaturezaOperacaoId" +
                               " INNER JOIN TabelaCFOPs CFOP on CFOP.Id = NTOP.TabelaCFOPId" +
                               " INNER JOIN Pessoas FRNC on FRNC.Id = NFET.ClienteId" +
                               " INNER JOIN NFEI on NFEI.NotaFiscalSaidaId = NFET.Id" +
                                " LEFT JOIN Cidades CDFN on CDFN.Id = FRNC.End_CidadeId" +
                                " LEFT JOIN Estados ETFN on ETFN.Id = CDFN.EstadoId" +
                              " WHERE CAST(NFET.DataEmissao AS DATE) >= '" + param[4] + "'" +
                                " AND CAST(NFET.DataEmissao AS DATE) <= '" + param[5] + "'";

                        if (!string.IsNullOrEmpty(param[1].ToString()))
                        {
                            sql = sql + " AND NFET.ClienteId = '" + param[1] + "'";
                        }
                        if (!string.IsNullOrEmpty(param[2].ToString()))
                        {
                            sql = sql + " AND NTOP.Id = '" + param[2] + "'";
                        }

                        sql = sql +
                              " ORDER BY NFET.NotaFiscal";
                        data = DB.Executar(sql);

                        this.Text = "Nota Fiscal de Saída";

                        reportViewer1.LocalReport.ReportEmbeddedResource = "SisCom.Aplicacao.Report.Fiscal.NFEntradas.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGeral", data));
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("EmpresaLogada", Declaracoes.dados_Empresa_Nome ),
                                                                                        new ReportParameter("Usuario", Declaracoes.sistema_UsuarioLogado),
                                                                                        new ReportParameter("Emissao", DateTime.Now.ToString()),
                                                                                        new ReportParameter("Empresa", string.IsNullOrEmpty(param[6]) ? "TODOS" : param[6]),
                                                                                        new ReportParameter("CFOP", string.IsNullOrEmpty(param[8]) ? "TODOS" : param[8]),
                                                                                        new ReportParameter("Pessoa", string.IsNullOrEmpty(param[7]) ? "TODOS" : param[9]),
                                                                                        new ReportParameter("DataInicial", param[4]),
                                                                                        new ReportParameter("DataFinal", param[5]),
                                                                                        new ReportParameter("PessoaRotulo", "Cliente"),
                                                                                        new ReportParameter("TipoNotaFiscal", "Saída") });

                        break;
                    }
                case TipoRelatorio.ApuracaoICMS:
                    {
                        decimal ValorEntrada = 0;
                        decimal ValorSaida = 0;
                        decimal Saldo  = 0;

                        sql = @$"select iif(TipoOperacaoCFOP < 4, 'ENTRADAS', 'SAÍDAS') Tipo,
                                        cfop.Codigo CFOP,
                                        sum(merc.PrecoTotal) ValorItens, 0 ValorOutros, 0 ValorDesconto,
                                        sum(merc.PrecoTotal) ValorTotal,
                                        sum(merc.PercentualICMS) ValorICMS,
                                        sum(merc.PrecoTotal) ValorBaseICMS
                                 from NotaFiscalEntradas nfe
                                  inner join NotaFiscalEntradaMercadorias merc on merc.NotaFiscalEntradaId = nfe.Id
                                  inner join TabelaCFOPs cfop on cfop.Id = merc.CFOPId
                                  inner join GrupoCFOPs grp on grp.Id = cfop.GrupoCFOPId
                                 WHERE CAST(nfe.DataEmissao AS DATE) >= '{param[4]}'
                                   AND CAST(nfe.DataEmissao AS DATE) <= '{param[5]}'
                                 group by iif(TipoOperacaoCFOP < 4, 'ENTRADAS', 'SAÍDAS'), cfop.Codigo
                                 union all
                                 select iif(TipoOperacaoCFOP < 4, 'ENTRADAS', 'SAÍDAS') Tipo,
                                        cfop.Codigo CFOP,
                                        sum(merc.PrecoTotal) ValorItens, 0 ValorOutros, 0 ValorDesconto,
                                        sum(merc.PrecoTotal) ValorTotal,
                                        sum(merc.ValorICMS) ValorICMS,
                                        sum(merc.ValorBaseCalculo) ValorBaseICMS
                                  from NotaFiscalSaidas nfe
                                   inner join NotaFiscalSaidaMercadorias merc on merc.NotaFiscalSaidaId = nfe.Id
                                   inner join TabelaCFOPs cfop on cfop.Id = merc.TabelaCFOPId
                                  inner join GrupoCFOPs grp on grp.Id = cfop.GrupoCFOPId
                                 WHERE CAST(nfe.DataEmissao AS DATE) >= '{param[4]}'
                                   AND CAST(nfe.DataEmissao AS DATE) <= '{param[5]}'
                                  group by iif(TipoOperacaoCFOP < 4, 'ENTRADAS', 'SAÍDAS'), cfop.Codigo";
                        data = DB.Executar(sql);

                        this.Text = "Apuração de ICMS";

                        foreach (DataRow row in data.Rows)
                        {
                            if (row["Tipo"].ToString() == "ENTRADAS")
                            {
                                ValorEntrada += Convert.ToDecimal(row["ValorICMS"]);
                            }
                            else
                            {
                                ValorSaida += Convert.ToDecimal(row["ValorICMS"]);
                            }
                        }

                        Saldo = ValorEntrada - ValorSaida;

                        reportViewer1.LocalReport.ReportEmbeddedResource = "SisCom.Aplicacao.Report.Fiscal.Apuracao.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGeral", data));
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("EmpresaLogada", Declaracoes.dados_Empresa_Nome ),
                                                                                        new ReportParameter("Usuario", Declaracoes.sistema_UsuarioLogado),
                                                                                        new ReportParameter("Emissao", DateTime.Now.ToString()),
                                                                                        new ReportParameter("Empresa", string.IsNullOrEmpty(param[6]) ? "TODOS" : param[6]),
                                                                                        new ReportParameter("CFOP", string.IsNullOrEmpty(param[8]) ? "TODOS" : param[8]),
                                                                                        new ReportParameter("Pessoa", string.IsNullOrEmpty(param[7]) ? "TODOS" : param[9]),
                                                                                        new ReportParameter("DataInicial", param[4]),
                                                                                        new ReportParameter("DataFinal", param[5]),
                                                                                        new ReportParameter("ValorEntrada", ValorEntrada.ToString("C")),
                                                                                        new ReportParameter("ValorSaida", ValorSaida.ToString("C")),
                                                                                        new ReportParameter("Saldo", Saldo.ToString("C")) });

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
