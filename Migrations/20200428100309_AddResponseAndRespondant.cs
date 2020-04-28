using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class AddResponseAndRespondant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Cases",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Respondants",
                columns: table => new
                {
                    RespondantId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Occupation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondants", x => x.RespondantId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RespondantId = table.Column<int>(nullable: true),
                    ChosenCaseCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Cases_ChosenCaseCaseId",
                        column: x => x.ChosenCaseCaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Responses_Respondants_RespondantId",
                        column: x => x.RespondantId,
                        principalTable: "Respondants",
                        principalColumn: "RespondantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ResponseId",
                table: "Cases",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ChosenCaseCaseId",
                table: "Responses",
                column: "ChosenCaseCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RespondantId",
                table: "Responses",
                column: "RespondantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Responses_ResponseId",
                table: "Cases",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "ResponseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Responses_ResponseId",
                table: "Cases");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Respondants");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ResponseId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Cases");
        }
    }
}
