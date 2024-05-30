using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class AssignedInvestigatorRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6973de56-1363-46b9-b7e7-368b98d82f05", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEJjgddI9rWISzt06bwR9T+NXCHW3G7UgmyQsTE/0DIGYOhNSVi4Iq6hCE2foThMKEQ==", "516b8696-ea46-44a5-a628-4f35c1077d06" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomUsername", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "357f9cab-c811-47c9-980b-6e500ef98cd8", 0, "308dc79b-57cd-4dac-902a-b75e9533295a", "testInvestigator", "investigator@mail.com", true, false, null, "INVESTIGATOR@MAIL.COM", "INVESTIGATOR@MAIL.COM", "AQAAAAEAACcQAAAAEO+g3O3cyf0W+K5bXWgoy6kg4cy1fcccVy8sJSiZFUW4x8yMoTUMmhQqIZ7CEmjk2Q==", "", false, "444b3f8f-ad7e-462d-a211-20722bda7dd9", false, "investigator@mail.com" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7576), new DateTime(2024, 5, 25, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 24, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7589), new DateTime(2024, 5, 25, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7599), new DateTime(2024, 5, 25, 12, 21, 3, 358, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "90b7db83-4a71-4ef1-b3ae-07b481310175", "357f9cab-c811-47c9-980b-6e500ef98cd8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "90b7db83-4a71-4ef1-b3ae-07b481310175", "357f9cab-c811-47c9-980b-6e500ef98cd8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a476ebb-cc70-483e-952c-942b797a6d2c", "ADMIN@MAIL.COM ", "AQAAAAEAACcQAAAAEAjhMrKpXHHlhqz2AdG9qagQxuzD+nFty4GZJA4IrZuhoEzR0SpQ97qOZC5HOcrBcg==", "6f871cd3-dbe8-4a23-8c0c-6e240d707842" });

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
    }
}
