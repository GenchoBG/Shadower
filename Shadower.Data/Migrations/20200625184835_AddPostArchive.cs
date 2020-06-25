using Microsoft.EntityFrameworkCore.Migrations;

namespace Shadower.Data.Migrations
{
    public partial class AddPostArchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Posts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Posts");
        }
    }
}
