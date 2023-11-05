using Microsoft.EntityFrameworkCore;
using Module4_HM4_EF2.DbData.Context;
using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.Repositories.Abstractions;

namespace Module4_HM4_EF2.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BreedRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Breed item)
        {
            await _dbContext.Breeds.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingBrred = await GetByIdAsync(id);
            if (existingBrred == null) return false;

            _dbContext.Remove(existingBrred);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Breed>> GetAllAsync()
        {
            return await _dbContext.Breeds
                .Include(b => b.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Breed> GetByIdAsync(int id)
        {
            var existingBreed = await _dbContext.Breeds.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
            return existingBreed;
        }

        public async Task<Breed> GetByNameAsync(string name)
        {
            var existingBreed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.BreedName == name);
            return existingBreed;
        }

        public async Task<bool> UpdateAsync(Breed item)
        {       
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
