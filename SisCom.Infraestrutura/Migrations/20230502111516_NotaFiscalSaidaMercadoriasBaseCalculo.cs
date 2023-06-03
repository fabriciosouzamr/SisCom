using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaidaMercadoriasBaseCalculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBaseSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBaseCalculo",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBaseSubstituicaoTributaria",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBaseCalculo",
                table: "NotaFiscalSaidaMercadorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldDefaultValue: 0m);
        }
    }
}
