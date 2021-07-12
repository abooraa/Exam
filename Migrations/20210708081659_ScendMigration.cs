using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class ScendMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Activities_TheActivityId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_UserId",
                table: "Participants",
                newName: "IX_Participants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_TheActivityId",
                table: "Participants",
                newName: "IX_Participants_TheActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activities_TheActivityId",
                table: "Participants",
                column: "TheActivityId",
                principalTable: "Activities",
                principalColumn: "TheActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_TheActivityId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_UserId",
                table: "Participant",
                newName: "IX_Participant_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_TheActivityId",
                table: "Participant",
                newName: "IX_Participant_TheActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Activities_TheActivityId",
                table: "Participant",
                column: "TheActivityId",
                principalTable: "Activities",
                principalColumn: "TheActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
