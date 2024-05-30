using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Transaction;

namespace BudgetKeeper.Resource.Interface
{
    public interface ITransactionService
    {
        Transaction? Add(TransactionCreateDto record);
        List<Transaction> GetAll();
        Transaction? Get(Guid id);
        List<Transaction> Get(DateTime from, DateTime to);
        List<Transaction> Get(DateTime day);
        Transaction? Update(Guid id,TransactionUpdateDto record);
        bool Delete(Guid id);
        bool Delete(Transaction record);
    }
}
