using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDevelop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    ImageFooterPath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<double>(type: "double precision", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ImageFooterPath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", maxLength: 15, nullable: false),
                    OldPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Article = table.Column<long>(type: "bigint", maxLength: 9, nullable: false),
                    InStock = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ImageMiniPath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Rating = table.Column<double>(type: "double precision", maxLength: 4, nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDedails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sizes = table.Column<string[]>(type: "text[]", nullable: false),
                    Composition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDedails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDedails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDedails_ProductId",
                table: "ProductDedails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ApplicationUserId",
                table: "ShoppingCartItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductDedails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
