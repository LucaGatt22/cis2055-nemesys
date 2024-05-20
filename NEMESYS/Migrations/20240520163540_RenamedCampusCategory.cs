using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCampusCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_Categories_CategoryId",
                table: "Investigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Categories_CategoryId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Reports",
                newName: "CampusCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CategoryId",
                table: "Reports",
                newName: "IX_Reports_CampusCategoryId");

            migrationBuilder.CreateTable(
                name: "CampusCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "489f31ae-b73e-479a-9c5e-9a4828c7c87e", "AQAAAAEAACcQAAAAEKohE2WrgTb+AUfGMzOZHxwZ+vPddiNlnn0owXn/wcS4/2pl+0vIAU/TzGSbFwmkMA==", "c3ad42b7-01a2-46ea-ae3b-9cfe66ff226b" });

            migrationBuilder.InsertData(
                table: "CampusCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Msida Campus" },
                    { 2, "Valletta Campus" },
                    { 3, "Marsaxlokk Campus" },
                    { 4, "Gozo Campus" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_CampusCategories_CategoryId",
                table: "Investigations",
                column: "CategoryId",
                principalTable: "CampusCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_CampusCategories_CampusCategoryId",
                table: "Reports",
                column: "CampusCategoryId",
                principalTable: "CampusCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_CampusCategories_CategoryId",
                table: "Investigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_CampusCategories_CampusCategoryId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "CampusCategories");

            migrationBuilder.RenameColumn(
                name: "CampusCategoryId",
                table: "Reports",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CampusCategoryId",
                table: "Reports",
                newName: "IX_Reports_CategoryId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452581b6-fe12-4961-b2dc-5086088ce200", "AQAAAAEAACcQAAAAEHes4evzcUEKDJ5KBIyM9Mb5AKOAqi0ODUnd7UlUb983CwX7ZYhpjN0JJVzBA87nhQ==", "b5aa04a8-297b-4519-8b98-f06c7f65300b" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Uncategorised" },
                    { 2, "Comedy" },
                    { 3, "News" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Categories_CategoryId",
                table: "Investigations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Categories_CategoryId",
                table: "Reports",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
