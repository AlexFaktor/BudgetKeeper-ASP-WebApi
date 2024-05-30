using BudgetKeeper.Database.Database;
using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.CategoryDtos;
using BudgetKeeper.Models.DTO.TransactionDtos;
using BudgetKeeper.Resource.Interface;
using Microsoft.EntityFrameworkCore;

namespace BudgetKeeper.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BudgetDbContext _db;

        public TransactionService(BudgetDbContext db)
        {
            _db = db;
        }

        public async Task<TransactionDto?> AddAsync(TransactionCreateDto transactionDto)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == transactionDto.CategoryId);
            if (category is null)
            {
                category = await _db.Categories.FirstOrDefaultAsync(c => c.Name == "Unknown");
                if (category is null)
                    return null;
            }

            var record = new Transaction
            {
                Comment = transactionDto.Comment,
                Amount = transactionDto.Amount,
                Category = category,
                CategoryId = category.Id,
                Time = transactionDto.Time
            };

            await _db.Transactions.AddAsync(record);
            await _db.SaveChangesAsync();
            return new(record);
        }

        public async Task<List<TransactionDto>> GetAllAsync() => await _db.Transactions.Select(t => new TransactionDto(t)).ToListAsync();

        public async Task<TransactionDto?> GetAsync(Guid id)
        {
            var transaction = await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            return transaction == null ? null : new TransactionDto(transaction);
        }

        public async Task<List<TransactionDto>> GetAsync(DateTime from, DateTime to) => await _db.Transactions.Where(t => t.Time >= from && t.Time <= to)
            .Select(t => new TransactionDto(t)).ToListAsync();

        public async Task<List<TransactionDto>> GetAsync(DateTime day) => await _db.Transactions.Where(t => t.Time.Date == day.Date)
            .Select(t => new TransactionDto(t)).ToListAsync();

        public async Task<TransactionDto?> UpdateAsync(Guid id, TransactionUpdateDto transactionDto)
        {
            var record = await _db.Transactions.FirstOrDefaultAsync(c => c.Id == id);
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == transactionDto.CategoryId);
            if (category is null)
            {
                category = await _db.Categories.FirstOrDefaultAsync(c => c.Name == "Unknown");
                if (category is null)
                    return null;
            }

            if (record is not null)
            {
                record.Comment = transactionDto.Comment;
                record.Amount = transactionDto.Amount;
                record.Time = transactionDto.Time;
                record.Category = category;
                record.CategoryId = transactionDto.CategoryId;
                await _db.SaveChangesAsync();
                return new(record);
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var record = await _db.Transactions.FirstOrDefaultAsync(c => c.Id == id);
            if (record != null)
            {
                _db.Transactions.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Transaction record)
        {
            return await DeleteAsync(record.Id);
        }
    }
}

