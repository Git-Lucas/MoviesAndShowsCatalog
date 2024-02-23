namespace MoviesAndShowsCatalog.RatingAndReview.Domain.ValueObjects;

public class Rating
{
    public float Value { get; private set; }

    public Rating() { }

    public Rating(float rating)
    {
        if (rating >= 0 && rating <= 5)
        {
            Value = rating;
        }
        else
        {
            throw new Exception($"The {nameof(Rating)} must be between 0 and 5.");
        }
    }
}
