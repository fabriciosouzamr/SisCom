using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class SubGrupoNatureza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SubGrupoNaturezaReceita_CTS_PIS_COFINSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupoNaturezaReceita_CTS_PIS_COFINSs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "SubGrupoNaturezaReceita_CTS_PIS_COFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_CSOSNRelacionado01Id");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_CSOSNRelacionado02Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                principalTable: "SubGrupoNaturezaReceita_CTS_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_CSOSNRelacionado01Id",
                principalTable: "TabelaCST_CSOSNs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_CSOSNRelacionado02Id",
                principalTable: "TabelaCST_CSOSNs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropTable(
                name: "SubGrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropColumn(
                name: "SubGrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropColumn(
                name: "TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropColumn(
                name: "TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");
        }
    }
}
