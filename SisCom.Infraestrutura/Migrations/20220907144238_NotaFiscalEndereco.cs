using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "PercentualFrete",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "NotaFiscalSaidas",
                newName: "Cliente_Telefone");

            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "NotaFiscalSaidas",
                newName: "Cliente_EMail");

            migrationBuilder.AddColumn<string>(
                name: "End_Complemento",
                table: "Transportadoras",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Percentual",
                table: "TabelaCST_PIS_COFINSs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "End_Complemento",
                table: "Pessoas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_Complemento",
                table: "NotaFiscalSaidas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TransmitirCliente",
                table: "NotaFiscalSaidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoTotal",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFrete",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NomeInterno",
                table: "FormaPagamentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoIBGE",
                table: "Estados",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoCNAEPrincipal",
                table: "Empresas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_Complemento",
                table: "Empresas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoContribuinteICMS",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidaReferencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaFiscal = table.Column<string>(type: "varchar(10)", nullable: false),
                    CodigoChaveAcesso = table.Column<string>(type: "varchar(44)", nullable: false),
                    NotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidaReferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaReferencias_NotaFiscalSaidas_NotaFiscalSaidaId",
                        column: x => x.NotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidaSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Serie = table.Column<string>(type: "varchar(3)", nullable: false),
                    UltimaNotaFiscal = table.Column<string>(type: "varchar(10)", nullable: false, defaultValue: "0"),
                    UltimaNotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidaSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaSeries_NotaFiscalSaidas_UltimaNotaFiscalSaidaId",
                        column: x => x.UltimaNotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_COFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaReferencias_NotaFiscalSaidaId",
                table: "NotaFiscalSaidaReferencias",
                column: "NotaFiscalSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaSeries_UltimaNotaFiscalSaidaId",
                table: "NotaFiscalSaidaSeries",
                column: "UltimaNotaFiscalSaidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_COFINSId",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropTable(
                name: "NotaFiscalSaidaReferencias");

            migrationBuilder.DropTable(
                name: "NotaFiscalSaidaSeries");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "End_Complemento",
                table: "Transportadoras");

            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "TabelaCST_PIS_COFINSs");

            migrationBuilder.DropColumn(
                name: "End_Complemento",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_Complemento",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "TransmitirCliente",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "TabelaCST_PIS_COFINS_COFINSId",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "ValorFrete",
                table: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropColumn(
                name: "NomeInterno",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "CodigoIBGE",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CodigoCNAEPrincipal",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "End_Complemento",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "TipoContribuinteICMS",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "Cliente_Telefone",
                table: "NotaFiscalSaidas",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Cliente_EMail",
                table: "NotaFiscalSaidas",
                newName: "EMail");

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<float>(
                name: "PrecoUnitario",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<float>(
                name: "PrecoTotal",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<float>(
                name: "PercentualIPI",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<float>(
                name: "PercentualICMS",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "PercentualFrete",
                table: "NotaFiscalSaidaMercadorias",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISCOFINSId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINS_PISCOFINSId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_PIS_COFINS_PISCOFINSId",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
