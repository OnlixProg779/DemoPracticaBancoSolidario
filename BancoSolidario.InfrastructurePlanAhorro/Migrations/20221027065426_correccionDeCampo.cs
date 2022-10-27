using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoSolidario.InfrastructurePlanAhorro.Migrations
{
    public partial class correccionDeCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "MontoDeAhorro",
                table: "PlanAhorro",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MontoDeAhorro",
                table: "PlanAhorro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
