using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClassTeacherID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassTeachers",
                table: "ClassTeachers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClassTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassTeachers",
                table: "ClassTeachers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_ClassId",
                table: "ClassTeachers",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassTeachers",
                table: "ClassTeachers");

            migrationBuilder.DropIndex(
                name: "IX_ClassTeachers_ClassId",
                table: "ClassTeachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassTeachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassTeachers",
                table: "ClassTeachers",
                columns: new[] { "ClassId", "TeacherId" });
        }
    }
}
