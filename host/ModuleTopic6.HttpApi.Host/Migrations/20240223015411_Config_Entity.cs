using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTopic6.Migrations
{
    /// <inheritdoc />
    public partial class Config_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderList_Order_OrderId",
                table: "OrderList");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderList_Products_ProductId",
                table: "OrderList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderList",
                table: "OrderList");

            migrationBuilder.DropIndex(
                name: "IX_OrderList_ProductId",
                table: "OrderList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderList",
                newName: "OrderLists");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderList_OrderId",
                table: "OrderLists",
                newName: "IX_OrderLists_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLists",
                table: "OrderLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLists_Orders_OrderId",
                table: "OrderLists",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_Orders_OrderId",
                table: "OrderLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLists",
                table: "OrderLists");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderLists",
                newName: "OrderList");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLists_OrderId",
                table: "OrderList",
                newName: "IX_OrderList_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderList",
                table: "OrderList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_ProductId",
                table: "OrderList",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderList_Order_OrderId",
                table: "OrderList",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderList_Products_ProductId",
                table: "OrderList",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
