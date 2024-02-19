using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GodzillaRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class FoodTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "FoodType",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "FoodType");
        }
    }
}
