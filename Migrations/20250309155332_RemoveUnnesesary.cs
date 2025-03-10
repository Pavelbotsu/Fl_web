using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fl_web.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnesesary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImages_ProductImageModelImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductImageModelImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImageModelImageId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductImageModelImageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImageModelImageId",
                table: "Products",
                column: "ProductImageModelImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImages_ProductImageModelImageId",
                table: "Products",
                column: "ProductImageModelImageId",
                principalTable: "ProductImages",
                principalColumn: "ImageId");
        }
    }
}
