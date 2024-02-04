using ColdrunERP.Core.Interfaces.Filters;
using ColdrunERP.Data.EntityModels;

namespace ColdrunERP.Data.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        Task<IEnumerable<TruckEntity>> GetAllTrucksAsync();
        Task<IEnumerable<TruckEntity>> GetFilteredTrucksAsync(ITruckFilter filter);
        Task<TruckEntity> GetTruckByIdAsync(int id);
        Task AddTruckAsync(TruckEntity truck);
        Task UpdateTruckAsync(TruckEntity truck);
        Task DeleteTruckAsync(int coidde);
    }
}
