using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class AjusteTabelaNCM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoNCM");

            migrationBuilder.DropColumn(
                name: "TipoOperacaoCFOPId",
                table: "GrupoCFOPs");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TabelaNCMs",
                type: "varchar(1500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AddColumn<double>(
                name: "TotalTributos",
                table: "TabelaNCMs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TributosEstaduais",
                table: "TabelaNCMs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TributosFederais",
                table: "TabelaNCMs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TributosMunicipais",
                table: "TabelaNCMs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TabelaCFOPs",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "TabelaBeneficioSPEDs",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "TabelaBeneficioSPEDs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicial",
                table: "TabelaBeneficioSPEDs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTributos",
                table: "TabelaNCMs");

            migrationBuilder.DropColumn(
                name: "TributosEstaduais",
                table: "TabelaNCMs");

            migrationBuilder.DropColumn(
                name: "TributosFederais",
                table: "TabelaNCMs");

            migrationBuilder.DropColumn(
                name: "TributosMunicipais",
                table: "TabelaNCMs");

            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "TabelaBeneficioSPEDs");

            migrationBuilder.DropColumn(
                name: "DataInicial",
                table: "TabelaBeneficioSPEDs");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TabelaNCMs",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TabelaCFOPs",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "TabelaBeneficioSPEDs",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoOperacaoCFOPId",
                table: "GrupoCFOPs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GrupoNCM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNCM", x => x.Id);
                });
        }
    }
}
