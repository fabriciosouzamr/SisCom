using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class AjusreMDFeSerie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UltimoNumeroManifestoEletronicoDocumento",
                table: "ManifestoEletronicoDocumentoSeries",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimoNumeroManifestoEletronicoDocumento",
                table: "ManifestoEletronicoDocumentoSeries");
        }
    }
}
