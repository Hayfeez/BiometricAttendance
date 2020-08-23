using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceLibrary.Migrations.SqlServer
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSyncs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SystemId = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    SyncDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSyncs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CourseRegistrationId = table.Column<string>(nullable: true),
                    MarkedBy = table.Column<string>(nullable: true),
                    DateMarked = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: true),
                    LevelId = table.Column<string>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseRegistration",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SessionSemesterId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    LevelId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    RegisteredBy = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegistration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTitle",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionSemester",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Session = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSemester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffCourse",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    DateAssigned = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MatricNo = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Othername = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    IsGraduated = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentFinger",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    FingerTemplate = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentLevel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NoOfFinger = table.Column<int>(nullable: false),
                    SuperAdminLastname = table.Column<string>(nullable: true),
                    SuperAdminFirstname = table.Column<string>(nullable: true),
                    SuperAdminEmail = table.Column<string>(nullable: true),
                    SuperAdminPassword = table.Column<string>(nullable: true),
                    SuperAdminNo = table.Column<string>(nullable: true),
                    UserDefaultPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StaffNo = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Othername = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    TitleId = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    PasswordChanged = table.Column<bool>(nullable: false),
                    IsSuperAdmin = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSyncs");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseRegistration");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "PersonTitle");

            migrationBuilder.DropTable(
                name: "SessionSemester");

            migrationBuilder.DropTable(
                name: "StaffCourse");

            migrationBuilder.DropTable(
                name: "StudentDetail");

            migrationBuilder.DropTable(
                name: "StudentFinger");

            migrationBuilder.DropTable(
                name: "StudentLevel");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
