using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Resource.Interface
{
    public interface ITransactionService
    {
        bool Add(TransactionRecord record);
        List<TransactionRecord> GetAll();
        TransactionRecord? Get(Guid id);
        List<TransactionRecord> Get(DateTime from, DateTime to);
        List<TransactionRecord> Get(DateTime day);
        bool Update(TransactionRecord record);
        bool Delete(Guid id);
        bool Delete(TransactionRecord record);
    }
}
