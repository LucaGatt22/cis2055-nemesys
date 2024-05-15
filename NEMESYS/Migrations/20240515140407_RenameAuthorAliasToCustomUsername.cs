using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class RenameAuthorAliasToCustomUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "AuthorAlias",
                table: "AspNetUsers",
                newName: "CustomUsername");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investigations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investigations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investigations_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89f9f84b-8dd1-436c-b62c-ba22a7797c1c", "AQAAAAEAACcQAAAAEAspQJq0csPwShj/LdZ+F3jClDADlCYZTEHq4bQbaVk7B4oP8rXVZskSNJmJpLbPww==", "be3e895e-7648-484e-9995-dd2e8c75b5cd" });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "ImageUrl", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Today's AGA is characterized by a series of discussions and debates around ...", new DateTime(2024, 5, 15, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8233), "/images/seed1.jpg", "AGA Today", new DateTime(2024, 5, 15, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8235), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" },
                    { 2, 2, "Today's traffic can't be described using words. Only an image can do that ...", new DateTime(2024, 5, 14, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8238), "/images/seed2.jpg", "Traffic is incredible", new DateTime(2024, 5, 15, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8241), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" },
                    { 3, 3, "Clouds clouds all around us. I thought spring started already, but ...", new DateTime(2024, 5, 13, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8243), "/images/seed3.jpg", "When is Spring really starting?", new DateTime(2024, 5, 15, 14, 4, 7, 494, DateTimeKind.Utc).AddTicks(8244), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_CategoryId",
                table: "Investigations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_UserId",
                table: "Investigations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CategoryId",
                table: "Reports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investigations");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.RenameColumn(
                name: "CustomUsername",
                table: "AspNetUsers",
                newName: "AuthorAlias");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "ImageUrl", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Today's AGA is characterized by a series of discussions and debates around ...", new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6185), "/images/seed1.jpg", "AGA Today", new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6186), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" },
                    { 2, 2, "Today's traffic can't be described using words. Only an image can do that ...", new DateTime(2024, 4, 23, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6187), "/images/seed2.jpg", "Traffic is incredible", new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6191), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" },
                    { 3, 3, "Clouds clouds all around us. I thought spring started already, but ...", new DateTime(2024, 4, 22, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6192), "/images/seed3.jpg", "When is Spring really starting?", new DateTime(2024, 4, 24, 9, 44, 29, 459, DateTimeKind.Utc).AddTicks(6193), "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" }
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5591f4-62fc-417b-8473-fb1f22cd1cd5", "AQAAAAEAACcQAAAAEFpewfGCzMRLJ0GiKEyKbBToR79rSBLCRJyztv+4ReYfA1YLXW0bzN76xeq7RpEPnw==", "6cf2e281-d390-48c4-9148-ed9654ecc2b8" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");
        }
    }
}
