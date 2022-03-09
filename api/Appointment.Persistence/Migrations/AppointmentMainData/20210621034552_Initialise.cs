using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment.Persistence.Migrations.AppointmentMainData
{
    public partial class Initialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AppointmentMain");

            migrationBuilder.CreateTable(
                name: "CTCountry",
                schema: "AppointmentMain",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    PhoneCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CTOccupation",
                schema: "AppointmentMain",
                columns: table => new
                {
                    OccupationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTOccupation", x => x.OccupationId);
                });

            migrationBuilder.CreateTable(
                name: "CTRace",
                schema: "AppointmentMain",
                columns: table => new
                {
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IRISCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTRace", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "CTRelationship",
                schema: "AppointmentMain",
                columns: table => new
                {
                    RelationshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTRelationship", x => x.RelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "CTReligion",
                schema: "AppointmentMain",
                columns: table => new
                {
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTReligion", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "TenantMapping",
                schema: "AppointmentMain",
                columns: table => new
                {
                    TenantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DBUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantIndex = table.Column<int>(type: "int", nullable: false),
                    HeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMobileEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMapping", x => x.TenantID);
                });

            migrationBuilder.CreateTable(
                name: "TenantConfiguration",
                schema: "AppointmentMain",
                columns: table => new
                {
                    TenantConfigurationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KioskTenantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KioskTenantName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantConfiguration", x => x.TenantConfigurationID);
                    table.ForeignKey(
                        name: "FK_TenantConfiguration_TenantMapping_TenantFK",
                        column: x => x.TenantFK,
                        principalSchema: "AppointmentMain",
                        principalTable: "TenantMapping",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantConfiguration_TenantFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                column: "TenantFK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTCountry",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "CTOccupation",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "CTRace",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "CTRelationship",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "CTReligion",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "TenantConfiguration",
                schema: "AppointmentMain");

            migrationBuilder.DropTable(
                name: "TenantMapping",
                schema: "AppointmentMain");
        }
    }
}
