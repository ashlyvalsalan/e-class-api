using Microsoft.EntityFrameworkCore.Migrations;

namespace e_class.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherID",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherID",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectID",
                table: "Teachers",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubjectID",
                table: "Teachers",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubjectID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SubjectID",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherID",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherID",
                table: "Subjects",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherID",
                table: "Subjects",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
