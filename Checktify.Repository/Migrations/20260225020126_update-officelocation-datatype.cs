using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checktify.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateofficelocationdatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "OfficeLocations",
                type: "decimal(18,8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "OfficeLocations",
                type: "decimal(18,8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "OfficeLocations",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "OfficeLocations",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)");
        }
    }
}
