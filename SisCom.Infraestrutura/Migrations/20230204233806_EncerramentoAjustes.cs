using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class EncerramentoAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEncerramento",
                table: "ManifestoEletronicoDocumentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetornoEncerramento",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEncerramento",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "RetornoEncerramento",
                table: "ManifestoEletronicoDocumentos");
        }
    }
}
