using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class EstoqueUnidadeMedidaConversao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias");

            migrationBuilder.DropIndex(
                name: "IX_Mercadorias_Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias");

            migrationBuilder.DropColumn(
                name: "Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias");

            migrationBuilder.CreateTable(
                name: "EstoqueUnidadeMedidaConversaos",
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
                    table.PrimaryKey("PK_EstoqueUnidadeMedidaConversaos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_UnidadeMedidaId",
                table: "Mercadorias",
                column: "Estoque_UnidadeMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeMedidaId",
                table: "Mercadorias",
                column: "Estoque_UnidadeMedidaId",
                principalTable: "UnidadeMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeMedidaId",
                table: "Mercadorias");

            migrationBuilder.DropTable(
                name: "EstoqueUnidadeMedidaConversaos");

            migrationBuilder.DropIndex(
                name: "IX_Mercadorias_Estoque_UnidadeMedidaId",
                table: "Mercadorias");

            migrationBuilder.AddColumn<Guid>(
                name: "Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias",
                column: "Estoque_UnidadeMedidaMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias",
                column: "Estoque_UnidadeMedidaMedidaId",
                principalTable: "UnidadeMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
