using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class MDfeCondutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DadoVeiculo_NumeroPlaca",
                table: "ManifestoEletronicoDocumentos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadoVeiculo_NumeroPlaca",
                table: "ManifestoEletronicoDocumentos");
        }
    }
}
