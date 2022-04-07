using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageOO.DAL.Migrations
{
    public partial class Mig_AjoutVoiture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaque = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbRoues = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    NbPortes = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    CapaciteCoffre = table.Column<double>(type: "float", nullable: false),
                    NbSiege = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Voiture", x => x.Id);
                    table.CheckConstraint("Chk_NbRoues", "NbRoues>=2 AND NbRoues<=4");
                    table.CheckConstraint("Chk_Portes", "NbPortes>=3 AND NbPortes<=5");
                    table.CheckConstraint("Chk_Siege", "NbSiege>=2 AND NbSiege<=8");
                    table.CheckConstraint("Chk_PlaqueCD", "UPPER(Plaque) not like 'CD%'");
                    table.CheckConstraint("Chk_PlaqueFormat", "Plaque like '_-___-___'");
                },
                comment: "Nous considérons qu'une voiture ne peut pas avoir plus de 4 roues");

            migrationBuilder.CreateIndex(
                name: "UK_Plaque",
                table: "Car",
                column: "Plaque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
