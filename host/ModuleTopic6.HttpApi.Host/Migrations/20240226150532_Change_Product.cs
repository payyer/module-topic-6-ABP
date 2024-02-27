using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTopic6.Migrations
{
    /// <inheritdoc />
    public partial class Change_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchasingUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeOfImport",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WarehouseCode",
                table: "Products",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "WarehouseCode");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PurchasingUnit",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfImport",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
