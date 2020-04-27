using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class UpdateCaseParameterCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CaseParameters");

            migrationBuilder.AddColumn<int>(
                name: "Indicator",
                table: "CaseParameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "CaseParameters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Indicator",
                table: "CaseParameters");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "CaseParameters");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CaseParameters",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
