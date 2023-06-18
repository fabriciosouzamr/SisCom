using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaidaTipoNotaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque_Quantidade",
                table: "Mercadorias");

            migrationBuilder.AddColumn<int>(
                name: "TipoNotaFiscal",
                table: "NotaFiscalSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoNotaFiscal",
                table: "NotaFiscalSaidas");

            migrationBuilder.AddColumn<double>(
                name: "Estoque_Quantidade",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
