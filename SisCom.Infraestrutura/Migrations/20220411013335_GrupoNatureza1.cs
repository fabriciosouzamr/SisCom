using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class GrupoNatureza1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.RenameColumn(
                name: "TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "TabelaCST_PIS_COFINSRelacionado02Id");

            migrationBuilder.RenameColumn(
                name: "TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "TabelaCST_PIS_COFINSRelacionado01Id");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado02Id");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado01Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_PIS_COFINSRelacionado01Id",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                column: "TabelaCST_PIS_COFINSRelacionado02Id",
                principalTable: "TabelaCST_PIS_COFINSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.RenameColumn(
                name: "TabelaCST_PIS_COFINSRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "TabelaCST_CSOSNRelacionado02Id");

            migrationBuilder.RenameColumn(
                name: "TabelaCST_PIS_COFINSRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "TabelaCST_CSOSNRelacionado01Id");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado02Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado02Id");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_PIS_COFINSRelacionado01Id",
                table: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                newName: "IX_GrupoNaturezaReceita_CTS_PIS_COFINSs_TabelaCST_CSOSNRelacionado01Id");

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
    }
}
