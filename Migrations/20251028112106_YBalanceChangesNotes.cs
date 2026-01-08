using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class YBalanceChangesNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YBalanceNotes",
                table: "Assessments",
                newName: "YBalanceRightNotes");

            migrationBuilder.AddColumn<string>(
                name: "YBalanceLeftNotes",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YBalanceLeftNotes",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "YBalanceRightNotes",
                table: "Assessments",
                newName: "YBalanceNotes");
        }
    }
}
