using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Resource.Interface;

namespace BudgetKeeper.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BudgetDbContext _db;

        public TransactionService(BudgetDbContext db)
        {
            _db = db;
        }

        public bool Add(TransactionRecord record)
        {
            _db.Transactions.Add(record);
            _db.SaveChanges();
            return true;
        }

        public List<TransactionRecord> GetAll() => _db.Transactions.ToList();
        public TransactionRecord? Get(Guid id) => _db.Transactions.FirstOrDefault(c => c.Id == id);
        public List<TransactionRecord> Get(DateTime from, DateTime to) => _db.Transactions.Where(t => t.Time >= from && t.Time <= to).ToList();

        public List<TransactionRecord> Get(DateTime day)
        {
            DateTime dayStart = day.Date; 
            DateTime dayEnd = day.Date.AddDays(1).AddTicks(-1);

            return _db.Transactions
                      .Where(t => t.Time >= dayStart && t.Time <= dayEnd)
                      .ToList();
        }

        public bool Update(TransactionRecord record)
        {
            var existingRecord = _db.Transactions.FirstOrDefault(c => c.Id == record.Id);
            if (existingRecord != null)
            {
                existingRecord.Name = existingRecord.Name;
                existingRecord.Income = existingRecord.Income;
                existingRecord.Time = existingRecord.Time;
                existingRecord.Category = existingRecord.Category;
                existingRecord.CategoryId = existingRecord.CategoryId;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            var record = _db.Transactions.FirstOrDefault(c => c.Id == id);
            if (record != null)
            {
                _db.Transactions.Remove(record);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(TransactionRecord record)
        {
            return Delete(record.Id);
        }
    }
}
