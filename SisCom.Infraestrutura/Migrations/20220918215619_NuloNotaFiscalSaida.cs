using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NuloNotaFiscalSaida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRetornoSefaz",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "TransmitirEnderecoCliente",
                table: "NotaFiscalSaidas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransmitirEnderecoCliente",
                table: "NotaFiscalSaidas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRetornoSefaz",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
