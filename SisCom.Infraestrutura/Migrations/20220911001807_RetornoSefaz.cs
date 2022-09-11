using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class RetornoSefaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetornoSefaz",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRetornoSefaz",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas");
        }
    }
}
