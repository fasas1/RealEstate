using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace ExclusiveVillaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedVilleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villes",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2340), "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight", "https://www.pexels.com/photo/white-concrete-2-storey-house-206172/", "Quest Villa", 31, 230.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2361), "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight", "https://www.pexels.com/photo/palm-trees-at-night-258154/", "Skully Villa", 41, 350.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2366), "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight", "https://www.pexels.com/photo/construction-house-architecture-luxury-53610/", "Moment Villa", 21, 80.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2370), "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight", "https://www.pexels.com/photo/architecture-beach-blue-chairs-261101/", "Qassy Villa", 21, 130.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2023, 4, 4, 12, 47, 16, 462, DateTimeKind.Local).AddTicks(2374), "it catering to the demands of users, technology and whatsoever it maybe. Version control systems keep these revisions straight", "https://www.pexels.com/photo/architecture-beach-blue-chairs-261101/", "Bazooy Villa", 11, 190.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
