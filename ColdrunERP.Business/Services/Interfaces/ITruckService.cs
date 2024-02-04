using ColdrunERP.Business.Dtos;
using ColdrunERP.Core.Enums;
using ColdrunERP.Core.Interfaces.Filters;

namespace ColdrunERP.Business.Services.Interfaces
{
    public interface ITruckService
    {
        Task<IEnumerable<Truck>> GetAllTrucksAsync();
        Task<IEnumerable<Truck>> GetFilteredTrucksAsync(ITruckFilter filter);
        Task<Truck> GetTruckByIdAsync(int id);
        Task AddTruckAsync(Truck truck);
        Task UpdateTruckAsync(Truck truck);
        Task DeleteTruckAsync(int id);
        Task<bool> UpdateTruckStatusAsync(int truckId, TruckStatus newStatus);
    }
}
