using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyinTracksessionconstrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeetingLink",
                table: "TrackSessions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeetingLink",
                table: "TrackSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
