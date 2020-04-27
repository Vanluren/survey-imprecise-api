using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class IntialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Soil = table.Column<int>(nullable: false),
                    Husbandry = table.Column<int>(nullable: false),
                    Nutrients = table.Column<int>(nullable: false),
                    Water = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    Biodiversity = table.Column<int>(nullable: false),
                    Workconditions = table.Column<int>(nullable: false),
                    Lifeequality = table.Column<int>(nullable: false),
                    Economy = table.Column<int>(nullable: false),
                    Management = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "CaseParameters",
                columns: table => new
                {
                    CaseParameterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierId1 = table.Column<int>(nullable: true),
                    CaseId1 = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DescriptionOne = table.Column<string>(nullable: true),
                    DescriptionTwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseParameters", x => x.CaseParameterId);
                    table.ForeignKey(
                        name: "FK_CaseParameters_Cases_CaseId1",
                        column: x => x.CaseId1,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseParameters_Suppliers_SupplierId1",
                        column: x => x.SupplierId1,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseParameters_CaseId1",
                table: "CaseParameters",
                column: "CaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CaseParameters_SupplierId1",
                table: "CaseParameters",
                column: "SupplierId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseParameters");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
