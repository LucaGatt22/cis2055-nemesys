using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCount",
                table: "BlogPosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BlogPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 17, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4217), new DateTime(2024, 4, 17, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 16, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4220), new DateTime(2024, 4, 17, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 15, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4224), new DateTime(2024, 4, 17, 9, 35, 58, 443, DateTimeKind.Utc).AddTicks(4225) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BlogPosts");

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
    }
}
