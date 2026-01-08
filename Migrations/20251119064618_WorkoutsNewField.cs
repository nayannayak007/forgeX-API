using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutsNewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "WorkoutCompletions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "WorkoutCompletions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "WorkoutCompletions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "WorkoutCompletions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "WorkoutCompletions");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "WorkoutCompletions");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "WorkoutCompletions");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "WorkoutCompletions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
