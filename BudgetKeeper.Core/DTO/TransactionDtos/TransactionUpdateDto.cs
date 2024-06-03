using System.ComponentModel.DataAnnotations;

namespace BudgetKeeper.Core.TransactionDtos
{
    public class TransactionUpdateDto
    {
        public string Comment { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }
    }

}
