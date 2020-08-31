using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.Sqlite
{
    public partial class StaffFinger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "StaffFinger",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: true),
                    Fingerprint = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffFinger", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffFinger");

        }
    }
}
