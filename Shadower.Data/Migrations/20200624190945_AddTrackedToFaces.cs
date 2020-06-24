using Microsoft.EntityFrameworkCore.Migrations;

namespace Shadower.Data.Migrations
{
    public partial class AddTrackedToFaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Tracked",
                table: "Faces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tracked",
                table: "Faces");
        }
    }
}
