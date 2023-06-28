using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class MercadoriaUnidadeMedidaConversao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QuantidadeEmEstoque",
                table: "EstoqueLancamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "MercadoriaUnidadeMedidaConversaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FatorConversao = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercadoriaUnidadeMedidaConversaos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MercadoriaUnidadeMedidaConversaos");

            migrationBuilder.DropColumn(
                name: "QuantidadeEmEstoque",
                table: "EstoqueLancamentos");
        }
    }
}
