namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Util;

public class Pagination
{
    public static int CurrentPage(int skip, int take)
    {
        return skip / take + 1;
    }

    public static int TotalPages(int totalInDatabase, int take)
    {
        return
            totalInDatabase % take != 0 ?
            totalInDatabase / take + 1 :
            totalInDatabase / take;
    }
}
