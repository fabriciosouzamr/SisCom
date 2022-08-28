using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class TipoPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPagamentos_TipoPagamento_TipoPagamentoId",
                table: "FormaPagamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPagamento",
                table: "TipoPagamento");

            migrationBuilder.RenameTable(
                name: "TipoPagamento",
                newName: "TipoPagamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TipoPagamentos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPagamentos",
                table: "TipoPagamentos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidaPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataVecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    NotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormaPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidaPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaPagamentos_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaPagamentos_NotaFiscalSaidas_NotaFiscalSaidaId",
                        column: x => x.NotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaPagamentos_FormaPagamentoId",
                table: "NotaFiscalSaidaPagamentos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaPagamentos_NotaFiscalSaidaId",
                table: "NotaFiscalSaidaPagamentos",
                column: "NotaFiscalSaidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPagamentos_TipoPagamentos_TipoPagamentoId",
                table: "FormaPagamentos",
                column: "TipoPagamentoId",
                principalTable: "TipoPagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPagamentos_TipoPagamentos_TipoPagamentoId",
                table: "FormaPagamentos");

            migrationBuilder.DropTable(
                name: "NotaFiscalSaidaPagamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPagamentos",
                table: "TipoPagamentos");

            migrationBuilder.RenameTable(
                name: "TipoPagamentos",
                newName: "TipoPagamento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TipoPagamento",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPagamento",
                table: "TipoPagamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPagamentos_TipoPagamento_TipoPagamentoId",
                table: "FormaPagamentos",
                column: "TipoPagamentoId",
                principalTable: "TipoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
