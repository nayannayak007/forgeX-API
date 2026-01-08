using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeXAPI.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentDynamicLabelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "AssessmentField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "AssessmentField");
        }
    }
}
