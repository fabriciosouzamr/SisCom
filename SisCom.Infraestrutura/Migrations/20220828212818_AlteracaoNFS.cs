using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class AlteracaoNFS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroNotaFiscalSaida",
                table: "NotaFiscalSaidas",
                newName: "NotaFiscal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaFiscal",
                table: "NotaFiscalSaidas",
                newName: "NumeroNotaFiscalSaida");
        }
    }
}
