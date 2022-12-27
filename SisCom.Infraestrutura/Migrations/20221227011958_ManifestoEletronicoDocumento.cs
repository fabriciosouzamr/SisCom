using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class ManifestoEletronicoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManifestoEletronicoDocumentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHoraEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Carga = table.Column<string>(type: "varchar(8)", nullable: true),
                    TipoEmissao = table.Column<int>(type: "int", nullable: false),
                    TipoTransportador = table.Column<int>(type: "int", nullable: false),
                    RNTRCEmitente = table.Column<string>(type: "varchar(10)", nullable: true),
                    DadoVeiculo_Renavam = table.Column<string>(type: "varchar(10)", nullable: true),
                    DadoVeiculo_TaraKG = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DadoVeiculo_CapacidadeKG = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DadoVeiculo_CapacidadeME = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DadoVeiculo_TipoRodado = table.Column<int>(type: "int", nullable: false),
                    DadoVeiculo_TipoCarroceria = table.Column<int>(type: "int", nullable: false),
                    DadoVeiculoVeiculoTerceiros_NomeProprietario = table.Column<string>(type: "varchar(100)", nullable: true),
                    DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario = table.Column<string>(type: "varchar(14)", nullable: true),
                    DadoVeiculoVeiculoTerceiros_IEProprietario = table.Column<string>(type: "varchar(15)", nullable: true),
                    DadoVeiculoVeiculoTerceiros_RNTRCProprietario = table.Column<string>(type: "varchar(10)", nullable: true),
                    DadoVeiculoVeiculoTerceiros_TipoProprietario = table.Column<int>(type: "int", nullable: false),
                    QuantidadeNFe = table.Column<int>(type: "int", nullable: false),
                    ValorTotalCarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PesoBrutoCarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    UnidadePeso = table.Column<int>(type: "int", nullable: false),
                    Autorizacao_ChaveAutenticacao = table.Column<string>(type: "varchar(44)", nullable: true),
                    Autorizacao_Protocolo = table.Column<string>(type: "varchar(44)", nullable: true),
                    Autorizacao_DataHoraAutorizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Autorizacao_DataHoraEncerramento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condutor_CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: true),
                    Condutor_Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    InformacoesAdicionaisInteresseFisco = table.Column<string>(type: "varchar(8000)", nullable: true),
                    InformacoesComplementaresInteresseContribuinte = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManifestoEletronicoDocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoCarregamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CidadeCarregamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoDescargaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DadoVeiculo_PlacaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DadoVeiculo_EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DadoVeiculoVeiculoTerceiros_EstadoProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestoEletronicoDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Cidades_CidadeCarregamentoId",
                        column: x => x.CidadeCarregamentoId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Estados_DadoVeiculo_EstadoId",
                        column: x => x.DadoVeiculo_EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Estados_DadoVeiculoVeiculoTerceiros_EstadoProprietarioId",
                        column: x => x.DadoVeiculoVeiculoTerceiros_EstadoProprietarioId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Estados_EstadoCarregamentoId",
                        column: x => x.EstadoCarregamentoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_Estados_EstadoDescargaId",
                        column: x => x.EstadoDescargaId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentos_VeiculoPlacas_DadoVeiculo_PlacaId",
                        column: x => x.DadoVeiculo_PlacaId,
                        principalTable: "VeiculoPlacas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestoEletronicoDocumentoNotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoManifestoEletronicoDocumentoNotas = table.Column<int>(type: "int", nullable: false),
                    NumeroNotaFiscal = table.Column<string>(type: "varchar(20)", nullable: true),
                    ChaveAcesso = table.Column<string>(type: "varchar(44)", nullable: true),
                    CidadeDescargaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValorNota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PesoNota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ManifestoEletronicoDocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotaFiscalEntradaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestoEletronicoDocumentoNotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoNotas_Cidades_CidadeDescargaId",
                        column: x => x.CidadeDescargaId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoNotas_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoId",
                        column: x => x.ManifestoEletronicoDocumentoId,
                        principalTable: "ManifestoEletronicoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoNotas_NotaFiscalEntradas_NotaFiscalEntradaId",
                        column: x => x.NotaFiscalEntradaId,
                        principalTable: "NotaFiscalEntradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoNotas_NotaFiscalSaidas_NotaFiscalSaidaId",
                        column: x => x.NotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestoEletronicoDocumentoPercursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManifestoEletronicoDocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestoEletronicoDocumentoPercursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoPercursos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoPercursos_ManifestoEletronicoDocumentos_ManifestoEletronicoDocumentoId",
                        column: x => x.ManifestoEletronicoDocumentoId,
                        principalTable: "ManifestoEletronicoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestoEletronicoDocumentoSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Serie = table.Column<string>(type: "varchar(3)", nullable: false),
                    UltimoManifestoEletronicoDocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestoEletronicoDocumentoSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoSeries_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestoEletronicoDocumentoSeries_ManifestoEletronicoDocumentos_UltimoManifestoEletronicoDocumentoId",
                        column: x => x.UltimoManifestoEletronicoDocumentoId,
                        principalTable: "ManifestoEletronicoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoNotas_CidadeDescargaId",
                table: "ManifestoEletronicoDocumentoNotas",
                column: "CidadeDescargaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoNotas_ManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoNotas",
                column: "ManifestoEletronicoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoNotas_NotaFiscalEntradaId",
                table: "ManifestoEletronicoDocumentoNotas",
                column: "NotaFiscalEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoNotas_NotaFiscalSaidaId",
                table: "ManifestoEletronicoDocumentoNotas",
                column: "NotaFiscalSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoPercursos_EstadoId",
                table: "ManifestoEletronicoDocumentoPercursos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoPercursos_ManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoPercursos",
                column: "ManifestoEletronicoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_CidadeCarregamentoId",
                table: "ManifestoEletronicoDocumentos",
                column: "CidadeCarregamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_DadoVeiculo_EstadoId",
                table: "ManifestoEletronicoDocumentos",
                column: "DadoVeiculo_EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_DadoVeiculo_PlacaId",
                table: "ManifestoEletronicoDocumentos",
                column: "DadoVeiculo_PlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_DadoVeiculoVeiculoTerceiros_EstadoProprietarioId",
                table: "ManifestoEletronicoDocumentos",
                column: "DadoVeiculoVeiculoTerceiros_EstadoProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_EmpresaId",
                table: "ManifestoEletronicoDocumentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_EstadoCarregamentoId",
                table: "ManifestoEletronicoDocumentos",
                column: "EstadoCarregamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentos_EstadoDescargaId",
                table: "ManifestoEletronicoDocumentos",
                column: "EstadoDescargaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_EmpresaId",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEletronicoDocumentoSeries_UltimoManifestoEletronicoDocumentoId",
                table: "ManifestoEletronicoDocumentoSeries",
                column: "UltimoManifestoEletronicoDocumentoId",
                unique: true,
                filter: "[UltimoManifestoEletronicoDocumentoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManifestoEletronicoDocumentoNotas");

            migrationBuilder.DropTable(
                name: "ManifestoEletronicoDocumentoPercursos");

            migrationBuilder.DropTable(
                name: "ManifestoEletronicoDocumentoSeries");

            migrationBuilder.DropTable(
                name: "ManifestoEletronicoDocumentos");
        }
    }
}
