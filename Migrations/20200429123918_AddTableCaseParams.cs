using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class AddTableCaseParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "CaseParameters",
                            columns: table => new
                            {
                                CaseParameterId = table.Column<int>(nullable: false)
                                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                                CaseId = table.Column<int>(nullable: true),
                                Title = table.Column<string>(nullable: true),
                                DescriptionOne = table.Column<string>(nullable: true),
                                DescriptionTwo = table.Column<string>(nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_CaseParameters", x => x.CaseParameterId);
                                table.ForeignKey(
                                    name: "FK_CaseParameters_Cases_CaseId",
                                    column: x => x.CaseId,
                                    principalTable: "Cases",
                                    principalColumn: "CaseId",
                                    onDelete: ReferentialAction.Restrict);
                            });
            migrationBuilder.CreateIndex(
       name: "IX_CaseParameters_CaseId",
       table: "CaseParameters",
       column: "CaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
