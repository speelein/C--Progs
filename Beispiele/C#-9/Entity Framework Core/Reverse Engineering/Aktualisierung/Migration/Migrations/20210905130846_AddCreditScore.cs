using Microsoft.EntityFrameworkCore.Migrations;

namespace Reverse_Engineering.Migrations
{
    public partial class AddCreditScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditScore",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditScore",
                table: "Customers");
        }
    }
}
