using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class notafiscalCartacorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCartaCorrecao",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCancelamento",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCartaCorrecao",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "DataCartaCorrecao",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "DescricaoCancelamento",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "DescricaoCartaCorrecao",
                table: "NotaFiscalSaidas");
        }
    }
}
