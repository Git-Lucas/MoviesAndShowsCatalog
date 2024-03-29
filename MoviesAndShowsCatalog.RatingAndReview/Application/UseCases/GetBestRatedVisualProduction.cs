﻿using MoviesAndShowsCatalog.RatingAndReview.Domain.Data;
using MoviesAndShowsCatalog.RatingAndReview.Domain.DTOs;
using MoviesAndShowsCatalog.RatingAndReview.Domain.UseCases;

namespace MoviesAndShowsCatalog.RatingAndReview.Application.UseCases;

public class GetBestRatedVisualProduction(IRatingAndReviewData ratingAndReviewData) : IGetBestRatedVisualProduction
{
    public GetRatingsAndReviewsResponse Execute()
    {
        IEnumerable<Domain.Entities.RatingAndReview> ratingsAndReviews = ratingAndReviewData.GetAll();
        GetRatingsAndReviewsResponse getRatingsAndReviewsResponse = ratingsAndReviews
            .GroupBy(x => x.VisualProductionId)
            .Select(x => new GetRatingsAndReviewsResponse(x.Key, x))
            .OrderByDescending(x => x.AverageRating)
            .FirstOrDefault()
            ?? throw new Exception("Unable to search for the best rated");

        return getRatingsAndReviewsResponse;
    }
}
