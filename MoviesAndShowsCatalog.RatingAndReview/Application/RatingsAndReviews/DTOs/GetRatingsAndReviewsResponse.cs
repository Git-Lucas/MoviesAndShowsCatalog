namespace MoviesAndShowsCatalog.RatingAndReview.Application.RatingsAndReviews.DTOs;

public record GetRatingsAndReviewsResponse
{
    public int VisualProductionId { get; }
    public float AverageRating { get; }
    public IEnumerable<RatingAndReviewResponse> RatingsAndReviews { get; } = [];

    public GetRatingsAndReviewsResponse(int visualProducionId, IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> ratingsAndReviews)
    {
        VisualProductionId = visualProducionId;
        RatingsAndReviews = ratingsAndReviews.Select(x => x.ToDtoResponse());
        AverageRating = CalculateAverageRating();
    }

    private float CalculateAverageRating()
    {
        return RatingsAndReviews.Select(x => x.Rating).Average();
    }
}

public record RatingAndReviewResponse(int Id, float Rating, string Review)
{
}