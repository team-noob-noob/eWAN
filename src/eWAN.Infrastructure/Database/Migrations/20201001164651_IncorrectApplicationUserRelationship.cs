using Microsoft.EntityFrameworkCore.Migrations;

namespace eWAN.Infrastructure.Database.Migrations
{
    public partial class IncorrectApplicationUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Manual
            migrationBuilder.Sql(@"ALTER TABLE `Applications` DROP FOREIGN KEY `FK_Applications_User_Applicant_Id`; ");
            
            migrationBuilder.DropIndex(
                name: "IX_Applications_Applicant_Id",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Applicant_Id",
                table: "Applications",
                column: "Applicant_Id");

            // Manual
            migrationBuilder.Sql(@"ALTER TABLE `Applications` ADD CONSTRAINT `FK_Applications_User_Applicant_Id` FOREIGN KEY (`Applicant_Id`) REFERENCES `user` (`Id`) ON DELETE RESTRICT; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Manual
            migrationBuilder.Sql(@"ALTER TABLE `Applications` DROP FOREIGN KEY `FK_Applications_User_Applicant_Id`; ");

            migrationBuilder.DropIndex(
                name: "IX_Applications_Applicant_Id",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Applicant_Id",
                table: "Applications",
                column: "Applicant_Id",
                unique: true);

            // Manual 
            migrationBuilder.Sql(@"ALTER TABLE `Applications` ADD CONSTRAINT `FK_Applications_User_Applicant_Id` FOREIGN KEY (`Applicant_Id`) REFERENCES `user` (`Id`) ON DELETE RESTRICT; ");
        }
    }
}
