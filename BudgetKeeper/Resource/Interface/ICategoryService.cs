using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        Task<Category?> AddAsync(CategoryCreateDto categoryDto);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetAsync(Guid id);
        Task<Category?> GetAsync(string name);
        Task<Category?> UpdateAsync(Guid id, CategoryUpdateDto categoryDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Category record);
    }
}
