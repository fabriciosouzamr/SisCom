using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class TipoUnidadeMedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "UnidadeMedidas",
                type: "varchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "UnidadeMedidas",
                type: "char(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)");
        }
    }
}
