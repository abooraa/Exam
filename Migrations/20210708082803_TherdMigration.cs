using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class TherdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationState",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationState",
                table: "Activities");
        }
    }
}
