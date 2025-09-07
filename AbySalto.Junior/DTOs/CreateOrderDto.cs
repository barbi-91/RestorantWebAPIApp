using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderPaymentMethod PaymentMethod { get; set; }

        [Required]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string ContactNumber { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderCurrency Currency { get; set; }

        [Required]
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
