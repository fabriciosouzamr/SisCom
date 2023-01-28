using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class VeciuloPlacaajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoPlacas_Cidades_CidadeId",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "CodigoRenavan",
                table: "VeiculoPlacas");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "VeiculoPlacas",
                newName: "Terceiros_EstadoProprietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoPlacas_CidadeId",
                table: "VeiculoPlacas",
                newName: "IX_VeiculoPlacas_Terceiros_EstadoProprietarioId");

            migrationBuilder.AddColumn<double>(
                name: "CapacidadeKG",
                table: "VeiculoPlacas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CapacidadeM3",
                table: "VeiculoPlacas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "VeiculoPlacas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Renavam",
                table: "VeiculoPlacas",
                type: "varchar(11)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaraKG",
                table: "VeiculoPlacas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Terceiros_CPFCNPJProprietario",
                table: "VeiculoPlacas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terceiros_IEProprietario",
                table: "VeiculoPlacas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terceiros_NomeProprietario",
                table: "VeiculoPlacas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terceiros_RNTRCProprietario",
                table: "VeiculoPlacas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Terceiros_TipoProprietario",
                table: "VeiculoPlacas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoCarroceria",
                table: "VeiculoPlacas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoRodado",
                table: "VeiculoPlacas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "ManifestoEletronicoDocumentoPercursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoPlacas_EstadoId",
                table: "VeiculoPlacas",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoPlacas_Estados_EstadoId",
                table: "VeiculoPlacas",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoPlacas_Estados_Terceiros_EstadoProprietarioId",
                table: "VeiculoPlacas",
                column: "Terceiros_EstadoProprietarioId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoPlacas_Estados_EstadoId",
                table: "VeiculoPlacas");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoPlacas_Estados_Terceiros_EstadoProprietarioId",
                table: "VeiculoPlacas");

            migrationBuilder.DropIndex(
                name: "IX_VeiculoPlacas_EstadoId",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "CapacidadeKG",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "CapacidadeM3",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Renavam",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "TaraKG",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Terceiros_CPFCNPJProprietario",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Terceiros_IEProprietario",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Terceiros_NomeProprietario",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Terceiros_RNTRCProprietario",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Terceiros_TipoProprietario",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "TipoCarroceria",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "TipoRodado",
                table: "VeiculoPlacas");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "ManifestoEletronicoDocumentoPercursos");

            migrationBuilder.RenameColumn(
                name: "Terceiros_EstadoProprietarioId",
                table: "VeiculoPlacas",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoPlacas_Terceiros_EstadoProprietarioId",
                table: "VeiculoPlacas",
                newName: "IX_VeiculoPlacas_CidadeId");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRenavan",
                table: "VeiculoPlacas",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoPlacas_Cidades_CidadeId",
                table: "VeiculoPlacas",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
