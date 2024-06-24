using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESC.AdministrationCore.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class NorthWind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Products",
                newName: "ProductDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                schema: "dbo",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "dbo",
                table: "Products",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuantityPerUnit",
                schema: "dbo",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ReorderLevel",
                schema: "dbo",
                table: "Products",
                type: "smallint",
                nullable: true,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "dbo",
                table: "Products",
                type: "money",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<short>(
                name: "UnitsInStock",
                schema: "dbo",
                table: "Products",
                type: "smallint",
                nullable: true,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "UnitsOnOrder",
                schema: "dbo",
                table: "Products",
                type: "smallint",
                nullable: true,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Picture = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                schema: "dbo",
                columns: table => new
                {
                    CustomerTypeID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    CustomerDesc = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDemographics", x => x.CustomerTypeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    ReportsTo = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Employees",
                        column: x => x.ReportsTo,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "dbo",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                schema: "dbo",
                columns: table => new
                {
                    ShipperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "dbo",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    HomePage = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    CustomerTypeID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerDemo", x => new { x.CustomerId, x.CustomerTypeID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo",
                        column: x => x.CustomerTypeID,
                        principalSchema: "dbo",
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerTypeID");
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_Customers",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                schema: "dbo",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_Territories_Region_RegionID",
                        column: x => x.RegionID,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipVia = table.Column<int>(type: "int", nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true, defaultValue: 0m),
                    ShipName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Orders_Shippers",
                        column: x => x.ShipVia,
                        principalSchema: "dbo",
                        principalTable: "Shippers",
                        principalColumn: "ShipperId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TerritoryID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTerritories", x => new { x.EmployeeId, x.TerritoryID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Employees",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Territories",
                        column: x => x.TerritoryID,
                        principalSchema: "dbo",
                        principalTable: "Territories",
                        principalColumn: "TerritoryID");
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_Order_Details_Products",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                schema: "dbo",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "CategoryName",
                schema: "dbo",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeID",
                schema: "dbo",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "City",
                schema: "dbo",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                schema: "dbo",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                schema: "dbo",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "Region",
                schema: "dbo",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                schema: "dbo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "LastName",
                schema: "dbo",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                schema: "dbo",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                schema: "dbo",
                table: "EmployeeTerritories",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "OrderId",
                schema: "dbo",
                table: "Order Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "OrdersOrder_Details",
                schema: "dbo",
                table: "Order Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                schema: "dbo",
                table: "Order Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "ProductsOrder_Details",
                schema: "dbo",
                table: "Order Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "CustomerId",
                schema: "dbo",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "CustomersOrders",
                schema: "dbo",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "EmployeeId",
                schema: "dbo",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "EmployeesOrders",
                schema: "dbo",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "OrderDate",
                schema: "dbo",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "ShippedDate",
                schema: "dbo",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "ShippersOrders",
                schema: "dbo",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "ShipPostalCode",
                schema: "dbo",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                schema: "dbo",
                table: "Supplier",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                schema: "dbo",
                table: "Supplier",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionID",
                schema: "dbo",
                table: "Territories",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories",
                schema: "dbo",
                table: "Products",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers",
                schema: "dbo",
                table: "Products",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "Supplier",
                principalColumn: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order Details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerDemographics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Territories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Shippers",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discontinued",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityPerUnit",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReorderLevel",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitsInStock",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitsOnOrder",
                schema: "dbo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                schema: "dbo",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "Products",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
