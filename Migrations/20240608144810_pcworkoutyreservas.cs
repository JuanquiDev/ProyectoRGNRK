using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class pcworkoutyreservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PersonalCalendars_PersonalCalendarId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_PersonalCalendars_PersonalCalendarId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_PersonalCalendarId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_PersonalCalendarId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "PersonalCalendarId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "PersonalCalendarId",
                table: "Reservas");

            migrationBuilder.CreateTable(
                name: "PersonalCalendarReservas",
                columns: table => new
                {
                    PersonalCalendarId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalCalendarReservas", x => new { x.PersonalCalendarId, x.ReservaId });
                    table.ForeignKey(
                        name: "FK_PersonalCalendarReservas_PersonalCalendars_PersonalCalendarId",
                        column: x => x.PersonalCalendarId,
                        principalTable: "PersonalCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalCalendarReservas_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonalCalendarWorkouts",
                columns: table => new
                {
                    PersonalCalendarId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalCalendarWorkouts", x => new { x.PersonalCalendarId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_PersonalCalendarWorkouts_PersonalCalendars_PersonalCalendarId",
                        column: x => x.PersonalCalendarId,
                        principalTable: "PersonalCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalCalendarWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalCalendarReservas_ReservaId",
                table: "PersonalCalendarReservas",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalCalendarWorkouts_WorkoutId",
                table: "PersonalCalendarWorkouts",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalCalendarReservas");

            migrationBuilder.DropTable(
                name: "PersonalCalendarWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "PersonalCalendarId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalCalendarId",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_PersonalCalendarId",
                table: "Workouts",
                column: "PersonalCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PersonalCalendarId",
                table: "Reservas",
                column: "PersonalCalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PersonalCalendars_PersonalCalendarId",
                table: "Reservas",
                column: "PersonalCalendarId",
                principalTable: "PersonalCalendars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_PersonalCalendars_PersonalCalendarId",
                table: "Workouts",
                column: "PersonalCalendarId",
                principalTable: "PersonalCalendars",
                principalColumn: "Id");
        }
    }
}
