using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NaturezaOperacaoAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UnidadeMedidaBId",
                table: "UnidadeMedidaConversoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Devolucao",
                table: "NaturezaOperacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EntradaSaida",
                table: "NaturezaOperacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualICMS",
                table: "NaturezaOperacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCFOPId",
                table: "NaturezaOperacoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NaturezaOperacoes_TabelaCFOPId",
                table: "NaturezaOperacoes",
                column: "TabelaCFOPId");

            migrationBuilder.AddForeignKey(
                name: "FK_NaturezaOperacoes_TabelaCFOPs_TabelaCFOPId",
                table: "NaturezaOperacoes",
                column: "TabelaCFOPId",
                principalTable: "TabelaCFOPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaturezaOperacoes_TabelaCFOPs_TabelaCFOPId",
                table: "NaturezaOperacoes");

            migrationBuilder.DropIndex(
                name: "IX_NaturezaOperacoes_TabelaCFOPId",
                table: "NaturezaOperacoes");

            migrationBuilder.DropColumn(
                name: "Devolucao",
                table: "NaturezaOperacoes");

            migrationBuilder.DropColumn(
                name: "EntradaSaida",
                table: "NaturezaOperacoes");

            migrationBuilder.DropColumn(
                name: "PercentualICMS",
                table: "NaturezaOperacoes");

            migrationBuilder.DropColumn(
                name: "TabelaCFOPId",
                table: "NaturezaOperacoes");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnidadeMedidaBId",
                table: "UnidadeMedidaConversoes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnidadeMedidaAId",
                table: "UnidadeMedidaConversoes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
