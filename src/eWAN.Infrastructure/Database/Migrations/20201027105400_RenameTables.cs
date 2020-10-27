using Microsoft.EntityFrameworkCore.Migrations;

namespace eWAN.Infrastructure.Database.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_User_Applicant_Id",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_User_Staff_Id",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_User_InstructorId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_User_Id",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_Applicant_Id",
                table: "Applications",
                column: "Applicant_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_Staff_Id",
                table: "Applications",
                column: "Staff_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_InstructorId",
                table: "Sessions",
                column: "InstructorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_User_Id",
                table: "UserRoles",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_Applicant_Id",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_Staff_Id",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_InstructorId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_User_Id",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_User_Applicant_Id",
                table: "Applications",
                column: "Applicant_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_User_Staff_Id",
                table: "Applications",
                column: "Staff_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_User_InstructorId",
                table: "Sessions",
                column: "InstructorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_User_Id",
                table: "UserRoles",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
