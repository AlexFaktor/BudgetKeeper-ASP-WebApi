using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Transaction;

namespace BudgetKeeper.Resource.Interface
{
    public interface ITransactionService
    {
        Task<Transaction?> AddAsync(TransactionCreateDto record);
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetAsync(Guid id);
        Task<List<Transaction>> GetAsync(DateTime from, DateTime to);
        Task<List<Transaction>> GetAsync(DateTime day);
        Task<Transaction?> UpdateAsync(Guid id,TransactionUpdateDto record);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Transaction record);
    }
}
