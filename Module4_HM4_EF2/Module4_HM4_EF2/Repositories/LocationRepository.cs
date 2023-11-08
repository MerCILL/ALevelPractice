using Microsoft.EntityFrameworkCore;
using Module4_HM4_EF2.DbData.Context;
using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories.Abstractions;

namespace Module4_HM4_EF2.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Location item)
        {
            await _dbContext.Locations.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingLocation = await GetByIdAsync(id);
            if (existingLocation == null) return false;

            _dbContext.Remove(existingLocation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _dbContext.Locations.AsNoTracking().ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            var existingLocation = await _dbContext.Locations.FindAsync(id);
            return existingLocation;
        }

        public async Task<Location> GetByNameAsync(string name)
        {
            var existingLocation = await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationName == name);
            return existingLocation;
        }

        public async Task<bool> UpdateAsync(Location item)
        {
            var existingLocation = await GetByIdAsync(item.Id);
            if (GetByIdAsync(item.Id) == null) return false;
            
            existingLocation.LocationName = item.LocationName;
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
