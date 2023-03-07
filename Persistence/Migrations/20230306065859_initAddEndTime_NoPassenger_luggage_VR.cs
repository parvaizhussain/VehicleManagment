using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initAddEndTime_NoPassenger_luggage_VR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLuggage",
                table: "VehicleRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoOfPassanger",
                table: "VehicleRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RequestEndTime",
                table: "VehicleRequests",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLuggage",
                table: "VehicleRequests");

            migrationBuilder.DropColumn(
                name: "NoOfPassanger",
                table: "VehicleRequests");

            migrationBuilder.DropColumn(
                name: "RequestEndTime",
                table: "VehicleRequests");
        }
    }
}
