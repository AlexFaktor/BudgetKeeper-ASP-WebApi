using BudgetKeeper.Models.DTO.TransactionDtos;

namespace BudgetKeeper.UI.Services
{
    public class TransactionService
    {
        private readonly HttpClient _httpClient;

        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TransactionDto>> GetAllAsync()
        {
            try
            {
                var transactions = await _httpClient.GetFromJsonAsync<List<TransactionDto>>("api/transaction/all");
                return transactions ?? new List<TransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching all transactions: {ex.Message}");
                return new List<TransactionDto>();
            }
        }

        public async Task<TransactionDto> GetAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid transaction ID");
                }

                return await _httpClient.GetFromJsonAsync<TransactionDto>($"api/transaction/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching transaction with ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<TransactionDto>> GetByPeriodAsync(DateTime from, DateTime to)
        {
            try
            {
                if (from > to)
                {
                    throw new ArgumentException("The 'from' date must be earlier than the 'to' date");
                }

                var transactions = await _httpClient.GetFromJsonAsync<List<TransactionDto>>($"api/transaction/period?from={from:O}&to={to:O}");
                return transactions ?? new List<TransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching transactions by period: {ex.Message}");
                return new List<TransactionDto>();
            }
        }

        public async Task<List<TransactionDto>> GetByDayAsync(DateTime day)
        {
            try
            {
                var transactions = await _httpClient.GetFromJsonAsync<List<TransactionDto>>($"api/transaction/day?day={day:O}");
                return transactions ?? new List<TransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching transactions for day {day:O}: {ex.Message}");
                return new List<TransactionDto>();
            }
        }

        public async Task<TransactionDto> CreateAsync(TransactionCreateDto transactionDto)
        {
            try
            {
                if (transactionDto == null)
                {
                    throw new ArgumentNullException(nameof(transactionDto), "Transaction data must not be null");
                }

                var response = await _httpClient.PostAsJsonAsync("api/transaction", transactionDto);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating transaction: {ex.Message}");
                throw;
            }
        }

        public async Task<TransactionDto> UpdateAsync(Guid id, TransactionUpdateDto transactionDto)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid transaction ID");
                }
                if (transactionDto == null)
                {
                    throw new ArgumentNullException(nameof(transactionDto), "Transaction data must not be null");
                }

                var response = await _httpClient.PutAsJsonAsync($"api/transaction/{id}", transactionDto);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating transaction with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid transaction ID");
                }

                var response = await _httpClient.DeleteAsync($"api/transaction/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting transaction with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
