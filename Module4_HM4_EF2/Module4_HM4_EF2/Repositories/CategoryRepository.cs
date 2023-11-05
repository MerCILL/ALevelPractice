using Microsoft.EntityFrameworkCore;
using Module4_HM4_EF2.DbData.Context;
using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.Repositories.Abstractions;

namespace Module4_HM4_EF2.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Category item)
        {
            await _dbContext.Categories.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCategory = await GetByIdAsync(id);
            if (existingCategory == null) return false;

            _dbContext.Remove(existingCategory);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(id);
            return existingCategory;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryName == name);
            return existingCategory;
        }

        public async Task<bool> UpdateAsync(Category item)
        {
            var existingCategory = await GetByIdAsync(item.Id);
            if (existingCategory == null) return false;

            existingCategory.CategoryName = item.CategoryName;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
