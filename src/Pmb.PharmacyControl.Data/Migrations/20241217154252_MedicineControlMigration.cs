using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class MedicineControlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicine_control",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    PharmaceuticalId = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    prescription_url = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_control", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicine_control_medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "public",
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_control_pharmaceutical_PharmaceuticalId",
                        column: x => x.PharmaceuticalId,
                        principalSchema: "public",
                        principalTable: "pharmaceutical",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicine_control_MedicineId",
                schema: "public",
                table: "medicine_control",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_control_PharmaceuticalId",
                schema: "public",
                table: "medicine_control",
                column: "PharmaceuticalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine_control",
                schema: "public");
        }
    }
}
