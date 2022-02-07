using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisCom.Infraestrutura.Migrations
{
    public partial class TipoPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPessoas");
        }
    }
}
