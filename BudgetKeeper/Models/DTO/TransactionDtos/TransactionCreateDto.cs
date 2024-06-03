using System.ComponentModel.DataAnnotations;

namespace BudgetKeeper.Models.DTO.TransactionDtos
{
    public class TransactionCreateDto
    {
        public string Comment { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
