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
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/Category/all");
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/Category/{id}");
        }

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Category", categoryDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CategoryDto>();
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, CategoryUpdateDto categoryDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Category/{id}", categoryDto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CategoryDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Category/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
