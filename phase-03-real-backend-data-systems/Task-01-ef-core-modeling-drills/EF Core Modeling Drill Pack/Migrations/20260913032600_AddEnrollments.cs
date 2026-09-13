using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drill_01_DbContext___First_Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "EnrollmentDate", "FinalGrade", "Status", "StudentId", "TrackId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.5m, "Active", 1, 1 },
                    { 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Pending", 1, 2 },
                    { 3, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.0m, "Completed", 2, 1 },
                    { 4, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.5m, "Active", 2, 3 },
                    { 5, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.0m, "Completed", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_TrackId",
                table: "Enrollments",
                columns: new[] { "StudentId", "TrackId" },
                unique: true,
                filter: "[Status] = 'Active'");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TrackId",
                table: "Enrollments",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");
        }
    }
}
