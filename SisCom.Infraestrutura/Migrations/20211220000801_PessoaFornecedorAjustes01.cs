using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class PessoaFornecedorAjustes01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidade_End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("0e274933-e42a-4cb9-83cf-82326d96a67b"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("17dd5000-4fdb-4b7e-b1fd-2a079837120f"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("242114f9-cab5-4ce6-a143-f96be4b41245"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("323ed04c-9581-446b-a110-b2afdad13bac"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("431fe6c3-238b-46df-a531-ebe5f6cdf964"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("51524f7e-7bdc-42ea-a0c3-85319a8c52e3"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("665c9aec-751a-48e3-8009-3ab178a23fa9"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("6ad2a569-efc8-4ea5-be4e-f1f3f58108a9"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("704454b3-39d9-413a-a6aa-bf86f297dbbb"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("785038c0-792e-4969-8a34-65a8e7de8279"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("8dbcb02e-9d46-418c-8c59-87de734a849d"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("90116c55-7bc9-4a9a-b6c9-bf0b09b71afa"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("99574c6f-e7fa-459a-bfde-988bedd00812"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9bbdbd9a-e91c-421e-852d-4d9f4603e1fd"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9ea9fd16-ccea-4c2b-bce6-0d95d9e13a71"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a8fbe120-4c7b-43ac-a66e-fca8b5e24cdc"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ae8fbf07-8133-4657-8735-157042b03a55"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("b51fc858-9c74-4ddf-959a-432ea3265012"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("b7a63d5f-3a9a-4c94-8f76-c99276dc2677"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("bf2a8766-bea2-4d22-a7e9-43313d78af9a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("c4dd0642-a901-4134-bd70-0ace37a219b4"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("c5b933e8-452d-4c59-8644-ed2805986787"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ceace8ed-782a-454a-82cf-6b66a3e369ff"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("d9109848-ba5c-4531-85de-2fc62f0c7b15"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e28cc545-1cec-497a-9b5d-432a3b913bb1"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f0a9a4e6-2998-4cd7-b934-c6111ccc05fb"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f31df9d0-43ef-4463-8827-6b6c9f2ed1cf"));

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: new Guid("929b630e-20c4-4de2-b94b-a3ae00eb3305"));

            migrationBuilder.DropColumn(
                name: "End_CidadeIdId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "TipoPessoaId",
                table: "Pessoas");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "End_CidadeIdId",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Pessoas_End_CidadeIdId",
                table: "Pessoas",
                column: "End_CidadeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidade_End_CidadeIdId",
                table: "Pessoas",
                column: "End_CidadeIdId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
