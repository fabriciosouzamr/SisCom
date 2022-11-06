using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class MercadoriaImpostoEstadoICMS1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentualICMS_Destino",
                table: "MercadoriaImpostoEstados");

            migrationBuilder.RenameColumn(
                name: "PercentualICMS_Interno",
                table: "MercadoriaImpostoEstados",
                newName: "PercentualICMS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentualICMS",
                table: "MercadoriaImpostoEstados",
                newName: "PercentualICMS_Interno");

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualICMS_Destino",
                table: "MercadoriaImpostoEstados",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
