using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageOO.DAL.Migrations
{
    public partial class Mig_AjoutMecano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mecano",
                columns: table => new
                {
                    IdMecano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Expertise = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Tarif = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MECANO", x => x.IdMecano)
                        .Annotation("SqlServer:Clustered", true);
                    table.CheckConstraint("Chk_minNomLenght", "LEN(Nom)>=2");
                    table.CheckConstraint("Chk_minExpertise", "Expertise>=2");
                });

            migrationBuilder.CreateTable(
                name: "MecanicienEntityVoitureEntity",
                columns: table => new
                {
                    MecaniciensId = table.Column<int>(type: "int", nullable: false),
                    VoituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MecanicienEntityVoitureEntity", x => new { x.MecaniciensId, x.VoituresId });
                    table.ForeignKey(
                        name: "FK_MecanicienEntityVoitureEntity_Car_VoituresId",
                        column: x => x.VoituresId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MecanicienEntityVoitureEntity_Mecano_MecaniciensId",
                        column: x => x.MecaniciensId,
                        principalTable: "Mecano",
                        principalColumn: "IdMecano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MecanicienEntityVoitureEntity_VoituresId",
                table: "MecanicienEntityVoitureEntity",
                column: "VoituresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MecanicienEntityVoitureEntity");

            migrationBuilder.DropTable(
                name: "Mecano");
        }
    }
}
