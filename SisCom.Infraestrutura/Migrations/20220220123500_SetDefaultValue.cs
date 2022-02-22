using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class SetDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Cidades_End_CidadeId",
                table: "Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("1a5e710b-f938-4015-8cb5-701d96ddf962"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("29e42ae8-fb30-45d6-8cbb-12a8ad543721"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("2f59a585-72a9-4a80-83af-a35c6998465a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("33366d29-681a-4320-8f9a-a44e4500f26c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("38bd1f65-8b53-4f09-81c2-bbc282dce6fe"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("442efb14-0819-44a0-b083-ffe3cc703ed3"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("45d625f6-de25-460b-9f06-08fe819d3786"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("534e3d86-732c-45f6-8bee-3fef9e7f49bf"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("55080afa-2bcc-42a9-821c-c32b06f6f3dd"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("553b8968-67b5-4838-ab5b-0b3d0feffac6"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("55b6e6a8-80a5-44c5-992e-e21c3e782843"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("6d0572b9-ab00-42a0-bdd1-1c77957c79c5"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("6ebc7b66-46d4-482e-93df-f62046b60141"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("70e75ee9-ce97-4bf3-9021-c43096c64436"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("711d6dc1-f2c9-4917-840d-f4cdc0598c86"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("746e2afd-dfb4-4190-92cb-20cd707e2d5c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("762eac4a-2684-4ac4-a293-92112c74ca61"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("82cf67cb-9edc-4807-9d45-5badbcc2d10d"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("a937cea9-8e9d-4cb7-a7d0-7d35e38e0701"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ad415ae7-aed0-4fbe-8ad6-9f4cbcb87096"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("c69f5acb-47c4-4487-a506-c2b9f2995f33"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("c89c1019-7983-4b2d-aad2-ae2cdb69b8df"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("dcbd2a45-a35d-4d2f-b74b-52e9aaefe6f8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e1a9d2fb-d0f6-4ad8-937f-f743ca0aa4b4"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e3701391-baf6-435f-bb01-c20b9eb2dd30"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f0aac6ec-5827-4d71-887b-5430cc92d968"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f7a2e37e-cf0d-4093-acd2-7c8ffca55726"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("07cee876-958f-4a8c-9684-502b744be7c3"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("0de6a26d-9a59-467a-9c27-b7db81c945ac"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("4e6c19b9-7923-4f24-9811-75618c83f948"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("5daec5d5-b2c5-40d1-8442-283635275127"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("8ff91efd-ad59-4b83-8839-a60b52874c6d"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("a4541095-4f2a-461a-9026-5f46c424543a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("324974ee-3b60-4291-8cf9-acfd2031f3e4"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("40415dc6-fc8a-4086-b2e4-7bdea3c8a009"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("42ee4722-7530-476c-a46e-63c30690f206"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("569cf118-2db1-4b6b-b511-b02045ce70b3"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("5bd2d47f-efd0-4d47-94de-8168f353244f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("5c2f8ed5-35bb-4c89-a506-8eaec3ba2747"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("5f341c13-d097-4945-93a2-fe6fd1ea1e10"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("63098179-2698-449d-ad86-644ab774c25f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("792749f7-f4c2-4469-8fca-e683b23762b3"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("a86e7397-78ef-4f41-b820-52669f4ad5b5"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("ac57d9f1-0a7f-49dc-9b11-bf2b4f1804aa"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("ccc9ba58-71e8-4c6c-9e2c-1d3f7635acd7"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("ce80e81b-bd45-425b-92ee-febbd2a77cfe"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("d4e8249f-7bce-4714-b47b-1f31025e1519"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("0d495099-4cfc-4059-ab9c-154c1be1dc2a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("14557572-6a0b-45ef-bd9f-1e6d7f7d5d4f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("159162bf-8e25-4b6b-a29b-8e6c874f626c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("229f906c-5ffa-4eea-8bfa-a741d76bd70f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("23f35065-427c-48ab-8fda-e1f5630fcc6a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("2ea1852d-27c2-4933-a034-3988b0cecdd7"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("507eff37-1716-40e2-972b-b4eb91ba7501"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("544522bc-9f21-4cbb-bfb0-5abaea02fe6a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("660a257a-aa88-457b-b5f3-bb1f3be60788"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("6895ef66-e5ed-438e-b46e-d26a419f33fb"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("6c923d3f-530b-4b5e-ade0-b126655e7676"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("705dbc1b-b5e9-4b2c-9c45-91de1206a374"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("74fd2260-bed8-4b20-b04f-ac90829a477e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("776251d4-7cb0-498e-8857-c959f4149250"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("8b54ff12-5408-4680-9013-be9d441902c8"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("8c00ed24-1725-445d-b540-a5b3d4b57a4c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("8c25bef5-5176-4aed-bf98-68585a0993f7"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("96acc05a-2980-493f-8685-2fcd26e57d59"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9e59c173-2c1d-41fc-b18b-ca737123f241"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9ef75fe4-b266-47aa-ae6c-0ec2c45b4d6e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9f2c55b4-a77f-4f01-b91e-275ae9866b9c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9f6abdab-cf02-4b7c-b1fc-516541ea7f6a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("ac0a42aa-a656-4728-98bd-2cf8e5b4eaa3"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("b672f78f-85b9-4465-9e5d-f72ab5fd4b0e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("b6ca1ffd-3828-4600-ac4e-7b6937e780f5"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("c41b71c1-8e89-411b-822d-45735559d3b0"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("d6914fc7-fb4c-435e-8d6d-9ade0d1d405c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("e0a17a88-f581-4723-8270-2b5956596f12"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("e3754207-8cba-4fcd-94a5-b8b8b4c830e0"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("e81a5b41-2de4-45ad-b87b-b0829fa6c39c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("f3beb9bf-b22f-4b6c-95a6-9c69f8b0e5d5"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("fa54ff8f-41e1-442f-8ffc-1b39e96d1bf1"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("ff1265f4-ff7c-48ad-b0c6-fd3539334e44"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("2d10d007-021b-4922-a7c7-a12a97c5df4e"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("58e78195-9986-4654-8562-297304f855cc"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("9d3cd64c-6def-47dd-98fb-dfc8e208cb61"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("fe8e7c01-c452-4bac-8bb9-8cb75eeb8a68"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("0f35a334-c6fb-4bad-ac53-4a55b5bcd0ca"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("443b2943-864a-4439-86cc-4276d35bb219"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("9a9c92d8-58c4-49e1-98b0-f88434db4de7"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("bd303578-6f49-4b0c-91a6-3e3d227ac169"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("15653c42-9a61-4ffa-b48c-667260dac2b7"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2b2dd826-349e-4bc4-9444-25433ccf70ec"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2ba08f57-3a0d-4690-90f0-3e8a528d9c5b"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("36a5a774-4384-40ca-b02a-b188f66e332a"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("70e3dbdb-c043-4364-b918-213157d71eae"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("a27349ec-90ee-4677-8cc7-0598239d2f1b"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("a2cfc38a-e907-4a72-a451-58e7372803bd"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("c8a2f76b-3087-4ab3-9434-b0e592d94fad"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("d073bc62-9f0d-47ca-99c2-059b2589384e"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("e9feff60-2792-48d7-b230-90263938be8b"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("ec751484-adfb-4023-a36b-14c494316e91"));

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: new Guid("a4a4fea2-a390-4c25-9e59-cbbc28e9008c"));

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "Empresas");

            migrationBuilder.RenameIndex(
                name: "IX_Empresa_End_CidadeId",
                table: "Empresas",
                newName: "IX_Empresas_End_CidadeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoVenda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoSugerido",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoCompra",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoC",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoB",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoA",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PontoEquilibrio",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_OutrosCustos",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Marketing",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemVenda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemSugerido",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemC",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemB",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemA",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ImpostoFederais",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_IPI",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Venda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Fronteira",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Compra",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Frete",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_EncFinanceiro",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Embalagem",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CustoMercadoria",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CustoFixo",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Comissao",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CalculoPreco",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CalculoPrecificacao",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_OutrosPMC",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_OutrosNVE",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ValorTributosTotal",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosTotal",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosMunicipais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosFederais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosEstaduais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_PISCOFINS_PIS_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_IPI_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_ValorAdicional",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_ReducaoBase",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_Deferimento",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_ValorAdicional",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_ReducaoBase",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_PIS_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_IPI_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_COFINS_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_TributacaoNFCe_AliquotaICMS",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_QuantidadeMinimo",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_Quantidade",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_PesoLiquido",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_PesoBruto",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "QuantidadeEmEstoque",
                table: "Estoques",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "QuantidadeBloqueada",
                table: "Estoques",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Unidade",
                table: "Empresas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Empresas",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoMunicipal",
                table: "Empresas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual_SubTributaria",
                table: "Empresas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Numero",
                table: "Empresas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Logradouro",
                table: "Empresas",
                type: "varchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_CEP",
                table: "Empresas",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Bairro",
                table: "Empresas",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CreditoSimplesNacional",
                table: "Empresas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Empresas",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "GrupoCFOPs",
                columns: new[] { "Id", "Nome", "TipoOperacaoCFOP", "TipoOperacaoCFOPId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("29088a5e-44dd-47cd-903f-1be74dc27e98"), "1.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO ESTADO", 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("48283b6d-4630-4918-a2db-8661e24757e4"), "2.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DE OUTROS ESTADOS", 2, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a95d2d30-6f3a-49a3-af8e-a68347e79057"), "3.000 - ENTRADAS OU AQUISIÇÕES DE SERVIÇOS DO EXTERIOR", 3, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f2ddede-b9de-43f1-afd7-047743058bc9"), "5.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O ESTADO", 5, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eace3cfc-9844-42b2-aef0-9bc0a4a4fc3e"), "6.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA OUTROS ESTADOS", 6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09600943-ca75-4ac9-b9df-11d7804828ff"), "7.000 - SAÍDAS OU PRESTAÇÕES DE SERVIÇOS PARA O EXTERIOR", 7, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[] { new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TabelaCST_IPIs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarIPI", "EntradaSaida", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("e7b56194-81c8-465d-bde3-9ef4ad16e9f6"), "99", "Outras Saídas", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a27a29aa-f9d8-4113-849b-05b6d3b8a185"), "55", "Saída com Suspensão", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("563077dd-5009-4d93-950a-a3e159e20b31"), "53", "Saída Não-Tributada", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e7d10d6-4f7b-414e-8f90-00c7daf0b9d8"), "52", "Saída Isenta", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("689fc616-e300-4e37-b96e-0939d9b53b84"), "51", "Saída Tributável com Alíquota Zero", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd072319-87e9-4ad0-adc4-0a6f699d2f3c"), "50", "Saída Tributada", true, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6da9f8e2-21b9-4583-8819-908880649c6c"), "54", "Saída Imune", false, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c4cc729-2060-4145-9076-013f11a13839"), "05", "Entrada com Suspensão", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d30a07ec-712f-48f4-9fbd-41ff4c0edc3f"), "04", "Entrada Imune", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("602b93c7-cb76-427f-8d43-fa95734f5825"), "03", "Entrada Não-Tributada", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5a83bdc-28e9-42da-8ff8-a23745aa4fc8"), "02", "Entrada Isenta", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("beeb5abc-570b-4059-8c69-924d210bcb8a"), "01", "Entrada Tributável com Alíquota Zero", false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8b02720-3ab5-4cf4-91ef-100d5564f0e3"), "00", "Entrada com Recuperação de Crédito", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb1f9af0-5732-4d99-b150-4303cd6d279e"), "49", "Outras Entradas", true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("bf6970b9-52d7-4c53-a024-c0c5fafd2caa"), "62", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("c882c2af-a565-42df-8b96-fca693a877d2"), "63", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("94461050-8a45-472b-af8d-78999391b57a"), "64", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("e478d8bf-294a-4c34-a375-7d9bdbaedfbd"), "65", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("33b1bcbc-4223-433a-9c49-e8e3ded1acdb"), "66", "Crédito Presumido -Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("74d70ee3-6ea6-4a28-aec7-d687f211aad5"), "67", "Crédito Presumido -Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("da82e943-d00d-437e-8091-604f07cf1e7f"), "70", "Operação de Aquisição sem Direito a Crédito", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("d8c0faa3-c2e9-4276-9c0d-96e4935fbf37"), "73", "Operação de Aquisição a Alíquota Zero", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("ba190994-8e03-4a54-a3a2-b52015f57916"), "72", "Operação de Aquisição com Suspensão", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("067a178f-c4ac-4b97-a295-e649cee16504"), "74", "Operação de Aquisição sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("fe29b6e2-5f43-471c-8ff1-d35386cb24fc"), "75", "Operação de Aquisição por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("aabf2def-1afa-44f6-8e16-01716f2b2cf0"), "98", "Outras Operações de Entrada", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("3aab7950-67bf-4e08-97e8-ac85b440091e"), "99", "Outras Operações", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { new Guid("58b0b3f1-74bc-4407-ada3-c06b40684423"), "61", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Não - Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("fd4b01a8-6004-464b-9669-17bac490d0e9"), "71", "Operação de Aquisição com Isenção", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("1ecf9d9f-66a0-4400-9b56-25c702475dd5"), "60", "Crédito Presumido -Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("532d1324-623b-427d-9cc4-3ae7c1739788"), "55", "Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("4a060ac5-323a-45b5-b31e-cf6451bf8927"), "03", "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9dc9a904-b000-4399-8d05-eb7b05b31fdb"), "01", "Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("62fb953b-59d5-46e4-93e0-452c73a93d0f"), "02", "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("ab72c8dd-0de3-4fc7-bd4e-e44b728b0087"), "04", "Operação Tributável (tributação monofásica (alíquota zero))", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true }
                });

            migrationBuilder.InsertData(
                table: "TabelaCST_PIS_COFINSs",
                columns: new[] { "Id", "Codigo", "Descricao", "DestacarPIS_COFINS", "UltimaAtualizacao", "UsaNaEntrada", "UsaNaSaida" },
                values: new object[,]
                {
                    { new Guid("069ec88d-7e64-4f0a-974f-a6cf58d005aa"), "05", "Operação Tributável por Substituição Tributária", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("9b2c6396-2b15-4f67-9774-7db6933d9eb1"), "06", "Operação Tributável (alíquota zero)", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("3f6337a9-ece6-4b10-865a-205418f7dab9"), "07", "Operação Isenta da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("64a8843d-4753-430f-a34a-bb03988ef8d7"), "08", "Operação Sem Incidência da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("3297a71f-d8d5-44ec-842f-b7221bacd0b2"), "49", "Outras Operações de Saída", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("4dc0569d-356d-4c0d-a733-6ce1aaf3e881"), "50", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("20c16dfe-5c3b-44d1-b9b1-767bb1145fc0"), "51", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("ed26bbf9-9413-47a3-83ee-827802f6435e"), "52", "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("a1f78cbf-9fa4-4809-bc44-9a85a2980332"), "53", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("a06107ee-941c-4ed5-b655-c3deba5c5b17"), "54", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { new Guid("1434aaea-4dd6-4a6c-a034-a6e5f4bde6a6"), "09", "Operação com Suspensão da Contribuição", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { new Guid("bed9db31-d4d8-4b72-8729-d80d85b058a8"), "56", "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não - Tributadas no Mercado Interno e de Exportação", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false }
                });

            migrationBuilder.InsertData(
                table: "TabelaSituacaoTributariaNFCes",
                columns: new[] { "Id", "Codigo", "Descricao", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("723e08dd-e36a-4542-9143-14b678991263"), "II", "Isento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba820c12-eb1d-4c76-9b39-9b23ce344222"), "NN", "Não Incidente", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6aea67de-fb91-4afd-97cb-6373c2844acc"), "FF", "Substituição", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c53efb17-c0e8-4b77-8adf-6a84e712b1af"), "01", "Normal(% TRIBUTADO)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TipoMercadorias",
                columns: new[] { "Id", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("c585cae1-1e59-4230-b6e4-ec6be789a038"), "VEÍCULO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1c0edc94-6bad-4ecc-a574-09079a27e594"), "COMBUSTÍVEL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81be89af-18fd-4b66-9b56-e3760aa78459"), "MEDICAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80d06387-7d47-4061-8ed0-b446c914026f"), "ARMAMENTO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UnidadeMedidas",
                columns: new[] { "Id", "Codigo", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("0ae878fa-5373-49d8-b47d-d18178c58f72"), "PCT", "Pacote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50f54727-42fe-4830-ac7c-db5bde27b72a"), "FRC", "Frasco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a6ea3c3-2215-4ef0-a649-719372e0ada3"), "SCO", "Saco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d71ea258-a580-4238-ab91-3d67a9b4e9e7"), "LTR", "Litro ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9820688-ba90-4a07-be82-b03f0b8a4dbc"), "GR", "Grama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9fa9eee-87c9-483d-b058-6fe87ac742c5"), "MTR", "Metro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e60e19b4-2e48-4411-914c-f0d2549b5627"), "PCA", "Peca", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b835b25-a62a-4ab5-aaa2-7b78a63aab74"), "CXA", "Caixa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("151ab54e-2001-4b93-8c6d-67b3f8a6aacd"), "UND", "Unidade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a23d044-473f-4368-b4da-df37200dc203"), "KG", "Kilograma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac893d32-f53c-4482-86d3-77b8587d9525"), "FRD", "Fardo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Codigo", "Nome", "PaisId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("9616a0cc-5e55-47ce-b473-615b6fda6929"), "AC", "Acre", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27f89ec5-da57-4e0d-a354-8d5c46c65c8a"), "SP", "São Paulo", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4e044e4-8709-4eab-bb7c-e9d2c5765298"), "SC", "Santa Catarina", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bd258451-f46e-4de7-a7e2-91040b7340e5"), "RR", "Roraima", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93cd8035-83ea-4451-9003-21f03c2a79e3"), "RO", "Rondônia", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5578c22-b5f5-4c3c-8a23-d95c202e213c"), "RS", "Rio Grande do Sul", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e43ce966-e63e-4446-bcb8-6b793aab1cbe"), "RN", "Rio Grande do Norte", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69dbd44d-330b-449e-bcf5-63de519571cf"), "RJ", "Rio de Janeiro", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61e04229-6a43-481a-9050-cf8eaded6210"), "PI", "Piauí", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5faac871-d3e6-4a58-9746-29a11d8ddfe4"), "PE", "Pernambuco", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ddc62734-e8a3-4a0e-b320-e04857c68e3e"), "PR", "Paraná", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30793823-a5f7-433a-9666-16ca4618705d"), "PB", "Paraíba", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e1aaf33-b3c3-4f0f-9afd-7bb6b1ad00c4"), "SE", "Sergipe", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a4aac65-e2c3-44e2-aa5a-9f33596608a8"), "PA", "Pará", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("781c2f81-bc6a-4845-944c-61dc6df18bee"), "MT", "Mato Grosso", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ec8e867-4304-46e4-9699-6b86dbc07e57"), "MS", "Mato Grosso do Sul", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ba2a165-3a52-4518-99e2-a808925b9228"), "MA", "Maranhão", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9037e387-2eb4-40a5-bd99-b22968dffe17"), "GO", "Goias", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("02e96beb-cb98-4a08-bcd9-df018cd3bd7b"), "ES", "Espirito Santo", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77dfc781-f790-4587-99bd-087118bcc474"), "DF", "Distrito Federal", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c13c965-8e97-4aad-a92a-44862152857c"), "CE", "Ceará", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d747d9c2-047e-4561-9676-54fa0fb95ad3"), "BA", "Bahia", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cadebc30-4f17-4dac-b46a-0c572c7e04fc"), "AM", "Amazonas", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("783d76e1-0ef0-4f48-867a-1b9b464df5e9"), "AP", "Amapá", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea159fab-1f24-4735-8060-a7bc80bfaf04"), "AL", "Alagoas", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5026560-d966-4cf7-a6e0-1331b23d90b2"), "MG", "Minas Gerais", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d1591a2-72f3-45be-afd7-752af8199c4b"), "EX", "Exterior", new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Cidades_End_CidadeId",
                table: "Empresas",
                column: "End_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Cidades_End_CidadeId",
                table: "Empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("02e96beb-cb98-4a08-bcd9-df018cd3bd7b"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("0e1aaf33-b3c3-4f0f-9afd-7bb6b1ad00c4"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("27f89ec5-da57-4e0d-a354-8d5c46c65c8a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("30793823-a5f7-433a-9666-16ca4618705d"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("4a4aac65-e2c3-44e2-aa5a-9f33596608a8"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("5d1591a2-72f3-45be-afd7-752af8199c4b"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("5faac871-d3e6-4a58-9746-29a11d8ddfe4"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("61e04229-6a43-481a-9050-cf8eaded6210"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("69dbd44d-330b-449e-bcf5-63de519571cf"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("77dfc781-f790-4587-99bd-087118bcc474"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("781c2f81-bc6a-4845-944c-61dc6df18bee"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("783d76e1-0ef0-4f48-867a-1b9b464df5e9"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("7c13c965-8e97-4aad-a92a-44862152857c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("8ba2a165-3a52-4518-99e2-a808925b9228"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9037e387-2eb4-40a5-bd99-b22968dffe17"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("93cd8035-83ea-4451-9003-21f03c2a79e3"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9616a0cc-5e55-47ce-b473-615b6fda6929"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("9ec8e867-4304-46e4-9699-6b86dbc07e57"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("bd258451-f46e-4de7-a7e2-91040b7340e5"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("cadebc30-4f17-4dac-b46a-0c572c7e04fc"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("d5026560-d966-4cf7-a6e0-1331b23d90b2"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("d747d9c2-047e-4561-9676-54fa0fb95ad3"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ddc62734-e8a3-4a0e-b320-e04857c68e3e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e43ce966-e63e-4446-bcb8-6b793aab1cbe"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e5578c22-b5f5-4c3c-8a23-d95c202e213c"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("ea159fab-1f24-4735-8060-a7bc80bfaf04"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("f4e044e4-8709-4eab-bb7c-e9d2c5765298"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("09600943-ca75-4ac9-b9df-11d7804828ff"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("29088a5e-44dd-47cd-903f-1be74dc27e98"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("48283b6d-4630-4918-a2db-8661e24757e4"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("9f2ddede-b9de-43f1-afd7-047743058bc9"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("a95d2d30-6f3a-49a3-af8e-a68347e79057"));

            migrationBuilder.DeleteData(
                table: "GrupoCFOPs",
                keyColumn: "Id",
                keyValue: new Guid("eace3cfc-9844-42b2-aef0-9bc0a4a4fc3e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("4e7d10d6-4f7b-414e-8f90-00c7daf0b9d8"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("563077dd-5009-4d93-950a-a3e159e20b31"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("602b93c7-cb76-427f-8d43-fa95734f5825"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("689fc616-e300-4e37-b96e-0939d9b53b84"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("6da9f8e2-21b9-4583-8819-908880649c6c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("8c4cc729-2060-4145-9076-013f11a13839"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("a27a29aa-f9d8-4113-849b-05b6d3b8a185"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("beeb5abc-570b-4059-8c69-924d210bcb8a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("cb1f9af0-5732-4d99-b150-4303cd6d279e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("cd072319-87e9-4ad0-adc4-0a6f699d2f3c"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("d30a07ec-712f-48f4-9fbd-41ff4c0edc3f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("e7b56194-81c8-465d-bde3-9ef4ad16e9f6"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("e8b02720-3ab5-4cf4-91ef-100d5564f0e3"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_IPIs",
                keyColumn: "Id",
                keyValue: new Guid("f5a83bdc-28e9-42da-8ff8-a23745aa4fc8"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("067a178f-c4ac-4b97-a295-e649cee16504"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("069ec88d-7e64-4f0a-974f-a6cf58d005aa"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("1434aaea-4dd6-4a6c-a034-a6e5f4bde6a6"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("1ecf9d9f-66a0-4400-9b56-25c702475dd5"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("20c16dfe-5c3b-44d1-b9b1-767bb1145fc0"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("3297a71f-d8d5-44ec-842f-b7221bacd0b2"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("33b1bcbc-4223-433a-9c49-e8e3ded1acdb"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("3aab7950-67bf-4e08-97e8-ac85b440091e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("3f6337a9-ece6-4b10-865a-205418f7dab9"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("4a060ac5-323a-45b5-b31e-cf6451bf8927"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("4dc0569d-356d-4c0d-a733-6ce1aaf3e881"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("532d1324-623b-427d-9cc4-3ae7c1739788"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("58b0b3f1-74bc-4407-ada3-c06b40684423"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("62fb953b-59d5-46e4-93e0-452c73a93d0f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("64a8843d-4753-430f-a34a-bb03988ef8d7"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("74d70ee3-6ea6-4a28-aec7-d687f211aad5"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("94461050-8a45-472b-af8d-78999391b57a"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9b2c6396-2b15-4f67-9774-7db6933d9eb1"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("9dc9a904-b000-4399-8d05-eb7b05b31fdb"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("a06107ee-941c-4ed5-b655-c3deba5c5b17"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("a1f78cbf-9fa4-4809-bc44-9a85a2980332"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("aabf2def-1afa-44f6-8e16-01716f2b2cf0"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("ab72c8dd-0de3-4fc7-bd4e-e44b728b0087"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("ba190994-8e03-4a54-a3a2-b52015f57916"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("bed9db31-d4d8-4b72-8729-d80d85b058a8"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("bf6970b9-52d7-4c53-a024-c0c5fafd2caa"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("c882c2af-a565-42df-8b96-fca693a877d2"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("d8c0faa3-c2e9-4276-9c0d-96e4935fbf37"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("da82e943-d00d-437e-8091-604f07cf1e7f"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("e478d8bf-294a-4c34-a375-7d9bdbaedfbd"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("ed26bbf9-9413-47a3-83ee-827802f6435e"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("fd4b01a8-6004-464b-9669-17bac490d0e9"));

            migrationBuilder.DeleteData(
                table: "TabelaCST_PIS_COFINSs",
                keyColumn: "Id",
                keyValue: new Guid("fe29b6e2-5f43-471c-8ff1-d35386cb24fc"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("6aea67de-fb91-4afd-97cb-6373c2844acc"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("723e08dd-e36a-4542-9143-14b678991263"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("ba820c12-eb1d-4c76-9b39-9b23ce344222"));

            migrationBuilder.DeleteData(
                table: "TabelaSituacaoTributariaNFCes",
                keyColumn: "Id",
                keyValue: new Guid("c53efb17-c0e8-4b77-8adf-6a84e712b1af"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("1c0edc94-6bad-4ecc-a574-09079a27e594"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("80d06387-7d47-4061-8ed0-b446c914026f"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("81be89af-18fd-4b66-9b56-e3760aa78459"));

            migrationBuilder.DeleteData(
                table: "TipoMercadorias",
                keyColumn: "Id",
                keyValue: new Guid("c585cae1-1e59-4230-b6e4-ec6be789a038"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("0ae878fa-5373-49d8-b47d-d18178c58f72"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("151ab54e-2001-4b93-8c6d-67b3f8a6aacd"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("3a6ea3c3-2215-4ef0-a649-719372e0ada3"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("50f54727-42fe-4830-ac7c-db5bde27b72a"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("6a23d044-473f-4368-b4da-df37200dc203"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("9b835b25-a62a-4ab5-aaa2-7b78a63aab74"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("ac893d32-f53c-4482-86d3-77b8587d9525"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("c9fa9eee-87c9-483d-b058-6fe87ac742c5"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("d71ea258-a580-4238-ab91-3d67a9b4e9e7"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("e60e19b4-2e48-4411-914c-f0d2549b5627"));

            migrationBuilder.DeleteData(
                table: "UnidadeMedidas",
                keyColumn: "Id",
                keyValue: new Guid("f9820688-ba90-4a07-be82-b03f0b8a4dbc"));

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: new Guid("ea6ae817-b291-4814-a845-de7c37f53f82"));

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "Empresa");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_End_CidadeId",
                table: "Empresa",
                newName: "IX_Empresa_End_CidadeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoVenda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoSugerido",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoCompra",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoC",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoB",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PrecoA",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_PontoEquilibrio",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_OutrosCustos",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Marketing",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemVenda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemSugerido",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemC",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemB",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_MargemA",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ImpostoFederais",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_IPI",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Venda",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Fronteira",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_ICMS_Compra",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Frete",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_EncFinanceiro",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Embalagem",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CustoMercadoria",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CustoFixo",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Comissao",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CalculoPreco",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_CalculoPrecificacao",
                table: "Mercadorias",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_OutrosPMC",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_OutrosNVE",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ValorTributosTotal",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosTotal",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosMunicipais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosFederais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_TributosEstaduais",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_PISCOFINS_PIS_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_IPI_ValorAliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_ValorAdicional",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_ReducaoBase",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMS_Deferimento",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_ValorAdicional",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_ReducaoBase",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFS_ICMSST_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_PIS_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_IPI_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Fiscal_NFE_COFINS_Aliquota",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_TributacaoNFCe_AliquotaICMS",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_QuantidadeMinimo",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_Quantidade",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_PesoLiquido",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Estoque_PesoBruto",
                table: "Mercadorias",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "QuantidadeEmEstoque",
                table: "Estoques",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "QuantidadeBloqueada",
                table: "Estoques",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Unidade",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoMunicipal",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual_SubTributaria",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Numero",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Logradouro",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_CEP",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "End_Bairro",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CreditoSimplesNacional",
                table: "Empresa",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Empresa",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Cidades_End_CidadeId",
                table: "Empresa",
                column: "End_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
