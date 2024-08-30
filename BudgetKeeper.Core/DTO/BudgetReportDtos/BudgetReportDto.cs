using BudgetKeeper.Core.TransactionDtos;

namespace BudgetKeeper.Core.BudgetReportDtos
{
    public class BudgetReportDto
    {
        public decimal Profit { get; set; }
        public decimal Expenses { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new();

        public BudgetReportDto(List<TransactionDto> transactions)
        {
            Profit = transactions.Where(x => x.Amount > 0).Sum(x => x.Amount);
            Expenses = transactions.Where(x => x.Amount < 0).Sum(x => x.Amount);
            Transactions = transactions.ToList();
        }

        public BudgetReportDto()
        {

        }
    }
}
