using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Uncategorised" },
                    { 2, "Comedy" },
                    { 3, "News" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Today's AGA is characterized by a series of discussions and debates around ...", new DateTime(2024, 3, 20, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1426), "/images/seed1.jpg", "AGA Today" },
                    { 2, 2, "Today's traffic can't be described using words. Only an image can do that ...", new DateTime(2024, 3, 19, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1428), "/images/seed2.jpg", "Traffic is incredible" },
                    { 3, 3, "Clouds clouds all around us. I thought spring started already, but ...", new DateTime(2024, 3, 18, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1432), "/images/seed3.jpg", "When is Spring really starting?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
