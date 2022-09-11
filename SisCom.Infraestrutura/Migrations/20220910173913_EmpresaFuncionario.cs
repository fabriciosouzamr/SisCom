using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class EmpresaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaAcessoId",
                table: "Funcionarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoAcesso",
                table: "Funcionarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Controle",
                table: "Empresas",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaAcessoId",
                table: "Funcionarios",
                column: "EmpresaAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Empresas_EmpresaAcessoId",
                table: "Funcionarios",
                column: "EmpresaAcessoId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Empresas_EmpresaAcessoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EmpresaAcessoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EmpresaAcessoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UltimoAcesso",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Controle",
                table: "Empresas");
        }
    }
}
