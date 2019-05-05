using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCarBackEnd.Migrations
{
    public partial class TypeOfIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfIdId",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOfId",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfId", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeOfId",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Identification Card" });

            migrationBuilder.InsertData(
                table: "TypeOfId",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Passport" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeOfIdId",
                table: "Clients",
                column: "TypeOfIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_TypeOfId_TypeOfIdId",
                table: "Clients",
                column: "TypeOfIdId",
                principalTable: "TypeOfId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_TypeOfId_TypeOfIdId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "TypeOfId");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TypeOfIdId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TypeOfIdId",
                table: "Clients");
        }
    }
}
