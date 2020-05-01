using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class SetPrimaryKeyReposnses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey("PRIMARY", "Responses", "ResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
