using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Store_326659356 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caegories_tbl",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Caegorie__19093A0B9BBE4E16", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users_tbl",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users_tb__1788CC4C10880C8F", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products_tbl",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "char(40)", unicode: false, fixedLength: true, maxLength: 40, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__B40CC6CDA774E800", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_tbl_Caegories_tbl",
                        column: x => x.CategoryId,
                        principalTable: "Caegories_tbl",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Orders_tbl",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrderSum = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders_t__C3905BCF386CAE29", x => x.OrderId);
                    table.ForeignKey(
                        name: "fk_OrdersTbl_OrderId",
                        column: x => x.UserId,
                        principalTable: "Users_tbl",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem_tbl",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__57ED0681990DD3BD", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "fk_OrderItemTbl_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_tbl",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "fk_OrderItemTbl_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_tbl",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_tbl_OrderId",
                table: "OrderItem_tbl",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_tbl_ProductId",
                table: "OrderItem_tbl",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_tbl_UserId",
                table: "Orders_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tbl_CategoryId",
                table: "Products_tbl",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem_tbl");

            migrationBuilder.DropTable(
                name: "Orders_tbl");

            migrationBuilder.DropTable(
                name: "Products_tbl");

            migrationBuilder.DropTable(
                name: "Users_tbl");

            migrationBuilder.DropTable(
                name: "Caegories_tbl");
        }
    }
}
