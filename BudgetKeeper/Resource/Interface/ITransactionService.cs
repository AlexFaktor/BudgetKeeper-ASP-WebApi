using BudgetKeeper.Core.TransactionDtos;
using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Resource.Interface
{
    public interface ITransactionService
    {
        Task<TransactionDto?> AddAsync(TransactionCreateDto record);
        Task<List<TransactionDto>> GetAllAsync();
        Task<TransactionDto?> GetAsync(Guid id);
        Task<List<TransactionDto>> GetAsync(DateTime from, DateTime to);
        Task<List<TransactionDto>> GetAsync(DateTime day);
        Task<TransactionDto?> UpdateAsync(Guid id, TransactionUpdateDto record);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Transaction record);
    }
}
