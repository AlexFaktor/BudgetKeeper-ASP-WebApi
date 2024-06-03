﻿using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.TransactionDtos;

namespace BudgetKeeper.Models
{
    public class BudgetReport
    {
        public decimal Profit { get; set; }
        public decimal Expenses { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new();

        public BudgetReport(List<TransactionDto> transactions)
        {
            Profit = transactions.Where(x => x.Amount > 0).Sum(x => x.Amount);
            Expenses = transactions.Where(x => x.Amount < 0).Sum(x => x.Amount);
            Transactions = transactions.ToList();
        }

        public BudgetReport()
        { 
        
        }
    }
}
