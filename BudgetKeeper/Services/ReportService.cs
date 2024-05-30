using BudgetKeeper.Database.Database;
using BudgetKeeper.Models;
using BudgetKeeper.Resource.Interface;

namespace BudgetKeeper.Services
{
    public class ReportService : IReportService
    {
        private readonly TransactionService _transactionService;

        public ReportService(BudgetDbContext db)
        {
            _transactionService = new(db);
        }
        
        public async Task<BudgetReport?> GetAsync(DateTime day)
        {
            DateTime dayStart = day.Date;
            DateTime dayEnd = day.Date.AddDays(1).AddTicks(-1);

            return await GetAsync(dayStart, dayEnd);
        }

        public async Task<BudgetReport?> GetAsync(DateTime from, DateTime to)
        {
            var transactions = await _transactionService.GetAsync(from, to);
            if (transactions.Count < 1)
                return null;
            return new BudgetReport(transactions);
        }
    }
}
