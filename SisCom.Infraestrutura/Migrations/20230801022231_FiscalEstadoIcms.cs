using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class FiscalEstadoIcms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiscalEstadoIcmses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icms = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    EstadoOrigemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalEstadoIcmses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalEstadoIcmses_Estados_EstadoDestinoId",
                        column: x => x.EstadoDestinoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FiscalEstadoIcmses_Estados_EstadoOrigemId",
                        column: x => x.EstadoOrigemId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiscalEstadoIcmses_EstadoDestinoId",
                table: "FiscalEstadoIcmses",
                column: "EstadoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalEstadoIcmses_EstadoOrigemId",
                table: "FiscalEstadoIcmses",
                column: "EstadoOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalEstadoIcmses");
        }
    }
}
