using Microsoft.EntityFrameworkCore;
using Module4_HM4_EF2.DbData.Context;
using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.Repositories.Abstractions;

namespace Module4_HM4_EF2.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Pet item)
        {
            await _dbContext.Pets.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingPet = GetByIdAsync(id);
            if(existingPet == null) return false;

            _dbContext.Remove(existingPet);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _dbContext.Pets
              .Include(p => p.Breed)
              .Include(p => p.Category)
              .Include(p => p.Location)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            var existingPet = await _dbContext.Pets
            .Include(p => p.Breed)
            .Include(p => p.Category)
            .Include(p => p.Location)
            .FirstOrDefaultAsync(p => p.Id == id);
            return existingPet;
        }

        public async Task<bool> UpdateAsync(Pet item)
        {
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
