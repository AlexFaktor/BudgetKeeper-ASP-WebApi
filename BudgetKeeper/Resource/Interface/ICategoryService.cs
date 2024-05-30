using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        CategoryRecord? Add(CategoryCreateDto record);
        List<CategoryRecord> GetAll();
        CategoryRecord? Get(Guid id);
        CategoryRecord? Get(string name);
        CategoryRecord? Update(Guid id, CategoryUpdateDto record);
        bool Delete(Guid id);

    }
}
