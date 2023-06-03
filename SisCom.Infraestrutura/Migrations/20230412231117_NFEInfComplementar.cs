using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NFEInfComplementar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NFE_InfComple_CreditoSimplesNacional",
                table: "Empresas",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NFE_InfComple_TributosTotal",
                table: "Empresas",
                type: "varchar(1000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NFE_InfComple_CreditoSimplesNacional",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "NFE_InfComple_TributosTotal",
                table: "Empresas");
        }
    }
}
