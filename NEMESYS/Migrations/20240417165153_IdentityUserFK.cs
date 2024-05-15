using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BlogPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "134c1566-3f64-4ab4-b1e7-2ffe11f43e32", 0, "3097e083-8e64-4daf-bcfb-49099d8ca809", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM ", "AQAAAAEAACcQAAAAEIQQK8Oq4eB7LoQWKE8UYcGCoSfZncdbU1uRmvs9SwtWGUcDAuunHeXGinsB8XE8MA==", "", false, "f104bc87-e63d-4f60-9f91-16a081c023ad", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(794), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(797), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 16, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(799), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(803), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 15, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(804), new DateTime(2024, 4, 17, 16, 51, 53, 320, DateTimeKind.Utc).AddTicks(804), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AspNetUsers_UserId",
                table: "BlogPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AspNetUsers_UserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5391), new DateTime(2024, 4, 17, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 16, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5400), new DateTime(2024, 4, 17, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 15, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5408), new DateTime(2024, 4, 17, 16, 11, 44, 519, DateTimeKind.Utc).AddTicks(5409) });
        }
    }
}
