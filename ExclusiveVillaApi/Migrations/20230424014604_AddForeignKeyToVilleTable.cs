using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExclusiveVillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVilleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VilleID",
                table: "VilleNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 24, 2, 46, 3, 617, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 24, 2, 46, 3, 617, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 24, 2, 46, 3, 617, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 24, 2, 46, 3, 617, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 24, 2, 46, 3, 617, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.CreateIndex(
                name: "IX_VilleNumbers_VilleID",
                table: "VilleNumbers",
                column: "VilleID");

            migrationBuilder.AddForeignKey(
                name: "FK_VilleNumbers_Villes_VilleID",
                table: "VilleNumbers",
                column: "VilleID",
                principalTable: "Villes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VilleNumbers_Villes_VilleID",
                table: "VilleNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VilleNumbers_VilleID",
                table: "VilleNumbers");

            migrationBuilder.DropColumn(
                name: "VilleID",
                table: "VilleNumbers");

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
    }
}
