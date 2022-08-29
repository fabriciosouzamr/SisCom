using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaidaObservacaoFormaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidaObservacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false),
                    NotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObservacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidaObservacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaObservacaos_NotaFiscalSaidas_NotaFiscalSaidaId",
                        column: x => x.NotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaObservacaos_Observacaos_ObservacaoId",
                        column: x => x.ObservacaoId,
                        principalTable: "Observacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaObservacaos_NotaFiscalSaidaId",
                table: "NotaFiscalSaidaObservacaos",
                column: "NotaFiscalSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaObservacaos_ObservacaoId",
                table: "NotaFiscalSaidaObservacaos",
                column: "ObservacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscalSaidaObservacaos");
        }
    }
}
