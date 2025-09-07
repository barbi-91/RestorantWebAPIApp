using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbySalto.Junior.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ContactNumber", "Currency", "CustomerName", "DeliveryAddress", "Note", "OrderTime", "PaymentMethod", "Status" },
                values: new object[,]
                {
                    { 1, "0911234567", "EUR", "Ana Kolar", "Ulica 1, Zagreb", "Ring the doorbell", new DateTime(2025, 9, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Pending" },
                    { 2, "0987654321", "EUR", "Ivan Horvat", "Ulica 2, Split", null, new DateTime(2025, 9, 5, 18, 30, 0, 0, DateTimeKind.Unspecified), "CreditCard", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 8.50m, "Pizza Margherita", 2 },
                    { 2, 1, 2.50m, "Orange Juice", 1 },
                    { 3, 2, 7.00m, "Classic Burger", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
