using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.RatingsAndReviews.UseCases;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class GetRatingsAndReviewsByVisualProductionId(
    IRatingAndReviewData ratingAndReviewData, 
    IVisualProductionData visualProductionData) : IGetRatingsAndReviewsByVisualProductionId
{
    public async Task<GetRatingsAndReviewsResponse> ExecuteAsync(int visualProductionId)
    {
        VisualProduction visualProduction = await visualProductionData.GetByIdAsync(visualProductionId);
        
        IEnumerable<Domain.RatingsAndReviews.Entities.RatingAndReview> ratingsAndReviews = ratingAndReviewData.GetAllByVisualProductionId(visualProductionId);

        GetRatingsAndReviewsResponse getRatingsAndReviewsResponse = new(visualProduction.Id, ratingsAndReviews);

        return getRatingsAndReviewsResponse;
    }
}
