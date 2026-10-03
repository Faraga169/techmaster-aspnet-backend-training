using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 3, 15, 17, 3, 979, DateTimeKind.Utc).AddTicks(7319));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 303, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 303, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 8, 41, 20, 304, DateTimeKind.Utc).AddTicks(257));
        }
    }
}
