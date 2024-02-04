using ColdrunERP.Business.Dtos;
using ColdrunERP.Business.Services.Interfaces;
using ColdrunERP.Core;
using ColdrunERP.Core.Enums;
using ColdrunERP.Core.Interfaces.Filters;
using ColdrunERP.Data.Repositories.Interfaces;

namespace ColdrunERP.Business.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<Truck>> GetAllTrucksAsync()
        {
            var trucks = await _truckRepository.GetAllTrucksAsync();
            return trucks.Select(t => t.ToDto());
        }

        public async Task<IEnumerable<Truck>> GetFilteredTrucksAsync(ITruckFilter filter)
        {
            var trucks = await _truckRepository.GetFilteredTrucksAsync(filter);
            return trucks.Select(t => t.ToDto());
        }

        public async Task<Truck> GetTruckByIdAsync(int id)
        {
            var truck = await _truckRepository.GetTruckByIdAsync(id);
            return truck?.ToDto();
        }

        public async Task AddTruckAsync(Truck truck)
        {
             var existingTruck = await _truckRepository.GetTruckByIdAsync(truck.Id);

            if (existingTruck is not null) 
            {
                throw new Exception("Truck with given code already exist.");
            }

            await _truckRepository.AddTruckAsync(truck.ToEntity());
        }

        public async Task UpdateTruckAsync(Truck truck)
        {
            await _truckRepository.UpdateTruckAsync(truck.ToEntity());
        }

        public async Task DeleteTruckAsync(int id)
        {
            await _truckRepository.DeleteTruckAsync(id);
        }

        public async Task<bool> UpdateTruckStatusAsync(int truckId, TruckStatus newStatus)
        {
            var truck = await _truckRepository.GetTruckByIdAsync(truckId);

            if (truck == null)
            {
                return false;
            }

            if (!IsValidStatusTransition(truck.Status, newStatus))
            {
                return false;
            }

            truck.Status = newStatus;
            await _truckRepository.UpdateTruckAsync(truck);

            return true;
        }

        private bool IsValidStatusTransition(TruckStatus currentStatus, TruckStatus newStatus)
        {
            switch (newStatus)
            {
                case TruckStatus.OutOfService:
                    return true;
                case TruckStatus.Loading:
                case TruckStatus.ToJob:
                case TruckStatus.AtJob:
                case TruckStatus.Returning:
                    return currentStatus == TruckStatus.OutOfService || IsStatusOrderValid(currentStatus, newStatus);
                default:
                    return false;
            }
        }

        private bool IsStatusOrderValid(TruckStatus currentStatus, TruckStatus newStatus)
        {
            return currentStatus switch
            {
                TruckStatus.Loading => newStatus == TruckStatus.ToJob,
                TruckStatus.ToJob => newStatus == TruckStatus.AtJob,
                TruckStatus.AtJob => newStatus == TruckStatus.Returning,
                TruckStatus.Returning => newStatus == TruckStatus.Loading,
                _ => false,
            };
        }
    }
}
