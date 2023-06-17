using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class NotaFiscalSaidaReferenciaCodigoChaveAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoChaveAcesso",
                table: "NotaFiscalSaidaReferencias",
                type: "varchar(46)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(44)");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "EstoqueLancamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoChaveAcesso",
                table: "NotaFiscalSaidaReferencias",
                type: "varchar(44)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(46)");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "EstoqueLancamentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);
        }
    }
}
