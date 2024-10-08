﻿using MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.DTOs;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.VisualProductions.Entities;

public static class VisualProductionExtensions
{
    public static VisualProduction ToEntity(this CreateVisualProductionRequest dto)
    {
        return new VisualProduction(dto.Title, dto.Genre, dto.ReleaseYear);
    }

    public static VisualProductionResponse ToDto(this VisualProduction entity)
    {
        return new VisualProductionResponse(entity.Id,
                                            entity.Title,
                                            entity.Genre.ToString(),
                                            entity.ReleaseYear);
    }
}
