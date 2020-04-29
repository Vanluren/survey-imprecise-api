using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class UpdateIndicator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                            name: "Indicator",
                            table: "CaseParameters",
                            nullable: true,
                            defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                                name: "Score",
                                table: "CaseParameters",
                                nullable: true,
                                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
