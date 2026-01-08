using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentDynamic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BallToss",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "BallTossNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "BroadJump",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "BroadJumpNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "HopCircuit",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "HopCircuitNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PlankHold",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PlankNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PushUps",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PushUpsNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Run500m",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Run500mNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Sprint20m",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "SprintNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Squats",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "SquatsNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Test505",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Test505Notes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "YBalanceLeft",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "YBalanceLeftNotes",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "YBalanceRight",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "YBalanceRightNotes",
                table: "Assessments");

            migrationBuilder.CreateTable(
                name: "AssessmentField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentField_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentField_AssessmentId",
                table: "AssessmentField",
                column: "AssessmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentField");

            migrationBuilder.AddColumn<int>(
                name: "BallToss",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BallTossNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BroadJump",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BroadJumpNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HopCircuit",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HopCircuitNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlankHold",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlankNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PushUps",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PushUpsNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Run500m",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Run500mNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sprint20m",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SprintNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Squats",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SquatsNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Test505",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test505Notes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YBalanceLeft",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YBalanceLeftNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YBalanceRight",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YBalanceRightNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
