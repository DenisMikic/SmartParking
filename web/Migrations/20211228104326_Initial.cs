using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_time_TimeID",
                table: "enrollment");

            migrationBuilder.DropTable(
                name: "time");

            migrationBuilder.DropIndex(
                name: "IX_enrollment_TimeID",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "TimeID",
                table: "enrollment");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "enrollment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BusID",
                table: "enrollment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "enrollment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    BusID = table.Column<int>(nullable: false),
                    BusName = table.Column<string>(nullable: true),
                    Passengers = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateEdited = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus", x => x.BusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_BusID",
                table: "enrollment",
                column: "BusID");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_bus_BusID",
                table: "enrollment",
                column: "BusID",
                principalTable: "bus",
                principalColumn: "BusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_bus_BusID",
                table: "enrollment");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropIndex(
                name: "IX_enrollment_BusID",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "BusID",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "enrollment");

            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "time",
                columns: table => new
                {
                    TimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_time", x => x.TimeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_TimeID",
                table: "enrollment",
                column: "TimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_time_TimeID",
                table: "enrollment",
                column: "TimeID",
                principalTable: "time",
                principalColumn: "TimeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
