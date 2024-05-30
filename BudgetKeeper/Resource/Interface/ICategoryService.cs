using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        Category? Add(CategoryCreateDto record);
        List<Category> GetAll();
        Category? Get(Guid id);
        Category? Get(string name);
        Category? Update(Guid id, CategoryUpdateDto record);
        bool Delete(Guid id);

    }
}
