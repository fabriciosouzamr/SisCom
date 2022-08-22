using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturezaOperacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumeroNotaFiscalSaida = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEmissao = table.Column<string>(type: "varchar(5)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Serie = table.Column<string>(type: "varchar(3)", nullable: false),
                    SubSerie = table.Column<string>(type: "varchar(3)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    IE = table.Column<string>(type: "varchar(20)", nullable: false),
                    End_CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_Numero = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_PontoReferencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    EMail = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorSeguro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutrasDespesas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentualDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentuaAliquotaSimplesNacional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Transportadora_FreteConta = table.Column<int>(type: "int", nullable: false),
                    Transportadora_CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    Transportadora_Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    Transportadora_RNTRC = table.Column<string>(type: "varchar(10)", nullable: false),
                    Transportadora_NumeroCarga = table.Column<int>(type: "int", nullable: false),
                    VolumeTransportados_Quantidade = table.Column<int>(type: "int", nullable: false),
                    VolumeTransportados_Especie = table.Column<string>(type: "varchar(200)", nullable: false),
                    VolumeTransportados_Marca = table.Column<string>(type: "varchar(200)", nullable: false),
                    VolumeTransportados_Numero = table.Column<int>(type: "int", nullable: false),
                    VolumeTransportados_PesoBruto = table.Column<float>(type: "real", nullable: false),
                    VolumeTransportados_PesoLiquido = table.Column<float>(type: "real", nullable: false),
                    RegimeTributario = table.Column<int>(type: "int", nullable: false),
                    ObservacaoDocumento = table.Column<string>(type: "varchar(8000)", nullable: false),
                    InformacoesAdicionaisInteresseFisco = table.Column<string>(type: "varchar(8000)", nullable: false),
                    InformacoesComplementaresInteresseContribuinte_Obsersacao = table.Column<string>(type: "varchar(8000)", nullable: false),
                    InformacoesComplementaresInteresseContribuinte_Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaveNFe = table.Column<string>(type: "varchar(44)", nullable: false),
                    Protocolo = table.Column<string>(type: "varchar(40)", nullable: false),
                    IndicaPresenca = table.Column<int>(type: "int", nullable: false),
                    TipoEmissao = table.Column<int>(type: "int", nullable: false),
                    Operacao = table.Column<int>(type: "int", nullable: false),
                    EmailDestinoXML = table.Column<string>(type: "varchar(200)", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmpresaNaturezaOperacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotaFiscalFinalidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabelaOrigemVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Transportadora_UFId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegimeTributarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InformacoesComplementaresInteresseContribuinte_UFId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Cidades_End_CidadeId",
                        column: x => x.End_CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Estados_InformacoesComplementaresInteresseContribuinte_UFId",
                        column: x => x.InformacoesComplementaresInteresseContribuinte_UFId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Estados_Transportadora_UFId",
                        column: x => x.Transportadora_UFId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_NaturezaOperacoes_NaturezaOperacaoId",
                        column: x => x.NaturezaOperacaoId,
                        principalTable: "NaturezaOperacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_NotaFiscalFinalidades_NotaFiscalFinalidadeId",
                        column: x => x.NotaFiscalFinalidadeId,
                        principalTable: "NotaFiscalFinalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Pessoas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidas_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalSaidaMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<float>(type: "real", nullable: false),
                    PrecoUnitario = table.Column<float>(type: "real", nullable: false),
                    PrecoTotal = table.Column<float>(type: "real", nullable: false),
                    PercentualICMS = table.Column<float>(type: "real", nullable: false),
                    PercentualIPI = table.Column<float>(type: "real", nullable: false),
                    PercentualFrete = table.Column<float>(type: "real", nullable: false),
                    NotaFiscalSaidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabelaNCMId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabelaCST_CSOSNId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TabelaCFOPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnidadeMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalSaidaMercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_NotaFiscalSaidas_NotaFiscalSaidaId",
                        column: x => x.NotaFiscalSaidaId,
                        principalTable: "NotaFiscalSaidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_TabelaCFOPs_TabelaCFOPId",
                        column: x => x.TabelaCFOPId,
                        principalTable: "TabelaCFOPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_TabelaCST_CSOSNs_TabelaCST_CSOSNId",
                        column: x => x.TabelaCST_CSOSNId,
                        principalTable: "TabelaCST_CSOSNs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_TabelaNCMs_TabelaNCMId",
                        column: x => x.TabelaNCMId,
                        principalTable: "TabelaNCMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaFiscalSaidaMercadorias_UnidadeMedidas_UnidadeMedidaId",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadeMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_MercadoriaId",
                table: "NotaFiscalSaidaMercadorias",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_NotaFiscalSaidaId",
                table: "NotaFiscalSaidaMercadorias",
                column: "NotaFiscalSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCFOPId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCFOPId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaCST_CSOSNId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaCST_CSOSNId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_TabelaNCMId",
                table: "NotaFiscalSaidaMercadorias",
                column: "TabelaNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidaMercadorias_UnidadeMedidaId",
                table: "NotaFiscalSaidaMercadorias",
                column: "UnidadeMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_ClienteId",
                table: "NotaFiscalSaidas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_EmpresaId",
                table: "NotaFiscalSaidas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_End_CidadeId",
                table: "NotaFiscalSaidas",
                column: "End_CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_InformacoesComplementaresInteresseContribuinte_UFId",
                table: "NotaFiscalSaidas",
                column: "InformacoesComplementaresInteresseContribuinte_UFId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_NaturezaOperacaoId",
                table: "NotaFiscalSaidas",
                column: "NaturezaOperacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_NotaFiscalFinalidadeId",
                table: "NotaFiscalSaidas",
                column: "NotaFiscalFinalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_Transportadora_UFId",
                table: "NotaFiscalSaidas",
                column: "Transportadora_UFId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalSaidas_TransportadoraId",
                table: "NotaFiscalSaidas",
                column: "TransportadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscalSaidaMercadorias");

            migrationBuilder.DropTable(
                name: "NotaFiscalSaidas");
        }
    }
}
