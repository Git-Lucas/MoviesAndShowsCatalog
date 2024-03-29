﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAndShowsCatalog.RatingAndReview.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesAndShowsCatalog.RatingAndReview.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoviesAndShowsCatalog.RatingAndReview.Domain.Entities.RatingAndReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VisualProductionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VisualProductionId");

                    b.ToTable("RatingsAndReviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rating = 3f,
                            Review = "A thrilling series with great action sequences and an intriguing storyline.",
                            VisualProductionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Rating = 1f,
                            Review = "Henry Cavill's portrayal of Geralt is captivating, and the world-building is phenomenal.",
                            VisualProductionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Rating = 4f,
                            Review = "An adrenaline-fueled action film with breathtaking stunts and choreography.",
                            VisualProductionId = 2
                        },
                        new
                        {
                            Id = 4,
                            Rating = 2f,
                            Review = "Keanu Reeves delivers a standout performance as the legendary hitman.",
                            VisualProductionId = 2
                        },
                        new
                        {
                            Id = 5,
                            Rating = 5f,
                            Review = "A funny and heartwarming comedy that delivers a meaningful message about life and priorities.",
                            VisualProductionId = 3
                        },
                        new
                        {
                            Id = 6,
                            Rating = 0f,
                            Review = "A lighthearted comedy with a talented ensemble cast, perfect for a relaxing movie night.",
                            VisualProductionId = 4
                        },
                        new
                        {
                            Id = 7,
                            Rating = 2f,
                            Review = "An intense and gripping drama with unforgettable characters and plot twists.",
                            VisualProductionId = 5
                        },
                        new
                        {
                            Id = 8,
                            Rating = 4f,
                            Review = "Bryan Cranston's performance as Walter White is Emmy-worthy, and the storytelling is masterful.",
                            VisualProductionId = 5
                        },
                        new
                        {
                            Id = 9,
                            Rating = 1f,
                            Review = "A sprawling epic with complex characters and political intrigue, though the final season left some fans disappointed.",
                            VisualProductionId = 6
                        },
                        new
                        {
                            Id = 10,
                            Rating = 3f,
                            Review = "A groundbreaking sci-fi film with mind-bending visuals and thought-provoking themes.",
                            VisualProductionId = 7
                        },
                        new
                        {
                            Id = 11,
                            Rating = 2f,
                            Review = "Keanu Reeves shines in this action-packed thrill ride that challenges perceptions of reality.",
                            VisualProductionId = 7
                        },
                        new
                        {
                            Id = 12,
                            Rating = 5f,
                            Review = "A thought-provoking series that explores the dark side of technology and its impact on society.",
                            VisualProductionId = 8
                        },
                        new
                        {
                            Id = 13,
                            Rating = 0f,
                            Review = "Each episode is like a mini sci-fi film, leaving you questioning the future of humanity.",
                            VisualProductionId = 8
                        },
                        new
                        {
                            Id = 14,
                            Rating = 4f,
                            Review = "A captivating fantasy series with rich world-building and compelling characters.",
                            VisualProductionId = 9
                        },
                        new
                        {
                            Id = 15,
                            Rating = 1f,
                            Review = "The Grishaverse comes to life in this visually stunning adaptation, perfect for fans of the books.",
                            VisualProductionId = 9
                        },
                        new
                        {
                            Id = 16,
                            Rating = 2f,
                            Review = "An enchanting start to the beloved series, capturing the magic of J.K. Rowling's world on screen.",
                            VisualProductionId = 10
                        },
                        new
                        {
                            Id = 17,
                            Rating = 3f,
                            Review = "A delightful fantasy film that appeals to both children and adults, with memorable characters and whimsical adventures.",
                            VisualProductionId = 10
                        },
                        new
                        {
                            Id = 18,
                            Rating = 5f,
                            Review = "A thrilling horror series with engaging mythology and strong performances from the cast.",
                            VisualProductionId = 11
                        },
                        new
                        {
                            Id = 19,
                            Rating = 0f,
                            Review = "The dynamic between Sam and Dean Winchester is the heart of the show, keeping viewers hooked season after season.",
                            VisualProductionId = 11
                        },
                        new
                        {
                            Id = 20,
                            Rating = 4f,
                            Review = "A classic horror film that defined the slasher genre, with suspenseful scares and an iconic villain.",
                            VisualProductionId = 12
                        },
                        new
                        {
                            Id = 21,
                            Rating = 1f,
                            Review = "John Carpenter's direction creates a tense atmosphere, making every shadow feel ominous.",
                            VisualProductionId = 12
                        },
                        new
                        {
                            Id = 22,
                            Rating = 3f,
                            Review = "A brilliant modern take on the classic detective, with clever mysteries and stellar performances from Benedict Cumberbatch and Martin Freeman.",
                            VisualProductionId = 13
                        },
                        new
                        {
                            Id = 23,
                            Rating = 2f,
                            Review = "The writing is sharp and witty, keeping viewers guessing until the very end of each case.",
                            VisualProductionId = 13
                        },
                        new
                        {
                            Id = 24,
                            Rating = 5f,
                            Review = "A gripping mystery-thriller with intense performances from Hugh Jackman and Jake Gyllenhaal.",
                            VisualProductionId = 14
                        },
                        new
                        {
                            Id = 25,
                            Rating = 0f,
                            Review = "The tension builds relentlessly, leaving you on the edge of your seat until the shocking conclusion.",
                            VisualProductionId = 14
                        },
                        new
                        {
                            Id = 26,
                            Rating = 4f,
                            Review = "A sweeping romance with historical intrigue and breathtaking Scottish landscapes.",
                            VisualProductionId = 15
                        },
                        new
                        {
                            Id = 27,
                            Rating = 3f,
                            Review = "Claire and Jamie's love story transcends time, drawing viewers into their captivating adventures.",
                            VisualProductionId = 15
                        },
                        new
                        {
                            Id = 28,
                            Rating = 1f,
                            Review = "An epic romance set against the backdrop of the ill-fated Titanic, with stunning visuals and a timeless love story.",
                            VisualProductionId = 16
                        },
                        new
                        {
                            Id = 29,
                            Rating = 2f,
                            Review = "Leonardo DiCaprio and Kate Winslet's chemistry is electric, making this a must-watch for romantics.",
                            VisualProductionId = 16
                        },
                        new
                        {
                            Id = 30,
                            Rating = 5f,
                            Review = "An enthralling documentary that offers unprecedented insight into Michael Jordan's legendary career and the Chicago Bulls dynasty.",
                            VisualProductionId = 17
                        },
                        new
                        {
                            Id = 31,
                            Rating = 0f,
                            Review = "Even non-basketball fans will be captivated by the drama and intrigue behind one of sports' greatest teams.",
                            VisualProductionId = 17
                        },
                        new
                        {
                            Id = 32,
                            Rating = 4f,
                            Review = "A chilling and thought-provoking documentary that explores the perpetrators' perspective in the Indonesian genocide.",
                            VisualProductionId = 18
                        },
                        new
                        {
                            Id = 33,
                            Rating = 3f,
                            Review = "The reenactments are surreal and disturbing, shedding light on the atrocities committed and the lasting trauma.",
                            VisualProductionId = 18
                        },
                        new
                        {
                            Id = 34,
                            Rating = 1f,
                            Review = "A beloved animated sitcom with sharp satire and memorable characters that have become cultural icons.",
                            VisualProductionId = 19
                        },
                        new
                        {
                            Id = 35,
                            Rating = 2f,
                            Review = "The humor is timeless, making it a timeless classic for viewers of all ages.",
                            VisualProductionId = 19
                        },
                        new
                        {
                            Id = 36,
                            Rating = 5f,
                            Review = "An irreverent and hilarious take on fairy tales, with clever jokes and heartwarming moments.",
                            VisualProductionId = 20
                        },
                        new
                        {
                            Id = 37,
                            Rating = 0f,
                            Review = "The animation is groundbreaking, and the characters are endearing, making Shrek a modern classic.",
                            VisualProductionId = 20
                        },
                        new
                        {
                            Id = 38,
                            Rating = 4f,
                            Review = "A thrilling adventure series with epic battles and Viking lore.",
                            VisualProductionId = 21
                        },
                        new
                        {
                            Id = 39,
                            Rating = 3f,
                            Review = "Truly captures the spirit of Norse mythology with its engaging storytelling and strong performances.",
                            VisualProductionId = 21
                        },
                        new
                        {
                            Id = 40,
                            Rating = 2f,
                            Review = "An iconic adventure series with unforgettable action sequences and a charismatic hero.",
                            VisualProductionId = 22
                        },
                        new
                        {
                            Id = 41,
                            Rating = 5f,
                            Review = "Harrison Ford's portrayal of Indiana Jones is legendary, and the series is a thrilling ride from start to finish.",
                            VisualProductionId = 22
                        });
                });

            modelBuilder.Entity("MoviesAndShowsCatalog.RatingAndReview.Domain.Entities.VisualProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Genre")
                        .HasColumnType("integer");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VisualProductions");
                });

            modelBuilder.Entity("MoviesAndShowsCatalog.RatingAndReview.Domain.Entities.RatingAndReview", b =>
                {
                    b.HasOne("MoviesAndShowsCatalog.RatingAndReview.Domain.Entities.VisualProduction", "VisualProduction")
                        .WithMany()
                        .HasForeignKey("VisualProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VisualProduction");
                });
#pragma warning restore 612, 618
        }
    }
}
