using BudgetKeeper.Models;

namespace BudgetKeeper.Resource.Interface
{
    public interface IReportService
    {
        public BudgetReport? Get(DateTime day);
        public BudgetReport? Get(DateTime from, DateTime to);
    }
}
