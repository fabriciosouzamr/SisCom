using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class Vendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaOrigemVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaOrigemVendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoPlacas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "varchar(10)", nullable: false),
                    CodigoRenavan = table.Column<string>(type: "varchar(11)", nullable: false),
                    CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoPlacas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoPlacas_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: false),
                    EnderecoEntrega = table.Column<string>(type: "varchar(100)", nullable: true),
                    PosuiEntrega = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabelaOrigemVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MotoristaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VeiculoPlaca01Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VeiculoPlaca02Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VeiculoPlaca03Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Funcionarios_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Pessoas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_TabelaOrigemVendas_TabelaOrigemVendaId",
                        column: x => x.TabelaOrigemVendaId,
                        principalTable: "TabelaOrigemVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_VeiculoPlacas_VeiculoPlaca01Id",
                        column: x => x.VeiculoPlaca01Id,
                        principalTable: "VeiculoPlacas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_VeiculoPlacas_VeiculoPlaca02Id",
                        column: x => x.VeiculoPlaca02Id,
                        principalTable: "VeiculoPlacas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_VeiculoPlacas_VeiculoPlaca03Id",
                        column: x => x.VeiculoPlaca03Id,
                        principalTable: "VeiculoPlacas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendaMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnidadeMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaMercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaMercadorias_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaMercadorias_UnidadeMedidas_UnidadeMedidaId",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadeMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaMercadorias_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoPlacas_CidadeId",
                table: "VeiculoPlacas",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaMercadorias_MercadoriaId",
                table: "VendaMercadorias",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaMercadorias_UnidadeMedidaId",
                table: "VendaMercadorias",
                column: "UnidadeMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaMercadorias_VendaId",
                table: "VendaMercadorias",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_EmpresaId",
                table: "Vendas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_MotoristaId",
                table: "Vendas",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_TabelaOrigemVendaId",
                table: "Vendas",
                column: "TabelaOrigemVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_TransportadoraId",
                table: "Vendas",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoPlaca01Id",
                table: "Vendas",
                column: "VeiculoPlaca01Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoPlaca02Id",
                table: "Vendas",
                column: "VeiculoPlaca02Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoPlaca03Id",
                table: "Vendas",
                column: "VeiculoPlaca03Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaMercadorias");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "TabelaOrigemVendas");

            migrationBuilder.DropTable(
                name: "VeiculoPlacas");
        }
    }
}
