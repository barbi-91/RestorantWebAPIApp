using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = null!;

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [MaxLength(20)]
        public OrderPaymentMethod PaymentMethod { get; set; }

        [Required]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; } = null!;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string ContactNumber { get; set; } = null!;

        [MaxLength(500)]
        public string? Note { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [MaxLength(3)]
        public OrderCurrency Currency { get; set; }

        public decimal TotalAmount { get; set; }

        [Required]
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
