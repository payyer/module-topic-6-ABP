using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleTopic6.Migrations
{
    /// <inheritdoc />
    public partial class Change_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreTaxMoney",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PreTaxMoney",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
