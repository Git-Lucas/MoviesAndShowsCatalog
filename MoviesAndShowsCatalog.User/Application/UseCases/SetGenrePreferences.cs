using MoviesAndShowsCatalog.User.Domain.Data;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.DTOs;
using MoviesAndShowsCatalog.User.Domain.UseCases.GenrePreferences.Interfaces;

namespace MoviesAndShowsCatalog.User.Application.UseCases;

public class SetGenrePreferences(IUserData userData) : ISetGenrePreferences
{
    public async Task ExecuteAsync(SetGenrePreferencesRequest setGenrePreferencesRequest)
    {
        Domain.Entities.User user = await userData.GetByIdAsync(setGenrePreferencesRequest.UserId);
        user.SetGenrePreferences(setGenrePreferencesRequest.GenresCodes);

        await userData.UpdateAsync(user);
    }
}
