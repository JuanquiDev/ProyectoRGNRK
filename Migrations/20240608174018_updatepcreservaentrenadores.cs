using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class updatepcreservaentrenadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Entrenador",
                keyValue: null,
                column: "Entrenador",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Entrenador",
                table: "Reservas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Entrenador",
                table: "Reservas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
