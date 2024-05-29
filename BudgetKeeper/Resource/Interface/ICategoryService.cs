using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        bool Add(CategoryRecord record);
        List<CategoryRecord> GetAll();
        CategoryRecord? Get(Guid id);
        CategoryRecord? Get(string name);
        bool Update(CategoryRecord record);
        bool Delete(Guid id);
        bool Delete(CategoryRecord record);
    }
}
