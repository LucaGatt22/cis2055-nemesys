using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bloggy.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1db56103-a3e2-4edc-afab-abde856cebe0", "1", "User", "USER" },
                    { "d234f58e-7373-4ee5-98f0-c17892784b05", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec6b8913-759b-469c-8db6-de183fc32840", "AQAAAAEAACcQAAAAEBVREY5likLdOCdjykGo8TgeiFTtt6yS9QUrT/swzwVghmMqiApZ/hpTVnWvxli/uA==", "44f130ed-3a43-47e3-b237-f27f77f6830b" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 17, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8171), new DateTime(2024, 4, 17, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8172) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 16, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8174), new DateTime(2024, 4, 17, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8179), new DateTime(2024, 4, 17, 17, 50, 17, 380, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db56103-a3e2-4edc-afab-abde856cebe0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d234f58e-7373-4ee5-98f0-c17892784b05");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3097e083-8e64-4daf-bcfb-49099d8ca809", "AQAAAAEAACcQAAAAEIQQK8Oq4eB7LoQWKE8UYcGCoSfZncdbU1uRmvs9SwtWGUcDAuunHeXGinsB8XE8MA==", "f104bc87-e63d-4f60-9f91-16a081c023ad" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(794), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 16, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(799), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(803) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 15, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(804), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(804) });
        }
    }
}
