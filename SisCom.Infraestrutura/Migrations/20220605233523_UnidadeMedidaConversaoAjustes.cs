using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class UnidadeMedidaConversaoAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeMedidaConversoes_UnidadeMedidas_UnidadeMedideAId",
                table: "UnidadeMedidaConversoes");

            migrationBuilder.RenameColumn(
                name: "UnidadeMedideAId",
                table: "UnidadeMedidaConversoes",
                newName: "UnidadeMedidaAId");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadeMedidaConversoes_UnidadeMedideAId",
                table: "UnidadeMedidaConversoes",
                newName: "IX_UnidadeMedidaConversoes_UnidadeMedidaAId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeMedidaConversoes_UnidadeMedidas_UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes",
                column: "UnidadeMedidaAId",
                principalTable: "UnidadeMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeMedidaConversoes_UnidadeMedidas_UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes");

            migrationBuilder.RenameColumn(
                name: "UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes",
                newName: "UnidadeMedideAId");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadeMedidaConversoes_UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes",
                newName: "IX_UnidadeMedidaConversoes_UnidadeMedideAId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeMedidaConversoes_UnidadeMedidas_UnidadeMedideAId",
                table: "UnidadeMedidaConversoes",
                column: "UnidadeMedideAId",
                principalTable: "UnidadeMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
