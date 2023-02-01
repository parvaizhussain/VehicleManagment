using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initService_Maintainace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandID",
            //    table: "Set_VehicleDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_Set_VehicleDetails_VehicleBrandID",
            //    table: "Set_VehicleDetails");

            //migrationBuilder.AddColumn<int>(
            //    name: "VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaintainaceHistories",
                columns: table => new
                {
                    MaintainaceHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainaceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintainaceDateForm = table.Column<DateTime>(type: "date", nullable: false),
                    MaintainaceDateTo = table.Column<DateTime>(type: "date", nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintainaceHistories", x => x.MaintainaceHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenters",
                columns: table => new
                {
                    ServiceCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealerType = table.Column<bool>(type: "bit", nullable: false),
                    DealerID = table.Column<int>(type: "int", nullable: false),
                    //VehicleCompanyID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenters", x => x.ServiceCenterId);
                    table.ForeignKey(
                        name: "FK_ServiceCenters_VehicleCompanies_DealerID",
                        column: x => x.DealerID,
                        principalTable: "VehicleCompanies",
                        principalColumn: "VehicleCompanyID");
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Set_VehicleDetails_VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails",
            //    column: "VehicleBrandsVehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenters_DealerID",
                table: "ServiceCenters",
                column: "DealerID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails",
            //    column: "VehicleBrandsVehicleBrandId",
            //    principalTable: "VehicleBrands",
            //    principalColumn: "VehicleBrandId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails");

            //migrationBuilder.DropTable(
            //    name: "MaintainaceHistories");

            //migrationBuilder.DropTable(
            //    name: "ServiceCenters");

            //migrationBuilder.DropIndex(
            //    name: "IX_Set_VehicleDetails_VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails");

            //migrationBuilder.DropColumn(
            //    name: "VehicleBrandsVehicleBrandId",
            //    table: "Set_VehicleDetails");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Set_VehicleDetails_VehicleBrandID",
            //    table: "Set_VehicleDetails",
            //    column: "VehicleBrandID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Set_VehicleDetails_VehicleBrands_VehicleBrandID",
            //    table: "Set_VehicleDetails",
            //    column: "VehicleBrandID",
            //    principalTable: "VehicleBrands",
            //    principalColumn: "VehicleBrandId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
