using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParameterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Indicator = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Score = table.Column<int>(nullable: false),
                    DescriptionOne = table.Column<string>(nullable: true),
                    DescriptionTwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Respondants",
                columns: table => new
                {
                    RespondantId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Occupation = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondants", x => x.RespondantId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Soil = table.Column<int>(nullable: true),
                    Husbandry = table.Column<int>(nullable: true),
                    Nutrients = table.Column<int>(nullable: true),
                    Water = table.Column<int>(nullable: true),
                    Energy = table.Column<int>(nullable: true),
                    Biodiversity = table.Column<int>(nullable: true),
                    Workconditions = table.Column<int>(nullable: true),
                    Lifequality = table.Column<int>(nullable: true),
                    Economy = table.Column<int>(nullable: true),
                    Management = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "CaseParameters",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false),
                    ParameterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseParameters", x => new { x.CaseId, x.ParameterId });
                    table.ForeignKey(
                        name: "FK_CaseParameters_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCases",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    CaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCases", x => new { x.QuestionId, x.CaseId });
                    table.ForeignKey(
                        name: "FK_QuestionCases_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RespondantId = table.Column<int>(nullable: true),
                    ChosenCaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Respondants_RespondantId",
                        column: x => x.RespondantId,
                        principalTable: "Respondants",
                        principalColumn: "RespondantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResponseId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Responses",
                        principalColumn: "ResponseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseParameters_ParameterId",
                table: "CaseParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ResponseId",
                table: "Cases",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SupplierId",
                table: "Cases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCases_CaseId",
                table: "QuestionCases",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ChosenCaseId",
                table: "Responses",
                column: "ChosenCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RespondantId",
                table: "Responses",
                column: "RespondantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseParameters_Cases_CaseId",
                table: "CaseParameters",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionCases_Cases_CaseId",
                table: "QuestionCases",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Cases_ChosenCaseId",
                table: "Responses",
                column: "ChosenCaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Cases_ChosenCaseId",
                table: "Responses");

            migrationBuilder.DropTable(
                name: "CaseParameters");

            migrationBuilder.DropTable(
                name: "QuestionCases");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Respondants");
        }
    }
}
