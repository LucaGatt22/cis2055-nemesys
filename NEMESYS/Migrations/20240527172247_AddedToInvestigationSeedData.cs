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
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations");

            migrationBuilder.DropIndex(
                name: "IX_Investigations_ReportId",
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f34d6db5-37c9-4192-bd6e-e16608253adc", "AQAAAAEAACcQAAAAEDFaRMG+k5fhO7bxf4Q2GkFOb+cRiGwCqzGIYkx1PGKUJXXPoqhH8SKC94yAqlWx5g==", "8054ba83-70b8-4f45-9fe9-a5b8783bfafd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a3fc5a6-439d-4820-9de8-81977968284a", "AQAAAAEAACcQAAAAEJ3AoGNCHzJ+MJRaeIFCRwgEX/z/gJqMvdfTkk/uJFe9p/RAd6zurWIHcZfFQMPq9Q==", "5eb25e87-eddf-469f-87e3-ff4634fc2575" });

            migrationBuilder.InsertData(
                table: "Investigations",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Today's AGA is characterized by ...", new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8828), "/images/seed1.jpg", "AGA Today", new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8829), "357f9cab-c811-47c9-980b-6e500ef98cd8" },
                    { 2, "Today's traffic can't be described using words...", new DateTime(2024, 5, 26, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(9073), "/images/seed2.jpg", "Traffic is incredible", new DateTime(2024, 5, 26, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(9075), "357f9cab-c811-47c9-980b-6e500ef98cd8" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InvestigationId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8762), 0, new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "InvestigationId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8769), 0, new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "InvestigationId", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8778), 0, new DateTime(2024, 5, 27, 17, 22, 47, 109, DateTimeKind.Utc).AddTicks(8779) });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InvestigationId",
                table: "Reports",
                column: "InvestigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Investigations_InvestigationId",
                table: "Reports",
                column: "InvestigationId",
                principalTable: "Investigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Investigations_InvestigationId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_InvestigationId",
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

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Investigations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb88e6a-4f1e-488f-b927-df9f139d79f5", "AQAAAAEAACcQAAAAELCqBxOwHOQZJNQMoMgXmI/nOCqBt/weWMWZJDn7216K/vcaSTFLRb9dPoHbLzx3EA==", "600c031e-0c54-4e6f-a867-39e0e961920d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f177e7cb-2fd6-4282-bfda-684340822948", "AQAAAAEAACcQAAAAEJoj2l3RBt5m4MLsfvdARCX1MtuoCfKoz+hTmcFPj8CZDbwjuMET9uH4uokfQHb96w==", "8a2b4861-0580-40ba-a3d4-6a2f19b75e57" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2085), new DateTime(2024, 5, 26, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2097), new DateTime(2024, 5, 26, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2109), new DateTime(2024, 5, 26, 13, 14, 16, 61, DateTimeKind.Utc).AddTicks(2109) });

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
