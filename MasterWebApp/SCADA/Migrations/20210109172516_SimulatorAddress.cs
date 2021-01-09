using Microsoft.EntityFrameworkCore.Migrations;

namespace SCADA.Migrations
{
    public partial class SimulatorAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SimulatorAddress",
                table: "Breakers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SimulatorAddress",
                table: "Breakers");
        }
    }
}
