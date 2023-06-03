using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class AjusteNotaFiscalEntrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "NotaFiscalEntradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagamento",
                table: "NotaFiscalEntradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalEntradaMercadorias_UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias",
                column: "UnidadeMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalEntradaMercadorias_UnidadeMedidas_UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias",
                column: "UnidadeMedidaId",
                principalTable: "UnidadeMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalEntradaMercadorias_UnidadeMedidas_UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalEntradaMercadorias_UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NotaFiscalEntradas");

            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "NotaFiscalEntradas");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaId",
                table: "NotaFiscalEntradaMercadorias");
        }
    }
}
