using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel.ReceiptViewModel
{
    public class ReceiptRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int RelieftId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ReceiptDetailRequest
    {
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Quantities { get; set; }
    }
}
