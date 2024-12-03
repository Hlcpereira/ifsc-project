using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pmb.PharmacyControl.Data.Migrations
{
    public partial class HealthUnitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "health_nit",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: true),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", nullable: true),
                    complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    zip_code = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_health_nit", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "health_nit",
                schema: "public");
        }
    }
}
