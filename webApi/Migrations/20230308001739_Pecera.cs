using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    public partial class Pecera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peceras",
                columns: table => new
                {
                    PeceraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Pecera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad_Peces = table.Column<int>(type: "int", nullable: false),
                    Capacidad_LitrosAgua = table.Column<int>(type: "int", nullable: false),
                    AcuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peceras", x => x.PeceraID);
                    table.ForeignKey(
                        name: "FK_Peceras_Acuarios_AcuarioID",
                        column: x => x.AcuarioID,
                        principalTable: "Acuarios",
                        principalColumn: "AcuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peceras_AcuarioID",
                table: "Peceras",
                column: "AcuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peceras");
        }
    }
}
