using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCarBackEnd.Migrations
{
    public partial class ImageNameToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");
        }
    }
}
