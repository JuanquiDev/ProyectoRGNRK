using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class changesBenchmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Benchmarks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Benchmarks");
        }
    }
}
