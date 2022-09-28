using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalVendaSerie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "NotaFiscalSaidaSeries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaSeries_EmpresaId",
                table: "NotaFiscalSaidaSeries",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidaSeries_Empresas_EmpresaId",
                table: "NotaFiscalSaidaSeries",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidaSeries_Empresas_EmpresaId",
                table: "NotaFiscalSaidaSeries");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidaSeries_EmpresaId",
                table: "NotaFiscalSaidaSeries");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "NotaFiscalSaidaSeries");
        }
    }
}
