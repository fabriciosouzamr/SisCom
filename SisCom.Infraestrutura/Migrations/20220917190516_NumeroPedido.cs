using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NumeroPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroPedido",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_VendedorId",
                table: "NotaFiscalSaidas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidas_Funcionarios_VendedorId",
                table: "NotaFiscalSaidas",
                column: "VendedorId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidas_Funcionarios_VendedorId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidas_VendedorId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "NumeroPedido",
                table: "NotaFiscalSaidas");
        }
    }
}
