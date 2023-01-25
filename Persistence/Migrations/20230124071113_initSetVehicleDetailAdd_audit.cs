using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initSetVehicleDetailAdd_audit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Set_VehicleDetails",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Set_VehicleDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Set_VehicleDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Set_VehicleDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Set_VehicleDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Set_VehicleDetails",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Set_VehicleDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Set_VehicleDetails");
        }
    }
}
