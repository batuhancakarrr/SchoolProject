using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations.UniversityDb;

/// <inheritdoc />
public partial class AddUserTable : Migration {
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder) {
		migrationBuilder.CreateTable(
			name: "Users",
			columns: table => new {
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table => {
				table.PrimaryKey("PK_Users", x => x.Id);
			});
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder) {
		migrationBuilder.DropTable(
			name: "UniversityDepartments");

		migrationBuilder.DropTable(
			name: "Users");

		migrationBuilder.DropTable(
			name: "Departments");

		migrationBuilder.DropTable(
			name: "Universities");

		migrationBuilder.DropTable(
			name: "Types");
	}
}
