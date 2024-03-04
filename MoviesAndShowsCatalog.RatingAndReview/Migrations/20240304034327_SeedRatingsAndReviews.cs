using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesAndShowsCatalog.RatingAndReview.Migrations
{
    /// <inheritdoc />
    public partial class SeedRatingsAndReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RatingsAndReviews",
                columns: ["Id", "Rating", "Review", "VisualProductionId"],
                values: new object[,]
                {
                    { 1, 3f, "A thrilling series with great action sequences and an intriguing storyline.", 1 },
                    { 2, 1f, "Henry Cavill's portrayal of Geralt is captivating, and the world-building is phenomenal.", 1 },
                    { 3, 4f, "An adrenaline-fueled action film with breathtaking stunts and choreography.", 2 },
                    { 4, 2f, "Keanu Reeves delivers a standout performance as the legendary hitman.", 2 },
                    { 5, 5f, "A funny and heartwarming comedy that delivers a meaningful message about life and priorities.", 3 },
                    { 6, 0f, "A lighthearted comedy with a talented ensemble cast, perfect for a relaxing movie night.", 4 },
                    { 7, 2f, "An intense and gripping drama with unforgettable characters and plot twists.", 5 },
                    { 8, 4f, "Bryan Cranston's performance as Walter White is Emmy-worthy, and the storytelling is masterful.", 5 },
                    { 9, 1f, "A sprawling epic with complex characters and political intrigue, though the final season left some fans disappointed.", 6 },
                    { 10, 3f, "A groundbreaking sci-fi film with mind-bending visuals and thought-provoking themes.", 7 },
                    { 11, 2f, "Keanu Reeves shines in this action-packed thrill ride that challenges perceptions of reality.", 7 },
                    { 12, 5f, "A thought-provoking series that explores the dark side of technology and its impact on society.", 8 },
                    { 13, 0f, "Each episode is like a mini sci-fi film, leaving you questioning the future of humanity.", 8 },
                    { 14, 4f, "A captivating fantasy series with rich world-building and compelling characters.", 9 },
                    { 15, 1f, "The Grishaverse comes to life in this visually stunning adaptation, perfect for fans of the books.", 9 },
                    { 16, 2f, "An enchanting start to the beloved series, capturing the magic of J.K. Rowling's world on screen.", 10 },
                    { 17, 3f, "A delightful fantasy film that appeals to both children and adults, with memorable characters and whimsical adventures.", 10 },
                    { 18, 5f, "A thrilling horror series with engaging mythology and strong performances from the cast.", 11 },
                    { 19, 0f, "The dynamic between Sam and Dean Winchester is the heart of the show, keeping viewers hooked season after season.", 11 },
                    { 20, 4f, "A classic horror film that defined the slasher genre, with suspenseful scares and an iconic villain.", 12 },
                    { 21, 1f, "John Carpenter's direction creates a tense atmosphere, making every shadow feel ominous.", 12 },
                    { 22, 3f, "A brilliant modern take on the classic detective, with clever mysteries and stellar performances from Benedict Cumberbatch and Martin Freeman.", 13 },
                    { 23, 2f, "The writing is sharp and witty, keeping viewers guessing until the very end of each case.", 13 },
                    { 24, 5f, "A gripping mystery-thriller with intense performances from Hugh Jackman and Jake Gyllenhaal.", 14 },
                    { 25, 0f, "The tension builds relentlessly, leaving you on the edge of your seat until the shocking conclusion.", 14 },
                    { 26, 4f, "A sweeping romance with historical intrigue and breathtaking Scottish landscapes.", 15 },
                    { 27, 3f, "Claire and Jamie's love story transcends time, drawing viewers into their captivating adventures.", 15 },
                    { 28, 1f, "An epic romance set against the backdrop of the ill-fated Titanic, with stunning visuals and a timeless love story.", 16 },
                    { 29, 2f, "Leonardo DiCaprio and Kate Winslet's chemistry is electric, making this a must-watch for romantics.", 16 },
                    { 30, 5f, "An enthralling documentary that offers unprecedented insight into Michael Jordan's legendary career and the Chicago Bulls dynasty.", 17 },
                    { 31, 0f, "Even non-basketball fans will be captivated by the drama and intrigue behind one of sports' greatest teams.", 17 },
                    { 32, 4f, "A chilling and thought-provoking documentary that explores the perpetrators' perspective in the Indonesian genocide.", 18 },
                    { 33, 3f, "The reenactments are surreal and disturbing, shedding light on the atrocities committed and the lasting trauma.", 18 },
                    { 34, 1f, "A beloved animated sitcom with sharp satire and memorable characters that have become cultural icons.", 19 },
                    { 35, 2f, "The humor is timeless, making it a timeless classic for viewers of all ages.", 19 },
                    { 36, 5f, "An irreverent and hilarious take on fairy tales, with clever jokes and heartwarming moments.", 20 },
                    { 37, 0f, "The animation is groundbreaking, and the characters are endearing, making Shrek a modern classic.", 20 },
                    { 38, 4f, "A thrilling adventure series with epic battles and Viking lore.", 21 },
                    { 39, 3f, "Truly captures the spirit of Norse mythology with its engaging storytelling and strong performances.", 21 },
                    { 40, 2f, "An iconic adventure series with unforgettable action sequences and a charismatic hero.", 22 },
                    { 41, 5f, "Harrison Ford's portrayal of Indiana Jones is legendary, and the series is a thrilling ride from start to finish.", 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RatingsAndReviews",
                keyColumn: "Id",
                keyValue: 41);
        }
    }
}
