using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeightCm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bmi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentRollNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    DominantHandFoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentSport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyScreenTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakenOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sprint20m = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlankHold = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PushUps = table.Column<int>(type: "int", nullable: true),
                    Squats = table.Column<int>(type: "int", nullable: true),
                    YBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BallToss = table.Column<int>(type: "int", nullable: true),
                    HopCircuit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Run500m = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BroadJump = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Test505 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SprintNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlankNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PushUpsNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SquatsNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YBalanceNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BallTossNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HopCircuitNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Run500mNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BroadJumpNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test505Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    RecordedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ClassId",
                table: "Assessments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_PlayerId",
                table: "Assessments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PlayerId",
                table: "Attendance",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClassId",
                table: "Players",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
