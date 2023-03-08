using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitBookingAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BookingMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BookingMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BookingMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BookingMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "BookingMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "BookingMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BookingDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BookingDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BookingDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BookingDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "BookingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "BookingDetail",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "BookingMasters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "BookingDetail");
        }
    }
}
