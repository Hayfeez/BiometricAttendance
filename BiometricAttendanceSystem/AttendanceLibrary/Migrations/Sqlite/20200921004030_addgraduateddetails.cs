using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.Sqlite
{
    public partial class addgraduateddetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateGraduated",
                table: "StudentDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GraduatedSessionId",
                table: "StudentDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateGraduated",
                table: "StudentDetail");

            migrationBuilder.DropColumn(
                name: "GraduatedSessionId",
                table: "StudentDetail");
        }
    }
}
