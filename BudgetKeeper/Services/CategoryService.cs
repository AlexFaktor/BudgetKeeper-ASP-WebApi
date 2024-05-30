using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.CategoryDtos;
using BudgetKeeper.Resource.Interface;
using Microsoft.EntityFrameworkCore;

namespace BudgetKeeper.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BudgetDbContext _db;

        public CategoryService(BudgetDbContext db)
        {
            _db = db;
        }

        public async Task<CategoryDto?> AddAsync(CategoryCreateDto categoryDto)
        {
            if (categoryDto.Name is null)
                return null;

            if (await GetAsync(categoryDto.Name) != null) // If a category with this name exists, return null
                return null;

            var category = new Category
            {
                Name = categoryDto.Name
            };

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return await GetAsync(category.Name);
        }

        public async Task<List<CategoryDto>> GetAllAsync() => await _db.Categories.Select(c => new CategoryDto(c)).ToListAsync();

        public async Task<CategoryDto?> GetAsync(Guid id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category == null ? null : new CategoryDto(category);
        }

        public async Task<CategoryDto?> GetAsync(string name)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            return category == null ? null : new CategoryDto { Id = category.Id, Name = category.Name };
        }
        public async Task<CategoryDto?> UpdateAsync(Guid id, CategoryUpdateDto categoryDto)
        {
            if (categoryDto.Name is null)
                return null;

            if (await GetAsync(categoryDto.Name) != null) // If a category with this name exists, return null
                return null;

            var existingRecord = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingRecord != null)
            {
                existingRecord.Name = categoryDto.Name;
                await _db.SaveChangesAsync();
                return new CategoryDto(existingRecord);
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var record = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (record != null)
            {
                if (await _db.Transactions.AnyAsync(t => t.CategoryId == id))
                    return false;

                _db.Categories.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Category record)
        {
            return await DeleteAsync(record.Id);
        }
    }

}
