using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almoxarifados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almoxarifados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", nullable: false),
                    AcessoFinanceiro = table.Column<bool>(type: "bit", nullable: false),
                    AcessoFiscal = table.Column<bool>(type: "bit", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    Desativado = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoCFOPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoOperacaoCFOP = table.Column<int>(type: "int", nullable: false),
                    TipoOperacaoCFOPId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoCFOPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    NaoVender = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoMercadorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNaturezaReceita_CTS_PIS_COFINSs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoNCM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNCM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Similares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Similares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaANPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaANPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaBeneficioSPEDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(8)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaBeneficioSPEDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaClasseEnquadramentoIPIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(5)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaClasseEnquadramentoIPIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCNAEs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(7)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCNAEs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCodigoEnquadramentoIPIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoTabelaCodigoEnquadramentoIPI = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(3)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCodigoEnquadramentoIPIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCST_CSOSNs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(3)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    DestacarICMS = table.Column<bool>(type: "bit", nullable: false),
                    DestacarICMSST = table.Column<bool>(type: "bit", nullable: false),
                    PossuiDesoneracaoICMS = table.Column<bool>(type: "bit", nullable: false),
                    CRT = table.Column<int>(type: "int", nullable: false),
                    ST = table.Column<string>(type: "varchar(2)", nullable: true),
                    CSTEquivalente = table.Column<string>(type: "varchar(3)", nullable: true),
                    PossuiDiferimentoICMS = table.Column<bool>(type: "bit", nullable: false),
                    PossuiReducaoICMS = table.Column<bool>(type: "bit", nullable: false),
                    DestacarICMSSTEfetivo = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCST_CSOSNs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCST_IPIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    EntradaSaida = table.Column<int>(type: "int", nullable: false),
                    DestacarIPI = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCST_IPIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCST_PIS_COFINSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    DestacarPIS_COFINS = table.Column<bool>(type: "bit", nullable: false),
                    UsaNaEntrada = table.Column<bool>(type: "bit", nullable: false),
                    UsaNaSaida = table.Column<bool>(type: "bit", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCST_PIS_COFINSs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaModalidadeDeterminacaoBCICMSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(1)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    TipoModalidadeDeterminacaoBCICMS = table.Column<int>(type: "int", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaModalidadeDeterminacaoBCICMSs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaOrigemMercadoriaServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(1)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaOrigemMercadoriaServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaSituacaoTributariaNFCes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "char(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaSituacaoTributariaNFCes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaSpedCodigoGeneros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaSpedCodigoGeneros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaSpedInformacaoAdicionalItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(8)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaSpedInformacaoAdicionalItens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaSpedTipoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaSpedTipoItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercadorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeMedidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "char(3)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeMedidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VinculoFiscais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoFiscais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCFOPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(4)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    GrupoCFOPId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCFOPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaCFOPs_GrupoCFOPs_GrupoCFOPId",
                        column: x => x.GrupoCFOPId,
                        principalTable: "GrupoCFOPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGrupoMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    GrupoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupoMercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGrupoMercadorias_GrupoMercadorias_GrupoMercadoriaId",
                        column: x => x.GrupoMercadoriaId,
                        principalTable: "GrupoMercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TabelaNaturezaReceita_CTS_PIS_COFINSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "char(5)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    GrupoNaturezaReceita_CTS_PIS_COFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaNaturezaReceita_CTS_PIS_COFINSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaNaturezaReceita_CTS_PIS_COFINSs_GrupoNaturezaReceita_CTS_PIS_COFINSs_GrupoNaturezaReceita_CTS_PIS_COFINSId",
                        column: x => x.GrupoNaturezaReceita_CTS_PIS_COFINSId,
                        principalTable: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TabelaNCMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(8)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    GrupoNCMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaNCMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaNCMs_GrupoNCM_GrupoNCMId",
                        column: x => x.GrupoNCMId,
                        principalTable: "GrupoNCM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "char(2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    PaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicoFiscais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(7)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    TabelaCNAEId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicoFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoServicoFiscais_TabelaCNAEs_TabelaCNAEId",
                        column: x => x.TabelaCNAEId,
                        principalTable: "TabelaCNAEs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TabelaMotivoDesoneracaoICMSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    TabelaCST_CSOSNId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaMotivoDesoneracaoICMSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaMotivoDesoneracaoICMSs_TabelaCST_CSOSNs_TabelaCST_CSOSNId",
                        column: x => x.TabelaCST_CSOSNId,
                        principalTable: "TabelaCST_CSOSNs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCESTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(7)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    TabelaNCMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCESTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaCESTs_TabelaNCMs_TabelaNCMId",
                        column: x => x.TabelaNCMId,
                        principalTable: "TabelaNCMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoIBGE = table.Column<string>(type: "varchar(8)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    Unidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(15)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(15)", nullable: true),
                    InscricaoEstadual_SubTributaria = table.Column<string>(type: "varchar(15)", nullable: true),
                    End_CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    End_Logradouro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    End_Numero = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    End_Bairro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    End_PontoReferencia = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: true),
                    RegimeTributario = table.Column<int>(type: "int", nullable: true),
                    CreditoSimplesNacional = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDesativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NFE_Ambiente = table.Column<int>(type: "int", nullable: true),
                    NFE_VersaoEmissor = table.Column<string>(type: "varchar(20)", nullable: true),
                    NFE_Layout = table.Column<int>(type: "int", nullable: true),
                    NFE_Serie = table.Column<string>(type: "varchar(2)", nullable: true),
                    PathLogomarca = table.Column<string>(type: "varchar(200)", nullable: true),
                    ImagemLogomarca = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Sped_TipoGeracaoInventario = table.Column<int>(type: "int", nullable: true),
                    MDFe_Serie = table.Column<string>(type: "varchar(3)", nullable: true),
                    MDFe_Ambiente = table.Column<int>(type: "int", nullable: true),
                    MDFe_TipoEmirssor = table.Column<int>(type: "int", nullable: true),
                    NuvemFiscal_Usar = table.Column<bool>(type: "bit", nullable: false),
                    NuvemFiscal_AmbienteWebService = table.Column<int>(type: "int", nullable: true),
                    NuvemFiscal_Certificado = table.Column<string>(type: "varchar(200)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Cidades_End_CidadeId",
                        column: x => x.End_CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoContribuinte = table.Column<int>(type: "int", nullable: true),
                    RG = table.Column<string>(type: "varchar(20)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(15)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(15)", nullable: true),
                    End_CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_Numero = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    End_Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    End_PontoReferencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    FAX = table.Column<string>(type: "varchar(20)", nullable: true),
                    NomeContato = table.Column<string>(type: "varchar(50)", nullable: true),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: true),
                    Site = table.Column<string>(type: "varchar(100)", nullable: true),
                    Representante = table.Column<string>(type: "varchar(100)", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    RegimeTributario = table.Column<int>(type: "int", nullable: true),
                    SelecionarEtiqueta = table.Column<bool>(type: "bit", nullable: false),
                    Desativado = table.Column<bool>(type: "bit", nullable: false),
                    UsarFoto = table.Column<bool>(type: "bit", nullable: false),
                    Imagem = table.Column<byte[]>(type: "image", nullable: true),
                    DatCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fornecedor = table.Column<bool>(type: "bit", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Cidades_End_CidadeId",
                        column: x => x.End_CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_Funcionarios_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_TipoClientes_TipoClienteId",
                        column: x => x.TipoClienteId,
                        principalTable: "TipoClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFabricante = table.Column<string>(type: "varchar(50)", nullable: true),
                    CodigoBarra = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    NaoVender = table.Column<bool>(type: "bit", nullable: false),
                    NaoControlarEstoque = table.Column<bool>(type: "bit", nullable: false),
                    Ativado = table.Column<bool>(type: "bit", nullable: false),
                    Preco_PrecoCompra = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_ICMS_Compra = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_ICMS_Fronteira = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_IPI = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_Frete = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_Embalagem = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_EncFinanceiro = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_CustoMercadoria = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_CustoFixo = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_ImpostoFederais = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_ICMS_Venda = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_Comissao = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_Marketing = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_OutrosCustos = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PontoEquilibrio = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_MargemSugerido = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PrecoSugerido = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_MargemVenda = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PrecoVenda = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_MargemA = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PrecoA = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_MargemB = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PrecoB = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_MargemC = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_PrecoC = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_CalculoPreco = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Preco_CalculoPrecificacao = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Estoque_Quantidade = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Estoque_QuantidadeMinimo = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Estoque_UnidadeMedidaMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Estoque_Pratileira = table.Column<string>(type: "varchar(20)", nullable: true),
                    Estoque_PesoBruto = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Estoque_PesoLiquido = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Estoque_UltimaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estoque_AlteracaoPreco = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estoque_TributacaoNFCe_AliquotaICMS = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Estoque_TributacaoNFCe_TipoServicoMunicipal = table.Column<string>(type: "varchar(10)", nullable: true),
                    Fiscal_InformacaoAdicional = table.Column<string>(type: "varchar(200)", nullable: true),
                    Fiscal_CodigoAnvisa = table.Column<string>(type: "varchar(13)", nullable: true),
                    Fiscal_NFE_IPI_Aliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFE_PIS_Aliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFE_COFINS_Aliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMS_ValorAdicional = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMS_Deferimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMS_ReducaoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMSST_ValorAdicional = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMSST_Aliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ICMSST_ReducaoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_IPI_ValorAliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_PISCOFINS_PIS_ValorAliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_OutrosPMC = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_OutrosNVE = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_TributosFederais = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_TributosMunicipais = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_TributosEstaduais = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_TributosTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fiscal_NFS_ValorTributosTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Producao_Configuracao_ValidadeDias = table.Column<int>(type: "int", nullable: false),
                    Producao_Configuracao_NaoBaixarComposicaoVenda = table.Column<bool>(type: "bit", nullable: false),
                    FotoEspecificacao_Especificacao = table.Column<string>(type: "text", nullable: true),
                    FotoEspecificacao_URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    FotoEspecificacao_UsarFoto = table.Column<bool>(type: "bit", nullable: false),
                    FotoEspecificacao_Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GrupoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubGrupoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Estoque_UnidadeMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Estoque_TributacaoNFCe_TabelaCFOPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Estoque_TributacaoNFCe_TipoServicoFiscalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_VinculoFiscalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TipoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaANPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaNCMId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaCESTId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaOrigemMercadoriaServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaCST_CSOSNId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_TabelaBeneficioSPEDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFE_TabelaCST_IPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFE_TabelaCST_COFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFE_TabelaCST_PISId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_IPI_TabelaCST_IPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_SPED_TabelaSpedTipoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_SPED_TabelaSpedCodigoGeneroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mercadorias_GrupoMercadorias_GrupoMercadoriaId",
                        column: x => x.GrupoMercadoriaId,
                        principalTable: "GrupoMercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_GrupoNaturezaReceita_CTS_PIS_COFINSs_Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId",
                        column: x => x.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId,
                        principalTable: "GrupoNaturezaReceita_CTS_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_Pessoas_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_Pessoas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_SubGrupoMercadorias_SubGrupoMercadoriaId",
                        column: x => x.SubGrupoMercadoriaId,
                        principalTable: "SubGrupoMercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaANPs_Fiscal_TabelaANPId",
                        column: x => x.Fiscal_TabelaANPId,
                        principalTable: "TabelaANPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaBeneficioSPEDs_Fiscal_TabelaBeneficioSPEDId",
                        column: x => x.Fiscal_TabelaBeneficioSPEDId,
                        principalTable: "TabelaBeneficioSPEDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCESTs_Fiscal_TabelaCESTId",
                        column: x => x.Fiscal_TabelaCESTId,
                        principalTable: "TabelaCESTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCFOPs_Estoque_TributacaoNFCe_TabelaCFOPId",
                        column: x => x.Estoque_TributacaoNFCe_TabelaCFOPId,
                        principalTable: "TabelaCFOPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaClasseEnquadramentoIPIs_Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId",
                        column: x => x.Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId,
                        principalTable: "TabelaClasseEnquadramentoIPIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCodigoEnquadramentoIPIs_Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId",
                        column: x => x.Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId,
                        principalTable: "TabelaCodigoEnquadramentoIPIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_CSOSNs_Fiscal_TabelaCST_CSOSNId",
                        column: x => x.Fiscal_TabelaCST_CSOSNId,
                        principalTable: "TabelaCST_CSOSNs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_IPIs_Fiscal_NFE_TabelaCST_IPIId",
                        column: x => x.Fiscal_NFE_TabelaCST_IPIId,
                        principalTable: "TabelaCST_IPIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_IPIs_Fiscal_NFS_IPI_TabelaCST_IPIId",
                        column: x => x.Fiscal_NFS_IPI_TabelaCST_IPIId,
                        principalTable: "TabelaCST_IPIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_PIS_COFINSs_Fiscal_NFE_TabelaCST_COFINSId",
                        column: x => x.Fiscal_NFE_TabelaCST_COFINSId,
                        principalTable: "TabelaCST_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_PIS_COFINSs_Fiscal_NFE_TabelaCST_PISId",
                        column: x => x.Fiscal_NFE_TabelaCST_PISId,
                        principalTable: "TabelaCST_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_PIS_COFINSs_Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId",
                        column: x => x.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId,
                        principalTable: "TabelaCST_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaCST_PIS_COFINSs_Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId",
                        column: x => x.Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId,
                        principalTable: "TabelaCST_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaModalidadeDeterminacaoBCICMSs_Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId",
                        column: x => x.Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId,
                        principalTable: "TabelaModalidadeDeterminacaoBCICMSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaModalidadeDeterminacaoBCICMSs_Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId",
                        column: x => x.Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId,
                        principalTable: "TabelaModalidadeDeterminacaoBCICMSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaMotivoDesoneracaoICMSs_Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId",
                        column: x => x.Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId,
                        principalTable: "TabelaMotivoDesoneracaoICMSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaNaturezaReceita_CTS_PIS_COFINSs_Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId",
                        column: x => x.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId,
                        principalTable: "TabelaNaturezaReceita_CTS_PIS_COFINSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaNCMs_Fiscal_TabelaNCMId",
                        column: x => x.Fiscal_TabelaNCMId,
                        principalTable: "TabelaNCMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaOrigemMercadoriaServicos_Fiscal_TabelaOrigemMercadoriaServicoId",
                        column: x => x.Fiscal_TabelaOrigemMercadoriaServicoId,
                        principalTable: "TabelaOrigemMercadoriaServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaSituacaoTributariaNFCes_Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId",
                        column: x => x.Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId,
                        principalTable: "TabelaSituacaoTributariaNFCes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaSpedCodigoGeneros_Fiscal_SPED_TabelaSpedCodigoGeneroId",
                        column: x => x.Fiscal_SPED_TabelaSpedCodigoGeneroId,
                        principalTable: "TabelaSpedCodigoGeneros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaSpedInformacaoAdicionalItens_Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId",
                        column: x => x.Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId,
                        principalTable: "TabelaSpedInformacaoAdicionalItens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TabelaSpedTipoItems_Fiscal_SPED_TabelaSpedTipoItemId",
                        column: x => x.Fiscal_SPED_TabelaSpedTipoItemId,
                        principalTable: "TabelaSpedTipoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TipoMercadorias_Fiscal_TipoMercadoriaId",
                        column: x => x.Fiscal_TipoMercadoriaId,
                        principalTable: "TipoMercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_TipoServicoFiscais_Estoque_TributacaoNFCe_TipoServicoFiscalId",
                        column: x => x.Estoque_TributacaoNFCe_TipoServicoFiscalId,
                        principalTable: "TipoServicoFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeMedidaMedidaId",
                        column: x => x.Estoque_UnidadeMedidaMedidaId,
                        principalTable: "UnidadeMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercadorias_VinculoFiscais_Fiscal_VinculoFiscalId",
                        column: x => x.Fiscal_VinculoFiscalId,
                        principalTable: "VinculoFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeEmEstoque = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    QuantidadeBloqueada = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AlmoxarifadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoques_Almoxarifados_AlmoxarifadoId",
                        column: x => x.AlmoxarifadoId,
                        principalTable: "Almoxarifados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoques_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MercadoriaFornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoFonecedor = table.Column<string>(type: "varchar(50)", nullable: false),
                    QuantidadePorCaixa = table.Column<double>(type: "float", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercadoriaFornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MercadoriaFornecedores_Mercadorias_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MercadoriaFornecedores_Pessoas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "AcessoFinanceiro", "AcessoFiscal", "Administrador", "Desativado", "Nome", "Senha", "UltimaAtualizacao" },
                values: new object[] { new Guid("da27e6d8-a881-4ccc-8327-7706124fb272"), true, true, true, true, "Administrador", "1234", new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(9151) });

            migrationBuilder.InsertData(
                table: "GrupoCFOPs",
                columns: new[] { "Id", "Nome", "TipoOperacaoCFOP", "TipoOperacaoCFOPId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("38c5afbb-f5ce-49d1-8732-1f2062040ab4"), "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(482) },
                    { new Guid("3b5e76c2-252e-4c8b-b0ae-f4d8619cc9b7"), "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(497) },
                    { new Guid("7e5e23da-1b3b-40d3-90cf-9802a1da4559"), "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(501) },
                    { new Guid("97b64ec3-6c73-4daa-b83d-c7f3b8e8755f"), "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(504) },
                    { new Guid("95a12925-2294-46da-a60d-772fb43603a8"), "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(508) },
                    { new Guid("a8c97764-ff04-4738-9e99-81905fed5d8b"), "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", 7, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(512) }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[] { new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), "Brasil", new DateTime(2022, 3, 4, 19, 9, 33, 778, DateTimeKind.Local).AddTicks(9098) });

            migrationBuilder.InsertData(
                table: "TabelaCST_IPIs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarIPI", "EntradaSaida", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("ce168fc0-7539-4b0d-b476-18c4b0b1ad60"), "99", "Outras Saídas", true, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2583) },
                    { new Guid("27d5e0d8-bff8-4af0-936a-3fa966066cb4"), "55", "Saída com Suspensão", false, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2580) },
                    { new Guid("92c5d0cc-2d7b-46dc-8e73-bffd9f28272c"), "54", "Saída Imune", false, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2577) },
                    { new Guid("c56c4aea-a839-4916-8692-c44693f7408e"), "52", "Saída Isenta", false, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2568) },
                    { new Guid("e70d1cfe-5b5d-43af-b492-1dceb780942b"), "51", "Saída Tributável com Alíquota Zero", false, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2564) },
                    { new Guid("57e634a1-4f5f-4541-8b99-b3d35847213d"), "50", "Saída Tributada", true, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2560) },
                    { new Guid("7464b751-c514-48b4-b71c-da1d276a0520"), "53", "Saída Não-Tributada", false, 2, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2574) },
                    { new Guid("95c06bbb-7201-4e86-8c87-8830eff579f5"), "05", "Entrada com Suspensão", false, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2553) },
                    { new Guid("aa7847ec-0036-4d04-a8fc-d2f8e954179d"), "04", "Entrada Imune", false, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2549) },
                    { new Guid("36ebcacc-7a28-430c-92cc-5a7525155ae7"), "03", "Entrada Não-Tributada", false, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2546) },
                    { new Guid("77b2fc77-176e-4186-a2b7-9b1606093500"), "02", "Entrada Isenta", false, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2542) },
                    { new Guid("68382e40-33b0-4630-a686-eb8f4d72b570"), "01", "Entrada Tributável com Alíquota Zero", false, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2531) },
                    { new Guid("bdc5345a-f3f9-4629-abbc-87640f6173dd"), "00", "Entrada com Recuperação de Crédito", true, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2518) },
                    { new Guid("2ba13d85-3c88-4497-b36e-135e30ed5021"), "49", "Outras Entradas", true, 1, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(2556) }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("dc50d618-7295-4fe6-9d74-b2118cd9e2a7"), "62", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5195), true, false },
                    { new Guid("6dbd631d-f505-461d-a097-f45651bae8b6"), "63", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5201), true, false },
                    { new Guid("ef9c920c-47a5-4814-9fd1-a1747724dd30"), "64", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5205), true, false },
                    { new Guid("7ddb8f0f-5c53-41f1-8cfb-e20f280eb99e"), "65", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5208), true, false },
                    { new Guid("1f3f4c42-2c63-4e70-bc50-8987d319af76"), "66", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5211), true, false },
                    { new Guid("afb18ec9-5e18-4320-a09c-8a6df17dfa52"), "67", "Crédito Presumido -Outras Operações", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5215), true, false },
                    { new Guid("27f2b29c-41cb-40e4-a06e-fb3f8ac2c7e0"), "70", "Operação de Aquisição sem Direito a Crédito", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5219), true, false },
                    { new Guid("1fb2e2d3-63e8-43bc-a247-5e3b6ea96e00"), "73", "Operação de Aquisição a Alíquota Zero", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5231), true, false },
                    { new Guid("3ca50010-fb85-4cba-8d26-7fa2a38bfe6e"), "72", "Operação de Aquisição com Suspensão", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5225), true, false },
                    { new Guid("7b09eced-cf84-4a4a-9a0d-f5ac8a4bc0d5"), "74", "Operação de Aquisição sem Incidência da Contribuição", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5234), true, false },
                    { new Guid("22b0550b-4225-4a7a-9076-a2f6ddd65877"), "75", "Operação de Aquisição por Substituição Tributária", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5237), true, false },
                    { new Guid("8813b358-a3b6-4a1a-83c4-141277f52761"), "98", "Outras Operações de Entrada", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5240), true, false },
                    { new Guid("8ecabc23-81a5-4d05-8520-1974edd37d58"), "99", "Outras Operações", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5244), true, true },
                    { new Guid("742f4257-ea04-43cd-9f8f-11a202a35494"), "61", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5192), true, false },
                    { new Guid("5c70f295-8592-4d90-8d4c-de78a1c5223b"), "71", "Operação de Aquisição com Isenção", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5222), true, false },
                    { new Guid("cd8e68c5-f98f-450f-9d5f-8b1ba75272e2"), "60", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5189), true, false },
                    { new Guid("067b343b-f84d-4d77-b775-8999670edd60"), "55", "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5182), true, false },
                    { new Guid("d3e9212d-55dd-44a9-9cdf-86c773379b38"), "02", "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4754), false, true },
                    { new Guid("ddf89583-e3aa-460e-9922-b0487000d89c"), "01", "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4736), false, true },
                    { new Guid("2a7212d1-ec9a-41f3-bf8a-d785238e432d"), "03", "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4758), false, true }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("d2fc723b-c790-42f7-94b5-07ef093dbbe7"), "04", "Operação Tributável (tributação monofásica (alíquota zero))", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4761), false, true },
                    { new Guid("4a30dcbd-6b88-4749-ab73-cd7f19c2a1c4"), "05", "Operação Tributável por Substituição Tributária", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4771), false, true },
                    { new Guid("d2cb5bc7-6c81-4725-9851-e8b24852841a"), "06", "Operação Tributável (alíquota zero)", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4775), false, true },
                    { new Guid("3664428c-d082-420f-8bb2-b8edbfc7a694"), "07", "Operação Isenta da Contribuição", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4778), false, true },
                    { new Guid("07522bc4-016a-48f8-9104-721e9f837288"), "08", "Operação Sem Incidência da Contribuição", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4782), false, true },
                    { new Guid("c1528d4f-37cb-4c2b-b0b3-e750bef2933e"), "49", "Outras Operações de Saída", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4790), false, true },
                    { new Guid("ce87c0f3-efab-491a-83bf-f865b4776a4c"), "50", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5151), true, false },
                    { new Guid("891f830f-cdb6-45e9-ba6d-d122e701ca9d"), "51", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5162), true, false },
                    { new Guid("4185f7ee-ec4a-40b6-b7b2-b0f2605b0d61"), "52", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5171), true, false },
                    { new Guid("ef961f9f-ef19-40a9-adfd-dead6da15713"), "53", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5175), true, false },
                    { new Guid("bb4b7a54-f23d-4852-a495-05f40300c678"), "54", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5178), true, false },
                    { new Guid("9d20dc73-49fe-431d-ae6d-f6380225cfba"), "09", "Operação com Suspensão da Contribuição", false, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(4786), false, true },
                    { new Guid("d6580629-a5c0-42e2-95f6-2d66609a1827"), "56", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", true, new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(5185), true, false }
                });

            migrationBuilder.InsertData(
                table: "TabelaSituacaoTributariaNFCes",
                columns: new[] { "Id", "Codigo", "Descricao", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("49c7c66a-3dd6-4c0b-aa54-546d6a6b0d23"), "II", "Isento", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(6692) },
                    { new Guid("e38c6e00-f0fa-4e42-accd-ca1239b1f681"), "NN", "Não Incidente", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(6701) },
                    { new Guid("71abf482-3029-459c-8875-45051ad96737"), "FF", "Substituição", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(6689) },
                    { new Guid("080f047f-58f9-466a-8432-8effa2060d5d"), "01", "Normal(% TRIBUTADO)", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(6676) }
                });

            migrationBuilder.InsertData(
                table: "TipoClientes",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[] { new Guid("7188fcb0-c909-4bf7-b2be-b01fe25d7380"), "CONSUMIDOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TipoMercadorias",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("6ac65b65-6003-41a2-be66-341d65603caa"), "VEÍCULO", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(8794) },
                    { new Guid("a060c353-8c9b-4d54-9b9b-8678ea14ea42"), "COMBUSTÍVEL", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(8808) },
                    { new Guid("6ac17134-3dbd-4d23-92f2-5c752b79c5f4"), "MEDICAMENTO", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(8811) },
                    { new Guid("081d7a38-93ac-4b02-aad2-9f50cc783746"), "ARMAMENTO", new DateTime(2022, 3, 4, 19, 9, 33, 782, DateTimeKind.Local).AddTicks(8814) }
                });

            migrationBuilder.InsertData(
                table: "UnidadeMedidas",
                columns: new[] { "Id", "Codigo", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("3e234e39-c6ee-4b9d-b479-e911a06578fb"), "PCT", "Pacote", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(113) },
                    { new Guid("f76c0b6c-c074-49e4-b4f4-2a938bfd732f"), "FRC", "Frasco", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(120) },
                    { new Guid("b5fa02aa-0165-462f-aa6f-8347380a205d"), "SCO", "Saco", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(116) },
                    { new Guid("16b18a3b-4ca5-4e17-aa5f-2456f8fa9819"), "LTR", "Litro ", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(110) },
                    { new Guid("9db13ddc-5f9a-4f5e-b8f0-d0937ff69abe"), "GR", "Grama", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(123) },
                    { new Guid("f47935ed-4ab5-46a7-9a88-5fc48d75b4e6"), "MTR", "Metro", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(103) },
                    { new Guid("1ebbe3bf-e8a6-4a79-88fb-e30494a7ba0a"), "PCA", "Peca", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(100) },
                    { new Guid("6c169b00-4128-4fd3-a89e-00a4b326ca5a"), "CXA", "Caixa", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(90) },
                    { new Guid("7e67de11-e681-4303-8b84-89dfb7470f6b"), "UND", "Unidade", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(77) },
                    { new Guid("24b41325-3be1-4a90-92c6-f8c3eebab236"), "KG", "Kilograma", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(106) },
                    { new Guid("3142866a-d9cc-4ede-b07e-87829aeb0f14"), "FRD", "Fardo", new DateTime(2022, 3, 4, 19, 9, 33, 783, DateTimeKind.Local).AddTicks(128) }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("971c14e6-6903-4467-8794-4fcc17891694"), "AC", "Acre", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(5995) },
                    { new Guid("18abf346-ad59-47e7-8c73-f9e4d9afa17b"), "SP", "São Paulo", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6172) },
                    { new Guid("dade771b-ab82-4c3a-97a2-f6a332c736d5"), "SC", "Santa Catarina", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6169) },
                    { new Guid("eeebc2b4-1c83-4725-987a-ca66e09cb0a3"), "RR", "Roraima", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6166) },
                    { new Guid("f5902f8c-da79-4b99-b121-1642643ef2e0"), "RO", "Rondônia", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6162) },
                    { new Guid("6ffdec0d-bb88-4380-b15f-b12fff160733"), "RS", "Rio Grande do Sul", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6159) },
                    { new Guid("3c0b3730-a2ec-4ec9-8f51-df7b13c1cdee"), "RN", "Rio Grande do Norte", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6152) },
                    { new Guid("a4e895e8-d411-4944-992c-a6871293da1c"), "RJ", "Rio de Janeiro", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6149) },
                    { new Guid("e121afce-f11f-4361-b046-75ecd173dca0"), "PI", "Piauí", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6146) },
                    { new Guid("88213846-705a-408b-97d1-0d2bfca2d40d"), "PE", "Pernambuco", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6141) },
                    { new Guid("db096a78-9151-4dd1-81d6-94d902425fe3"), "PR", "Paraná", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6138) },
                    { new Guid("5ef8cb03-6b3e-4b81-b9e3-fd858715a172"), "PB", "Paraíba", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6135) },
                    { new Guid("265a5322-92c0-49bf-b7c8-77169fe7f7d8"), "SE", "Sergipe", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6175) },
                    { new Guid("5b72ffe2-f24c-4f38-af3e-76e0b629c949"), "PA", "Pará", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6131) },
                    { new Guid("7843f65a-da06-45a4-9a1e-7f9a42869c3c"), "MT", "Mato Grosso", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6120) },
                    { new Guid("9e620a8d-f63a-4ce8-a7dc-421601baac14"), "MS", "Mato Grosso do Sul", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6116) },
                    { new Guid("51c8bbd0-fede-4e2b-9855-845320a79906"), "MA", "Maranhão", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6113) },
                    { new Guid("1694ed05-6ff5-4c4f-aa86-04446e664fbb"), "GO", "Goias", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6108) },
                    { new Guid("d4f6c75d-8ac3-4142-b09b-49719ea628b6"), "ES", "Espirito Santo", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6104) },
                    { new Guid("60559bf8-ab2c-47e3-bc73-165e86e66091"), "DF", "Distrito Federal", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6100) },
                    { new Guid("227b9123-fd38-4faa-b73e-e582b7b5fe4a"), "CE", "Ceará", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6096) },
                    { new Guid("12b4bad9-6dbf-4ced-9c51-02252506fca4"), "BA", "Bahia", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6091) },
                    { new Guid("6d70dce6-75ff-4c4b-a16b-0b80e036e30f"), "AM", "Amazonas", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6067) },
                    { new Guid("ee65945d-19f7-4d25-80d9-aea6ba22fc41"), "AP", "Amapá", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6062) },
                    { new Guid("932903c0-c73a-490f-b8b5-e4ef13b73c1f"), "AL", "Alagoas", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6058) },
                    { new Guid("1ff917d9-a137-4f46-8112-889aa97b5a38"), "MG", "Minas Gerais", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6127) },
                    { new Guid("3c32ea2c-9026-4caa-b759-e02f18fd71eb"), "EX", "Exterior", new Guid("2928f9c6-cbe6-4417-bbf9-bd525bfdf4c9"), new DateTime(2022, 3, 4, 19, 9, 33, 781, DateTimeKind.Local).AddTicks(6179) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_End_CidadeId",
                table: "Empresas",
                column: "End_CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_AlmoxarifadoId",
                table: "Estoques",
                column: "AlmoxarifadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_MercadoriaId",
                table: "Estoques",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaFornecedores_FornecedorId",
                table: "MercadoriaFornecedores",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoriaFornecedores_MercadoriaId",
                table: "MercadoriaFornecedores",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_TributacaoNFCe_TabelaCFOPId",
                table: "Mercadorias",
                column: "Estoque_TributacaoNFCe_TabelaCFOPId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId",
                table: "Mercadorias",
                column: "Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_TributacaoNFCe_TipoServicoFiscalId",
                table: "Mercadorias",
                column: "Estoque_TributacaoNFCe_TipoServicoFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Estoque_UnidadeMedidaMedidaId",
                table: "Mercadorias",
                column: "Estoque_UnidadeMedidaMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_FabricanteId",
                table: "Mercadorias",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFE_TabelaCST_COFINSId",
                table: "Mercadorias",
                column: "Fiscal_NFE_TabelaCST_COFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFE_TabelaCST_IPIId",
                table: "Mercadorias",
                column: "Fiscal_NFE_TabelaCST_IPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFE_TabelaCST_PISId",
                table: "Mercadorias",
                column: "Fiscal_NFE_TabelaCST_PISId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId",
                table: "Mercadorias",
                column: "Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId",
                table: "Mercadorias",
                column: "Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId",
                table: "Mercadorias",
                column: "Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId",
                table: "Mercadorias",
                column: "Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId",
                table: "Mercadorias",
                column: "Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_IPI_TabelaCST_IPIId",
                table: "Mercadorias",
                column: "Fiscal_NFS_IPI_TabelaCST_IPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId",
                table: "Mercadorias",
                column: "Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId",
                table: "Mercadorias",
                column: "Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId",
                table: "Mercadorias",
                column: "Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId",
                table: "Mercadorias",
                column: "Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_SPED_TabelaSpedCodigoGeneroId",
                table: "Mercadorias",
                column: "Fiscal_SPED_TabelaSpedCodigoGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId",
                table: "Mercadorias",
                column: "Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_SPED_TabelaSpedTipoItemId",
                table: "Mercadorias",
                column: "Fiscal_SPED_TabelaSpedTipoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaANPId",
                table: "Mercadorias",
                column: "Fiscal_TabelaANPId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaBeneficioSPEDId",
                table: "Mercadorias",
                column: "Fiscal_TabelaBeneficioSPEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaCESTId",
                table: "Mercadorias",
                column: "Fiscal_TabelaCESTId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaCST_CSOSNId",
                table: "Mercadorias",
                column: "Fiscal_TabelaCST_CSOSNId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaNCMId",
                table: "Mercadorias",
                column: "Fiscal_TabelaNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TabelaOrigemMercadoriaServicoId",
                table: "Mercadorias",
                column: "Fiscal_TabelaOrigemMercadoriaServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_TipoMercadoriaId",
                table: "Mercadorias",
                column: "Fiscal_TipoMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_Fiscal_VinculoFiscalId",
                table: "Mercadorias",
                column: "Fiscal_VinculoFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_FornecedorId",
                table: "Mercadorias",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_GrupoMercadoriaId",
                table: "Mercadorias",
                column: "GrupoMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_SubGrupoMercadoriaId",
                table: "Mercadorias",
                column: "SubGrupoMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoas_CNPJ_CPF",
                table: "Pessoas",
                column: "CNPJ_CPF",
                unique: true)
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_End_CidadeId",
                table: "Pessoas",
                column: "End_CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TipoClienteId",
                table: "Pessoas",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_VendedorId",
                table: "Pessoas",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupoMercadorias_GrupoMercadoriaId",
                table: "SubGrupoMercadorias",
                column: "GrupoMercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaCESTs_TabelaNCMId",
                table: "TabelaCESTs",
                column: "TabelaNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaCFOPs_GrupoCFOPId",
                table: "TabelaCFOPs",
                column: "GrupoCFOPId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaMotivoDesoneracaoICMSs_TabelaCST_CSOSNId",
                table: "TabelaMotivoDesoneracaoICMSs",
                column: "TabelaCST_CSOSNId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaNaturezaReceita_CTS_PIS_COFINSs_GrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "TabelaNaturezaReceita_CTS_PIS_COFINSs",
                column: "GrupoNaturezaReceita_CTS_PIS_COFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaNCMs_GrupoNCMId",
                table: "TabelaNCMs",
                column: "GrupoNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoServicoFiscais_TabelaCNAEId",
                table: "TipoServicoFiscais",
                column: "TabelaCNAEId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "MercadoriaFornecedores");

            migrationBuilder.DropTable(
                name: "Similares");

            migrationBuilder.DropTable(
                name: "Almoxarifados");

            migrationBuilder.DropTable(
                name: "Mercadorias");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "SubGrupoMercadorias");

            migrationBuilder.DropTable(
                name: "TabelaANPs");

            migrationBuilder.DropTable(
                name: "TabelaBeneficioSPEDs");

            migrationBuilder.DropTable(
                name: "TabelaCESTs");

            migrationBuilder.DropTable(
                name: "TabelaCFOPs");

            migrationBuilder.DropTable(
                name: "TabelaClasseEnquadramentoIPIs");

            migrationBuilder.DropTable(
                name: "TabelaCodigoEnquadramentoIPIs");

            migrationBuilder.DropTable(
                name: "TabelaCST_IPIs");

            migrationBuilder.DropTable(
                name: "TabelaCST_PIS_COFINSs");

            migrationBuilder.DropTable(
                name: "TabelaModalidadeDeterminacaoBCICMSs");

            migrationBuilder.DropTable(
                name: "TabelaMotivoDesoneracaoICMSs");

            migrationBuilder.DropTable(
                name: "TabelaNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropTable(
                name: "TabelaOrigemMercadoriaServicos");

            migrationBuilder.DropTable(
                name: "TabelaSituacaoTributariaNFCes");

            migrationBuilder.DropTable(
                name: "TabelaSpedCodigoGeneros");

            migrationBuilder.DropTable(
                name: "TabelaSpedInformacaoAdicionalItens");

            migrationBuilder.DropTable(
                name: "TabelaSpedTipoItems");

            migrationBuilder.DropTable(
                name: "TipoMercadorias");

            migrationBuilder.DropTable(
                name: "TipoServicoFiscais");

            migrationBuilder.DropTable(
                name: "UnidadeMedidas");

            migrationBuilder.DropTable(
                name: "VinculoFiscais");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "TipoClientes");

            migrationBuilder.DropTable(
                name: "GrupoMercadorias");

            migrationBuilder.DropTable(
                name: "TabelaNCMs");

            migrationBuilder.DropTable(
                name: "GrupoCFOPs");

            migrationBuilder.DropTable(
                name: "TabelaCST_CSOSNs");

            migrationBuilder.DropTable(
                name: "GrupoNaturezaReceita_CTS_PIS_COFINSs");

            migrationBuilder.DropTable(
                name: "TabelaCNAEs");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "GrupoNCM");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
