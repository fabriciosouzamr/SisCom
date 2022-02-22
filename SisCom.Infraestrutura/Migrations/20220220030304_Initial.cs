using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class Initial : Migration
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
                name: "GrupoNaturezaReceita_CTS_PIS_COFINS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNaturezaReceita_CTS_PIS_COFINS", x => x.Id);
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
                name: "TabelaNaturezaReceita_CTS_PIS_COFINS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    GrupoNaturezaReceita_CTS_PIS_COFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaNaturezaReceita_CTS_PIS_COFINS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaNaturezaReceita_CTS_PIS_COFINS_GrupoNaturezaReceita_CTS_PIS_COFINS_GrupoNaturezaReceita_CTS_PIS_COFINSId",
                        column: x => x.GrupoNaturezaReceita_CTS_PIS_COFINSId,
                        principalTable: "GrupoNaturezaReceita_CTS_PIS_COFINS",
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
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(100)", nullable: true),
                    Unidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Fantasia = table.Column<string>(type: "varchar(100)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(100)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(100)", nullable: true),
                    InscricaoEstadual_SubTributaria = table.Column<string>(type: "varchar(100)", nullable: true),
                    End_CEP = table.Column<string>(type: "varchar(100)", nullable: true),
                    End_Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    End_Numero = table.Column<string>(type: "varchar(100)", nullable: true),
                    End_Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: true),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: true),
                    RegimeTributario = table.Column<int>(type: "int", nullable: false),
                    CreditoSimplesNacional = table.Column<double>(type: "float", nullable: false),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Cidades_End_CidadeId",
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
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomePopular = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(15)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(15)", nullable: true),
                    End_CEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    End_Logradouro = table.Column<string>(type: "varchar(60)", nullable: true),
                    End_Numero = table.Column<string>(type: "varchar(10)", nullable: true),
                    End_Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    End_PontoReferencia = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    FAX = table.Column<string>(type: "varchar(20)", nullable: true),
                    NomeContato = table.Column<string>(type: "varchar(50)", nullable: true),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: true),
                    Site = table.Column<string>(type: "varchar(100)", nullable: true),
                    Representante = table.Column<string>(type: "varchar(100)", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(100)", nullable: true),
                    Fornecedor = table.Column<bool>(type: "bit", nullable: false),
                    Fabricante = table.Column<bool>(type: "bit", nullable: false),
                    End_CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    CodigoFabricante = table.Column<string>(type: "varchar(50)", nullable: true),
                    CodigoBarra = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Observacao = table.Column<int>(type: "int", nullable: false),
                    NaoVender = table.Column<bool>(type: "bit", nullable: false),
                    NaoControlarEstoque = table.Column<bool>(type: "bit", nullable: false),
                    Ativado = table.Column<bool>(type: "bit", nullable: false),
                    Preco_PrecoCompra = table.Column<decimal>(type: "money", nullable: false),
                    Preco_ICMS_Compra = table.Column<decimal>(type: "money", nullable: false),
                    Preco_ICMS_Fronteira = table.Column<decimal>(type: "money", nullable: false),
                    Preco_IPI = table.Column<decimal>(type: "money", nullable: false),
                    Preco_Frete = table.Column<decimal>(type: "money", nullable: false),
                    Preco_Embalagem = table.Column<decimal>(type: "money", nullable: false),
                    Preco_EncFinanceiro = table.Column<decimal>(type: "money", nullable: false),
                    Preco_CustoMercadoria = table.Column<decimal>(type: "money", nullable: false),
                    Preco_CustoFixo = table.Column<decimal>(type: "money", nullable: false),
                    Preco_ImpostoFederais = table.Column<decimal>(type: "money", nullable: false),
                    Preco_ICMS_Venda = table.Column<decimal>(type: "money", nullable: false),
                    Preco_Comissao = table.Column<decimal>(type: "money", nullable: false),
                    Preco_Marketing = table.Column<decimal>(type: "money", nullable: false),
                    Preco_OutrosCustos = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PontoEquilibrio = table.Column<decimal>(type: "money", nullable: false),
                    Preco_MargemSugerido = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PrecoSugerido = table.Column<decimal>(type: "money", nullable: false),
                    Preco_MargemVenda = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PrecoVenda = table.Column<decimal>(type: "money", nullable: false),
                    Preco_MargemA = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PrecoA = table.Column<decimal>(type: "money", nullable: false),
                    Preco_MargemB = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PrecoB = table.Column<decimal>(type: "money", nullable: false),
                    Preco_MargemC = table.Column<decimal>(type: "money", nullable: false),
                    Preco_PrecoC = table.Column<decimal>(type: "money", nullable: false),
                    Preco_CalculoPreco = table.Column<decimal>(type: "money", nullable: false),
                    Preco_CalculoPrecificacao = table.Column<decimal>(type: "money", nullable: false),
                    Estoque_Quantidade = table.Column<double>(type: "float", nullable: false),
                    Estoque_QuantidadeMinimo = table.Column<double>(type: "float", nullable: false),
                    Estoque_Pratileira = table.Column<string>(type: "varchar(20)", nullable: true),
                    Estoque_PesoBruto = table.Column<double>(type: "float", nullable: false),
                    Estoque_PesoLiquido = table.Column<double>(type: "float", nullable: false),
                    Estoque_UltimaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estoque_AlteracaoPreco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estoque_TributacaoNFCe_AliquotaICMS = table.Column<double>(type: "float", nullable: false),
                    Estoque_TributacaoNFCe_TipoServicoMunicipal = table.Column<string>(type: "varchar(10)", nullable: true),
                    Fiscal_InformacaoAdicional = table.Column<string>(type: "varchar(200)", nullable: true),
                    Fiscal_CodigoAnvisa = table.Column<string>(type: "varchar(13)", nullable: true),
                    Fiscal_NFE_IPI_Aliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFE_PIS_Aliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFE_COFINS_Aliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMS_ValorAdicional = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMS_Deferimento = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMS_ReducaoBase = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMSST_ValorAdicional = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMSST_Aliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ICMSST_ReducaoBase = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_IPI_ValorAliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_PISCOFINS_PIS_ValorAliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota = table.Column<double>(type: "float", nullable: false),
                    Fiscal_OutrosPMC = table.Column<double>(type: "float", nullable: false),
                    Fiscal_OutrosNVE = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_TributosFederais = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_TributosMunicipais = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_TributosEstaduais = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_TributosTotal = table.Column<double>(type: "float", nullable: false),
                    Fiscal_NFS_ValorTributosTotal = table.Column<double>(type: "float", nullable: false),
                    Producao_Configuracao_ValidadeDias = table.Column<int>(type: "int", nullable: false),
                    Producao_Configuracao_NaoBaixarComposicaoVenda = table.Column<bool>(type: "bit", nullable: false),
                    FotoEspecificacao_Especificacao = table.Column<string>(type: "text", nullable: true),
                    FotoEspecificacao_URL = table.Column<string>(type: "varchar(200)", nullable: true),
                    FotoEspecificacao_UsarFoto = table.Column<bool>(type: "bit", nullable: false),
                    FotoEspecificacao_Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FotoEspecificacao_Imagem_ContentType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    GrupoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubGrupoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estoque_UnidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estoque_TributacaoNFCe_TabelaCFOPId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estoque_TributacaoNFCe_TipoServicoFiscalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_VinculoFiscalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TipoMercadoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaANPId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaNCMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaCESTId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaOrigemMercadoriaServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaCST_CSOSNId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_TabelaBeneficioSPEDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFE_TabelaCST_IPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFE_TabelaCST_COFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFE_TabelaCST_PISId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_IPI_TabelaCST_IPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_SPED_TabelaSpedTipoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_SPED_TabelaSpedCodigoGeneroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Mercadorias_GrupoNaturezaReceita_CTS_PIS_COFINS_Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId",
                        column: x => x.Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId,
                        principalTable: "GrupoNaturezaReceita_CTS_PIS_COFINS",
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
                        name: "FK_Mercadorias_TabelaNaturezaReceita_CTS_PIS_COFINS_Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId",
                        column: x => x.Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId,
                        principalTable: "TabelaNaturezaReceita_CTS_PIS_COFINS",
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
                        name: "FK_Mercadorias_UnidadeMedidas_Estoque_UnidadeId",
                        column: x => x.Estoque_UnidadeId,
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
                    QuantidadeEmEstoque = table.Column<double>(type: "float", nullable: false),
                    QuantidadeBloqueada = table.Column<double>(type: "float", nullable: false),
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
                table: "GrupoCFOPs",
                columns: new[] { "Id", "Nome", "TipoOperacaoCFOP", "TipoOperacaoCFOPId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("0de6a26d-9a59-467a-9c27-b7db81c945ac"), "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("07cee876-958f-4a8c-9684-502b744be7c3"), "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e6c19b9-7923-4f24-9811-75618c83f948"), "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5daec5d5-b2c5-40d1-8442-283635275127"), "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ff91efd-ad59-4b83-8839-a60b52874c6d"), "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4541095-4f2a-461a-9026-5f46c424543a"), "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", 7, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[] { new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TabelaCST_IPIs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarIPI", "EntradaSaida", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("40415dc6-fc8a-4086-b2e4-7bdea3c8a009"), "99", "Outras Saídas", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42ee4722-7530-476c-a46e-63c30690f206"), "55", "Saída com Suspensão", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63098179-2698-449d-ad86-644ab774c25f"), "53", "Saída Não-Tributada", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c2f8ed5-35bb-4c89-a506-8eaec3ba2747"), "52", "Saída Isenta", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a86e7397-78ef-4f41-b820-52669f4ad5b5"), "51", "Saída Tributável com Alíquota Zero", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5bd2d47f-efd0-4d47-94de-8168f353244f"), "50", "Saída Tributada", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("792749f7-f4c2-4469-8fca-e683b23762b3"), "54", "Saída Imune", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("569cf118-2db1-4b6b-b511-b02045ce70b3"), "05", "Entrada com Suspensão", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4e8249f-7bce-4714-b47b-1f31025e1519"), "04", "Entrada Imune", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("324974ee-3b60-4291-8cf9-acfd2031f3e4"), "03", "Entrada Não-Tributada", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac57d9f1-0a7f-49dc-9b11-bf2b4f1804aa"), "02", "Entrada Isenta", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f341c13-d097-4945-93a2-fe6fd1ea1e10"), "01", "Entrada Tributável com Alíquota Zero", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ccc9ba58-71e8-4c6c-9e2c-1d3f7635acd7"), "00", "Entrada com Recuperação de Crédito", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce80e81b-bd45-425b-92ee-febbd2a77cfe"), "49", "Outras Entradas", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("705dbc1b-b5e9-4b2c-9c45-91de1206a374"), "62", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("776251d4-7cb0-498e-8857-c959f4149250"), "63", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("6c923d3f-530b-4b5e-ade0-b126655e7676"), "64", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("507eff37-1716-40e2-972b-b4eb91ba7501"), "65", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("23f35065-427c-48ab-8fda-e1f5630fcc6a"), "66", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("fa54ff8f-41e1-442f-8ffc-1b39e96d1bf1"), "67", "Crédito Presumido -Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("b6ca1ffd-3828-4600-ac4e-7b6937e780f5"), "70", "Operação de Aquisição sem Direito a Crédito", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("74fd2260-bed8-4b20-b04f-ac90829a477e"), "73", "Operação de Aquisição a Alíquota Zero", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("e81a5b41-2de4-45ad-b87b-b0829fa6c39c"), "72", "Operação de Aquisição com Suspensão", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f3beb9bf-b22f-4b6c-95a6-9c69f8b0e5d5"), "74", "Operação de Aquisição sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("ff1265f4-ff7c-48ad-b0c6-fd3539334e44"), "75", "Operação de Aquisição por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("229f906c-5ffa-4eea-8bfa-a741d76bd70f"), "98", "Outras Operações de Entrada", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("c41b71c1-8e89-411b-822d-45735559d3b0"), "99", "Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { new Guid("8b54ff12-5408-4680-9013-be9d441902c8"), "61", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("e3754207-8cba-4fcd-94a5-b8b8b4c830e0"), "71", "Operação de Aquisição com Isenção", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("8c00ed24-1725-445d-b540-a5b3d4b57a4c"), "60", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("d6914fc7-fb4c-435e-8d6d-9ade0d1d405c"), "55", "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("96acc05a-2980-493f-8685-2fcd26e57d59"), "03", "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("2ea1852d-27c2-4933-a034-3988b0cecdd7"), "01", "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("ac0a42aa-a656-4728-98bd-2cf8e5b4eaa3"), "02", "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("660a257a-aa88-457b-b5f3-bb1f3be60788"), "04", "Operação Tributável (tributação monofásica (alíquota zero))", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("544522bc-9f21-4cbb-bfb0-5abaea02fe6a"), "05", "Operação Tributável por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("b672f78f-85b9-4465-9e5d-f72ab5fd4b0e"), "06", "Operação Tributável (alíquota zero)", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9f2c55b4-a77f-4f01-b91e-275ae9866b9c"), "07", "Operação Isenta da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("0d495099-4cfc-4059-ab9c-154c1be1dc2a"), "08", "Operação Sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9e59c173-2c1d-41fc-b18b-ca737123f241"), "49", "Outras Operações de Saída", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9ef75fe4-b266-47aa-ae6c-0ec2c45b4d6e"), "50", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("159162bf-8e25-4b6b-a29b-8e6c874f626c"), "51", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("e0a17a88-f581-4723-8270-2b5956596f12"), "52", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("6895ef66-e5ed-438e-b46e-d26a419f33fb"), "53", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("14557572-6a0b-45ef-bd9f-1e6d7f7d5d4f"), "54", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("8c25bef5-5176-4aed-bf98-68585a0993f7"), "09", "Operação com Suspensão da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9f6abdab-cf02-4b7c-b1fc-516541ea7f6a"), "56", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false }
                });

            migrationBuilder.InsertData(
                table: "TabelaSituacaoTributariaNFCes",
                columns: new[] { "Id", "Codigo", "Descricao", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("fe8e7c01-c452-4bac-8bb9-8cb75eeb8a68"), "II", "Isento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d3cd64c-6def-47dd-98fb-dfc8e208cb61"), "NN", "Não Incidente", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("58e78195-9986-4654-8562-297304f855cc"), "FF", "Substituição", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d10d007-021b-4922-a7c7-a12a97c5df4e"), "01", "Normal(% TRIBUTADO)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TipoMercadorias",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("bd303578-6f49-4b0c-91a6-3e3d227ac169"), "VEÍCULO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("443b2943-864a-4439-86cc-4276d35bb219"), "COMBUSTÍVEL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a9c92d8-58c4-49e1-98b0-f88434db4de7"), "MEDICAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f35a334-c6fb-4bad-ac53-4a55b5bcd0ca"), "ARMAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UnidadeMedidas",
                columns: new[] { "Id", "Codigo", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("a2cfc38a-e907-4a72-a451-58e7372803bd"), "PCT", "Pacote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70e3dbdb-c043-4364-b918-213157d71eae"), "FRC", "Frasco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b2dd826-349e-4bc4-9444-25433ccf70ec"), "SCO", "Saco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9feff60-2792-48d7-b230-90263938be8b"), "LTR", "Litro ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8a2f76b-3087-4ab3-9434-b0e592d94fad"), "GR", "Grama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15653c42-9a61-4ffa-b48c-667260dac2b7"), "MTR", "Metro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec751484-adfb-4023-a36b-14c494316e91"), "PCA", "Peca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a27349ec-90ee-4677-8cc7-0598239d2f1b"), "CXA", "Caixa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ba08f57-3a0d-4690-90f0-3e8a528d9c5b"), "UND", "Unidade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36a5a774-4384-40ca-b02a-b188f66e332a"), "KG", "Kilograma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d073bc62-9f0d-47ca-99c2-059b2589384e"), "FRD", "Fardo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("70e75ee9-ce97-4bf3-9021-c43096c64436"), "AC", "Acre", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("38bd1f65-8b53-4f09-81c2-bbc282dce6fe"), "SP", "São Paulo", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3701391-baf6-435f-bb01-c20b9eb2dd30"), "SC", "Santa Catarina", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("534e3d86-732c-45f6-8bee-3fef9e7f49bf"), "RR", "Roraima", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29e42ae8-fb30-45d6-8cbb-12a8ad543721"), "RO", "Rondônia", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("746e2afd-dfb4-4190-92cb-20cd707e2d5c"), "RS", "Rio Grande do Sul", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33366d29-681a-4320-8f9a-a44e4500f26c"), "RN", "Rio Grande do Norte", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f0aac6ec-5827-4d71-887b-5430cc92d968"), "RJ", "Rio de Janeiro", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("442efb14-0819-44a0-b083-ffe3cc703ed3"), "PI", "Piauí", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("762eac4a-2684-4ac4-a293-92112c74ca61"), "PE", "Pernambuco", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45d625f6-de25-460b-9f06-08fe819d3786"), "PR", "Paraná", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("553b8968-67b5-4838-ab5b-0b3d0feffac6"), "PB", "Paraíba", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f59a585-72a9-4a80-83af-a35c6998465a"), "SE", "Sergipe", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c69f5acb-47c4-4487-a506-c2b9f2995f33"), "PA", "Pará", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55080afa-2bcc-42a9-821c-c32b06f6f3dd"), "MT", "Mato Grosso", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55b6e6a8-80a5-44c5-992e-e21c3e782843"), "MS", "Mato Grosso do Sul", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a5e710b-f938-4015-8cb5-701d96ddf962"), "MA", "Maranhão", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ebc7b66-46d4-482e-93df-f62046b60141"), "GO", "Goias", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad415ae7-aed0-4fbe-8ad6-9f4cbcb87096"), "ES", "Espirito Santo", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c89c1019-7983-4b2d-aad2-ae2cdb69b8df"), "DF", "Distrito Federal", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82cf67cb-9edc-4807-9d45-5badbcc2d10d"), "CE", "Ceará", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a9d2fb-d0f6-4ad8-937f-f743ca0aa4b4"), "BA", "Bahia", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcbd2a45-a35d-4d2f-b74b-52e9aaefe6f8"), "AM", "Amazonas", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a937cea9-8e9d-4cb7-a7d0-7d35e38e0701"), "AP", "Amapá", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7a2e37e-cf0d-4093-acd2-7c8ffca55726"), "AL", "Alagoas", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("711d6dc1-f2c9-4917-840d-f4cdc0598c86"), "MG", "Minas Gerais", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d0572b9-ab00-42a0-bdd1-1c77957c79c5"), "EX", "Exterior", new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_End_CidadeId",
                table: "Empresa",
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
                name: "IX_Mercadorias_Estoque_UnidadeId",
                table: "Mercadorias",
                column: "Estoque_UnidadeId");

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
                name: "IX_TabelaNaturezaReceita_CTS_PIS_COFINS_GrupoNaturezaReceita_CTS_PIS_COFINSId",
                table: "TabelaNaturezaReceita_CTS_PIS_COFINS",
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
                name: "Empresa");

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
                name: "TabelaNaturezaReceita_CTS_PIS_COFINS");

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
                name: "GrupoMercadorias");

            migrationBuilder.DropTable(
                name: "TabelaNCMs");

            migrationBuilder.DropTable(
                name: "GrupoCFOPs");

            migrationBuilder.DropTable(
                name: "TabelaCST_CSOSNs");

            migrationBuilder.DropTable(
                name: "GrupoNaturezaReceita_CTS_PIS_COFINS");

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
