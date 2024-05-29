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
            Profit = transactions.Where(x => x.Income > 0).Sum(x => x.Income);
            Expenses = transactions.Where(x => x.Income < 0).Sum(x => x.Income);
            Total = transactions.Select(t => new BudgetTransaction(t)).ToList();
        }
    }
}
