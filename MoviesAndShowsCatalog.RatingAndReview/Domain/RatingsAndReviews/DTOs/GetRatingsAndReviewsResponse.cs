namespace MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;

public record GetRatingsAndReviewsResponse
{
    public int VisualProductionId { get; set; }
    public float AverageRating { get; set; }
    public List<RatingAndReviewResponse> RatingsAndReviews { get; set; } = [];

    public GetRatingsAndReviewsResponse(int visualProducionId, IEnumerable<Entities.RatingAndReview> ratingsAndReviews)
    {
        VisualProductionId = visualProducionId;
        RatingsAndReviews = MapDomainObjectToDTO(ratingsAndReviews);
        AverageRating = CalculateAverageRating();
    }

    private List<RatingAndReviewResponse> MapDomainObjectToDTO(IEnumerable<Entities.RatingAndReview> ratingsAndReviews)
    {
        List<RatingAndReviewResponse> result = [];

        foreach (Entities.RatingAndReview ratingAndReview in ratingsAndReviews)
        {
            result.Add(new RatingAndReviewResponse()
            {
                Id = ratingAndReview.Id,
                Rating = ratingAndReview.Rating.Value,
                Review = ratingAndReview.Review
            });
        }

        return result;
    }
    private float CalculateAverageRating()
    {
        return RatingsAndReviews.Select(x => x.Rating).Average();
    }
}
