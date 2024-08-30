using BudgetKeeper.Core.BudgetReportDtos;

namespace BudgetKeeper.UI.Services
{
    public class ReportService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReportService> _logger;

        public ReportService(HttpClient httpClient, ILogger<ReportService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<BudgetReportDto?> GetDayReportAsync(DateTime day)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/report/day?day={day:yyyy-MM-dd}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<BudgetReportDto>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error fetching day report: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                return null;
            }
        }

        public async Task<BudgetReportDto?> GetPeriodReportAsync(DateTime from, DateTime to)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/report/period?from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<BudgetReportDto>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error fetching period report: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}
