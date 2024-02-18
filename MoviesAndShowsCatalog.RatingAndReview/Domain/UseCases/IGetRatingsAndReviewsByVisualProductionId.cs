namespace MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

public interface IGetRatingsAndReviewsByVisualProductionId
{
    Task<IEnumerable<Models.RatingAndReview>> ExecuteAsync(int visualProductionId);
}
