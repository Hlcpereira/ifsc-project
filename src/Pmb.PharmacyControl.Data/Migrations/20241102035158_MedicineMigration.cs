using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class MedicineMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "medicine",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    control_level = table.Column<short>(type: "smallint", nullable: false),
                    integration_url = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine",
                schema: "public");
        }
    }
}
