using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MultipleRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_User_Id",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_User_Id",
                table: "UserRoles",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_User_Id",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_User_Id",
                table: "UserRoles",
                column: "User_Id",
                unique: true);
        }
    }
}
