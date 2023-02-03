using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitVehicleRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleRequests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HODApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPDF = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PickFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRequests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_VehicleRequests_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRequests_RegionID",
                table: "VehicleRequests",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRequests");
        }
    }
}
