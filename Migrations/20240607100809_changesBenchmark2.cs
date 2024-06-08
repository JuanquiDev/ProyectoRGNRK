using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class changesBenchmark2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchmarkExercise");

            migrationBuilder.RenameColumn(
                name: "personalRecords",
                table: "Benchmarks",
                newName: "PersonalRecords");

            migrationBuilder.CreateIndex(
                name: "IX_Benchmarks_ExerciseId",
                table: "Benchmarks",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benchmarks_Exercises_ExerciseId",
                table: "Benchmarks",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benchmarks_Exercises_ExerciseId",
                table: "Benchmarks");

            migrationBuilder.DropIndex(
                name: "IX_Benchmarks_ExerciseId",
                table: "Benchmarks");

            migrationBuilder.RenameColumn(
                name: "PersonalRecords",
                table: "Benchmarks",
                newName: "personalRecords");

            migrationBuilder.CreateTable(
                name: "BenchmarkExercise",
                columns: table => new
                {
                    BenchmarksId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchmarkExercise", x => new { x.BenchmarksId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_BenchmarkExercise_Benchmarks_BenchmarksId",
                        column: x => x.BenchmarksId,
                        principalTable: "Benchmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenchmarkExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BenchmarkExercise_ExerciseId",
                table: "BenchmarkExercise",
                column: "ExerciseId");
        }
    }
}
