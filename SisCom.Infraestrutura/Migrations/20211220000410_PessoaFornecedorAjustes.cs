using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class PessoaFornecedorAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPessoas");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ_CPF",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CidadeId",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_Bairro",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_CEP",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "End_CidadeIdId",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_Logradouro",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End_Numero",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FAX",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoMunicipal",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePopular",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PontoReferencia",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Representante",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pessoas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoa",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    PaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305"), "Brasil" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId" },
                values: new object[,]
                {
                    { new Guid("9bbdbd9a-e91c-421e-852d-4d9f4603e1fd"), "AC", "Acre", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("99574c6f-e7fa-459a-bfde-988bedd00812"), "SP", "São Paulo", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("242114f9-cab5-4ce6-a143-f96be4b41245"), "SC", "Santa Catarina", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("d9109848-ba5c-4531-85de-2fc62f0c7b15"), "RR", "Roraima", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("c4dd0642-a901-4134-bd70-0ace37a219b4"), "RO", "Rondônia", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("9ea9fd16-ccea-4c2b-bce6-0d95d9e13a71"), "RS", "Rio Grande do Sul", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("ae8fbf07-8133-4657-8735-157042b03a55"), "RN", "Rio Grande do Norte", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("785038c0-792e-4969-8a34-65a8e7de8279"), "RJ", "Rio de Janeiro", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("a8fbe120-4c7b-43ac-a66e-fca8b5e24cdc"), "PI", "Piauí", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("ceace8ed-782a-454a-82cf-6b66a3e369ff"), "PE", "Pernambuco", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("bf2a8766-bea2-4d22-a7e9-43313d78af9a"), "PR", "Paraná", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("6ad2a569-efc8-4ea5-be4e-f1f3f58108a9"), "PB", "Paraíba", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("665c9aec-751a-48e3-8009-3ab178a23fa9"), "SE", "Sergipe", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("b7a63d5f-3a9a-4c94-8f76-c99276dc2677"), "PA", "Pará", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("c5b933e8-452d-4c59-8644-ed2805986787"), "MT", "Mato Grosso", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("704454b3-39d9-413a-a6aa-bf86f297dbbb"), "MS", "Mato Grosso do Sul", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("b51fc858-9c74-4ddf-959a-432ea3265012"), "MA", "Maranhão", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("90116c55-7bc9-4a9a-b6c9-bf0b09b71afa"), "GO", "Goias", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("e28cc545-1cec-497a-9b5d-432a3b913bb1"), "ES", "Espirito Santo", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("431fe6c3-238b-46df-a531-ebe5f6cdf964"), "DF", "Distrito Federal", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("51524f7e-7bdc-42ea-a0c3-85319a8c52e3"), "CE", "Ceará", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("f0a9a4e6-2998-4cd7-b934-c6111ccc05fb"), "BA", "Bahia", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("0e274933-e42a-4cb9-83cf-82326d96a67b"), "AM", "Amazonas", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("f31df9d0-43ef-4463-8827-6b6c9f2ed1cf"), "AP", "Amapá", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("17dd5000-4fdb-4b7e-b1fd-2a079837120f"), "AL", "Alagoas", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("323ed04c-9581-446b-a110-b2afdad13bac"), "MG", "Minas Gerais", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") },
                    { new Guid("8dbcb02e-9d46-418c-8c59-87de734a849d"), "EX", "Exterior", new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CidadeId",
                table: "Pessoas",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_End_CidadeIdId",
                table: "Pessoas",
                column: "End_CidadeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidade_CidadeId",
                table: "Pessoas",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidade_End_CidadeIdId",
                table: "Pessoas",
                column: "End_CidadeIdId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidade_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidade_End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CNPJ_CPF",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_Bairro",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_CEP",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_Logradouro",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "End_Numero",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "FAX",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "InscricaoMunicipal",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "NomePopular",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "PontoReferencia",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Representante",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "TipoPessoaId",
                table: "Pessoas");

            migrationBuilder.CreateTable(
                name: "TipoPessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoPessoas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("1608cdcc-9ca8-498f-ad54-c36113831170"), "Física" });

            migrationBuilder.InsertData(
                table: "TipoPessoas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("6422c371-32c9-4cac-b3f0-1be02103ef8e"), "Jurídica" });
        }
    }
}
