using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarmUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarmUpDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrengthBlock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrengthBlockDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgilitySpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgilitySpeedDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HybridEndurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HybridEnduranceDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolDown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolDownDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
