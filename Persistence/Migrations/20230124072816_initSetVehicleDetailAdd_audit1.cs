using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initSetVehicleDetailAdd_audit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandID",
                table: "Set_VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Set_VehicleDetails_VehicleBrandID",
                table: "Set_VehicleDetails");

            migrationBuilder.AddColumn<int>(
                name: "VehicleBrandsVehicleBrandId",
                table: "Set_VehicleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Set_VehicleDetails_VehicleBrandID",
                table: "Set_VehicleDetails",
                column: "VehicleBrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandID",
                table: "Set_VehicleDetails",
                column: "VehicleBrandID",
                principalTable: "VehicleBrands",
                principalColumn: "VehicleBrandId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandsVehicleBrandId",
                table: "Set_VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Set_VehicleDetails_VehicleBrandsVehicleBrandId",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "VehicleBrandsVehicleBrandId",
                table: "Set_VehicleDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Set_VehicleDetails_VehicleBrandID",
                table: "Set_VehicleDetails",
                column: "VehicleBrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandID",
                table: "Set_VehicleDetails",
                column: "VehicleBrandID",
                principalTable: "VehicleBrands",
                principalColumn: "VehicleBrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
