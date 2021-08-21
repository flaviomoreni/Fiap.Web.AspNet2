using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Web.AspNet2.Migrations
{
    public partial class CidadeFiap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    QuantidadeHabitantes = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                });

            migrationBuilder.InsertData(
                table: "Cidade",
                columns: new[] { "CidadeId", "Estado", "NomeCidade", "QuantidadeHabitantes" },
                values: new object[] { 1, "SP", "São Paulo", 11 });

            migrationBuilder.InsertData(
                table: "Cidade",
                columns: new[] { "CidadeId", "Estado", "NomeCidade", "QuantidadeHabitantes" },
                values: new object[] { 2, "RJ", "Rio de Janeiro", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_NomeCidade_Estado",
                table: "Cidade",
                columns: new[] { "NomeCidade", "Estado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
