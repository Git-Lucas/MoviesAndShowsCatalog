using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Events;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;

public class DeleteVisualProduction : IVisualProductionDeleted
{
    private readonly IVisualProductionRepository _repository;

    public event Action<int> OnVisualProductionDeleted;

    public DeleteVisualProduction(IVisualProductionRepository repository, VisualProductionDeleted visualProductionDeleted)
    {
        _repository = repository;
        OnVisualProductionDeleted += visualProductionDeleted.OnVisualProductionDeletedPublishOnExchange;
    }

    public async Task ExecuteAsync(DeleteVisualProductionRequest dtoRequest)
    {
        VisualProduction visualProduction = await _repository.GetByIdAsync(dtoRequest.VisualProductionId);

        await _repository.DeleteAsync(visualProduction);

        OnVisualProductionDeleted.Invoke(dtoRequest.VisualProductionId);
    }
}

public record DeleteVisualProductionRequest(int VisualProductionId)
{
}