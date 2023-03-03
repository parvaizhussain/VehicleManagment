using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init_VehicleRequest_DAte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "Request",
                table: "VehicleRequests",
                newName: "RequestDate");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCenters_VehicleCompanies_VehicleCompanyID",
                table: "ServiceCenters");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "VehicleRequests",
                newName: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleCompanyID",
                table: "ServiceCenters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DealerID",
                table: "ServiceCenters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCenters_VehicleCompanies_VehicleCompanyID",
                table: "ServiceCenters",
                column: "VehicleCompanyID",
                principalTable: "VehicleCompanies",
                principalColumn: "VehicleCompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
