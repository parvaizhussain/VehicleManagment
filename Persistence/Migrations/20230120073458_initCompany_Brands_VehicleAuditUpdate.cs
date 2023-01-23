using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initCompany_Brands_VehicleAuditUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VehicleSpecifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VehicleSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VehicleSpecifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleSpecifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VehicleSpecifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VehicleSpecifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VehicleCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VehicleCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VehicleCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VehicleCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VehicleCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VehicleBrands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VehicleBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VehicleBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VehicleBrands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VehicleBrands",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VehicleSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VehicleCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VehicleBrands");
        }
    }
}
