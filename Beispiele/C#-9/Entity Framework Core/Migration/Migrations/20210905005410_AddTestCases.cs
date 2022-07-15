using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationDemo.Migrations
{
    public partial class AddTestCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Rating", "Url" },
                values: new object[] { 1, 3, "https://devblogs.microsoft.com/aspnet/" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Rating", "Url" },
                values: new object[] { 2, 2, "https://devblogs.microsoft.com/visualstudio/" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "Title" },
                values: new object[] { 1, 2, null, "New in 2019 16.11.2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "Title" },
                values: new object[] { 2, 2, null, "VS 2022 Preview" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);
        }
    }
}
