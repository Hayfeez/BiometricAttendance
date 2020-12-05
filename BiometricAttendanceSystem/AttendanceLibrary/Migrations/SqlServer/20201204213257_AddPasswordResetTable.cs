using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.Sqlserver
{
    public partial class AddPasswordResetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordReset",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RequestingSystemId = table.Column<string>(nullable: true),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    IsReset = table.Column<bool>(nullable: false),
                    ResetBy = table.Column<string>(nullable: true),
                    DateReset = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordReset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordReset");
        }
    }
}
