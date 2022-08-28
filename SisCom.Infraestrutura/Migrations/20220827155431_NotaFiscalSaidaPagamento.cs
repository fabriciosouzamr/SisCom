using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaidaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalEntradaFaturas_FormaPagamento_FormaPagamentoId",
                table: "NotaFiscalEntradaFaturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento");

            migrationBuilder.RenameTable(
                name: "FormaPagamento",
                newName: "FormaPagamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FormaPagamentos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "FormaPagamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TipoPagamentoId",
                table: "FormaPagamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsaNaVenda",
                table: "FormaPagamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsaNoPagamento",
                table: "FormaPagamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamentos",
                table: "FormaPagamentos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamentos_TipoPagamentoId",
                table: "FormaPagamentos",
                column: "TipoPagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPagamentos_TipoPagamento_TipoPagamentoId",
                table: "FormaPagamentos",
                column: "TipoPagamentoId",
                principalTable: "TipoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalEntradaFaturas_FormaPagamentos_FormaPagamentoId",
                table: "NotaFiscalEntradaFaturas",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPagamentos_TipoPagamento_TipoPagamentoId",
                table: "FormaPagamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalEntradaFaturas_FormaPagamentos_FormaPagamentoId",
                table: "NotaFiscalEntradaFaturas");

            migrationBuilder.DropTable(
                name: "TipoPagamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamentos",
                table: "FormaPagamentos");

            migrationBuilder.DropIndex(
                name: "IX_FormaPagamentos_TipoPagamentoId",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "TipoPagamentoId",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "UsaNaVenda",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "UsaNoPagamento",
                table: "FormaPagamentos");

            migrationBuilder.RenameTable(
                name: "FormaPagamentos",
                newName: "FormaPagamento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FormaPagamento",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalEntradaFaturas_FormaPagamento_FormaPagamentoId",
                table: "NotaFiscalEntradaFaturas",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
