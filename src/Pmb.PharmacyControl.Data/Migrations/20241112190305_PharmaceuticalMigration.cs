using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class PharmaceuticalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "integration_url",
                schema: "public",
                table: "medicine",
                newName: "name");

            migrationBuilder.CreateTable(
                name: "pharmaceutical",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: true),
                    register_number = table.Column<string>(type: "varchar", nullable: true),
                    health_unit_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmaceutical", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pharmaceutical",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "medicine",
                newName: "integration_url");
        }
    }
}
