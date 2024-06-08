using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGNRK.Migrations
{
    /// <inheritdoc />
    public partial class changesBenchmark3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Benchmarks",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Benchmarks_UserId",
                table: "Benchmarks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benchmarks_AspNetUsers_UserId",
                table: "Benchmarks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benchmarks_AspNetUsers_UserId",
                table: "Benchmarks");

            migrationBuilder.DropIndex(
                name: "IX_Benchmarks_UserId",
                table: "Benchmarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Benchmarks");
        }
    }
}
