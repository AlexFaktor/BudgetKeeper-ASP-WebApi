using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        bool Add(CategoryCreateDto record);
        List<CategoryRecord> GetAll();
        CategoryRecord? Get(Guid id);
        CategoryRecord? Get(string name);
        bool Update(Guid id, CategoryUpdateDto record);
        bool Delete(Guid id);

    }
}
