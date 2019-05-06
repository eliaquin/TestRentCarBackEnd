using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCarBackEnd.Migrations
{
    public partial class TypeOfIdConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypeOfId",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Driver's License");

            migrationBuilder.InsertData(
                table: "TypeOfId",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeOfId",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "TypeOfId",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Identification Card");
        }
    }
}
