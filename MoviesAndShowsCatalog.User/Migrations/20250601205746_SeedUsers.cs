using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesAndShowsCatalog.User.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GenrePreferences", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "", "AQAAAAIAAYagAAAAEOH8C7EC030bk6itGAXNQcRDMOcNYtiKYZp4EzeI12Zq6kOBdC2qIPeP3mUgqZcl+A==", 1, "administrador" },
                    { 2, "Action,ScienceFiction", "AQAAAAIAAYagAAAAEFjT+mfY9mXm0rAkEHo2T5ju0W3JBRFyYSFzhIPaXVUo8OiuyC86UbVYrqTzSX8IXg==", 0, "lucas" },
                    { 3, "Comedy,Adventure", "AQAAAAIAAYagAAAAEAyKJYCmG6f7E/5MmM/7E0MKSjEoNFTcp+x77gG18lVukfP4JjyhU48H3w6M1NppqA==", 0, "joão" },
                    { 4, "Action,Fantasy,Romance", "AQAAAAIAAYagAAAAEAbpYOwKD0NlxbzGRhKYNm3nNxJN6t92ksA80aMdJ+134gyfD08c9dtyyBsEYSv+tA==", 0, "maria" },
                    { 5, "Animation,Documentary", "AQAAAAIAAYagAAAAEBHSfqJgFy4dqwRDDEIQwWJuRGgk6iuP1plQ5iTp0aZX1txOBILwgSpiK1WwWfUtbQ==", 0, "carlos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
