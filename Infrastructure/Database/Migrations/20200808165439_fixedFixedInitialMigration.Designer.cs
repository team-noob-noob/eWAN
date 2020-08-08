﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eWAN.Infrastructure.Database;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EwanContext))]
    [Migration("20200808165439_fixedFixedInitialMigration")]
    partial class fixedFixedInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Application", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Applicant_Id")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Staff_Id")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("reason")
                        .HasColumnType("text");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Applicant_Id")
                        .IsUnique();

                    b.HasIndex("Staff_Id")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ParentCourse_Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Program_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ParentCourse_Id");

                    b.HasIndex("Program_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Program_Id")
                        .HasColumnType("int");

                    b.Property<string>("Student_Id")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Program_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("EnrolledProgram");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Subject_Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("User_Id")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("grade")
                        .HasColumnType("text");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Subject_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("EnrolledSubjects");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("User_Id")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Semester", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsOpenForEnrollment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("InstructorId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoomId")
                        .HasColumnType("varchar(767)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("SubjectId")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Subject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("SemesterId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("AssignedSectionId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AssignedSectionId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Application", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "applicant")
                        .WithOne()
                        .HasForeignKey("eWAN.Infrastructure.Database.Entities.Application", "Applicant_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "staff")
                        .WithOne()
                        .HasForeignKey("eWAN.Infrastructure.Database.Entities.Application", "Staff_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Course", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Course", "Prerequesite")
                        .WithMany("Prerequisites")
                        .HasForeignKey("ParentCourse_Id");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Program", "AssignedProgram")
                        .WithMany("Courses")
                        .HasForeignKey("Program_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledProgram", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Program", "Program")
                        .WithMany("EnrolledStudentsInProgram")
                        .HasForeignKey("Program_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "Student")
                        .WithMany("EnrolledPrograms")
                        .HasForeignKey("Student_Id");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledSubject", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Subject", "subject")
                        .WithMany("StudentsEnrolled")
                        .HasForeignKey("Subject_Id");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "enrolledStudent")
                        .WithMany("EnrolledSubjects")
                        .HasForeignKey("User_Id");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Role", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "user")
                        .WithOne("AssignedRole")
                        .HasForeignKey("eWAN.Infrastructure.Database.Entities.Role", "User_Id");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Session", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Room", "Room")
                        .WithMany("Schedule")
                        .HasForeignKey("RoomId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Subject", "Subject")
                        .WithMany("Sessions")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Subject", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Course", "Course")
                        .WithMany("OpenedSubjects")
                        .HasForeignKey("CourseId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Semester", "Semester")
                        .WithMany("OpenCourses")
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.User", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Section", "AssignedSection")
                        .WithMany("Students")
                        .HasForeignKey("AssignedSectionId");
                });
#pragma warning restore 612, 618
        }
    }
}
