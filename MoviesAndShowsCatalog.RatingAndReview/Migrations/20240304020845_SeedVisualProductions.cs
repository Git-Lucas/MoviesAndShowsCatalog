using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAndShowsCatalog.RatingAndReview.Migrations
{
    /// <inheritdoc />
    public partial class SeedVisualProductions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VisualProductions",
                columns: ["Id", "Genre", "ReleaseYear", "Title"],
                values: new object[,]
                {
                    { 1, 0, 2019, "The Witcher" },
                    { 2, 0, 2014, "John Wick" },
                    { 3, 1, 2006, "Click" },
                    { 4, 1, 2010, "Grown Ups" },
                    { 5, 2, 2008, "Breaking Bad" },
                    { 6, 2, 2011, "Game of Thrones" },
                    { 7, 3, 1999, "The Matrix" },
                    { 8, 3, 2011, "Black Mirror" },
                    { 9, 4, 2021, "Shadow and Bone" },
                    { 10, 4, 2001, "Harry Potter and the Philosopher's Stone" },
                    { 11, 5, 2005, "Supernatural" },
                    { 12, 5, 1978, "Halloween" },
                    { 13, 6, 2010, "Sherlock" },
                    { 14, 6, 2013, "Prisoners" },
                    { 15, 7, 2014, "Outlander" },
                    { 16, 7, 1997, "Titanic" },
                    { 17, 8, 2020, "The Last Dance" },
                    { 18, 8, 2012, "The Act of Killing" },
                    { 19, 9, 1989, "The Simpsons" },
                    { 20, 9, 2001, "Shrek" },
                    { 21, 10, 2013, "Vikings" },
                    { 22, 10, 1981, "Indiana Jones Series" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VisualProductions",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
