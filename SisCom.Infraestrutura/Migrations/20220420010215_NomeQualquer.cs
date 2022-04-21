using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NomeQualquer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportadoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(15)", nullable: true),
                    End_CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_Numero = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_PontoReferencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlacaVeiculo = table.Column<string>(type: "varchar(9)", nullable: true),
                    PlacaCarreta01 = table.Column<string>(type: "varchar(9)", nullable: true),
                    PlacaCarreta02 = table.Column<string>(type: "varchar(9)", nullable: true),
                    NomeContato = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportadoras_Cidades_End_CidadeId",
                        column: x => x.End_CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transportadoras_End_CidadeId",
                table: "Transportadoras",
                column: "End_CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transportadoras");
        }
    }
}
