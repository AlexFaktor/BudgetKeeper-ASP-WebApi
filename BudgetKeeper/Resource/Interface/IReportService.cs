using BudgetKeeper.Core.BudgetReportDtos;

namespace BudgetKeeper.Resource.Interface
{
    public interface IReportService
    {
        public Task<BudgetReportDto?> GetAsync(DateTime day);
        public Task<BudgetReportDto?> GetAsync(DateTime from, DateTime to);
    }
}
