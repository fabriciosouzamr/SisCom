using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class CadastroMercadorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estados_EstadoId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidade_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "SubGrupos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("00feb906-b703-4202-8671-bf18280c963e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("05595d97-b661-4424-b4c7-2e465ec6bbb6"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("071756f7-7fe7-41c8-937f-7abda52ab910"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("07fd2138-4fa1-4a44-8a88-f9fcabb1c337"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("2b069935-643d-4607-8f60-27da089b9468"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("36eb9ee0-c33c-4343-b577-d7c75ad615e2"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("36f24ccc-3d56-4add-802c-3b559d37ddee"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("3d4b9348-d1e0-49b3-b16f-8807edb33fb8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("639aac23-2cdd-436a-bdee-443f696016d7"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("64b55a6c-db7f-4f8b-865f-09b26236c450"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("6dc64fd1-d98c-4a4b-9f22-8cbafa558dda"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("724d77eb-bf18-4a93-be1a-11e0812281dd"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("774f0c5b-8775-498c-939f-14f296c9429e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("7983ad1f-e585-41f0-a312-c02dff92c222"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("947dd66a-9770-49cc-bfc0-45a26b31208a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9a17793f-20c3-4913-ac1f-debb6ed6a769"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a25fef73-89ce-4bb6-8871-1bcbbec8ef38"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a4e56dee-0c96-45dd-8d33-f18a9eff719d"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("b9b6b8aa-33e6-44d1-a743-f77ce0ddb110"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("c17cf59f-c344-43cb-87d1-269a5d462b77"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("cad20c4a-4e5f-444a-92ca-e8c4fad413dd"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ebb939cd-f25f-4b42-9b67-7787de0137c8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ed68fde0-b24f-40ae-877d-83f773582714"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ee5de09d-f8fd-4c4e-af24-b4271ecf87a8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f19dd3d4-e581-48ef-809b-0df22f69ca52"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f7007c11-7d1c-459c-92d6-f2465aa5701a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("fcdd9f7e-13db-4feb-9247-ba5dbcc0d6de"));

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2"));

            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "PontoReferencia",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "Cidades");

            migrationBuilder.RenameIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidades",
                newName: "IX_Cidades_EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pessoas",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoMunicipal",
                table: "Pessoas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAX",
                table: "Pessoas",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Numero",
                table: "Pessoas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Logradouro",
                table: "Pessoas",
                type: "varchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_CEP",
                table: "Pessoas",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Bairro",
                table: "Pessoas",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ_CPF",
                table: "Pessoas",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_PontoReferencia",
                table: "Pessoas",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Fabricante",
                table: "Pessoas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeContato",
                table: "Pessoas",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Estados",
                type: "char(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cidades",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoIBGE",
                table: "Cidades",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades",
                column: "Id");

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
                    { new Guid("c71222a1-5995-4639-a4dd-10e417e80757"), "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("024a5d61-71b1-4e6f-ad9c-22c615b28672"), "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59b25494-31dc-47b1-85c7-91596f21bf7c"), "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d539a6f2-1126-40d1-b5f2-061251360ea0"), "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74127c3d-c081-427e-9410-a88887adca4d"), "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("431c0276-b0c1-43e9-8aac-3913eff95dcf"), "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", 7, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[] { new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TabelaCST_IPIs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarIPI", "EntradaSaida", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("6d1e5803-ec26-4a88-a055-e69cf50854e3"), "99", "Outras Saídas", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b551a356-50e8-4afb-809a-28268da7ca49"), "55", "Saída com Suspensão", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e68f2eb0-d044-4c0a-81fa-82315b69700d"), "53", "Saída Não-Tributada", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f32b1200-9c3c-4743-8b35-cf6489511b79"), "52", "Saída Isenta", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("537ca43c-8ee4-4f52-bb17-672c7e792675"), "51", "Saída Tributável com Alíquota Zero", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ae0378e-c2d1-4017-b829-d8e8684e03cd"), "50", "Saída Tributada", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0128c87-9377-4ef8-b8fa-c2d8fe157add"), "54", "Saída Imune", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("920389f1-7931-4d88-828b-59c8b7b0f526"), "05", "Entrada com Suspensão", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("acf97aff-65d7-4101-9897-8ebde36a3fa6"), "04", "Entrada Imune", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c9225db-7bc5-445a-b0ae-88b1611ac9ca"), "03", "Entrada Não-Tributada", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a05caf24-efd0-424d-882f-14e984371c6e"), "02", "Entrada Isenta", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5f6aaad-a151-41a3-8ff1-7a4a593805f5"), "01", "Entrada Tributável com Alíquota Zero", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("826c0e7b-0c0b-4899-9610-4cf735a58707"), "00", "Entrada com Recuperação de Crédito", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("62ca2fc6-7a38-4991-a0bb-040697f5c544"), "49", "Outras Entradas", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("e764afc0-ba3a-4a51-baae-3e65eee40049"), "62", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("108123b9-5ee4-43fa-8813-5243f84dee9e"), "63", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("226441e0-8b26-4ace-82d6-1640ced3ecec"), "64", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("4c43efa5-1510-4300-9a66-31c732e08874"), "65", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("715eca90-359a-4c00-b1b0-70efc93c046f"), "66", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("2666d449-f3ec-4b2b-8785-7d8f9ca2e707"), "67", "Crédito Presumido -Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("edb571c9-8a8d-49aa-8244-3b22c5f28f3b"), "70", "Operação de Aquisição sem Direito a Crédito", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f429489a-3ed4-4dca-b970-311ce492c17f"), "73", "Operação de Aquisição a Alíquota Zero", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f602af8b-1010-4c76-83f8-a5e59bde4133"), "72", "Operação de Aquisição com Suspensão", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("e7e1f0b1-005c-4a7c-adbb-d95f91aee351"), "74", "Operação de Aquisição sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("a1aafeb6-1c1c-40e4-b2d8-d43d3a1067ac"), "75", "Operação de Aquisição por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("4adf26c9-6b53-4883-99d7-e0de2f15a82f"), "98", "Outras Operações de Entrada", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("c6dfa821-a09a-4501-aed3-b9359a1958fc"), "99", "Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { new Guid("d1a1d37c-d31a-4923-8206-2bc304a161f4"), "61", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f50c21d0-fe33-4fa2-be17-ac6b970a0577"), "71", "Operação de Aquisição com Isenção", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("12c7142f-7775-42fc-a9f7-658d170aaf3f"), "60", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("8577744b-c794-4b45-9c7c-3f09b6b6aa2a"), "55", "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("2bb9b5e9-6b9f-43ba-8678-72babf4b7fb7"), "03", "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9844509e-9df3-4b7f-b410-03e253758886"), "01", "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("70608042-f7a4-4ef2-a610-a6be73793ba7"), "02", "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("c36d3efb-c594-4b65-ab81-c2c19a49da1c"), "04", "Operação Tributável (tributação monofásica (alíquota zero))", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("76a63e9f-682d-43ce-b5a7-4a6d65d00196"), "05", "Operação Tributável por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("6f24530f-933f-4c5d-aaa6-319f94a37b0f"), "06", "Operação Tributável (alíquota zero)", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("bd0f0a25-7cc3-4899-94ff-5dbb5f08d7ce"), "07", "Operação Isenta da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("ffc82589-c781-4110-b551-73a64a6e993a"), "08", "Operação Sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("97f66672-de13-41cc-a888-b241bd565144"), "49", "Outras Operações de Saída", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("afc8766b-e119-4ae0-a7d4-73f7bbfa5db9"), "50", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f415962a-77c9-4b74-b9ab-7eb9ba525254"), "51", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("a9d4917b-91d4-45e5-8c9a-4985863e5467"), "52", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("f7dadbe5-fb15-4baa-b517-4dd2293a7b02"), "53", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("3efd8f83-51c1-41ab-ae8d-856675137db4"), "54", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("bdf84b24-b4b5-4d52-8286-18cdc1810d3f"), "09", "Operação com Suspensão da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("db37e539-d770-4052-a0c2-dab668727017"), "56", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false }
                });

            migrationBuilder.InsertData(
                table: "TabelaSituacaoTributariaNFCes",
                columns: new[] { "Id", "Codigo", "Descricao", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("606093b1-6829-41fa-b5a5-6d0b280ddc90"), "II", "Isento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac4050eb-39ca-4f2f-89f0-881cf983ec43"), "NN", "Não Incidente", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5f195e4-c22c-47c4-bee3-6e246b35c333"), "FF", "Substituição", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69b5005a-4daa-4bd0-8436-ea4a81f7aae9"), "01", "Normal(% TRIBUTADO)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TipoMercadorias",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("308fb9a9-da5d-450b-aae9-39e05a4568db"), "VEÍCULO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2908802-b160-406f-92e8-263c77d38b4f"), "COMBUSTÍVEL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99ca99a2-8cc0-49b0-b1e8-677954769275"), "MEDICAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cc18d07-67cc-4493-a086-6e548cfe7167"), "ARMAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UnidadeMedidas",
                columns: new[] { "Id", "Codigo", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("495b154f-7d61-4810-8d00-65b5bc7561f8"), "PCT", "Pacote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19fbc344-df61-483e-9d24-bf5b27a51620"), "FRC", "Frasco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59ace6e2-353c-4c9b-ba95-48db036a50cb"), "SCO", "Saco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21c4d228-59e2-4809-b1e2-72eaac11c3fd"), "LTR", "Litro ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70a412a6-6a94-4af0-8c02-f2cef9b7067a"), "GR", "Grama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4276b984-230e-479e-a94f-e0676acda5b8"), "MTR", "Metro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b41276fe-c11b-4a85-9597-a0ae0d7eff2d"), "PCA", "Peca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a263e1a5-8fe8-4a87-bccc-42a0f4450dce"), "CXA", "Caixa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e61d7d37-5256-4e82-9e9e-d9019c58d2a4"), "UND", "Unidade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7ec7811-fa37-4ec3-9d79-38bcfdb71c23"), "KG", "Kilograma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b37d296-c0ba-4c9e-9961-c350955b244c"), "FRD", "Fardo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("ad2c4330-6ed6-4bff-87b9-fb48f06b7355"), "AC", "Acre", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc3af8d3-f287-44d6-9188-f867608a3caf"), "SP", "São Paulo", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("506d2aa6-6caa-483a-b6df-a5e0e5157e33"), "SC", "Santa Catarina", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcb12e9b-9c99-4e9a-b7dc-4229547c4f36"), "RR", "Roraima", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae34808a-ae8c-4b3e-b66b-63688a2b5a8b"), "RO", "Rondônia", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1eff192d-655c-4c49-845e-195dce5f5469"), "RS", "Rio Grande do Sul", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8b49a76-0495-4c6f-8cd2-7821b2a359b6"), "RN", "Rio Grande do Norte", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92701b58-91b6-4fe8-b53e-9b20aee7190f"), "RJ", "Rio de Janeiro", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4bae038c-8360-4c72-becd-b67ac5ecfd29"), "PI", "Piauí", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91f27bd9-01ec-4017-a0cc-7d64573c7d3d"), "PE", "Pernambuco", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("258208d1-3bf0-4c89-954d-3bcbb3dd1744"), "PR", "Paraná", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3505aecd-b180-4b55-a52f-aaebca7e694c"), "PB", "Paraíba", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("55e5fb6c-ee9e-4575-afed-6b4e4cb67972"), "SE", "Sergipe", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10de653b-80a1-4fd8-ae27-41f24236d875"), "PA", "Pará", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("78c3d90e-0c0b-4133-aa9d-efdd383d1787"), "MT", "Mato Grosso", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fdd40f6-d339-4a42-8283-0bc16568df56"), "MS", "Mato Grosso do Sul", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3af3ef90-4be5-43b3-8fd2-3d79ad0236f1"), "MA", "Maranhão", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("adfc2af9-21f7-4c96-bc07-26dbf57a9b92"), "GO", "Goias", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50fb081a-939d-45e2-9ab9-b426e5c6592c"), "ES", "Espirito Santo", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4231c998-2425-4ff9-bed3-1b8f0cee38f8"), "DF", "Distrito Federal", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("960288b4-3d57-47da-aa26-5a3b3445652a"), "CE", "Ceará", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3e7ffc6-467f-404b-9bf0-ed8842f9f739"), "BA", "Bahia", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f46b8cd5-c6b1-462e-8ee5-a23a942970e9"), "AM", "Amazonas", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49ed77db-5cfb-4fd4-9c76-df8e1787c3f8"), "AP", "Amapá", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a63ada3a-6073-4aee-b609-a089522cfbf5"), "AL", "Alagoas", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("316299c0-f09f-4564-80e4-0a9b4fb3126e"), "MG", "Minas Gerais", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a49e7adb-9fc9-48f1-93b7-e7df032a8fc5"), "EX", "Exterior", new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidades_CidadeId",
                table: "Pessoas",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidades_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "MercadoriaFornecedores");

            migrationBuilder.DropTable(
                name: "Similares");

            migrationBuilder.DropTable(
                name: "Almoxarifados");

            migrationBuilder.DropTable(
                name: "Mercadorias");

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
                name: "GrupoNCM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("10de653b-80a1-4fd8-ae27-41f24236d875"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("1eff192d-655c-4c49-845e-195dce5f5469"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("258208d1-3bf0-4c89-954d-3bcbb3dd1744"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("316299c0-f09f-4564-80e4-0a9b4fb3126e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("3505aecd-b180-4b55-a52f-aaebca7e694c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("3af3ef90-4be5-43b3-8fd2-3d79ad0236f1"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("4231c998-2425-4ff9-bed3-1b8f0cee38f8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("49ed77db-5cfb-4fd4-9c76-df8e1787c3f8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("4bae038c-8360-4c72-becd-b67ac5ecfd29"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("506d2aa6-6caa-483a-b6df-a5e0e5157e33"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("50fb081a-939d-45e2-9ab9-b426e5c6592c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("55e5fb6c-ee9e-4575-afed-6b4e4cb67972"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("78c3d90e-0c0b-4133-aa9d-efdd383d1787"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("91f27bd9-01ec-4017-a0cc-7d64573c7d3d"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("92701b58-91b6-4fe8-b53e-9b20aee7190f"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("960288b4-3d57-47da-aa26-5a3b3445652a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9fdd40f6-d339-4a42-8283-0bc16568df56"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a49e7adb-9fc9-48f1-93b7-e7df032a8fc5"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a63ada3a-6073-4aee-b609-a089522cfbf5"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ad2c4330-6ed6-4bff-87b9-fb48f06b7355"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("adfc2af9-21f7-4c96-bc07-26dbf57a9b92"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ae34808a-ae8c-4b3e-b66b-63688a2b5a8b"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("b8b49a76-0495-4c6f-8cd2-7821b2a359b6"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("dc3af8d3-f287-44d6-9188-f867608a3caf"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("dcb12e9b-9c99-4e9a-b7dc-4229547c4f36"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f3e7ffc6-467f-404b-9bf0-ed8842f9f739"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f46b8cd5-c6b1-462e-8ee5-a23a942970e9"));

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: new Guid("6c4ba1ac-6225-492d-ad1d-7687cfa89e05"));

            migrationBuilder.DropColumn(
                name: "End_PontoReferencia",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "NomeContato",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CodigoIBGE",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Cidades");

            migrationBuilder.RenameTable(
                name: "Cidades",
                newName: "Cidade");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidade",
                newName: "IX_Cidade_EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoMunicipal",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAX",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Numero",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Logradouro",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_CEP",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Bairro",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ_CPF",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PontoReferencia",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Estados",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cidade",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    NaoVender = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGrupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGrupos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2"), "Brasil" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId" },
                values: new object[,]
                {
                    { new Guid("36eb9ee0-c33c-4343-b577-d7c75ad615e2"), "AC", "Acre", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("05595d97-b661-4424-b4c7-2e465ec6bbb6"), "SP", "São Paulo", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("a25fef73-89ce-4bb6-8871-1bcbbec8ef38"), "SC", "Santa Catarina", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("a4e56dee-0c96-45dd-8d33-f18a9eff719d"), "RR", "Roraima", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("36f24ccc-3d56-4add-802c-3b559d37ddee"), "RO", "Rondônia", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("ed68fde0-b24f-40ae-877d-83f773582714"), "RS", "Rio Grande do Sul", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("fcdd9f7e-13db-4feb-9247-ba5dbcc0d6de"), "RN", "Rio Grande do Norte", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("3d4b9348-d1e0-49b3-b16f-8807edb33fb8"), "RJ", "Rio de Janeiro", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("7983ad1f-e585-41f0-a312-c02dff92c222"), "PI", "Piauí", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("64b55a6c-db7f-4f8b-865f-09b26236c450"), "PE", "Pernambuco", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("947dd66a-9770-49cc-bfc0-45a26b31208a"), "PR", "Paraná", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("00feb906-b703-4202-8671-bf18280c963e"), "PB", "Paraíba", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("cad20c4a-4e5f-444a-92ca-e8c4fad413dd"), "SE", "Sergipe", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("774f0c5b-8775-498c-939f-14f296c9429e"), "PA", "Pará", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("f7007c11-7d1c-459c-92d6-f2465aa5701a"), "MT", "Mato Grosso", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("639aac23-2cdd-436a-bdee-443f696016d7"), "MS", "Mato Grosso do Sul", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("ee5de09d-f8fd-4c4e-af24-b4271ecf87a8"), "MA", "Maranhão", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("6dc64fd1-d98c-4a4b-9f22-8cbafa558dda"), "GO", "Goias", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("f19dd3d4-e581-48ef-809b-0df22f69ca52"), "ES", "Espirito Santo", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("724d77eb-bf18-4a93-be1a-11e0812281dd"), "DF", "Distrito Federal", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("b9b6b8aa-33e6-44d1-a743-f77ce0ddb110"), "CE", "Ceará", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("2b069935-643d-4607-8f60-27da089b9468"), "BA", "Bahia", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("071756f7-7fe7-41c8-937f-7abda52ab910"), "AM", "Amazonas", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("9a17793f-20c3-4913-ac1f-debb6ed6a769"), "AP", "Amapá", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("07fd2138-4fa1-4a44-8a88-f9fcabb1c337"), "AL", "Alagoas", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("ebb939cd-f25f-4b42-9b67-7787de0137c8"), "MG", "Minas Gerais", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") },
                    { new Guid("c17cf59f-c344-43cb-87d1-269a5d462b77"), "EX", "Exterior", new Guid("4acbeeac-2d40-4158-b0dd-159ba6cf55a2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupos_GrupoId",
                table: "SubGrupos",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estados_EstadoId",
                table: "Cidade",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidade_CidadeId",
                table: "Pessoas",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
