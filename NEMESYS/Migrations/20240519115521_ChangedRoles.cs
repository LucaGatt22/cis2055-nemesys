using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db56103-a3e2-4edc-afab-abde856cebe0",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Reporter", "REPORTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90b7db83-4a71-4ef1-b3ae-07b481310175", "1", "Investigator", "INVESTIGATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452581b6-fe12-4961-b2dc-5086088ce200", "AQAAAAEAACcQAAAAEHes4evzcUEKDJ5KBIyM9Mb5AKOAqi0ODUnd7UlUb983CwX7ZYhpjN0JJVzBA87nhQ==", "b5aa04a8-297b-4519-8b98-f06c7f65300b" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2279), new DateTime(2024, 5, 19, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 18, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2287), new DateTime(2024, 5, 19, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 17, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2304), new DateTime(2024, 5, 19, 11, 55, 21, 174, DateTimeKind.Utc).AddTicks(2305) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b7db83-4a71-4ef1-b3ae-07b481310175");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db56103-a3e2-4edc-afab-abde856cebe0",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccf0de65-fc5f-4847-8c5d-30bb5e272330", "AQAAAAEAACcQAAAAEGdh6gix3swylpuVSmh7lfJhK9yOAYrAwNE8RreTBMM7UwozfY08z30zrDjZjWM8dQ==", "7231f489-13be-4288-aeb5-3d6fae1ad45e" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9626), new DateTime(2024, 5, 19, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 18, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9630), new DateTime(2024, 5, 19, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9636) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 17, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9641), new DateTime(2024, 5, 19, 9, 15, 57, 185, DateTimeKind.Utc).AddTicks(9641) });
        }
    }
}
