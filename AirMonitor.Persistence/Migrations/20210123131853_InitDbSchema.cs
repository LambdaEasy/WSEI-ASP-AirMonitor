using Microsoft.EntityFrameworkCore.Migrations;

namespace AirMonitor.Persistence.Migrations
{
    public partial class InitDbSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstallationAddress",
                columns: table => new
                {
                    InstallationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayAddress1 = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DisplayAddress2 = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallationAddress", x => x.InstallationId);
                });

            migrationBuilder.CreateTable(
                name: "InstallationSponsor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUri = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    LinkUri = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallationSponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Installations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false),
                    IsAirly = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Elevation = table.Column<float>(type: "real", nullable: false),
                    AddressInstallationId = table.Column<long>(type: "bigint", nullable: true),
                    SponsorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installations_InstallationAddress_AddressInstallationId",
                        column: x => x.AddressInstallationId,
                        principalTable: "InstallationAddress",
                        principalColumn: "InstallationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installations_InstallationSponsor_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "InstallationSponsor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installations_AddressInstallationId",
                table: "Installations",
                column: "AddressInstallationId");

            migrationBuilder.CreateIndex(
                name: "IX_Installations_SponsorId",
                table: "Installations",
                column: "SponsorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installations");

            migrationBuilder.DropTable(
                name: "InstallationAddress");

            migrationBuilder.DropTable(
                name: "InstallationSponsor");
        }
    }
}
