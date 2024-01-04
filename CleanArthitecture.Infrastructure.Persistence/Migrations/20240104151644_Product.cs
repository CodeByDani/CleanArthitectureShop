using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArthitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderID",
                schema: "Sample",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AmountDiscount",
                schema: "Sample",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                schema: "Sample",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                schema: "Sample",
                table: "OrderDetails",
                column: "OrderID",
                principalSchema: "Sample",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderID",
                schema: "Sample",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderID",
                schema: "Sample",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddColumn<double>(
                name: "AmountDiscount",
                schema: "Sample",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                schema: "Sample",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                schema: "Sample",
                table: "Payment",
                column: "OrderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Sample",
                table: "OrderDetails",
                column: "OrderId",
                principalSchema: "Sample",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
