using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.Models;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class GetRatingsAndReviewsByVisualProductionId(
    IRatingAndReviewData ratingAndReviewData, 
    IVisualProductionData visualProductionData) : IGetRatingsAndReviewsByVisualProductionId
{
    public async Task<GetRatingsAndReviewsResponse> ExecuteAsync(int visualProductionId)
    {
        VisualProduction visualProduction = await visualProductionData.GetByIdAsync(visualProductionId);
        
        IEnumerable<Domain.Models.RatingAndReview> ratingsAndReviews = ratingAndReviewData.GetAllByVisualProductionId(visualProductionId);

        GetRatingsAndReviewsResponse getRatingsAndReviewsResponse = new(visualProduction.Id, ratingsAndReviews);

        return getRatingsAndReviewsResponse;
    }
}
