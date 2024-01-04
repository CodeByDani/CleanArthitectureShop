using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArthitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryID",
                schema: "Sample",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                schema: "Sample",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryID",
                schema: "Sample",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Sample",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Sample",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Sample",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "Sample",
                table: "Products",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                schema: "Sample",
                table: "Products",
                newName: "IX_Products_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryID",
                schema: "Sample",
                table: "Products",
                column: "CategoryID",
                principalSchema: "Sample",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
