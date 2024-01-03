using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArthitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class change1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMage",
                schema: "Sample",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "Sample",
                table: "OrderDetails",
                newName: "OldPrice");

            migrationBuilder.AddColumn<double>(
                name: "NewPrice",
                schema: "Sample",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sample",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "Sample",
                table: "Category",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_Name",
                schema: "Sample",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                schema: "Sample",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OldPrice",
                schema: "Sample",
                table: "OrderDetails",
                newName: "Price");

            migrationBuilder.AddColumn<byte[]>(
                name: "IMage",
                schema: "Sample",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Sample",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
