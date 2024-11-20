using MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.Data;
using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

namespace MoviesAndShowsCatalog.MovieAndShow.Application.VisualProductions.UseCases;

public class GetVisualProductionById(IVisualProductionRepository repository)
{
    private readonly IVisualProductionRepository _repository = repository;

    public async Task<VisualProduction> ExecuteAsync(GetVisualProductionByIdRequest dtoRequest)
    {
        VisualProduction visualProduction = await _repository.GetByIdAsync(dtoRequest.VisualProductionId);

        return visualProduction;
    }
}

public record GetVisualProductionByIdRequest(int VisualProductionId)
{
}