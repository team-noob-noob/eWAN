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
    [Migration("20200608113822_AddUserRoles")]
    partial class AddUserRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eWAN.Domains.Role.Role", b =>
                {
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

            modelBuilder.Entity("eWAN.Domains.Role.Role", b =>
                {
                    b.HasOne("eWAN.Infrastructure.Database.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });
#pragma warning restore 612, 618
        }
    }
}
