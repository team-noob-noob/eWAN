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
    [Migration("20200530100920_IntialCreate")]
    partial class IntialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("eWAN.Domains.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("eWAN.Infrastructure.Database.Entities.User", b =>
                {
                    b.HasBaseType("eWAN.Domains.User.User");

                    b.HasDiscriminator().HasValue("User");
                });
#pragma warning restore 612, 618
        }
    }
}
