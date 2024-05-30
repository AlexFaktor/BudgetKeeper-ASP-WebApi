﻿using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models
{
    public class BudgetReport
    {
        public decimal Profit { get; set; }
        public decimal Expenses { get; set; }
        public List<BudgetTransaction> Total { get; set; }

        public BudgetReport(List<Transaction> transactions)
        {
            Profit = transactions.Where(x => x.Amount > 0).Sum(x => x.Amount);
            Expenses = transactions.Where(x => x.Amount < 0).Sum(x => x.Amount);
            Total = transactions.Select(t => new BudgetTransaction(t)).ToList();
        }
    }
}
