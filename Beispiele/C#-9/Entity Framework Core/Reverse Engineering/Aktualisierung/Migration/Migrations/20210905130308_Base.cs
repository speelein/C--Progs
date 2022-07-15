using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reverse_Engineering.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
            //        CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
            //        ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
            //        City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
            //        Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
            //        Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        OrderID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerID = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true),
            //        EmployeeID = table.Column<int>(type: "int", nullable: true),
            //        OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ShipVia = table.Column<int>(type: "int", nullable: true),
            //        Freight = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
            //        ShipName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            //        ShipAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
            //        ShipCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        ShipRegion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
            //        ShipPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
            //        ShipCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.OrderID);
            //        table.ForeignKey(
            //            name: "FK_Orders_Customers",
            //            column: x => x.CustomerID,
            //            principalTable: "Customers",
            //            principalColumn: "CustomerID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "City",
            //    table: "Customers",
            //    column: "City");

            //migrationBuilder.CreateIndex(
            //    name: "CompanyName",
            //    table: "Customers",
            //    column: "CompanyName");

            //migrationBuilder.CreateIndex(
            //    name: "PostalCode",
            //    table: "Customers",
            //    column: "PostalCode");

            //migrationBuilder.CreateIndex(
            //    name: "Region",
            //    table: "Customers",
            //    column: "Region");

            //migrationBuilder.CreateIndex(
            //    name: "CustomerID",
            //    table: "Orders",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "CustomersOrders",
            //    table: "Orders",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "EmployeeID",
            //    table: "Orders",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "EmployeesOrders",
            //    table: "Orders",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "OrderDate",
            //    table: "Orders",
            //    column: "OrderDate");

            //migrationBuilder.CreateIndex(
            //    name: "ShippedDate",
            //    table: "Orders",
            //    column: "ShippedDate");

            //migrationBuilder.CreateIndex(
            //    name: "ShippersOrders",
            //    table: "Orders",
            //    column: "ShipVia");

            //migrationBuilder.CreateIndex(
            //    name: "ShipPostalCode",
            //    table: "Orders",
            //    column: "ShipPostalCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
