using BudgetKeeper.Core.CategoryDtos;
using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Resource.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDto?> AddAsync(CategoryCreateDto categoryDto);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetAsync(Guid id);
        Task<CategoryDto?> GetAsync(string name);
        Task<CategoryDto?> UpdateAsync(Guid id, CategoryUpdateDto categoryDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Category record);
    }
}
