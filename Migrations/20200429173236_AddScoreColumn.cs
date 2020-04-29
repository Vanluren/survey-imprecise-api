using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class AddScoreColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Indicator",
                table: "CaseParameters",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                            name: "Score",
                            table: "CaseParameters",
                            nullable: true,
                            defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Indicator",
                table: "CaseParameters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
