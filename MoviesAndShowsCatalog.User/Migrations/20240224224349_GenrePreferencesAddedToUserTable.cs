using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAndShowsCatalog.User.Migrations
{
    /// <inheritdoc />
    public partial class GenrePreferencesAddedToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenrePreferences",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenrePreferences",
                table: "Users");
        }
    }
}
