using Microsoft.EntityFrameworkCore.Migrations;

namespace e_class.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID1",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectID2",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectID3",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectID4",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectID2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectID3",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectID4",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
