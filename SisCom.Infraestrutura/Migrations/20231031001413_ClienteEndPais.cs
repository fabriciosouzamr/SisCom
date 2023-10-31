using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class ClienteEndPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "End_PaisId",
                table: "Transportadoras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "End_PaisId",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "End_PaisId",
                table: "NotaFiscalSaidas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "End_PaisId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportadoras_End_PaisId",
                table: "Transportadoras",
                column: "End_PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_End_PaisId",
                table: "Pessoas",
                column: "End_PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_End_PaisId",
                table: "NotaFiscalSaidas",
                column: "End_PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_End_PaisId",
                table: "Empresas",
                column: "End_PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Paises_End_PaisId",
                table: "Empresas",
                column: "End_PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalSaidas_Paises_End_PaisId",
                table: "NotaFiscalSaidas",
                column: "End_PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Paises_End_PaisId",
                table: "Pessoas",
                column: "End_PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportadoras_Paises_End_PaisId",
                table: "Transportadoras",
                column: "End_PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Paises_End_PaisId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalSaidas_Paises_End_PaisId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Paises_End_PaisId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportadoras_Paises_End_PaisId",
                table: "Transportadoras");

            migrationBuilder.DropIndex(
                name: "IX_Transportadoras_End_PaisId",
                table: "Transportadoras");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_End_PaisId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalSaidas_End_PaisId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_End_PaisId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "End_PaisId",
                table: "Transportadoras");

            migrationBuilder.DropColumn(
                name: "End_PaisId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_PaisId",
                table: "NotaFiscalSaidas");

            migrationBuilder.DropColumn(
                name: "End_PaisId",
                table: "Empresas");
        }
    }
}
