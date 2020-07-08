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
    [Migration("20200708000059_UpdateSubjectConfig")]
    partial class UpdateSubjectConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eWAN.Domains.Application.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("applicantId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("reason")
                        .HasColumnType("text");

                    b.Property<string>("staffId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("applicantId");

                    b.HasIndex("staffId");

                    b.ToTable("Applications");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Application");
                });

            modelBuilder.Entity("eWAN.Domains.Role.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("userId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("UserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Role");
                });

            modelBuilder.Entity("eWAN.Domains.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ParentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SubjectId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("enrolledStudentId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("grade")
                        .HasColumnType("text");

                    b.Property<string>("subjectId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("enrolledStudentId");

                    b.HasIndex("subjectId");

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

                    b.Property<string>("InstructorId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoomId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

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

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Application", b =>
                {
                    b.HasBaseType("eWAN.Domains.Application.Application");

                    b.HasDiscriminator().HasValue("Application");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Role", b =>
                {
                    b.HasBaseType("eWAN.Domains.Role.Role");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.User", b =>
                {
                    b.HasBaseType("eWAN.Domains.User.User");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("eWAN.Domains.Application.Application", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "applicant")
                        .WithMany()
                        .HasForeignKey("applicantId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "staff")
                        .WithMany()
                        .HasForeignKey("staffId");
                });

            modelBuilder.Entity("eWAN.Domains.Role.Role", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Course", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Program", null)
                        .WithMany("Courses")
                        .HasForeignKey("CourseId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Course", null)
                        .WithMany("Prerequisites")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.EnrolledSubject", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Subject", null)
                        .WithMany("Students")
                        .HasForeignKey("SubjectId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "enrolledStudent")
                        .WithMany()
                        .HasForeignKey("enrolledStudentId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("subjectId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Session", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Subject", null)
                        .WithMany("Sessions")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.Subject", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("eWAN.Infrastructure.Database.Entities.Semester", null)
                        .WithMany("OpenCourses")
                        .HasForeignKey("SemesterId");
                });
#pragma warning restore 612, 618
        }
    }
}
