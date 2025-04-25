using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Project.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTimeSlotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Descreption",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Descreption",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Available = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
