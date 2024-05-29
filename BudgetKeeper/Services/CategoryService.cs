using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
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
        
        public bool Add(CategoryRecord record)
        { 
            if(Get(record.Name) != null)
                return false;

            _db.Categories.Add(record);
            _db.SaveChanges();
            return true;
        }

        public List<CategoryRecord> GetAll() => _db.Categories.ToList();
        public CategoryRecord? Get(Guid id) => _db.Categories.FirstOrDefault(c => c.Id == id);
        public CategoryRecord? Get(string name) => _db.Categories.FirstOrDefault(c => c.Name == name);

        public bool Update(CategoryRecord record)
        {
            if (Get(record.Name) != null)
                return false;

            var existingRecord = _db.Categories.FirstOrDefault(c => c.Id == record.Id);
            if (existingRecord != null)
            {
                existingRecord.Name = existingRecord.Name;
                _db.SaveChanges();
                return true;
            }
            return false;
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
