using Microsoft.AspNetCore.Mvc;
using MoviesAndShowsCatalog.MovieAndShow.Application.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;
namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;

public class GetAllVisualProductions(IVisualProductionRepository repository)
{
    private readonly IVisualProductionRepository _repository = repository;

    public async Task<GetPagedResponse<VisualProductionResponse>> ExecuteAsync(GetAllVisualProductionsRequest dtoRequest)
    {
        IEnumerable<VisualProduction> visualProductionsFromDatabase = await _repository.GetAllAsync(dtoRequest.Skip, dtoRequest.Take);

        IEnumerable<VisualProductionResponse> visualProductionsResponse = visualProductionsFromDatabase.Select(x => x.ToDto());

        int countVisualProductionInDatabase = await _repository.CountAsync();
        GetPagedResponse<VisualProductionResponse> response = new(countVisualProductionInDatabase,
                                                                  dtoRequest.Skip,
                                                                  dtoRequest.Take,
                                                                  visualProductionsResponse);

        return response;
    }
}

public record GetAllVisualProductionsRequest(int Skip, int Take)
{
}

public record VisualProductionResponse(int Id, string Title, string Genre, int ReleaseYear)
{
}