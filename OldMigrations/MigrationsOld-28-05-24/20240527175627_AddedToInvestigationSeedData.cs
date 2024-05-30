using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class AddedToInvestigationSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_CampusCategories_CategoryId",
                table: "Investigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations");

            migrationBuilder.DropIndex(
                name: "IX_Investigations_CategoryId",
                table: "Investigations");

            migrationBuilder.DropIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Investigations");

            migrationBuilder.AddColumn<int>(
                name: "InvestigationId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReadCount",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e19fd667-c653-44ef-8330-a8ca116ccfab", "AQAAAAEAACcQAAAAECUK5btwwOK88petssDOFkP1U/eatXY849BbXWK8x+xW8X3CYhzrGnvs+iSRBHrAvg==", "f632d525-8a44-4c44-aa5b-04dc51efc114" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "720156f5-f38d-4d22-a519-e0848aaa4db9", "AQAAAAEAACcQAAAAEJAHeSywk+TGNXGXsZm8ZciJkGNZ8WxWyWlzj9uEF1TfUhUTqqOI/TAqeFI4PbThoA==", "cb2316b8-98eb-4d3d-ad72-4895d20e02cd" });

            migrationBuilder.InsertData(
                table: "Investigations",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Today's AGA is characterized by ...", new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8310), "/images/seed1.jpg", "AGA Today", new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8311), "357f9cab-c811-47c9-980b-6e500ef98cd8" },
                    { 2, "Today's traffic can't be described using words...", new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8327), "/images/seed2.jpg", "Traffic is incredible", new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8328), "357f9cab-c811-47c9-980b-6e500ef98cd8" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InvestigationId", "ReadCount", "StatusId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8226), 0, 0, 1, new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "InvestigationId", "ReadCount", "StatusId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8236), 0, 0, 2, new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "InvestigationId", "ReadCount", "StatusId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8250), 0, 0, 3, new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8250) });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Being Investigated" },
                    { 2, "No Action Required" },
                    { 3, "Closed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InvestigationId",
                table: "Reports",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StatusId",
                table: "Reports",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Investigations_InvestigationId",
                table: "Reports",
                column: "InvestigationId",
                principalTable: "Investigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Statuses_StatusId",
                table: "Reports",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Investigations_InvestigationId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Statuses_StatusId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Reports_InvestigationId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_StatusId",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "InvestigationId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReadCount",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Investigations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Investigations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6973de56-1363-46b9-b7e7-368b98d82f05", "AQAAAAEAACcQAAAAEJjgddI9rWISzt06bwR9T+NXCHW3G7UgmyQsTE/0DIGYOhNSVi4Iq6hCE2foThMKEQ==", "516b8696-ea46-44a5-a628-4f35c1077d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308dc79b-57cd-4dac-902a-b75e9533295a", "AQAAAAEAACcQAAAAEO+g3O3cyf0W+K5bXWgoy6kg4cy1fcccVy8sJSiZFUW4x8yMoTUMmhQqIZ7CEmjk2Q==", "444b3f8f-ad7e-462d-a211-20722bda7dd9" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_CategoryId",
                table: "Investigations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_CampusCategories_CategoryId",
                table: "Investigations",
                column: "CategoryId",
                principalTable: "CampusCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }
    }
}
