using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageOO.DAL.Migrations
{
    public partial class Mig_AjoutUniqueSurPLaque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Plaque",
                table: "Car");

            migrationBuilder.CreateIndex(
                name: "UK_Plaque",
                table: "Car",
                column: "Plaque",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Plaque",
                table: "Car");

            migrationBuilder.CreateIndex(
                name: "UK_Plaque",
                table: "Car",
                column: "Plaque");
        }
    }
}
