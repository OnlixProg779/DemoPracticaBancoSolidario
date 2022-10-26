using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoSolidario.InfrastructurePlanAhorro.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiempoPlanDeAhorro",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Meses = table.Column<int>(type: "int", nullable: false),
                    TasaDeInteresAnual = table.Column<float>(type: "real", nullable: false),
                    TipoDeInteres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Editable = table.Column<bool>(type: "bit", nullable: false),
                    Borrable = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ShowToUserMed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiempoPlanDeAhorro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanAhorro",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoDeAhorro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoPlanDeAhorroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Editable = table.Column<bool>(type: "bit", nullable: false),
                    Borrable = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ShowToUserMed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAhorro", x => x.Id);
                    table.ForeignKey(
                        name: "Ref_PlanesDeAhorro_to_TiempoPlanAhorro",
                        column: x => x.TiempoPlanDeAhorroId,
                        principalTable: "TiempoPlanDeAhorro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanAhorro_TiempoPlanDeAhorroId",
                table: "PlanAhorro",
                column: "TiempoPlanDeAhorroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanAhorro");

            migrationBuilder.DropTable(
                name: "TiempoPlanDeAhorro");
        }
    }
}
