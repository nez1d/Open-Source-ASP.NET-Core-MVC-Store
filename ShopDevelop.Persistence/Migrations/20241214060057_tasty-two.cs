using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDevelop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tastytwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seller_SellerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Seller");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Sellers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Sellers",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Sellers",
                newName: "ImageFooterPath");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Sellers",
                newName: "Description");

            migrationBuilder.AlterColumn<decimal>(
                name: "OldPrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Article",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Seller",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Seller",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ImageFooterPath",
                table: "Seller",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Seller",
                newName: "LastName");

            migrationBuilder.AlterColumn<decimal>(
                name: "OldPrice",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Article",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Seller",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Seller_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
