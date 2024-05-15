using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.Migrations
{
    /// <inheritdoc />
    public partial class CreatedReadCountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadCount",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ReadCount" },
                values: new object[] { new DateTime(2024, 4, 8, 8, 44, 7, 934, DateTimeKind.Utc).AddTicks(5062), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ReadCount" },
                values: new object[] { new DateTime(2024, 4, 7, 8, 44, 7, 934, DateTimeKind.Utc).AddTicks(5065), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ReadCount" },
                values: new object[] { new DateTime(2024, 4, 6, 8, 44, 7, 934, DateTimeKind.Utc).AddTicks(5068), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCount",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 20, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 19, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 18, 11, 52, 27, 205, DateTimeKind.Utc).AddTicks(1432));
        }
    }
}
