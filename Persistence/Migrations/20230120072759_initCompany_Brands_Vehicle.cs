using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initCompany_Brands_Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "VehicleSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VehicleBrandID",
                table: "VehicleSpecifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "VehicleSpecifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleCompanyId",
                table: "VehicleSpecifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Region",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Network",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Group",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "City",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Branch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "VehicleCompanies",
                columns: table => new
                {
                    VehicleCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCompanies", x => x.VehicleCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleBrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.VehicleBrandId);
                    table.ForeignKey(
                        name: "FK_VehicleBrands_VehicleCompanies_VehicleCompanyId",
                        column: x => x.VehicleCompanyId,
                        principalTable: "VehicleCompanies",
                        principalColumn: "VehicleCompanyID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecifications_VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications",
                column: "VehicleBrandsVehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecifications_VehicleCompanyId",
                table: "VehicleSpecifications",
                column: "VehicleCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrands_VehicleCompanyId",
                table: "VehicleBrands",
                column: "VehicleCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSpecifications_VehicleBrands_VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications",
                column: "VehicleBrandsVehicleBrandId",
                principalTable: "VehicleBrands",
                principalColumn: "VehicleBrandId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSpecifications_VehicleCompanies_VehicleCompanyId",
                table: "VehicleSpecifications",
                column: "VehicleCompanyId",
                principalTable: "VehicleCompanies",
                principalColumn: "VehicleCompanyID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSpecifications_VehicleBrands_VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSpecifications_VehicleCompanies_VehicleCompanyId",
                table: "VehicleSpecifications");

            migrationBuilder.DropTable(
                name: "VehicleBrands");

            migrationBuilder.DropTable(
                name: "VehicleCompanies");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSpecifications_VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSpecifications_VehicleCompanyId",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "VehicleBrandID",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "VehicleBrandsVehicleBrandId",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "VehicleColor",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "VehicleCompanyId",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Network");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "City");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Branch");
        }
    }
}
