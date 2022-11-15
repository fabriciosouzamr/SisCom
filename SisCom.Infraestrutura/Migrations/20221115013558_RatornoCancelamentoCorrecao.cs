using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class RatornoCancelamentoCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RetornoCancelamento",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetornoCartaCorrecao",
                table: "NotaFiscalSaidas",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetornoCancelamento",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "RetornoCartaCorrecao",
                table: "NotaFiscalSaidas");
        }
    }
}
