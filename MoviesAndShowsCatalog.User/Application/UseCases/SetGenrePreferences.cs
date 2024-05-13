using MoviesAndShowsCatalog.User.Domain.Users.Data;
using MoviesAndShowsCatalog.User.Domain.Users.DTOs;
using MoviesAndShowsCatalog.User.Domain.Users.UseCases;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class SetGenrePreferences(IUserRepository userData) : ISetGenrePreferencesUseCase
{
    public async Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest)
    {
        Domain.Users.Entities.User user = await userData.GetByIdAsync(setGenrePreferencesRequest.UserId);
        user.SetGenrePreferences(setGenrePreferencesRequest.GenresCodes);

        await userData.UpdateAsync(user);
    }
}
