using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class personalcalendarreservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalCalendarId",
                table: "Reservas",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PersonalCalendars_PersonalCalendarId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_PersonalCalendarId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "PersonalCalendarId",
                table: "Reservas");
        }
    }
}
