using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class YBalanceChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YBalanceDir",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "YBalance",
                table: "Assessments",
                newName: "YBalanceRight");

            migrationBuilder.AddColumn<decimal>(
                name: "YBalanceLeft",
                table: "Assessments",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YBalanceLeft",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "YBalanceRight",
                table: "Assessments",
                newName: "YBalance");

            migrationBuilder.AddColumn<string>(
                name: "YBalanceDir",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
