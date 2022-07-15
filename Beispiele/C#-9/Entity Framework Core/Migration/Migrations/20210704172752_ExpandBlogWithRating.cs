using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationDemo.Migrations
{
    public partial class ExpandBlogWithRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Blogs");
        }
    }
}
