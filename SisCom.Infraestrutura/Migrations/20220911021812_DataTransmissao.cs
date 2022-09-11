using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class DataTransmissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataTransmissao",
                table: "NotaFiscalSaidas",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTransmissao",
                table: "NotaFiscalSaidas");

            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
