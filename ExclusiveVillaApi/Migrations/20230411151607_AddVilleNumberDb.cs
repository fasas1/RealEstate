using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExclusiveVillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVilleNumberDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VilleNumbers",
                columns: table => new
                {
                    VilleNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VilleNumbers", x => x.VilleNo);
                });

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 11, 16, 16, 6, 586, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 11, 16, 16, 6, 586, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 11, 16, 16, 6, 586, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 11, 16, 16, 6, 586, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 11, 16, 16, 6, 586, DateTimeKind.Local).AddTicks(1695));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VilleNumbers");

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2374));
        }
    }
}
