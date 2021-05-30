using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.Sqlite
{
    public partial class AddAppSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffNumber",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "StaffNo",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    LogoBase64 = table.Column<string>(nullable: true),
                    PrimaryColor = table.Column<string>(nullable: true),
                    SecondaryColor = table.Column<string>(nullable: true),
                    DatabaseName = table.Column<string>(nullable: true),
                    DatabaseServer = table.Column<string>(nullable: true),
                    DbUsername = table.Column<string>(nullable: true),
                    DbPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropColumn(
                name: "StaffNo",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "StaffNumber",
                table: "User",
                type: "TEXT",
                nullable: true);
        }
    }
}
