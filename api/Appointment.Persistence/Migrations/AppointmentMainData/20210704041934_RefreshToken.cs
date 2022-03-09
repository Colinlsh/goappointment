using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment.Persistence.Migrations.AppointmentMainData
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantConfiguration_TenantMapping_TenantFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration");

            migrationBuilder.DropColumn(
                name: "TenantIdentifier",
                schema: "AppointmentMain",
                table: "TenantMapping");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshToken",
                newSchema: "AppointmentMain");

            migrationBuilder.RenameColumn(
                name: "TenantFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                newName: "TenantMappingFK");

            migrationBuilder.RenameIndex(
                name: "IX_TenantConfiguration_TenantFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                newName: "IX_TenantConfiguration_TenantMappingFK");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantConfiguration_TenantMapping_TenantMappingFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                column: "TenantMappingFK",
                principalSchema: "AppointmentMain",
                principalTable: "TenantMapping",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantConfiguration_TenantMapping_TenantMappingFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                schema: "AppointmentMain",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "TenantMappingFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                newName: "TenantFK");

            migrationBuilder.RenameIndex(
                name: "IX_TenantConfiguration_TenantMappingFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                newName: "IX_TenantConfiguration_TenantFK");

            migrationBuilder.AddColumn<string>(
                name: "TenantIdentifier",
                schema: "AppointmentMain",
                table: "TenantMapping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantConfiguration_TenantMapping_TenantFK",
                schema: "AppointmentMain",
                table: "TenantConfiguration",
                column: "TenantFK",
                principalSchema: "AppointmentMain",
                principalTable: "TenantMapping",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
