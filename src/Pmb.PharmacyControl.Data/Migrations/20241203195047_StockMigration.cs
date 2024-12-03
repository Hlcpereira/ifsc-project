using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class StockMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicine_stock",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    HealthUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicine_stock_health_nit_HealthUnitId",
                        column: x => x.HealthUnitId,
                        principalSchema: "public",
                        principalTable: "health_nit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_stock_medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "public",
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicine_stock_HealthUnitId",
                schema: "public",
                table: "medicine_stock",
                column: "HealthUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_stock_MedicineId",
                schema: "public",
                table: "medicine_stock",
                column: "MedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine_stock",
                schema: "public");
        }
    }
}
