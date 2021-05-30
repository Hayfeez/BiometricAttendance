using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.SqlServer
{
    public partial class AddAppSettingsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffNumber",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffNumber",
                table: "User");
        }
    }
}
