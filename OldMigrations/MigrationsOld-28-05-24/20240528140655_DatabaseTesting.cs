using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEMESYS.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "134c1566-3f64-4ab4-b1e7-2ffe11f43e32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c43b52c5-4aaf-4ba6-a3e1-80416ae7b362", "AQAAAAEAACcQAAAAEBlT5cJOkmFFAlKbcFYjSFZEh7XsRI2+q5/+sC3kifMPCc5vpXmoPsvBCZzZeA2T1A==", "8d0e02e4-cdc8-46b3-a889-15059a6a0556" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "357f9cab-c811-47c9-980b-6e500ef98cd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e607ab02-8ba1-4194-850b-c4005a21bbde", "AQAAAAEAACcQAAAAEJ0SxQqVDPmkITWHXsTO+CGcZP+z9IqK9FdhLI52nmGCnNmnmztKZKSlXUFn9g9fmg==", "37209098-cd30-4e13-8f22-4ccd3c406c7f" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1228), new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1229) });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1233), new DateTime(2024, 5, 27, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1234) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1194), new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1199), new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1205), new DateTime(2024, 5, 28, 14, 6, 55, 483, DateTimeKind.Utc).AddTicks(1206) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8310), new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8327), new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8226), new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 26, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8236), new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 25, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8250), new DateTime(2024, 5, 27, 17, 56, 26, 796, DateTimeKind.Utc).AddTicks(8250) });
        }
    }
}
