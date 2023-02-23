using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initServiceCenteraddMaintain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceCenterId",
                table: "MaintainaceHistories",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_MaintainaceHistories_ServiceCenterId",
                table: "MaintainaceHistories",
                column: "ServiceCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintainaceHistories_ServiceCenters_ServiceCenterId",
                table: "MaintainaceHistories",
                column: "ServiceCenterId",
                principalTable: "ServiceCenters",
                principalColumn: "ServiceCenterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintainaceHistories_ServiceCenters_ServiceCenterId",
                table: "MaintainaceHistories");

            migrationBuilder.DropIndex(
                name: "IX_MaintainaceHistories_ServiceCenterId",
                table: "MaintainaceHistories");

            migrationBuilder.DropColumn(
                name: "ServiceCenterId",
                table: "MaintainaceHistories");
        }
    }
}
