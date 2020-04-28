using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_imprecise_api.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "CaseParameters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseParameters_SupplierId",
                table: "CaseParameters",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseParameters_Suppliers_SupplierId",
                table: "CaseParameters",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseParameters_Suppliers_SupplierId",
                table: "CaseParameters");

            migrationBuilder.DropIndex(
                name: "IX_CaseParameters_SupplierId",
                table: "CaseParameters");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "CaseParameters");
        }
    }
}
