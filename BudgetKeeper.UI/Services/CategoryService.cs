using BudgetKeeper.Models.DTO.CategoryDtos;

namespace BudgetKeeper.UI.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Category/all");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<CategoryDto>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return new List<CategoryDto>();
            }
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Category/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching category with ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Category", categoryDto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating category: {ex.Message}");
                return null;
            }
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, CategoryUpdateDto categoryDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Category/{id}", categoryDto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category with ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Category/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category with ID {id}: {ex.Message}");
            }
        }
    }
}
