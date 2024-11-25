using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.DTOs;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Enums;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;

public class CreateVisualProduction : IVisualProductionCreated
{
    private readonly IVisualProductionRepository _repository;

    public event Action<VisualProduction> OnVisualProductionCreated;

    public CreateVisualProduction(IVisualProductionRepository repository, VisualProductionCreated visualProductionCreated)
    {
        _repository = repository;
        OnVisualProductionCreated += visualProductionCreated.OnVisualProductionCreatedPublishOnExchange;
    }

    public async Task<int> ExecuteAsync(CreateVisualProductionRequest dtoRequest)
    {
        VisualProduction entity = dtoRequest.ToEntity();

        await _repository.CreateAsync(entity);

        OnVisualProductionCreated.Invoke(entity);

        return entity.Id;
    }
}

public record CreateVisualProductionRequest(string Title, Genre Genre, int ReleaseYear)
{
}