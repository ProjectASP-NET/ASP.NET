using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_DLiquid.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStockQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Vapes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string[]>(
                name: "Flavors",
                table: "Liquids",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Liquids",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Consumables",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Vapes");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Liquids");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Consumables");

            migrationBuilder.AlterColumn<string>(
                name: "Flavors",
                table: "Liquids",
                type: "text",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");
        }
    }
}
