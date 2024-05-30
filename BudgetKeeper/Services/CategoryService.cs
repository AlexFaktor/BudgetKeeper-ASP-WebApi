using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;
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

        public async Task<Category?> AddAsync(CategoryCreateDto categoryDto)
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

        public async Task<List<Category>> GetAllAsync() => await _db.Categories.ToListAsync();

        public async Task<Category?> GetAsync(Guid id) => await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Category?> GetAsync(string name) => await _db.Categories.FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());

        public async Task<Category?> UpdateAsync(Guid id, CategoryUpdateDto categoryDto)
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
                return existingRecord;
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
