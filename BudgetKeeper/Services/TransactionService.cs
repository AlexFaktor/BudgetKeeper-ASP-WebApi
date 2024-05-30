using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Transaction;
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

        public Transaction? Add(TransactionCreateDto transactionDto)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == transactionDto.CategoryId);
            if (category is null)
            {
                category = _db.Categories.FirstOrDefault(c => c.Name == "Unknown");
                if (category is null)
                    return null;
            }

            var record = new Transaction
            {
                Comment = transactionDto.Name,
                Amount = transactionDto.Income,
                Category = category,
                CategoryId = category.Id,
                Time = transactionDto.Time
            };

            _db.Transactions.Add(record);
            _db.SaveChanges();
            return record;
        }

        public List<Transaction> GetAll() => _db.Transactions.ToList();
        public Transaction? Get(Guid id) => _db.Transactions.FirstOrDefault(c => c.Id == id);
        public List<Transaction> Get(DateTime from, DateTime to) => _db.Transactions.Where(t => t.Time >= from && t.Time <= to).ToList();

        public List<Transaction> Get(DateTime day) => _db.Transactions.Where(t => t.Time.Date == day.Date).ToList();

        public Transaction? Update(Guid id,TransactionUpdateDto transactionDto)
        {
            var record = _db.Transactions.FirstOrDefault(c => c.Id == id);
            var category = _db.Categories.FirstOrDefault(c => c.Id == transactionDto.CategoryId);
            if (category is null)
            {
                category = _db.Categories.FirstOrDefault(c => c.Name == "Unknown");
                if (category is null)
                    return null;
            }

            if (record is not null)
            {
                record.Comment = transactionDto.Name;
                record.Amount = transactionDto.Income;
                record.Time = transactionDto.Time;
                record.Category = category;
                record.CategoryId = transactionDto.CategoryId;
                _db.SaveChanges();
                return record;
            }
            return null;
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

        public bool Delete(Transaction record)
        {
            return Delete(record.Id);
        }
    }
}
