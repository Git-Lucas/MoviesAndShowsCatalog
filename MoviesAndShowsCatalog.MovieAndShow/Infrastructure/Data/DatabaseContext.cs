using Microsoft.EntityFrameworkCore;
using MoviesAndShowsCatalog.MovieAndShow.Domain.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Infrastructure.Data;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<VisualProduction> VisualProductions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VisualProduction>().HasData(
                new VisualProduction(
                        id: 1,
                        title: "The Witcher",
                        genre: Domain.Enums.Genre.Action,
                        releaseYear: 2019
                    ),
                new VisualProduction(
                        id: 2,
                        title: "John Wick",
                        genre: Domain.Enums.Genre.Action,
                        releaseYear: 2014
                    ),
                new VisualProduction(
                        id: 3,
                        title: "Click",
                        genre: Domain.Enums.Genre.Comedy,
                        releaseYear: 2006
                    ),
                new VisualProduction(
                        id: 4,
                        title: "Grown Ups",
                        genre: Domain.Enums.Genre.Comedy,
                        releaseYear: 2010
                    ),
                new VisualProduction(
                        id: 5,
                        title: "Breaking Bad",
                        genre: Domain.Enums.Genre.Drama,
                        releaseYear: 2008
                    ),
                new VisualProduction(
                        id: 6,
                        title: "Game of Thrones",
                        genre: Domain.Enums.Genre.Drama,
                        releaseYear: 2011
                    ),
                new VisualProduction(
                        id: 7,
                        title: "The Matrix",
                        genre: Domain.Enums.Genre.ScienceFiction,
                        releaseYear: 1999
                    ),
                new VisualProduction(
                        id: 8,
                        title: "Black Mirror",
                        genre: Domain.Enums.Genre.ScienceFiction,
                        releaseYear: 2011
                    ),
                new VisualProduction(
                        id: 9,
                        title: "Shadow and Bone",
                        genre: Domain.Enums.Genre.Fantasy,
                        releaseYear: 2021
                    ),
                new VisualProduction(
                        id: 10,
                        title: "Harry Potter and the Philosopher's Stone",
                        genre: Domain.Enums.Genre.Fantasy,
                        releaseYear: 2001
                    ),
                new VisualProduction(
                        id: 11,
                        title: "Supernatural",
                        genre: Domain.Enums.Genre.Horror,
                        releaseYear: 2005
                    ),
                new VisualProduction(
                        id: 12,
                        title: "Halloween",
                        genre: Domain.Enums.Genre.Horror,
                        releaseYear: 1978
                    ),
                new VisualProduction(
                        id: 13,
                        title: "Sherlock",
                        genre: Domain.Enums.Genre.Mystery,
                        releaseYear: 2010
                    ),
                new VisualProduction(
                        id: 14,
                        title: "Prisoners",
                        genre: Domain.Enums.Genre.Mystery,
                        releaseYear: 2013
                    ),
                new VisualProduction(
                        id: 15,
                        title: "Outlander",
                        genre: Domain.Enums.Genre.Romance,
                        releaseYear: 2014
                    ),
                new VisualProduction(
                        id: 16,
                        title: "Titanic",
                        genre: Domain.Enums.Genre.Romance,
                        releaseYear: 1997
                    ),
                new VisualProduction(
                        id: 17,
                        title: "The Last Dance",
                        genre: Domain.Enums.Genre.Documentary,
                        releaseYear: 2020
                    ),
                new VisualProduction(
                        id: 18,
                        title: "The Act of Killing",
                        genre: Domain.Enums.Genre.Documentary,
                        releaseYear: 2012
                    ),
                new VisualProduction(
                        id: 19,
                        title: "The Simpsons",
                        genre: Domain.Enums.Genre.Animation,
                        releaseYear: 1989
                    ),
                new VisualProduction(
                        id: 20,
                        title: "Shrek",
                        genre: Domain.Enums.Genre.Animation,
                        releaseYear: 2001
                    ),
                new VisualProduction(
                        id: 21,
                        title: "Vikings",
                        genre: Domain.Enums.Genre.Adventure,
                        releaseYear: 2013
                    ),
                new VisualProduction(
                        id: 22,
                        title: "Indiana Jones Series",
                        genre: Domain.Enums.Genre.Adventure,
                        releaseYear: 1981
                    )
            );
    }
}
