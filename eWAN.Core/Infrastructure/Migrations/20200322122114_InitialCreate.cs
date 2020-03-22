using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false),
                    deletedAt = table.Column<DateTime>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    details_firstName = table.Column<string>(nullable: true),
                    details_middleName = table.Column<string>(nullable: true),
                    details_lastName = table.Column<string>(nullable: true),
                    contacts_emailAddress = table.Column<string>(nullable: true),
                    contacts_mobileNumber_countryCode = table.Column<string>(nullable: true),
                    contacts_mobileNumber_areaCode = table.Column<string>(nullable: true),
                    contacts_mobileNumber_extension = table.Column<string>(nullable: true),
                    contacts_homeAddress_street = table.Column<string>(nullable: true),
                    contacts_homeAddress_barangay = table.Column<string>(nullable: true),
                    contacts_homeAddress_subdivision = table.Column<string>(nullable: true),
                    contacts_homeAddress_city = table.Column<string>(nullable: true),
                    contacts_homeAddress_region = table.Column<string>(nullable: true),
                    contacts_homeAddress_zip = table.Column<string>(nullable: true),
                    guardian_name = table.Column<string>(nullable: true),
                    guardian_mobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
