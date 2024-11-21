using MoviesAndShowsCatalog.User.Application.Users.Data;

namespace MoviesAndShowsCatalog.User.Application.Users.UseCases;

public class SetGenrePreferences(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest)
    {
        Domain.Users.Entities.User user = await _repository.GetByIdAsync(setGenrePreferencesRequest.UserId);
        user.SetGenrePreferences(setGenrePreferencesRequest.GenresCodes);

        await _repository.UpdateAsync(user);
    }
}

public record SetGenrePreferencesRequest(int UserId, int[] GenresCodes)
{
}
