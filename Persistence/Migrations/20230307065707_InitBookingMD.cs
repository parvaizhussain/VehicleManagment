using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitBookingMD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingMasters",
                columns: table => new
                {
                    BookingMID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    FuelCardID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentKM = table.Column<int>(type: "int", nullable: false),
                    ArrivedKM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingMasters", x => x.BookingMID);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingMID = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    BookingMasterBookingMID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.BookingDID);
                    table.ForeignKey(
                        name: "FK_BookingDetail_BookingMasters_BookingMasterBookingMID",
                        column: x => x.BookingMasterBookingMID,
                        principalTable: "BookingMasters",
                        principalColumn: "BookingMID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_BookingMasterBookingMID",
                table: "BookingDetail",
                column: "BookingMasterBookingMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "BookingMasters");
        }
    }
}
