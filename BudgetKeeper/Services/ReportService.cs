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
        
        public BudgetReport? Get(DateTime day)
        {
            DateTime dayStart = day.Date;
            DateTime dayEnd = day.Date.AddDays(1).AddTicks(-1);

            return Get(dayStart, dayEnd);
        }

        public BudgetReport? Get(DateTime from, DateTime to)
        {
            var transactions = _transactionService.Get(from, to);
            if (transactions.Count < 1)
                return null;
            return new BudgetReport(transactions);
        }
    }
}
