using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class MDFeAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                table: "ManifestoEletronicoDocumentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetornoSefaz",
                table: "ManifestoEletronicoDocumentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCancelamento",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetornoCancelamento",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetornoSefaz",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetornoSefazCodigo",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "DataRetornoSefaz",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "DescricaoCancelamento",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "RetornoCancelamento",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "RetornoSefaz",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "RetornoSefazCodigo",
                table: "ManifestoEletronicoDocumentos");
        }
    }
}
