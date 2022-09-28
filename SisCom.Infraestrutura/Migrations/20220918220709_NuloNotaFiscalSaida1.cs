using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NuloNotaFiscalSaida1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VolumeTransportados_Marca",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "VolumeTransportados_Especie",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_RNTRC",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_Placa",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_CNPJ_CPF",
                table: "NotaFiscalSaidas",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "SubSerie",
                table: "NotaFiscalSaidas",
                type: "varchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "Serie",
                table: "NotaFiscalSaidas",
                type: "varchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefaz",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");

            migrationBuilder.AlterColumn<string>(
                name: "Protocolo",
                table: "NotaFiscalSaidas",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "ObservacaoDocumento",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");

            migrationBuilder.AlterColumn<string>(
                name: "NotaFiscal",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "NotaFiscalSaidas",
                type: "varchar(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesComplementaresInteresseContribuinte_Obsersacao",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesAdicionaisInteresseFisco",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");

            migrationBuilder.AlterColumn<string>(
                name: "IE",
                table: "NotaFiscalSaidas",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "HoraEmissao",
                table: "NotaFiscalSaidas",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailDestinoXML",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoChaveAcesso",
                table: "NotaFiscalSaidas",
                type: "varchar(44)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(44)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente_Telefone",
                table: "NotaFiscalSaidas",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente_EMail",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ_CPF",
                table: "NotaFiscalSaidas",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VolumeTransportados_Marca",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VolumeTransportados_Especie",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_RNTRC",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_Placa",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Transportadora_CNPJ_CPF",
                table: "NotaFiscalSaidas",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubSerie",
                table: "NotaFiscalSaidas",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Serie",
                table: "NotaFiscalSaidas",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefazCodigo",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RetornoSefaz",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Protocolo",
                table: "NotaFiscalSaidas",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObservacaoDocumento",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotaFiscal",
                table: "NotaFiscalSaidas",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "NotaFiscalSaidas",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesComplementaresInteresseContribuinte_Obsersacao",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InformacoesAdicionaisInteresseFisco",
                table: "NotaFiscalSaidas",
                type: "varchar(8000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IE",
                table: "NotaFiscalSaidas",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraEmissao",
                table: "NotaFiscalSaidas",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailDestinoXML",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoChaveAcesso",
                table: "NotaFiscalSaidas",
                type: "varchar(44)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(44)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cliente_Telefone",
                table: "NotaFiscalSaidas",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cliente_EMail",
                table: "NotaFiscalSaidas",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ_CPF",
                table: "NotaFiscalSaidas",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);
        }
    }
}
