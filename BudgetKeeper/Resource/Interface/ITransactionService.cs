using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Transaction;

namespace BudgetKeeper.Resource.Interface
{
    public interface ITransactionService
    {
        TransactionRecord? Add(TransactionCreateDto record);
        List<TransactionRecord> GetAll();
        TransactionRecord? Get(Guid id);
        List<TransactionRecord> Get(DateTime from, DateTime to);
        List<TransactionRecord> Get(DateTime day);
        TransactionRecord? Update(Guid id,TransactionUpdateDto record);
        bool Delete(Guid id);
        bool Delete(TransactionRecord record);
    }
}
