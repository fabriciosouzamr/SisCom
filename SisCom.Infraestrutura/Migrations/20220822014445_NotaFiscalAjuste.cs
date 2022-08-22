using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalAjuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaNaturezaOperacaoId",
                table: "NotaFiscalSaidas");

            migrationBuilder.RenameColumn(
                name: "ChaveNFe",
                table: "NotaFiscalSaidas",
                newName: "CodigoChaveAcesso");

            migrationBuilder.AlterColumn<float>(
                name: "VolumeTransportados_PesoLiquido",
                table: "NotaFiscalSaidas",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "VolumeTransportados_PesoBruto",
                table: "NotaFiscalSaidas",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorSeguro",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFrete",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDesconto",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualDesconto",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentuaAliquotaSimplesNacional",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OutrasDespesas",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesComplementaresInteresseContribuinte_Local",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "PrecoUnitario",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "PrecoTotal",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "PercentualIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "PercentualICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "PercentualFrete",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaAdicional",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaCOFINS",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaFCP",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaPIS",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AliquotaReducao",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseCalculoFCP",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "NotaFiscalSaidaMercadorias",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPedidoCompra",
                table: "NotaFiscalSaidaMercadorias",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroPedidoCompra",
                table: "NotaFiscalSaidaMercadorias",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAdicional",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorBaseCalculo",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorBaseIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorBaseSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFCP",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_IPIId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISCOFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_IPIs_TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_IPIId",
                principalTable: "TabelaCST_IPIs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISCOFINSId",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISId",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_IPIs_TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaAdicional",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaCOFINS",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaFCP",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaICMS",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaIPI",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaPIS",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "AliquotaReducao",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "BaseCalculoFCP",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ItemPedidoCompra",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "NumeroPedidoCompra",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "TabelaCST_IPIId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "TabelaCST_PIS_COFINS_PISId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorAdicional",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorBaseCalculo",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorBaseIPI",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorBaseSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorFCP",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorICMS",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorIPI",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.RenameColumn(
                name: "CodigoChaveAcesso",
                table: "NotaFiscalSaidas",
                newName: "ChaveNFe");

            migrationBuilder.AlterColumn<float>(
                name: "VolumeTransportados_PesoLiquido",
                table: "NotaFiscalSaidas",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "VolumeTransportados_PesoBruto",
                table: "NotaFiscalSaidas",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorSeguro",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFrete",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDesconto",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualDesconto",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentuaAliquotaSimplesNacional",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "OutrasDespesas",
                table: "NotaFiscalSaidas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesComplementaresInteresseContribuinte_Local",
                table: "NotaFiscalSaidas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaNaturezaOperacaoId",
                table: "NotaFiscalSaidas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "PrecoUnitario",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "PrecoTotal",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "PercentualIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "PercentualICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "PercentualFrete",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);
        }
    }
}
