using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checktify.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addusernewatribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "AspNetUsers");
        }
    }
}
