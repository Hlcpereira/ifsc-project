using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class PharmaceuticalHasHealthunit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_pharmaceutical_health_unit_id",
                schema: "public",
                table: "pharmaceutical",
                column: "health_unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pharmaceutical_health_nit_health_unit_id",
                schema: "public",
                table: "pharmaceutical",
                column: "health_unit_id",
                principalSchema: "public",
                principalTable: "health_nit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pharmaceutical_health_nit_health_unit_id",
                schema: "public",
                table: "pharmaceutical");

            migrationBuilder.DropIndex(
                name: "IX_pharmaceutical_health_unit_id",
                schema: "public",
                table: "pharmaceutical");
        }
    }
}
