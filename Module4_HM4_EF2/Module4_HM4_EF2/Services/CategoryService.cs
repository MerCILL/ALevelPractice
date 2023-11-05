using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories;
using Module4_HM4_EF2.Repositories.Abstractions;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateAsync(string name)
        {
            var existingCategory = await _categoryRepository.GetByNameAsync(name);
            if (existingCategory != null) return false;

            var newCategory = new Category { CategoryName = name};
            await _categoryRepository.CreateAsync(newCategory);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(category => new CategoryDTO { Id = category.Id, CategoryName = category.CategoryName });
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory != null) return new CategoryDTO { Id = existingCategory.Id, CategoryName = existingCategory.CategoryName };
            return null;
        }

        public async Task<CategoryDTO> GetByNameAsync(string name)
        {
            var existingCategory = await _categoryRepository.GetByNameAsync(name);

            if (existingCategory == null) return null;

            return new CategoryDTO { Id = existingCategory.Id, CategoryName = existingCategory.CategoryName };
        }

        public async Task<bool> UpdateAsync(CategoryDTO item)
        {
            var checkName = await _categoryRepository.GetByNameAsync(item.CategoryName);
            if (checkName != null) return false;

            var category = new Category { Id = item.Id, CategoryName = item.CategoryName };
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
