using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArthitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                schema: "Sample",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupDate",
                schema: "Sample",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                schema: "Sample",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                schema: "Sample",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OldPrice",
                schema: "Sample",
                table: "OrderDetails",
                newName: "TotalPrice");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "Sample",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Sample",
                table: "OrderDetails",
                column: "OrderId",
                principalSchema: "Sample",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Sample",
                table: "OrderDetails",
                column: "ProductId",
                principalSchema: "Sample",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Sample",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "Sample",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Sample",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "Sample",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                schema: "Sample",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OldPrice");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderID");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupDate",
                schema: "Sample",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "NewPrice",
                schema: "Sample",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                schema: "Sample",
                table: "OrderDetails",
                column: "OrderID",
                principalSchema: "Sample",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                schema: "Sample",
                table: "OrderDetails",
                column: "ProductID",
                principalSchema: "Sample",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                schema: "Sample",
                table: "Orders",
                column: "CustomerID",
                principalSchema: "Sample",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
