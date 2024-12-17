using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class PrescriptionIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_medicine_control_prescription_url",
                schema: "public",
                table: "medicine_control",
                column: "prescription_url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_medicine_control_prescription_url",
                schema: "public",
                table: "medicine_control");
        }
    }
}
