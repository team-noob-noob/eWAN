using Microsoft.EntityFrameworkCore.Migrations;

namespace eWAN.Infrastructure.Database.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Programs_Program_Id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Program_Id",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCourse_Id",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Programs_Program_Id",
                table: "Courses",
                column: "Program_Id",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Programs_Program_Id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Program_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCourse_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Programs_Program_Id",
                table: "Courses",
                column: "Program_Id",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
