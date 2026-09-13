using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drill_01_DbContext___First_Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsProfile_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Farag", true },
                    { 2, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@example.com", "Mohamed Ali", true },
                    { 3, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "amna@example.com", "Amna Ali", true }
                });

            migrationBuilder.InsertData(
                table: "StudentsProfile",
                columns: new[] { "Id", "Address", "DateOfBirth", "EmergencyPhone", "NationalId", "StudentId" },
                values: new object[,]
                {
                    { 1, "Cairo, Egypt", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01012345678", 29801011234567L, 1 },
                    { 2, "Giza, Egypt", new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "01112345678", 29902021234568L, 2 },
                    { 3, "Alexandria, Egypt", new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "01212345678", 30003031234569L, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsProfile_StudentId",
                table: "StudentsProfile",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsProfile");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
