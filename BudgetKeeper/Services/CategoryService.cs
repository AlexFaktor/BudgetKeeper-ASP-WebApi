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

        public CategoryRecord? Add(CategoryCreateDto categoryDto)
        {
            if (Get(categoryDto.Name) != null)
                return null;

            var category = new CategoryRecord
            {
                Name = categoryDto.Name
            };

            _db.Categories.Add(category);
            _db.SaveChanges();
            return Get(category.Name);
        }

        public List<CategoryRecord> GetAll() => _db.Categories.ToList();
        public CategoryRecord? Get(Guid id) => _db.Categories.FirstOrDefault(c => c.Id == id);
        public CategoryRecord? Get(string name) => _db.Categories.FirstOrDefault(c => c.Name == name);

        public CategoryRecord? Update(Guid id, CategoryUpdateDto categoryDto)
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

        public bool Delete(CategoryRecord record)
        {
            return Delete(record.Id);
        }
    }
}
