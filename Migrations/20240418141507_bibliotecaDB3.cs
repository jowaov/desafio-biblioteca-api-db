using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAPIRocketseat.Migrations
{
    /// <inheritdoc />
    public partial class bibliotecaDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Livros");
        }
    }
}
