using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClasssToClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Schools_SchoolId",
                table: "Classs");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_Classs_ClassId",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classs_ClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classs",
                table: "Classs");

            migrationBuilder.RenameTable(
                name: "Classs",
                newName: "Classes");

            migrationBuilder.RenameIndex(
                name: "IX_Classs_SchoolId",
                table: "Classes",
                newName: "IX_Classes_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_Classes_ClassId",
                table: "ClassTeachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_Classes_ClassId",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Classs");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_SchoolId",
                table: "Classs",
                newName: "IX_Classs_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classs",
                table: "Classs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classs_Schools_SchoolId",
                table: "Classs",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_Classs_ClassId",
                table: "ClassTeachers",
                column: "ClassId",
                principalTable: "Classs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classs_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
