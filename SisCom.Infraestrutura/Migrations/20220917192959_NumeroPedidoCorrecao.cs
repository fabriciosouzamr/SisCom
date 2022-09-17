using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NumeroPedidoCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPedido",
                table: "NotaFiscalSaidas");

            migrationBuilder.AddColumn<string>(
                name: "NumeroPedido",
                table: "Vendas",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPedido",
                table: "Vendas");

            migrationBuilder.AddColumn<string>(
                name: "NumeroPedido",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
