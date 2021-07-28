using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class managerprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductsId",
                table: "LineItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Manager",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "ProductsId",
                table: "LineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductsId",
                table: "LineItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
