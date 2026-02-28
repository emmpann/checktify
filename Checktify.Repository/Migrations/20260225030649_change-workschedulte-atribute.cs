using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checktify.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changeworkschedulteatribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_Companies_CompanyId",
                table: "WorkSchedules");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "WorkSchedules",
                newName: "OfficeLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSchedules_CompanyId",
                table: "WorkSchedules",
                newName: "IX_WorkSchedules_OfficeLocationId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WorkSchedules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AppRole",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OfficeLocations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_Code",
                table: "WorkSchedules",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Code",
                table: "AppRole",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocations_Code",
                table: "OfficeLocations",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_OfficeLocations_OfficeLocationId",
                table: "WorkSchedules",
                column: "OfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_OfficeLocations_OfficeLocationId",
                table: "WorkSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedules_Code",
                table: "WorkSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Role_Code",
                table: "AppRole");

            migrationBuilder.DropIndex(
                name: "IX_OfficeLocations_Code",
                table: "OfficeLocations");

            migrationBuilder.RenameColumn(
                name: "OfficeLocationId",
                table: "WorkSchedules",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSchedules_OfficeLocationId",
                table: "WorkSchedules",
                newName: "IX_WorkSchedules_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "WorkSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AppRole",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "OfficeLocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_Companies_CompanyId",
                table: "WorkSchedules",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
