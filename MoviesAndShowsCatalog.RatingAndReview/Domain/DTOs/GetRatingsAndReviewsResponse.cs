namespace MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;

public record GetRatingsAndReviewsResponse
{
    public int VisualProductionId { get; set; }
    public float AverageRating { get; set; }
    public List<RatingAndReviewResponse> RatingsAndReviews { get; set; } = [];

    public GetRatingsAndReviewsResponse(int visualProducionId, IEnumerable<Models.RatingAndReview> ratingsAndReviews)
    {
        VisualProductionId = visualProducionId;
        RatingsAndReviews = MapDomainObjectToDTO(ratingsAndReviews);
        AverageRating = CalculateAverageRating();
    }

    private List<RatingAndReviewResponse> MapDomainObjectToDTO(IEnumerable<Models.RatingAndReview> ratingsAndReviews)
    {
        List<RatingAndReviewResponse> result = [];

        foreach (Models.RatingAndReview ratingAndReview in ratingsAndReviews)
        {
            result.Add(new RatingAndReviewResponse()
            {
                Id = ratingAndReview.Id,
                Rating = ratingAndReview.Rating,
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
