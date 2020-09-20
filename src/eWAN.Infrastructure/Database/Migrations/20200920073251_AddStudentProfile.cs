using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eWAN.Infrastructure.Migrations
{
    public partial class AddStudentProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledProgram_User_Student_Id",
                table: "EnrolledProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledSubjects_User_User_Id",
                table: "EnrolledSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Sections_AssignedSectionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AssignedSectionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AssignedSectionId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    deletedAt = table.Column<DateTime>(nullable: true),
                    AssignedSectionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Sections_AssignedSectionId",
                        column: x => x.AssignedSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AssignedSectionId",
                table: "Students",
                column: "AssignedSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledProgram_Students_Student_Id",
                table: "EnrolledProgram",
                column: "Student_Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledSubjects_Students_User_Id",
                table: "EnrolledSubjects",
                column: "User_Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledProgram_Students_Student_Id",
                table: "EnrolledProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledSubjects_Students_User_Id",
                table: "EnrolledSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AssignedSectionId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AssignedSectionId",
                table: "User",
                column: "AssignedSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledProgram_User_Student_Id",
                table: "EnrolledProgram",
                column: "Student_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledSubjects_User_User_Id",
                table: "EnrolledSubjects",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Sections_AssignedSectionId",
                table: "User",
                column: "AssignedSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
