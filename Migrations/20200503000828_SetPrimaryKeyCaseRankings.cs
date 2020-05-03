using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class SetPrimaryKeyCaseRankings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseRankings",
                table: "CaseRankings",
                columns: new[] { "CaseId", "RankingId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseRankings",
                table: "CaseRankings");
        }
    }
}
