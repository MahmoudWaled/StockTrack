using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Electronics", "Laptop Dell XPS 13", 1200.00m, 50 },
                    { 2, "Accessories", "Wireless Mouse", 25.00m, 200 },
                    { 3, "Electronics", "Samsung Galaxy S23", 900.00m, 30 },
                    { 4, "Accessories", "USB-C Cable", 10.00m, 500 },
                    { 5, "Electronics", "Headphones Sony WH-1000XM5", 350.00m, 40 },
                    { 6, "Accessories", "Keyboard Logitech K380", 45.00m, 150 },
                    { 7, "Electronics", "Monitor LG 27-inch", 300.00m, 20 },
                    { 8, "Storage", "External Hard Drive 1TB", 60.00m, 100 },
                    { 9, "Wearables", "Smartwatch Fitbit Versa 4", 200.00m, 60 },
                    { 10, "Accessories", "Power Bank 10000mAh", 30.00m, 300 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Pass123!", "Admin", "ahmed_mohamed" },
                    { 2, "Sara2023", "User", "sara_ali" },
                    { 3, "Mh12345", "Seller", "mohamed_hassan" },
                    { 4, "Fatima99", "Seller", "fatima_khaled" },
                    { 5, "Omar2023", "Seller", "omar_youssef" },
                    { 6, "NouraPass", "User", "noura_ahmed" },
                    { 7, "Khaled123", "Seller", "khaled_mahmoud" },
                    { 8, "Layan2023", "Admin", "layan_said" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ProductId", "QuantitySold", "SaleDate", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400.00m, 3 },
                    { 2, 2, 5, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.00m, 4 },
                    { 3, 3, 1, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.00m, 5 },
                    { 4, 4, 10, new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.00m, 7 },
                    { 5, 5, 1, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.00m, 3 },
                    { 6, 6, 3, new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.00m, 4 },
                    { 7, 7, 2, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.00m, 5 },
                    { 8, 8, 4, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 240.00m, 7 },
                    { 9, 9, 1, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, 3 },
                    { 10, 10, 6, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 180.00m, 4 },
                    { 11, 1, 1, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.00m, 5 },
                    { 12, 2, 8, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, 7 },
                    { 13, 3, 2, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800.00m, 3 },
                    { 14, 4, 15, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.00m, 4 },
                    { 15, 5, 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 350.00m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
