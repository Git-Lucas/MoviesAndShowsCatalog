﻿using MoviesAndShowsCatalog.MovieAndShow.Domain.Models;

namespace MoviesAndShowsCatalog.MovieAndShow.Domain.Data;

public interface IVisualProductionData
{
    Task<int> CreateAsync(VisualProduction visualProduction);
    Task<List<VisualProduction>> GetAllAsync(int skip, int take);
    Task<VisualProduction?> GetByIdAsync(int visualProductionId);
    Task DeleteAsync(VisualProduction visualProduction);
    Task<int> CountAsync();
}
