using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackSessionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByInstructorId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackSessions_Instructors_CreatedByInstructorId",
                        column: x => x.CreatedByInstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackSessions_TrainingTracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 31, 40, 413, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.CreateIndex(
                name: "IX_TrackSessions_CreatedByInstructorId",
                table: "TrackSessions",
                column: "CreatedByInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackSessions_TrackId",
                table: "TrackSessions",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackSessions");

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9281));
        }
    }
}
