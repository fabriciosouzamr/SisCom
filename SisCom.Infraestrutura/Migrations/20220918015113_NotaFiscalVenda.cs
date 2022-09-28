using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VendaId",
                table: "NotaFiscalSaidas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_VendaId",
                table: "NotaFiscalSaidas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidas_Vendas_VendaId",
                table: "NotaFiscalSaidas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidas_Vendas_VendaId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidas_VendaId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "NotaFiscalSaidas");
        }
    }
}
