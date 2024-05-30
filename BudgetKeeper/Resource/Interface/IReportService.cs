using BudgetKeeper.Models;

namespace BudgetKeeper.Resource.Interface
{
    public interface IReportService
    {
        public Task<BudgetReport?> GetAsync(DateTime day);
        public Task<BudgetReport?> GetAsync(DateTime from, DateTime to);
    }
}
