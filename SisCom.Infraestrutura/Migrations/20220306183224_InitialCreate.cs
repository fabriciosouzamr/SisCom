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
