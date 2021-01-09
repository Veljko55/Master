using Microsoft.EntityFrameworkCore.Migrations;

namespace SCADA.Migrations
{
    public partial class renameBreakerValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOpet",
                table: "Breakers",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Breakers",
                newName: "IsOpet");
        }
    }
}
