using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Infra.Data.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                schema: "dbo",
                table: "Person",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_City_CityId",
                schema: "dbo",
                table: "Person",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_City_CityId",
                schema: "dbo",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CityId",
                schema: "dbo",
                table: "Person");
        }
    }
}
