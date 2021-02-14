using Microsoft.EntityFrameworkCore.Migrations;

namespace AirMonitor.Persistence.Migrations
{
    public partial class AddExternalIdToMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InstallationExternalId",
                table: "Measurement",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallationExternalId",
                table: "Measurement");
        }
    }
}
