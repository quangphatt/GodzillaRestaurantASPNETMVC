using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GodzillaRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class FoodUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Food",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Food");
        }
    }
}
