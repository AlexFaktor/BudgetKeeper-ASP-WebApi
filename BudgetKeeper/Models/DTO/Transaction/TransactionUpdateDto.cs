namespace BudgetKeeper.Models.DTO.Transaction
{
    public class TransactionUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; }
    }

}
