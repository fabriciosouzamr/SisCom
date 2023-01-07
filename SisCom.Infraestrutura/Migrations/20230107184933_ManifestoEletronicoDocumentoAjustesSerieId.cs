using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class ManifestoEletronicoDocumentoAjustesSerieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentos_UltimoManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_UltimoManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropColumn(
                name: "ManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.AddColumn<Guid>(
                name: "UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "UltimoManifestoEletronicoDocumentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos",
                column: "ManifestoEletronicoDocumentoSerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos",
                column: "ManifestoEletronicoDocumentoSerieId",
                principalTable: "ManifestoEletronicoDocumentoSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentos_UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "UltimoManifestoEletronicoDocumentoId1",
                principalTable: "ManifestoEletronicoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentos_UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropIndex(
                name: "IX_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.DropColumn(
                name: "UltimoManifestoEletronicoDocumentoId1",
                table: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropColumn(
                name: "ManifestoEletronicoDocumentoSerieId",
                table: "ManifestoEletronicoDocumentos");

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_UltimoManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "UltimoManifestoEletronicoDocumentoId",
                unique: true,
                filter: "[UltimoManifestoEletronicoDocumentoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentos_UltimoManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "UltimoManifestoEletronicoDocumentoId",
                principalTable: "ManifestoEletronicoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
