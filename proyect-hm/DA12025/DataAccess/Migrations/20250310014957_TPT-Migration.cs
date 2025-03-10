using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class TPTMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Salary" },
                values: new object[] { 2, 10000f });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "StudentId" },
                values: new object[] { 1, 216743 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "PersonType",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Persons",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PersonType", "Salary" },
                values: new object[] { 2, "Professor Name", "Professor", 10000f });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PersonType", "StudentId" },
                values: new object[] { 1, "Student Name", "Student", 216743 });
        }
    }
}
