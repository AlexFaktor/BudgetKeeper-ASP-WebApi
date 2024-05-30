using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models
{
    public class BudgetReport
    {
        public decimal Profit { get; set; }
        public decimal Expenses { get; set; }
        public List<BudgetTransaction> Total { get; set; }

        public BudgetReport(List<TransactionRecord> transactions)
        {
            Profit = transactions.Where(x => x.Value > 0).Sum(x => x.Value);
            Expenses = transactions.Where(x => x.Value < 0).Sum(x => x.Value);
            Total = transactions.Select(t => new BudgetTransaction(t)).ToList();
        }
    }
}
