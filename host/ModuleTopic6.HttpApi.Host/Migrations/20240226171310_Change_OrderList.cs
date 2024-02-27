using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTopic6.Migrations
{
    /// <inheritdoc />
    public partial class Change_OrderList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "PurchasingUnit",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "TypeOfImport",
                table: "OrderLists");

            migrationBuilder.RenameColumn(
                name: "WarehouseCode",
                table: "OrderLists",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderLists",
                newName: "WarehouseCode");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderLists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PurchasingUnit",
                table: "OrderLists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfImport",
                table: "OrderLists",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
