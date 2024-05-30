using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class AddedInvestigatorUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a476ebb-cc70-483e-952c-942b797a6d2c", "AQAAAAEAACcQAAAAEAjhMrKpXHHlhqz2AdG9qagQxuzD+nFty4GZJA4IrZuhoEzR0SpQ97qOZC5HOcrBcg==", "6f871cd3-dbe8-4a23-8c0c-6e240d707842" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4218), new DateTime(2024, 5, 25, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 24, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4229), new DateTime(2024, 5, 25, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4244), new DateTime(2024, 5, 25, 12, 5, 34, 286, DateTimeKind.Utc).AddTicks(4245) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "489f31ae-b73e-479a-9c5e-9a4828c7c87e", "AQAAAAEAACcQAAAAEKohE2WrgTb+AUfGMzOZHxwZ+vPddiNlnn0owXn/wcS4/2pl+0vIAU/TzGSbFwmkMA==", "c3ad42b7-01a2-46ea-ae3b-9cfe66ff226b" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 20, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6737), new DateTime(2024, 5, 20, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6751), new DateTime(2024, 5, 20, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6773) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 18, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6776), new DateTime(2024, 5, 20, 16, 35, 40, 120, DateTimeKind.Utc).AddTicks(6777) });
        }
    }
}
