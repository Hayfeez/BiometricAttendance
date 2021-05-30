﻿// <auto-generated />
using System;
using AttendanceLibrary.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AttendanceLibrary.Migrations.Sqlite
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("AttendanceLibrary.Model.AppSetting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatabaseServer")
                        .HasColumnType("TEXT");

                    b.Property<string>("DbPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("DbUsername")
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoBase64")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondaryColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppSettings");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.AppSync", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SyncDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SystemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppSyncs");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.Attendance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseRegistrationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateMarked")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LevelId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.CourseRegistration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("TEXT");

                    b.Property<string>("LevelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegisteredBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionSemesterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CourseRegistration");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.PersonTitle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PersonTitle");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.ServerSetting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServerSettings");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.SessionSemester", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Semester")
                        .HasColumnType("TEXT");

                    b.Property<string>("Session")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SessionSemester");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StaffCourse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StaffCourse");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StaffDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSuperAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Othername")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PasswordChanged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("TitleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StaffFingerprint", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Fingerprint")
                        .HasColumnType("BLOB");

                    b.Property<string>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StaffFingerprint");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StudentDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateGraduated")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("GraduatedSessionId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGraduated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("MatricNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Othername")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudentDetail");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StudentFinger", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("FingerTemplate")
                        .HasColumnType("BLOB");

                    b.Property<string>("StudentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudentFinger");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.StudentLevel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Level")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudentLevel");
                });

            modelBuilder.Entity("AttendanceLibrary.Model.SystemSetting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfFinger")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SuperAdminEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuperAdminFirstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuperAdminLastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuperAdminNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuperAdminPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserDefaultPassword")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
