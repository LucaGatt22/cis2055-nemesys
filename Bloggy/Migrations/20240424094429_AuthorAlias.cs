using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.Migrations
{
    /// <inheritdoc />
    public partial class AuthorAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32");

            migrationBuilder.AddColumn<string>(
                name: "AuthorAlias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 23, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6187), new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 22, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6192), new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6193) });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "134c1566-3f64-4ab4-b1e7-2ffe11f43e32", 0, "2e5591f4-62fc-417b-8473-fb1f22cd1cd5", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM ", "AQAAAAEAACcQAAAAEFpewfGCzMRLJ0GiKEyKbBToR79rSBLCRJyztv+4ReYfA1YLXW0bzN76xeq7RpEPnw==", "", false, "6cf2e281-d390-48c4-9148-ed9654ecc2b8", false, "admin@mail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "AuthorAlias",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "134c1566-3f64-4ab4-b1e7-2ffe11f43e32", 0, "ec6b8913-759b-469c-8db6-de183fc32840", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM ", "AQAAAAEAACcQAAAAEBVREY5likLdOCdjykGo8TgeiFTtt6yS9QUrT/swzwVghmMqiApZ/hpTVnWvxli/uA==", "", false, "44f130ed-3a43-47e3-b237-f27f77f6830b", false, "admin@mail.com" });

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
        }
    }
}
