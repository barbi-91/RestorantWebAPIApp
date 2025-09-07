﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        // Primary key
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = null!;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderTime { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(20)]
        public OrderPaymentMethod PaymentMethod { get; set; } = OrderPaymentMethod.Cash;

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
        [MaxLength(3)]
        public OrderCurrency Currency { get; set; } = OrderCurrency.EUR;

        // Navigation property for related order items
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Read-only property for total amount, not mapped to the database
        [NotMapped]
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}
