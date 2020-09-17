using Microsoft.EntityFrameworkCore.Migrations;

namespace e_class.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubjectID",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_SubjectID",
                table: "Students",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectID",
                table: "Students",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
