using Microsoft.EntityFrameworkCore.Migrations;

namespace e_class.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Tutorials_TutorialID",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Assignments_AssignmentlID",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Chapters_ChapterID",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubjectID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SubjectID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ChapterID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_AssignmentlID",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TutorialID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ChapterID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AssignmentlID",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "TutorialID",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChapterID",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentlID",
                table: "Chapters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutorialID",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectID",
                table: "Teachers",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ChapterID",
                table: "Subjects",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_AssignmentlID",
                table: "Chapters",
                column: "AssignmentlID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TutorialID",
                table: "Assignments",
                column: "TutorialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Tutorials_TutorialID",
                table: "Assignments",
                column: "TutorialID",
                principalTable: "Tutorials",
                principalColumn: "TutorialID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Assignments_AssignmentlID",
                table: "Chapters",
                column: "AssignmentlID",
                principalTable: "Assignments",
                principalColumn: "AssignmentlID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Chapters_ChapterID",
                table: "Subjects",
                column: "ChapterID",
                principalTable: "Chapters",
                principalColumn: "ChapterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubjectID",
                table: "Teachers",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
