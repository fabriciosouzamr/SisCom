using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class Observacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "QuantidadePorCaixa",
                table: "MercadoriaFornecedores",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "MercadoriaComposicaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    PercentualPerdaQuebra = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercadoriaComponenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercadoriaComposicaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MercadoriaComposicaos_Mercadorias_MercadoriaComponenteId",
                        column: x => x.MercadoriaComponenteId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MercadoriaComposicaos_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MercadoriaImpostoEstados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercentualICMS_Interno = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PercentualICMS_Destino = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoOrigemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercadoriaImpostoEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MercadoriaImpostoEstados_Estados_EstadoDestinoId",
                        column: x => x.EstadoDestinoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MercadoriaImpostoEstados_Estados_EstadoOrigemId",
                        column: x => x.EstadoOrigemId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MercadoriaImpostoEstados_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    TipoObservacao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacaos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaComposicaos_MercadoriaComponenteId",
                table: "MercadoriaComposicaos",
                column: "MercadoriaComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaComposicaos_MercadoriaId",
                table: "MercadoriaComposicaos",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaImpostoEstados_EstadoDestinoId",
                table: "MercadoriaImpostoEstados",
                column: "EstadoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaImpostoEstados_EstadoOrigemId",
                table: "MercadoriaImpostoEstados",
                column: "EstadoOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaImpostoEstados_MercadoriaId",
                table: "MercadoriaImpostoEstados",
                column: "MercadoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MercadoriaComposicaos");

            migrationBuilder.DropTable(
                name: "MercadoriaImpostoEstados");

            migrationBuilder.DropTable(
                name: "Observacaos");

            migrationBuilder.AlterColumn<double>(
                name: "QuantidadePorCaixa",
                table: "MercadoriaFornecedores",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);
        }
    }
}
