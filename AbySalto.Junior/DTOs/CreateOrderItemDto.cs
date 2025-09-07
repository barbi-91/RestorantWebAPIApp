using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.DTOs
{
    public class CreateOrderItemDto
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Price must be non-negative")]
        public decimal Price { get; set; }
    }
}
