using ColdrunERP.Core.Interfaces.Filters;
using ColdrunERP.Data.Contexts;
using ColdrunERP.Data.EntityModels;
using ColdrunERP.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ColdrunERP.Data.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckDbContext _dbContext;

        public TruckRepository(TruckDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TruckEntity>> GetAllTrucksAsync()
        {
            return await _dbContext.Trucks.ToListAsync();
        }

        public async Task<IEnumerable<TruckEntity>> GetFilteredTrucksAsync(ITruckFilter filter)
        {
            var query = _dbContext.Trucks.AsQueryable();

            if (filter.Code != null)
                query = query.Where(t => t.Code.Contains(filter.Code, StringComparison.OrdinalIgnoreCase));

            if (filter.Name != null)
                query = query.Where(t => t.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

            if (filter.Status != null)
                query = query.Where(t => t.Status == filter.Status);

            if (filter.Description != null)
                query = query.Where(t => t.Description.Contains(filter.Description, StringComparison.OrdinalIgnoreCase));

            return await query.ToListAsync();
        }

        public async Task<TruckEntity> GetTruckByIdAsync(int id)
        {
            return await _dbContext.Trucks.FindAsync(id);
        }

        public async Task AddTruckAsync(TruckEntity truck)
        {
            _dbContext.Trucks.Add(truck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTruckAsync(TruckEntity truck)
        {
            _dbContext.Entry(truck).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTruckAsync(int id)
        {
            var truck = await _dbContext.Trucks.FindAsync(id);
            if (truck != null)
            {
                _dbContext.Trucks.Remove(truck);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
