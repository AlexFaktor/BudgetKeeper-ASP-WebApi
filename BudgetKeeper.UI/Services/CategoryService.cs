using BudgetKeeper.Core.CategoryDtos;

namespace BudgetKeeper.UI.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReportService> _logger;

        public CategoryService(HttpClient httpClient, ILogger<ReportService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<CategoryDto>?> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Category/all");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<CategoryDto>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching categories");
                return new List<CategoryDto>();
            }
        }

        public async Task<CategoryDto?> GetAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Category/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching category with ID {CategoryId}", id);
                return null;
            }
        }

        public async Task<CategoryDto?> CreateAsync(CategoryCreateDto categoryDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Category", categoryDto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                return null;
            }
        }

        public async Task<CategoryDto?> UpdateAsync(Guid id, CategoryUpdateDto categoryDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Category/{id}", categoryDto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category with ID {CategoryId}", id);
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
                _logger.LogError(ex, "Error deleting category with ID {CategoryId}", id);
            }
        }
    }
}
