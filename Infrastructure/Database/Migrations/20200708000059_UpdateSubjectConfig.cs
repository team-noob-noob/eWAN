using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateSubjectConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Subjects_SubjectId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SubjectId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "EnrolledSubjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledSubjects_SubjectId",
                table: "EnrolledSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledSubjects_Subjects_SubjectId",
                table: "EnrolledSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledSubjects_Subjects_SubjectId",
                table: "EnrolledSubjects");

            migrationBuilder.DropIndex(
                name: "IX_EnrolledSubjects_SubjectId",
                table: "EnrolledSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "EnrolledSubjects");

            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "User",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SubjectId",
                table: "User",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Subjects_SubjectId",
                table: "User",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
