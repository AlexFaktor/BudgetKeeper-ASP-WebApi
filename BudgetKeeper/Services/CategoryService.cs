using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;
using BudgetKeeper.Resource.Interface;

namespace BudgetKeeper.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BudgetDbContext _db;

        public CategoryService(BudgetDbContext db)
        { 
            _db = db;
        }

        public Category? Add(CategoryCreateDto categoryDto)
        {
            if (Get(categoryDto.Name) != null)
                return null;

            var category = new Category
            {
                Name = categoryDto.Name
            };

            _db.Categories.Add(category);
            _db.SaveChanges();
            return Get(category.Name);
        }

        public List<Category> GetAll() => _db.Categories.ToList();
        public Category? Get(Guid id) => _db.Categories.FirstOrDefault(c => c.Id == id);
        public Category? Get(string name) => _db.Categories.FirstOrDefault(c => c.Name == name);

        public Category? Update(Guid id, CategoryUpdateDto categoryDto)
        {
            var existingRecord = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (existingRecord != null)
            {
                existingRecord.Name = categoryDto.Name;
                _db.SaveChanges();
                return existingRecord;
            }
            return null;
        }

        public bool Delete(Guid id)
        {
            var record = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (record != null)
            {
                _db.Categories.Remove(record);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Category record)
        {
            return Delete(record.Id);
        }
    }
}
