using Microsoft.EntityFrameworkCore.Migrations;

namespace AppData.Migrations
{
    public partial class SeAgreganIndice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Categoria",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_Url",
                table: "Libro",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Url",
                table: "Categoria",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Libro_Url",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_Url",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Categoria");
        }
    }
}
