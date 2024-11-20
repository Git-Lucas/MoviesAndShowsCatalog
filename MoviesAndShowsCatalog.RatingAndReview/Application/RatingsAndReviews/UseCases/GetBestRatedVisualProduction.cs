using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.UseCases;

public class GetBestRatedVisualProduction(IRatingAndReviewRepository repository)
{
    private readonly IRatingAndReviewRepository _repository = repository;

    public GetRatingsAndReviewsResponse Execute()
    {
        IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> ratingsAndReviews = _repository.GetAll();
        GetRatingsAndReviewsResponse dtoResponse = ratingsAndReviews
            .GroupBy(x => x.VisualProductionId)
            .Select(x => new GetRatingsAndReviewsResponse(x.Key, x))
            .OrderByDescending(x => x.AverageRating)
            .FirstOrDefault()
            ?? throw new InvalidOperationException("Unable to search for the best rated");

        return dtoResponse;
    }
}
