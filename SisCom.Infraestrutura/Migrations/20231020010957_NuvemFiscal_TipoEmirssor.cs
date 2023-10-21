using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NuvemFiscal_TipoEmirssor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MDFe_TipoEmirssor",
                table: "Empresas",
                newName: "NuvemFiscal_TipoEmirssor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NuvemFiscal_TipoEmirssor",
                table: "Empresas",
                newName: "MDFe_TipoEmirssor");
        }
    }
}
