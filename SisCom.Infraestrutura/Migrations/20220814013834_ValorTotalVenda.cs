using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class ValorTotalVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Vendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Vendas");
        }
    }
}
